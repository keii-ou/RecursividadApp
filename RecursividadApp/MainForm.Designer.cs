#nullable disable

namespace RecursividadApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            tabHanoi = new TabPage();
            picHanoi = new PictureBox();
            panelHanoiDerecha = new Panel();
            lstHanoiMovimientos = new ListBox();
            lblHanoiLista = new Label();
            lblHanoiInfo = new Label();
            panelHanoiSuperior = new Panel();
            lblDiscos = new Label();
            nudDiscos = new NumericUpDown();
            btnHanoiResolver = new Button();
            btnHanoiReiniciar = new Button();
            lblHanoiVelocidad = new Label();
            trackHanoiVelocidad = new TrackBar();
            tabLaberinto = new TabPage();
            picLaberinto = new PictureBox();
            lblLaberintoInfo = new Label();
            panelLaberintoSuperior = new Panel();
            lblFilas = new Label();
            nudFilas = new NumericUpDown();
            lblColumnas = new Label();
            nudColumnas = new NumericUpDown();
            btnLaberintoGenerar = new Button();
            btnLaberintoResolver = new Button();
            lblLaberintoVelocidad = new Label();
            trackLaberintoVelocidad = new TrackBar();
            tabAnalisis = new TabPage();
            dgvResultados = new DataGridView();
            colAlgoritmo = new DataGridViewTextBoxColumn();
            colN = new DataGridViewTextBoxColumn();
            colMsRecursivo = new DataGridViewTextBoxColumn();
            colMsIterativo = new DataGridViewTextBoxColumn();
            colLlamadas = new DataGridViewTextBoxColumn();
            colProfundidad = new DataGridViewTextBoxColumn();
            colCoincide = new DataGridViewTextBoxColumn();
            colObservacion = new DataGridViewTextBoxColumn();
            txtAnalisisNotas = new TextBox();
            panelAnalisisSuperior = new Panel();
            lblAlgoritmo = new Label();
            cmbAlgoritmo = new ComboBox();
            lblValores = new Label();
            txtValores = new TextBox();
            btnMedir = new Button();
            btnLimpiar = new Button();
            lblAnalisisEstado = new Label();
            timerHanoi = new System.Windows.Forms.Timer(components);
            timerLaberinto = new System.Windows.Forms.Timer(components);
            tabControl.SuspendLayout();
            tabHanoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHanoi).BeginInit();
            panelHanoiDerecha.SuspendLayout();
            panelHanoiSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackHanoiVelocidad).BeginInit();
            tabLaberinto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLaberinto).BeginInit();
            panelLaberintoSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFilas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudColumnas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackLaberintoVelocidad).BeginInit();
            tabAnalisis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            panelAnalisisSuperior.SuspendLayout();
            SuspendLayout();
            //
            // tabControl
            //
            tabControl.Controls.Add(tabHanoi);
            tabControl.Controls.Add(tabLaberinto);
            tabControl.Controls.Add(tabAnalisis);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1100, 720);
            tabControl.TabIndex = 0;
            //
            // tabHanoi
            //
            tabHanoi.Controls.Add(picHanoi);
            tabHanoi.Controls.Add(panelHanoiDerecha);
            tabHanoi.Controls.Add(lblHanoiInfo);
            tabHanoi.Controls.Add(panelHanoiSuperior);
            tabHanoi.Location = new Point(4, 24);
            tabHanoi.Name = "tabHanoi";
            tabHanoi.Padding = new Padding(6);
            tabHanoi.Size = new Size(1092, 692);
            tabHanoi.TabIndex = 0;
            tabHanoi.Text = "Torres de Hanoi";
            tabHanoi.UseVisualStyleBackColor = true;
            //
            // picHanoi
            //
            picHanoi.BackColor = Color.White;
            picHanoi.BorderStyle = BorderStyle.FixedSingle;
            picHanoi.Dock = DockStyle.Fill;
            picHanoi.Location = new Point(6, 62);
            picHanoi.Name = "picHanoi";
            picHanoi.Size = new Size(820, 564);
            picHanoi.TabIndex = 0;
            picHanoi.TabStop = false;
            picHanoi.Paint += picHanoi_Paint;
            picHanoi.Resize += picHanoi_Resize;
            //
            // panelHanoiDerecha
            //
            panelHanoiDerecha.Controls.Add(lstHanoiMovimientos);
            panelHanoiDerecha.Controls.Add(lblHanoiLista);
            panelHanoiDerecha.Dock = DockStyle.Right;
            panelHanoiDerecha.Location = new Point(826, 62);
            panelHanoiDerecha.Name = "panelHanoiDerecha";
            panelHanoiDerecha.Size = new Size(260, 564);
            panelHanoiDerecha.TabIndex = 1;
            //
            // lstHanoiMovimientos
            //
            lstHanoiMovimientos.Dock = DockStyle.Fill;
            lstHanoiMovimientos.FormattingEnabled = true;
            lstHanoiMovimientos.ItemHeight = 15;
            lstHanoiMovimientos.Location = new Point(0, 28);
            lstHanoiMovimientos.Name = "lstHanoiMovimientos";
            lstHanoiMovimientos.Size = new Size(260, 536);
            lstHanoiMovimientos.TabIndex = 1;
            //
            // lblHanoiLista
            //
            lblHanoiLista.Dock = DockStyle.Top;
            lblHanoiLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHanoiLista.Location = new Point(0, 0);
            lblHanoiLista.Name = "lblHanoiLista";
            lblHanoiLista.Size = new Size(260, 28);
            lblHanoiLista.TabIndex = 0;
            lblHanoiLista.Text = "Movimientos realizados";
            lblHanoiLista.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblHanoiInfo
            //
            lblHanoiInfo.Dock = DockStyle.Bottom;
            lblHanoiInfo.Location = new Point(6, 626);
            lblHanoiInfo.Name = "lblHanoiInfo";
            lblHanoiInfo.Size = new Size(1080, 60);
            lblHanoiInfo.TabIndex = 2;
            lblHanoiInfo.Text = "Elige el número de discos y pulsa \"Resolver y animar\".";
            lblHanoiInfo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelHanoiSuperior
            //
            panelHanoiSuperior.Controls.Add(lblDiscos);
            panelHanoiSuperior.Controls.Add(nudDiscos);
            panelHanoiSuperior.Controls.Add(btnHanoiResolver);
            panelHanoiSuperior.Controls.Add(btnHanoiReiniciar);
            panelHanoiSuperior.Controls.Add(lblHanoiVelocidad);
            panelHanoiSuperior.Controls.Add(trackHanoiVelocidad);
            panelHanoiSuperior.Dock = DockStyle.Top;
            panelHanoiSuperior.Location = new Point(6, 6);
            panelHanoiSuperior.Name = "panelHanoiSuperior";
            panelHanoiSuperior.Size = new Size(1080, 56);
            panelHanoiSuperior.TabIndex = 3;
            //
            // lblDiscos
            //
            lblDiscos.AutoSize = true;
            lblDiscos.Location = new Point(12, 19);
            lblDiscos.Name = "lblDiscos";
            lblDiscos.Size = new Size(46, 15);
            lblDiscos.TabIndex = 0;
            lblDiscos.Text = "Discos:";
            //
            // nudDiscos
            //
            nudDiscos.Location = new Point(70, 15);
            nudDiscos.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiscos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDiscos.Name = "nudDiscos";
            nudDiscos.Size = new Size(60, 23);
            nudDiscos.TabIndex = 1;
            nudDiscos.Value = new decimal(new int[] { 4, 0, 0, 0 });
            nudDiscos.ValueChanged += nudDiscos_ValueChanged;
            //
            // btnHanoiResolver
            //
            btnHanoiResolver.Location = new Point(150, 11);
            btnHanoiResolver.Name = "btnHanoiResolver";
            btnHanoiResolver.Size = new Size(150, 34);
            btnHanoiResolver.TabIndex = 2;
            btnHanoiResolver.Text = "Resolver y animar";
            btnHanoiResolver.UseVisualStyleBackColor = true;
            btnHanoiResolver.Click += btnHanoiResolver_Click;
            //
            // btnHanoiReiniciar
            //
            btnHanoiReiniciar.Location = new Point(310, 11);
            btnHanoiReiniciar.Name = "btnHanoiReiniciar";
            btnHanoiReiniciar.Size = new Size(110, 34);
            btnHanoiReiniciar.TabIndex = 3;
            btnHanoiReiniciar.Text = "Reiniciar";
            btnHanoiReiniciar.UseVisualStyleBackColor = true;
            btnHanoiReiniciar.Click += btnHanoiReiniciar_Click;
            //
            // lblHanoiVelocidad
            //
            lblHanoiVelocidad.AutoSize = true;
            lblHanoiVelocidad.Location = new Point(450, 19);
            lblHanoiVelocidad.Name = "lblHanoiVelocidad";
            lblHanoiVelocidad.Size = new Size(63, 15);
            lblHanoiVelocidad.TabIndex = 4;
            lblHanoiVelocidad.Text = "Velocidad:";
            //
            // trackHanoiVelocidad
            //
            trackHanoiVelocidad.Location = new Point(520, 8);
            trackHanoiVelocidad.Maximum = 10;
            trackHanoiVelocidad.Minimum = 1;
            trackHanoiVelocidad.Name = "trackHanoiVelocidad";
            trackHanoiVelocidad.Size = new Size(180, 45);
            trackHanoiVelocidad.TabIndex = 5;
            trackHanoiVelocidad.Value = 5;
            trackHanoiVelocidad.Scroll += trackHanoiVelocidad_Scroll;
            //
            // tabLaberinto
            //
            tabLaberinto.Controls.Add(picLaberinto);
            tabLaberinto.Controls.Add(lblLaberintoInfo);
            tabLaberinto.Controls.Add(panelLaberintoSuperior);
            tabLaberinto.Location = new Point(4, 24);
            tabLaberinto.Name = "tabLaberinto";
            tabLaberinto.Padding = new Padding(6);
            tabLaberinto.Size = new Size(1092, 692);
            tabLaberinto.TabIndex = 1;
            tabLaberinto.Text = "Laberinto (backtracking)";
            tabLaberinto.UseVisualStyleBackColor = true;
            //
            // picLaberinto
            //
            picLaberinto.BackColor = Color.White;
            picLaberinto.BorderStyle = BorderStyle.FixedSingle;
            picLaberinto.Dock = DockStyle.Fill;
            picLaberinto.Location = new Point(6, 62);
            picLaberinto.Name = "picLaberinto";
            picLaberinto.Size = new Size(1080, 564);
            picLaberinto.TabIndex = 0;
            picLaberinto.TabStop = false;
            picLaberinto.Paint += picLaberinto_Paint;
            picLaberinto.Resize += picLaberinto_Resize;
            //
            // lblLaberintoInfo
            //
            lblLaberintoInfo.Dock = DockStyle.Bottom;
            lblLaberintoInfo.Location = new Point(6, 626);
            lblLaberintoInfo.Name = "lblLaberintoInfo";
            lblLaberintoInfo.Size = new Size(1080, 60);
            lblLaberintoInfo.TabIndex = 1;
            lblLaberintoInfo.Text = "Genera un laberinto y pulsa \"Resolver (backtracking)\".";
            lblLaberintoInfo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelLaberintoSuperior
            //
            panelLaberintoSuperior.Controls.Add(lblFilas);
            panelLaberintoSuperior.Controls.Add(nudFilas);
            panelLaberintoSuperior.Controls.Add(lblColumnas);
            panelLaberintoSuperior.Controls.Add(nudColumnas);
            panelLaberintoSuperior.Controls.Add(btnLaberintoGenerar);
            panelLaberintoSuperior.Controls.Add(btnLaberintoResolver);
            panelLaberintoSuperior.Controls.Add(lblLaberintoVelocidad);
            panelLaberintoSuperior.Controls.Add(trackLaberintoVelocidad);
            panelLaberintoSuperior.Dock = DockStyle.Top;
            panelLaberintoSuperior.Location = new Point(6, 6);
            panelLaberintoSuperior.Name = "panelLaberintoSuperior";
            panelLaberintoSuperior.Size = new Size(1080, 56);
            panelLaberintoSuperior.TabIndex = 2;
            //
            // lblFilas
            //
            lblFilas.AutoSize = true;
            lblFilas.Location = new Point(12, 19);
            lblFilas.Name = "lblFilas";
            lblFilas.Size = new Size(34, 15);
            lblFilas.TabIndex = 0;
            lblFilas.Text = "Filas:";
            //
            // nudFilas
            //
            nudFilas.Location = new Point(60, 15);
            nudFilas.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            nudFilas.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudFilas.Name = "nudFilas";
            nudFilas.Size = new Size(60, 23);
            nudFilas.TabIndex = 1;
            nudFilas.Value = new decimal(new int[] { 15, 0, 0, 0 });
            //
            // lblColumnas
            //
            lblColumnas.AutoSize = true;
            lblColumnas.Location = new Point(140, 19);
            lblColumnas.Name = "lblColumnas";
            lblColumnas.Size = new Size(61, 15);
            lblColumnas.TabIndex = 2;
            lblColumnas.Text = "Columnas:";
            //
            // nudColumnas
            //
            nudColumnas.Location = new Point(210, 15);
            nudColumnas.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            nudColumnas.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudColumnas.Name = "nudColumnas";
            nudColumnas.Size = new Size(60, 23);
            nudColumnas.TabIndex = 3;
            nudColumnas.Value = new decimal(new int[] { 25, 0, 0, 0 });
            //
            // btnLaberintoGenerar
            //
            btnLaberintoGenerar.Location = new Point(300, 11);
            btnLaberintoGenerar.Name = "btnLaberintoGenerar";
            btnLaberintoGenerar.Size = new Size(150, 34);
            btnLaberintoGenerar.TabIndex = 4;
            btnLaberintoGenerar.Text = "Generar laberinto";
            btnLaberintoGenerar.UseVisualStyleBackColor = true;
            btnLaberintoGenerar.Click += btnLaberintoGenerar_Click;
            //
            // btnLaberintoResolver
            //
            btnLaberintoResolver.Location = new Point(460, 11);
            btnLaberintoResolver.Name = "btnLaberintoResolver";
            btnLaberintoResolver.Size = new Size(170, 34);
            btnLaberintoResolver.TabIndex = 5;
            btnLaberintoResolver.Text = "Resolver (backtracking)";
            btnLaberintoResolver.UseVisualStyleBackColor = true;
            btnLaberintoResolver.Click += btnLaberintoResolver_Click;
            //
            // lblLaberintoVelocidad
            //
            lblLaberintoVelocidad.AutoSize = true;
            lblLaberintoVelocidad.Location = new Point(660, 19);
            lblLaberintoVelocidad.Name = "lblLaberintoVelocidad";
            lblLaberintoVelocidad.Size = new Size(63, 15);
            lblLaberintoVelocidad.TabIndex = 6;
            lblLaberintoVelocidad.Text = "Velocidad:";
            //
            // trackLaberintoVelocidad
            //
            trackLaberintoVelocidad.Location = new Point(730, 8);
            trackLaberintoVelocidad.Maximum = 10;
            trackLaberintoVelocidad.Minimum = 1;
            trackLaberintoVelocidad.Name = "trackLaberintoVelocidad";
            trackLaberintoVelocidad.Size = new Size(180, 45);
            trackLaberintoVelocidad.TabIndex = 7;
            trackLaberintoVelocidad.Value = 4;
            //
            // tabAnalisis
            //
            tabAnalisis.Controls.Add(dgvResultados);
            tabAnalisis.Controls.Add(txtAnalisisNotas);
            tabAnalisis.Controls.Add(panelAnalisisSuperior);
            tabAnalisis.Location = new Point(4, 24);
            tabAnalisis.Name = "tabAnalisis";
            tabAnalisis.Padding = new Padding(6);
            tabAnalisis.Size = new Size(1092, 692);
            tabAnalisis.TabIndex = 2;
            tabAnalisis.Text = "Análisis de profundidad";
            tabAnalisis.UseVisualStyleBackColor = true;
            //
            // dgvResultados
            //
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.BackgroundColor = SystemColors.Window;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { colAlgoritmo, colN, colMsRecursivo, colMsIterativo, colLlamadas, colProfundidad, colCoincide, colObservacion });
            dgvResultados.Dock = DockStyle.Fill;
            dgvResultados.Location = new Point(6, 96);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.Size = new Size(1080, 470);
            dgvResultados.TabIndex = 0;
            //
            // colAlgoritmo
            //
            colAlgoritmo.HeaderText = "Algoritmo";
            colAlgoritmo.Name = "colAlgoritmo";
            colAlgoritmo.ReadOnly = true;
            colAlgoritmo.Width = 130;
            //
            // colN
            //
            colN.HeaderText = "n";
            colN.Name = "colN";
            colN.ReadOnly = true;
            colN.Width = 80;
            //
            // colMsRecursivo
            //
            colMsRecursivo.HeaderText = "Recursivo (ms)";
            colMsRecursivo.Name = "colMsRecursivo";
            colMsRecursivo.ReadOnly = true;
            colMsRecursivo.Width = 110;
            //
            // colMsIterativo
            //
            colMsIterativo.HeaderText = "Iterativo (ms)";
            colMsIterativo.Name = "colMsIterativo";
            colMsIterativo.ReadOnly = true;
            colMsIterativo.Width = 110;
            //
            // colLlamadas
            //
            colLlamadas.HeaderText = "Llamadas recursivas";
            colLlamadas.Name = "colLlamadas";
            colLlamadas.ReadOnly = true;
            colLlamadas.Width = 140;
            //
            // colProfundidad
            //
            colProfundidad.HeaderText = "Profundidad máx. de pila";
            colProfundidad.Name = "colProfundidad";
            colProfundidad.ReadOnly = true;
            colProfundidad.Width = 160;
            //
            // colCoincide
            //
            colCoincide.HeaderText = "Resultados iguales";
            colCoincide.Name = "colCoincide";
            colCoincide.ReadOnly = true;
            colCoincide.Width = 120;
            //
            // colObservacion
            //
            colObservacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colObservacion.HeaderText = "Observación";
            colObservacion.Name = "colObservacion";
            colObservacion.ReadOnly = true;
            //
            // txtAnalisisNotas
            //
            txtAnalisisNotas.Dock = DockStyle.Bottom;
            txtAnalisisNotas.Location = new Point(6, 566);
            txtAnalisisNotas.Multiline = true;
            txtAnalisisNotas.Name = "txtAnalisisNotas";
            txtAnalisisNotas.ReadOnly = true;
            txtAnalisisNotas.ScrollBars = ScrollBars.Vertical;
            txtAnalisisNotas.Size = new Size(1080, 120);
            txtAnalisisNotas.TabIndex = 1;
            txtAnalisisNotas.Text = "Cómo leer la tabla:\r\n" +
                "• \"Llamadas recursivas\" = cuántas veces se invocó la función. \"Profundidad máx. de pila\" = cuántos marcos (frames) estuvieron apilados a la vez.\r\n" +
                "• Factorial y Suma de arreglo: profundidad = n (una llamada pendiente por elemento). Con n muy grande el hilo principal (1 MB de pila) se desbordaría; por eso las mediciones corren en un hilo con 256 MB.\r\n" +
                "• Fibonacci ingenuo: pocas llamadas apiladas a la vez (profundidad n) pero un número exponencial de llamadas totales. Torres de Hanoi: 2^n - 1 llamadas, profundidad n.\r\n" +
                "• La primera medición incluye el tiempo de compilación JIT; repite la medición para valores más estables.";
            //
            // panelAnalisisSuperior
            //
            panelAnalisisSuperior.Controls.Add(lblAlgoritmo);
            panelAnalisisSuperior.Controls.Add(cmbAlgoritmo);
            panelAnalisisSuperior.Controls.Add(lblValores);
            panelAnalisisSuperior.Controls.Add(txtValores);
            panelAnalisisSuperior.Controls.Add(btnMedir);
            panelAnalisisSuperior.Controls.Add(btnLimpiar);
            panelAnalisisSuperior.Controls.Add(lblAnalisisEstado);
            panelAnalisisSuperior.Dock = DockStyle.Top;
            panelAnalisisSuperior.Location = new Point(6, 6);
            panelAnalisisSuperior.Name = "panelAnalisisSuperior";
            panelAnalisisSuperior.Size = new Size(1080, 90);
            panelAnalisisSuperior.TabIndex = 2;
            //
            // lblAlgoritmo
            //
            lblAlgoritmo.AutoSize = true;
            lblAlgoritmo.Location = new Point(12, 17);
            lblAlgoritmo.Name = "lblAlgoritmo";
            lblAlgoritmo.Size = new Size(62, 15);
            lblAlgoritmo.TabIndex = 0;
            lblAlgoritmo.Text = "Algoritmo:";
            //
            // cmbAlgoritmo
            //
            cmbAlgoritmo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgoritmo.FormattingEnabled = true;
            cmbAlgoritmo.Items.AddRange(new object[] { "Factorial", "Fibonacci", "Suma de arreglo", "Torres de Hanoi (conteo)" });
            cmbAlgoritmo.Location = new Point(90, 13);
            cmbAlgoritmo.Name = "cmbAlgoritmo";
            cmbAlgoritmo.Size = new Size(210, 23);
            cmbAlgoritmo.TabIndex = 1;
            cmbAlgoritmo.SelectedIndexChanged += cmbAlgoritmo_SelectedIndexChanged;
            //
            // lblValores
            //
            lblValores.AutoSize = true;
            lblValores.Location = new Point(330, 17);
            lblValores.Name = "lblValores";
            lblValores.Size = new Size(215, 15);
            lblValores.TabIndex = 2;
            lblValores.Text = "Valores de n / profundidad (con comas):";
            //
            // txtValores
            //
            txtValores.Location = new Point(555, 13);
            txtValores.Name = "txtValores";
            txtValores.Size = new Size(330, 23);
            txtValores.TabIndex = 3;
            //
            // btnMedir
            //
            btnMedir.Location = new Point(12, 48);
            btnMedir.Name = "btnMedir";
            btnMedir.Size = new Size(150, 32);
            btnMedir.TabIndex = 4;
            btnMedir.Text = "Medir";
            btnMedir.UseVisualStyleBackColor = true;
            btnMedir.Click += btnMedir_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(172, 48);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 32);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar tabla";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // lblAnalisisEstado
            //
            lblAnalisisEstado.AutoSize = true;
            lblAnalisisEstado.Location = new Point(300, 56);
            lblAnalisisEstado.Name = "lblAnalisisEstado";
            lblAnalisisEstado.Size = new Size(0, 15);
            lblAnalisisEstado.TabIndex = 6;
            //
            // timerHanoi
            //
            timerHanoi.Interval = 600;
            timerHanoi.Tick += timerHanoi_Tick;
            //
            // timerLaberinto
            //
            timerLaberinto.Interval = 30;
            timerLaberinto.Tick += timerLaberinto_Tick;
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 720);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MainForm_Load;
            tabControl.ResumeLayout(false);
            tabHanoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picHanoi).EndInit();
            panelHanoiDerecha.ResumeLayout(false);
            panelHanoiSuperior.ResumeLayout(false);
            panelHanoiSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiscos).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackHanoiVelocidad).EndInit();
            tabLaberinto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLaberinto).EndInit();
            panelLaberintoSuperior.ResumeLayout(false);
            panelLaberintoSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFilas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudColumnas).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackLaberintoVelocidad).EndInit();
            tabAnalisis.ResumeLayout(false);
            tabAnalisis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            panelAnalisisSuperior.ResumeLayout(false);
            panelAnalisisSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabHanoi;
        private TabPage tabLaberinto;
        private TabPage tabAnalisis;

        // Hanoi
        private PictureBox picHanoi;
        private Panel panelHanoiDerecha;
        private ListBox lstHanoiMovimientos;
        private Label lblHanoiLista;
        private Label lblHanoiInfo;
        private Panel panelHanoiSuperior;
        private Label lblDiscos;
        private NumericUpDown nudDiscos;
        private Button btnHanoiResolver;
        private Button btnHanoiReiniciar;
        private Label lblHanoiVelocidad;
        private TrackBar trackHanoiVelocidad;

        // Laberinto
        private PictureBox picLaberinto;
        private Label lblLaberintoInfo;
        private Panel panelLaberintoSuperior;
        private Label lblFilas;
        private NumericUpDown nudFilas;
        private Label lblColumnas;
        private NumericUpDown nudColumnas;
        private Button btnLaberintoGenerar;
        private Button btnLaberintoResolver;
        private Label lblLaberintoVelocidad;
        private TrackBar trackLaberintoVelocidad;

        // Análisis
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn colAlgoritmo;
        private DataGridViewTextBoxColumn colN;
        private DataGridViewTextBoxColumn colMsRecursivo;
        private DataGridViewTextBoxColumn colMsIterativo;
        private DataGridViewTextBoxColumn colLlamadas;
        private DataGridViewTextBoxColumn colProfundidad;
        private DataGridViewTextBoxColumn colCoincide;
        private DataGridViewTextBoxColumn colObservacion;
        private TextBox txtAnalisisNotas;
        private Panel panelAnalisisSuperior;
        private Label lblAlgoritmo;
        private ComboBox cmbAlgoritmo;
        private Label lblValores;
        private TextBox txtValores;
        private Button btnMedir;
        private Button btnLimpiar;
        private Label lblAnalisisEstado;

        private System.Windows.Forms.Timer timerHanoi;
        private System.Windows.Forms.Timer timerLaberinto;
    }
}
