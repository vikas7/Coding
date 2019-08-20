import React from 'react';
import logo from './logo.svg';
import './App.css';
import Menu from './ui/containers/Menu';
import AppRouter from './Router';
import {BrowserRouter as Router} from 'react-router-dom'

const App: React.FC = () => {
  return (
    <Router>
      <Menu/>
      <AppRouter/>
    </Router>    
  );
}

export default App;
