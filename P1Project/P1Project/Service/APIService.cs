using P1Project.Models;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace P1Project.Service
{
    public class APIService : IAPIService
    {

        public static string _baseUrl;

        public HttpClient _httpClient;
        public APIService()
        {

            var builder = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);


        }
        public async Task<bool> CrearOrden(Orden nOrden)
        {
            var content = new StringContent(JsonConvert.SerializeObject(nOrden), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Orden/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Plato orden1 = JsonConvert.DeserializeObject<Plato>(json_response);
                return true;
            }
            return false;
        }

        public async Task<Plato> CrearPlato(Plato nplato)
        {
            var content = new StringContent(JsonConvert.SerializeObject(nplato), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Plato/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Plato plato2 = JsonConvert.DeserializeObject<Plato>(json_response);
                return plato2;
            }
            return new Plato();
        }

        public async Task<bool> DeletePlato(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Plato/{id}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditarPlato(int id, Plato eplato)
        {
            var content = new StringContent(JsonConvert.SerializeObject(eplato), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Plato/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Plato plato = JsonConvert.DeserializeObject<Plato>(json_response);
                return true;
            }
            return false;
        }

        public async Task<Plato> GetPlato(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Plato/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Plato plato = JsonConvert.DeserializeObject<Plato>(json_response);
                return plato;
            }
            return new Plato();
        }

        public async Task<List<Plato>> GetPlatos()
        {
            var response = await _httpClient.GetAsync("/api/Plato");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Plato> plato = JsonConvert.DeserializeObject<List<Plato>>(json_response);
                return plato;
            }
            return new List<Plato>();
        }

        public async Task<List<Mesa>> Mesas()
        {
            var response = await _httpClient.GetAsync("/api/Mesa");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Mesa> mesas = JsonConvert.DeserializeObject<List<Mesa>>(json_response);
            return mesas;

        }

        public async Task<Mesa> ObtenerMesa(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Mesa/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Mesa mesa1 = JsonConvert.DeserializeObject<Mesa>(json_response);
                return mesa1;
            }
            return new Mesa();

        }

        public async Task<Orden> ObtenerOrden(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Orden/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Orden or1 = JsonConvert.DeserializeObject<Orden>(json_response);
                return or1;
            }
            return new Orden();
        }
    }
}
