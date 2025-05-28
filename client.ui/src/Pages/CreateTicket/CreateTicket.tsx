import React, { useEffect, useState } from 'react';
import '../../css/CreateTicket.css';
import axios from 'axios';
import {
  LuggageValidator,
  PassengerValidator,
  SeatValidator,
} from "../../app/TicketValidation";

interface Flight {
  id: number;
  flightNumber: string;
}

export default function CreateTicket() {
  const [flights, setFlights] = useState<Flight[]>([]);
  const [formData, setFormData] = useState({
    flightNumber: '',
    firstName: '',
    lastName: '',
    passportNumber: '',
    seat: 0,
    mealOption: 0,
    luggageWeight: 0,
  });

  const fetchActiveFlights = async () => {
    try {
      const response = await axios.get('http://localhost:5236/api/Flights/avaible');
      setFlights(response.data);
    } catch (error) {
      console.error('Eroare la obținerea zborurilor:', error);
    }
  };

  useEffect(() => {
    fetchActiveFlights();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: name === 'seat' || name === 'mealOption' || name === 'luggageWeight' ? Number(value) : value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();

  const seatValidator = new SeatValidator();
  const luggageValidator = new LuggageValidator();
  const passengerValidator = new PassengerValidator();

  seatValidator.setNext(luggageValidator).setNext(passengerValidator);

  const validationError = seatValidator.validate(formData);
  if (validationError) {
    alert(validationError);
    return;
  }

  const token = localStorage.getItem("token");

  try {
    const response = await axios.post(
      "http://localhost:5236/api/Command/create-ticket",
      formData,
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }
    );

    alert("Bilet rezervat cu succes!");
  } catch (error: any) {
    console.error("Eroare la rezervare:", error);
    if (error.response?.status === 401) {
      alert("Nu ești autentificat. Te rugăm să te loghezi.");
    } else {
      alert("A apărut o eroare la rezervarea biletului.");
    }
  }
};


  return (
  <>
  <div className="animated-waves-bg" />
  <div className="create-ticket-container">
    <form onSubmit={handleSubmit} className="create-ticket-card">
      <h2>Rezervă un Bilet</h2>

      <div className="form-group">
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

      <div className="form-group">
        <label>Nume:</label>
        <input type="text" name="firstName" value={formData.firstName} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label>Prenume:</label>
        <input type="text" name="lastName" value={formData.lastName} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label>Număr pașaport:</label>
        <input type="text" name="passportNumber" value={formData.passportNumber} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label>Loc:</label>
        <input type="number" name="seat" value={formData.seat} onChange={handleChange} required />
      </div>

      <div className="form-group">
        <label>Opțiune masă:</label>
        <select name="mealOption" value={formData.mealOption} onChange={handleChange} required>
          <option value={0}>Normal</option>
          <option value={1}>Vegetarian</option>
        </select>
      </div>

      <div className="form-group">
        <label>Greutate bagaj (kg):</label>
        <input type="number" name="luggageWeight" value={formData.luggageWeight} onChange={handleChange} required />
      </div>

      <button type="submit" className="submit-btn">Rezervă</button>
    </form>
  </div>
  </>
);

}
