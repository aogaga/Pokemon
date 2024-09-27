import React from 'react';

interface HeaderProps {
    title: string;
}

const Header: React.FC<HeaderProps> = ({ title }) => {
    return (
        <header className="navbar bg-dark border-bottom border-body" data-bs-theme="dark">
            <div className="container">
                <h1 className="navbar-brand">{title}</h1>
            </div>

        </header>
    );
};

export default Header;