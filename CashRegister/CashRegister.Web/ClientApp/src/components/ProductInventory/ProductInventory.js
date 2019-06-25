import React, { Component } from "react";
import { AddProduct } from "./AddProduct";
import { EditProduct } from "./EditProduct";
// import "./CashRegister.css";

export class ProductInventory extends Component {
  static displayName = ProductInventory.name;

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
      searchbarInput: "",
      productListVisibility: { display: "none" },
      productToSave: { product: {}, amount: "" },
      isAddOpen: false,
      isEditOpen: false
    };
  }

  handleKeyDown = event => {
    const ESCAPE_KEY = 27;
    const ENTER_KEY = 13;
    const PLUS_KEY = 107;

    switch (event.keyCode) {
      case ESCAPE_KEY:
        this.setState({ isEditOpen: false, isAddOpen: false });
        break;

      case ENTER_KEY:
        this.setState({ isEditOpen: true, isAddOpen: false });
        break;

      case PLUS_KEY:
        this.setState({ isAddOpen: true, isEditOpen: false });
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
      searchbarInput: product.type,
      productToSave
    });
  };

  render() {
    const {
      searchbarInput,
      productListVisibility,
      productsArray,
      isAddOpen,
      isEditOpen
    } = this.state;

    if (!isAddOpen && !isEditOpen)
      return (
        <div>
          <p>Press the + key to open product add</p>
          <p>Press the ENTER key to open product edit</p>
        </div>
      );

    if (isAddOpen) return <AddProduct />;

    if (isEditOpen)
      return (
        <EditProduct
          productsArray={productsArray}
          onProductClick={this.onProductClick}
          searchbarInput={searchbarInput}
          productListVisibility={productListVisibility}
        />
      );
  }
}
