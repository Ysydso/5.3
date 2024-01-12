using AuthService;
using BusinessLogic.Classes;
using DAL.DBO;

namespace DAL.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly GymWorkoutDisclosedDBContext _context;

    public AuthRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }

    public GymGoer CreateGymGoerIfDoesntExist(GymGoer gymGoer)
    {
        GymGoerEntity gymGoerEntity = _context.gymGoer.FirstOrDefault(gg => gg.Email == gymGoer.Email);
        if (gymGoerEntity == null)
        {
            gymGoerEntity = new GymGoerEntity
            {
                Name = gymGoer.Name,
                Email = gymGoer.Email
            };
            _context.gymGoer.Add(gymGoerEntity);
            _context.SaveChanges();
        }
        return gymGoerEntity.ToGymGoer();
    }

    public GymGoer GetGymGoerByEmail(string email)
    {
        GymGoerEntity gymGoerEntity = _context.gymGoer.FirstOrDefault(gg => gg.Email == email);
        return gymGoerEntity?.ToGymGoer();
    }
}