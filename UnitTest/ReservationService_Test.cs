using Business.Abstract;
using Business.Concrete;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using MockQueryable.Core;
using MockQueryable.NSubstitute;

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
            var service = new ReservationService(FakeDbContextFactory.Create());

            var result = await service.GetAsync(1);

            Assert.True(result.Success);
        }
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = a - b;

            // Assert
            Assert.Equal(2, result);
        }
    }
    public static class FakeDbContextFactory
    {
        public static CoreDbContext Create()
        {
            var context = Substitute.For<CoreDbContext>();

            var users = new List<Reservation>
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

            context.Reservation.Returns(users);

            return context;
        }
    }
}
