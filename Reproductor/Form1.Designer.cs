namespace Reproductor
{
    partial class Reproductor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reproductor));
            this.reproductorMedia = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstCanciones = new System.Windows.Forms.ListBox();
            this.lstListas = new System.Windows.Forms.ListBox();
            this.trckSong = new XComponent.SliderBar.MACTrackBar();
            this.trckSound = new XComponent.SliderBar.MACTrackBar();
            this.lblSong = new System.Windows.Forms.Label();
            this.tmSong = new System.Windows.Forms.Timer(this.components);
            this.lblNombreLista = new System.Windows.Forms.TextBox();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.lblAddSong = new System.Windows.Forms.Label();
            this.lblDeleteSong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteList = new System.Windows.Forms.PictureBox();
            this.btnDeleteSong = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.PictureBox();
            this.btnSound = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnAddSongs = new System.Windows.Forms.PictureBox();
            this.btn_addList = new System.Windows.Forms.PictureBox();
            this.lblAddList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reproductorMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_addList)).BeginInit();
            this.SuspendLayout();
            // 
            // reproductorMedia
            // 
            this.reproductorMedia.Enabled = true;
            this.reproductorMedia.Location = new System.Drawing.Point(235, 488);
            this.reproductorMedia.Name = "reproductorMedia";
            this.reproductorMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reproductorMedia.OcxState")));
            this.reproductorMedia.Size = new System.Drawing.Size(357, 71);
            this.reproductorMedia.TabIndex = 0;
            this.reproductorMedia.Visible = false;
            this.reproductorMedia.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.ReproductorMedia_PlayStateChange);
            // 
            // lstCanciones
            // 
            this.lstCanciones.FormattingEnabled = true;
            this.lstCanciones.Location = new System.Drawing.Point(230, 116);
            this.lstCanciones.Name = "lstCanciones";
            this.lstCanciones.Size = new System.Drawing.Size(558, 290);
            this.lstCanciones.TabIndex = 1;
            this.lstCanciones.SelectedIndexChanged += new System.EventHandler(this.LstCanciones_SelectedIndexChanged);
            // 
            // lstListas
            // 
            this.lstListas.FormattingEnabled = true;
            this.lstListas.Location = new System.Drawing.Point(12, 77);
            this.lstListas.Name = "lstListas";
            this.lstListas.Size = new System.Drawing.Size(212, 329);
            this.lstListas.TabIndex = 2;
            this.lstListas.SelectedIndexChanged += new System.EventHandler(this.LstListas_SelectedIndexChanged);
            // 
            // trckSong
            // 
            this.trckSong.BackColor = System.Drawing.Color.Transparent;
            this.trckSong.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.trckSong.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trckSong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.trckSong.IndentHeight = 6;
            this.trckSong.Location = new System.Drawing.Point(254, 38);
            this.trckSong.Maximum = 10;
            this.trckSong.Minimum = 0;
            this.trckSong.Name = "trckSong";
            this.trckSong.Size = new System.Drawing.Size(333, 28);
            this.trckSong.TabIndex = 9;
            this.trckSong.TabStop = false;
            this.trckSong.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trckSong.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.trckSong.TickHeight = 4;
            this.trckSong.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trckSong.TrackerColor = System.Drawing.Color.Black;
            this.trckSong.TrackerSize = new System.Drawing.Size(16, 16);
            this.trckSong.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.trckSong.TrackLineHeight = 3;
            this.trckSong.TrackLineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.trckSong.Value = 0;
            // 
            // trckSound
            // 
            this.trckSound.BackColor = System.Drawing.Color.Transparent;
            this.trckSound.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.trckSound.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trckSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.trckSound.IndentHeight = 6;
            this.trckSound.Location = new System.Drawing.Point(646, 38);
            this.trckSound.Maximum = 100;
            this.trckSound.Minimum = 0;
            this.trckSound.Name = "trckSound";
            this.trckSound.Size = new System.Drawing.Size(145, 28);
            this.trckSound.TabIndex = 10;
            this.trckSound.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trckSound.TickColor = System.Drawing.Color.Black;
            this.trckSound.TickHeight = 4;
            this.trckSound.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trckSound.TrackerColor = System.Drawing.Color.Black;
            this.trckSound.TrackerSize = new System.Drawing.Size(16, 16);
            this.trckSound.TrackLineColor = System.Drawing.Color.Gray;
            this.trckSound.TrackLineHeight = 3;
            this.trckSound.TrackLineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.trckSound.Value = 0;
            this.trckSound.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.TrckSound_ValueChanged);
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSong.Location = new System.Drawing.Point(249, 3);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(0, 29);
            this.lblSong.TabIndex = 11;
            // 
            // tmSong
            // 
            this.tmSong.Enabled = true;
            this.tmSong.Interval = 1;
            this.tmSong.Tick += new System.EventHandler(this.TmSong_Tick);
            // 
            // lblNombreLista
            // 
            this.lblNombreLista.BackColor = System.Drawing.SystemColors.Control;
            this.lblNombreLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblNombreLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreLista.Location = new System.Drawing.Point(230, 88);
            this.lblNombreLista.Name = "lblNombreLista";
            this.lblNombreLista.Size = new System.Drawing.Size(436, 24);
            this.lblNombreLista.TabIndex = 13;
            this.lblNombreLista.DoubleClick += new System.EventHandler(this.LblNombreLista_DoubleClick);
            this.lblNombreLista.Enter += new System.EventHandler(this.LblNombreLista_Enter);
            this.lblNombreLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LblNombreLista_KeyDown);
            this.lblNombreLista.Leave += new System.EventHandler(this.LblNombreLista_Leave);
            // 
            // btnChangeName
            // 
            this.btnChangeName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChangeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChangeName.Location = new System.Drawing.Point(669, 86);
            this.btnChangeName.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(119, 34);
            this.btnChangeName.TabIndex = 14;
            this.btnChangeName.Text = "Cambiar Nombre";
            this.btnChangeName.UseVisualStyleBackColor = false;
            this.btnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // lblAddSong
            // 
            this.lblAddSong.AutoSize = true;
            this.lblAddSong.Location = new System.Drawing.Point(709, 409);
            this.lblAddSong.Name = "lblAddSong";
            this.lblAddSong.Size = new System.Drawing.Size(79, 13);
            this.lblAddSong.TabIndex = 15;
            this.lblAddSong.Text = "Añadir Canción";
            // 
            // lblDeleteSong
            // 
            this.lblDeleteSong.AutoSize = true;
            this.lblDeleteSong.Location = new System.Drawing.Point(615, 409);
            this.lblDeleteSong.Name = "lblDeleteSong";
            this.lblDeleteSong.Size = new System.Drawing.Size(77, 13);
            this.lblDeleteSong.TabIndex = 17;
            this.lblDeleteSong.Text = "Borrar Canción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Borrar Lista";
            // 
            // btnDeleteList
            // 
            this.btnDeleteList.Image = global::Reproductor.Properties.Resources.borrado;
            this.btnDeleteList.Location = new System.Drawing.Point(139, 425);
            this.btnDeleteList.Name = "btnDeleteList";
            this.btnDeleteList.Size = new System.Drawing.Size(48, 36);
            this.btnDeleteList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteList.TabIndex = 18;
            this.btnDeleteList.TabStop = false;
            this.btnDeleteList.Click += new System.EventHandler(this.BtnDeleteList_Click);
            // 
            // btnDeleteSong
            // 
            this.btnDeleteSong.Image = global::Reproductor.Properties.Resources.borrado;
            this.btnDeleteSong.Location = new System.Drawing.Point(634, 425);
            this.btnDeleteSong.Name = "btnDeleteSong";
            this.btnDeleteSong.Size = new System.Drawing.Size(48, 36);
            this.btnDeleteSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteSong.TabIndex = 16;
            this.btnDeleteSong.TabStop = false;
            this.btnDeleteSong.Click += new System.EventHandler(this.BtnDeleteSong_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::Reproductor.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(98, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(57, 49);
            this.btnStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStop.TabIndex = 8;
            this.btnStop.TabStop = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnSound
            // 
            this.btnSound.Image = global::Reproductor.Properties.Resources.sound;
            this.btnSound.Location = new System.Drawing.Point(593, 35);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(47, 36);
            this.btnSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSound.TabIndex = 7;
            this.btnSound.TabStop = false;
            this.btnSound.Click += new System.EventHandler(this.BtnSound_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::Reproductor.Properties.Resources.prev;
            this.btnPrev.Location = new System.Drawing.Point(161, 35);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(36, 36);
            this.btnPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrev.TabIndex = 6;
            this.btnPrev.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Reproductor.Properties.Resources.next;
            this.btnNext.Location = new System.Drawing.Point(203, 35);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 36);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext.TabIndex = 5;
            this.btnNext.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(12, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 68);
            this.btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPlay.TabIndex = 4;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // btnAddSongs
            // 
            this.btnAddSongs.Image = global::Reproductor.Properties.Resources.addMusic;
            this.btnAddSongs.Location = new System.Drawing.Point(728, 425);
            this.btnAddSongs.Name = "btnAddSongs";
            this.btnAddSongs.Size = new System.Drawing.Size(40, 36);
            this.btnAddSongs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddSongs.TabIndex = 3;
            this.btnAddSongs.TabStop = false;
            this.btnAddSongs.Click += new System.EventHandler(this.AddSongs_Click);
            // 
            // btn_addList
            // 
            this.btn_addList.Image = global::Reproductor.Properties.Resources.addList;
            this.btn_addList.Location = new System.Drawing.Point(44, 425);
            this.btn_addList.Name = "btn_addList";
            this.btn_addList.Size = new System.Drawing.Size(48, 36);
            this.btn_addList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_addList.TabIndex = 20;
            this.btn_addList.TabStop = false;
            this.btn_addList.Click += new System.EventHandler(this.Btn_addList_Click);
            // 
            // lblAddList
            // 
            this.lblAddList.AutoSize = true;
            this.lblAddList.Location = new System.Drawing.Point(41, 409);
            this.lblAddList.Name = "lblAddList";
            this.lblAddList.Size = new System.Drawing.Size(62, 13);
            this.lblAddList.TabIndex = 21;
            this.lblAddList.Text = "Añadir Lista";
            // 
            // Reproductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.lblAddList);
            this.Controls.Add(this.btn_addList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteList);
            this.Controls.Add(this.lblDeleteSong);
            this.Controls.Add(this.btnDeleteSong);
            this.Controls.Add(this.lblAddSong);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.lblNombreLista);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.trckSound);
            this.Controls.Add(this.trckSong);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnAddSongs);
            this.Controls.Add(this.lstListas);
            this.Controls.Add(this.lstCanciones);
            this.Controls.Add(this.reproductorMedia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Reproductor";
            this.Text = "Reproductor de Musica";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reproductor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reproductor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.reproductorMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_addList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer reproductorMedia;
        private System.Windows.Forms.ListBox lstCanciones;
        private System.Windows.Forms.ListBox lstListas;
        private System.Windows.Forms.PictureBox btnAddSongs;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox btnPrev;
        private System.Windows.Forms.PictureBox btnSound;
        private System.Windows.Forms.PictureBox btnStop;
        private XComponent.SliderBar.MACTrackBar trckSong;
        private XComponent.SliderBar.MACTrackBar trckSound;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.Timer tmSong;
        private System.Windows.Forms.TextBox lblNombreLista;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Label lblAddSong;
        private System.Windows.Forms.PictureBox btnDeleteSong;
        private System.Windows.Forms.Label lblDeleteSong;
        private System.Windows.Forms.PictureBox btnDeleteList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btn_addList;
        private System.Windows.Forms.Label lblAddList;
    }
}

