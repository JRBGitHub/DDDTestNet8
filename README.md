# DDDTestNet8 - Servicio de Consulta de Acumulados de Divisas

## Descripción

Este proyecto implementa un servicio de consulta de acumulados de divisas por cliente y canal, siguiendo los principios de **Domain-Driven Design (DDD)** y **Clean Architecture** en .NET 8/9. Incluye API REST, tests unitarios, pruebas BDD (SpecFlow) y documentación para facilitar su replicación en otros negocios.

---

## Estructura del Proyecto

```
DDDTestNet8.sln
src/
  DDDTestNet8.Domain/         # Entidades y lógica de dominio
  DDDTestNet8.Application/    # Servicios de aplicación y casos de uso
  DDDTestNet8.Infrastructure/ # Implementaciones de repositorios (InMemory)
  DDDTestNet8.Api/            # API REST (ASP.NET Core)
tests/
  DDDTestNet8.UnitTests/      # Tests unitarios y BDD (SpecFlow)
```

---

## Principios y Buenas Prácticas

- **DDD**: Separación clara entre dominio, aplicación e infraestructura.
- **Clean Architecture**: Dependencias dirigidas hacia el dominio.
- **Inyección de dependencias**: Configurada en la API.
- **Patrón Repositorio**: Abstracción para acceso a datos.
- **Testing**: Unitarios (NUnit) y BDD (SpecFlow).
- **Documentación y replicabilidad**: Este README y prompt guía.

---

## Instalación y Ejecución

1. **Clona el repositorio**  
   ```powershell
   git clone <url-del-repo>
   cd DDD-TEST-NET8
   ```

2. **Restaura dependencias y compila**  
   ```powershell
   dotnet restore
   dotnet build
   ```

3. **Ejecuta la API**  
   ```powershell
   dotnet run --project src/DDDTestNet8.Api
   ```
   La API estará disponible en `https://localhost:5001` o `http://localhost:5000`.

4. **Prueba el endpoint principal**  
   - **GET** `/acumulados?idHost=1&canal=WEB1`
   - Respuesta: Lista de acumulados filtrados por cliente y canal.

---

## Testing

### Unitarios

```powershell
dotnet test tests/DDDTestNet8.UnitTests
```

- Ubicación: `tests/DDDTestNet8.UnitTests/UnitTest1.cs`
- Cobertura: Servicio de aplicación y lógica de filtrado.

### BDD (SpecFlow)

- Escenarios en: `ConsultaAcumulados.feature`
- Steps en: `ConsultaAcumuladosSteps.cs`
- Ejecuta junto con los tests unitarios.

---

## Replicación para Otros Negocios

1. **Define la entidad principal** en el proyecto Domain.
2. **Crea interfaces y servicios de aplicación** en Application.
3. **Implementa repositorios** (InMemory, SQL, etc.) en Infrastructure.
4. **Expón endpoints** en la API.
5. **Agrega tests unitarios y BDD** en tests.
6. **Documenta el proceso** siguiendo este README.

---

## Prompt Guía para IA/Desarrolladores

> **Prompt sugerido:**  
> "Crea un servicio .NET siguiendo DDD y Clean Architecture para consultar acumulados de [entidad] por [criterio1] y [criterio2], con API REST, tests unitarios y BDD, y documentación clara para replicar el proceso en otros negocios. Incluye un README completo y un prompt guía para IA/desarrolladores."

---

## Ejemplo de User Story y BDD

**User Story (Markdown):**
```
Como usuario del sistema  
Quiero consultar los acumulados de divisas por cliente y canal  
Para conocer el estado de mis operaciones en diferentes plataformas
```

**Escenario BDD (SpecFlow):**
```
Given existen acumulados para el cliente 1 en el canal "WEB1"
When consulto los acumulados para el cliente 1 y canal "WEB1"
Then obtengo solo los acumulados correspondientes a ese canal
```

---

## Contacto y Soporte

Para dudas o mejoras, abre un issue o contacta al equipo de desarrollo.

---

¿Listo para replicar el patrón en tu negocio? Solo sigue los pasos y adapta la entidad y lógica a tu dominio.

---
