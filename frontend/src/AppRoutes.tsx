import { BrowserRouter, Route, Routes } from "react-router-dom";
import { PersonPage } from "./pages/PersonPage";
import { CategoryPage } from "./pages/CategoryPage";
import { TransactionPage } from "./pages/TransactionPage";
import { HomePage } from "./pages/HomePage";

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={HomePage} />
        <Route path="/person" Component={PersonPage} />
        <Route path="/category" Component={CategoryPage} />
        <Route path="/transaction" Component={TransactionPage} />
      </Routes>
    </BrowserRouter>
  );
}