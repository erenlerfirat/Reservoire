using Domain.Dtos;
using Domain.Models;
using Utility.Results;

namespace Business.Abstract
{
    public interface IReservationService
    {
        public Task<IResult> BookAsync(ReservationRequest request);
        public Task<IResult> CancelAsync(int id);
        public Task<IDataResult<Reservation>> GetAsync(int id);
        public Task<IResult> EditAsync(int id);
    }
}
