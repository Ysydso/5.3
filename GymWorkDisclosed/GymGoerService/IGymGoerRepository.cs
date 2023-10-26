using BusinessLogic.Entities;
namespace BusinessLogic.Services.GymGoer;

public interface IGymGoerRepository
{
    public GymGoerEntity? GetGymGoerById(Guid id);
}