using BusinessLogic.Entities;
using BusinessLogic.Services.GymGoer;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories;

public class GymGoerRepository : IGymGoerRepository
{
    private readonly GymWorkoutDisclosedDBContext _context;

    public GymGoerRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }

    public GymGoerEntity? GetGymGoerById(Guid id)
    {
        return _context.gymGoer
            .Include(g => g.Workouts)
            .ThenInclude(w => w.Sets)
            .FirstOrDefault(g => g.Id == id);
    }
}