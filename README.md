# 🛠️ Ejercicio Práctico .NET 8 - Gestión de Transportes

Este proyecto consiste en un ejercicio práctico en consola utilizando **C# con .NET 8 y Entity Framework Core**, que simula un sistema simple de registro y gestión de transportes: **aviones y automóviles**, modelados mediante herencia.

El objetivo del ejercicio es demostrar el uso de buenas prácticas modernas en programación orientada a objetos, Entity Framework, y estructura organizada por capas.

---

## 📚 Enunciado del ejercicio

> Se desea implementar una aplicación de consola para registrar diferentes tipos de transporte.  
> 
> Todos los transportes deben tener:
> - Secuencia
> - Número de ruedas
> - Color
> - Largo
> - Ancho
> - Número de pasajeros
> 
> - Si es un **avión**, debe registrar piloto y copiloto.
> - Si es un **automóvil**, debe registrar el conductor.
> 
> Todos los transportes pueden avanzar o detenerse.
> 
> Al iniciar el programa deben cargarse **6 objetos desordenados**.
> Se deben poder:
> - Insertar transportes
> - Actualizar datos
> - Eliminar transportes
> - Listar transportes ordenados por secuencia (ascendente)

---

## 🧱 Estructura del Proyecto

TransporteApp/
├── Models/ # Clases: Transporte, Avion, Automovil
├── Data/ # AppDbContext (configuración EF Core)
├── Services/ # TransporteService (CRUD y validación)
├── Program.cs # Consola principal y menú interactivo
├── appsettings.json # Cadena de conexión SQL Server
└── Migrations/ # Migraciones EF Core


## 📦 Dependencias Principales

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.Extensions.Hosting
- Microsoft.Extensions.Configuration

---

## ✅ Tecnologías usadas

- 🟢 **.NET 8 SDK**
- 🧠 **C# orientado a objetos (herencia, encapsulamiento)**
- 🗃 **Entity Framework Core**
- 💾 **SQL Server**
- ⚙ **Migraciones con CLI (`dotnet ef`)**
- 🎨 Consola con mensajes formateados, colores y control de errores

---

## 📦 Requisitos

- Visual Studio 2022 o superior
- .NET 8 SDK
- SQL Server LocalDB o Express
- Entity Framework Core Tools (`dotnet ef`)

---

## ⚙️ Instrucciones de ejecución

1. Clonar el proyecto o descargarlo:

```bash
git clone https://github.com/tu-usuario/TransporteApp.git
cd TransporteApp/TransporteApp


2. Restaurar dependencias:

dotnet restore


3. Aplicar migraciones para crear la base de datos:

dotnet ef database update


4. Ejecutar la consola:

dotnet run


🔄 Funcionalidades disponibles
Listar transportes: ordenados por secuencia

Insertar: avión o automóvil (con validación por tipo)

Actualizar: color, pasajeros, piloto/copiloto o conductor

Eliminar: por ID

Control de errores: validaciones y mensajes informativos

Datos iniciales: se cargan automáticamente 6 registros (semilla)

✍️ Aprendizajes aplicados
Herencia y relaciones uno a uno en EF Core

Separación por capas (modelo, lógica, datos)

Configuración externa mediante appsettings.json

Migraciones, precision decimal y carga de datos iniciales (HasData)

Manejo de errores y experiencia de usuario en consola

🧠 Propósito
Este ejercicio fue desarrollado con fines prácticos y académicos, para demostrar el dominio de:

Programación en C# .NET moderno

Manejo de datos y ORM con EF Core

Organización de proyectos y arquitectura clara

📤 Licencia
Uso libre para aprendizaje, pruebas técnicas o base de proyectos personales.



