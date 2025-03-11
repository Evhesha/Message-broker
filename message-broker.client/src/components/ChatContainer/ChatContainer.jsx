import React from 'react';
import './ChatContainer.css';


const ChatContainer = ({ messages, sendMessage }) => {
    const handleKeyPress = (event) => {
        if (event.key === 'Enter') {
            sendMessage();
        }
    };

    return (
        <div className="chat-container">
            <div className="messages" id="messages">
                {messages.map((msg, index) => (
                    <div key={index} className={`message ${msg.type}`}>
                        {msg.text}
                    </div>
                ))}
            </div>
            <div className="input-container">
                <input
                    type="text"
                    id="messageInput"
                    placeholder="Введите сообщение..."
                    autoFocus
                    onKeyPress={handleKeyPress}
                />

                <button class='button' onClick={sendMessage}>Отправить</button>
            </div>
        </div>
    );
};

export default ChatContainer;