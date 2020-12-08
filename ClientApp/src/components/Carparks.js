import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { authHeader, authService } from '../helpers/Authentication';
import { handleResponse } from '../helpers/ResponseHandler';

export class Carparks extends Component {
    static displayName = Carparks.name;

    constructor(props) {
        super(props);
        this.state = { carparks: [], loading: true };

        // Redirect back to login page if user is not yet logged in
        if (!authService.currentUserValue) {
            <Redirect to={{ pathname: '/login' }} />
        }
    }

    componentDidMount() {
        this.populateCarparksData();
    }

    static renderCarparksTable(carparks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Carpark number</th>
                        <th>Total lots</th>
                        <th>Available lots</th>
                        <th>Lot type</th>
                    </tr>
                </thead>
                <tbody>
                    {carparks.map(carpark =>
                        <tr key={carpark.number}>
                            <td>{carpark.number}</td>
                            <td>{carpark.totalLots}</td>
                            <td>{carpark.availableLots}</td>
                            <td>{carpark.lotType}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Carparks.renderCarparksTable(this.state.carparks);

        return (
            <div>
                <h1 id="tabelLabel" >Carparks in Singapore</h1>
                <p>This table contains a list of all carparks in Singapore.</p>
                {contents}
            </div>
        );
    }

    async populateCarparksData() {
        const requestOptions = { method: 'GET', headers: authHeader() }
        const response = await fetch('api/carpark', requestOptions).then(handleResponse);
        this.setState({ carparks: response, loading: false });
    }
}
