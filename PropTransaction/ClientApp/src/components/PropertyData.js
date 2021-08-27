import React, { Component } from 'react';

export class PropertyData extends Component {
  static displayName = PropertyData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populatePropertyData();
  }

  static renderPropertyTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>PropertyId</th>
            <th>PropertyName</th>
            <th>IsAvaliable</th>
            <th>SalePrice</th>
            <th>LeasePrice</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.propertyId}>
                  <td>{forecast.propertyId}</td>
                  <td>{forecast.propertyName}</td>
                  <td>{forecast.isAvaliable}</td>
                  <td>{forecast.salePrice}</td>
                  <td>{forecast.leasePrice}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : PropertyData.renderPropertyTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Property Data</h1>
        <p>Property Data Page.</p>
        {contents}
      </div>
    );
  }

  async populatePropertyData() {
      const response = await fetch('property');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
