import React, { useEffect, useState } from 'react';
import './ChatContainer.css';

const ChatContainer = ({ messages, sendMessage }) => {
    const [showWelcomeMessage, setShowWelcomeMessage] = useState(true);
    
    const welcomeMessage = "👋 Привет! Я ваш личный чат-бот. Здесь, чтобы помочь вам с любыми вопросами. Просто напишите, и я постараюсь ответить! 😊";

    const handleKeyPress = (event) => {
        if (event.key === 'Enter') {
            sendMessage();
            if (showWelcomeMessage) {
                setShowWelcomeMessage(false);
            }
        }
    };

    const handleSendMessage = () => {
        sendMessage();
        if (showWelcomeMessage) {
            setShowWelcomeMessage(false);
        }
    };

    useEffect(() => {
        if (messages.length > 0) {
            setShowWelcomeMessage(false);
        }
    }, [messages]);

    return (
        <div className="chat-container">
            <div className="messages" id="messages">
                {showWelcomeMessage && (
                    <div className="welcome-message">
                        {welcomeMessage}
                    </div>
                )}
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
                <button className="button" onClick={handleSendMessage}>
                    Отправить
                </button>
            </div>
        </div>
    );
};

export default ChatContainer;