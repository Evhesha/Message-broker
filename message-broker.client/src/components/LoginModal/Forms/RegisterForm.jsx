import { useState } from 'react';
import { Register } from '../../../Queries/Auth/Register';
import '../LoginModal.css';


import { ToastContainer, toast } from 'react-toastify';

const RegisterForm = ({ onSubmit, onGoogleLogin }) => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        if (password !== confirmPassword) {
            setErrorMessage('Passwords do not match!');
            return;
        }
        if (!email.includes('@')) {
            setErrorMessage('Please enter a valid email.');
            return;
        }
        
        const notify = () => toast("Wow so easy!");

        const result = Register({Name: username, Email: email, Password: password});
        console.log("Success: ", result);
        onSubmit(result);
        setErrorMessage('');
    };

    return (
        <form onSubmit={handleSubmit}>
            <input 
                type="text" 
                placeholder="Username" 
                value={username} 
                onChange={(e) => setUsername(e.target.value)} 
                required 
            />
            <input 
                type="email" 
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
            <input 
                type="password" 
                placeholder="Repeat password" 
                value={confirmPassword} 
                onChange={(e) => setConfirmPassword(e.target.value)} 
                required 
            />
            {errorMessage && <div className="error-message">{errorMessage}</div>}
            <button type="submit" className="submit-button">Register</button>
            <button onClick={onGoogleLogin} className="google-button">Sign up with Google</button>
        </form>
    );
};

export default RegisterForm;
