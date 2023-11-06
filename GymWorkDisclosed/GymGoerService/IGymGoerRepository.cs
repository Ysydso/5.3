using BusinessLogic.Classes;
namespace BusinessLogic.Services.GymGoer;

public interface IGymGoerRepository
{
    public Classes.GymGoer GetGymGoerById(Guid id);
}