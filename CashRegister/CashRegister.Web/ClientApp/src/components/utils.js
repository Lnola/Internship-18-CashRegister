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
    name: editedProduct.name,
    barcode: editedProduct.barcode,
    tax: editedProduct.tax,
    price: editedProduct.price
  });

export const editAmount = (id, amount) =>
  axios.post("/api/products/editAmount", {
    id: id,
    amount: amount
  });

export const getTenBills = startingPosition =>
  axios.get("/api/bills/get-ten", { params: { startingPosition } });

export const getSimilarBills = searchbarInput =>
  axios.get("/api/bills/get-similar", {
    params: { dateInput: searchbarInput }
  });

export const getLatestBill = () => axios.get("/api/bills/last");

export const addProductToBill = billProductToAdd =>
  axios.post("/api/billProducts/add", {
    billId: billProductToAdd.billId,
    productId: billProductToAdd.productId,
    priceAtPurchase: billProductToAdd.price,
    taxAtPuchase: billProductToAdd.tax
  });

export const addBill = billToAdd =>
  axios.post("/api/bills/add", {
    totalPriceWithoutTax: billToAdd.totalPriceWithoutTax,
    exciseDutyAmount: billToAdd.exciseDutyAmount,
    valueAddedTaxAmount: billToAdd.valueAddedTaxAmount,
    customTaxAmount: billToAdd.customTaxAmount,
    totalPriceWithTax: billToAdd.totalPriceWithTax,
    billProducts: billToAdd.billProducts
  });

export const addCashierRegister = (registerId, cashierId) =>
  axios.post("/api/cashier-register/add", {
    registerId,
    cashierId
  });
