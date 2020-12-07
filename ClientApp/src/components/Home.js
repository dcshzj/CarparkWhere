import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render () {
        return (
            <div>
                <h1>CarparkWhere: Where got parking space?</h1>
                <p>Wondering where in Singapore is there parking space available? Fret not! This application will tell you all the carparks in Singapore and their available parking space!</p>
            </div>
        );
    }
}
