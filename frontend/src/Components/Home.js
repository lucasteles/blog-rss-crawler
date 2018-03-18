import React from 'react'
import PostService from '../Services/PostService'
import Post from './Post'
import {Loader} from './Loader'
import './Home.css'

const postService = new PostService()

class Home extends React.Component {
  constructor() {
     super()
     this.state = { posts : [], loaded:false }
  }

  async componentWillMount() {
      const posts = await postService.GetAllPosts()
      this.setState({posts, loaded:true})
  }

   render() { 
     return (
      <div>
        <Loader hidden={this.state.loaded}/>
         <div className="posts" hidden={!this.state.loaded}>
          { this.state.posts.map(p => <Post key={p.id} {...p} />) }
         </div>
      </div>
     )}

}
export default Home
