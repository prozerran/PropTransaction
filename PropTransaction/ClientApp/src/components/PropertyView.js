import React, { Component } from 'react';

export class PropertyView extends Component {
    static displayName = PropertyView.name;

    constructor(props) {
        super(props);
        this.state = { items: [], loading: true };
    }

    componentDidMount() {
        this.populatePropertyView();
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
            : PropertyView.renderPropertyTable(this.state.items);

        return (
            <div>
                <h1 id="tabelLabel" >Property View</h1>
                <p>Property View Page.</p>
                {contents}
            </div>
        );
    }

    async populatePropertyView() {
        const response = await fetch('propertyview');
        const data = await response.json();
        this.setState({ items: data, loading: false });
    }
}
