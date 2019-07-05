import React, { Component } from "react";
import "./CashRegister/CashRegister.css";
import { getMatchingProducts } from "./utils";
import { debounce } from "throttle-debounce";

export class SortedSearch extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productsMatchingSearch: [],
      searchbarInput: "",
      productListVisibility: { display: "none" },
      isInputDisabled: false,
      boughtProducts: [],
      productToSave: { product: {}, amount: "" },
      totalPrice: 0
    };
    this.fetchMatchingProductsDebounced = debounce(
      500,
      this.fetchMatchingProducts
    );
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      isInputDisabled: nextProps.disabled,
      searchbarInput: nextProps.searchbarInput,
      productListVisibility: nextProps.productListVisibility,
      boughtProducts: nextProps.boughtProducts
    });
  }

  setMatchingProducts = input => {
    getMatchingProducts(input).then(response => {
      const { boughtProducts } = this.state;

      for (let i = 0; i < boughtProducts.length; i++)
        for (let j = 0; j < response.data.length; j++) {
          console.log(response.data, boughtProducts);
          if (boughtProducts[i].product.name === response.data[j].name)
            response.data[j].amount = boughtProducts[i].product.amount;
        }

      let products = response.data.filter(product => {
        if (product.amount !== 0) return true;
        return false;
      });

      if (response.data.length !== 0) {
        this.setState({ productListVisibility: { display: "block" } });
      } else this.setState({ productListVisibility: { display: "none" } });

      this.setState({ productsMatchingSearch: products });
    });
  };

  handleInput = e => {
    this.setState({ searchbarInput: e.target.value }, () => {
      if (
        this.state.searchbarInput.length >= 3 ||
        this.state.searchbarInput.length === 0
      )
        this.fetchMatchingProductsDebounced(this.state.searchbarInput);
    });
  };

  fetchMatchingProducts = input => {
    this.setMatchingProducts(input);
  };

  render() {
    const {
      productsMatchingSearch,
      searchbarInput,
      productListVisibility,
      isInputDisabled
    } = this.state;

    return (
      <div>
        <input
          className="item-search"
          value={searchbarInput}
          placeholder="Search products..."
          onChange={this.handleInput}
          disabled={isInputDisabled}
        />

        <ul className="product-list" style={productListVisibility}>
          {productsMatchingSearch.map((product, index) => (
            <li
              className="product-list-item"
              key={index}
              onClick={() => this.props.handleProductClick(product)}
            >
              {product.name} - <i> in stock ({product.amount}</i>)
            </li>
          ))}
        </ul>
      </div>
    );
  }
}
