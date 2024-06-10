using Models;
using System.Collections.Generic;

namespace PresentationLayer.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly Center context;

        public TraineeRepository(Center center)
        {
            context = center;
        }
        public async Task<IEnumerable<Trainee>> GetAll()
        {
            return context.Trainees.ToList();
        }

        public async Task Update(int id, Trainee trainee)
        {
            Trainee OldTrainee = await GetByID(id);
            OldTrainee.Address = trainee.Address;
            OldTrainee.Name = trainee.Name;
            OldTrainee.Image = trainee.Image;
            OldTrainee.Dept_ID = trainee.Dept_ID;
            context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            Trainee trainee = await GetByID(id);
            context.Remove(trainee);
            context.SaveChanges();
        }

        public async Task<Trainee> GetByID(int id)
        {
            Trainee trainee = context.Trainees.FirstOrDefault(a => a.Id == id); ;
            return trainee;
        }

        public async Task<IEnumerable<CourseResult>> TrainesCrsResult(int id)
        {
           return  context.CourseResults.Where(a => a.Trainee_Id == id).ToList();
        }
    }
}
