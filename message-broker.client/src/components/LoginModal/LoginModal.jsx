import React, { useState } from 'react';
import './LoginModal.css';

const LoginModal = ({ onClose, isDarkTheme }) => {
    const [isRegistering, setIsRegistering] = useState(false);
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        if (isRegistering) {
            if (password !== confirmPassword) {
                setErrorMessage('Passwords do not match!');
                return;
            }
            if (!email.includes('@')) {
                setErrorMessage('Please enter a valid email.');
                return;
            }
            console.log('Registration:', username, email, password);
            setErrorMessage('');
        } else {
            console.log('Login:', username, password);
            setErrorMessage('');
        }
    };

    const handleGoogleLogin = () => {
        console.log('Login with Google');
        // Здесь будет логика авторизации через Google
    };

    return (
        <div className={`modal-overlay ${isDarkTheme ? 'dark' : ''}`}>
            <div className="modal-content">
                <button className="close-button" onClick={onClose}>×</button>
                <h2>{isRegistering ? 'Registration' : 'Login'}</h2>
                <form onSubmit={handleSubmit}>
                    <input 
                        type="text" 
                        placeholder="Username" 
                        value={username} 
                        onChange={(e) => setUsername(e.target.value)} 
                        required 
                    />
                    {isRegistering && (
                        <input 
                            type="email" 
                            placeholder="Email" 
                            value={email} 
                            onChange={(e) => setEmail(e.target.value)} 
                            required 
                        />
                    )}
                    <input 
                        type="password" 
                        placeholder="Password" 
                        value={password} 
                        onChange={(e) => setPassword(e.target.value)} 
                        required 
                    />
                    {isRegistering && (
                        <input 
                            type="password" 
                            placeholder="Repeat password" 
                            value={confirmPassword} 
                            onChange={(e) => setConfirmPassword(e.target.value)} 
                            required 
                        />
                    )}

                    {errorMessage && (
                        <div className="error-message">{errorMessage}</div>
                    )}

                    <button type="submit" className="submit-button">
                        {isRegistering ? 'Register' : 'Login'}
                    </button>
                </form>

                <button onClick={handleGoogleLogin} className="google-button">
                    <img 
                        src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/google/google-original.svg" 
                        alt="Google Icon" 
                        className="google-icon" 
                    />
                    {isRegistering ? 'Sign up with Google' : 'Login with Google'}
                </button>

                <div className="register-text">
                    {isRegistering ? (
                        <span> Already have an account? <a href="#" onClick={() => setIsRegistering(false)}>Login</a></span>
                    ) : (
                        <span> Don't have an account? <a href="#" onClick={() => setIsRegistering(true)}>Register</a></span>
                    )}
                </div>
            </div>
        </div>
    );
};

export default LoginModal;
