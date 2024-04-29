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

            return new SuccessDataResult<LoginResponse>(response);
        }

        public IDataResult<RegisterResponse> Register(RegisterRequest request)
        {            
            // check is email unique

            string hash = hashHelper.Encrypt(request.Password);

            User user = new() 
            { 
                Email = request.Email,
                PasswordHash = hash ,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now 
            };
            
            context.User.Add(user);
            context.SaveChanges();

            UserRole role = new() 
            { 
                UserId = user.Id,
                RoleType = request.RoleType ,
                CreatedOn = DateTime.Now ,
                UpdatedOn = DateTime.Now
            };
            context.Add(role);
            context.SaveChanges();

            return new SuccessDataResult<RegisterResponse>(new RegisterResponse());
        }

        public void UpdatePassword(string username, string password)
        {
            // check jwt and update user password
            throw new NotImplementedException();
        }
    }
}
