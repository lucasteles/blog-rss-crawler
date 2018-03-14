import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../logo.png'

const Header = () => (
  <header>
      <nav className="navbar is-transparent">
        <div className="navbar-brand">
          <a className="navbar-item" href="https://lucasteles.net">
            <img src={logo}/>
          </a>
        </div>
        <div id="nav-top" className="navbar-menu">
          <div className="navbar-start">
            <a className="navbar-item" href="https://bulma.io/">
              Home
            </a>
            <div className="navbar-item has-dropdown is-hoverable">
              <a className="navbar-link" href="/documentation/overview/start/">
                Docs
              </a>
              <div className="navbar-dropdown is-boxed">
                <a className="navbar-item" href="/documentation/overview/start/">
                  Overview
                </a>
                <a className="navbar-item" href="https://bulma.io/documentation/modifiers/syntax/">
                  Modifiers
                </a>
                <a className="navbar-item" href="https://bulma.io/documentation/columns/basics/">
                  Columns
                </a>
                <a className="navbar-item" href="https://bulma.io/documentation/layout/container/">
                  Layout
                </a>
                <a className="navbar-item" href="https://bulma.io/documentation/form/general/">
                  Form
                </a>
                <hr className="navbar-divider" />
                <a className="navbar-item" href="https://bulma.io/documentation/elements/box/">
                  Elements
                </a>
                <a className="navbar-item is-active" href="https://bulma.io/documentation/components/breadcrumb/">
                  Components
                </a>
              </div>
            </div>
          </div>

          <div className="navbar-end">
            <div className="navbar-item">
          
            </div>
          </div>
        </div>
      </nav>
    </header>
)


{/* <li><Link to='/'>Home</Link></li>
        <li><Link to='/post'>Post</Link></li> */}

        
export default Header