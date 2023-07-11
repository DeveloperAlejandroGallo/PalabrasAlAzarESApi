using Newtonsoft.Json;
using PalabrasAlAzarESApi.Data;
using PalabrasAlAzarESApi.Enums;
using PalabrasAlAzarESApi.Models;

namespace PalabrasAlAzarESApi.Services
{
    public class PalabraService : IPalabraService
    {
        const string PALABRAS_DIR = "Data/palabras.json";

        private static List<Palabra> palabrasList = new List<Palabra>();

        public PalabraService()
        {
        }
        public Palabra? GetPalabra(int id)
        {
            Palabra? result = null;

            if(id < 1) { return result; }
            
            if(palabrasList.Count == 0)
            {
                palabrasList = GetPalabrasJson();
            }

            result = palabrasList[id-1];

            return result;
        }

        public Palabra GetPalabraAlAzar()
        {
            Palabra result = new Palabra();

            if (palabrasList.Count == 0)
            {
                palabrasList = GetPalabrasJson();
            }

            var random = new Random();

            return palabrasList[random.Next(1,palabrasList.Count)];

        }

        //public async Task<List<Palabra>> GetPalabrasFirebase()
        //{
        //    var result = new List<Palabra>();
        //    Query palabrasQuery = _firestoreDb.Collection(DB);
        //    QuerySnapshot palabrasQuerySnapchot = await palabrasQuery.GetSnapshotAsync();
        //    _palabras = new List<Palabra>();

        //    foreach (var docSnapShot in palabrasQuerySnapchot.Documents)
        //    {
        //        Console.WriteLine("Que onda?");
        //        if (docSnapShot.Exists)
        //        {
        //            Console.WriteLine(docSnapShot);
        //            Dictionary<string, object> palabras = docSnapShot.ToDictionary();
        //            string json = JsonConvert.SerializeObject(palabras);

        //            Palabra nuevPalabra = JsonConvert.DeserializeObject<Palabra>(json)!;

        //            result.Add(nuevPalabra);
        //        }
        //    }

        //    return result;

        //}

        public int  GuardarJsonInicial()
        {
            string jsonNuevasPalabras = JsonConvert.SerializeObject(PalabrasLista.palabrasNuevas);
            File.WriteAllText(PALABRAS_DIR, jsonNuevasPalabras);

            return jsonNuevasPalabras.Length;
        }

        public List<Palabra> GetPalabrasJson()
        {

            if(palabrasList.Count == 0)
            {
                string json = File.ReadAllText(PALABRAS_DIR);
                List<Palabra> palabrasJson = JsonConvert.DeserializeObject<List<Palabra>>(json)!;
                return palabrasJson;
            }

            return palabrasList;
        }

        public Task<Palabra> PostPalabra(Palabra palabra)
        {
            throw new NotImplementedException();
        }

        public Task<Palabra> PutPalabra(Palabra palabra)
        {
            throw new NotImplementedException();
        }
        

    }
}
