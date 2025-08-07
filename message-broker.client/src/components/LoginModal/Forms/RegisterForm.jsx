import { useState } from "react";
import { Register } from "../../../Queries/Auth/Register";
import "../LoginModal.css";
import { useTranslation } from "react-i18next";

import { toast } from "react-toastify";

const RegisterForm = ({ onSubmit, onGoogleLogin }) => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const { t } = useTranslation();

  const notifyLight = () =>
    toast.success(t("registerSuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "light",
    });

  const notifyDark = () =>
    toast.success(t("registerSuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "dark",
    });

  const notifyLightError = () =>
    toast.error(t("registerUnsuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "light",
    });

  const notifyDarkError = () =>
    toast.error(t("registerUnsuccess"), {
      autoClose: 3000,
      draggable: true,
      theme: "dark",
    });

  const handleSubmit = (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      setErrorMessage(t("passwordDoNotMatch"));
      return;
    }
    if (!email.includes("@")) {
      setErrorMessage(t("invalidEmail"));
      return;
    }

    const result = Register({
      Name: username,
      Email: email,
      Password: password,
    });
    notifyLight();
    onSubmit(result);
    setErrorMessage("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder={t("userName")}
        value={username}
        onChange={(e) => setUsername(e.target.value)}
        required
      />
      <input
        type="email"
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
      <input
        type="password"
        placeholder={t("repeatPassword")}
        value={confirmPassword}
        onChange={(e) => setConfirmPassword(e.target.value)}
        required
      />
      {errorMessage && <div className="error-message">{errorMessage}</div>}
      <button type="submit" className="submit-button">
        {t("register")}
      </button>
      <button onClick={onGoogleLogin} className="google-button">
        {t("signUpWithGoogle")}
        <img
          src="/images/google-icon.png"
          alt="Google icon"
          className="google-icon"
        />
      </button>
    </form>
  );
};

export default RegisterForm;
