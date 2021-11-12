import React from 'react';
import ReactDOM from 'react-dom';
import {  Route,  BrowserRouter as Router, Redirect, Switch} from 'react-router-dom';

import './index.css';

import Home from './pages/Home/App';
import Consultas from './pages/consultas/Consultas';
import NotFound from './pages/notFound/NotFound.js';
import Login from './pages/Login/login';


import reportWebVitals from './reportWebVitals';


const routing=(
  <Router>
    <div>
      <Switch>
      <Route exact path="/" component={ Home } />
      <Route  path="/consultas" component={ Consultas } />
      <Route  path="/login" component={ Login } />
      <Route  path="/notfound" component={ NotFound } />
      <Redirect to="/notfound" />
      </Switch>
     
    </div>
  </Router>
)

ReactDOM.render(  routing,  document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
