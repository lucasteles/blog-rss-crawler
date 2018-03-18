import React from 'react'
import renderHTML from 'react-render-html'
import './Post.css'
import { Link } from 'react-router-dom'

const Post = ({title, description, path}) => {
    return (
      <div className="blog-post">
      <h1> 
        <span className="anchor">#</span> 
        <Link to={path}>{title}</Link>
      </h1>
      <div className="description">{renderHTML(description)}</div>
      
      </div>
    )
  }

export default Post