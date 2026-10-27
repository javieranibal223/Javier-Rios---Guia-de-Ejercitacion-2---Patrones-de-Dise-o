using System;
using System.Collections.Generic;
using System.Linq;

// -----------------------
// SECCIÓN C — Ejercicio 1
// ¿Cuál es el error y de qué tipo es?: Es un error de ejecucion Es un error de ejecución (InvalidOperationException)
// ¿Por qué ocurre?: Porque AvisoUnico quiere desuscribirse mientras itera el foreach.
// ¿Cómo se corrige?: itinerando una copia de la lista utilzando ToList().

namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);
        public void Sonar()
        {
            Console.WriteLine("¡Riiiing!");

            var copiaObservadores = _observadores.ToList();

            foreach (var o in copiaObservadores)
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");
    }

    public static class Demo
    {
        public static void Ejecutar()
        {
            var alarma = new Alarma();
            alarma.Suscribir(new AvisoUnico());
            alarma.Suscribir(new Luz());
            alarma.Sonar();
        }
    }
}

// -----------------------
// SECCIÓN C — Ejercicio 2
// ¿Cuál es el error y de qué tipo es?: Es un error de diseño, ya que el patron Strategy reemplaza los if y switch por una interfaz que cada clase debe implementar, sin importarle a esta el como.
// ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?: Debido a la mala implementacion del patron Strategy, requeriria otro caso if.
// ¿Cómo se corrige?: Creando una clase por cada tipo de tarifa, implemtando cada uno la interfaz IEnvioStrategy.

namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }
    public class TarifaMoto : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    }

    public class TarifaCamion : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    }

    public class TarifaComun : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    }
}

// -----------------------
// SECCIÓN C — Ejercicio 3
// ¿Cuál es el error y de qué tipo es?: Es un error de compilacion ya que si el metodo de envio no es email o SMS, el metodo no puede devolver nada.
// ¿Cómo se corrige?: Lanzando una excepcion de forma que se devuelva un objeto o devuelve dicha excepcion.
// ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?: La excepcion nos informa del error y el dato no valido. En caso de que devuelva null, el programa usaria el mismo tipo de notificador mas adelante.

namespace EjercicioC3
{
    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }

    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"[MAIL a {destino}] {mensaje}");
    }

    public class NotificadorSms : INotificador
    {
        public void Enviar(string destino, string mensaje) =>
            Console.WriteLine($"[SMS a {destino}] {mensaje}");
    }

    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();

            throw new ArgumentException($"Canal de notificación desconocido: {canal}");
        }
    }
}
