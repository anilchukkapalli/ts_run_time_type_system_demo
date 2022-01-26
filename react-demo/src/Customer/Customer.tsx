import React, { useState, useEffect } from 'react';
import { Suspense } from 'react';
import { createMirror, useSnapshot } from 'react-zen';

// A mirror automatically fetches data as it is required, and purges it
// once it is no longer in use.
const BaseURL = 'https://localhost:7280/';
const api = createMirror(async url => {
    let response = await fetch(BaseURL+url)
    return response.json()
  });

type CustomerInfo = {
    id: string,
    firstName: string,
    lastName: string,
    address: Address
};

type Address = {
    street: string,
    city: string,
    state: string,
    zip: string
}

type CustomerProps = {
    readonly uri: string
}

function Customers(props: CustomerProps): JSX.Element {
    let { data } = useSnapshot(api.key(props.uri));
    return (<div>
        {data.map(e => <div key={e.id}>
                <div>FirstName: {e.firstName}</div>
                <div>LastName: {e.lastName}</div> 
                <div>Street: {e.address.street}</div>
                <div>City: {e.address.city}</div>
                <div>State: {e.address.state}</div>
                <div>Zip: {e.address.zip}</div>
                <div>--------------------------</div>
            </div>)}
    </div>);
  }


interface AppProps {}

function Customer({}: AppProps) {
    return (
    <div className="App">
        <Customers uri='customers' />
    </div>
  );
}

export default Customer;
