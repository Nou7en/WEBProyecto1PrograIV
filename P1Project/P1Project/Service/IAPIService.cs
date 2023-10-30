using Microsoft.AspNetCore.Mvc;
using P1Project.Models;

namespace P1Project.Service
{
    public interface IAPIService
    {
        public Task<List<Mesa>> Mesas();

        public Task<Mesa> ObtenerMesa(int id);

        public Task<Orden> ObtenerOrden(int id);

        public Task<Boolean> CrearOrden(Orden nOrden);

        public Task<List<Plato>> GetPlatos();

        public Task<Plato> GetPlato(int id);

        public Task<Plato> CrearPlato(Plato nplato); //Por revisar

        public Task<Boolean> DeletePlato(int id);

        public Task<Boolean> EditarPlato(int id, Plato eplato);

        }
}
