import React, { useState } from 'react';
import ChatContainer from './components/ChatContainer/ChatContainer';
import MessageHistory from './components/MessageHistory/MessageHistory';
import Sidebar from './components/Sidebar/Sidebar';
import SignalRConsoleLogger from './components/SignalRConsolerLogger';
import './App.css';

const App = () => {
    const [messages, setMessages] = useState([]);
    const [darkMode, setDarkMode] = useState(false);
    const [chatHistory, setChatHistory] = useState([]);

    const sendMessage = (messageText) => {
        if (messageText.trim()) {
            setMessages((prevMessages) => [...prevMessages, { text: messageText, type: 'sent' }]);
            simulateResponse(messageText);
        }
    };

    const simulateResponse = (userMessage) => {
        setTimeout(() => {
            setMessages((prevMessages) => [...prevMessages, { text: `Вы сказали: "${userMessage}"`, type: 'received' }]);
        }, 1000);
    };

    const toggleTheme = () => {
        setDarkMode((prev) => !prev);
    };

    const startNewChat = () => {
        setMessages([]);
        setChatHistory((prevHistory) => [...prevHistory, { title: `Чат ${chatHistory.length + 1}`, messages: [] }]);
    };

    return (
        <div className={`app-container ${darkMode ? 'dark' : ''}`}>
            <Sidebar toggleTheme={toggleTheme} startNewChat={startNewChat} chatHistory={chatHistory} />
            <div className="chat-area">
                <MessageHistory messages={messages} />
                <ChatContainer messages={messages} setMessages={setMessages} sendMessage={sendMessage} />
            </div>
            <SignalRConsoleLogger></SignalRConsoleLogger>
        </div>
    );
};

export default App;
