import React, { useState } from 'react';
import '../../css/UpdateStatus.css';
import axios from 'axios';

export default function UpdateStatus() {
  const [formData, setFormData] = useState({
    flightNumber: '',
    newStatus: 0
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'newStatus' ? parseInt(value) : value
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await axios.put('http://localhost:5236/api/Flights/update-status', formData);
      alert('Statusul zborului a fost actualizat cu succes!');
    } catch (error) {
      alert('Eroare la actualizarea statusului!');
      console.error(error);
    }
  };

  return (
    <>
    <div className= "animated-waves-bg"></div>
    <div className="update-status-container">
    <form className="update-status-card" onSubmit={handleSubmit}>
      <h2>Actualizează Statusul Zborului</h2>

      <div className="form-row">
        <label>Număr zbor:</label>
        <input
          type="text"
          name="flightNumber"
          value={formData.flightNumber}
          onChange={handleChange}
          placeholder="Ex: AI13333"
          required
        />
      </div>

      <div className="form-row">
        <label>Status nou:</label>
        <select name="newStatus" value={formData.newStatus} onChange={handleChange} required>
          <option value={0}>Activ</option>
          <option value={1}>Anulat</option>
          <option value={2}>In desfasurare</option>
        </select>
      </div>

      <button type="submit" className="update-btn">Actualizează</button>
    </form>
  </div>
  </>
);
}
