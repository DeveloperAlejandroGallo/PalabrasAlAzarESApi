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
        //            Dictionary<string, object> palabrasNuevas = docSnapShot.ToDictionary();
        //            string json = JsonConvert.SerializeObject(palabrasNuevas);

        //            Palabra nuevPalabra = JsonConvert.DeserializeObject<Palabra>(json)!;

        //            result.Add(nuevPalabra);
        //        }
        //    }

        //    return result;

        //}

        public int  GuardarJson(List<Palabra> palabrasNuevas)
        {
            string jsonNuevasPalabras = JsonConvert.SerializeObject(palabrasNuevas);
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

        public Palabra PostPalabra(Palabra palabra)
        {
            throw new NotImplementedException();
        }

        public Palabra PutPalabra(Palabra palabra)
        {
            if (palabra.Texto != String.Empty && !palabrasList.Contains(palabra))
            {
                palabrasList.Add(palabra);
            }

            return palabra;
        }
        

    }
}
