export const getTotalWithoutTax = products => {
  let total = 0;
  products.forEach(product => {
    total +=
      getPriceWithoutTax(product.product.price, product.product.tax) *
      product.amount;
  });

  return parseInt(total.toFixed(2), 10);
};

export const getTotalTaxForTaxType = (products, type, totalPrice) => {
  let total = 0;

  let taxRate = 0;
  if (type === "exciseDuty") taxRate = 5;
  else if (type === "VAT") taxRate = 25;

  products.forEach(product => {
    if (
      type === "custom" &&
      product.product.tax !== 25 &&
      product.product.tax !== 5
    )
      taxRate = product.product.tax;
    if (product.product.tax === taxRate)
      total +=
        getPriceWithoutTax(product.product.price, taxRate) * product.amount;
    else totalPrice -= product.product.price * product.amount;
  });

  if (total !== 0) return parseInt((totalPrice - total).toFixed(2), 10);

  return 0;
};

export const getBillProductsFromProducts = products => {
  let billProducts = [];

  products.forEach(product => {
    let billProduct = {
      productId: product.product.id,
      product: product.product,
      priceAtPurchase: product.product.price,
      taxAtPurchase: product.product.tax
    };

    billProducts.push(billProduct);
  });

  return billProducts;
};

const getPriceWithoutTax = (priceWithTax, taxRate) => {
  return priceWithTax / (1 + taxRate / 100);
};
