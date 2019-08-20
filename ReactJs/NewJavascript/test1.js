// new variable types

for(let i=0;i<10;i++){
    setTimeout(function(){
        console.log(i);
    },i*100);
}

// const a=10;
// a=20;

// template literals / string literals
// ``
const name='vikas';
const msg=`hello ${name}`;
console.log(msg);

const user={
    name2:'vikas',
    age:21
}
const {age}=user;
console.log(age);

//Arrow functions
// input => expressions
// if one line expression then no need to  use retun statemment
//otherwise user return statement

const test1 = () => 'value';
const test2= () => ({value1:'value2', value3:'value3'});
console.log(test1());
console.log(test2().value1+" "+test2().value3);