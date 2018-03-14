import React from 'react'
import PostService from '../Services/PostService'

const postService = new PostService()

class Home extends React.Component {
  constructor() {
     super()
     this.state = { posts : [] }
  }

  async componentWillMount() {
      const posts = await postService.GetAllPosts()
      this.setState({posts})
  }

   render() { 
     return (
      <div>
       <h1>Welcome to Casteles Website!</h1>
       { this.state.posts.map(p => <div>{JSON.stringify(p)  }</div>) }
      </div>)
    }

}
export default Home
