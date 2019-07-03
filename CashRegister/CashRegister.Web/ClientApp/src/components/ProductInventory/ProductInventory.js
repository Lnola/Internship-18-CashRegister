import React, { Component } from "react";
import { AddProduct } from "./AddProduct";
import { EditProduct } from "./EditProduct";
import "./ProductInventory.css";
import axios from "axios";
// import "./CashRegister.css";

export class ProductInventory extends Component {
  static displayName = ProductInventory.name;

  constructor(props) {
    super(props);
    this.state = {
      productsArray: [],
      searchbarInput: "",
      productListVisibility: { display: "none" },
      choiceButtonsVisibility: { display: "none" },
      productToSave: { product: {}, amount: "" },
      isInputDisabled: false,
      isAddOpen: false,
      isEditOpen: false
    };
  }

  handleKeyDown = event => {
    const ESCAPE_KEY = 27;
    const ENTER_KEY = 13;
    const PLUS_KEY = 107;
    const { isEditOpen, isAddOpen } = this.state;

    switch (event.keyCode) {
      case ESCAPE_KEY:
        this.setState({ isEditOpen: false, isAddOpen: false });
        break;

      case ENTER_KEY:
        if (!isEditOpen) this.setState({ isEditOpen: true, isAddOpen: false });
        break;

      case PLUS_KEY:
        if (!isAddOpen) this.setState({ isAddOpen: true, isEditOpen: false });
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
      choiceButtonsVisibility: { display: "block" },
      searchbarInput: product.type,
      isInputDisabled: true,
      productToSave
    });
  };

  render() {
    const {
      searchbarInput,
      productListVisibility,
      productsArray,
      isAddOpen,
      isEditOpen,
      productToSave,
      isInputDisabled,
      choiceButtonsVisibility
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
          productToEdit={productToSave.product}
          isInputDisabled={isInputDisabled}
          choiceButtonsVisibility={choiceButtonsVisibility}
        />
      );
  }
}
