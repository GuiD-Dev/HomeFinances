import styles from "./AppHeader.module.css";
import { NavLink } from 'react-router-dom';

interface Props {
  pageTitle: string
}

export function AppHeader({ pageTitle }: Props) {
  return (
    <header>
      <nav>
        <NavLink className={styles.tab} to="/">Home</NavLink>
        <NavLink className={styles.tab} to="/person">People</NavLink>
        <NavLink className={styles.tab} to="/category">Categories</NavLink>
        <NavLink className={styles.tab} to="/transaction">Transactions</NavLink>
      </nav>

      <h1 className='mt-4'>{pageTitle}</h1>
    </header>
  );
}