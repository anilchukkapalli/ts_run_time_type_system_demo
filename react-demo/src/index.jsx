import React from 'react';
import ReactDOM from 'react-dom';
import Timer from './timer.jsx';

//ReactDOM.render(<div>HELLO REACT WORLD</div>, document.getElementById('root'));

ReactDOM.render(
       <React.StrictMode>
         <Timer />
       </React.StrictMode>,
       document.getElementById('root'),
    );