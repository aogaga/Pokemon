import React from 'react';
import {BrowserRouter as Router, Routes, Route, Link} from "react-router-dom";
import logo from './logo.svg';
import './App.css';
import Header from './Header'
import DashBoard from './DashBoard';
import Details from './Details';

const App: React.FC = () => {
    return (
        <Router>
            <Header title="Pokemon App" />
            <nav>
                <Link to="/">Home</Link>
                <Link to="/details">Details</Link>
            </nav>
            <Routes>
                <Route path="/" element={<DashBoard />} />
                <Route path="/details" element={<Details />} />
            </Routes>

        </Router>
    );
};
export default App;
