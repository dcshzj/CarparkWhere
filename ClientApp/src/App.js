import React, { Component } from 'react';
import { Route } from 'react-router';
import { PrivateRoute } from './components/PrivateRoute';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Carparks } from './components/Carparks';
import { Login } from './components/Login';
import { Signup } from './components/Signup';
import { Profile } from './components/Profile';
import { Users } from './components/Users';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <PrivateRoute exact path='/carparks' component={Carparks} />
                <PrivateRoute exact path='/profile' component={Profile} />
                <PrivateRoute exact path='/users' component={Users} />
                <Route exact path='/login' component={Login} />
                <Route exact path='/signup' component={Signup} />
            </Layout>
        );
    }
}
