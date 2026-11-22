using System.Diagnostics;
using System.Numerics;

namespace RecursividadApp.Logic;

public sealed record ResultadoMedicion(
    string Algoritmo,
    int N,
    double MsRecursivo,
    double MsIterativo,
    long Llamadas,
    int ProfundidadMaxima,
    bool Coincide,
    string Observacion);

/// Versiones recursivas e iterativas de varios algoritmos, instrumentadas para medir
/// número de llamadas y profundidad máxima de la pila de llamadas.

public static class Algoritmos
{
    public static long Llamadas;
    public static int ProfundidadMaxima;

    private static void Reiniciar()
    {
        Llamadas = 0;
        ProfundidadMaxima = 0;
    }

    private static void Entrar(int profundidad)
    {
        Llamadas++;
        if (profundidad > ProfundidadMaxima)
            ProfundidadMaxima = profundidad;
    }

    // --- Factorial

    public static BigInteger FactorialRec(int n, int profundidad = 1)
    {
        Entrar(profundidad);
        if (n <= 1) return BigInteger.One;                     // caso base
        return n * FactorialRec(n - 1, profundidad + 1);       // caso recursivo
    }

    public static BigInteger FactorialIter(int n)
    {
        BigInteger r = BigInteger.One;
        for (int i = 2; i <= n; i++) r *= i;
        return r;
    }

    // --- Fibonacci

    public static long FibRec(int n, int profundidad = 1)
    {
        Entrar(profundidad);
        if (n < 2) return n;                                                  // casos base
        return FibRec(n - 1, profundidad + 1) + FibRec(n - 2, profundidad + 1); // caso recursivo
    }

    public static long FibIter(int n)
    {
        long a = 0, b = 1;
        for (int i = 0; i < n; i++)
        {
            long t = a + b;
            a = b;
            b = t;
        }
        return a;
    }

    // --- Suma de arreglo

    public static long SumaRec(int[] datos, int indice, int profundidad = 1)
    {
        Entrar(profundidad);
        if (indice == datos.Length) return 0;                                  // caso base
        return datos[indice] + SumaRec(datos, indice + 1, profundidad + 1);   // caso recursivo
    }

    public static long SumaIter(int[] datos)
    {
        long s = 0;
        foreach (int x in datos) s += x;
        return s;
    }

    // --- Torres de Hanoi (conteo de movimientos)

    public static long HanoiRec(int n, int profundidad = 1)
    {
        Entrar(profundidad);
        if (n == 1) return 1;                                                         // caso base
        return HanoiRec(n - 1, profundidad + 1) + 1 + HanoiRec(n - 1, profundidad + 1); // caso recursivo
    }

    //Versión iterativa con pila explícita (se reemplaza la pila de llamadas por un Stack propio).
    public static long HanoiIter(int n)
    {
        long movimientos = 0;
        var pila = new Stack<int>();
        pila.Push(n);
        while (pila.Count > 0)
        {
            int k = pila.Pop();
            movimientos++;
            if (k > 1)
            {
                pila.Push(k - 1);
                pila.Push(k - 1);
            }
        }
        return movimientos;
    }

    // --- Medición

    public static ResultadoMedicion Medir(string algoritmo, int n)
    {
        if (algoritmo.StartsWith("Factorial"))
        {
            Validar(n, 1, 20000);
            return Comparar("Factorial", n,
                () => FactorialRec(n), () => FactorialIter(n),
                "Profundidad lineal: n llamadas apiladas.");
        }

        if (algoritmo.StartsWith("Fibonacci"))
        {
            Validar(n, 0, 40);
            return Comparar("Fibonacci", n,
                () => FibRec(n), () => FibIter(n),
                "Recursión ingenua: llamadas exponenciales, pila poco profunda.");
        }

        if (algoritmo.StartsWith("Suma"))
        {
            Validar(n, 1, 500000);
            int[] datos = Enumerable.Range(1, n).ToArray();
            return Comparar("Suma de arreglo", n,
                () => SumaRec(datos, 0), () => SumaIter(datos),
                "Profundidad lineal: n + 1 marcos de pila.");
        }

        if (algoritmo.StartsWith("Torres"))
        {
            Validar(n, 1, 25);
            return Comparar("Torres de Hanoi", n,
                () => HanoiRec(n), () => HanoiIter(n),
                "2^n - 1 movimientos; profundidad solo n.");
        }

        throw new ArgumentException("Algoritmo no reconocido.");
    }

    private static void Validar(int n, int min, int max)
    {
        if (n < min || n > max)
            throw new ArgumentException($"Fuera de rango (válido: {min:N0} a {max:N0}).");
    }

    private static ResultadoMedicion Comparar<T>(string nombre, int n, Func<T> recursivo, Func<T> iterativo, string observacion)
    {
        Reiniciar();
        var reloj = Stopwatch.StartNew();
        T r1 = recursivo();
        reloj.Stop();
        double msRec = reloj.Elapsed.TotalMilliseconds;
        long llamadas = Llamadas;
        int profundidad = ProfundidadMaxima;

        reloj.Restart();
        T r2 = iterativo();
        reloj.Stop();
        double msIter = reloj.Elapsed.TotalMilliseconds;

        bool coincide = EqualityComparer<T>.Default.Equals(r1, r2);
        return new ResultadoMedicion(nombre, n, msRec, msIter, llamadas, profundidad, coincide, observacion);
    }

 
    // Ejecuta el trabajo en un hilo con pila de 256 MB. El hilo principal de Windows solo tiene 1 MB, y en .NET un
    // StackOverflowException no se puede capturar: terminaría el proceso. Por eso las pruebas profundas usan este hilo.

    public static Task<T> EjecutarConPilaGrande<T>(Func<T> trabajo)
    {
        var tcs = new TaskCompletionSource<T>();
        var hilo = new Thread(() =>
        {
            try { tcs.SetResult(trabajo()); }
            catch (Exception ex) { tcs.SetException(ex); }
        }, 256 * 1024 * 1024)
        {
            IsBackground = true
        };
        hilo.Start();
        return tcs.Task;
    }
}
