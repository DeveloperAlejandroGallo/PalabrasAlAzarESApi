using Google.Cloud.Firestore;
using PalabrasAlAzarESApi.Enums;

namespace PalabrasAlAzarESApi.Models
{
    //[FirestoreData]
    public class Palabra 
    {
        //[FirestoreProperty]
        public int Id { get; set; } 
        //[FirestoreProperty]
        public string Texto { get; set; } = string.Empty;
        //[FirestoreProperty] 
        public string Definicion { get; set;} = string.Empty;
        //[FirestoreProperty] 
        public  Idiomas Idioma { get; set; }
        //[FirestoreProperty] 
        public bool Revisada { get; set; }
        //[FirestoreProperty]
        public string FechaActualizacion { get; set; } = string.Empty;

    }
}
