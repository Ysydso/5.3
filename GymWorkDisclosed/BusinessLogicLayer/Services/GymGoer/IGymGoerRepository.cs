using BusinessLogicLayer.Entities;
namespace BusinessLogicLayer.Services.GymGoer;

public interface IGymGoerRepository
{
    public GymGoerEntity? GetGymGoerById(Guid id);
}