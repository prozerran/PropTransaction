import React, { Component } from 'react';

export class PropertyMod extends Component {
    static displayName = PropertyMod.name;

    constructor(props) {
        super(props);
        this.state = { propertyId: '', propertyName: '', bedroom: 1, isAvaliable: true, salePrice: '', leasePrice: '' };

        // properties change
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleRoomChange = this.handleRoomChange.bind(this);
        this.handleAvalChange = this.handleAvalChange.bind(this);
        this.handleSaleChange = this.handleSaleChange.bind(this);
        this.handleRentChange = this.handleRentChange.bind(this);

        // del and submits
        this.handleAddSubmit = this.handleAddSubmit.bind(this);
        this.handleDelChange = this.handleDelChange.bind(this);
        this.handleDelSubmit = this.handleDelSubmit.bind(this);
    }

    componentDidMount() {
        //this.handlePropertyMod();
    }

    handleNameChange(event) {
        this.setState({ propertyName: event.target.value });
    }

    handleRoomChange(event) {
        this.setState({ bedroom: event.target.value });
    }

    handleAvalChange(event) {
        let boolValue = event.target.value;
        boolValue = JSON.parse(boolValue);
        this.setState({ isAvaliable: boolValue });
    }

    handleSaleChange(event) {
        this.setState({ salePrice: event.target.value });
    }

    handleRentChange(event) {
        this.setState({ leasePrice: event.target.value });
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
                Bedroom: this.state.bedroom,
                IsAvaliable: this.state.isAvaliable,
                SalePrice: this.state.salePrice,
                LeasePrice: this.state.leasePrice
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
                    <input type="text" value={this.state.propertyName} onChange={this.handleNameChange} /><br />
                    <label>Bedrooms</label>
                    <input type="number" value={this.state.bedroom} onChange={this.handleRoomChange} /><br />
                    <label>Is Avaliable</label>
                    <select value={this.state.isAvaliable} onChange={this.handleAvalChange}>
                        <option value="true" selected>Yes</option>
                        <option value="false">No</option>
                    </select><br />
                    <label>Sale Price</label>
                    <input type="number" value={this.state.salePrice} onChange={this.handleSaleChange} /><br />
                    <label>Monthly Lease</label>
                    <input type="number" value={this.state.leasePrice} onChange={this.handleRentChange} /><br />
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
