import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { setSettings } from "./env/settings.ts";

fetch("/api/settings")
  .then(async (response) => {
    setSettings(await response.json());
    ReactDOM.createRoot(document.getElementById("root")!).render(
      <React.StrictMode>
        <App />
      </React.StrictMode>
    );
  })
  .catch((err) => console.error(err));
