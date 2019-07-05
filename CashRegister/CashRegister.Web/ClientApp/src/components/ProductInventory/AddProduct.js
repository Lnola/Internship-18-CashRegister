import React, { Component } from "react";
import { addNewProduct } from "../utils";

export class AddProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {
      customTaxVisibility: { display: "none" },
      isCustomTaxVisible: false,
      nameInput: "",
      barcodeInput: "",
      amountInput: "",
      priceInput: "",
      customTaxInput: "",
      radioInput: ""
    };
  }

  handleTextInputChange = (e, type) => {
    const input = e.target.value;
    switch (type) {
      case "name":
        this.setState({ nameInput: input });
        break;

      case "barcode":
        if (input.length <= 13) this.setState({ barcodeInput: input });
        break;

      default:
        break;
    }
  };

  handleNumberInputChange = (e, type) => {
    let input = e.target.value;
    switch (type) {
      case "amount":
        if (input !== "") {
          input = parseInt(input, 10);
          if (input > 0) this.setState({ amountInput: input });
        } else this.setState({ amountInput: "" });
        break;

      case "price":
        if (input !== "") {
          input = parseInt(input, 10);
          if (input > 0) this.setState({ priceInput: input });
        } else this.setState({ priceInput: "" });
        break;

      case "custom":
        if (input !== "") {
          input = parseInt(input, 10);
          if (input > 0) this.setState({ customTaxInput: input });
        } else this.setState({ customTaxInput: "" });
        break;

      default:
        break;
    }
  };

  handleRadioClick = e => {
    if (e.target.value === "custom")
      this.setState({ isCustomTaxVisible: true });
    else this.setState({ isCustomTaxVisible: false });

    this.setState({ radioInput: e.target.value });
  };

  handleCreateProduct = () => {
    const {
      nameInput,
      barcodeInput,
      amountInput,
      priceInput,
      customTaxInput,
      radioInput
    } = this.state;

    if (
      nameInput !== "" &&
      barcodeInput !== "" &&
      amountInput !== "" &&
      priceInput !== "" &&
      radioInput !== ""
    ) {
      let tax = 5;
      let isCustomTaxFieldEmpty = false;
      if (radioInput === "custom" && customTaxInput !== "")
        tax = customTaxInput;
      else if (radioInput !== "custom") {
        if (radioInput === "VAT") tax = 25;
      } else {
        alert("Custom tax field can't be empty");
        isCustomTaxFieldEmpty = true;
      }

      if (!isCustomTaxFieldEmpty) {
        const productToAdd = {
          name: nameInput,
          barcode: barcodeInput,
          price: priceInput,
          tax: tax,
          amount: amountInput
        };

        addNewProduct(productToAdd)
          .then(() => alert("Add successful"))
          .catch(() => alert("Add unsuccessful"));
      }
    } else alert("Fields can't be empty");
  };

  render() {
    const {
      nameInput,
      barcodeInput,
      amountInput,
      priceInput,
      customTaxInput
    } = this.state;

    return (
      <div>
        <h1>Add product</h1>

        <form className="add-product-wrapper">
          <input
            onChange={e => this.handleTextInputChange(e, "name")}
            value={nameInput}
            type="text"
            placeholder="Product name..."
          />
          <input
            onChange={e => this.handleTextInputChange(e, "barcode")}
            value={barcodeInput}
            type="text"
            placeholder="Barcode..."
          />
          <div className="number-input-wrapper">
            <input
              onChange={e => this.handleNumberInputChange(e, "amount")}
              value={amountInput}
              className="number-input"
              type="number"
              placeholder="Amount..."
            />
            <input
              onChange={e => this.handleNumberInputChange(e, "price")}
              value={priceInput}
              className="number-input"
              type="number"
              placeholder="HRK..."
            />
          </div>
          <div className="radio-wrapper">
            <div>
              <input
                className="radio-input"
                onChange={this.handleRadioClick}
                type="radio"
                name="tax"
                value="custom"
              />
              Custom
            </div>
            <div>
              <input
                className="radio-input"
                onChange={this.handleRadioClick}
                type="radio"
                name="tax"
                value="exciseDuty"
              />
              Excise Duty
            </div>
            <div>
              <input
                className="radio-input"
                onChange={this.handleRadioClick}
                type="radio"
                name="tax"
                value="VAT"
              />
              VAT
            </div>
          </div>
          {this.state.isCustomTaxVisible ? (
            <div>
              <input
                onChange={e => this.handleNumberInputChange(e, "custom")}
                value={customTaxInput}
                className="custom-input"
                type="number"
                placeholder="Custom tax..."
              />
            </div>
          ) : (
            <div />
          )}
        </form>
        <button onClick={this.handleCreateProduct} className="save-button">
          Save product
        </button>
      </div>
    );
  }
}
