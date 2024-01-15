using BusinessLogic.Classes;

namespace PersonalTrainerService;

public interface ITrainerRepository
{
    public PersonalTrainer GetTrainer(Guid id);
}