import { configureStore } from '@reduxjs/toolkit';

import alertReducer from './redux/alert';

export default configureStore({
  reducer: {
    alerts: alertReducer,
  },
});
