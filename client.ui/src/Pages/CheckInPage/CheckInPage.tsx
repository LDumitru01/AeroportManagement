import React, { useState } from 'react';
import axios from 'axios';
import { useParams, useNavigate} from 'react-router-dom';
import '../../css/CheckinPage.css';

export default function CheckInPage() {
  const { ticketId } = useParams<{ ticketId: string }>();
  const [checkInType, setCheckInType] = useState('');
  const [idnp, setIdnp] = useState('');
  const [birthDay, setBirthDay] = useState('');
  const [birthMonth, setBirthMonth] = useState('');
  const [birthYear, setBirthYear] = useState('');
  const [passportType, setPassportType] = useState('');
  const navigate = useNavigate();

  const handleCheckIn = async () => {
    try {
      const token = localStorage.getItem('token');

      const response = await axios.post(
        "http://localhost:5236/api/checkin/perform",
        {
          ticketId: parseInt(ticketId ?? '0'),
          type: checkInType,                      // Trebuie EXACT ca enumul C#
          cnp: idnp,                              // IDNP transmis ca CNP
          passportType: passportType,             // Trebuie EXACT ca enumul C#
          dateOfBirth: `${birthYear}-${birthMonth}-${birthDay}`
        },
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Check-in realizat cu succes!");
      navigate('/reserved-tickets');
    } catch (err) {
      console.error(err);
      alert("Eroare la check-in.");
    }
  };

  return (
    <div className="checkin-container">
      <h2>Check-In pentru Bilet</h2>

      <label>IDNP:</label>
      <input
        type="text"
        placeholder="Introduceți IDNP"
        value={idnp}
        onChange={(e) => setIdnp(e.target.value)}
      />

      <label>Data nașterii:</label>
      <div className="birth-date">
        <input
          type="text"
          placeholder="Zi"
          maxLength={2}
          value={birthDay}
          onChange={(e) => setBirthDay(e.target.value)}
        />
        <input
          type="text"
          placeholder="Lună"
          maxLength={2}
          value={birthMonth}
          onChange={(e) => setBirthMonth(e.target.value)}
        />
        <input
          type="text"
          placeholder="An"
          maxLength={4}
          value={birthYear}
          onChange={(e) => setBirthYear(e.target.value)}
        />
      </div>

      <label>Tip pașaport:</label>
      <select
        value={passportType}
        onChange={(e) => setPassportType(e.target.value)}
      >
        <option value="">Selectează</option>
        <option value="Biometric">Biometric</option>
        <option value="Simplu">Simplu</option>
        <option value="Diplomatic">Diplomatic</option>
      </select>

      <label>Tip Check-In:</label>
      <select
        value={checkInType}
        onChange={(e) => setCheckInType(e.target.value)}
      >
        <option value="">Selectează</option>
        <option value="Standard">Standard</option>
        <option value="Business">Business</option>
        <option value="VIP">VIP</option>
      </select>

      <button onClick={handleCheckIn}>Check-In</button>
    </div>
  );
}
