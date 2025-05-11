Architecture
<p></p>
<img src="https://github.com/user-attachments/assets/ecfd8c0a-0396-43c0-91d0-27adc347bf28" width="1000">
<p></p>
The application architecture is organized around the interaction of several key components:
1. Client (User)
• Sends a question to the server.
• Receives a response after processing the message through the entire interaction chain.

3. Main server (Message Broker)
• Receives questions from the client.
• Sends them to Kafka for asynchronous processing.
• Receives a response from the Ollama server after processing the message.
• Sends the received response back to the user via WebSocket or API.

5. Kafka (Message Queue)
• Receives a question from the main server and passes it on.
• Acts as a message broker, allowing the Ollama server to process questions asynchronously.
• Sends the processed message back to the queue, from where the main server picks it up.

7. Ollama Server
• Connected to Kafka as a message consumer.
• Receives questions from Kafka.
• Processes the request (e.g. using the Ollama model to generate a response).
• Sends the result back to Kafka.

9. MongoDB (Chat and message storage)
• Stores the history of the correspondence: chat ID, question, answer, date.
• Allows the client to load past messages when switching between chats.
• Supports the structure of storing data in the form of documents.

11. Interaction of components
  1. Client → Main server: Sending a question.
  2. Main server → Kafka: Passing a message for processing.
  3. Kafka → Ollama server: Receiving and processing the question.
  4. Ollama server → Kafka: Response after processing.
  5. Kafka → Main server: The server receives the response.
  6. Main server → Client: Returns the response to the user.
  7. MongoDB: Messages are saved at each stage, allowing you to track the history of communication.
