import { addAlert, removeAlert } from '../redux/alert';

export const publishAlert = (dispatch, name, message) => {
  dispatch(
    addAlert({
      name: name,
      severity: 'error',
      message: message,
    })
  );

  setTimeout(() => dispatch(removeAlert(name)), 3000);
};
