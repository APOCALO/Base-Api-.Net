
# 🌐 Proyecto Scaffold API .NET 8 para Microservicios

![Plataforma](https://img.shields.io/badge/platform-.NET%208-blueviolet)
![Licencia](https://img.shields.io/badge/license-MIT-green)
![Arquitectura limpia](https://img.shields.io/badge/architecture-clean-blue)
![DDD](https://img.shields.io/badge/pattern-DDD-orange)
![MediatR](https://img.shields.io/badge/tool-MediatR-red)

> **Proyecto de andamiaje de API eficiente para crear microservicios con .NET 8, aprovechando la arquitectura limpia, el diseño orientado al dominio (DDD) y MediatR**. Este proyecto proporciona una base altamente extensible para crear servicios robustos y escalables teniendo en cuenta las mejores prácticas. 🎯

---

## 🎯 Visión general

Este repositorio sirve de andamiaje para crear microservicios .NET eficientes. Diseñado teniendo en cuenta la modularidad y la mantenibilidad, proporciona un sólido punto de partida para aplicaciones de nivel empresarial. El proyecto se basa en:

- 🏗 **Arquitectura limpia**: Fomenta la separación de preocupaciones, lo que facilita las pruebas, el mantenimiento y la ampliación.
- 📦 **Diseño orientado al dominio (DDD)**: Ayuda a estructurar la lógica empresarial compleja con capas específicas del dominio.
- 📡 **MediatR**: Facilita la comunicación entre componentes utilizando el patrón mediador para un código más limpio y desacoplado.

---

## 🛠 Características

- **Estructura modular**: Proporciona capas organizadas para dominio, aplicación e infraestructura.
- **Altamente extensible**: Añade fácilmente nuevas funciones y componentes sin afectar a la estructura central.
- **Rendimiento eficiente**: Código base optimizado para aplicaciones de microservicios con capacidad de respuesta.
- **Mejores prácticas**: Sigue las mejores prácticas de .NET y de arquitectura para un código limpio y mantenible.

---

## 🚀 Primeros pasos

### Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (u otra base de datos compatible)
- [Docker](https://www.docker.com/products/docker-desktop) (opcional para el desarrollo en contenedores)

### Instalación

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/APOCALO/ScaffoldingMS.git
   cd ScaffoldingMS
   ```

2. **Instalar dependencias**:
   - Restore the dependencies by running:
     ```bash
     dotnet restore
     ```

3. **Configurar la base de datos**:
   - Actualiza `appsettings.json` con tu cadena de conexión a la base de datos.

4. **Ejecutar la aplicación**:
   ```bash
   dotnet run
   ```

---

## 📖 Utilización

Este scaffold está diseñado para apoyar el rápido desarrollo de APIs. Puede empezar a crear nuevas funciones definiéndolas en las capas **Dominio** y **Aplicación**, y exponiéndolas después a través de la capa **API**.

- **Añadir nuevos Endpoints**: Definir nuevos endpoints añadiendo DTOs de petición/respuesta en `Application` y handlers con MediatR.
- **Ampliar el dominio**: Organizar la lógica de negocio dentro de la capa `Domain` para la reutilización y la coherencia.

Consulte la [Documentación de la API](#) 📄 para obtener una lista detallada de los puntos finales disponibles y ejemplos de uso.

---

## 📂 Estructura del proyecto

```
📁 YourProjectName
├── 📁 Web.Api              # Contiene la capa API
├── 📁 Application          # Capa de aplicación con lógica de negocio, DTOs y handlers MediatR
├── 📁 Domain               # Capa de dominio para entidades, interfaces y lógica central
└── 📁 Infrastructure       # Capa de infraestructura para acceso a datos y servicios externos
```

---

## 🧑‍🤝‍🧑 Contribución

Las contribuciones son bienvenidas. Si desea contribuir a este proyecto, por favor:

1. Fork del repositorio.
2. Crear una nueva rama (`feature/YourFeature`).
3. Commit de los cambios..
4. Reliaza push a la rama y crea un Pull Request.

Por favor, lea nuestras [Directrices de contribución](CONTRIBUTING.md) para más detalles. 🙌

---

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

---

## 🌟 Agradecimientos

Un agradecimiento especial a la comunidad .NET y a los colaboradores que mejoran continuamente el ecosistema. 🙏

---

> Hecho con ❤️ por [Apocalo](https://github.com/APOCALO)
    