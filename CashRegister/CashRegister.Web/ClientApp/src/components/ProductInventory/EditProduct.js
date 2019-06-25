import React, { Component } from "react";
import { SortedSearch } from "../SortedSearch";

export class EditProduct extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    const {
      productsArray,
      onProductClick,
      searchbarInput,
      productListVisibility
    } = this.props;

    return (
      <div>
        <h1>Edit product</h1>
        <SortedSearch
          productsArray={productsArray}
          handleProductClick={onProductClick}
          searchbarInput={searchbarInput}
          productListVisibility={productListVisibility}
        />
      </div>
    );
  }
}
