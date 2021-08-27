import React, { Component } from 'react';

export class PropertyMod extends Component {
    static displayName = PropertyMod.name;

    constructor(props) {
        super(props);
        this.state = { items: [], loading: true };
    }

    componentDidMount() {
        this.populatePropertyMod();
    }

    static renderPropertyTable(items) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>PropertyId</th>
                        <th>PropertyName</th>
                        <th>Bedroom</th>
                        <th>IsAvaliable</th>
                        <th>SalePrice</th>
                        <th>LeasePrice</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(data =>
                        <tr key={data.propertyId}>
                            <td>{data.propertyId}</td>
                            <td>{data.propertyName}</td>
                            <td>{data.bedroom}</td>
                            <td>{data.isAvaliable.toString()}</td>
                            <td>{data.salePrice}</td>
                            <td>{data.leasePrice}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PropertyMod.renderPropertyTable(this.state.items);

        return (
            <div>
                <h1 id="tabelLabel" >Property Mod</h1>
                <p>Property Mod Page.</p>
                {contents}
            </div>
        );
    }

    async populatePropertyMod() {
        const response = await fetch('propertymod');
        const data = await response.json();
        this.setState({ items: data, loading: false });
    }
}
