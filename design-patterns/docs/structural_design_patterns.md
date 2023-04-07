# DESIGN PATTERNS:				by refactoring guru website


## Decorator:

* El decorador actua como capa adicional alrededor del objeto original, permitiendo que se agregen caracteristicas o comportamientos sin modificar el objeto original.

* Tantos decoradores como queramos mediante herencia.


## Diferencias con proxy:
Proxy se utiliza para controlar el acceso a un recurso o objeto. Actua como intermediario entre el cliente y el objeto original, permitiendo su acceso solamente desde el proxy.
Sirve para implementar un nivel de seguridad y control de acceso.

La intención, es decir, el proxy añade características que no tienen nada que ver con el resultado, es decir no altera el mensaje, sino se encarga de la infraestructura.

* Propósito
El propósito principal del decorador es agregar funcionalidad a un objeto existente de forma dinámica, mientras que el propósito del proxy es controlar el acceso a un objeto o recurso.

* Estructura
El decorador utiliza la composición para agregar funcionalidad, mientras que el proxy utiliza la agregación para controlar el acceso.

* Tiempo en ejecución
 El decorador modifica el comportamiento de un objeto en tiempo de ejecución, mientras que el proxy controla el acceso a un objeto en tiempo de ejecución.

# Resumen
 El decorador se utiliza para agregar funcionalidad a un objeto existente, mientras que el proxy se utiliza para controlar el acceso a un objeto o recurso.
