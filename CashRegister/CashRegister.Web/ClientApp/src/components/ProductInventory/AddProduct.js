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
        <form>
          <input type="text" placeholder="Product name..." />
          <input type="text" placeholder="Barcode..." />
          <input type="number" placeholder="Price in HRK..." />
          <input type="radio" name="tax" value="VAT" checked /> VAT
          <input type="radio" name="tax" value="ExciseDuty" checked /> Excise
          Duty
          <input type="number" placeholder="Amount..." />
        </form>
      </div>
    );
  }
}
