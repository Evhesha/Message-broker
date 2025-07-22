import jwtDecode from "jwt-decode";

function getCookie(name) {
  const value = `; ${document.cookie}`;
  const parts = value.split(`; ${name}=`);
  if (parts.length === 2) return parts.pop().split(';').shift();
}

export const PostQuestion = async (data) => {
  try {
    const token = getCookie("tasty-cookie");
    const decoded = jwtDecode(token);
    console.log(decoded.userId);

    const response = await fetch(
      "https://localhost:7151/api/kafka/create-ollama-question",
      {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
        credentials: 'include'
      }
    );

    if (!response.ok) {
      throw new Error(`Error HTTP: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error:", error);
    throw error;
  }
};
