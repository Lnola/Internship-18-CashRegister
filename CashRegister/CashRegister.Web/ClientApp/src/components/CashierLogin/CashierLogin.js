import React, { Component } from "react";
import { addCashierRegister } from "../utils";
import "./CashierLogin.css";

export class CashierLogin extends Component {
  constructor(props) {
    super(props);
    this.state = {
      registerId: "",
      cashierId: ""
    };
  }

  componentDidMount() {
    if (localStorage.getItem("registerId") !== null)
      this.props.history.push("/register");
  }

  handleInput = (e, type) => {
    switch (type) {
      case "register":
        this.setState({ registerId: e.target.value });
        break;

      case "cashier":
        this.setState({ cashierId: e.target.value });
        break;

      default:
        break;
    }
  };

  handleSubmit = () => {
    const { registerId, cashierId } = this.state;

    if (registerId !== "" && cashierId !== "")
      addCashierRegister(registerId, cashierId)
        .then(() => {
          localStorage.setItem("registerId", registerId);
          localStorage.setItem("cashierId", cashierId);

          alert("Logged in");

          this.props.history.push("/register");
        })
        .catch(() =>
          alert("Either the register or cashier with that id dont exist")
        );
    else alert("Fields cant be empty");
  };

  render() {
    const { registerId, cashierId } = this.state;

    return (
      <div className="login-wrapper">
        <h1>Login</h1>
        <input
          onChange={e => this.handleInput(e, "register")}
          value={registerId}
          type="number"
          placeholder="Register id..."
        />
        <input
          onChange={e => this.handleInput(e, "cashier")}
          value={cashierId}
          type="number"
          placeholder="Cashier id..."
        />
        <button onClick={this.handleSubmit}>Submit</button>
      </div>
    );
  }
}
