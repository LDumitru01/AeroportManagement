import React, { useState } from 'react';
import axios from 'axios';
import '../../css/VerifyCheckins.css';

export default function VerifyCheckins() {
  const [flightId, setFlightId] = useState('');
  const [checkins, setCheckins] = useState([]);

  const fetchCheckins = async () => {
    try {
      const token = localStorage.getItem("token");
      const response = await axios.get(`http://localhost:5236/api/checkin/flight-checkins/${flightId}`, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setCheckins(response.data);
    } catch (error) {
      alert("Eroare la încărcarea check-in-urilor.");
      console.error(error);
    }
  };

  return (
    <div className="checkin-container">
      <h2 className="checkin-title">Verifică Check-in-uri</h2>
      
      <div className="checkin-search">
        <input
          type="number"
          placeholder="Introdu ID zbor"
          value={flightId}
          onChange={(e) => setFlightId(e.target.value)}
        />
        <button onClick={fetchCheckins}>Caută Check-in-uri</button>
      </div>

      {checkins.length > 0 && (
        <table className="checkin-table">
          <thead>
            <tr>
              <th>ID Bilet</th>
              <th>Email</th>
              <th>Loc</th>
              <th>Masă</th>
              <th>Tip Check-In</th>
              <th>Tip Pașaport</th>
              <th>Data Nașterii</th>
            </tr>
          </thead>
          <tbody>
            {checkins.map((c: any) => (
                <tr key={c.id}>
                <td>{c.id}</td>
                <td>{c.email}</td>
                <td>{c.seat}</td>
                <td>{c.mealOption}</td>
                <td>{c.checkInType}</td>
                <td>{c.passportType || "Nespecificat"}</td>
                <td>
                    {c.dateOfBirth && c.dateOfBirth !== "0001-01-01T00:00:00"
                    ? new Date(c.dateOfBirth).toLocaleDateString()
                    : "Nespecificat"}
                </td>
                </tr>
            ))}
            </tbody>

        </table>
      )}
    </div>
  );
}
