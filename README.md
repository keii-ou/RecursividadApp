# Unidad 2 · Recursividad — Tarea 2.3

Aplicación Windows Forms (C#, .NET 10) que implementa casos recursivos y mide su comportamiento.

## Cómo abrirla
1. Instala Visual Studio con la carga de trabajo **"Desarrollo de escritorio con .NET"** y el SDK de **.NET 10**.
2. Abre `RecursividadApp.sln`.
3. Pulsa **F5** para ejecutar. Para ver/editar la interfaz: doble clic en `MainForm.cs` (abre el **diseñador**).

## Estructura
| Archivo | Contenido |
|---|---|
| `MainForm.Designer.cs` | Todos los controles de la interfaz (se editan en el diseñador de Visual Studio) |
| `MainForm.cs` | Eventos y dibujo de la interfaz |
| `Logic/HanoiSolver.cs` | Torres de Hanoi recursivo (caso base: 1 disco) |
| `Logic/Laberinto.cs` | Generación (DFS recursivo) y resolución con **backtracking** recursivo |
| `Logic/Algoritmos.cs` | Factorial, Fibonacci, suma de arreglo y Hanoi: versión recursiva vs. iterativa, con conteo de llamadas y profundidad de pila |

## Pestañas
1. **Torres de Hanoi** – de 1 a 10 discos, animación paso a paso, lista de movimientos, llamadas y profundidad.
2. **Laberinto (backtracking)** – genera un laberinto aleatorio y muestra cómo la recursión avanza (azul), retrocede (rosa) y encuentra el camino (verde).
3. **Análisis de profundidad** – tabla comparativa recursivo vs. iterativo con diferentes profundidades de llamada.

## Nota sobre el desbordamiento de pila
En .NET un `StackOverflowException` no se puede capturar y termina el proceso. Por eso las mediciones profundas se ejecutan en un hilo con 256 MB de pila y cada algoritmo tiene un rango máximo validado.
