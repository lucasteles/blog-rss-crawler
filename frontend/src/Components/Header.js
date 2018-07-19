import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../logo.png'
import config from '../Config'

export default class Header extends React.Component {
    constructor() {
        super()
        this.state = { menuOpen: false }
    }

    toggleMenu = () => {
        console.log(this.state)
        this.setState({ menuOpen: !this.state.menuOpen })
        console.log(this.state)
    }

    render() {
        const isActive = this.state.menuOpen ? ' is-active' : ''
        return (
            <header>
                <nav className="navbar is-black">
                    <div className="navbar-brand">
                        <a
                            className="navbar-item"
                            href="https://lucasteles.net"
                        >
                            <img src={logo} />
                        </a>
                        <div
                            className={'navbar-burger burger' + isActive}
                            data-target="nav-top"
                            onClick={this.toggleMenu}
                        >
                            <span /> <span /> <span />
                        </div>
                    </div>
                    <div id="nav-top" className={'navbar-menu' + isActive}>
                        <div className="navbar-start">
                            <Link className="navbar-item" to="/">
                                Blog
                            </Link>
                            <Link className="navbar-item" to="/piada">
                                Piada
                            </Link>
                        </div>

                        <div className="navbar-end">
                            <div className="navbar-item social-button">
                                <div className="field is-grouped">
                                    <a target="_blank" href="https://github.com/lucasteles">
                                        <i className="fab fa-github" />
                                    </a>
                                    <a target="_blank" href="https://facebook.com/lucas.teles">
                                        <i className="fab fa-facebook" />
                                    </a>
                                    <a target="_blank" href="https://twitter.com/lucasteles42">
                                        <i className="fab fa-twitter" />
                                    </a>
                                    <a target="_blank" href="https://linkedin.com/in/lteles">
                                        <i className="fab fa-linkedin" />
                                    </a>
                                    <a target="_blank" href={`${config.baseUrl}${config.urls.GetFeed}`}>
                                        <i className="fas fa-rss-square" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </nav>
            </header>
        )
    }
}
