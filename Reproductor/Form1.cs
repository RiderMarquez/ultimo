using Reproductor.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Plugin.Logs;
using Newtonsoft.Json;
using System.Text;

namespace Reproductor
{
    public partial class Reproductor : Form
    {

        internal List<Lista> listas;
        internal int SoundAux;
        internal Boolean Play;
        ILoggerFactory LoggerFactoryLista;
        ILogger Logger;
        Computer myComputer = new Computer();

        public Reproductor()
        {
            InitializeComponent();
            

            string rootFoolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + Properties.Settings.Default.RootFolder;
            SoundAux = 100;
            trckSound.Value = SoundAux;
            Play = false;

            if(!myComputer.FileSystem.DirectoryExists(rootFoolder))
                myComputer.FileSystem.CreateDirectory(rootFoolder);

            Properties.Settings.Default.completeFolder = rootFoolder;
            Properties.Settings.Default.logFolder = rootFoolder + Path.DirectorySeparatorChar + "Logs";
            Properties.Settings.Default.estadoFolder = Properties.Settings.Default.completeFolder + Path.DirectorySeparatorChar + "estado.json";
            Properties.Settings.Default.Save();
            InitLog();
            LoadListas();
        }

        private void InitLog()
        {
            LoggerFactoryLista = new LoggerFactory
            {
                LogDirectoryPath = Properties.Settings.Default.logFolder
            };

            Logger = LoggerFactoryLista.GetLogger("Main Window");
        }

        private void AddSongs_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Info("Añadiendo Cancion Nueva a la Lista");

                if (lstListas.SelectedIndex == -1)
                {
                    Logger.Warning("Añadiendo Lista al no existir una seleccionada");
                    listas.Add(new Lista());
                    UpdateListas();
                    lstListas.SelectedIndex = listas.Count - 1;
                }

                lblNombreLista.Text = listas[lstListas.SelectedIndex].GetNombre();
                Logger.Info("Creando caja de dialogo");
                OpenFileDialog CajaDeBusqueda = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = Properties.Settings.Default.formatAccepted
                };

                if (CajaDeBusqueda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Logger.Info("Añadiendo canciones");
                    for (int i = 0; i < CajaDeBusqueda.SafeFileNames.Length; i++)
                    {

                        TagLib.File tagFile = TagLib.File.Create(CajaDeBusqueda.FileNames[i]);
                        Cancion aux = new Cancion(tagFile, CajaDeBusqueda.FileNames[i]);

                        listas[lstListas.SelectedIndex].AddCancion(aux);

                        lstCanciones.Items.Add(aux);
                    }

                    if(lstCanciones.SelectedIndex == -1)
                    {
                        lstCanciones.SelectedIndex = 0;
                        Cancion actual = listas[lstListas.SelectedIndex].GetCancion(lstCanciones.SelectedIndex);
                        if (actual != null)
                        {
                            reproductorMedia.URL = actual.RutaArchivo;
                            lblSong.Text = actual.ToString();
                            Play = true;
                        }
                    }


                    UpdateCanciones();
                }
                Logger.Info("Cambios completados");
            }
            catch(Exception excepcion)
            {
                Logger.Log(" Error al añadir canciones a una lista", excepcion);
            }

            
        }

        private void LoadEstado()
        {

            try
            {

                if (!File.Exists(Properties.Settings.Default.estadoFolder))
                    return;

                Logger.Info("Cargando estado ...");
                Estado estado = JsonConvert.DeserializeObject<Estado>(File.ReadAllText(Properties.Settings.Default.estadoFolder));

                if(estado.NombreLista != null && estado.NombreCancion != null)
                {
                    for (int i = 0; i < listas.Count; i++)
                    {
                        if (!listas[i].GetNombre().Equals(estado.NombreLista))
                            continue;

                        lstListas.SelectedIndex = i;
                        UpdateCanciones();
                        break;
                    }

                    List<Cancion> canciones = listas[lstListas.SelectedIndex].GetCanciones();

                    for (int i = 0; i < canciones.Count; i++)
                    {
                        if (!canciones[i].Archivo.Equals(estado.NombreCancion))
                            continue;

                        lstCanciones.SelectedIndex = i;
                        reproductorMedia.URL = canciones[i].RutaArchivo;
                        reproductorMedia.Ctlcontrols.currentPosition = estado.PuntoCancion;
                        reproductorMedia.Ctlcontrols.pause();
                        break;
                    }
                }

                reproductorMedia.settings.volume = estado.Volumen;
                Logger.Info("Estado cargado");
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void LoadListas()
        {
            try
            {
                listas = new List<Lista>();

                ReadOnlyCollection<string> rutasListas = myComputer.FileSystem.GetDirectories(Properties.Settings.Default.completeFolder);

                for (int i = 0; i < rutasListas.Count; i++)
                {
                    if (rutasListas[i].Equals(Properties.Settings.Default.logFolder))
                        continue;
                    Lista aux = new Lista(rutasListas[i]);
                    listas.Add(aux);
                    lstListas.Items.Add(listas[listas.Count - 1]);
                }

                UpdateListas();
                LoadEstado();
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
             
        }

        private void UpdateListas()
        {
            lstListas.Items.Clear();
            for (int i = 0; i < listas.Count; i++)
            {
                lstListas.Items.Add(listas[i]);
            }
        }

        private void UpdateCanciones()
        {
            lstCanciones.Items.Clear();
            if (lstListas.SelectedIndex == -1) return;
            for (int i = 0; i < listas[lstListas.SelectedIndex].GetCanciones().Count; i++)
            {
                lstCanciones.Items.Add(listas[lstListas.SelectedIndex].GetCanciones()[i]);
            }
        }

        private void LstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex == -1)
                return;
            Cancion aux = listas[lstListas.SelectedIndex].GetCancion(lstCanciones.SelectedIndex);
            if (aux != null)
            {
                reproductorMedia.URL = aux.RutaArchivo;
                lblSong.Text = aux.ToString();
                Play = true;
            }
            
                Play = false;
        }

        private void BtnSound_Click(object sender, EventArgs e)
        {
            reproductorMedia.settings.volume = reproductorMedia.settings.volume > 0 ? 0 : SoundAux;
            btnSound.Image = trckSound.Value > 0 ? Properties.Resources.sound : Properties.Resources.no_sound;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Play = !Play;

            if (Play)
                reproductorMedia.Ctlcontrols.play();
            else
                reproductorMedia.Ctlcontrols.pause();

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Play = false;
            reproductorMedia.Ctlcontrols.stop();
        }

        private void UpdateTrackData()
        {
            try
            {
                if (reproductorMedia.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    trckSong.Maximum = (int)reproductorMedia.Ctlcontrols.currentItem.duration;
                    tmSong.Start();
                }
                else if (reproductorMedia.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    tmSong.Stop();
                }
                else if (reproductorMedia.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    tmSong.Stop();
                    trckSong.Value = 0;
                }
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void TmSong_Tick(object sender, EventArgs e)
        {
            UpdateTrackData();
            trckSong.Value = (int)reproductorMedia.Ctlcontrols.currentPosition;
            trckSound.Value = reproductorMedia.settings.volume;
            
            if (lstListas.SelectedIndex == -1)
                btnChangeName.Visible = false;
            else
                btnChangeName.Visible = true;
        }

        private void ReproductorMedia_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            UpdateTrackData();
        }

        private void TrckSound_ValueChanged(object sender, decimal value)
        {
            reproductorMedia.settings.volume = trckSound.Value;
            SoundAux = trckSound.Value > 0 ? trckSound.Value : SoundAux;
            btnSound.Image = trckSound.Value > 0 ? Properties.Resources.sound : Properties.Resources.no_sound;
        }

        private void LblNombreLista_DoubleClick(object sender, EventArgs e)
        {
            lblNombreLista.BackColor = Color.White;
        }


        private void LblNombreLista_Enter(object sender, EventArgs e)
        {
            lblNombreLista.BackColor = Color.White;
        }

        
        private void BtnChangeName_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstListas.SelectedIndex == -1)
                    return;
                reproductorMedia.URL = null;
                Play = false;
                listas[lstListas.SelectedIndex].SetNombre(lblNombreLista.Text);
                LblNombreLista_Leave(sender, e);
                int temporalSelect = lstListas.SelectedIndex;
                UpdateListas();
                lstListas.SelectedIndex = temporalSelect;
                LstCanciones_SelectedIndexChanged(sender, e);
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void LblNombreLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnChangeName_Click(sender, e);
                LblNombreLista_Leave(sender, e);
            }
                
        }
               

        private void LblNombreLista_Leave(object sender, EventArgs e)
        {
            lblNombreLista.BackColor = SystemColors.Control;
        }

        
        private void LstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstListas.SelectedIndex == -1) return;
                lstCanciones.Items.Clear();
                List<Cancion> canciones = listas[lstListas.SelectedIndex].GetCanciones();

                for (int i = 0; i < canciones.Count; i++)
                {
                    lstCanciones.Items.Add(canciones[i]);
                }
                lstCanciones.SelectedIndex = canciones.Count == 0 ? -1 : 0;
                lblNombreLista.Text = listas[lstListas.SelectedIndex].GetNombre();
                LstCanciones_SelectedIndexChanged(sender, e);
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            

        }

        private void BtnDeleteSong_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCanciones.SelectedIndex == -1) return;
                Play = false;
                reproductorMedia.URL = null;
                listas[lstListas.SelectedIndex].DeleteCancion(lstCanciones.SelectedIndex);
                lstCanciones.SelectedIndex = 0;
                UpdateCanciones();
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void Btn_addList_Click(object sender, EventArgs e)
        {
            try
            {
                listas.Add(new Lista());
                UpdateListas();
                lstListas.SelectedIndex = listas.Count - 1;
                lstCanciones.SelectedIndex = -1;
                UpdateCanciones();
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void BtnDeleteList_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstListas.SelectedIndex == -1) return;

                reproductorMedia.URL = null;
                listas[lstListas.SelectedIndex].DeleteLista();
                listas.RemoveAt(lstListas.SelectedIndex);
                UpdateListas();
                lstListas.SelectedIndex = -1;
                lstCanciones.SelectedIndex = -1;
                UpdateCanciones();
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }
            
        }

        private void Reproductor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (lstListas.SelectedIndex == -1 || lstCanciones.SelectedIndex == -1)
                    return;

                Estado estado = new Estado
                {
                    NombreLista = lstListas.SelectedIndex == -1 ? null : listas[lstListas.SelectedIndex].GetNombre(),
                    NombreCancion = lstCanciones.SelectedIndex == -1 ? null : listas[lstListas.SelectedIndex].GetCancion(lstCanciones.SelectedIndex).Archivo,
                    PuntoCancion = reproductorMedia.Ctlcontrols.currentPosition,
                    Volumen = reproductorMedia.settings.volume
                };

                string json = JsonConvert.SerializeObject(estado, Formatting.Indented);
               

                if (File.Exists(Properties.Settings.Default.estadoFolder))
                    File.Delete(Properties.Settings.Default.estadoFolder);

                FileStream fileStream = File.Create(Properties.Settings.Default.estadoFolder, 1024);

                Byte[] jsonByte = new UTF8Encoding(true).GetBytes(json);
                fileStream.Write(jsonByte, 0, jsonByte.Length);
            }
            catch (Exception excepcion)
            {
                Logger.Log(" Error al cargar todas las listas", excepcion);
            }

            
        }

        private void Reproductor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Info("Reproductor Cerrada");
        }
    }
}
