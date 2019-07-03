import React, { Component } from "react";

export class BoughtItems extends Component {
  render() {
    const { boughtProducts, totalPrice, handlePrintBill } = this.props;

    return (
      <div>
        <h1>Bought items</h1>
        <div className="bought-list-wrapper">
          <ul>
            {boughtProducts.map((product, index) => (
              <li key={index}>{product.product.name}</li>
            ))}
          </ul>

          <ul>
            {boughtProducts.map((product, index) => (
              <li key={index}>-</li>
            ))}
          </ul>

          <ul>
            {boughtProducts.map((product, index) => (
              <li className="bought-amount" key={index}>
                {product.amount}
              </li>
            ))}
          </ul>
        </div>
        <div className="finish-buy">
          {boughtProducts.length === 0 ? (
            <div />
          ) : (
            <button onClick={handlePrintBill}>Print the bill</button>
          )}
          <h5>Total: {totalPrice} kn</h5>
        </div>
      </div>
    );
  }
}
