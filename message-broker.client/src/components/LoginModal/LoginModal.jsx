import LoginForm from './Forms/LoginForm.jsx';
import RegisterForm from './Forms/RegisterForm.jsx';
import { useState } from 'react';
import { useTranslation } from "react-i18next";

const LoginModal = ({ onClose, isDarkTheme }) => {
    const [isRegistering, setIsRegistering] = useState(false);
    const { t, i18n } = useTranslation();

    const handleSubmit = (data) => {
        console.log(isRegistering ? t("registration") : t("login"), data);
    };

    const handleGoogleLogin = () => {
        console.log('Login with Google');
    };

    return (
        <div className={`modal-overlay ${isDarkTheme ? 'dark' : ''}`}>
            <div className="modal-content">
                <button className="close-button" onClick={onClose}>×</button>
                <h2>{isRegistering ? t("registration") : t("login")}</h2>
                
                {isRegistering ? (
                    <RegisterForm onSubmit={handleSubmit} onGoogleLogin={handleGoogleLogin} />
                ) : (
                    <LoginForm onSubmit={handleSubmit} onGoogleLogin={handleGoogleLogin} />
                )}

                <div className="register-text">
                    {isRegistering ? (
                        <span> {t("haveAccount")} <a href="#" onClick={() => setIsRegistering(false)}>{t("login")}</a></span>
                    ) : (
                        <span> {t("notHaveAccount")} <a href="#" onClick={() => setIsRegistering(true)}>{t("registration")}</a></span>
                    )}
                </div>
            </div>
        </div>
    );
};

export default LoginModal;