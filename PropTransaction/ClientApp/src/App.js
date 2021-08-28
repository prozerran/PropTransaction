import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Registration } from './components/Registration';
import { Login } from './components/Login';
import { PropertyMod } from './components/PropertyMod';
import { PropertyView } from './components/PropertyView';
import { Counter } from './components/Counter';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/register-user' component={Registration} />
            <Route path='/login-user' component={Login} />
            <Route path='/property-mod' component={PropertyMod} />
            <Route path='/property-view' component={PropertyView} />
      </Layout>
    );
  }
}
