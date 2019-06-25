import React, { Component } from "react";
import "./CashRegister.css";
import { SortedSearch } from "../SortedSearch";

export class CashRegister extends Component {
  static displayName = CashRegister.name;

  constructor(props) {
    super(props);
    this.state = {
      productsArray: [
        { type: "apple", amount: 1, id: 0, price: 200 },
        { type: "apples", amount: 1, id: 1, price: 200 },
        { type: "applees", amount: 1, id: 2, price: 200 },
        { type: "appleees", amount: 1, id: 3, price: 200 },
        { type: "appleeees", amount: 1, id: 4, price: 200 },
        { type: "orange", amount: 50, id: 5, price: 200 },
        { type: "banana", amount: 200, id: 6, price: 200 },
        { type: "lemon", amount: 20, id: 7, price: 200 }
      ],
      productsMatchingSearch: [],
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
      searchbarInput: product.type,
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

    if (productToSave.amount === 0 || productToSave.amount === "")
      alert("Amount input cant be 0 nor empty");
    else {
      // problem with people using the buttons on input to insert numbers higher
      // than the number of items availible. This should fix it
      if (productToSave.product.amount < productToSave.amount)
        productToSave.amount--;

      productToSave.product.amount -= productToSave.amount;

      let { boughtProducts } = this.state;
      boughtProducts.push(productToSave);

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
      productsArray
    } = this.state;

    // console.log("productsArray", this.state.productsArray);
    // console.log("boughtProducts", this.state.boughtProducts);

    if (!isRegisterOpened) return <p>Press ENTER to open the register...</p>;

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

        <div>
          <h1>Bought items</h1>
          <div className="bought-list-wrapper">
            <ul>
              {boughtProducts.map((product, index) => (
                <li key={index}>{product.product.type}</li>
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
          <h5 className="price-display">Total: {totalPrice}</h5>
        </div>
      </div>
    );
  }
}
