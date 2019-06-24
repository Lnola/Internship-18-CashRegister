export const spliceProductArray = (productsArray, product) => {
  productsArray.forEach((inArrayProduct, index) => {
    if (inArrayProduct === product && inArrayProduct.amount === 1)
      productsArray.splice(index, 1);
  });
};
