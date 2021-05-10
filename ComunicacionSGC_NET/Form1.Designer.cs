namespace ComunicacionSGC_NET
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbComunicar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timerProceso = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ndw2 = new System.Windows.Forms.NumericUpDown();
            this.nd1 = new System.Windows.Forms.NumericUpDown();
            this.lbComunicadas = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pendComunicarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicadasTool = new System.Windows.Forms.ToolStripMenuItem();
            this.conErrorTool = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ndw2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nd1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiempo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Retraso";
            // 
            // lbComunicar
            // 
            this.lbComunicar.BackColor = System.Drawing.Color.Black;
            this.lbComunicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComunicar.ForeColor = System.Drawing.Color.White;
            this.lbComunicar.Location = new System.Drawing.Point(150, 69);
            this.lbComunicar.Name = "lbComunicar";
            this.lbComunicar.Size = new System.Drawing.Size(78, 30);
            this.lbComunicar.TabIndex = 2;
            this.lbComunicar.Text = "0";
            this.lbComunicar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "A Comunicar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Error";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "Comunicadas";
            // 
            // timerProceso
            // 
            this.timerProceso.Interval = 1000;
            this.timerProceso.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "PLAY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(257, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 124);
            this.button1.TabIndex = 12;
            this.button1.Text = "PLAY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ndw2
            // 
            this.ndw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ndw2.Location = new System.Drawing.Point(328, 17);
            this.ndw2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ndw2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndw2.Name = "ndw2";
            this.ndw2.Size = new System.Drawing.Size(54, 29);
            this.ndw2.TabIndex = 11;
            this.ndw2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndw2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ndw2.ValueChanged += new System.EventHandler(this.ndw2_ValueChanged);
            // 
            // nd1
            // 
            this.nd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nd1.Location = new System.Drawing.Point(99, 16);
            this.nd1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nd1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nd1.Name = "nd1";
            this.nd1.Size = new System.Drawing.Size(54, 29);
            this.nd1.TabIndex = 10;
            this.nd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nd1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbComunicadas
            // 
            this.lbComunicadas.BackColor = System.Drawing.Color.Black;
            this.lbComunicadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComunicadas.ForeColor = System.Drawing.Color.White;
            this.lbComunicadas.Location = new System.Drawing.Point(150, 163);
            this.lbComunicadas.Name = "lbComunicadas";
            this.lbComunicadas.Size = new System.Drawing.Size(78, 30);
            this.lbComunicadas.TabIndex = 9;
            this.lbComunicadas.Text = "0";
            this.lbComunicadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbError
            // 
            this.lbError.BackColor = System.Drawing.Color.Black;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.White;
            this.lbError.Location = new System.Drawing.Point(150, 117);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(78, 30);
            this.lbError.TabIndex = 8;
            this.lbError.Text = "0";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "COMUNICADOR DE TAREAS";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendComunicarTool,
            this.comunicadasTool,
            this.conErrorTool});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 70);
            // 
            // pendComunicarTool
            // 
            this.pendComunicarTool.Name = "pendComunicarTool";
            this.pendComunicarTool.Size = new System.Drawing.Size(163, 22);
            this.pendComunicarTool.Text = "Pend Comunicar";
            // 
            // comunicadasTool
            // 
            this.comunicadasTool.Name = "comunicadasTool";
            this.comunicadasTool.Size = new System.Drawing.Size(163, 22);
            this.comunicadasTool.Text = "Comunicadas";
            // 
            // conErrorTool
            // 
            this.conErrorTool.Name = "conErrorTool";
            this.conErrorTool.Size = new System.Drawing.Size(163, 22);
            this.conErrorTool.Text = "Con Error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(425, 221);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nd1);
            this.Controls.Add(this.ndw2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbComunicadas);
            this.Controls.Add(this.lbComunicar);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SERVICIO DE COMUNICACION ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ndw2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nd1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbComunicar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerProceso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown ndw2;
        private System.Windows.Forms.NumericUpDown nd1;
        private System.Windows.Forms.Label lbComunicadas;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pendComunicarTool;
        private System.Windows.Forms.ToolStripMenuItem comunicadasTool;
        private System.Windows.Forms.ToolStripMenuItem conErrorTool;
    }
}

