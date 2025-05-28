import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import '../../css/PayTicket.css';

const PayTicket = () => {
  const { ticketId } = useParams();
  const navigate = useNavigate();
  const [amount, setAmount] = useState('');
  const [method, setMethod] = useState('');
  const [ticket, setTicket] = useState<any>(null);
  const [currency, setCurrency] = useState('MDL')

  useEffect(() => {
    const fetchTicket = async () => {
      try {
        const token = localStorage.getItem('token');
        const res = await axios.get(`http://localhost:5236/api/Ticket/${ticketId}`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        setTicket(res.data);
      } catch (error) {
        console.error('Eroare la obținerea biletului:', error);
      }
    };
    fetchTicket();
  }, [ticketId]);

 const handleSubmit = async (event: React.FormEvent) => {
  event.preventDefault(); // ⛔️ prevenim reload-ul formularului

  try {
    const token = localStorage.getItem("token");
    const response = await axios.post(
      "http://localhost:5236/api/payments/pay",
      {
        ticketId: ticketId,
        amount: parseFloat(amount),
        currency: "MDL",
        method,
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    if (response.status === 200) {
      alert("Plata a fost realizată cu succes!");
      navigate("/reserved-tickets");
    }
  } catch (error: any) {
    console.error("Eroare la achitare:", error);
    alert("Plata a eșuat. Verifică suma sau metoda.");
  }
};

  return (
    <div className="pay-ticket-container">
      <h2>Achitare bilet #{ticketId}</h2>
      {ticket && (
        <div className="ticket-details">
          <p><strong>Destinație:</strong> {ticket.flight?.destination || 'necunoscut'}</p>
          <p><strong>Preț:</strong> {ticket.flight?.price || 0} MDL</p>
          <p><strong>Status:</strong> {ticket.isPaid ? 'Achitat' : 'Neachitat'}</p>
        </div>
      )}

      <form onSubmit={handleSubmit} className="payment-form">
        <label>Suma de plată:</label>
        <input
          type="number"
          step="0.01"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
          required
        />

        <label>Metoda de plată:</label>
        <select value={method} onChange={(e) => setMethod(e.target.value)} required>
          <option value="">Selectează metoda</option>
          <option value="PayPal">PayPal</option>
          <option value="GooglePay">Google Pay</option>
          <option value="Crypto">Crypto</option>
        </select>

        <button type="submit">Achită</button>
      </form>
    </div>
  );
};

export default PayTicket;
