namespace ShopAPI
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_risposta = new System.Windows.Forms.TextBox();
            this.b_genera = new System.Windows.Forms.Button();
            this.txt_descrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_salvagioco = new System.Windows.Forms.Button();
            this.b_cerca = new System.Windows.Forms.Button();
            this.txt_descrizionegioco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nomegioco = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.l_giocoscelto = new System.Windows.Forms.Label();
            this.data_prezzi = new System.Windows.Forms.DataGridView();
            this.b_cercaprezzi = new System.Windows.Forms.Button();
            this.cbox_tuoigiochiprezzo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_nomegiocoprezzo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.b_rimuovigioco = new System.Windows.Forms.Button();
            this.txt_rimuovigioco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.data_listamieigiochi = new System.Windows.Forms.DataGridView();
            this.b_vedilistagiochi = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_prezzi)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listamieigiochi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImage = global::ShopAPI.Properties.Resources.istockphoto_1545637815_612x612;
            this.tabPage1.Controls.Add(this.txt_risposta);
            this.tabPage1.Controls.Add(this.b_genera);
            this.tabPage1.Controls.Add(this.txt_descrizione);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cerca giochi";
            // 
            // txt_risposta
            // 
            this.txt_risposta.Enabled = false;
            this.txt_risposta.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_risposta.Location = new System.Drawing.Point(417, 33);
            this.txt_risposta.Multiline = true;
            this.txt_risposta.Name = "txt_risposta";
            this.txt_risposta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_risposta.Size = new System.Drawing.Size(311, 272);
            this.txt_risposta.TabIndex = 3;
            // 
            // b_genera
            // 
            this.b_genera.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.b_genera.Location = new System.Drawing.Point(22, 311);
            this.b_genera.Name = "b_genera";
            this.b_genera.Size = new System.Drawing.Size(367, 51);
            this.b_genera.TabIndex = 2;
            this.b_genera.Text = "Genera";
            this.b_genera.UseVisualStyleBackColor = true;
            this.b_genera.Click += new System.EventHandler(this.b_genera_Click);
            // 
            // txt_descrizione
            // 
            this.txt_descrizione.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_descrizione.Location = new System.Drawing.Point(22, 33);
            this.txt_descrizione.Multiline = true;
            this.txt_descrizione.Name = "txt_descrizione";
            this.txt_descrizione.Size = new System.Drawing.Size(367, 272);
            this.txt_descrizione.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(17, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrizione";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::ShopAPI.Properties.Resources._360_F_323880864_TPsH5ropjEBo1ViILJmcFHJqsBzorxUB;
            this.tabPage2.Controls.Add(this.b_salvagioco);
            this.tabPage2.Controls.Add(this.b_cerca);
            this.tabPage2.Controls.Add(this.txt_descrizionegioco);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_nomegioco);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dettagli e aggiunta gioco";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_salvagioco
            // 
            this.b_salvagioco.Location = new System.Drawing.Point(40, 246);
            this.b_salvagioco.Name = "b_salvagioco";
            this.b_salvagioco.Size = new System.Drawing.Size(701, 34);
            this.b_salvagioco.TabIndex = 6;
            this.b_salvagioco.Text = "Salva gioco";
            this.b_salvagioco.UseVisualStyleBackColor = true;
            this.b_salvagioco.Click += new System.EventHandler(this.b_salvagioco_Click);
            // 
            // b_cerca
            // 
            this.b_cerca.Location = new System.Drawing.Point(40, 286);
            this.b_cerca.Name = "b_cerca";
            this.b_cerca.Size = new System.Drawing.Size(701, 33);
            this.b_cerca.TabIndex = 5;
            this.b_cerca.Text = "Cerca gioco";
            this.b_cerca.UseVisualStyleBackColor = true;
            this.b_cerca.Click += new System.EventHandler(this.b_cerca_Click);
            // 
            // txt_descrizionegioco
            // 
            this.txt_descrizionegioco.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_descrizionegioco.Location = new System.Drawing.Point(134, 58);
            this.txt_descrizionegioco.Multiline = true;
            this.txt_descrizionegioco.Name = "txt_descrizionegioco";
            this.txt_descrizionegioco.ReadOnly = true;
            this.txt_descrizionegioco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_descrizionegioco.Size = new System.Drawing.Size(607, 166);
            this.txt_descrizionegioco.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(5, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descrizione gioco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome gioco";
            // 
            // txt_nomegioco
            // 
            this.txt_nomegioco.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_nomegioco.Location = new System.Drawing.Point(134, 26);
            this.txt_nomegioco.Name = "txt_nomegioco";
            this.txt_nomegioco.Size = new System.Drawing.Size(226, 26);
            this.txt_nomegioco.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::ShopAPI.Properties.Resources.istockphoto_1227598160_612x612;
            this.tabPage3.Controls.Add(this.l_giocoscelto);
            this.tabPage3.Controls.Add(this.data_prezzi);
            this.tabPage3.Controls.Add(this.b_cercaprezzi);
            this.tabPage3.Controls.Add(this.cbox_tuoigiochiprezzo);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txt_nomegiocoprezzo);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Compra gioco";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // l_giocoscelto
            // 
            this.l_giocoscelto.AutoSize = true;
            this.l_giocoscelto.BackColor = System.Drawing.Color.White;
            this.l_giocoscelto.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.l_giocoscelto.Location = new System.Drawing.Point(32, 63);
            this.l_giocoscelto.Name = "l_giocoscelto";
            this.l_giocoscelto.Size = new System.Drawing.Size(0, 23);
            this.l_giocoscelto.TabIndex = 6;
            // 
            // data_prezzi
            // 
            this.data_prezzi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_prezzi.Location = new System.Drawing.Point(14, 89);
            this.data_prezzi.Name = "data_prezzi";
            this.data_prezzi.Size = new System.Drawing.Size(588, 220);
            this.data_prezzi.TabIndex = 5;
            // 
            // b_cercaprezzi
            // 
            this.b_cercaprezzi.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.b_cercaprezzi.Location = new System.Drawing.Point(14, 315);
            this.b_cercaprezzi.Name = "b_cercaprezzi";
            this.b_cercaprezzi.Size = new System.Drawing.Size(588, 59);
            this.b_cercaprezzi.TabIndex = 4;
            this.b_cercaprezzi.Text = "Cerca Prezzi";
            this.b_cercaprezzi.UseVisualStyleBackColor = true;
            this.b_cercaprezzi.Click += new System.EventHandler(this.b_cercaprezzi_Click);
            // 
            // cbox_tuoigiochiprezzo
            // 
            this.cbox_tuoigiochiprezzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_tuoigiochiprezzo.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.cbox_tuoigiochiprezzo.FormattingEnabled = true;
            this.cbox_tuoigiochiprezzo.Location = new System.Drawing.Point(466, 34);
            this.cbox_tuoigiochiprezzo.Name = "cbox_tuoigiochiprezzo";
            this.cbox_tuoigiochiprezzo.Size = new System.Drawing.Size(231, 27);
            this.cbox_tuoigiochiprezzo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(270, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "O scegli tra i tuoi giochi";
            // 
            // txt_nomegiocoprezzo
            // 
            this.txt_nomegiocoprezzo.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_nomegiocoprezzo.Location = new System.Drawing.Point(116, 35);
            this.txt_nomegiocoprezzo.Name = "txt_nomegiocoprezzo";
            this.txt_nomegiocoprezzo.Size = new System.Drawing.Size(148, 26);
            this.txt_nomegiocoprezzo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome gioco";
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = global::ShopAPI.Properties.Resources._360_F_395371923_x2IUqSOYDCQeBCx3auKcK3EbyzNjhlNV;
            this.tabPage4.Controls.Add(this.b_rimuovigioco);
            this.tabPage4.Controls.Add(this.txt_rimuovigioco);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.data_listamieigiochi);
            this.tabPage4.Controls.Add(this.b_vedilistagiochi);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 400);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Area personale";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // b_rimuovigioco
            // 
            this.b_rimuovigioco.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.b_rimuovigioco.Location = new System.Drawing.Point(367, 57);
            this.b_rimuovigioco.Name = "b_rimuovigioco";
            this.b_rimuovigioco.Size = new System.Drawing.Size(368, 43);
            this.b_rimuovigioco.TabIndex = 4;
            this.b_rimuovigioco.Text = "Rimuovi gioco";
            this.b_rimuovigioco.UseVisualStyleBackColor = true;
            this.b_rimuovigioco.Click += new System.EventHandler(this.b_rimuovigioco_Click);
            // 
            // txt_rimuovigioco
            // 
            this.txt_rimuovigioco.Font = new System.Drawing.Font("Palatino Linotype", 10.25F, System.Drawing.FontStyle.Bold);
            this.txt_rimuovigioco.Location = new System.Drawing.Point(574, 16);
            this.txt_rimuovigioco.Name = "txt_rimuovigioco";
            this.txt_rimuovigioco.Size = new System.Drawing.Size(163, 26);
            this.txt_rimuovigioco.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(363, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nome gioco da rimuovere";
            // 
            // data_listamieigiochi
            // 
            this.data_listamieigiochi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_listamieigiochi.Location = new System.Drawing.Point(21, 16);
            this.data_listamieigiochi.Name = "data_listamieigiochi";
            this.data_listamieigiochi.Size = new System.Drawing.Size(336, 284);
            this.data_listamieigiochi.TabIndex = 1;
            // 
            // b_vedilistagiochi
            // 
            this.b_vedilistagiochi.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.b_vedilistagiochi.Location = new System.Drawing.Point(21, 327);
            this.b_vedilistagiochi.Name = "b_vedilistagiochi";
            this.b_vedilistagiochi.Size = new System.Drawing.Size(336, 56);
            this.b_vedilistagiochi.TabIndex = 0;
            this.b_vedilistagiochi.Text = "Vedi lista tuoi giochi";
            this.b_vedilistagiochi.UseVisualStyleBackColor = true;
            this.b_vedilistagiochi.Click += new System.EventHandler(this.b_vedilistagiochi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 451);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ShopAPI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_prezzi)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_listamieigiochi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_descrizione;
        private System.Windows.Forms.Button b_genera;
        private System.Windows.Forms.Button b_cerca;
        private System.Windows.Forms.TextBox txt_descrizionegioco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nomegioco;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button b_salvagioco;
        private System.Windows.Forms.ComboBox cbox_tuoigiochiprezzo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nomegiocoprezzo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView data_prezzi;
        private System.Windows.Forms.Button b_cercaprezzi;
        private System.Windows.Forms.Label l_giocoscelto;
        private System.Windows.Forms.DataGridView data_listamieigiochi;
        private System.Windows.Forms.Button b_vedilistagiochi;
        private System.Windows.Forms.TextBox txt_rimuovigioco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_rimuovigioco;
        private System.Windows.Forms.TextBox txt_risposta;
    }
}

