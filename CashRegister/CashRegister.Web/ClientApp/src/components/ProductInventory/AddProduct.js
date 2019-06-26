import React, { Component } from "react";

export class AddProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div>
        <h1>Add product</h1>

        <form className="add-product-wrapper">
          <input type="text" placeholder="Product name..." />
          <input type="text" placeholder="Barcode..." />
          <div className="radio-wrapper">
            <div>
              <input
                className="radio-input"
                type="radio"
                name="tax"
                value="VAT"
                checked
              />
              VAT
            </div>
            <div>
              <input
                className="radio-input"
                type="radio"
                name="tax"
                value="ExciseDuty"
                checked
              />
              Excise Duty
            </div>
            <input
              className="number-input"
              type="number"
              placeholder="Amount..."
            />
          </div>
          <div>
            <input
              className="number-input"
              type="number"
              placeholder="HRK..."
            />
            <button className="save-button">Save product</button>
          </div>
        </form>
      </div>
    );
  }
}
