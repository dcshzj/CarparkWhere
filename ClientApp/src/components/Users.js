import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { authHeader, authService } from '../helpers/Authentication';
import { handleResponse } from '../helpers/ResponseHandler';

export class Users extends Component {
    static displayName = Users.name;

    constructor(props) {
        super(props);
        this.state = { allusers: [], loading: true };

        // Redirect back to login page if user is not yet logged in
        if (!authService.currentUserValue) {
            <Redirect to={{ pathname: '/login' }} />
        }
    }

    componentDidMount() {
        this.populateUsersData();
    }

    static renderUsersTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email Address</th>
                        <th>Contact Number</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.firstName}</td>
                            <td>{user.lastName}</td>
                            <td>{user.email}</td>
                            <td>{user.contactNumber}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Users.renderUsersTable(this.state.allusers);

        return (
            <div>
                <h1 id="tabelLabel">All users</h1>
                <p>This table contains all users currently present in this web application.</p>
                {contents}
            </div>
        );
    }

    async populateUsersData() {
        const requestOptions = { method: 'GET', headers: authHeader() }
        const response = await fetch('api/users', requestOptions).then(handleResponse);
        this.setState({ allusers: response, loading: false });
    }
}
