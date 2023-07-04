import { createSlice } from '@reduxjs/toolkit';

export const alertSlice = createSlice({
  name: 'alert',
  initialState: {
    items: [],
  },
  reducers: {
    addAlert: (state, action) => {
      state.items.push({
        severity: action.payload.severity,
        name: action.payload.name,
        message: action.payload.message,
      });
    },
    removeAlert: (state, action) => {
      let alertIndex = -1;
      for (let i = 0; i < state.items.length; i++) {
        if (state.items[i].name === action.payload) {
          alertIndex = i;
          break;
        }
      }

      if (alertIndex > -1) state.items.splice(alertIndex, 1);
    },
  },
});

export const { addAlert, removeAlert } = alertSlice.actions;
export default alertSlice.reducer;
