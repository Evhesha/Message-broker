import LoginForm from './Forms/LoginForm.jsx';
import RegisterForm from './Forms/RegisterForm.jsx';
import { useState } from 'react';

const LoginModal = ({ onClose, isDarkTheme }) => {
    const [isRegistering, setIsRegistering] = useState(false);

    const handleSubmit = (data) => {
        console.log(isRegistering ? 'Registration:' : 'Login:', data);
    };

    const handleGoogleLogin = () => {
        console.log('Login with Google');
    };

    return (
        <div className={`modal-overlay ${isDarkTheme ? 'dark' : ''}`}>
            <div className="modal-content">
                <button className="close-button" onClick={onClose}>×</button>
                <h2>{isRegistering ? 'Registration' : 'Login'}</h2>
                
                {isRegistering ? (
                    <RegisterForm onSubmit={handleSubmit} onGoogleLogin={handleGoogleLogin} />
                ) : (
                    <LoginForm onSubmit={handleSubmit} onGoogleLogin={handleGoogleLogin} />
                )}

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
