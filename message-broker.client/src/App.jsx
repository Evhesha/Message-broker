import React, { useState } from 'react';
import ChatContainer from './components/ChatContainer/ChatContainer';
import MessageHistory from './components/MessageHistory/MessageHistory';
import Sidebar from './components/Sidebar/Sidebar';
import './App.css';

const App = () => {
    const [messages, setMessages] = useState([]);
    const [darkMode, setDarkMode] = useState(false);
    const [chatHistory, setChatHistory] = useState([]);

    const sendMessage = () => {
        const input = document.getElementById('messageInput');
        const messageText = input.value.trim();
        if (messageText) {
            setMessages((prevMessages) => [
                ...prevMessages,
                { text: messageText, type: 'sent' },
            ]);
            input.value = '';
            simulateResponse(messageText);
        }
    };

    const simulateResponse = (userMessage) => {
        setTimeout(() => {
            const responseMessage = `Вы сказали: "${userMessage}"`;
            setMessages((prevMessages) => [
                ...prevMessages,
                { text: responseMessage, type: 'received' },
            ]);
        }, 1000);
    };

    const toggleTheme = () => {
        setDarkMode((prev) => !prev);
    };

    const startNewChat = () => {
        setMessages([]);
        const chatTitle = `Чат ${chatHistory.length + 1}`;
        setChatHistory((prevHistory) => [
            ...prevHistory,
            { title: chatTitle, messages: [] },
        ]);
    };

    return (
        <div className={`app-container ${darkMode ? 'dark' : ''}`}>
            <Sidebar toggleTheme={toggleTheme} startNewChat={startNewChat} chatHistory={chatHistory} />
            <div className="chat-area">
                <MessageHistory messages={messages} />
                <ChatContainer messages={messages} sendMessage={sendMessage} />
            </div>
        </div>
    );
};

export default App;