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
    let { data }:{data: CustomerInfo[]} = useSnapshot(api.key(props.uri));
    return (<div>
        {data.map(e => <CustomerDetail {...e} />)}
    </div>);
  }

function CustomerDetail(props: CustomerInfo): JSX.Element {
    return (
    <div key={props.id}>
        <div>FirstName: {props.firstName}</div>
        <div>LastName: {props.lastName}</div>
        <div>Street: {props.address.street}</div>
        <div>City: {props.address.city}</div>
        <div>State: {props.address.state}</div>
        <div>Zip: {props.address.zip}</div>
        <div>--------------------------</div>
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
