import React, { Component } from 'react';


class Demo extends Component {
    showAlert(a){
        alert('hello from react'+a);
    }
    render() {
        const name = 'vikas';
        return (
            <div>
                <p>Hello from {name}</p>
                <p>Welcome to react {4 + 5}</p>
                <button onClick={() =>this.showAlert('test')}>Click Me</button>
            </div>
        );
    }

}
export default Demo;