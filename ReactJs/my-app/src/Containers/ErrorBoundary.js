import React, {Component} from 'react';

class ErrorBoundary extends Component{

    state={
        hasError:false
    }

    static getDerivedStateFromError(){
        return {hasError:true};
    }

    componentDidCatch(err, info){
        console.log(err, info);
    }

    render(){
        if(this.state.hasError){
            return <p>Something went wrong</p>
        }
        return this.props.children;        
    }
}

export default ErrorBoundary;