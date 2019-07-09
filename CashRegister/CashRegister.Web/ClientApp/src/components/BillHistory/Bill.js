import React, { Component } from "react";

export class Bill extends Component {
  constructor(props) {
    super(props);
    this.state = {
      bill: this.props.displayedBill
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({ bill: nextProps.displayedBill });
  }

  render() {
    const { bill } = this.state;

    return (
      <div className="bill">
        <h5>Bill - {bill.guid}</h5>
        <p>Cash Register: {bill.register}</p>
        <p>Cashier: {bill.cashier}</p>

        {/* <div className="products-list">
          <ul className="t-a-start">
            <li>Name:</li>
            <br />
            {bill.products.map((product, index) => (
              <li key={index}>{product.type}</li>
            ))}
          </ul>

          <ul>
            <li>Amount:</li>
            <br />
            {bill.products.map((product, index) => (
              <li key={index}>{product.amount}</li>
            ))}
          </ul>

          <ul>
            <li>Price in HRK:</li>
            <br />
            {bill.products.map((product, index) => (
              <li key={index}>{product.price}</li>
            ))}
          </ul>
        </div> */}

        <p>Final: {bill.totalPriceWithTax}</p>
        <p>Price without tax: {bill.totalPriceWithoutTax}</p>
        <p>Price for VAT: {bill.valueAddedTaxAmount}</p>
        <p>Price for excise duty: {bill.exciseDutyAmount}</p>

        <p>GUID - {bill.guid}</p>
        <p>Date of issue - {bill.issueDate}</p>
      </div>
    );
  }
}
