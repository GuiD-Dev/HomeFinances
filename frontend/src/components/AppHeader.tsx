import './AppHeader.css'
import { NavLink } from 'react-router-dom';

interface Props {
  pageTitle: string
}

export function AppHeader({ pageTitle }: Props) {
  return (
    <header>
      <nav>
        <NavLink to="/">Home</NavLink>
        <NavLink to="/person">People</NavLink>
        <NavLink to="/category">Categories</NavLink>
        <NavLink to="/transaction">Transactions</NavLink>
      </nav>

      <h1 className='mt-4'>{pageTitle}</h1>
    </header>
  );
}