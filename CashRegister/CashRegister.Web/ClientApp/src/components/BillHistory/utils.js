export const getTotalWithTax = products => {
  let total = 0;
  products.forEach(product => {
    total += product.price;
  });

  return total;
};

export const getTotalWithoutTax = products => {
  let total = 0;
  products.forEach(product => {
    total += getPriceWithoutTax(product.price, 25);
  });

  return total;
};

export const getTotalWithVAT = products => {
  let total = 0;
  products.forEach(product => {
    total += getPriceWithoutTax(product.price, 25) * (1 + 25 / 100);
  });

  return total;
};

export const getTotalWithExciseDuty = products => {
  let total = 0;
  products.forEach(product => {
    total += getPriceWithoutTax(product.price, 25) * (1 + 5 / 100);
  });

  return total;
};

const getPriceWithoutTax = (priceWithTax, taxRate) => {
  return priceWithTax / (1 + taxRate / 100);
};
