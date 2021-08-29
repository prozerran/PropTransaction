import React, { Component } from 'react';
import Cookies from 'universal-cookie';

const cookies = new Cookies();

export class Login extends Component {
    static displayName = Login.name;
    static sessionId = cookies;

    constructor(props) {
        super(props);
        this.state = { email: '', password: '' };

        // properties change
        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handlePassWChange = this.handlePassWChange.bind(this);

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

    async handleAddSubmit(event) {
        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                Email: this.state.email,
                Password: this.state.password
            })
        };
        const response = await fetch('/login', addReq);

        if (!response.ok) {
            alert("FAILED TO LOGIN");
        }
        else {
            const jsonstr = await response.json();

            // lets try to use cookies to set global sessionId
            cookies.set('sessionId', jsonstr.sessionId, { path: '/' });

            alert("LOGIN OK");
        }
    }

    render() {
        return (
            <div>
                <h3>Login User</h3>
                <form onSubmit={this.handleAddSubmit}>
                    <label>Email Id</label>
                    <input type="text" value={this.state.email} onChange={this.handleEmailChange} /><br />
                    <label>Password</label>
                    <input type="password" value={this.state.password} onChange={this.handlePassWChange} /><br />
                    <input type="submit" value="Login" />
                </form>
            </div>
        );
    }
}
