import React, { useState } from 'react';
import axios from 'axios';
import "../../css/SendMessage.css";

export default function SendMessage() {
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      alert("Te rugăm să introduci un email valid.");
      return;
    }

    try {
      await axios.post("http://localhost:5236/api/Notifications/send", {
        destination: email,
        message: message,
      });
      alert("Mesajul a fost trimis cu succes!");
    } catch (error) {
      alert("A apărut o eroare la trimiterea mesajului.");
      console.error(error);
    }
  };

  return (
    <>
    <div className="animated-waves-bg" />
   
    <div className="send-message-container">
      <form className="send-message-form" onSubmit={handleSubmit}>
        <h2>Trimite un mesaj administratorului</h2>

        <label>Emailul tău:</label>
        <input
          type="email"
          placeholder="exemplu@email.com"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        <label>Mesaj:</label>
        <textarea
          rows={5}
          placeholder="Scrie mesajul aici..."
          value={message}
          onChange={(e) => setMessage(e.target.value)}
          required
        />

        <button type="submit">Trimite</button>
      </form>
    </div>
     </>
  );
}
