import { useEffect } from "react";
import * as signalR from "@microsoft/signalr";

const SignalRConsoleLogger = ({ onMessageReceived }) => {
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7151/messageHub")
            .build();

        connection.on("ReceiveMessage", (message) => {
            console.log("Получено сообщение от SignalR:", message);

            // Передаем сообщение в родительский компонент
            if (onMessageReceived) {
                onMessageReceived(message);
            }
        });

        connection.start()
            .then(() => console.log("SignalR подключен!"))
            .catch((err) => console.error("Ошибка подключения SignalR:", err));

        return () => {
            connection.stop()
                .then(() => console.log("SignalR отключен"))
                .catch((err) => console.error("Ошибка при отключении SignalR:", err));
        };
    }, [onMessageReceived]); // Добавляем зависимость на функцию обратного вызова

    return null; // Компонент ничего не рендерит
};

export default SignalRConsoleLogger;
