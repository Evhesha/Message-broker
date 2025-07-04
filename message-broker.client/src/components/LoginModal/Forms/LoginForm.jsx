import { useState } from 'react';
import { Login } from '../../../Queries/Auth/Login';
import '../LoginModal.css';

import {toast } from 'react-toastify';

const LoginForm = ({ onSubmit, onGoogleLogin }) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    
    const notifyLight = () => toast.success('Login success!', {
        autoClose: 3000,
        draggable: true,
        theme: "light",
        });

    const notifyDark = () => toast.success('Login success!', {
        autoClose: 3000,
        draggable: true,
        theme: "dark",
        });

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await Login({ Email: email, Password: password });
            notifyDark();
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
                value={email} 
                onChange={(e) => setEmail(e.target.value)} 
                required 
            />
            <input 
                type="password" 
                placeholder="Password" 
                value={password} 
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
