import React, { Component } from 'react';

export class PropertyMod extends Component {
    static displayName = PropertyMod.name;

    constructor(props) {
        super(props);
        this.state = { propertyName: '' };

        this.handleAddChange = this.handleAddChange.bind(this);
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
    }

    componentDidMount() {
        //this.populatePropertyMod();
    }

    handleAddChange(event) {
        this.setState({ propertyName: event.target.value });
    }

    async handleAddSubmit(event) {

        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ PropertyName: this.state.propertyName, Bedroom: 6, IsAvaliable: true, SalePrice: 56, LeasePrice: 17000 })
        };
        await fetch('/PropertyMod', addReq);
    }

    render() {
        return (
            <form onSubmit={this.handleAddSubmit}>
                <label>Property Name</label>
                <input type="text" value={this.state.propertyName} onChange={this.handleAddChange} /><br />
                <input type="submit" value="Add" />
            </form>
        );
    }

    async populatePropertyMod() {
        //const response = await fetch('propertymod');
        //const data = await response.json();
        //this.setState({ items: data, loading: false });
    }
}
