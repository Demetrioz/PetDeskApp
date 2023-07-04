import { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { RouterProvider } from 'react-router-dom';
import { Alert } from '@mui/material';

import router from './Routes';

import PetDeskApiService from './services/petdesk_api_service';

import styles from './App.module.css';

function App() {
  const alerts = useSelector((state) => state.alerts.items);

  useEffect(() => {
    PetDeskApiService.setApiUrl();
  }, []);

  return (
    <>
      <RouterProvider router={router} />
      <div id='alert-container' className={styles.alertContainer}>
        {alerts &&
          alerts.length > 0 &&
          alerts.map((a, i) => (
            <div id={`alert-${i}`} key={i} className={styles.alert}>
              <Alert severity={a.severity}>{a.message}</Alert>
            </div>
          ))}
      </div>
    </>
  );
}

export default App;
