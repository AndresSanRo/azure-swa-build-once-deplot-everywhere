import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";

await fetch("http://localhost:7071/api/HelloWorld")
  .then(async (response) => console.log(await response.text()))
  .catch(() => console.error("Sergio es maricón"));

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
