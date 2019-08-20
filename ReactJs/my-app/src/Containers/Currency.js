import React, { Component } from 'react';
import {connect} from 'react-redux';
import { updateCurrency } from '../store/actions/currency-actions';

class Currency extends Component{

  
    render(){
        const CurrencyCodes=['USD','INR','EUR','CAD']
        return (
            

            <select onChange={(e) => this.props.changeCurrency(e.currentTarget.value)}>
                {
                    CurrencyCodes.map(
                        code =><option value={code} key={code}>{code}</option>
                        )
                    }
            </select>
                    
        )
    }
}

const mapDispatchToProps= (dispatch) =>({
    changeCurrency:(c)=>dispatch(updateCurrency(c))
});

export default connect(null,mapDispatchToProps)(Currency);