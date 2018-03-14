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
            <Link  className="navbar-item" to='/piada'>Piada</Link>
          </div>

          <div className="navbar-end">
            <div className="navbar-item social-button">
              <a><i className="fab fa-github"></i></a>
              <a><i className="fab fa-facebook"></i></a>
              <a><i className="fab fa-twitter"></i></a>
              <a><i className="fab fa-linkedin"></i></a>
              <a><i className="fas fa-rss-square"></i></a>

            </div>
          </div>
        </div>
      </nav>
      
    </header>
)
        
export default Header