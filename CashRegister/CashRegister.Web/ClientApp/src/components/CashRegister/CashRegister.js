import React, { Component } from "react";
import "./CashRegister.css";
import { SortedSearch } from "../SortedSearch";
import axios from "axios";
import { BoughtItems } from "./BoughtItems";

export class CashRegister extends Component {
  static displayName = CashRegister.name;

  constructor(props) {
    super(props);
    this.state = {
      productsArray: [],
      productsMatchingSearch: [],
      isRegisterOpened: false,
      searchbarInput: "",
      productListVisibility: { display: "none" },
      productAmountVisibility: { display: "none" },
      isInputDisabled: false,
      boughtProducts: [],
      productToSave: { product: {}, amount: "" },
      totalPrice: 0,
      loading: true
    };
  }

  handleKeyDown = event => {
    const ESCAPE_KEY = 27;
    const ENTER_KEY = 13;

    switch (event.keyCode) {
      case ESCAPE_KEY:
        this.setState({ isRegisterOpened: false });
        break;

      case ENTER_KEY:
        this.setState({ isRegisterOpened: true });
        break;

      default:
        break;
    }
  };

  componentDidMount() {
    axios.get("/api/products/all").then(response => {
      this.setState({ productsArray: response.data, loading: false });
    });

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
    if (e.target.value !== "") productToSave.amount = parseInt(e.target.value);
    else productToSave.amount = "";

    if (
      productToSave.product.amount >= e.target.value &&
      productToSave.amount >= 0
    )
      this.setState(productToSave);
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
      if (productToSave.product.amount < productToSave.amount)
        productToSave.amount--;

      productToSave.product.amount -= productToSave.amount;

      let { boughtProducts } = this.state;
      let isProductAdded = false;
      boughtProducts.forEach(product => {
        if (product.product === productToSave.product) {
          product.amount += productToSave.amount;
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
      const a = product.product.id;
      const b = product.amount;
      // axios
      //   .post(`/api/products/editAmount`, {
      //     newAmount: b,
      //     productId: a
      //   })
      //   .then(() => {
      //     // axios.get("/api/products/all").then(response => {
      //     //   this.setState({ productsArray: response.data });
      //     // });
      //     this.setState({
      //       boughtProducts: [],
      //       totalPrice: 0
      //     });
      //     alert("Printing the bill");
      //   })
      //   .catch(() => alert("Unsuccessful"));

      fetch("/api/products/editAmount", {
        method: "POST", // or 'PUT'
        body: JSON.stringify({ newAmount: b, productId: a }), // data can be `string` or {object}!
        headers: {
          "Content-Type": "application/json"
        }
      }).then(res => res.json());
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
      totalPrice,
      productsArray,
      loading
    } = this.state;

    // console.log("productsArray", this.state.productsArray);
    // console.log("boughtProducts", this.state.boughtProducts);

    if (!isRegisterOpened) return <p>Press ENTER to open the register...</p>;
    if (loading) return <p>Loading...</p>;

    return (
      <div className="register-wrapper">
        <div>
          <h1>Product list</h1>
          <SortedSearch
            productsArray={productsArray}
            handleProductClick={this.onProductClick}
            disabled={isInputDisabled}
            searchbarInput={searchbarInput}
            productListVisibility={productListVisibility}
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
          boughtProducts={boughtProducts}
          totalPrice={totalPrice}
          handlePrintBill={this.onPrintBill}
        />
      </div>
    );
  }
}
