using Microsoft.EntityFrameworkCore;
using Models;

namespace PresentationLayer.Repository.InstractorRepo
{
    public class InstractorRepository : IInstractorRepository

    {
        private readonly Center context;

        public InstractorRepository(Center _center)
        {
            context = _center;
        }
        public async Task Delete(int id)
        {
            Instractor instractor = await GetByID(id);
            context.Remove(instractor);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Instractor>> GetAll()
        {
            return await context.Instractors.ToListAsync();
        }

        public async Task<Instractor> GetByID(int id)
        {
            return await context.Instractors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, Instractor newInstractor)
        {
            Instractor OldInstractor = await GetByID(id);
            OldInstractor.Name = newInstractor.Name;
            OldInstractor.Address = newInstractor.Address;
            OldInstractor.Dept_ID = newInstractor.Dept_ID;
            OldInstractor.Image = newInstractor.Image;
            OldInstractor.Course = newInstractor.Course;
            context.Update(OldInstractor);
            context.SaveChanges();

        }
    }
}
