using BusinessLogic.Classes;
namespace BusinessLogic.Services.GymGoer;

public class GymGoerService
{
    private readonly IGymGoerRepository _gymGoerRepository;
    
    public GymGoerService(IGymGoerRepository gymGoerRepository)
    {
        _gymGoerRepository = gymGoerRepository;
    }
    
    public Classes.GymGoer GetGymGoerById(Guid id)
    {
        return _gymGoerRepository.GetGymGoerById(id).ToGymGoer();
    }
    
}