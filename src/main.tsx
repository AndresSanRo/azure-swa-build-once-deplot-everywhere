import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
fetch("http://localhost:7071/api/HelloWorld")
  // fetch(`${import.meta.env.VITE_SWA_API}/HelloWorld`)
  .then(async (response) => console.log(await response.text()))
  .catch((err) => console.error(err));

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
