import React, { useState } from 'react';
import './LoginModal.css';

const LoginModal = ({ onClose, isDarkTheme }) => {
    const [isRegistering, setIsRegistering] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        if (isRegistering) {
            if (password !== confirmPassword) {
                alert('Пароли не совпадают!');
                return;
            }
            console.log('Регистрация:', username, password);
        } else {
            console.log('Вход:', username, password);
        }
    };

    const handleGoogleLogin = () => {
        console.log('Вход через Google');
        // Тут будет реальный вход через Google
    };

    return (
        <div className={`modal-overlay ${isDarkTheme ? 'dark' : ''}`}>
            <div className="modal-content">
                <button className="close-button" onClick={onClose}>×</button>
                <h2>{isRegistering ? 'Регистрация' : 'Вход'}</h2>
                <form onSubmit={handleSubmit}>
                    <input 
                        type="text" 
                        placeholder="Имя пользователя" 
                        value={username} 
                        onChange={(e) => setUsername(e.target.value)} 
                        required 
                    />
                    <input 
                        type="password" 
                        placeholder="Пароль" 
                        value={password} 
                        onChange={(e) => setPassword(e.target.value)} 
                        required 
                    />
                    {isRegistering && (
                        <input 
                            type="password" 
                            placeholder="Повторите пароль" 
                            value={confirmPassword} 
                            onChange={(e) => setConfirmPassword(e.target.value)} 
                            required 
                        />
                    )}
                    <button type="submit" className="submit-button">
                        {isRegistering ? 'Зарегистрироваться' : 'Войти'}
                    </button>
                </form>

                <button onClick={handleGoogleLogin} className="google-button">
                    <img 
                        src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/google/google-original.svg" 
                        alt="Google Icon" 
                        className="google-icon" 
                    />
                    Войти через Google
                </button>

                <div className="register-text">
                    {isRegistering ? (
                        <span>Уже есть аккаунт? <a href="#" onClick={() => setIsRegistering(false)}>Войти</a></span>
                    ) : (
                        <span>Нет аккаунта? <a href="#" onClick={() => setIsRegistering(true)}>Зарегистрироваться</a></span>
                    )}
                </div>
            </div>
        </div>
    );
};

export default LoginModal;
