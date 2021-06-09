import logo from "./logo.svg";
import "./App.css";
import { useState } from "react";

const requestOptions = {
  method: "GET",
  headers: { "Content-Type": "application/json" },
};

function App() {
  const [reviews, setReviews] = useState([]);

  async function getReviews() {
    return fetch(`http://localhost:5000/api/Reviews`, requestOptions).then(
      (response) =>
        response.text().then((text) => {
          text && setReviews(JSON.parse(text));
        })
    );
  }

  function logReviews() {
    console.log(reviews);
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <button onClick={getReviews} type="button">
          Get Reviews
        </button>
        <button onClick={logReviews} type="button">
          Log Reviews
        </button>
      </header>
    </div>
  );
}

export default App;
