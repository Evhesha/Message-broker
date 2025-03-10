import React from 'react';
import './Sidebar.css';

const Sidebar = ({ toggleTheme, startNewChat, chatHistory }) => {
    return (
        <div className="sidebar">
            <button className="theme-toggle" onClick={toggleTheme}>Сменить тему</button>
            <button className="new-chat" onClick={startNewChat}>Новый чат</button>
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