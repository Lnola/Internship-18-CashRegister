import React, { Component } from "react";

export class AddProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nameInput: "",
      barcodeInput: "",
      amountInput: "",
      priceInput: "",
      customTaxInput: "",
      radioInput: "",
      isCustomTaxVisible: false
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      nameInput: nextProps.nameInput,
      barcodeInput: nextProps.barcodeInput,
      amountInput: nextProps.amountInput,
      priceInput: nextProps.priceInput,
      customTaxInput: nextProps.customTaxInput,
      radioInput: nextProps.radioInput,
      isCustomTaxVisible: nextProps.isCustomTaxVisible
    });
  }

  render() {
    const {
      nameInput,
      barcodeInput,
      amountInput,
      priceInput,
      customTaxInput
    } = this.state;

    const {
      handleTextInputChange,
      handleNumberInputChange,
      handleRadioClick,
      handleCreateProduct
    } = this.props;

    return (
      <div>
        <h1>Add product</h1>

        <form className="add-product-wrapper">
          <input
            onChange={e => handleTextInputChange(e, "name")}
            value={nameInput}
            type="text"
            placeholder="Product name..."
          />
          <input
            onChange={e => handleTextInputChange(e, "barcode")}
            value={barcodeInput}
            type="text"
            placeholder="Barcode..."
          />
          <div className="number-input-wrapper">
            <input
              onChange={e => handleNumberInputChange(e, "amount")}
              value={amountInput}
              className="number-input"
              type="number"
              placeholder="Amount..."
            />
            <input
              onChange={e => handleNumberInputChange(e, "price")}
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
                onChange={handleRadioClick}
                type="radio"
                name="tax"
                value="custom"
              />
              Custom
            </div>
            <div>
              <input
                className="radio-input"
                onChange={handleRadioClick}
                type="radio"
                name="tax"
                value="exciseDuty"
              />
              Excise Duty
            </div>
            <div>
              <input
                className="radio-input"
                onChange={handleRadioClick}
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
                onChange={e => handleNumberInputChange(e, "custom")}
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
        <button onClick={handleCreateProduct} className="save-button">
          Save product
        </button>
      </div>
    );
  }
}
