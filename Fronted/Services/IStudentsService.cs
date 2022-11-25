using System.Threading.Tasks;
using System.Collections.Generic;
using Fronted.Models;

namespace Fronted.Services
{
    public interface IStudentsService
    {
        Task<List<Students>> GetStudents();
        public Task<Students>GetStudents(int id);
        public Task <Students> CreateStudents(Students students);
        public Task UpdateStudents(int id, Students students);
        public Task DeleteStudents(int id);
         
    }
}