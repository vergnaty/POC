import React from "react";
import Result from "./result-component";
import DataAccess from "../server/graphql-data-access"

export default class Main extends React.Component {

    constructor() {
        super();
        this.state = { q: "se19", page: 1, totalItems: 10, totalRecords :0, restaurants: [] };
    }

    componentDidMount() {
        this.getData(1);
    }

    getData = (page) => {
        this.setState({ page: page });
        DataAccess.getRestaurants(this.state.q,page,this.state.totalItems).then(d => {
            this.setState({ restaurants: d.data.restaurants.items });
            this.setState({ totalRecords: d.data.restaurants.totalRecords });
            console.log(d.data.restaurants.totalRecords);
        });
    }

    queryChanged(event) {
        this.setState({ q: event.target.value });
    }

     pageChanged(value) {
        this. getData(value);
    }

    render() {
        return (
            <div className="row">
                <div className="col-md-12">
                    <div class="input-group">
                        <input type="text" class="form-control" value={this.state.q} onChange={(e) => this.queryChanged(e)} />
                        <span class="input-group-addon search-btn" onClick={() => this.getData(1)}>Search</span>
                    </div>
                </div>
                <div className="col-md-12">
                    <Result data={this.state} pageChanged={(value)=> this.pageChanged(value)} />
                 </div>
            </div>
        );
    }
}
