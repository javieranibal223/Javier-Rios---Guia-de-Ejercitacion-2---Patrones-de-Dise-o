// -------------------------
// Ejercicio E - Escenario 1
// Respuesta : Ya que el costo del envio depende del medio de transporte y se sumara uno nuevo, elegiria el patron Strategy para evitar varios if o switch y poder nuevos medios de transporte sin necesidad de modificar codigo existente.

// -------------------------
// Ejercicio E - Escenario 2
// Respuesta : Elegiria el patron Observer ya que hay un evento ( notificacion de pedidos listos ) del que tienen que enterarse varios "suscriptos", pudiendo agregar nuevos medios de avisos sin modificar codigo existente. 

// -------------------------
// Ejercicio E - Escenario 3
// Respuesta : Elegiria el patron Singleton para que haya una unica instancia de configuracion y cualquier cambio sea leido uniformemente por todo el sistema.

// -------------------------
// Ejercicio E - Escenario 4
// Respuesta : Elegiria el patron Factory Method ya que se requiere transformar texto en objetos y sumar nuevos metodos de pagos evitando errores de ejecucion.

// -------------------------
// Ejercicio E - Escenario 5
// Respuesta : No implementaria ni un patron de diseño ya que al crearse un unico repositorio al iniciar y nunca cambiar durante la ejecucion, utilizar un patron representaria sobrecodigo y sobreutilizacion de memoria