// ----------------------
// SECCION A - Pregunta 1
// Respuesta : c) El constructor private AppLogger() { }.
// ¿Por qué? : Al ser contructor privado se impide que las demas clases creen nuevas nuevas instancias por fuera, controlando una sola clase la creacion d eobjetos que es la base de Singleton.

// ----------------------
// SECCION A - Pregunta 2
// Respuesta : a) La instancia se crea la primera vez que alguien la pide, no antes.
// ¿Por qué? : Singleton requiere que no se malgaste memoria sin que se llame a la propiedad Instancia por primera vez.
// ¿Por que no es la opcion C? : Contradice el patron Singleton al crear multiples instancias cada vez que se llama a la propiedad, en lugar de una compartida.

// ----------------------
// SECCION A - Pregunta 3
// Respuesta : d) Reemplazar un condicional que elige entre variantes de un algoritmo por clases intercambiables detrás de una interfaz.
// ¿Por qué? : Evita largos if o switch mediante una interfaz "modelo", delegando las implementaciones a cada clase.
// ¿Por que no es la opcion A? : Eso corresponde al patron Singleton

// ----------------------
// SECCION A - Pregunta 4
// Respuesta : b) Usa una estrategia a través de la interfaz y le delega el cálculo, sin saber cuál es.
// ¿Por que? : Es una de las bases del patron Strategy, reemplazando los largos if o switch mediante una interfaz "modelo", delegando las implementaciones a cada clase, sin importarle dichas imprementaciones.
// ¿Por que no es la opcion D? : Contradice el patron Strategy al crear switchs

// ----------------------
// SECCION A - Pregunta 5
// Respuesta : c) El medio de pago llega como texto ("QR", "EFECTIVO") desde un ComboBox y desde un JSON, y hay que crear el objeto correcto en varios lugares.
// ¿Por que? : Como la creacion de objetos dependen de datos dinamicos, se evita duplicar condicionales, centralizando la tarea.

// ----------------------
// SECCION A - Pregunta 6
// Respuesta : a) En Factory Method, una superclase con lógica de negocio declara el método de creación y cada subclase decide qué producto concreto crear.
// ¿Por que? : Factoy Method delega la creacion de productos a las subclases mientras que Simple Factory centraliza la creacion con un switch.

// ----------------------
// SECCION A - Pregunta 7
// Respuesta : b) Una lista de referencias a objetos que implementan la interfaz suscriptora.
// ¿Por que? : Porque al notificador no le importa las clases que lo escuchan, sino que guarda una lista de objetos que imprementan su interfaz.

// ----------------------
// SECCION A - Pregunta 8
// Respuesta : d) El controller le sigue avisando a un formulario destruido: puede saltar una excepción y el objetonunca se libera de memoria.
// ¿Por que? : Porque el suscriptor sigue estando en la lista del notificador (a cual solo le interesan los objetos que implemtan su interfaz) aunque el formulario no exista, ya que no se utilizo el metodo de desuscripcion.

// ----------------------
// SECCION A - Pregunta 9
// Respuesta : b) Suscriptor.
// ¿Por que? : Porque se "suscribe" al evento que provoca el boton , y pasa a recibir avisos.

// ----------------------
// SECCION A - Pregunta 10
// Respuesta : c) Creás una clase que implementa la interfaz suscriptora y la suscribís en Program.cs.
// ¿Por que? : Las demas opciones implican modificacion de codigo existente, contradiciendo Open / Closed.












