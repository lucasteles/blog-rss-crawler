import React from 'react'
import { Link } from 'react-router-dom'
import renderHTML from 'react-render-html'
import { Loader } from './Loader'
import PostService from '../Services/PostService'

const postService = new PostService()

function toTitleCase(str) {
    return str.replace(
        /\w\S*/g,
        function(txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        }
    );
}
class FullPost extends React.Component {
    constructor() {
        super()
        this.state = { loaded: false }
    }

    async componentWillMount() {
        const post = await postService.GetPost(this.props.match.params.id)
        this.setState({ post, loaded: true })
    }

    render() {
        return (
            <div>
                <Loader hidden={this.state.loaded} />
                <div className="post" hidden={!this.state.loaded}>
                    <div className="blog-post">
                        <h1 className="post-title">
                            {this.state.post && this.state.post.title}
                        </h1>
                        <div>
                            {this.state.post &&
                                this.state.post
                                  .tags
                                  .map(x => x.toLocaleUpperCase())
                                  .filter((value, index, self) => self.indexOf(value) === index)
                                  .map(x => toTitleCase(x))
                                  .map(x => (
                                    <span className="tag is-info">{x}</span>
                                ))}
                        </div>
                        <hr />
                        <div className="description">
                            {this.state.post &&
                                renderHTML(this.state.post.description)}
                        </div>
                        <div className="description">
                            {this.state.post &&
                                renderHTML(this.state.post.content)}
                        </div>
                    </div>
                </div>
                <hr />
                <Link to="/" className="button is-dark">
                    Voltar
                </Link>
            </div>
        )
    }
}

export default FullPost
