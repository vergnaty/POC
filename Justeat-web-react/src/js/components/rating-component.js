import React from 'react'
import { Glyphicon } from 'react-bootstrap'

export default class Rating extends React.Component {

  render () {
    var stars = []
    for (var i = 0; i < this.props.num; i++) {
      stars.push(<span bsSize='small'>< Glyphicon glyph = 'star'/></span>)
    }
    return ( <div> {stars}</div>)
  }
}
