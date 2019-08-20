import React, { Component } from 'react';
import Product from '../components/Product'
import { getProducts } from '../Services/Product-service'
import {connect} from 'react-redux';
import { addToCart } from '../store/actions/cart-action';

class ProductList extends Component {

    state = {
        pList: []
    };

    componentDidMount() {
        this.getData();
    }

    getData() {
        getProducts().
            then(
                (response) => this.setState({ pList: response.data })
            ).
            catch(
                (err) => console.log('error', err)
            );
    }
    addItemToCart(product) {
        this.props.addItem(product);
        this.props.history.push('/cart');
    }

    render() {
        console.log(this.props);
        // const pList = [{
        //     productId: 1000,
        //     productname: 'Product 1',
        //     productprice: 1200,
        //     productStock: true,
        //     productImage: 'C:/Users/singhv33/Downloads/Coding/ReactJs/NewJavascript/image1.png'
        // },
        // {
        //     productId: 2000,
        //     productname: 'Product 2',
        //     productprice: 2200,
        //     productStock: true,
        //     productImage: 'https://www.iconfinder.com/icons/4301503/coffee_cup_drinks_hot_relax_tea_icon'
        // }];
        return (
            <div>
                {
                    this.state.pList.map(
                        (p, i) =>
                            <Product
                                {...this.props}
                                isCart
                                pdata={p}
                                key={p.productId}
                                code={this.props.cCode}
                                addToCart={() => this.addItemToCart(p)} />
                    )

                }
            </div>
        )
    }
}

const mapStateToProps =(state) =>({
    cCode:state.currency
});

const mapDispatchToProps=(dispatch) =>({
    addItem:(p) =>dispatch(addToCart(p))
})

export default connect(mapStateToProps,mapDispatchToProps)(ProductList);