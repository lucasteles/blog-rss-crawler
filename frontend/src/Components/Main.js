import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Home from './Home'
import Post from './Post'

const Main = () => (
  <main>
    <Switch>
      <Route exact path='/:id' component={Post}/>
      <Route exact path='/' component={Home}/>
      <Route path='/post/:id' component={Post}/>
    </Switch>
  </main>
)

export default Main