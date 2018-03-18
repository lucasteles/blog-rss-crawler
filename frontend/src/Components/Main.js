import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Home from './Home'
import FullPost from './FullPost'
import {Presentation} from './Presentation'

const Main = () => (
  <main>
     <div className="columns is-centered blog-main">
       <div className="column is-half is-narrow">
         <Switch>
            <Route exact path='/:id' component={FullPost}/>
            <Route exact path='/' component={Home}/>
            <Route path='/post/:id' component={FullPost}/>
         </Switch>
       </div>
       <div className="column is-4">
          <Presentation />    
       </div>

      </div>
   
  </main>
)

export default Main