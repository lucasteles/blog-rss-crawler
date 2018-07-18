import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../logo.png'

const Header = () => (
  <header>
      <nav className="navbar is-black">
        <div className="navbar-brand">
          <a className="navbar-item" href="https://lucasteles.net">
            <img src={logo}/> 
          </a>
        </div>
        <div id="nav-top" className="navbar-menu">
          <div className="navbar-start">
            <Link className="navbar-item" to='/'>Blog</Link>
            <a  className="navbar-item" href='/piada'>Piada</a>
          </div>

          <div className="navbar-end">
            <div className="navbar-item social-button">
              <a href="https://github.com/lucasteles"><i className="fab fa-github"></i></a>
              <a href="https://facebook.com/lucas.teles"><i className="fab fa-facebook"></i></a>
              <a href="https://twitter.com/lucasteles42"><i className="fab fa-twitter"></i></a>
              <a href="https://linkedin.com/in/lteles"><i className="fab fa-linkedin"></i></a>
              <a href="https://"><i className="fas fa-rss-square"></i></a>
            </div>
          </div>
        </div>
      </nav>
      
    </header>
)
        
export default Header