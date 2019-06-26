import React, { Component } from "react";
import {
  getTotalWithTax,
  getTotalWithoutTax,
  getTotalWithVAT,
  getTotalWithExciseDuty
} from "./utils";

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
    console.log(bill);

    return (
      <div className="bill">
        <h1>Bill - {bill.guid}</h1>
        <p>Cash Register: {bill.register}</p>
        <p>Cashier: {bill.cashier}</p>

        <div className="products-list">
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
        </div>

        <p>Final: {getTotalWithTax(bill.products)}</p>
        <p>Price without tax: {getTotalWithoutTax(bill.products)}</p>
        <p>Price for VAT: {getTotalWithVAT(bill.products)}</p>
        <p>Price for excise duty: {getTotalWithExciseDuty(bill.products)}</p>

        <p>GUID - {bill.guid}</p>
        <p>Date of issue - {bill.dateOfIssue}</p>
      </div>
    );
  }
}
