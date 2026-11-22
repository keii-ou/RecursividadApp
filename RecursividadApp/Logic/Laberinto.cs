namespace RecursividadApp.Logic;

[Flags]
public enum Pared : byte
{
    Ninguna = 0,
    Norte = 1,
    Este = 2,
    Sur = 4,
    Oeste = 8
}

public enum TipoPaso
{
    Entrar,      // la recursión entra a una celda (nueva llamada)
    Retroceder   // la celda no llevó a la salida (backtracking: se regresa de la llamada)
}

public readonly record struct Paso(int Fila, int Columna, TipoPaso Tipo);


/// Laberinto perfecto (sin ciclos). Se genera con DFS recursivo y se resuelve con backtracking recursivo.
/// Entrada: esquina superior izquierda. Salida: esquina inferior derecha.

public class Laberinto
{
    private static readonly int[] DF = { -1, 0, 1, 0 };                       // Norte, Este, Sur, Oeste
    private static readonly int[] DC = { 0, 1, 0, -1 };
    private static readonly Pared[] Banderas = { Pared.Norte, Pared.Este, Pared.Sur, Pared.Oeste };

    private readonly Random _azar = new();

    public int Filas { get; }
    public int Columnas { get; }
    public Pared[,] Celdas { get; }

    // Resultados de la resolución
    public List<Paso> Pasos { get; } = new();
    public bool[,] EnCamino { get; private set; }
    public long Llamadas { get; private set; }
    public int Retrocesos { get; private set; }
    public int ProfundidadMaxima { get; private set; }
    public int LongitudCamino { get; private set; }
    public int CeldasVisitadas { get; private set; }

    public Laberinto(int filas, int columnas)
    {
        Filas = filas;
        Columnas = columnas;
        Celdas = new Pared[filas, columnas];
        EnCamino = new bool[filas, columnas];
        for (int f = 0; f < filas; f++)
            for (int c = 0; c < columnas; c++)
                Celdas[f, c] = Pared.Norte | Pared.Este | Pared.Sur | Pared.Oeste;
    }

    // --- Generación

    public void Generar()
    {
        var visitado = new bool[Filas, Columnas];
        Tallar(0, 0, visitado);
    }

    // Recursión: derriba el muro hacia un vecino no visitado y se llama sobre él.
    private void Tallar(int f, int c, bool[,] visitado)
    {
        visitado[f, c] = true;
        int[] orden = Enumerable.Range(0, 4).OrderBy(_ => _azar.Next()).ToArray();

        foreach (int d in orden)
        {
            int nf = f + DF[d];
            int nc = c + DC[d];
            if (nf < 0 || nc < 0 || nf >= Filas || nc >= Columnas || visitado[nf, nc])
                continue;

            Celdas[f, c] &= ~Banderas[d];
            Celdas[nf, nc] &= ~Banderas[(d + 2) % 4];
            Tallar(nf, nc, visitado);
        }
        // CASO BASE implícito: sin vecinos sin visitar, la función termina y regresa.
    }

    // --- Resolución

    public bool Resolver()
    {
        Pasos.Clear();
        EnCamino = new bool[Filas, Columnas];
        Llamadas = 0;
        Retrocesos = 0;
        ProfundidadMaxima = 0;
        LongitudCamino = 0;

        var visitado = new bool[Filas, Columnas];
        bool exito = Buscar(0, 0, 1, visitado);
        CeldasVisitadas = Pasos.Count(p => p.Tipo == TipoPaso.Entrar);
        return exito;
    }

    private bool Buscar(int f, int c, int profundidad, bool[,] visitado)
    {
        Llamadas++;
        if (profundidad > ProfundidadMaxima)
            ProfundidadMaxima = profundidad;

        visitado[f, c] = true;
        Pasos.Add(new Paso(f, c, TipoPaso.Entrar));

        // CASO BASE 1 (éxito): se llegó a la salida.
        if (f == Filas - 1 && c == Columnas - 1)
        {
            EnCamino[f, c] = true;
            LongitudCamino++;
            return true;
        }

        // CASO RECURSIVO: probar cada dirección abierta y no visitada.
        for (int d = 0; d < 4; d++)
        {
            if ((Celdas[f, c] & Banderas[d]) != 0)
                continue;                       // hay muro

            int nf = f + DF[d];
            int nc = c + DC[d];
            if (nf < 0 || nc < 0 || nf >= Filas || nc >= Columnas || visitado[nf, nc])
                continue;

            if (Buscar(nf, nc, profundidad + 1, visitado))
            {
                EnCamino[f, c] = true;          // esta celda forma parte de la solución
                LongitudCamino++;
                return true;
            }
        }

        // CASO BASE 2 (fracaso): ninguna dirección funcionó -> BACKTRACKING.
        Pasos.Add(new Paso(f, c, TipoPaso.Retroceder));
        Retrocesos++;
        return false;
    }
}
