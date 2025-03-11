import React from 'react';
import './MessageHistory.css';

const MessageHistory = ({ messages }) => {
    return (
        <div className="message-history">
            {messages.map((msg, index) => (
                <div key={index} className={`message ${msg.type}`}>
                    {msg.text}
                </div>
            ))}
        </div>
    );
};

export default MessageHistory;