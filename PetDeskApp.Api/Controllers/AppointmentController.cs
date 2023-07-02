using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetDeskApp.Api.DTOs;
using PetDeskApp.Data.Context;

namespace PetDeskApp.Api.Controllers
{
    // TODO: Add Authentication & Authorization
    // TODO: Move logic into services / repos
    // TODO: Add error logging

    /// <summary>
    /// Controller responsible for handling requests related to appointments
    /// </summary>
    [ApiController]
    [Route("Appointments")]
    public class AppointmentController
    {
        private readonly PetDeskContext _dbContext;

        public AppointmentController(PetDeskContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO: Add pagination
        // TODO: Add filters

        /// <summary>
        /// Retrieve all appointments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _dbContext.Appointments
                .AsNoTracking()
                .Include(a => a.Animal)
                .Include(a => a.User)
                .ToListAsync();

            var appointmentSummaries = appointments.Select(a => new AppointmentSummary
            {
                Id = a.AppointmentId,
                Type = a.AppointmentType,
                Date = a.RequestedDateTimeOffset,
                IsConfirmed = a.IsConfirmed,
                PetParent = $"{a.User?.LastName}, {a.User?.FirstName}",
                Pet = a.Animal?.FirstName ?? "New Pet",
                Breed = a.Animal?.Breed ?? "Unknown"
            });

            return new OkObjectResult(appointmentSummaries);
        }

        /// <summary>
        /// Confirm a specified appointment
        /// </summary>
        /// <param name="id">The ID of the appointment that should be confirmed</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        [HttpPost("{id}/confirm")]
        public async Task<IActionResult> ConfirmAppointment(int id)
        {
            try
            {
                var appointment = await _dbContext.Appointments
                    .Where(a => a.AppointmentId == id)
                    .FirstOrDefaultAsync();

                if (appointment == null)
                    throw new ApplicationException("Appointment not found");

                appointment.IsConfirmed = true;

                await _dbContext.SaveChangesAsync();
                return new OkObjectResult(true);
            }
            catch(Exception ex)
            {
                return new OkObjectResult(false);
            }
        }

        /// <summary>
        /// Unconfirm a specified appointment
        /// </summary>
        /// <param name="id">The id of the appointment to be unconfirmed</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        [HttpPost("{id}/unconfirm")]
        public async Task<IActionResult> UnconfirmAppointment(int id)
        {
            try
            {
                var appointment = await _dbContext.Appointments
                    .Where(a => a.AppointmentId == id)
                    .FirstOrDefaultAsync();

                if (appointment == null)
                    throw new ApplicationException("Appointment not found");

                appointment.IsConfirmed = false;

                await _dbContext.SaveChangesAsync();
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(false);
            }
        }

        /// <summary>
        /// Reschedule an appointment to a different date in the future
        /// </summary>
        /// <param name="id">The id of the appointment to reschedule</param>
        /// <param name="appointment">An object containing the new appointment date</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        [HttpPatch("{id}/reschedule")]
        public async Task<IActionResult> RescheduleAppointment(
            int id, 
            [FromBody] RescheduleAppointment appointment
        )
        {
            try
            {
                if (appointment.NewDate < DateTimeOffset.UtcNow)
                    throw new ApplicationException("Dates must be in the future");

                var existingAppointment = await _dbContext.Appointments
                    .Where(a => a.AppointmentId == id)
                    .FirstOrDefaultAsync();

                if (existingAppointment == null)
                    throw new ApplicationException("Appointment not found");

                existingAppointment.RequestedDateTimeOffset = appointment.NewDate;

                await _dbContext.SaveChangesAsync();
                return new OkObjectResult(true);
            }
            catch(Exception ex)
            {
                return new OkObjectResult(false);
            }
        }
    }
}
