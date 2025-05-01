export const PostQuestion = async (data) => {
    try {
        const response = await fetch('https://localhost:7151/api/kafka/create-ollama-question', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
};
