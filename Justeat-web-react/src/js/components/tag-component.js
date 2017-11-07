import React from "react";

export default class Tag extends React.Component {

    render() {
        const items = this.props.tags.map((d) => <span className="tag label-info">{d.Name}</span>);
        return (<div className="row">
            <div className="col-xs-12 col-lg-12">
                {items}
            </div>
        </div>);
    }
}
