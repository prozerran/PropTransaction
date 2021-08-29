import React, { Component } from 'react';
import { Login } from './Login';

export class TransactionView extends Component {
    static displayName = TransactionView.name;

    constructor(props) {
        super(props);
        this.state = { items: [], loading: true };
    }

    componentDidMount() {
        this.populateTransactionView();
    }

    static renderTransactionTable(items) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>TransactionId</th>
                        <th>PropertyId</th>
                        <th>UserId</th>
                        <th>TransactionDate</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(data =>
                        <tr key={data.transactionId}>
                            <td>{data.transactionId}</td>
                            <td>{data.propertyId}</td>
                            <td>{data.userId}</td>
                            <td>{data.transactionDate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TransactionView.renderTransactionTable(this.state.items);

        return (
            <div>
                <h1 id="tabelLabel" >Transaction View</h1>
                <p>Transaction View Page.</p>
                {contents}
            </div>
        );
    }

    async populateTransactionView() {

        var sessionId = Login.sessionId.get('sessionId');

        const req = {
            method: 'GET',
            headers: { 'Authorization': sessionId }
        };

        const response = await fetch('transactionview', req);

        if (response.ok) {
            const data = await response.json();
            this.setState({ items: data, loading: false });
        }
        else {
            alert("Please log in first.");
        }
    }
}
