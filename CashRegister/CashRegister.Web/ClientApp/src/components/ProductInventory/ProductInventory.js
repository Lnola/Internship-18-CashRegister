import React, { Component } from "react";
import { AddProduct } from "./AddProduct";
import { EditProduct } from "./EditProduct";
import { addNewProduct, editProduct, editAmount } from "../utils";
import "./ProductInventory.css";

export class ProductInventory extends Component {
  static displayName = ProductInventory.name;

  constructor(props) {
    super(props);
    this.state = {
      searchbarInput: "",
      productListVisibility: { display: "none" },
      choiceButtonsVisibility: { display: "none" },
      productToSave: { product: {}, amount: "" },
      isInputDisabled: false,
      isAddOpen: false,
      isEditOpen: false,
      // add and edit props
      nameInput: "",
      barcodeInput: "",
      amountInput: "",
      priceInput: "",
      customTaxInput: "",
      radioInput: "",
      isCustomTaxVisible: false
    };
  }

  handleKeyDown = event => {
    const ESCAPE_KEY = 27;
    const ENTER_KEY = 13;
    const PLUS_KEY = 107;
    const { isEditOpen, isAddOpen } = this.state;

    switch (event.keyCode) {
      case ESCAPE_KEY:
        this.setState({
          isEditOpen: false,
          isAddOpen: false,
          radioInput: "",
          customTaxInput: "",
          isCustomTaxVisible: false
        });
        break;

      case ENTER_KEY:
        if (!isEditOpen)
          this.setState({
            isEditOpen: true,
            isAddOpen: false,
            radioInput: "",
            customTaxInput: "",
            isCustomTaxVisible: false
          });
        break;

      case PLUS_KEY:
        if (!isAddOpen)
          this.setState({
            isAddOpen: true,
            isEditOpen: false,
            radioInput: "",
            customTaxInput: "",
            isCustomTaxVisible: false
          });
        break;

      default:
        break;
    }
  };

  componentDidMount() {
    if (
      localStorage.getItem("cashierId") === null ||
      localStorage.getItem("registerId") === null
    )
      this.props.history.push("/");
    document.addEventListener("keydown", this.handleKeyDown);
  }

  componentWillUnmount() {
    document.removeEventListener("keydown", this.handleKeyDown);
  }

  onProductClick = product => {
    const { productToSave } = this.state;
    productToSave.product = product;

    this.setState({
      productListVisibility: { display: "none" },
      choiceButtonsVisibility: { display: "block" },
      isInputDisabled: true,
      productToSave,
      searchbarInput: product.name,
      barcodeInput: productToSave.product.barcode,
      priceInput: productToSave.product.price
    });

    switch (product.tax) {
      case 25:
        this.setState({ radioInput: "VAT" });
        break;

      case 5:
        this.setState({ radioInput: "exciseDuty" });
        break;

      default:
        this.setState({
          radioInput: "custom",
          customTaxInput: product.tax,
          isCustomTaxVisible: true
        });
        break;
    }
  };

  onTextInputChange = (e, type) => {
    this.setState({ choiceButtonsVisibility: { display: "none" } });

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

  onNumberInputChange = (e, type) => {
    this.setState({ choiceButtonsVisibility: { display: "none" } });

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

  onRadioClick = e => {
    this.setState({ choiceButtonsVisibility: { display: "none" } });

    if (e.target.value === "custom")
      this.setState({ isCustomTaxVisible: true });
    else this.setState({ isCustomTaxVisible: false });

    this.setState({ radioInput: e.target.value });
  };

  onCreateProduct = () => {
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
      let isBarcodeTooShort = false;

      if (radioInput === "custom" && customTaxInput !== "")
        tax = customTaxInput;
      else if (radioInput !== "custom") {
        if (radioInput === "VAT") tax = 25;
      } else {
        alert("Custom tax field can't be empty");
        isCustomTaxFieldEmpty = true;
      }
      if (barcodeInput.length < 13) {
        alert("Barcode input too short");
        isBarcodeTooShort = true;
      }

      if (!isCustomTaxFieldEmpty && !isBarcodeTooShort) {
        const productToAdd = {
          name: nameInput,
          barcode: barcodeInput,
          price: priceInput,
          tax: tax,
          amount: amountInput
        };

        addNewProduct(productToAdd)
          .then(() => {
            alert("Add successful");
            this.setState({
              isCustomTaxVisible: false,
              nameInput: "",
              barcodeInput: "",
              amountInput: "",
              priceInput: "",
              customTaxInput: "",
              radioInput: ""
            });
          })
          .catch(() =>
            alert("Add unsuccessful! Either name or barcode allready exists")
          );
      }
    } else alert("Fields can't be empty");
  };

  onSaveEdit = () => {
    const { barcodeInput, priceInput, customTaxInput, radioInput } = this.state;

    if (barcodeInput !== "" && priceInput !== "" && radioInput !== "") {
      let tax = 5;
      let isCustomTaxFieldEmpty = false;
      let isBarcodeTooShort = false;

      if (radioInput === "custom" && customTaxInput !== "")
        tax = customTaxInput;
      else if (radioInput !== "custom") {
        if (radioInput === "VAT") tax = 25;
      } else {
        alert("Custom tax field can't be empty");
        isCustomTaxFieldEmpty = true;
      }

      if (barcodeInput.length < 13) {
        alert("Barcode input too short");
        isBarcodeTooShort = true;
      }

      if (!isCustomTaxFieldEmpty && !isBarcodeTooShort) {
        const productToEdit = {
          id: this.state.productToSave.product.id,
          name: this.state.searchbarInput,
          barcode: barcodeInput,
          tax: tax,
          price: priceInput
        };

        editProduct(productToEdit)
          .then(() => {
            alert("Edit successful");
            this.setState({
              isCustomTaxVisible: false,
              barcodeInput: "",
              priceInput: "",
              customTaxInput: "",
              radioInput: "",
              isInputDisabled: false,
              isEditOpen: false
            });
          })
          .catch(() =>
            alert(
              "Edit unsuccessful! Either barcode exists or nothing was changed in the edit"
            )
          );
      }
    } else alert("Fields can't be empty");
  };

  onSaveAmountChange = () => {
    if (this.state.amountInput !== "") {
      const { productToSave, amountInput } = this.state;
      editAmount(
        productToSave.product.id,
        amountInput + productToSave.product.amount
      )
        .then(() => {
          alert("New products successfuly added");
          this.setState({
            amountInput: "",
            isEditOpen: false,
            searchbarInput: "",
            isInputDisabled: false
          });
        })
        .catch(() => alert("Unsuccessful"));
    } else alert("Field must contain a number");
  };

  render() {
    const {
      searchbarInput,
      productListVisibility,
      isAddOpen,
      isEditOpen,
      isInputDisabled,
      choiceButtonsVisibility,
      nameInput,
      barcodeInput,
      amountInput,
      priceInput,
      customTaxInput,
      radioInput,
      isCustomTaxVisible
    } = this.state;

    if (!isAddOpen && !isEditOpen)
      return (
        <div>
          <p>Press the + key to open product add</p>
          <p>Press the ENTER key to open product edit</p>
        </div>
      );

    if (isAddOpen)
      return (
        <AddProduct
          //event handlers
          handleTextInputChange={this.onTextInputChange}
          handleNumberInputChange={this.onNumberInputChange}
          handleRadioClick={this.onRadioClick}
          handleCreateProduct={this.onCreateProduct}
          // add props
          nameInput={nameInput}
          barcodeInput={barcodeInput}
          amountInput={amountInput}
          priceInput={priceInput}
          customTaxInput={customTaxInput}
          radioInput={radioInput}
          isCustomTaxVisible={isCustomTaxVisible}
        />
      );

    if (isEditOpen) {
      return (
        <EditProduct
          // event handlers
          handleTextInputChange={this.onTextInputChange}
          handleNumberInputChange={this.onNumberInputChange}
          handleRadioClick={this.onRadioClick}
          handleSaveEdit={this.onSaveEdit}
          handleSaveAmountChange={this.onSaveAmountChange}
          // sorted search props
          onProductClick={this.onProductClick}
          productListVisibility={productListVisibility}
          isInputDisabled={isInputDisabled}
          searchbarInput={searchbarInput}
          // edit props
          barcodeInput={barcodeInput}
          amountInput={amountInput}
          priceInput={priceInput}
          customTaxInput={customTaxInput}
          radioInput={radioInput}
          choiceButtonsVisibility={choiceButtonsVisibility}
          isCustomTaxVisible={isCustomTaxVisible}
        />
      );
    }
  }
}
