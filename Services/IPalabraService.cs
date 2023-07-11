using PalabrasAlAzarESApi.Models;

namespace PalabrasAlAzarESApi.Services
{
    public interface IPalabraService
    {
        Palabra GetPalabraAlAzar();
        Palabra? GetPalabra(int id);
        List<Palabra> GetPalabrasJson();
        //Task<List<Palabra>> GetPalabrasFirebase();
        Task<Palabra> PostPalabra(Palabra palabra);
        Task<Palabra> PutPalabra(Palabra palabra);
        int GuardarJsonInicial();
    }
}
