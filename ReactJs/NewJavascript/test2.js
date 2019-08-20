// lexical scoping

let obj={
    value:12,
    test:function(){let self=this; 
        setTimeout(() => {
        console.log('VALUE', self.value);
    }, 100);}
}

let obj2={
    value:12,
    test:function(){
        console.log('VALUE', self.value);
    }
}

let someOb=obj.test.bind();
console.log(someOb());

// use arrow function thne no need to do binding

let obj3={
    value:12,
    test:() =>{console.log(this.value)}
}

let someObj2=obj3.test();
console.log(someObj2);
