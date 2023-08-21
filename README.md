# TestTask

Este proyecto es una aplicación web desarrollada para realizar Tests. Permite a los administradores crear, editar y eliminar preguntas, así como también crear pruebas utilizando esas preguntas.

## Tabla de Contenidos
- [Caracteristicas](#características)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Inicio Rápido](#inicio-rápido)
- [Funcionamiento básico](#funcionamiento-básico)
- [Bugs](#bugs)


## Características

- Gestión de preguntas: Agregar, editar y eliminar preguntas.
- Creación de pruebas: Componer pruebas utilizando preguntas existentes.
- Interfaz de administración: Una interfaz intuitiva para administrar las preguntas y pruebas.
- Integración con MongoDB: Utiliza MongoDB como base de datos para almacenar preguntas y pruebas.

## Tecnologías Utilizadas

- ASP.NET MVC: Framework para el desarrollo de aplicaciones web.
- C#: Lenguaje de programación utilizado para la lógica del backend.
- MongoDB: Base de datos NoSQL utilizada para almacenar los datos.
- HTML, CSS y JavaScript: Utilizados para la creación de la interfaz de usuario.
- Bootstrap: Framework CSS para diseño y estilos responsivos.
- Visual Studio: IDE utilizado para el desarrollo.

## Inicio Rápido

1. Clona este repositorio: `git clone https://github.com/tuusuario/TestTask.git`
2. Abre el proyecto en Visual Studio.
3. Configura la conexión a la base de datos MongoDB en `web.config`.
4. Compila y ejecuta el proyecto.
5. Abre tu navegador y accede a `http://localhost:puerto` para ver la aplicación en funcionamiento.

## Funcionamiento básico
- La base de datos solo almacena el nombre de la persona que realiza el test
- Para acceder al panel de administración hay que introducir en el campo Nombre "Admin" y seleccionar cualquier test, le redirigirá a la pagina de login de la administración y tendrá que introducir la contraseña
pass="ContraseñaSuperSegura"
- A pesar de que hay un aviso de intentos y de bloqueo de IP, no está esa funcionalidad incorporada y al introducir mal la contraseña simplemente recarga la vista
- Para los test unitarios habría que configurar una base de datos con las mismas colecciones que la principal e introducir los datos necesarios, se han creado los test con una herramienta automatizada asi que posiblemente den problemas. El resto de funcionalidades han sido testeadas por el desarrollador, sin embargo no hay un metodo automatizado aún desarrollado


## BUGS 
- Los botones de cerrar de las modales no cierra, para salir se debe de darle click afuera de la modal
- El panel de administración solo está diseñado para realizar las acciones CRUD basicas, no relaciona respuestas con las preguntas, etc... habría que hacer las relaciones con la tabla correspondiente en la base de datos


