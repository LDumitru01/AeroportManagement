import { BrowserRouter, Routes, Route, useLocation } from 'react-router-dom';
import Login from '../../Pages/Login/Login';
import Home from '../../Pages/Home';
import NaveBar from './NavBar';
import { CssBaseline } from '@mui/material';
//import CreateTicket from '../../Pages/CreateTicket/CreateTicket';
import CreateFligt from '../../Pages/CreateFlight/CreateFlight';
import AllFlights from '../../Pages/AllFlights/AllFlights';
import CreateTicket from '../../Pages/CreateTicket/CreateTicket';
import UpdateStatus from '../../Pages/UpdateStatus/UpdateStatus';
import SendMessage from '../../Pages/SendMesagge/SendMessage';
import ReservedTickets from '../../Pages/ReservedTickets/ReservedTickets';
import PayTicket from '../../Pages/PayTicket/PayTicket';
import CheckInPage from '../../Pages/CheckInPage/CheckInPage';


function AppContent() {
  const location = useLocation();
  const hideNav = location.pathname === '/';

  return (
    <>
      <CssBaseline />
      {!hideNav && <NaveBar />}
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/home" element={<Home />} />
        <Route path="/create-flight" element={<CreateFligt />} />
        <Route path="/flights" element={<AllFlights />} />
        <Route path="/create-ticket" element={<CreateTicket />} />
        <Route path="/update-status" element={<UpdateStatus />} />
        <Route path="/send-message" element={<SendMessage />} />
        <Route path="/reserved-tickets" element={<ReservedTickets/>} />
        <Route path="/pay-ticket/:ticketId" element={<PayTicket />} />
        <Route path="/check-in/:ticketId" element={<CheckInPage/>} />

      </Routes>
    </>
  );
}

function App() {
  return (
    <BrowserRouter>
      <AppContent />
    </BrowserRouter>
  );
}

export default App;