namespace Proyecto_1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.varMenu = new System.Windows.Forms.MenuStrip();
            this.men1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPestañas = new System.Windows.Forms.TabControl();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gbPais = new System.Windows.Forms.GroupBox();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.lblPaisSelecionado = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.pbPais = new System.Windows.Forms.PictureBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.gbGrafica = new System.Windows.Forms.GroupBox();
            this.pbGrafica = new System.Windows.Forms.PictureBox();
            this.varMenu.SuspendLayout();
            this.gbPais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPais)).BeginInit();
            this.gbGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // varMenu
            // 
            this.varMenu.BackColor = System.Drawing.Color.White;
            this.varMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.men1,
            this.ayudaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.varMenu.Location = new System.Drawing.Point(0, 0);
            this.varMenu.Name = "varMenu";
            this.varMenu.Size = new System.Drawing.Size(962, 24);
            this.varMenu.TabIndex = 0;
            this.varMenu.Text = "menuStrip1";
            this.varMenu.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.varMenu_ChangeUICues);
            // 
            // men1
            // 
            this.men1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.men1.ForeColor = System.Drawing.Color.Black;
            this.men1.Name = "men1";
            this.men1.Size = new System.Drawing.Size(60, 20);
            this.men1.Text = "Archivo";
            this.men1.DropDownOpened += new System.EventHandler(this.men1_DropDownOpened);
            this.men1.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            this.men1.MouseHover += new System.EventHandler(this.archivoToolStripMenuItem_MouseHover);
            this.men1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.men1_MouseMove);
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nuevaPestañaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nuevaPestañaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevaPestañaToolStripMenuItem.Image")));
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guardarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guardarComoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.guardarComoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarComoToolStripMenuItem.Image")));
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.ayudaToolStripMenuItem.Text = "Acerca de...";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tcPestañas
            // 
            this.tcPestañas.Location = new System.Drawing.Point(12, 28);
            this.tcPestañas.Name = "tcPestañas";
            this.tcPestañas.SelectedIndex = 0;
            this.tcPestañas.Size = new System.Drawing.Size(300, 544);
            this.tcPestañas.TabIndex = 1;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAnalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.ForeColor = System.Drawing.Color.White;
            this.btnAnalizar.Location = new System.Drawing.Point(349, 397);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(127, 35);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(338, 474);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(147, 35);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar PDF";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // gbPais
            // 
            this.gbPais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(64)))));
            this.gbPais.Controls.Add(this.lblPoblacion);
            this.gbPais.Controls.Add(this.lblPaisSelecionado);
            this.gbPais.Controls.Add(this.lblTexto);
            this.gbPais.Controls.Add(this.pbPais);
            this.gbPais.Controls.Add(this.lblNo);
            this.gbPais.ForeColor = System.Drawing.Color.White;
            this.gbPais.Location = new System.Drawing.Point(529, 348);
            this.gbPais.Name = "gbPais";
            this.gbPais.Size = new System.Drawing.Size(425, 224);
            this.gbPais.TabIndex = 4;
            this.gbPais.TabStop = false;
            this.gbPais.Text = "País Seleccionado";
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoblacion.Location = new System.Drawing.Point(7, 143);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(0, 18);
            this.lblPoblacion.TabIndex = 4;
            // 
            // lblPaisSelecionado
            // 
            this.lblPaisSelecionado.AutoSize = true;
            this.lblPaisSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaisSelecionado.Location = new System.Drawing.Point(7, 49);
            this.lblPaisSelecionado.Name = "lblPaisSelecionado";
            this.lblPaisSelecionado.Size = new System.Drawing.Size(0, 18);
            this.lblPaisSelecionado.TabIndex = 3;
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(7, 109);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(88, 18);
            this.lblTexto.TabIndex = 2;
            this.lblTexto.Text = "Población:";
            // 
            // pbPais
            // 
            this.pbPais.Location = new System.Drawing.Point(210, 19);
            this.pbPais.Name = "pbPais";
            this.pbPais.Size = new System.Drawing.Size(209, 120);
            this.pbPais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPais.TabIndex = 1;
            this.pbPais.TabStop = false;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.Location = new System.Drawing.Point(7, 20);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(158, 18);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "País Seleccionado: ";
            // 
            // gbGrafica
            // 
            this.gbGrafica.BackColor = System.Drawing.Color.Transparent;
            this.gbGrafica.Controls.Add(this.pbGrafica);
            this.gbGrafica.ForeColor = System.Drawing.Color.White;
            this.gbGrafica.Location = new System.Drawing.Point(318, 28);
            this.gbGrafica.Name = "gbGrafica";
            this.gbGrafica.Size = new System.Drawing.Size(632, 314);
            this.gbGrafica.TabIndex = 5;
            this.gbGrafica.TabStop = false;
            this.gbGrafica.Text = "Grafica";
            // 
            // pbGrafica
            // 
            this.pbGrafica.Location = new System.Drawing.Point(7, 13);
            this.pbGrafica.Name = "pbGrafica";
            this.pbGrafica.Size = new System.Drawing.Size(619, 295);
            this.pbGrafica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGrafica.TabIndex = 0;
            this.pbGrafica.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(962, 584);
            this.Controls.Add(this.gbGrafica);
            this.Controls.Add(this.gbPais);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.tcPestañas);
            this.Controls.Add(this.varMenu);
            this.MainMenuStrip = this.varMenu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisador Léxico";
            this.varMenu.ResumeLayout(false);
            this.varMenu.PerformLayout();
            this.gbPais.ResumeLayout(false);
            this.gbPais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPais)).EndInit();
            this.gbGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip varMenu;
        private System.Windows.Forms.ToolStripMenuItem men1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.TabControl tcPestañas;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox gbPais;
        private System.Windows.Forms.GroupBox gbGrafica;
        private System.Windows.Forms.PictureBox pbGrafica;
        private System.Windows.Forms.PictureBox pbPais;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblPaisSelecionado;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblPoblacion;
    }
}

