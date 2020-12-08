import React, {Component} from 'react';
import { Redirect } from 'react-router-dom';
import { authService } from '../helpers/Authentication';

export class Profile extends Component {
    constructor(props) {
        super(props);

        // Redirect back to login page if user is not yet logged in
        if (!authService.currentUserValue) {
            <Redirect to={{ pathname: '/login' }} />
        }
    }

    render() {
        const currentUser = authService.currentUserValue;
        console.log(currentUser);
        return (
            <div>
                <h1>User profile</h1>
                <p>The following are details about the current logged in user:</p>
                <p><b>User ID</b>: {currentUser.id}</p>
                <p><b>First name</b>: {currentUser.firstName}</p>
                <p><b>Last name</b>: {currentUser.lastName}</p>
                <p><b>Email address</b>: {currentUser.email}</p>
                {currentUser.contactNumber &&
                    <p><b>Contact number</b>: {currentUser.contactNumber}</p>
                }
            </div>
        )
    }
}
