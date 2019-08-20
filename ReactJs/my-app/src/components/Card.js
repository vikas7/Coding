import React from 'react';
import propTypes from 'prop-types';
import { createECDH } from 'crypto';

const Card = (props) => {
    const style = {
        border: '1px solid #000',
        padding: '10px',       
        boxSizing:'border-box',        
        float:'left',
        width:!props.size?'100%':`${100/props.size}%`
    }
    return (
        <div style={style}>
            {props.children}
        </div>
    );
}
Card.propTypes= {
    size:propTypes.number
};

Card.defaultProps={
    size:1
};

export default Card;