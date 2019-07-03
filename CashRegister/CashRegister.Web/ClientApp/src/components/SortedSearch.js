import React, { Component } from "react";
import "./CashRegister/CashRegister.css";

export class SortedSearch extends Component {
  constructor(props) {
    super(props);
    this.state = {
      productsArray: [],
      productsMatchingSearch: [],
      searchbarInput: "",
      productListVisibility: { display: "none" },
      isInputDisabled: false,
      boughtProducts: [],
      productToSave: { product: {}, amount: "" },
      totalPrice: 0
    };
  }

  componentDidMount() {
    this.setState({ productsArray: this.props.productsArray });
  }

  componentWillReceiveProps(nextProps) {
    this.setState({
      productsArray: nextProps.productsArray,
      isInputDisabled: nextProps.disabled,
      searchbarInput: nextProps.searchbarInput,
      productListVisibility: nextProps.productListVisibility
    });
  }

  handleInput = e => {
    let { searchbarInput } = this.state;
    const { productsArray } = this.state;

    searchbarInput = e.target.value;
    let products = productsArray.filter(product => {
      if (product.amount !== 0) {
        const lowerCaseProduct = product.name.toLowerCase();
        const filter = searchbarInput.toLowerCase();
        return lowerCaseProduct.includes(filter);
      } else return false;
    });

    if (searchbarInput !== "") {
      this.setState({ productListVisibility: { display: "block" } });
    } else this.setState({ productListVisibility: { display: "none" } });

    this.setState({ searchbarInput, productsMatchingSearch: products });
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
