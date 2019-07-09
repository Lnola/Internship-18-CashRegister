import React, { Component } from "react";
import "./BillHistory.css";
import { Bill } from "./Bill";
import InfiniteScroll from "react-infinite-scroll-component";
import { getTenBills, getSimilarBills } from "../utils";

export class BillHistory extends Component {
  static displayName = BillHistory.name;

  constructor(props) {
    super(props);
    this.state = {
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
      hasMore: true,
      startingPosition: 10
    };
  }

  componentDidMount() {
    getTenBills(0).then(response => {
      this.setState({
        billsMatchingSearch: response.data
      });

      if (response.data.length < 10) this.setState({ hasMore: false });
    });
  }

  handleSearchInput = e => {
    let { searchbarInput } = this.state;

    searchbarInput = e.target.value;
    this.setState({ searchbarInput });

    if (searchbarInput.length > 3)
      getSimilarBills(searchbarInput).then(response => {
        this.setState({
          billsMatchingSearch: response.data
        });
      });
    else if (searchbarInput.length === 0) {
      this.setState({
        billsMatchingSearch: [],
        startingPosition: 0,
        hasMore: true
      });

      setTimeout(() => {
        this.fetchMoreData();
      }, 300);
    }
  };

  handleBillClick = index => {
    this.setState({
      displayedBill: this.state.billsMatchingSearch[index],
      billVisibility: { display: "inline-block" }
    });
  };

  fetchMoreData = () => {
    const { startingPosition, billsMatchingSearch } = this.state;

    getTenBills(startingPosition).then(response => {
      if (response.data.length === 0) this.setState({ hasMore: false });
      else
        this.setState({
          billsMatchingSearch: billsMatchingSearch.concat(response.data),
          startingPosition: startingPosition + 10
        });
    });
    console.log(this.state.billsMatchingSearch.length);
  };

  render() {
    const {
      billsMatchingSearch,
      searchbarInput,
      displayedBill,
      billVisibility,
      hasMore
    } = this.state;

    return (
      <div className="history-wrapper">
        <div>
          <h1>History</h1>

          <input
            className="bill-search"
            type="text"
            onChange={this.handleSearchInput}
            value={searchbarInput}
            placeholder="Date format yyyy-mm-dd..."
          />

          <div className="items-list">
            <InfiniteScroll
              dataLength={billsMatchingSearch.length}
              next={this.fetchMoreData}
              hasMore={hasMore}
              loader={
                <p>
                  <b>Loading...</b>
                </p>
              }
              height={400}
              endMessage={
                <p>
                  <b>No more bills</b>
                </p>
              }
            >
              <ul className="bills-container">
                {billsMatchingSearch.map((bill, index) => (
                  <li onClick={() => this.handleBillClick(index)} key={index}>
                    <p>{bill.guid}</p> - <p>{bill.issueDate}</p>
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
