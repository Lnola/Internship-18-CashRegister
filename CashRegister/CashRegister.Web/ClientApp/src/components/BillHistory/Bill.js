import React, { Component } from "react";

export class Bill extends Component {
  constructor(props) {
    super(props);
    this.state = {
      bill: this.props.displayedBill
    };
  }

  componentWillReceiveProps(nextProps) {
    const { displayedBill } = nextProps;

    if (displayedBill.cashierRegister === null) {
      displayedBill.cashierRegister = {
        registerId: 1,
        cashierId: 1,
        cashier: { name: "Mate Matic" }
      };
    }

    this.setState({ bill: displayedBill });
  }

  render() {
    const { bill } = this.state;

    return (
      <div id="printMe" className="bill">
        <h5>Bill - {bill.guid}</h5>
        <p>Cash Register: {bill.cashierRegister.registerId}</p>
        <p>
          Cashier: {bill.cashierRegister.cashierId} -{" "}
          {bill.cashierRegister.cashier.name}
        </p>

        <div className="products-list">
          <ul className="t-a-start">
            <li>Name:</li>
            <br />
            {bill.billProducts.map((billProduct, index) => (
              <li key={index}>{billProduct.product.name}</li>
            ))}
          </ul>

          <ul>
            <li>Amount:</li>
            <br />
            {bill.billProducts.map((billProduct, index) => (
              <li key={index}>{billProduct.amountBought}</li>
            ))}
          </ul>

          <ul>
            <li>Price in HRK:</li>
            <br />
            {bill.billProducts.map((billProduct, index) => (
              <li key={index}>{billProduct.priceAtPurchase}</li>
            ))}
          </ul>
        </div>

        <p>Final: {bill.totalPriceWithTax}</p>
        <p>Price without tax: {bill.totalPriceWithoutTax}</p>
        <p>VAT: {bill.valueAddedTaxAmount}</p>
        <p>Excise duty: {bill.exciseDutyAmount}</p>
        <p>Custom duty: {bill.customTaxAmount}</p>

        <p>GUID - {bill.guid}</p>
        <p>Date of issue - {bill.issueDate}</p>
      </div>
    );
  }
}
