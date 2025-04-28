import React, { useState } from 'react';
import ChatContainer from './components/ChatContainer/ChatContainer';
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
        }
    };

    const toggleTheme = () => {
        setDarkMode((prev) => !prev);
    };

    const startNewChat = () => {
        setMessages([]);
        setChatHistory((prevHistory) => [...prevHistory, { title: `Чат ${chatHistory.length + 1}`, messages: [] }]);
    };

    // Обработчик входящих сообщений от SignalR
    const handleSignalRMessage = (signalRMessage) => {
        setMessages((prevMessages) => [...prevMessages, { text: signalRMessage, type: 'received' }]);
    };

    return (
        <div className={`app-container ${darkMode ? 'dark' : ''}`}>
            <Sidebar toggleTheme={toggleTheme} startNewChat={startNewChat} chatHistory={chatHistory} />
            <div className="chat-area">
                <ChatContainer messages={messages} setMessages={setMessages} sendMessage={sendMessage} />
            </div>
            <SignalRConsoleLogger onMessageReceived={handleSignalRMessage} />
        </div>
    );
};

export default App;