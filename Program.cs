//Ejercicio 2

namespace EvaluacionCilindroNeumatico
{
    // CLASE: Representa un cilindro neumático para evaluar la fuerza producida
    public class CilindroNeumatico
    {
        // PROPIEDADES
        public double PresionKpa { get; set; }
        public double AreaCm2 { get; set; }

        // CONSTRUCTOR
        public CilindroNeumatico(double presionKpa, double areaCm2)
        {
            PresionKpa = presionKpa;
            AreaCm2 = areaCm2;
        }

        // MÉTODOS DE CONVERSIÓN DE UNIDADES

        // Convierte la presión de kPa a Pa (1 kPa = 1000 Pa)
        public double ObtenerPresionPa()
        {
            return PresionKpa * 1000.0;
        }

        // Convierte el área efectiva de cm² a m² (1 m² = 10000 cm²)
        public double ObtenerAreaM2()
        {
            return AreaCm2 / 10000.0;
        }

        // MÉTODOS DE CÁLCULO Y EVALUACIÓN

        // Calcula la fuerza producida en Newtons (F = P * A)
        public double CalcularFuerza()
        {
            double presionPa = ObtenerPresionPa();
            double areaM2 = ObtenerAreaM2();
            return presionPa * areaM2;
        }

        // Evalúa si la fuerza producida alcanza o supera la fuerza mínima requerida
        public bool EvaluarRequerimientoMinimo(double fuerzaMinima)
        {
            return CalcularFuerza() >= fuerzaMinima;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" EVALUACIÓN DE FUERZA EN CILINDRO NEUMÁTICO ");
            Console.WriteLine("==================================================\n");

            // Captura de datos con validaciones de no negatividad
            double presionInput = LeerNumeroPositivo("Ingrese la presión de trabajo [kPa]: ");
            double areaInput = LeerNumeroPositivo("Ingrese el área efectiva del pistón [cm²]: ");
            double fuerzaMinimaInput = LeerNumeroPositivo("Ingrese la fuerza mínima requerida [N]: ");

            // OBJETO: Instanciación del objeto cilindroEvaluado a partir de la clase CilindroNeumatico
            CilindroNeumatico cilindroEvaluado = new CilindroNeumatico(presionInput, areaInput);

            // CÁLCULOS Y CONVERSIONES
            double presionPa = cilindroEvaluado.ObtenerPresionPa();
            double areaM2 = cilindroEvaluado.ObtenerAreaM2();
            double fuerzaCalculada = cilindroEvaluado.CalcularFuerza();
            bool cumpleRequerimiento = cilindroEvaluado.EvaluarRequerimientoMinimo(fuerzaMinimaInput);

            // SALIDA DE RESULTADOS CON UNIDADES DE MEDIDA
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("               RESULTADOS DEL ANÁLISIS            ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Presión convertida      : {presionPa:N2} Pa");
            Console.WriteLine($"Área convertida         : {areaM2:F6} m²");
            Console.WriteLine($"Fuerza calculada        : {fuerzaCalculada:F2} N");
            Console.WriteLine($"Fuerza mínima requerida : {fuerzaMinimaInput:F2} N");

            if (cumpleRequerimiento)
            {
                Console.WriteLine("Estado del requerimiento: CUMPLE (Fuerza suficiente)");
            }
            else
            {
                Console.WriteLine("Estado del requerimiento: NO CUMPLE (Fuerza insuficiente)");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // MÉTODO AUXILIAR DE VALIDACIÓN: Evita números negativos y errores de formato
        static double LeerNumeroPositivo(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out valor))
                {
                    if (valor >= 0)
                    {
                        return valor; // Retorna el valor validado
                    }
                    else
                    {
                        Console.WriteLine("Error: El valor no puede ser negativo. Intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Entrada no válida. Ingrese un valor numérico positivo.");
                }
            }
        }
    }
}