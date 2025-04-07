import React, { useEffect, useState, useRef } from 'react';
import { Button, InputGroup, Form } from 'react-bootstrap';
import { Send, Clock, PersonFill, Robot } from 'react-bootstrap-icons';
import './ChatContainer.css';

const ChatContainer = ({ messages, sendMessage, darkMode }) => {
    const [showWelcomeMessage, setShowWelcomeMessage] = useState(true);
    const messagesEndRef = useRef(null);
    
    const welcomeMessage = {
        text: "👋 Добро пожаловать в FITR Assistant! Я здесь чтобы помочь вам с любыми вопросами. Просто напишите, и я постараюсь ответить! 😊",
        type: 'received',
        timestamp: new Date()
    };

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    };

    const handleKeyPress = (event) => {
        if (event.key === 'Enter' && !event.shiftKey) {
            event.preventDefault();
            handleSendMessage();
        }
    };

    const handleSendMessage = () => {
        sendMessage();
        if (showWelcomeMessage) setShowWelcomeMessage(false);
    };

    useEffect(() => {
        if (messages.length > 0) {
            setShowWelcomeMessage(false);
        }
        scrollToBottom();
    }, [messages]);

    const formatTime = (date) => {
        return new Date(date).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    };

    return (
        <div className={`chat-container ${darkMode ? 'dark' : ''}`}>
            <div className="messages" id="messages">
                {showWelcomeMessage && (
                    <div className="welcome-message animate__animated animate__fadeIn">
                        <div className="welcome-content">
                            <Robot size={40} className="welcome-icon" />
                            <div className="welcome-text">{welcomeMessage.text}</div>
                        </div>
                    </div>
                )}
                
                {messages.map((msg, index) => (
                    <div 
                        key={index} 
                        className={`message-container ${msg.type}-container animate__animated animate__fadeIn`}
                        style={{ animationDelay: `${index * 0.1}s` }}
                    >
                        <div className={`message ${msg.type}`}>
                            <div className="message-header">
                                {msg.type === 'sent' ? (
                                    <PersonFill className="user-icon" />
                                ) : (
                                    <Robot className="bot-icon" />
                                )}
                            </div>
                            <div className="message-content">
                                <div className="message-text">{msg.text}</div>
                                <div className="message-time">
                                    <Clock size={12} className="time-icon" />
                                    {formatTime(msg.timestamp)}
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
                <div ref={messagesEndRef} />
            </div>
            
            <div className="input-container">
                <InputGroup>
                    <Form.Control
                        as="textarea"
                        rows={1}
                        id="messageInput"
                        placeholder="Введите сообщение..."
                        onKeyPress={handleKeyPress}
                        className={`message-input ${darkMode ? 'dark' : ''}`}
                    />
                    <Button 
                        variant={darkMode ? "outline-light" : "primary"}
                        className="send-button"
                        onClick={handleSendMessage}
                    >
                        <Send size={20} />
                    </Button>
                </InputGroup>
            </div>
        </div>
    );
};

export default ChatContainer;