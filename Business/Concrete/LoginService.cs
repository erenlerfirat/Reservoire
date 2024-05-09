using Business.Abstract;
using Domain.Dtos;
using Domain.Models;
using Utility.Results;
using Utiliy.Abstract;

namespace Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly CoreDbContext context;
        private readonly IHashHelper hashHelper;
        private readonly IJwtHelper jwtHelper;
        public LoginService(CoreDbContext context, IHashHelper hashHelper , IJwtHelper jwtHelper)
        {
            this.context = context;
            this.hashHelper = hashHelper;
            this.jwtHelper = jwtHelper;
        }

        public IDataResult<UserDetailsDto> GetUserDetails(string token)
        {
            var result = jwtHelper.GetUserDetails(token);
            return new SuccessDataResult<UserDetailsDto>(result);
        }

        public IDataResult<LoginResponse> Login(LoginRequest request)
        {
            var response = new LoginResponse();
            
            var user = context.User.Where(u=> u.Email == request.Email).SingleOrDefault();
            var role = context.UserRole.Where(u=>u.UserId == user.Id).SingleOrDefault();

            bool isPasswordValid = hashHelper.Validate(request.Password, user.PasswordHash);
            var tokenRequest = new UserTokenRequest 
            { 
                Email = request.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id ,
                RoleType = role.RoleType
            };
            string token = jwtHelper.CreateToken(tokenRequest);
            response.Token = token;
            var x = new SuccessDataResult<LoginResponse>(response,"Success");
            return x;
        }

        public IDataResult<RegisterResponse> Register(RegisterRequest request)
        {
            // check is email unique
            var transaction = context.Database.BeginTransaction();
            try
            {
                string hash = hashHelper.Encrypt(request.Password);
                
                User user = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    Email = request.Email,
                    PasswordHash = hash,
                    FailedTryCount = 0,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                context.User.Add(user);
                context.SaveChanges();

                UserRole role = new()
                {
                    UserId = user.Id,
                    RoleType = request.RoleType,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                context.Add(role);

                context.SaveChanges();
                transaction.Commit();

                return new SuccessDataResult<RegisterResponse>(new RegisterResponse());
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return new ErrorDataResult<RegisterResponse>(ex.Message);
            }
            
        }

        public IDataResult<bool> UpdatePassword(string username, string password)
        {
            // check jwt and update user password
            throw new NotImplementedException();
        }
    }
}
