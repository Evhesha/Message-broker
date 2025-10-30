import { useState } from "react";
import { Login } from "../../../Queries/Auth/Login";
import "../LoginModal.css";
import { useTranslation } from "react-i18next";

import { toast } from "react-toastify";

const LoginForm = ({ onSubmit, onGoogleLogin }) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const { t } = useTranslation();

  const notifyLight = () =>
    toast.success(t("loginSuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "light",
    });

  const notifyDark = () =>
    toast.success(t("loginSuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "dark",
    });

  const notifyLightError = () =>
    toast.error(t("loginUnsuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "light",
    });

  const notifyDarkError = () =>
    toast.error(t("loginUnsuccess"), {
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
      setErrorMessage("");
    } catch (error) {
      setErrorMessage(t("loginFailed"));
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder={t("email")}
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
      />
      <input
        type="password"
        placeholder={t("password")}
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        required
      />
      {errorMessage && <div className="error-message">{errorMessage}</div>}
      <button type="submit" className="submit-button">
        {t("login")}
      </button>
      <button onClick={onGoogleLogin} className="google-button">
        {t("loginWithGoogle")}
        <img
          src="/images/google-icon.png"
          alt="Google icon"
          className="google-icon"
        />
      </button>
    </form>
  );
};

export default LoginForm;
