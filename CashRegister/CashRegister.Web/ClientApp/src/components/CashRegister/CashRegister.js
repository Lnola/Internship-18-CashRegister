import React, { Component } from "react";
import { SortedSearch } from "../SortedSearch";
import { BoughtItems } from "./BoughtItems";
import { editAmount, addProductToBill } from "../utils";
import "./CashRegister.css";

export class CashRegister extends Component {
  static displayName = CashRegister.name;

  constructor(props) {
    super(props);
    this.state = {
      isRegisterOpened: false,
      searchbarInput: "",
      productListVisibility: { display: "none" },
      productAmountVisibility: { display: "none" },
      isInputDisabled: false,
      boughtProducts: [],
      productToSave: { product: {}, amount: "" },
      totalPrice: 0
    };
  }

  handleKeyDown = event => {
    const ESCAPE_KEY = 27;
    const ENTER_KEY = 13;

    switch (event.keyCode) {
      case ESCAPE_KEY:
        this.setState({
          isRegisterOpened: false,
          productListVisibility: { display: "none" },
          productAmountVisibility: { display: "none" },
          boughtProducts: [],
          productToSave: { product: {}, amount: "" },
          totalPrice: 0
        });
        break;

      case ENTER_KEY:
        this.setState({ isRegisterOpened: true });
        break;

      default:
        break;
    }
  };

  componentDidMount() {
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
      productAmountVisibility: { display: "block" },
      searchbarInput: product.name,
      isInputDisabled: true,
      productToSave
    });
  };

  handleNumberInput = e => {
    const { productToSave } = this.state;
    if (e.target.value !== "")
      productToSave.amount = parseInt(e.target.value, 10);
    else productToSave.amount = "";

    if (
      productToSave.product.amount >= e.target.value &&
      productToSave.amount >= 0
    ) {
      this.setState(productToSave);
    }
  };

  handleProductAdd = () => {
    const { productToSave } = this.state;

    if (
      productToSave.amount === 0 ||
      productToSave.amount === "" ||
      productToSave.amount === -1
    )
      alert("Amount input cant be 0 nor empty");
    else {
      if (productToSave.amount === productToSave.product.amount + 1)
        productToSave.amount--;

      if (productToSave.amount > productToSave.product.amount)
        productToSave.amount = parseInt(productToSave.amount / 10, 10);

      productToSave.product.amount -= productToSave.amount;

      let { boughtProducts } = this.state;
      let isProductAdded = false;

      boughtProducts.forEach(product => {
        if (product.product.name === productToSave.product.name) {
          product.amount += productToSave.amount;
          product.product.amount -= productToSave.amount;
          isProductAdded = true;
        }
      });

      if (!isProductAdded) boughtProducts.push(productToSave);

      let { totalPrice } = this.state;
      totalPrice += productToSave.product.price * productToSave.amount;

      this.setState({
        productAmountVisibility: { display: "none" },
        productToSave: { product: {}, amount: "" },
        isInputDisabled: false,
        searchbarInput: "",
        boughtProducts,
        totalPrice
      });
    }
  };

  onPrintBill = () => {
    const { boughtProducts } = this.state;
    boughtProducts.forEach(product => {
      editAmount(product.product.id, product.product.amount)
        .then(() => {
          this.setState({
            boughtProducts: [],
            totalPrice: 0
          });
          alert("Printing the bill");
        })
        .catch(() => alert("Unsuccessful"));
    });
  };

  render() {
    const {
      isRegisterOpened,
      searchbarInput,
      productListVisibility,
      productAmountVisibility,
      isInputDisabled,
      productToSave,
      boughtProducts,
      totalPrice
    } = this.state;

    if (!isRegisterOpened)
      return (
        <div>
          <p>Press ENTER to open the register..</p>
          <p>To cancel purchase press ESC...</p>
        </div>
      );

    return (
      <div className="register-wrapper">
        <div>
          <h1>Product list</h1>
          <SortedSearch
            handleProductClick={this.onProductClick}
            productListVisibility={productListVisibility}
            disabled={isInputDisabled}
            searchbarInput={searchbarInput}
            boughtProducts={boughtProducts}
            isRegister={true}
          />

          <div className="amount-modal" style={productAmountVisibility}>
            <p className="amount-info">
              {productToSave.product.amount} item(s) availible
            </p>

            <input
              className="number-input"
              type="number"
              value={productToSave.amount}
              onChange={this.handleNumberInput}
              placeholder="Amount..."
            />
            <button className="submit-button" onClick={this.handleProductAdd}>
              Submit
            </button>
          </div>
        </div>

        <BoughtItems
          handlePrintBill={this.onPrintBill}
          boughtProducts={boughtProducts}
          totalPrice={totalPrice}
        />
      </div>
    );
  }
}
