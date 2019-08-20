import React, {Component} from 'react';

class UserFormRef extends React.Component{

    user={
        name:null,
        email:null
    }
    saveData(e){
        e.preventDefault();
        console.log('form submitted', this.user.name.value);          
    }
    render(){
        return (
            <form onSubmit={(e) => this.saveData(e)}>
                <label>Name</label>
                <input type="text" ref={r=>this.user.name=r}/>
                <label>Email</label>
                <input type="text" ref={r => this.user.email=r}/>
                <button>Submit</button>
            </form>
        );
    }
}

export default UserFormRef;