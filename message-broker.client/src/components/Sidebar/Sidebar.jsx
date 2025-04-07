import React from 'react';
import './Sidebar.css';
import { Sun, Moon, Globe, BoxArrowInRight } from 'react-bootstrap-icons';

const Sidebar = ({ toggleTheme, startNewChat, chatHistory, isDarkTheme, toggleLanguage }) => {
    return (
        <div className={`sidebar ${isDarkTheme ? 'dark' : ''}`}>
            <div className="sidebar-header">
                <button 
                    className="btn theme-toggle" 
                    onClick={toggleTheme}
                    title={isDarkTheme ? 'Switch to light theme' : 'Switch to dark theme'}
                >
                    {isDarkTheme ? <Moon size={18} /> : <Sun size={18} />}
                </button>
                
                <button 
                    className="btn language-toggle"
                    onClick={toggleLanguage}
                    title="Switch language"
                >
                    <Globe size={18} />
                </button>
                
                <button className="login-button">
                    <span className="login-text">Вход</span>
                    <BoxArrowInRight size={18} className="login-icon" />
                </button>
            </div>
            
            <button className="new-chat" onClick={startNewChat}>
                Новый чат
            </button>
            
            <h3>История сообщений</h3>
            <ul className="chat-list">
                {chatHistory.map((chat, index) => (
                    <li key={index} className="chat-title">{chat.title}</li>
                ))}
            </ul>
        </div>
    );
};

export default Sidebar;