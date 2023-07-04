import { useEffect } from 'react';

import PetDeskApiService from './services/petdesk_api_service';
import { RouterProvider } from 'react-router-dom';

import router from './Routes';
import { useSelector } from 'react-redux';
import { Alert } from '@mui/material';

function App() {
  const alerts = useSelector((state) => state.alerts.items);

  useEffect(() => {
    PetDeskApiService.setApiUrl();
  }, []);

  return (
    <>
      <RouterProvider router={router} />
      <div
        style={{
          position: 'absolute',
          bottom: 0,
          width: '100%',
          zIndex: 999999,
          display: 'flex',
          flexDirection: 'column-reverse',
          alignItems: 'center',
        }}
      >
        {alerts &&
          alerts.length > 0 &&
          alerts.map((a, i) => (
            <div key={i} style={{ maxWidth: '280px', margin: '.25rem 0' }}>
              <Alert severity={a.severity}>{a.message}</Alert>
            </div>
          ))}
      </div>
    </>
  );
}

export default App;
