import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const response = await fetch('http://localhost:5236/api/Auth/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email, password })
    });

    if (response.ok) {
      const data = await response.json();
      localStorage.setItem("token", data.token);  
      localStorage.setItem("role", data.role);

      navigate("/home");
    } else {
      alert("Email or password is wrong");
    }
  };

  return (
    <>
    <div className="animated-waves-bg" />
    <div className="login-container">
      <form className="login-form" onSubmit={handleLogin}>
        <h2>Login</h2>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={e => setEmail(e.target.value)}
        />
        <input
          type="password"
          placeholder="Parola"
          value={password}
          onChange={e => setPassword(e.target.value)}
        />
        <button type="submit">Autentificare</button>
      </form>
    </div>
    </>
  );
}

export default Login;
