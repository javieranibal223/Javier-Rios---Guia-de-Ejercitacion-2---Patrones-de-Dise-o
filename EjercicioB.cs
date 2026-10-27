using System;
using System.Collections.Generic;
using System.Linq;

// -----------------------
// SECCIÓN B — Ejercicio 1
// -----------------------
namespace EjercicioB1
{
    public class Contador
    {
        private static Contador _instancia;
        private int _valor = 0;
        private Contador() { Console.WriteLine("Creando contador"); }
        public static Contador Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Contador();
                return _instancia;
            }
        }
        public int Siguiente()
        {
            _valor++;
            return _valor;
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var a = Contador.Instancia;
            var b = Contador.Instancia;

            Console.WriteLine(a.Siguiente());
            Console.WriteLine(b.Siguiente());
            Console.WriteLine(Contador.Instancia.Siguiente());
            Console.WriteLine(ReferenceEquals(a, b));
        }
    }

    // -----------------------
    // SECCIÓN B — Ejercicio 1
    // ¿Qué imprime?:
    // Creando contador
    // 1
    // 2
    // 3
    // True

    // ¿Cuántas veces aparece "Creando contador" y por qué?: Aparece una vez, ya que se intacia una sola vez por principio Singleton.
    //¿Por qué b.Siguiente() no devuelve 1?: Porque el metodo Siguienta suma 1 al ultimo numero guardado en memoria.
    
}

// -----------------------
// SECCIÓN B — Ejercicio 2
// -----------------------
namespace EjercicioB2
{
    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }
    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";
        public decimal Calcular(decimal total) => 0;
    }
    public class Propina10 : IPropina
    {
        public string Nombre => "10%";
        public decimal Calcular(decimal total) => total * 0.10m;
    }
    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;
        public PropinaFija(decimal monto) => _monto = monto;
        public string Nombre => "Fija";
        public decimal Calcular(decimal total) => _monto;
    }
    public class Cuenta
    {
        private IPropina _propina;
        public Cuenta(IPropina propina) => _propina = propina;
        public void CambiarPropina(IPropina propina) => _propina = propina;
        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);
            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var cuenta = new Cuenta(new SinPropina());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new Propina10());
            cuenta.Mostrar(20000);
            cuenta.CambiarPropina(new PropinaFija(1500));
            cuenta.Mostrar(20000);
        }
    }

    // -----------------------
    // SECCIÓN B — Ejercicio 2
    // ¿Qué imprime?:
    // Sin propina : 20000
    // 10% : 22000
    // Fija : 21500
    //
    // En este código, ¿quién es el contexto y quiénes son las estrategias?: El contexto es la clase Cuenta que guarda el contrato ( la interfaz IPropina ) y las estrategias reprsentan cada clase de tipo de propina.
    // ¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?: Nada, ya que a la clase Cuenta y a la interfaz IPropina no le interesan los tipos de propina que se imprementen, por lo que cada nuevo tipo de propina basta una nueva clase que llama a la interfaz, sin modificar codigo existente, cumpliendo principio Open / Close.
    
}

// -----------------------
// SECCIÓN B — Ejercicio 3
// -----------------------
namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }
    public class Canal
    {
        private readonly List<IObservador> _suscriptores = new List<IObservador>();
        public void Suscribir(IObservador o) => _suscriptores.Add(o);
        public void Desuscribir(IObservador o) => _suscriptores.Remove(o);
        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");
            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }
    public class Fan : IObservador
    {
        private readonly string _nombre;
        public Fan(string nombre) => _nombre = nombre;
        public void Actualizar(string video) => Console.WriteLine($" {_nombre} mira {video}");
    }
    public class Estadisticas : IObservador
    {
        private int _avisos = 0;
        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");
        }
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var canal = new Canal();
            var lu = new Fan("Lu");
            canal.Suscribir(lu);
            canal.Suscribir(new Fan("Tomi"));
            canal.Suscribir(new Estadisticas());
            canal.Publicar("Patrones en C#");
            canal.Desuscribir(lu);
            canal.Publicar("Observer en WinForms");
        }
    }

    // -----------------------
    // SECCIÓN B — Ejercicio 3
    // ¿Qué imprime?:
    // Nuevo video: Patrones en C#
    // Lu mira Patrones en C#
    // Tomi mira Patrones en C#
    // Avisos registrados: 1
    // Nuevo video: Observer en WinForms
    // Tomi mira Observer en WinForms
    // Avisos registrados: 2
    
    // ¿Por qué Lu no aparece en la segunda publicación?: Porque fue desubscripta antes de la segunda publicacion
    // ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?: No, Canal maneja la lista implemetando la interfaz IObservador, sin importar que otras la implementen.
    
}