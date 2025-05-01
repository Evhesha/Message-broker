import React, { useEffect, useState, useRef } from 'react';
import { Button, Form, Spinner, Alert } from 'react-bootstrap';
import { Send, Clock, PersonFill, Robot } from 'react-bootstrap-icons';
import './ChatContainer.css'; // Убедитесь, что путь правильный
import { PostQuestion } from '../../Queries/Ollama/PostQuestion';

const ChatContainer = ({ 
    messages, 
    setMessages, 
    darkMode, 
    isWaitingForResponse, 
    setIsWaitingForResponse 
}) => {
    const [inputMessage, setInputMessage] = useState('');
    const [error, setError] = useState(null);
    const messagesEndRef = useRef(null);

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    };

    const handleKeyPress = (event) => {
        if (event.key === 'Enter' && !event.shiftKey && !isWaitingForResponse) {
            event.preventDefault();
            handleSendMessage();
        }
    };

    const handleSendMessage = async () => {
        if (!inputMessage.trim() || isWaitingForResponse) return;
    
        const userMessage = { text: inputMessage, type: 'sent', timestamp: new Date() };
        setMessages(prev => [...prev, userMessage]);
        setInputMessage('');
        setIsWaitingForResponse(true);
        setError(null);
    
        try {
            await PostQuestion({ question: inputMessage });
        } catch (error) {
            console.error('Error sending:', error);
            setError('There was an error sending your request');
            setIsWaitingForResponse(false);
        }
    };

    useEffect(() => {
        scrollToBottom();
    }, [messages]);

    return (
        <div className={`chat-container ${darkMode ? 'dark' : ''}`}>
            <div className="messages">
                {messages.map((msg, index) => (
                    <div 
                        key={index} 
                        className={`message-container ${msg.type}-container animate__animated animate__fadeIn`}
                        style={{ animationDelay: `${index * 0.1}s` }}
                    >
                        <div className={`message ${msg.type}`}>
                            <div className="message-header">
                                {msg.type === 'sent' ? <PersonFill className="user-icon" /> : <Robot className="bot-icon" />}
                            </div>
                            <div className="message-content">
                                <div className="message-text">{msg.text}</div>
                                <div className="message-time">
                                    <Clock size={12} className="time-icon" />
                                    {new Date(msg.timestamp).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
                
                {isWaitingForResponse && (
                    <div className="message-container received-container">
                        <div className="message received">
                            <div className="message-header">
                                <Robot className="bot-icon" />
                            </div>
                            <div className="message-content">
                                <div className="message-text typing-indicator">
                                    <Spinner animation="border" size="sm" role="status" />
                                    <span className="ms-2">The bot is typing...</span>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
                
                {error && (
                    <Alert variant="danger" className="mt-2">
                        {error}
                    </Alert>
                )}
                
                <div ref={messagesEndRef} />
            </div>
            
            <div className="input-container">
                <Form.Control
                    as="textarea"
                    rows={1}
                    value={inputMessage}
                    placeholder={isWaitingForResponse ? "Please wait for the bot to respond..." : "Enter message..."}
                    onChange={(e) => setInputMessage(e.target.value)}
                    onKeyPress={handleKeyPress}
                    className={`message-input ${darkMode ? 'dark' : ''}`}
                    disabled={isWaitingForResponse}
                />
                <Button 
                    variant="none"
                    className="send-button"
                    onClick={handleSendMessage}
                    disabled={isWaitingForResponse || !inputMessage.trim()}
                >
                    {isWaitingForResponse ? (
                        <Spinner animation="border" size="sm" />
                    ) : (
                        <Send size={20} />
                    )}
                </Button>
            </div>
        </div>
    );
};

export default ChatContainer;