export const GetUserChats = async (id) => {
  try {
    const response = await fetch(`https://localhost:7151/api/chat/${id}`, {
      method: "DELETE",
    });

    if (!response.ok) {
      throw new Error(`Error HTTP: ${response.status}`);
    }

    if (response.status === 204) {
      return null;
    }
    return await response.json();
  } catch (error) {
    console.error("Error:", error);
    throw error;
  }
};
