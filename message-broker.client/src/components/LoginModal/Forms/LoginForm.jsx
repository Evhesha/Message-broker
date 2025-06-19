import { useState } from 'react';
import { Login } from '../../../Queries/Auth/Login';
import '../LoginModal.css';

const LoginForm = ({ onSubmit, onGoogleLogin }) => {
    const [Email, setEmail] = useState('');
    const [Password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await Login({ Email: Email, Password: Password });
            console.log('Login successful:', result);
            onSubmit(result);
            setErrorMessage('');
        } catch (error) {
            setErrorMessage('Login failed. Please check your credentials.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input 
                type="text" 
                placeholder="Email" 
                value={Email} 
                onChange={(e) => setEmail(e.target.value)} 
                required 
            />
            <input 
                type="password" 
                placeholder="Password" 
                value={Password} 
                onChange={(e) => setPassword(e.target.value)} 
                required 
            />
            {errorMessage && <div className="error-message">{errorMessage}</div>}
            <button type="submit" className="submit-button">Login</button>
            <button onClick={onGoogleLogin} className="google-button">Login with Google</button>
        </form>
    );
};

export default LoginForm;
