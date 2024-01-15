using BusinessLogic.Classes;

namespace AuthService;

public interface IAuthRepository
{
    public GymGoer GetGymGoerByEmail(string email);
}