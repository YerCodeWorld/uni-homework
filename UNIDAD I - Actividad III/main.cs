using System;
using System.Collections.Generic;
					
public class Program
{
	
	public string mensaje = "No entró un número válido...";
	
	Dictionary<int, Func<int, int, int>> actions = new Dictionary<int, Func<int, int, int>>()
	{
		{ 1, (a, b) => a + b },
		{ 2, (a, b) => a - b },
		{ 3, (a, b) => a * b },
		{ 4, (a, b) => b != 0 ? a / b : throw new DivideByZeroException("No se puede dividir por cero.")}
	};

	public static void Main()
	{
		var instance = new Program();
		int a = instance.preguntarNúmero("Entre el primer número: ");
		int b = instance.preguntarNúmero("Entre el segundo número: ");
		
		instance.realizarOperación(a, b); 
	}
	
	// utilizando funciones independientes para hacer el código más dinámico
	public int preguntarNúmero(string operation) {
		
		Console.WriteLine(operation);
		string input = Console.ReadLine(); 
		
		if (int.TryParse(input, out int number)) {
			if (0 > number) {
				Console.WriteLine(mensaje);			
			} else {
				return number;
			}
		} else {
			Console.WriteLine(mensaje);			
		}
		return preguntarNúmero(operation);
	}
	
	public void realizarOperación(int a, int b) {
			
		Console.WriteLine("Elija su operación: \n 1 - Suma | 2 - Resta | 3 - Multiplicación | 4 - División");
		int input = preguntarNúmero("Elija su opción");
		
		if (input <= 0 || input >= 5) {
			Console.WriteLine("La opcion elejida no es válida. Intente denuevo."); 
		} else {
			try {
				int resultado = actions[input](a, b);
				Console.WriteLine($"Resultado: {resultado}. Bye!"); 
			} catch (Exception ex) {
				Console.WriteLine("Error: " + ex.Message);
			}
		}
		
		realizarOperación(a, b);
	}
}
