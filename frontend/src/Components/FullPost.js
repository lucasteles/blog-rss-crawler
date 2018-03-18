import React from 'react'
import { Link } from 'react-router-dom'
import renderHTML from 'react-render-html'
import {Loader} from './Loader'  
import PostService from '../Services/PostService'


const postService = new PostService()

class FullPost extends React.Component {
  constructor() {
     super()
     this.state = {  loaded:false }
  }
  
  async componentWillMount() {
      const post = await postService.GetPost(this.props.match.params.id)
      this.setState({post, loaded:true})
  }

   render() { 
     return (
      <div>
        <Loader hidden={this.state.loaded}/>
         <div className="post" hidden={!this.state.loaded}>
         <div className="blog-post">
            <h1> 
              {this.state.post && this.state.post.title}
             </h1>
             <div className="description">{ this.state.post && renderHTML( this.state.post.description)}</div>
             <div className="description">{ this.state.post && renderHTML( this.state.post.content)}</div>
           </div>
          </div>
         <Link to='/'>Voltar</Link>
      </div>
     )}

}

  export default FullPost