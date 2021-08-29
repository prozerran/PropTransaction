import React, { Component } from 'react';
import { Login } from './Login';

export class TransactionMod extends Component {
    static displayName = TransactionMod.name;

    constructor(props) {
        super(props);
        this.state = { transactionId: '', propertyId: '', userId: '', transactionDate: '', loading: true };

        // properties change
        this.handlePidChange = this.handlePidChange.bind(this);
        this.handleUidChange = this.handleUidChange.bind(this);
        this.handleTdtChange = this.handleTdtChange.bind(this);

        // del and submits
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
        this.handleDelChange = this.handleDelChange.bind(this);
        this.handleDelSubmit = this.handleDelSubmit.bind(this);
    }

    componentDidMount() {
        this.handleTransactionMod();
    }

    handlePidChange(event) {
        this.setState({ propertyId: event.target.value });
    }

    handleUidChange(event) {
        this.setState({ userId: event.target.value });
    }

    handleTdtChange(event) {
        this.setState({ transactionDate: event.target.value });
    }

    handleDelChange(event) {
        this.setState({ transactionId: event.target.value });
    }

    async handleAddSubmit(event) {
        var sessionId = Login.sessionId.get('sessionId');

        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'Authorization': sessionId },
            body: JSON.stringify({
                PropertyId: this.state.propertyId,
                UserId: this.state.userId,
                TransactionDate: this.state.transactionDate
            })
        };
        const response = await fetch('/TransactionMod', addReq);

        if (!response.ok) {
            alert("Please log in first.");
        }
    }

    async handleDelSubmit(event) {
        var sessionId = Login.sessionId.get('sessionId');

        const delReq = {
            method: 'DELETE',
            headers: { 'Authorization': sessionId }
        };
        const response = await fetch('/TransactionMod/' + this.state.transactionId, delReq);

        if (!response.ok) {
            alert("Please log in first.");
        }
    }

    render() {

        //// NO CLUE WHY THIS DOESNT WORK
        //if (this.state.loading) {
        //    return (<p><em>Loading...</em></p>);
        //}

        return (
            <div>
                <h3>Add Transaction</h3>
                <form onSubmit={this.handleAddSubmit}>
                    <label>Property Id</label>
                    <input type="number" value={this.state.propertyId} onChange={this.handlePidChange} /><br />
                    <label>User Id</label>
                    <input type="number" value={this.state.userId} onChange={this.handleUidChange} /><br />
                    <label>Transaction Date</label>
                    <input type="number" value={this.state.transactionDate} onChange={this.handleTdtChange} /><br />
                    <input type="submit" value="Add" />
                </form>

                <hr />
                <h3>Edit Transaction</h3><br />
                <label>Not yet Implemented. Please use Swagger to modify.</label><br />
                <a href="https://localhost:44334/swagger/index.html">Modify in TransactionMod PUT method</a>

                <hr />
                <h3>Del Transaction</h3><br />
                <label>This really should be a drop down combo box</label>
                <form onSubmit={this.handleDelSubmit}>
                    <label>Transaction Id</label>
                    <input type="number" value={this.state.transactionId} onChange={this.handleDelChange} /><br />
                    <input type="submit" value="Del" />
                </form>
            </div>
        );
    }

    async handleTransactionMod() {
        var sessionId = Login.sessionId.get('sessionId');

        const req = {
            method: 'GET',
            headers: { 'Authorization': sessionId }
        };

        const response = await fetch('transactionmod', req);

        if (response.ok) {
            this.setState({ loading: false });
        } else {
            alert("Please log in first.");
        }
    }
}
