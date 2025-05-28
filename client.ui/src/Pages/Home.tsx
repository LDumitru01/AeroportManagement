import '../css/Home.css';
import airplane from '../assets/Airplane.png';

export default function Home() {
  return (
    <>
    <div className="animated-waves-bg" />
    <div className="home-container">
      <div className="overlay">
        <h1>Bine ai venit la DFly!</h1>
      </div>
      <img src={airplane} alt="Avion" className="airplane-image" />
    </div>
    </>
  );
}