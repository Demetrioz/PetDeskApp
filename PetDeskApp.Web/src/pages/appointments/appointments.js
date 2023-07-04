import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import dayjs from 'dayjs';
import {
  Checkbox,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from '@mui/material';
import { DateTimePicker } from '@mui/x-date-pickers';

import PageBase from '../../components/page_base/page_base';

import { publishAlert } from '../../utilities/alert_utility';

import PetDeskApiService from '../../services/petdesk_api_service';

export default function Appointments() {
  const dispatch = useDispatch();

  const [appointments, setAppointments] = useState([]);

  useEffect(() => {
    const loadData = async () => {
      try {
        const petAppointments =
          await PetDeskApiService.Appointments.getAppointments();
        setAppointments(petAppointments);
      } catch (e) {
        publishAlert(dispatch, 'load-appointment-error', e.message);
      }
    };

    loadData();
  }, []);

  const handleConfirmAppointment = async (value, id, index) => {
    try {
      if (appointments[index].id !== id)
        throw new Error('Cannot update appointment');

      if (dayjs(appointments[index].date) < dayjs())
        throw new Error(
          'Cannot confirm an appointment in the past. Please update the date first'
        );

      const result = value
        ? await PetDeskApiService.Appointments.confirmAppointment(id)
        : await PetDeskApiService.Appointments.unconfirmAppointment(id);

      if (result) {
        const updatedAppointments = [...appointments];
        updatedAppointments[index].isConfirmed = value;
        setAppointments(updatedAppointments);
      } else {
        throw new Error('Unable to confirm appointment');
      }
    } catch (e) {
      publishAlert(dispatch, 'appointment-confirm-error', e.message);
    }
  };

  const handleRescheduleAppointment = async (value, id, index) => {
    try {
      if (appointments[index].id !== id)
        throw new Error('Cannot update appointment');

      const result = await PetDeskApiService.Appointments.rescheduleAppointment(
        id,
        dayjs(value).toISOString()
      );
      if (result) {
        const updatedAppointments = [...appointments];
        updatedAppointments[index].date = dayjs(value).toISOString();
        setAppointments(updatedAppointments);
      } else {
        throw new Error('Unable to reschedule appointment');
      }
    } catch (e) {
      publishAlert(dispatch, 'appointment-reschedule-error', e.message);
    }
  };

  return (
    <PageBase>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Date</TableCell>
            <TableCell>Type</TableCell>
            <TableCell>Pet</TableCell>
            <TableCell>Breed</TableCell>
            <TableCell>Pet Parent</TableCell>
            <TableCell>Confirmed</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {appointments.map((a, index) => {
            return (
              <TableRow key={a.id}>
                <TableCell>
                  <DateTimePicker
                    value={dayjs(a.date)}
                    disabled={a.isConfirmed}
                    onAccept={(newValue) =>
                      handleRescheduleAppointment(newValue, a.id, index)
                    }
                    minDate={a.isConfirmed ? null : dayjs()}
                  />
                </TableCell>
                <TableCell>{a.type}</TableCell>
                <TableCell>{a.pet}</TableCell>
                <TableCell>{a.breed}</TableCell>
                <TableCell>{a.petParent}</TableCell>
                <TableCell>
                  <Checkbox
                    checked={a.isConfirmed ?? false}
                    size='small'
                    onChange={(event) =>
                      handleConfirmAppointment(
                        event.target.checked,
                        a.id,
                        index
                      )
                    }
                  />
                </TableCell>
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
    </PageBase>
  );
}
