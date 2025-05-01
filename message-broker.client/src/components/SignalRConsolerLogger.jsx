import { useEffect } from "react";
import * as signalR from "@microsoft/signalr";

const SignalRConsoleLogger = ({ onMessageReceived }) => {
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7151/messageHub")
            .build();

        connection.on("ReceiveMessage", (message) => {
            console.log("Received message from SignalR:", message);

            if (onMessageReceived) {
                onMessageReceived(message);
            }
        });

        connection.start()
            .then(() => console.log("SignalR is connected!"))
            .catch((err) => console.error("SignalR connection error:", err));

        return () => {
            connection.stop()
                .then(() => console.log("SignalR is disabled"))
                .catch((err) => console.error("Error when disabling SignalR:", err));
        };
    }, [onMessageReceived]);

    return null;
};

export default SignalRConsoleLogger;
