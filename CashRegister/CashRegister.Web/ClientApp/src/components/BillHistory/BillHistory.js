import React, { Component } from "react";
import "./BillHistory.css";
import { Bill } from "./Bill";
import Axios from "axios";
import InfiniteScroll from "react-infinite-scroll-component";

export class BillHistory extends Component {
  static displayName = BillHistory.name;

  constructor(props) {
    super(props);
    this.state = {
      billArray: [
        {
          guid: "1111111111",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple1", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111112",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple2", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111114",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple3", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111113",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple4", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111115",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple5", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111116",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple6", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111117",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple7", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111118",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple8", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111119",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple9", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111110",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple12", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111121",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple13", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        },
        {
          guid: "1111111122",
          register: 1,
          cashier: 1,
          dateOfIssue: "12 / 2 / 2019",
          products: [
            { type: "apple14", amount: 1, price: 200 },
            { type: "orange", amount: 50, price: 200 },
            { type: "banana", amount: 200, price: 200 },
            { type: "lemon", amount: 20, price: 200 }
          ]
        }
      ],
      billsMatchingSearch: [],
      searchbarInput: "",
      billVisibility: { display: "none" },
      displayedBill: {
        guid: 1,
        register: 1,
        cashier: 1,
        dateOfIssue: "12 / 2 / 2019",
        products: [{ type: "apple", amount: 1, price: 200 }]
      },
      bills: [],
      hasMore: true
    };
  }

  componentDidMount() {
    Axios.get("/api/bills/get-ten", { params: { startingPosition: 0 } }).then(
      response => {
        this.setState({ bills: response.data });
      }
    );

    this.setState({ billsMatchingSearch: this.state.billArray });
  }

  handleSearchInput = e => {
    let { searchbarInput } = this.state;
    const { billArray } = this.state;

    searchbarInput = e.target.value;
    let bills = billArray.filter(bill => {
      return bill.guid.includes(searchbarInput);
    });

    this.setState({ searchbarInput, billsMatchingSearch: bills });
  };

  handleBillClick = index => {
    this.setState({
      displayedBill: this.state.billsMatchingSearch[index],
      billVisibility: { display: "inline-block" }
    });
  };

  fetchMoreData = () => {
    Axios.get("/api/bills/get-ten", { params: { startingPosition: 0 } }).then(
      response => {
        console.log(response.data);
        this.setState({ bills: this.state.bills.concat(response.data) });
      }
    );
  };

  render() {
    const {
      billsMatchingSearch,
      searchbarInput,
      displayedBill,
      billVisibility
    } = this.state;

    return (
      <div className="history-wrapper">
        <div>
          <h1>History</h1>

          <input
            className="bill-search"
            type="text"
            placeholder=" Search for a bill..."
            onChange={this.handleSearchInput}
            value={searchbarInput}
          />
          <div className="items-list">
            <InfiniteScroll
              dataLength={this.state.bills.length}
              next={this.fetchMoreData}
              hasMore={true}
              loader={<h4>Loading...</h4>}
            >
              <ul className="bills-container">
                {this.state.bills.map((bill, index) => (
                  <li onClick={() => this.handleBillClick(index)} key={index}>
                    {bill.guid}
                  </li>
                ))}
              </ul>
            </InfiniteScroll>
          </div>
        </div>

        <div style={billVisibility}>
          <Bill displayedBill={displayedBill} />
        </div>
      </div>
    );
  }
}
