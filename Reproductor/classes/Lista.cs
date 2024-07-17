using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualBasic.Devices;
using Plugin.Logs;

namespace Reproductor.classes
{
    public class Lista
    {
        private List<Cancion> Canciones;
        private readonly string folder = Properties.Settings.Default.completeFolder;
        private Computer myComputer;
        private string Nombre;
        ILoggerFactory LoggerFactoryLista;
        ILogger Logger;


        public Lista(string ruta)
        {
            InitLog();
            
            try
            {
                Logger.Info("Construyendo Lista");
                myComputer = new Computer();
                Canciones = new List<Cancion>();
                Nombre = Path.GetFileName(ruta);
                ReadOnlyCollection<string> rutasCanciones = myComputer.FileSystem.GetFiles(ruta);

                for (int i = 0; i < rutasCanciones.Count; i++)
                {
                    TagLib.File tagFile = TagLib.File.Create(rutasCanciones[i]);
                    Cancion aux = new Cancion(tagFile, rutasCanciones[i]);
                    Canciones.Add(aux);
                }
            }
            catch(Exception excepcion)
            {
                Logger.Log("Error en la construcción de la Lista :" + Nombre, excepcion);
                
            }
            

        }

        public Lista()
        {

            InitLog();
            try
            {
                Logger.Info("Construyendo Lista");

                myComputer = new Computer();
                Canciones = new List<Cancion>();
                Nombre = "Nueva Lista";

                string listaFolder = folder + Path.DirectorySeparatorChar + Nombre;

                int i = 0;
                while (myComputer.FileSystem.DirectoryExists(listaFolder))
                {
                    Logger.Warning("Ya existe una Lista con ese nombre - " + Nombre);
                    i++;
                    listaFolder = folder + Path.DirectorySeparatorChar + Nombre + " (" + i + ")";
                }
                myComputer.FileSystem.CreateDirectory(listaFolder);
                if (i > 0)
                    Nombre = Nombre + " (" + i + ")";

                Logger.Info("Lista Creada - " + Nombre);
            }
            catch(Exception excepcion)
            {
                Logger.Log("Error en la construcción de la Lista :" + Nombre, excepcion);
            }

        }

        private void InitLog()
        {
            LoggerFactoryLista = new LoggerFactory
            {
                LogDirectoryPath = Properties.Settings.Default.logFolder
            };

            Logger = LoggerFactoryLista.GetLogger("Lista");
        }

        public void SetNombre(string nombre)
        {

            try
            {
                Logger.Info("Modificando nombre de la Lista ...");

                if (myComputer.FileSystem.DirectoryExists(folder + Path.DirectorySeparatorChar + nombre))
                    return;

                myComputer.FileSystem.RenameDirectory(folder + Path.DirectorySeparatorChar + Nombre, nombre);
                Nombre = nombre;

                Logger.Info("Actualizando rutas de las canciones contenidas ...");
                for (int i = 0; i < Canciones.Count; i++)
                {
                    Canciones[i].RutaArchivo = folder + Path.DirectorySeparatorChar + Nombre + Path.DirectorySeparatorChar + Path.GetFileName(Canciones[i].RutaArchivo);
                }
                Logger.Info("Cambio Completado en la Lista "+Nombre);
            }
            catch (Exception excepcion)
            {
                Logger.Log("Error en el cambio de nombre de la Lista :" + Nombre, excepcion);
            }

        }

        public string GetNombre() { return Nombre; }

        public List<Cancion> GetCanciones() { return Canciones; }

        public void AddCancion(Cancion cancion)
        {

            try
            {
                Logger.Info("Añadiendo cancion nueva ");

                if (!myComputer.FileSystem.FileExists(cancion.RutaArchivo))
                    return;


                string nuevaRuta = folder + Path.DirectorySeparatorChar + Nombre + Path.DirectorySeparatorChar + Path.GetFileName(cancion.RutaArchivo);

                Logger.Info("Nueva ruta Calculcada = "+nuevaRuta);

                int i = 1;
                while (myComputer.FileSystem.FileExists(nuevaRuta))
                {
                    Logger.Info("(Nombre Fichero Existe) Nueva ruta ReCalculcada = " + nuevaRuta);
                    nuevaRuta = folder + Path.DirectorySeparatorChar + Nombre + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(cancion.RutaArchivo) + " (" + i + ")" + Path.GetExtension(cancion.RutaArchivo);
                    i++;
                }
                myComputer.FileSystem.CopyFile(cancion.RutaArchivo, nuevaRuta);
                cancion.RutaArchivo = nuevaRuta;

                Canciones.Add(cancion);
                Logger.Info("Cancion Añadida");
            }
            catch (Exception excepcion)
            {
                Logger.Log("Error al añadir la cancion de la Lista :" + Nombre, excepcion);
            }
            
        }

        public Cancion GetCancion( int index )
        {
            if (index >= Canciones.Count)
                return null;
            return Canciones[index];
        }

        public void DeleteCancion( int index)
        {
            try
            {
                if (index > Canciones.Count - 1 || !myComputer.FileSystem.FileExists(Canciones[index].RutaArchivo))
                    return;

                myComputer.FileSystem.DeleteFile(Canciones[index].RutaArchivo);
                Canciones.RemoveAt(index);
            }
            catch (Exception excepcion)
            {
                Logger.Log("Error en el borrado de la Cacion de la Lista :" + Nombre, excepcion);
            }
            
        }

        public void DeleteLista() => myComputer.FileSystem.DeleteDirectory(folder + Path.DirectorySeparatorChar + Nombre, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);

        public override string ToString()
        {
            return Nombre;
        }
    }
}
