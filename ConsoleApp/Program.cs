using DomainModel;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetClassrooms();

            var classroom = new Classroom()
            {
                ClassroomId = 5,
                Name = "Salle Anders Hejlsberg",
                Floor = 8,
                Corridor = "Gris"
            };

            //PostClassroom(classroom);
            //PutClassroom(classroom);
            //GetClassroom(classroom.ClassroomId);
            DeleteClassroom(classroom.ClassroomId);

            Console.ReadLine();
        }

        private static async void GetClassrooms()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.GetAsync("api/classroom");

                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();

                    Console.WriteLine(content);
                }
            }
        }

        private static async void GetClassroom(int classroomId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.GetAsync($"api/classroom/{classroomId}");

                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();

                    Console.WriteLine(content);
                }
            }
        }

        private static async void PostClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage message = await client.PostAsync("api/classroom", httpContent);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom ajouté");
                }
            }
        }

        private static async void PutClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage message = await client.PutAsync($"api/classroom/{classroom.ClassroomId}", httpContent);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom mis à jour");
                }
            }
        }

        private static async void DeleteClassroom(int classroomId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.DeleteAsync($"api/classroom/{classroomId}");

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom supprimé");
                }
            }
        }
    }
}
