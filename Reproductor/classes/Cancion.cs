using System;


namespace Reproductor.classes
{
    public class Cancion
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Archivo { get; set; }
        public string RutaArchivo { get; set; }
        public double Puntuacion { get; set; }
        public TimeSpan Duracion { get; set; }
        public string FileType { get; set; }

        public Cancion()
        {
            Titulo = null;
            Archivo = null;
            RutaArchivo = null;
            Puntuacion = 0;
        }

        public Cancion(TagLib.File tagFile, string rutaFichero)
        {
            Archivo = tagFile.Name;
            Titulo = tagFile.Tag.Title ?? "Titulo desconocido";
            Artista = tagFile.Tag.Performers.Length == 0 ? "Autor desconocido" : tagFile.Tag.Performers[0];
            Album = tagFile.Tag.Album ?? "Album desconocido";
            Duracion = tagFile.Properties.Duration;
            RutaArchivo = rutaFichero;
            FileType = tagFile.MimeType;
            Puntuacion = 0;
        }

        public override string ToString()
        {
            return Titulo + " - " + Album + " | " + Artista;
        }
    }
}
