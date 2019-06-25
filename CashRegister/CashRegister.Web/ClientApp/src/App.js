import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout/Layout";
import { CashRegister } from "./components/CashRegister/CashRegister";
import { ProductInventory } from "./components/ProductInventory/ProductInventory";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={CashRegister} />
        <Route path="/inventory" component={ProductInventory} />
      </Layout>
    );
  }
}
