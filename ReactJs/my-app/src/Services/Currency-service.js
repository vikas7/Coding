/* this is service layer basically it does the calculation part and business logic should be
written here*/


export const convertCurrency=(price,code)=>{

    switch(code){
        case 'USD':price/=70;
        break;
        case 'EUR': price/=87;
        break;
        case 'CAD': price/=78;
        break;
    }
    return price.toFixed(2);
}