import React, { Component } from 'react';

export class PropertyMod extends Component {
    static displayName = PropertyMod.name;

    constructor(props) {
        super(props);
        this.state = { value: 'The House' };

        this.handleChange = this.handleChange.bind(this);
        this.handleAdd = this.handleAdd.bind(this);
    }

    componentDidMount() {
        //this.populatePropertyMod();
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    async handleAdd(event) {

        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ PropertyName: this.state.value, Bedroom: 6, IsAvaliable: true, SalePrice: 56, LeasePrice: 17000 })
        };
        await fetch('/PropertyMod', addReq);
    }

    render() {
        return (
            <form onSubmit={this.handleAdd}>
                <label>Property Name</label>
                <input type="text" value={this.state.value} onChange={this.handleChange} /><br />
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
