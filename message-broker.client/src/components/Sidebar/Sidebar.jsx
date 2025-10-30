import { useState, useEffect } from "react";
import "./Sidebar.css";
import { Sun, Moon, Globe, BoxArrowInRight } from "react-bootstrap-icons";
import LoginModal from "../LoginModal/LoginModal";

import { useTranslation } from "react-i18next";

import { CreateChat } from "../../Queries/Chats/CreateChat";
import { GetUserChats } from "../../Queries/Chats/GetUserChats";

const Sidebar = ({
  toggleTheme,
  startNewChat,
  isDarkTheme,
  toggleLanguage,
}) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [chatHistory, setChatHistory] = useState([]);
  const [isAuthorized, setIsAuthorized] = useState(true);
  const [isLangMenuOpen, setIsLangMenuOpen] = useState(false);
  const { t, i18n } = useTranslation();

  useEffect(() => {
    const fetchChats = async () => {
      try {
        const chats = await GetUserChats();
        setChatHistory(chats);
      } catch (error) {
        console.error("Failed to fetch chats", error);
      }
    };

    fetchChats();
  }, []);

  const toggleModal = () => setIsModalOpen(!isModalOpen);

  const toggleLangMenu = () => setIsLangMenuOpen(!isLangMenuOpen);
  const changeLanguage = (language) => {
    i18n.changeLanguage(language);
  };

  return (
    <div className={`sidebar ${isDarkTheme ? "dark" : ""}`}>
      <img src="/images/bntu_assistent_logo.png" alt="BNTU Assistant Logo" />

      <div className="sidebar-header">
        <button
          className="btn theme-toggle"
          onClick={toggleTheme}
          title={isDarkTheme ? t("lightThemeHint") : t("darkThemeHint")}
        >
          {isDarkTheme ? <Moon size={18} /> : <Sun size={18} />}
        </button>

        <div className="language-dropdown">
          <button
            className="btn language-toggle"
            onClick={toggleLangMenu}
            title={t("selectLanguageHint")}
          >
            <Globe size={18} />
          </button>

          {isLangMenuOpen && (
            <ul className="language-menu">
              <li onClick={() => changeLanguage("ru")}>Русский</li>
              <li onClick={() => changeLanguage("en")}>English</li>
              <li onClick={() => changeLanguage("cn")}>中文</li>
            </ul>
          )}
        </div>

        {isAuthorized ? (
          <button className="logout-button" onClick={toggleModal}>
            <span className="login-text">{t("login")}</span>
            <BoxArrowInRight size={18} className="login-icon" />
          </button>
        ) : (
          <button className="login-button" onClick={toggleModal}>
            <span className="login-text">{t("logout")}</span>
            <BoxArrowInRight size={18} className="login-icon" />
          </button>
        )}
      </div>

      <button className="new-chat" onClick={startNewChat}>
        {t("newChat")}
      </button>

      <h3>{t("msgHistory")}</h3>
      <ul className="chat-list">
        {chatHistory.map((chat, index) => (
          <li key={index} className="chat-title">
            {chat.title}
          </li>
        ))}
      </ul>

      {isModalOpen && (
        <LoginModal onClose={toggleModal} isDarkTheme={isDarkTheme} />
      )}
    </div>
  );
};

export default Sidebar;
