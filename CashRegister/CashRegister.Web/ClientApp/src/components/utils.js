import axios from "axios";

export const getAllProducts = () => axios.get("/api/products/all");

export const getMatchingProducts = input =>
  axios.get("/api/products/matching", { params: { input: input } });

export const addNewProduct = productToAdd =>
  axios.post("/api/products/add", {
    name: productToAdd.name,
    barcode: productToAdd.barcode,
    price: productToAdd.price,
    tax: productToAdd.tax,
    amount: productToAdd.amount
  });

export const editProduct = editedProduct =>
  axios.post("/api/products/edit", {
    id: editedProduct.id,
    barcode: editedProduct.barcode,
    tax: editedProduct.tax,
    price: editedProduct.price
  });

export const editAmount = (id, amount) =>
  axios.post(`/api/products/editAmount`, {
    id: id,
    amount: amount
  });
