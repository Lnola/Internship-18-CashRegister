import React, { Component } from "react";
import "./CashRegister.css";

export class CashRegister extends Component {
  static displayName = CashRegister.name;

  constructor(props) {
    super(props);
    this.state = {
      productsArray: [
        { type: "apple", amount: 1 },
        { type: "apples", amount: 1 },
        { type: "applees", amount: 1 },
        { type: "appleees", amount: 1 },
        { type: "appleeees", amount: 1 },
        { type: "orange", amount: 50 },
        { type: "banana", amount: 200 },
        { type: "lemon", amount: 20 }
      ],
      productsMatchingSearch: [],
      isRegisterOpened: false,
      searchbarInput: "",
      productListVisibility: { display: "none" }
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

  handleInput = e => {
    let { searchbarInput } = this.state;
    const { productsArray } = this.state;

    searchbarInput = e.target.value;
    let products = productsArray.filter(product => {
      const lowerCaseProduct = product.type.toLowerCase();
      const filter = searchbarInput.toLowerCase();
      return lowerCaseProduct.includes(filter);
    });

    if (searchbarInput !== "") {
      this.setState({ productListVisibility: { display: "inline" } });
    } else this.setState({ productListVisibility: { display: "none" } });

    console.log(products);

    this.setState({ searchbarInput, productsMatchingSearch: products });
  };

  render() {
    const {
      isRegisterOpened,
      productsMatchingSearch,
      searchbarInput,
      productListVisibility
    } = this.state;

    if (!isRegisterOpened) return null;

    return (
      <div>
        <h1>Product list</h1>

        <div>
          <input
            value={searchbarInput}
            placeholder="Search products..."
            onChange={this.handleInput}
          />

          <ul style={productListVisibility}>
            {productsMatchingSearch.map((product, index) => (
              <li key={index}>{product.type}</li>
            ))}
          </ul>
        </div>
      </div>
    );
  }
}
