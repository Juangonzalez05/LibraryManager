# 📚 Book Manager

## Descripción
Book Manager es una aplicación de gestión de libros desarrollada con Blazor WebAssembly en el frontend y ASP.NET Core en el backend. Permite la administración de libros y autores, incluyendo la creación, edición, eliminación y visualización de detalles.

---

## 🚀 Tecnologías Utilizadas

### **Frontend:**
- Blazor WebAssembly
- .NET 8
- C#
- HttpClient para consumo de API

### **Backend:**
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

---

## 📂 Estructura del Proyecto

### **Backend (BookManager.API)**
Controllers/ → Contiene los controladores de la API (ej. BooksController, AuthorsController).

DTOs/ → Define los objetos de transferencia de datos usados entre el backend y el frontend.

Entities/ → Modelos de base de datos como Book y Author.

Exceptions/ → Manejo centralizado de errores y excepciones personalizadas.

Interfaces/ → Contiene las interfaces para los servicios de acceso a datos.

Migrations/ → Archivos generados por Entity Framework Core para el control de la base de datos.

Services/ → Implementación de la lógica de negocio para libros y autores.

### **Frontend (BookManager.Blazor)**
- `Pages/` → Vistas con componentes Blazor.
- `Services/` → Servicios para consumir la API.
- `Models/` → Modelos para representar datos.

---

## ⚙️ Configuración y Ejecución

### **1️⃣ Clonar el repositorio**
```sh
 git clone https://github.com/Juangonzalez05/LibraryManager.git
 cd LibraryManager
```

### **2️⃣ Configurar el backend**
1. Ir a `BookManager.API`
2. Configurar la cadena de conexión en `appsettings.json`:
```json
 "ConnectionStrings": {
   "DefaultConnection": "Server=TU_SERVIDOR;Database=BookDB;Trusted_Connection=True;"
 }
```
3. Ejecutar migraciones y actualizar la base de datos:
```sh
 dotnet ef database update
```
4. Iniciar la API:
```sh
 dotnet run
```

### **3️⃣ Configurar el frontend**
1. Ir a `BookManager.Blazor`
2. Ejecutar:
```sh
 dotnet run
```
3. Abrir el navegador en:
```
 http://localhost:5000
```

---

## 🔗 Endpoints Principales

### **Libros**
- `GET /api/books` → Obtener todos los libros.
- `GET /api/books/{id}` → Obtener un libro por ID.
- `POST /api/books` → Crear un nuevo libro.
- `PUT /api/books/{id}` → Actualizar un libro.
- `DELETE /api/books/{id}` → Eliminar un libro.

### **Autores**
- `GET /api/authors` → Obtener todos los autores.
- `POST /api/authors` → Crear un nuevo autor.
- `DELETE /api/authors/{id}` → Eliminar un autor.

---

## 🛠️ Funcionalidades
✅ Listar libros y autores  
✅ Crear y editar libros  
✅ Eliminar libros y autores  
✅ Asociar libros con autores  
✅ Persistencia de datos con SQL Server  
✅ Interfaz moderna con Blazor WebAssembly  

---



