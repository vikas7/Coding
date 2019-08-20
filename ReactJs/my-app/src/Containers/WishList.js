import React from 'react'
import Product from '../components/Product';

class WishList extends React.Component {

    addItemToCart(product) {
        // this.props.history.push('/cart');
        console.log("does nothing");
    }
    render() {
        const pList = [{
            productId: 1000,
            productname: 'Product 1',
            productPrice: 1200,
            productStock: true,
            productImage: 'C:/Users/singhv33/Downloads/Coding/ReactJs/NewJavascript/image1.png'
        },
        {
            productId: 2000,
            productname: 'Product 2',
            productPrice: 2200,
            productStock: true,
            productImage: 'https://www.iconfinder.com/icons/4301503/coffee_cup_drinks_hot_relax_tea_icon'
        }];

        return (
            <div>
                {
                    pList.map(
                        (p, i) => <Product
                            {...this.props}
                            pdata={p}
                            key={p.productId}
                            code={this.props.cCode} />
                    )

                }
            </div>
        );
    }
}
export default WishList;