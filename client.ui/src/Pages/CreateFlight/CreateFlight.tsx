import React, { useEffect, useState } from "react";
import "../../css/CreateFlight.css";

export default function CreateFlight() {
  const [flight, setFlight] = useState({
    
    flightNumber: "",
    destination: "",
    departureTime: "",
    status: 0,
    price: 0,
    isInternational: false,
  });

 const handleChange = (
  e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
) => {
  const { name, value, type } = e.target;

  if (type === "checkbox" && e.target instanceof HTMLInputElement) {
    const checked = e.target.checked;
    setFlight((prev) => ({
      ...prev,
      [name]: checked,
    }));
  } else {
    setFlight((prev) => ({
      ...prev,
      [name]: value,
    }));
  }
};

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Validări simple
    if (!flight.flightNumber || !flight.destination || !flight.departureTime || flight.price <= 0) {
      alert("Completează toate câmpurile obligatorii!");
      return;
    }

    const response = await fetch("http://localhost:5236/api/Flights", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        ...flight,
        price: parseFloat(flight.price.toString()),
        status: parseInt(flight.status.toString()),
      }),
    });

    if (response.ok) {
      alert("Zborul a fost creat cu succes!");
      setFlight({
        flightNumber: "",
        destination: "",
        departureTime: "",
        status: 0,
        price: 0,
        isInternational: false,
      });
    } else {
      alert("Eroare la crearea zborului!");
    }
  };

  return (
    <>
    <div className="animated-waves-bg" />
    <div className="create-flight-container">
      <h2>Creare Zbor</h2>
      <form className="create-flight-form" onSubmit={handleSubmit}>
        <input
          name="flightNumber"
          type="text"
          placeholder="Numărul zborului"
          value={flight.flightNumber}
          onChange={handleChange}
          required
        />
        <input
          name="destination"
          type="text"
          placeholder="Destinația"
          value={flight.destination}
          onChange={handleChange}
          required
        />
        <input
            id="departureTime"
            name="departureTime"
            type="datetime-local"
            value={flight.departureTime}
            onChange={handleChange}
            min={new Date().toISOString().slice(0, 16)} // ex: 2025-05-19T15:30
        /> 
        <input
            name="price"
            type="number"
            placeholder="Preț"
            value={flight.price}
            onChange={handleChange}
            min={0}
            required
        />
        <select name="status" value={flight.status} onChange={handleChange}>
          <option value={0}>Activ</option>
          <option value={1}>Anulat</option>
          <option value={2}>În desfășurare</option>
        </select>
        <label className="checkbox-label">
          <input
            type="checkbox"
            name="isInternational"
            checked={flight.isInternational}
            onChange={handleChange}
          />
          Este internațional?
        </label>
        <button type="submit">Crează zbor</button>
      </form>
    </div>
    </>
  );
}
