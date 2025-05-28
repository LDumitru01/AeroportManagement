import React, { useEffect, useState } from 'react';
import axios from 'axios';
import '../../css/ReservedTickets.css';
import { Link } from 'react-router-dom';

interface Ticket {
  id: number;
  flight: {
    number: string;
    destination: string;
    price: number;
  } | null;
  seat: number;
  mealOption: number;
  luggageWeight: number;
  isPaid: boolean;
  email: string;
  isCheckedIn: boolean;
}

const ReservedTickets = () => {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const ticketsPerPage = 2;

  const fetchReservedTickets = async () => {
    try {
      const token = localStorage.getItem('token');
      const response = await axios.get('http://localhost:5236/api/Ticket/reserved', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      setTickets(response.data);
    } catch (error) {
      console.error('Eroare la încărcarea biletelor:', error);
    }
  };

  useEffect(() => {
    fetchReservedTickets();
  }, []);

  const indexOfLast = currentPage * ticketsPerPage;
  const indexOfFirst = indexOfLast - ticketsPerPage;
  const currentTickets = tickets.slice(indexOfFirst, indexOfLast);

  return (
    <>
    <div className="animated-waves-bg" />
    <div className="reserved-tickets">
      <h2>Biletele Mele Rezervate</h2>
      {currentTickets.length === 0 ? (
        <p>Nu ai niciun bilet rezervat.</p>
      ) : (
        <ul className="ticket-list">
  {currentTickets.map((ticket, index) => (
    <li className="ticket-card" key={ticket.id}>
      <p className="ticket-title"><strong>Număr bilet: {ticket.flight?.number || "necunoscut"}</strong></p>
      <p className="ticket-field">Destinație: {ticket.flight?.destination || "necunoscut"}</p>
      <p className="ticket-field">Email: {ticket.email}</p>
      <p className="ticket-field">Loc: {ticket.seat}</p>
      <p className="ticket-field">Masă: {ticket.mealOption === 0 ? 'Normal' : 'Vegetarian'}</p>
      <p className="ticket-field">Greutate bagaj: {ticket.luggageWeight} kg</p>
      <p className="ticket-field">Preț: {ticket.flight?.price || 0} lei</p>
      <p className="ticket-field">Status plată: {ticket.isPaid ? 'Achitat' : 'Neachitat'}</p>
      {!ticket.isPaid ? (
  <button
    className="pay-button"
    onClick={() => window.location.href = `/pay-ticket/${ticket.id}`}
  >
    Achită
  </button>
) : !ticket.isCheckedIn ? (
  <Link to={`/check-in/${ticket.id}`} className="checkin-button">
    Check-in
  </Link>

) : null}
    </li>
  ))}
</ul>
      )}
      <div className="pagination-controls">
        <button
          className="pagination-button"
          onClick={() => setCurrentPage(prev => prev - 1)}
          disabled={currentPage === 1}
        >
          ◀ Anterior
        </button>
        <span className="pagination-info">Pagina {currentPage}</span>
        <button
          className="pagination-button"
          onClick={() => setCurrentPage(prev => prev + 1)}
          disabled={indexOfLast >= tickets.length}
        >
          Următor ▶
        </button>
      </div>
    </div>
    </>
  );
};

export default ReservedTickets;
