import React, { Component } from 'react';

export class PropertyMod extends Component {
    static displayName = PropertyMod.name;

    constructor(props) {
        super(props);
        this.state = { propertyId: '', propertyName: '' };

        this.handleAddChange = this.handleAddChange.bind(this);
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
        this.handleDelChange = this.handleDelChange.bind(this);
        this.handleDelSubmit = this.handleDelSubmit.bind(this);
    }

    componentDidMount() {
        //this.handlePropertyMod();
    }

    handleAddChange(event) {
        this.setState({ propertyName: event.target.value });
    }

    handleDelChange(event) {
        this.setState({ propertyId: event.target.value });
    }

    async handleAddSubmit(event) {
        const addReq = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                PropertyName: this.state.propertyName,
                Bedroom: 6,
                IsAvaliable: true,
                SalePrice: 56,
                LeasePrice: 17000
            })
        };
        await fetch('/PropertyMod', addReq);
    }

    async handleDelSubmit(event) {
        const delReq = {
            method: 'DELETE',
        };
        await fetch('/PropertyMod/' + this.state.propertyId, delReq);
    }

    render() {
        return (
            <div>
                <h3>Add Property</h3>
                <form onSubmit={this.handleAddSubmit}>
                    <label>Property Name</label>
                    <input type="text" value={this.state.propertyName} onChange={this.handleAddChange} /><br />
                    <input type="submit" value="Add" />
                </form>

                <hr />
                <h3>Del Property</h3>
                <form onSubmit={this.handleDelSubmit}>
                    <label>Property Id</label>
                    <input type="text" value={this.state.propertyId} onChange={this.handleDelChange} /><br />
                    <input type="submit" value="Del" />
                </form>
            </div>
        );
    }

    async handlePropertyMod() {
    }
}
