import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Registration } from './components/Registration';
import { Login } from './components/Login';
import { PropertyMod } from './components/PropertyMod';
import { PropertyView } from './components/PropertyView';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route path='/register-user' component={Registration} />
            <Route path='/login-user' component={Login} />
            <Route path='/property-mod' component={PropertyMod} />
            <Route path='/property-view' component={PropertyView} />
      </Layout>
    );
  }
}
