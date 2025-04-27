import React, { useEffect } from "react";
import * as signalR from "@microsoft/signalr";

const SignalRConsoleLogger = () => {
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7151/messageHub") // Укажите правильный адрес вашего хаба
            .build();

        // Подключаем обработчик входящих сообщений
        connection.on("ReceiveMessage", (message) => {
            console.log("Получено сообщение от SignalR:", message);
        });

        // Запускаем соединение
        connection.start()
            .then(() => console.log("SignalR подключен!"))
            .catch((err) => console.error("Ошибка подключения SignalR:", err));

        // Очищаем соединение при размонтировании компонента
        return () => {
            connection.stop()
                .then(() => console.log("SignalR отключен"))
                .catch((err) => console.error("Ошибка при отключении SignalR:", err));
        };
    }, []); // Пустой массив зависимостей, чтобы код выполнялся только один раз при загрузке компонента

    return null; // Пока компонент ничего не рендерит
};

export default SignalRConsoleLogger;
