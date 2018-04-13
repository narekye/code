"use strict";
import React from 'react';
export default function() {
    const element = (
        <div>
            <h2> It is {new Date().toLocaleTimeString()} </h2>
        </div>
    );
    return element;
}