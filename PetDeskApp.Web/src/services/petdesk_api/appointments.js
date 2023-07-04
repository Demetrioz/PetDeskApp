import PetDeskApiService from '../petdesk_api_service';

export const getAppointments = () =>
  PetDeskApiService.request('GET', 'Appointments');

export const confirmAppointment = (id) =>
  PetDeskApiService.request('POST', `Appointments/${id}/confirm`);

export const unconfirmAppointment = (id) =>
  PetDeskApiService.request('POST', `Appointments/${id}/unconfirm`);

export const rescheduleAppointment = (id, newDate) =>
  PetDeskApiService.request('PATCH', `Appointments/${id}/reschedule`, {
    newDate: newDate,
  });
