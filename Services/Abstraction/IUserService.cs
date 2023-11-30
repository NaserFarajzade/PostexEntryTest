using Models.OnlineShop;

namespace Services.Abstraction;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
}