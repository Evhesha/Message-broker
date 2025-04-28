import React, { useEffect, useState, useRef } from 'react';
import { Button, InputGroup, Form } from 'react-bootstrap';
import { Send, Clock, PersonFill, Robot } from 'react-bootstrap-icons';
import './ChatContainer.css';
import { PostQuestion } from '../../Queries/Ollama/PostQuestion';

const ChatContainer = ({ messages, setMessages, darkMode }) => {
    const [inputMessage, setInputMessage] = useState('');
    const messagesEndRef = useRef(null);

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    };

    const handleKeyPress = (event) => {
        if (event.key === 'Enter' && !event.shiftKey) {
            event.preventDefault();
            handleSendMessage();
        }
    };

    const handleSendMessage = async () => {
        if (!inputMessage.trim()) return;
    
        const userMessage = { text: inputMessage, type: 'sent', timestamp: new Date() };
        setMessages([...messages, userMessage]);
    
        try {
            const response = await PostQuestion({ question: inputMessage });
            console.log(response.message)
            setMessages([...messages, userMessage]); 
        } catch (error) {
            console.error('Ошибка при отправке:', error);
        }
    
        setInputMessage('');
        scrollToBottom();
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
                <div ref={messagesEndRef} />
            </div>
            
            <div className="input-container">
                <InputGroup>
                    <Form.Control
                        as="textarea"
                        rows={1}
                        value={inputMessage}
                        placeholder="Введите сообщение..."
                        onChange={(e) => setInputMessage(e.target.value)}
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