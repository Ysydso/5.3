using BusinessLogic.Classes;

namespace AuthService;

public interface IAuthRepository
{
    public GymGoer CreateGymGoerIfDoesntExist(GymGoer gymGoer);
    
    public GymGoer GetGymGoerByEmail(string email);
}