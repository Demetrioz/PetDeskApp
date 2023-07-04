import { createBrowserRouter } from 'react-router-dom';

import Dashboard from './pages/dashboard/dashboard';
import Appointments from './pages/appointments/appointments';
import NotFound from './pages/not_found/not_found';

const routes = {
  index: '/',
  appointment: '/appointments',
  catchAll: '*',
};

const router = createBrowserRouter([
  {
    path: routes.index,
    element: <Dashboard />,
  },
  {
    path: routes.appointment,
    element: <Appointments />,
  },
  {
    path: routes.catchAll,
    element: <NotFound />,
  },
]);

export default router;
export { routes };
