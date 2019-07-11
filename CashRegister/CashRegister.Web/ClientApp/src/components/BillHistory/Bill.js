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

    console.log(bill);

    return (
      <div id="printMe" className="bill">
        <h5>Bill - {bill.guid}</h5>
        <p>Cash Register: {bill.register}</p>
        <p>Cashier: {bill.cashier}</p>

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
