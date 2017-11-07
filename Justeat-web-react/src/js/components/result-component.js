import React from "react";
import { Pagination, Glyphicon } from "react-bootstrap"
import Tag from "./tag-component";
import Rating from "./rating-component";

export default class Result extends React.Component {

    constructor() {
        super();
    }

    render() {

        const listRestaurants = this.props.data.restaurants.map((d) =>
            <div className="col-xs-12 col-lg-12">
                <div className="thumbnail">
                    <div className="caption">
                        <span><h4>  {d.Name} </h4></span>
                        <Rating num={d.RatingStars} />
                        <Tag tags={d.CuisineTypes} />
                    </div>
                </div>
            </div>);

        const basePaging = <div className="col-md-12">
                             <Pagination
                                        prev
                                        next
                                        first
                                        last
                                        items={Math.ceil(this.props.data.totalRecords/this.props.data.totalItems) -1 }
                                        maxButtons={5}
                                        activePage={this.props.data.page}
                                        onSelect={this.props.pageChanged} />
                            </div>
        return (
            <div className="row list-group">
                {listRestaurants}
                {basePaging }
            </div>
        );
    }
}
