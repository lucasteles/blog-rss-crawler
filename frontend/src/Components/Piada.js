import React from 'react'
import me from '../me.jpg'
import './Piada.css'
import axios from 'axios'

export class PiadaPage extends React.Component {
    constructor() {
        super()
        this.state = {
            piada: [],
            loading: true,
            flipped: false
        }
    }

    async componentWillMount() {
        await this.loadPiada()
    }

    proxima = async () => {
        this.setState({ loading: true, flipped: !this.state.flipped })
        await this.loadPiada()
    }

    async loadPiada() {
        const url =
            'https://teles-jokes.azurewebsites.net/api/GetJoke?code=7skvGJHPnh6jOiZhwNKV0dL0awj9qTorLElJq596sKVHmrmgFJ6u4w=='
        const data = await axios.get(url)
        const piada = data.data.joke.split('|')
        this.setState({ loading: false, piada: piada })
    }
    render() {
        return (
            <div className="piada">
                <div className="center">
                    <img
                        className={
                            'foto ' + (this.state.flipped ? 'flip' : '')
                        }
                        src={me}
                    />
                </div>
                <div className="center">
                    <blockquote className="cite">
                        {this.state.loading && (
                            <img
                                className="p-loader"
                                src="https://68.media.tumblr.com/695ce9a82c8974ccbbfc7cad40020c62/tumblr_o9c9rnRZNY1qbmm1co1_500.gif"
                            />
                        )}
                        {!this.state.loading &&
                            this.state.piada.map((x, i) => (
                                <span key={i}>
                                    {x}
                                    <br />
                                </span>
                            ))}
                    </blockquote>
                    <br />
                    <code>npm install -g teles</code>
                    <br />
                    <button
                        className="button is-dark"
                        id="proxima"
                        onClick={this.proxima}
                    >
                        Proxima piada!
                    </button>
                </div>
            </div>
        )
    }
}
