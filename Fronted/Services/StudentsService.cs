using Fronted.Models;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Fronted.Services
{
   
    public class StudentsService : IStudentsService
    {
       
       private readonly HttpClient httpClient;

       public StudentsService(HttpClient _httpClient)
       {
        httpClient = _httpClient;
        ServicePointManager.ServerCertificateValidationCallback =  delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
            { return true; };
       }

        async Task<List<Students>> IStudentsService.GetStudents()
        {
            return await httpClient.GetFromJsonAsync<List<Students>>("api/Students");
        }

          async Task<Students> IStudentsService.GetStudents(int id)
        {
            return await httpClient.GetFromJsonAsync<Students>($"api/Students/{id}");
        }

        async Task<Students> IStudentsService.CreateStudents(Students students)
        {
            var result = await httpClient.PostAsJsonAsync<Students>($"api/Students",students);
            var newStudent = await result.Content.ReadFromJsonAsync<Students>();
            return newStudent;
        }

        async Task IStudentsService.UpdateStudents(int id,Students students)
        {
            await httpClient.PutAsJsonAsync<Students>($"api/Students/{id}", students);
        }

        public async Task DeleteStudents(int id)
        {
            await httpClient.DeleteAsync($"api/Students/{id}");
        }



}
}