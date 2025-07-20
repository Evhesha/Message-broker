export const GetChatMessages = async (id) => {
  try {
    const response = await fetch("https://localhost:7151/api/chat", {
      method: "GET",
    });

    if (!response.ok) {
      throw new Error(`Error HTTP: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error:", error);
    throw error;
  }
};
