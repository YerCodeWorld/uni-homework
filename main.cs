using System;
					
public class Program
{
	public static void Main()
	{
		string nombre = preguntarNombre(); 
		int edad = preguntarEdad();
		
		Console.WriteLine($"Bienvenido, {nombre}! {edad} años es una edad interesante!");
	}
	
	// utilizando funciones independientes para hacer el código más dinámico
	public static int preguntarEdad() {
		Console.WriteLine("Escriba su edad: ");
		string input = Console.ReadLine(); 
		
		// añadir error handling para edades menores a 0 o mayores a 100
		if (int.TryParse(input, out int age)) {
			if (age >= 0 && age <= 100) {
				return age; 
			} else {
				Console.WriteLine("Por favor, introduzca una edad entre 0 y 100.");
			}
		} else {
			Console.WriteLine("La edad entrada no es correcta.");			
		}
		
		return preguntarEdad();
	}
	
	public static string preguntarNombre() {
		Console.WriteLine("Escriba su nombre: ");
		return Console.ReadLine(); 
	}
}
