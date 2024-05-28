using Business.Abstract;
using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Utility.Results;
using Utiliy.Messages;

namespace Business.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly CoreDbContext context;
        public ReservationService(CoreDbContext context)
        {
                this.context = context;
        }

        public async Task<IDataResult<Reservation>> GetAsync(int id) 
        {
            var reservation = await context.Reservation.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (reservation is null)            
                return new ErrorDataResult<Reservation>(Messages.NotFound);
            
                return new SuccessDataResult<Reservation>(reservation,Messages.Success);
        }
        public async Task<IResult> BookAsync(ReservationRequest request)
        {
            var reservation = new Reservation 
            { 
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Description = request.Description,
                ReservationDate = request.ReservationDate,
                BusinessOwnerUserId = request.BusinessOwnerUserId,
                UserId = request.UserId,
                IsDeleted = false,
            };
            await context.AddAsync(reservation);
            await context.SaveChangesAsync();

            return new SuccessResult(Messages.Success);
        }
        public async Task<IResult> EditAsync(int id)
        {
            return await Task.FromResult(new SuccessResult(Messages.Success));
        }
        public async Task<IResult> CancelAsync(int id)
        {
            return await Task.FromResult(new SuccessResult(Messages.Success));
        }
    }
}
