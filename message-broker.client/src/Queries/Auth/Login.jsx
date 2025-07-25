export const Login = async (data) => {
    try {
        const response = await fetch('https://localhost:7080/Auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data),
            credentials: "include"
        });

        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }

        const token = await response.text();
        return token;
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
};