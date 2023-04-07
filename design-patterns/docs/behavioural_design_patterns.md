# behavioural design patternsº

## Strategy

Definición: 

El patrón de comportamiento Strategy es una forma de encapsular diferentes algoritmos en objetos separados y hacerlos intercambiables, lo que permite cambiar elcomportamiento de un objeto en tiempo de ejecución y tener una variedad de algoritmos disponibles para realizar una tarea específica.

Ejemplo:

```java
// Interfaz común para todas las estrategias de pago
interface PaymentStrategy {
    void pay(double amount);
}

// Implementación de la estrategia de pago con tarjeta de crédito
class CreditCardStrategy implements PaymentStrategy {
    private String cardNumber;
    private String expirationDate;
    private String cvv;

    public CreditCardStrategy(String cardNumber, String expirationDate, String cvv) {
        this.cardNumber = cardNumber;
        this.expirationDate = expirationDate;
        this.cvv = cvv;
    }

    public void pay(double amount) {
        // Lógica para procesar el pago con tarjeta de crédito
        System.out.println("Pagando " + amount + " con tarjeta de crédito...");
    }
}

// Implementación de la estrategia de pago con PayPal
class PayPalStrategy implements PaymentStrategy {
    private String email;
    private String password;

    public PayPalStrategy(String email, String password) {
        this.email = email;
        this.password = password;
    }

    public void pay(double amount) {
        // Lógica para procesar el pago con PayPal
        System.out.println("Pagando " + amount + " con PayPal...");
    }
}

// Clase de contexto que utiliza la estrategia de pago seleccionada
class PaymentContext {
    private PaymentStrategy paymentStrategy;

    public void setPaymentStrategy(PaymentStrategy paymentStrategy) {
        this.paymentStrategy = paymentStrategy;
    }

    public void makePayment(double amount) {
        paymentStrategy.pay(amount);
    }
}

// Ejemplo de uso del patrón de diseño Strategy
public class PaymentApp {
    public static void main(String[] args) {
        PaymentContext paymentContext = new PaymentContext();

        // Seleccionar la estrategia de pago con tarjeta de crédito
        PaymentStrategy creditCardStrategy = new CreditCardStrategy("1234 5678 9012 3456", "12/23", "123");
        paymentContext.setPaymentStrategy(creditCardStrategy);
        paymentContext.makePayment(100.00);

        // Seleccionar la estrategia de pago con PayPal
        PaymentStrategy payPalStrategy = new PayPalStrategy("example@gmail.com", "password123");
        paymentContext.setPaymentStrategy(payPalStrategy);
        paymentContext.makePayment(50.00);
    }
}

```

**En este ejemplo, la interfaz PaymentStrategy define la interfaz común que deben implementar todas las estrategias de pago, y las clases CreditCardStrategy y PayPalStrategy implementan cada una de las estrategias de pago específicas.

Luego, en la clase PaymentContext, se utiliza la estrategia de pago seleccionada para procesar el pago a través del método makePayment(). En el método main() de la clase PaymentApp, se crea un objeto PaymentContext y se cambia la estrategia de pago en tiempo de ejecución simplemente cambiando el objeto de estrategia actual y llamando al método makePayment().**

## Memento

**Sirve para guardar un estado, y poder recuperarlo**

permite capturar y almacenar el estado interno de un objeto en un momento dado, sin violar el principio de encapsulamiento, y posteriormente restaurar ese estado en el objeto cuando sea necesario. Este patrón se utiliza para implementar funciones como deshacer y rehacer, ya que permite volver a un estado anterior de un objeto.

En el patrón Memento, se definen tres clases principales: el objeto original que se quiere guardar su estado, la clase "Memento" que guarda el estado interno del objeto y una clase "Caretaker" que actúa como un administrador para el objeto y su estado guardado. El objeto original crea el "Memento" y lo pasa al "Caretaker" para almacenarlo. Cuando el objeto original necesita restaurar su estado anterior, el "Caretaker" devuelve el "Memento" al objeto original, que lo utiliza para restaurar su estado.

Este patrón es útil en situaciones donde se necesita guardar el estado de un objeto en un momento dado, sin comprometer la encapsulación del objeto. Además, permite que el objeto original sea independiente del proceso de almacenamiento y restauración del estado, lo que hace que el código sea más modular y fácil de mantener.

Clase originador-> clase la cual queremos 


## Template method

El patrón de diseño Template Method es un patrón de comportamiento que define la estructura básica de un algoritmo en una clase base, pero permite que las subclases redefinan ciertos pasos del algoritmo sin cambiar su estructura general.

En otras palabras, este patrón proporciona un marco para definir algoritmos en una clase base, mientras que los detalles específicos de cada paso pueden ser proporcionados por las subclases.

Un ejemplo común del patrón Template Method es el proceso de elaboración de una bebida caliente, como el té o el café. En este ejemplo, la clase base "BebidaCaliente" define la estructura básica del proceso de elaboración de la bebida, que incluye los siguientes pasos:

Hervir el agua.
Preparar la taza.
Agregar el ingrediente principal (café o té) a la taza.
Verter el agua caliente sobre el ingrediente.
Agregar leche o azúcar según sea necesario.

Cada uno de estos pasos es definido en la clase base como un método separado, que puede ser implementado por las subclases según sea necesario. Por ejemplo, la subclase "Té" podría redefinir el método "Agregar ingrediente principal" para agregar hojas de té en lugar de granos de café, mientras que la subclase "Café con leche" podría redefinir el método "Agregar leche o azúcar" para agregar leche y azúcar en lugar de solo uno de ellos.

De esta manera, el patrón Template Method permite que las subclases definan su propia variante del algoritmo general, sin tener que volver a implementar la estructura básica de la clase base.

## Chain of resposability

Chain of Responsibility (cadena de responsabilidad) es un patrón de diseño de comportamiento que permite que múltiples objetos se encadenen en una secuencia y manejen una solicitud en orden, hasta que uno de ellos pueda manejarla y resolverla.

En este patrón, cada objeto en la cadena tiene una referencia al siguiente objeto en la cadena. Cuando una solicitud llega al primer objeto, éste intenta manejarla. Si puede manejar la solicitud, la procesa y se detiene. De lo contrario, el objeto pasa la solicitud al siguiente objeto en la cadena, y así sucesivamente, hasta que la solicitud sea manejada o la cadena llegue al final.

Un ejemplo común del patrón Chain of Responsibility es el proceso de aprobación de solicitudes en una empresa. En este ejemplo, las solicitudes pasan por una serie de etapas de aprobación, comenzando con un nivel bajo y avanzando hasta un nivel alto. Cada nivel de aprobación es representado por un objeto en la cadena, y cada objeto puede aprobar o rechazar la solicitud en función de su nivel de autoridad.

Por ejemplo, el primer objeto podría ser un supervisor de nivel bajo que puede aprobar solicitudes de hasta cierta cantidad de dinero. Si la solicitud es demasiado grande, el supervisor pasa la solicitud al siguiente objeto en la cadena, que podría ser un gerente de nivel medio con una autoridad mayor para aprobar solicitudes de mayor cantidad de dinero. Si la solicitud es aún demasiado grande para el gerente, se pasa al siguiente objeto en la cadena, y así sucesivamente, hasta que la solicitud sea aprobada o rechazada.

En resumen, el patrón Chain of Responsibility es útil cuando hay múltiples objetos que pueden manejar una solicitud y se desea proporcionar una forma flexible de encadenarlos en una secuencia, para que cada objeto en la cadena tenga la oportunidad de manejar la solicitud en función de sus capacidades y autoridad.

## Observer

El patrón de diseño Observer (Observador) es un patrón de comportamiento que establece una relación uno-a-muchos entre objetos, de modo que cuando un objeto cambia su estado, todos los objetos dependientes son notificados y actualizados automáticamente.

En este patrón, hay dos tipos de objetos: el sujeto (o observable) y los observadores. El sujeto es el objeto que está siendo observado y mantiene una lista de todos los observadores que lo están observando. Cuando el sujeto cambia su estado, notifica automáticamente a todos los observadores en su lista, quienes se actualizan según corresponda.

Un ejemplo común del patrón Observer es el sistema de suscripción a una revista. En este ejemplo, la revista es el sujeto, mientras que los suscriptores son los observadores. Cuando se publica una nueva edición de la revista, todos los suscriptores deben ser notificados y recibir una copia de la edición actualizada.

En este caso, el sujeto (la revista) mantiene una lista de todos los observadores (los suscriptores), y cuando se publica una nueva edición, notifica automáticamente a todos los suscriptores en su lista. Cada suscriptor recibe una copia actualizada de la revista y se actualiza en consecuencia.

Otro ejemplo común del patrón Observer es en la implementación de patrones de diseño basados en eventos en lenguajes de programación, donde los eventos actúan como el sujeto y los controladores de eventos son los observadores. Cuando se produce un evento, se notifica automáticamente a todos los controladores de eventos registrados para ese evento, que pueden realizar las acciones correspondientes en respuesta al evento.

## iterator

El patrón de diseño Iterator (Iterador) es un patrón de comportamiento que proporciona una forma de acceder secuencialmente a los elementos de un objeto agregado sin exponer su representación interna.

En este patrón, un objeto iterador se utiliza para recorrer una colección de objetos y acceder a cada uno de ellos sin tener que conocer los detalles de su implementación. El iterador mantiene un registro de la posición actual en la colección y proporciona métodos para acceder al siguiente elemento, verificar si hay más elementos y restablecer la posición del iterador a la posición inicial.

Un ejemplo común del patrón Iterator es en la implementación de colecciones en lenguajes de programación, como las listas, los arrays y los diccionarios. En este ejemplo, el iterador se utiliza para recorrer los elementos de la colección uno por uno y realizar una operación en cada elemento.

Por ejemplo, considera una lista de números enteros. En lugar de acceder directamente a los elementos de la lista mediante su índice, se puede utilizar un iterador para recorrer todos los elementos de la lista y realizar alguna operación en cada elemento, como imprimirlos en la pantalla o calcular su suma total. En este caso, el iterador se encarga de recorrer los elementos de la lista sin exponer su representación interna y proporciona una interfaz simple para acceder a ellos secuencialmente.

En resumen, el patrón Iterator es útil cuando se desea recorrer los elementos de una colección sin tener que conocer su representación interna y proporciona una forma flexible y segura de acceder a los elementos de la colección secuencialmente.

## Visitor

El patrón de diseño Iterator (Iterador) es un patrón de comportamiento que proporciona una forma de acceder secuencialmente a los elementos de un objeto agregado sin exponer su representación interna.

En este patrón, un objeto iterador se utiliza para recorrer una colección de objetos y acceder a cada uno de ellos sin tener que conocer los detalles de su implementación. El iterador mantiene un registro de la posición actual en la colección y proporciona métodos para acceder al siguiente elemento, verificar si hay más elementos y restablecer la posición del iterador a la posición inicial.

Un ejemplo común del patrón Iterator es en la implementación de colecciones en lenguajes de programación, como las listas, los arrays y los diccionarios. En este ejemplo, el iterador se utiliza para recorrer los elementos de la colección uno por uno y realizar una operación en cada elemento.

Por ejemplo, considera una lista de números enteros. En lugar de acceder directamente a los elementos de la lista mediante su índice, se puede utilizar un iterador para recorrer todos los elementos de la lista y realizar alguna operación en cada elemento, como imprimirlos en la pantalla o calcular su suma total. En este caso, el iterador se encarga de recorrer los elementos de la lista sin exponer su representación interna y proporciona una interfaz simple para acceder a ellos secuencialmente.

En resumen, el patrón Iterator es útil cuando se desea recorrer los elementos de una colección sin tener que conocer su representación interna y proporciona una forma flexible y segura de acceder a los elementos de la colección secuencialmente.

## State

El patrón de diseño State (Estado) es un patrón de comportamiento que permite que un objeto altere su comportamiento cuando su estado interno cambia. Este patrón se basa en la idea de que un objeto puede cambiar su comportamiento en tiempo de ejecución al cambiar su estado interno.

En el patrón State, un objeto tiene diferentes estados y puede cambiar de un estado a otro cuando ciertas condiciones se cumplen. Cada estado está representado por un objeto separado y tiene un conjunto de comportamientos asociados. El objeto que está siendo controlado por los estados (conocido como el contexto) delega el comportamiento a los objetos de estado según corresponda.

Un ejemplo común del patrón State es en la implementación de una máquina expendedora. En este ejemplo, la máquina expendedora tiene diferentes estados, como "esperando a que se inserte una moneda", "seleccionando un producto", "entregando un producto", etc. Cada estado tiene su propio conjunto de comportamientos asociados, como aceptar una moneda, dispensar un producto, etc. Cuando un cliente interactúa con la máquina expendedora, el contexto (la máquina expendedora) delega el comportamiento a los objetos de estado según corresponda.

En resumen, el patrón State es útil cuando se desea que un objeto tenga diferentes comportamientos según su estado interno y proporciona una forma flexible y segura de cambiar el comportamiento en tiempo de ejecución.
