import React from 'react'
import { Link } from 'react-router-dom'

const Post = (props) => {
    return (
      <div>
        <h1>{props.match.params.id}</h1>
        <Link to='/'>Back</Link>
      </div>
    )
  }

  export default Post