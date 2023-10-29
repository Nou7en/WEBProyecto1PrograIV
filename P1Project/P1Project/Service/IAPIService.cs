using P1Project.Models;

namespace P1Project.Service
{
    public interface IAPIService
    {
        public Task<List<Mesa>> GetMesas();

        public Task<List<Orden>> GetOrdens(int id);



    }
}
