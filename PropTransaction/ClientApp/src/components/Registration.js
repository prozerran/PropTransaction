import React, { Component } from 'react';

export class Registration extends Component {
    static displayName = Registration.name;

    constructor(props) {
        super(props);
        this.state = { email: '', password: '', isAdmin: false };

        // properties change
        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handlePassWChange = this.handlePassWChange.bind(this);
        this.handleAdminChange = this.handleAdminChange.bind(this);

        // del and submits
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
    }

    componentDidMount() {
    }

    handleEmailChange(event) {
        this.setState({ email: event.target.value });
    }

    handlePassWChange(event) {
        this.setState({ password: event.target.value });
    }

    handleAdminChange(event) {
        let boolValue = event.target.value;
        boolValue = JSON.parse(boolValue);
        this.setState({ isAdmin: boolValue });
    }

    async handleAddSubmit(event) {
        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                Email: this.state.email,
                Password: this.state.password,
                IsAdmin: this.state.isAdmin
            })
        };
        await fetch('/registration', addReq);
    }

    render() {
        return (
            <div>
                <h3>Register New User</h3>
                <form onSubmit={this.handleAddSubmit}>
                    <label>Email Id</label>
                    <input type="text" value={this.state.email} onChange={this.handleEmailChange} /><br />
                    <label>Password</label>
                    <input type="password" value={this.state.password} onChange={this.handlePassWChange} /><br />
                    <label>Is Admin</label>
                    <select value={this.state.isAdmin} onChange={this.handleAdminChange}>
                        <option value="false" selected>No</option>
                        <option value="true">Yes</option>
                    </select><br />
                    <input type="submit" value="Add" />
                </form>
            </div>
        );
    }
}
