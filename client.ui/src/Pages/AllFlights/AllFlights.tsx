import React, { useEffect, useState } from "react";
import "../../css/AllFlights.css";

interface Flight {
  id: number;
  flightNumber: string;
  destination: string;
  departureTime: string;
  status: number;
  price: number;
  isInternational: boolean;
}

const statusText = ["Activ", "Anulat", "În desfășurare"];

export default function FlightList() {
  const [flights, setFlights] = useState<Flight[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [search, setSearch] = useState("");
  const [sortField, setSortField] = useState<keyof Flight | null>(null);
  const [sortAsc, setSortAsc] = useState(true);
  const [statusFilter, setStatusFilter] = useState("");
  const [destinationFilter, setDestinationFilter] = useState("");

  const itemsPerPage = 5;

  useEffect(() => {
    fetch("http://localhost:5236/api/Flights")
      .then((res) => res.json())
      .then(setFlights);
  }, []);

  const handleSort = (field: keyof Flight) => {
    if (sortField === field) setSortAsc(!sortAsc);
    else {
      setSortField(field);
      setSortAsc(true);
    }
  };

  const filtered = flights
    .filter((f) =>
      f.destination.toLowerCase().includes(destinationFilter.toLowerCase())
    )
    .filter((f) =>
      statusFilter === "" ? true : f.status.toString() === statusFilter
    )
    .filter(
      (f) =>
        f.destination.toLowerCase().includes(search.toLowerCase()) ||
        f.flightNumber.toLowerCase().includes(search.toLowerCase())
    );

  const sorted = sortField
    ? [...filtered].sort((a, b) => {
        const valA = a[sortField]!;
        const valB = b[sortField]!;

        if (typeof valA === "string")
          return sortAsc
            ? valA.localeCompare(valB as string)
            : (valB as string).localeCompare(valA);
        return sortAsc ? (valA as number) - (valB as number) : (valB as number) - (valA as number);
      })
    : filtered;

  const paginated = sorted.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
  );

  const totalPages = Math.ceil(filtered.length / itemsPerPage);

  return (
    <>
    <div className= "animated-waves-bg"></div>
    <div className="flight-list-container">
    <div className="flight-list-wrapper"></div>
      <h2>Zboruri disponibile</h2>

      <div className="filters">
        <input
          type="text"
          placeholder="Caută după destinație sau număr zbor..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <select
          value={destinationFilter}
          onChange={(e) => setDestinationFilter(e.target.value)}
        >
          <option value="">Toate destinațiile</option>
          {[...new Set(flights.map((f) => f.destination))].map((d) => (
            <option key={d} value={d}>
              {d}
            </option>
          ))}
        </select>
        <select
          value={statusFilter}
          onChange={(e) => setStatusFilter(e.target.value)}
        >
          <option value="">Toate statusurile</option>
          <option value="0">Activ</option>
          <option value="1">Anulat</option>
          <option value="2">În desfășurare</option>
        </select>
      </div>
      

      <table>
        <thead>
          <tr>
            <th onClick={() => handleSort("flightNumber")}>Număr</th>
            <th onClick={() => handleSort("destination")}>Destinație</th>
            <th onClick={() => handleSort("departureTime")}>Plecare</th>
            <th onClick={() => handleSort("status")}>Status</th>
            <th onClick={() => handleSort("price")}>Preț</th>
            <th onClick={() => handleSort("isInternational")}>Internațional</th>
          </tr>
        </thead>
        <tbody>
          {paginated.map((flight) => (
            <tr key={flight.id}>
              <td>{flight.flightNumber}</td>
              <td>{flight.destination}</td>
              <td>{new Date(flight.departureTime).toLocaleString()}</td>
              <td>{statusText[flight.status]}</td>
              <td>{flight.price} MDL</td>
              <td>{flight.isInternational ? "Da" : "Nu"}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="pagination">
        {Array.from({ length: totalPages }, (_, i) => (
          <button
            key={i}
            className={currentPage === i + 1 ? "active" : ""}
            onClick={() => setCurrentPage(i + 1)}
          >
            {i + 1}
          </button>
        ))}
      </div>
    </div>
    </>
  );
}
