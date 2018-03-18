import React from 'react'
import './Loader.css'

export const Loader = ({hidden}) => 
    <div className={"pageloader is-left-to-right " + (hidden ? "" : "is-active")}>
        <span className="title">Segura ai...</span>
    </div>
