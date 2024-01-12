using BusinessLogic.Classes;

namespace AuthService;

public class AuthService
{
    private readonly IAuthRepository _authRepository;
    
    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    public GymGoer CreateGymGoer(GymGoer gymGoer)
    {
        return _authRepository.CreateGymGoerIfDoesntExist(gymGoer);
    }
    
    public GymGoer GetGymGoerByEmail(string email)
    {
        GymGoer? gymGoer = _authRepository.GetGymGoerByEmail(email);
        return gymGoer;
    }
    
    // public bool CheckIfGymGoerExists(string email)
    // {
    //     return _authRepository.GetGymGoerByEmail(email) != null;
    // }
}