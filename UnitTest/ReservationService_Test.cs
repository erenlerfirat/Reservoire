using Business.Abstract;
using Business.Concrete;
using Domain.Models;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace UnitTest.Concrete
{
    public class ReservationService_Test
    {

        private readonly CoreDbContext context = FakeDbContextFactory.Create();
        private IReservationService GetService()
        {
            return new ReservationService(FakeDbContextFactory.Create());
        }

        [Fact]
        public async Task GetAsync_ReturnsTrue()
        {
            // Arrange
            var ctx = FakeDbContextFactory.Create();

            var reservation = new List<Reservation>
            {
                new Reservation()
                    {
                        Description = "Booking",
                        Id = 1,
                        BusinessOwnerUserId = 1,
                        UserId = 2,
                        ReservationDate = DateTime.Now,
                    },
            }.AsQueryable()
            .BuildMockDbSet();

            ctx.Reservation.Returns(reservation);
            var service = new ReservationService(ctx);

            // Act
            var result = await service.GetAsync(id:1);

            // Assert
            Assert.True(result.Success);
        }
    }
    public static class FakeDbContextFactory
    {
        public static CoreDbContext Create()
        {
            var context = Substitute.For<CoreDbContext>();
            return context;
        }
    }
}
