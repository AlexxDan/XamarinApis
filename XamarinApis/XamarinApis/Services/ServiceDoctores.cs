using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinApis.Models;

namespace XamarinApis.Services
{
   public class ServiceDoctores
    {
        private String url;
        public ServiceDoctores()
        {
            this.url = "https://apicruddoctorespgs.azurewebsites.net/";
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        
        private async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
                HttpResponseMessage response =
               await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);

                    return data;

                }
                else { return default(T); }
            }

        }

        public async Task<List<Doctores>> GetDoctoresAsync()
        {
            String request = "api/doctores";
            List<Doctores> doctores = await this.CallApiAsync<List<Doctores>>(request);
            return doctores;
        }


        public async Task<Doctores> FindDoctoresAsync(int id)
        {
            String request = "api/doctores/"+id;
            Doctores doct = await this.CallApiAsync<Doctores>(request);
            return doct;
        }

        public async Task InsertDoctor(int iddoctor,string apellido,
            string especialidad, int hospital, int salario)
        {
            Doctores doc = new Doctores();
            doc.IdDoctores = iddoctor;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.IdHospital = hospital;
            doc.Salario = salario;

            String json = JsonConvert.SerializeObject(doc);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                Uri uri = new Uri(this.url + request);


                HttpResponseMessage response =
               await client.PostAsync(uri, content);
            }
        }

        public async Task UpdateDoctor(int iddoctor, string apellido,
            string especialidad, int hospital, int salario)
        {
            Doctores doc =await FindDoctoresAsync(iddoctor);
           
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.IdHospital = hospital;
            doc.Salario = salario;

            String json = JsonConvert.SerializeObject(doc);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                String request = "api/doctores";
                Uri uri = new Uri(this.url + request);

                HttpResponseMessage response =
               await client.PutAsync(uri, content);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            String rquest = "api/doctores/" + id;
            Uri uri = new Uri(this.url + rquest);

            using (HttpClient client=new HttpClient())
            {
                await client.DeleteAsync(uri);
            }
        }

    }
}
