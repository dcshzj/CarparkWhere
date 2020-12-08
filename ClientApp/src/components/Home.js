import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { authService } from '../helpers/Authentication';

export class Home extends Component {
    static displayName = Home.name;

    render () {
        return (
            <div>
                <h1>CarparkWhere: Where got parking space?</h1>
                <p>Wondering where in Singapore is there parking space available? Fret not! This application will tell you all the carparks in Singapore and their available parking space!</p>
                {authService.currentUserValue &&
                    <p>You are currently logged in! <Link to="/carparks">See the carparks list</Link>.</p>
                }
                {!authService.currentUserValue &&
                    <p>Please <Link to="/login">login</Link> or <Link to="/signup">signup</Link> to continue.</p>
                }
            </div>
        );
    }
}
