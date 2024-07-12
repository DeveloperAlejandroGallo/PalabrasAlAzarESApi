using PalabrasAlAzarESApi.Models;

namespace PalabrasAlAzarESApi.Services
{
    public interface IPalabraService
    {
        Palabra GetPalabraAlAzar();
        Palabra? GetPalabra(int id);
        List<Palabra> GetPalabrasJson();
        //Task<List<Palabra>> GetPalabrasFirebase();
        Palabra PostPalabra(Palabra palabra);
        Palabra PutPalabra(Palabra palabra);
        int GuardarJson(List<Palabra> palabrasNuevas);
    }
}
