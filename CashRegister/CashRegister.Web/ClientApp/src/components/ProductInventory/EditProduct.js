import React, { Component } from "react";
import { SortedSearch } from "../SortedSearch";

export class EditProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isInputDisabled: false,
      editInputsVisibility: { display: "none" },
      newShipmentVisibility: { display: "none" },
      editOrShipmentVisibility: { display: "none" }
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      isInputDisabled: nextProps.isInputDisabled,
      searchbarInput: nextProps.searchbarInput,
      editOrShipmentVisibility: nextProps.choiceButtonsVisibility
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

  handleSaveEdit = () => {
    // const { newBarcode, isVAT, newPrice } = this.state;
  };

  render() {
    const {
      productsArray,
      onProductClick,
      productListVisibility,
      productToEdit
    } = this.props;
    const {
      searchbarInput,
      isInputDisabled,
      editInputsVisibility,
      newShipmentVisibility,
      editOrShipmentVisibility
    } = this.state;

    return (
      <div>
        <h1>Edit product</h1>
        <SortedSearch
          productsArray={productsArray}
          handleProductClick={onProductClick}
          searchbarInput={searchbarInput}
          productListVisibility={productListVisibility}
          disabled={isInputDisabled}
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
          <input className="edit-input" type="text" placeholder="Barcode..." />
          <div className="radio-wrapper">
            <div>
              <input
                className="radio-input"
                type="radio"
                name="tax"
                value="VAT"
              />
              VAT
            </div>
            <div>
              <input
                className="radio-input radio-input-edit"
                type="radio"
                name="tax"
                value="ExciseDuty"
              />
              Excise Duty
            </div>
          </div>
          <div className="edit-submit">
            <input
              className="number-input"
              type="number"
              placeholder="HRK..."
              value={productToEdit.price}
            />
            <button
              className="save-button-edit"
              onClick={this.handleCancelEdit}
            >
              Save
            </button>
            <button className="cancel-button" onClick={this.handleCancelEdit}>
              Cancel
            </button>
          </div>
        </div>

        <div style={newShipmentVisibility}>
          <div className="shipment-wrapper">
            <input
              className="shipment-input"
              type="number"
              placeholder="Amount that arrived..."
            />
            <div>
              <button
                className="shipment-button"
                onClick={this.handleCancelEdit}
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
