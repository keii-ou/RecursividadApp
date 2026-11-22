namespace RecursividadApp.Logic;

//Un movimiento de disco: número de disco (1 = el más pequeño) y torres origen/destino (0, 1, 2).
public readonly record struct MovimientoHanoi(int Disco, int Origen, int Destino);


// Resuelve las Torres de Hanoi de forma recursiva.
// Caso base:     n == 1  -> mover el disco directamente.
// Caso recursivo: mover n-1 discos a la torre auxiliar, mover el disco n, mover n-1 discos al destino.

public class HanoiSolver
{
    public List<MovimientoHanoi> Movimientos { get; } = new();
    public long Llamadas { get; private set; }
    public int ProfundidadMaxima { get; private set; }

    public void Resolver(int discos)
    {
        Movimientos.Clear();
        Llamadas = 0;
        ProfundidadMaxima = 0;
        Mover(discos, origen: 0, destino: 2, auxiliar: 1, profundidad: 1);
    }

    private void Mover(int n, int origen, int destino, int auxiliar, int profundidad)
    {
        Llamadas++;
        if (profundidad > ProfundidadMaxima)
            ProfundidadMaxima = profundidad;

        // CASO BASE: un solo disco, se mueve directamente.
        if (n == 1)
        {
            Movimientos.Add(new MovimientoHanoi(1, origen, destino));
            return;
        }

        // CASO RECURSIVO
        Mover(n - 1, origen, auxiliar, destino, profundidad + 1);   // 1) n-1 discos a la torre auxiliar
        Movimientos.Add(new MovimientoHanoi(n, origen, destino));   // 2) el disco más grande al destino
        Mover(n - 1, auxiliar, destino, origen, profundidad + 1);   // 3) n-1 discos sobre el disco grande
    }
}
