import axios from "axios";
import { toASCII } from "punycode";

export const editAmount = (id, amount) =>
  axios.post(`/api/products/editAmount`, {
    id: id,
    amount: amount
  });

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
