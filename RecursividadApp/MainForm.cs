using System.Drawing.Drawing2D;
using RecursividadApp.Logic;

namespace RecursividadApp;

public partial class MainForm : Form
{
    // --- Estado: Hanoi
    private readonly HanoiSolver _hanoi = new();
    private readonly List<int>[] _torres = { new(), new(), new() };
    private int _hanoiDiscos = 4;
    private int _hanoiIndice;
    private string _hanoiResumen = "";
    private static readonly string[] NombreTorre = { "A", "B", "C" };

    // --- Estado: Laberinto
    private Laberinto? _lab;
    private byte[,]? _estado;          // 0 = sin visitar, 1 = en la pila de llamadas, 2 = descartada (backtracking)
    private int _pasoIndice;
    private bool _mostrarCamino;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        cmbAlgoritmo.SelectedIndex = 0;
        ReiniciarHanoi();
        GenerarLaberinto();
    }

    //  TORRES DE HANOI
  

    private void ReiniciarHanoi()
    {
        timerHanoi.Stop();
        _hanoiDiscos = (int)nudDiscos.Value;
        _hanoiIndice = 0;
        foreach (var t in _torres) t.Clear();
        for (int k = _hanoiDiscos; k >= 1; k--) _torres[0].Add(k);

        lstHanoiMovimientos.Items.Clear();
        _hanoiResumen = "";
        lblHanoiInfo.Text = $"{_hanoiDiscos} discos. Pulsa \"Resolver y animar\" para ver la recursión en acción.";
        picHanoi.Invalidate();
    }

    private void nudDiscos_ValueChanged(object? sender, EventArgs e) => ReiniciarHanoi();

    private void btnHanoiReiniciar_Click(object? sender, EventArgs e) => ReiniciarHanoi();

    private void btnHanoiResolver_Click(object? sender, EventArgs e)
    {
        ReiniciarHanoi();
        _hanoi.Resolver(_hanoiDiscos);

        _hanoiResumen =
            $"n = {_hanoiDiscos} discos · Movimientos = 2ⁿ − 1 = {_hanoi.Movimientos.Count:N0} · " +
            $"Llamadas recursivas = {_hanoi.Llamadas:N0} · Profundidad máxima de la pila = {_hanoi.ProfundidadMaxima}";
        lblHanoiInfo.Text = _hanoiResumen;

        timerHanoi.Interval = IntervaloHanoi();
        timerHanoi.Start();
    }

    private void trackHanoiVelocidad_Scroll(object? sender, EventArgs e)
    {
        timerHanoi.Interval = IntervaloHanoi();
    }

    private int IntervaloHanoi() => 1100 - trackHanoiVelocidad.Value * 100;   // 1000 ms ... 100 ms

    private void timerHanoi_Tick(object? sender, EventArgs e)
    {
        if (_hanoiIndice >= _hanoi.Movimientos.Count)
        {
            timerHanoi.Stop();
            lblHanoiInfo.Text = _hanoiResumen + "\nSolución completa.";
            return;
        }

        MovimientoHanoi m = _hanoi.Movimientos[_hanoiIndice];
        List<int> origen = _torres[m.Origen];
        origen.RemoveAt(origen.Count - 1);
        _torres[m.Destino].Add(m.Disco);

        _hanoiIndice++;
        lstHanoiMovimientos.Items.Add($"{_hanoiIndice}. Disco {m.Disco}: {NombreTorre[m.Origen]} → {NombreTorre[m.Destino]}");
        lstHanoiMovimientos.TopIndex = Math.Max(0, lstHanoiMovimientos.Items.Count - 1);
        lblHanoiInfo.Text = _hanoiResumen + $"\nProgreso: {_hanoiIndice} de {_hanoi.Movimientos.Count}";
        picHanoi.Invalidate();
    }

    private void picHanoi_Resize(object? sender, EventArgs e) => picHanoi.Invalidate();

    private void picHanoi_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        int w = picHanoi.ClientSize.Width;
        int h = picHanoi.ClientSize.Height;
        int n = Math.Max(1, _hanoiDiscos);

        int baseY = h - 50;
        int colW = w / 3;
        int altoDisco = Math.Clamp((baseY - 80) / (n + 1), 12, 30);
        int altoPoste = altoDisco * (n + 1) + 10;

        using var brochaBase = new SolidBrush(Color.FromArgb(90, 70, 50));
        using var fuente = new Font("Segoe UI", 12F, FontStyle.Bold);

        for (int i = 0; i < 3; i++)
        {
            int cx = colW * i + colW / 2;

            g.FillRectangle(brochaBase, colW * i + 10, baseY, colW - 20, 10);
            g.FillRectangle(brochaBase, cx - 4, baseY - altoPoste, 8, altoPoste);

            string nombre = NombreTorre[i];
            SizeF tam = g.MeasureString(nombre, fuente);
            g.DrawString(nombre, fuente, Brushes.Black, cx - tam.Width / 2, baseY + 16);

            for (int j = 0; j < _torres[i].Count; j++)
            {
                int k = _torres[i][j];
                int ancho = 40 + (colW - 60) * k / n;
                int y = baseY - (j + 1) * altoDisco;
                var rect = new Rectangle(cx - ancho / 2, y, ancho, altoDisco - 2);

                using var brocha = new SolidBrush(ColorDisco(k, n));
                g.FillRectangle(brocha, rect);
                g.DrawRectangle(Pens.DimGray, rect);
            }
        }
    }

    private static Color ColorDisco(int k, int n)
    {
        double matiz = 210.0 - 180.0 * (k - 1) / Math.Max(1, n - 1);
        return DesdeHsv(matiz, 0.65, 0.92);
    }

    private static Color DesdeHsv(double h, double s, double v)
    {
        int hi = (int)(h / 60) % 6;
        double f = h / 60 - Math.Floor(h / 60);
        double p = v * (1 - s), q = v * (1 - f * s), t = v * (1 - (1 - f) * s);
        (double r, double g, double b) = hi switch
        {
            0 => (v, t, p),
            1 => (q, v, p),
            2 => (p, v, t),
            3 => (p, q, v),
            4 => (t, p, v),
            _ => (v, p, q)
        };
        return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
    }

   
    //  LABERINTO

    private void GenerarLaberinto()
    {
        timerLaberinto.Stop();
        int filas = (int)nudFilas.Value;
        int columnas = (int)nudColumnas.Value;

        _lab = new Laberinto(filas, columnas);
        _lab.Generar();
        _estado = new byte[filas, columnas];
        _pasoIndice = 0;
        _mostrarCamino = false;

        lblLaberintoInfo.Text = $"Laberinto {filas} × {columnas} generado recursivamente (DFS). Pulsa \"Resolver (backtracking)\".";
        picLaberinto.Invalidate();
    }

    private void btnLaberintoGenerar_Click(object? sender, EventArgs e) => GenerarLaberinto();

    private void btnLaberintoResolver_Click(object? sender, EventArgs e)
    {
        if (_lab == null) GenerarLaberinto();
        if (_lab == null) return;

        timerLaberinto.Stop();
        _estado = new byte[_lab.Filas, _lab.Columnas];
        _pasoIndice = 0;
        _mostrarCamino = false;

        var reloj = System.Diagnostics.Stopwatch.StartNew();
        bool exito = _lab.Resolver();
        reloj.Stop();

        lblLaberintoInfo.Text =
            (exito ? "Salida encontrada. " : "Sin solución. ") +
            $"Celdas visitadas: {_lab.CeldasVisitadas:N0} · Retrocesos (backtracking): {_lab.Retrocesos:N0} · " +
            $"Longitud del camino: {_lab.LongitudCamino:N0} · Llamadas recursivas: {_lab.Llamadas:N0}\n" +
            $"Profundidad máxima de recursión: {_lab.ProfundidadMaxima:N0} · Tiempo de cómputo: {reloj.Elapsed.TotalMilliseconds:F3} ms " +
            "(azul = en la pila de llamadas, rosa = callejón descartado, verde = camino final)";

        timerLaberinto.Start();
    }

    private void timerLaberinto_Tick(object? sender, EventArgs e)
    {
        if (_lab == null || _estado == null)
        {
            timerLaberinto.Stop();
            return;
        }

        int pasosPorTick = trackLaberintoVelocidad.Value * trackLaberintoVelocidad.Value;   // 1 ... 100
        for (int i = 0; i < pasosPorTick && _pasoIndice < _lab.Pasos.Count; i++)
        {
            Paso p = _lab.Pasos[_pasoIndice++];
            _estado[p.Fila, p.Columna] = p.Tipo == TipoPaso.Entrar ? (byte)1 : (byte)2;
        }

        if (_pasoIndice >= _lab.Pasos.Count)
        {
            timerLaberinto.Stop();
            _mostrarCamino = true;
        }
        picLaberinto.Invalidate();
    }

    private void picLaberinto_Resize(object? sender, EventArgs e) => picLaberinto.Invalidate();

    private void picLaberinto_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);
        if (_lab == null || _estado == null) return;

        int margen = 12;
        int tam = Math.Min((picLaberinto.ClientSize.Width - 2 * margen) / _lab.Columnas,
                           (picLaberinto.ClientSize.Height - 2 * margen) / _lab.Filas);
        if (tam < 4) return;

        int x0 = (picLaberinto.ClientSize.Width - tam * _lab.Columnas) / 2;
        int y0 = (picLaberinto.ClientSize.Height - tam * _lab.Filas) / 2;

        using var azul = new SolidBrush(Color.FromArgb(150, 200, 245));
        using var rosa = new SolidBrush(Color.FromArgb(248, 190, 200));
        using var verde = new SolidBrush(Color.FromArgb(110, 205, 120));
        using var inicio = new SolidBrush(Color.FromArgb(60, 160, 80));
        using var fin = new SolidBrush(Color.FromArgb(240, 190, 50));
        using var pared = new Pen(Color.FromArgb(40, 40, 40), 2f);

        for (int f = 0; f < _lab.Filas; f++)
        {
            for (int c = 0; c < _lab.Columnas; c++)
            {
                var rect = new Rectangle(x0 + c * tam, y0 + f * tam, tam, tam);

                if (_mostrarCamino && _lab.EnCamino[f, c]) g.FillRectangle(verde, rect);
                else if (_estado[f, c] == 1) g.FillRectangle(azul, rect);
                else if (_estado[f, c] == 2) g.FillRectangle(rosa, rect);
            }
        }

        g.FillRectangle(inicio, x0 + 3, y0 + 3, tam - 6, tam - 6);
        g.FillRectangle(fin, x0 + (_lab.Columnas - 1) * tam + 3, y0 + (_lab.Filas - 1) * tam + 3, tam - 6, tam - 6);

        for (int f = 0; f < _lab.Filas; f++)
        {
            for (int c = 0; c < _lab.Columnas; c++)
            {
                int x = x0 + c * tam;
                int y = y0 + f * tam;
                Pared p = _lab.Celdas[f, c];

                if ((p & Pared.Norte) != 0) g.DrawLine(pared, x, y, x + tam, y);
                if ((p & Pared.Este) != 0) g.DrawLine(pared, x + tam, y, x + tam, y + tam);
                if ((p & Pared.Sur) != 0) g.DrawLine(pared, x, y + tam, x + tam, y + tam);
                if ((p & Pared.Oeste) != 0) g.DrawLine(pared, x, y, x, y + tam);
            }
        }
    }

    //  ANÁLISIS DE PROFUNDIDAD

    private void cmbAlgoritmo_SelectedIndexChanged(object? sender, EventArgs e)
    {
        txtValores.Text = cmbAlgoritmo.SelectedIndex switch
        {
            0 => "10, 100, 1000, 5000, 10000",
            1 => "10, 20, 30, 35, 40",
            2 => "100, 1000, 10000, 100000, 500000",
            _ => "5, 10, 15, 20, 24"
        };
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        dgvResultados.Rows.Clear();
        lblAnalisisEstado.Text = "";
    }

    private async void btnMedir_Click(object? sender, EventArgs e)
    {
        string algoritmo = cmbAlgoritmo.SelectedItem?.ToString() ?? "Factorial";
        List<int> valores = LeerValores(txtValores.Text);
        if (valores.Count == 0)
        {
            MessageBox.Show("Escribe al menos un número entero (por ejemplo: 10, 100, 1000).",
                "Valores no válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnMedir.Enabled = false;
        btnLimpiar.Enabled = false;
        try
        {
            foreach (int n in valores)
            {
                lblAnalisisEstado.Text = $"Midiendo {algoritmo} con n = {n:N0} ...";
                try
                {
                    ResultadoMedicion r = await Algoritmos.EjecutarConPilaGrande(() => Algoritmos.Medir(algoritmo, n));
                    dgvResultados.Rows.Add(
                        r.Algoritmo,
                        r.N.ToString("N0"),
                        r.MsRecursivo.ToString("F3"),
                        r.MsIterativo.ToString("F3"),
                        r.Llamadas.ToString("N0"),
                        r.ProfundidadMaxima.ToString("N0"),
                        r.Coincide ? "Sí" : "No",
                        r.Observacion);
                }
                catch (ArgumentException ex)
                {
                    dgvResultados.Rows.Add(algoritmo, n.ToString("N0"), "—", "—", "—", "—", "—", ex.Message);
                }
            }
            lblAnalisisEstado.Text = "Medición terminada.";
        }
        finally
        {
            btnMedir.Enabled = true;
            btnLimpiar.Enabled = true;
        }
    }

    private static List<int> LeerValores(string texto)
    {
        var lista = new List<int>();
        foreach (string parte in texto.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(parte.Trim(), out int v))
                lista.Add(v);
        }
        return lista;
    }
}
