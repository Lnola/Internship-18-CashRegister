import React, { Component } from "react";
import { SortedSearch } from "../SortedSearch";

export class EditProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isInputDisabled: false,
      editInputsVisibility: { display: "none" },
      newShipmentVisibility: { display: "none" },
      editOrShipmentVisibility: { display: "none" },
      barcodeInput: "",
      amountInput: "",
      priceInput: "",
      customTaxInput: "",
      radioInput: ""
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      productListVisibility: nextProps.productListVisibility,
      isInputDisabled: nextProps.isInputDisabled,
      searchbarInput: nextProps.searchbarInput,
      editOrShipmentVisibility: nextProps.choiceButtonsVisibility,
      barcodeInput: nextProps.barcodeInput,
      amountInput: nextProps.amountInput,
      priceInput: nextProps.priceInput,
      customTaxInput: nextProps.customTaxInput,
      radioInput: nextProps.radioInput,
      isCustomTaxVisible: nextProps.isCustomTaxVisible
    });
  }

  handleOpenEdit = () => {
    this.setState({
      editInputsVisibility: { display: "block" },
      editOrShipmentVisibility: { display: "none" }
    });
  };

  handleOpenShipment = () => {
    this.setState({
      newShipmentVisibility: { display: "block" },
      editOrShipmentVisibility: { display: "none" }
    });
  };

  handleCancelEdit = () => {
    this.setState({
      isInputDisabled: false,
      searchbarInput: "",
      editInputsVisibility: { display: "none" },
      newShipmentVisibility: { display: "none" }
    });
  };

  render() {
    const {
      handleTextInputChange,
      handleNumberInputChange,
      handleRadioClick,
      handleSaveEdit,
      handleSaveAmountChange,
      onProductClick
    } = this.props;
    const {
      productListVisibility,
      isInputDisabled,
      searchbarInput,
      editInputsVisibility,
      newShipmentVisibility,
      editOrShipmentVisibility,
      barcodeInput,
      priceInput,
      radioInput,
      customTaxInput,
      amountInput
    } = this.state;

    return (
      <div>
        <h1>Edit product</h1>
        <SortedSearch
          handleProductClick={onProductClick}
          productListVisibility={productListVisibility}
          disabled={isInputDisabled}
          searchbarInput={searchbarInput}
          boughtProducts={[]}
          isRegister={false}
        />

        <div style={editOrShipmentVisibility}>
          <button onClick={this.handleOpenEdit} className="edit-select-button">
            Edit Product
          </button>
          <button
            onClick={this.handleOpenShipment}
            className="edit-select-button right-button"
          >
            New Shipment
          </button>
        </div>

        <div style={editInputsVisibility}>
          <form className="edit-form-wrapper">
            <input
              className="edit-input"
              onChange={e => handleTextInputChange(e, "barcode")}
              value={barcodeInput}
              type="text"
              placeholder="Barcode..."
            />
            <input
              className="number-input-edit"
              onChange={e => handleNumberInputChange(e, "price")}
              type="number"
              placeholder="HRK..."
              value={priceInput}
            />
            <p>Current tax type: {radioInput}</p>
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
          <div className="edit-submit">
            <button className="button-edit" onClick={handleSaveEdit}>
              Save
            </button>
            <button className="button-edit" onClick={this.handleCancelEdit}>
              Cancel
            </button>
          </div>
        </div>

        <div style={newShipmentVisibility}>
          <div className="shipment-wrapper">
            <input
              className="shipment-input"
              onChange={e => handleNumberInputChange(e, "amount")}
              value={amountInput}
              type="number"
              placeholder="Amount that arrived..."
            />
            <div>
              <button
                className="shipment-button"
                onClick={handleSaveAmountChange}
              >
                Save
              </button>
              <button
                className="shipment-button shipment-right-button"
                onClick={this.handleCancelEdit}
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
