import React, { Component } from 'react';
import { convertCurrency } from '../Services/Currency-service';
import Card from './Card';
import propTypes from 'prop-types'

const Product = (props) => {

    const { pdata, code, addToCart, isCart } = props;

    return (
        <Card size={3}>
            <img src={pdata.productImage} />
            <h3>{pdata.productName}</h3>
            <h4>{code} {convertCurrency(pdata.productPrice, code)}</h4>
            {
                pdata.productStock ?
                    <button onClick={() => addToCart}>
                        {isCart ? 'Add to Cart' : 'Add To Wishlist'}
                    </button> :
                    <p>Out of stock</p>
            }
            {/* {checkStock(pdata.productStock)}                 */}
        </Card>
    );

}

Product.propTypes = {
    pdata: propTypes.object.isRequired,
    code: propTypes.string
}
function checkStock(stock) {
    if (stock) {
        return <button>Add to cart</button>;
    }
    return <p>Out of stock</p>
}
export default Product;