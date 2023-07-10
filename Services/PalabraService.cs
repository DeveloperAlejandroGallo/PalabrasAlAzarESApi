using Google.Cloud.Firestore;
using Newtonsoft.Json;
using PalabrasAlAzarESApi.Data;
using PalabrasAlAzarESApi.Enums;
using PalabrasAlAzarESApi.Models;

namespace PalabrasAlAzarESApi.Services
{
    public class PalabraService : IPalabraService
    {
        private string directory = Path.GetFullPath(@"C:\Git\C#\PalabrasAlAzarESApi\palabrasalazar-cd9e7-firebase-adminsdk-v4nmu-7ef56d1f70.json");
        const string DB = "Palabras";
        const string PALABRAS_DIR = "Data/palabras.json";
        private string _projectId;
        private FirestoreDb _firestoreDb;
        private List<Palabra> _palabras = new List<Palabra>();

        public PalabraService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", directory);
            _projectId = "palabrasalazar-cd9e7";
            _firestoreDb = FirestoreDb.Create(_projectId);
        }
        public Task<Palabra> GetPalabra(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Palabra> GetPalabraAlAzar()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Palabra>> GetPalabrasFirebase()
        {
            var result = new List<Palabra>();
            Query palabrasQuery = _firestoreDb.Collection(DB);
            QuerySnapshot palabrasQuerySnapchot = await palabrasQuery.GetSnapshotAsync();
            _palabras = new List<Palabra>();

            foreach (var docSnapShot in palabrasQuerySnapchot.Documents)
            {
                Console.WriteLine("Que onda?");
                if (docSnapShot.Exists)
                {
                    Console.WriteLine(docSnapShot);
                    Dictionary<string, object> palabras = docSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(palabras);

                    Palabra nuevPalabra = JsonConvert.DeserializeObject<Palabra>(json)!;

                    result.Add(nuevPalabra);
                }
            }

            return result;

        }

        public int  GuardarJsonInicial()
        {
            string jsonNuevasPalabras = JsonConvert.SerializeObject(PalabrasLista.palabrasNuevas);
            File.WriteAllText(PALABRAS_DIR, jsonNuevasPalabras);

            return jsonNuevasPalabras.Length;
        }

        public List<Palabra> GetPalabrasJson()
        {
            string json = File.ReadAllText(PALABRAS_DIR);
            List<Palabra> palabrasJson = JsonConvert.DeserializeObject<List<Palabra>>(json)!;
            return palabrasJson;
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
