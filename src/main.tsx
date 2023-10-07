import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { Settings } from "./env/settings.ts";

fetch("http://localhost:7071/api/settings")
  .then(async (response) => {
    const environment: Settings = await response.json();
    ReactDOM.createRoot(document.getElementById("root")!).render(
      <React.StrictMode>
        <App {...environment} />
      </React.StrictMode>
    );
  })
  .catch((err) => console.error(err));
