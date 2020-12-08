import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { authService } from '../helpers/Authentication';

export const PrivateRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={props => {
        const currentUser = authService.currentUserValue;

        // Check if the user is currently logged in, otherwise redirect
        if (!currentUser) {
            return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
        }

        // Authorised, return the original component
        return <Component {...props} />
    }} />
)
