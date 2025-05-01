import React, { useState } from 'react';
import ChatContainer from './components/ChatContainer/ChatContainer';
import Sidebar from './components/Sidebar/Sidebar';
import SignalRConsoleLogger from './components/SignalRConsolerLogger';
import './App.css';

const App = () => {
    const [messages, setMessages] = useState([]);
    const [darkMode, setDarkMode] = useState(false);
    const [chatHistory, setChatHistory] = useState([]);
    const [isWaitingForResponse, setIsWaitingForResponse] = useState(false);

    const toggleTheme = () => {
        setDarkMode((prev) => !prev);
    };

    const startNewChat = () => {
        setMessages([]);
        setChatHistory((prevHistory) => [...prevHistory, { title: `Chat ${chatHistory.length + 1}`, messages: [] }]);
    };

    const handleSignalRMessage = (signalRMessage) => {
        setMessages((prevMessages) => [...prevMessages, { text: signalRMessage, type: 'received', timestamp: new Date() }]);
        setIsWaitingForResponse(false);
    };

    return (
        <div className={`app-container ${darkMode ? 'dark' : ''}`}>
            <Sidebar toggleTheme={toggleTheme} startNewChat={startNewChat} chatHistory={chatHistory} />
            <div className="chat-area">
                <ChatContainer 
                    messages={messages} 
                    setMessages={setMessages} 
                    darkMode={darkMode}
                    isWaitingForResponse={isWaitingForResponse}
                    setIsWaitingForResponse={setIsWaitingForResponse}
                />
            </div>
            <SignalRConsoleLogger onMessageReceived={handleSignalRMessage} />
        </div>
    );
};

export default App;