# 🇺🇸 TaskManagerApi: Because even chaos needs structure

A simple (yet mighty) Web API to manage tasks within user groups.  
This is the **first stage** of a Beta release. Translation: It mostly works, but don’t bet your life on it.

---

## 🖋 Author

Pablo Prado (dev-prado89)

---

## 🧠 What does it actually do?

- CRUD operations for tasks (it won’t *do* the tasks for you, though).
- Assign tasks to users within groups (perfect for families, teams, or control freaks).
- PostgreSQL as the database using Entity Framework Core.
- Uses DTOs because throwing raw models around is for amateurs.
- Comes with seed data, so you're not starting from absolute zero.
- Swagger UI is available for testing (read: poking your API with a stick).
- CORS enabled, because APIs need freedom too.

---

## ⚙️ How to get this thing running (without crying)

1. Clone the repo.
2. Edit the `appsettings.json` file with your PostgreSQL connection string.
3. Run the migrations and seed the database (if you’re using the seeder).
4. Launch it with `dotnet run`.
5. Access your endpoints at:  
   `http://localhost:5000/api/task`  
   Swagger lives at:  
   `http://localhost:5000/swagger` (Development mode only).

---

## 🛑 Things you should probably know

- Still in Beta, so don’t be shocked if you find some “features” (a.k.a bugs).
- Each user group only sees their own stuff — no spying on the Joneses.
- Currently focused on task creation, deletion, and assignment. Fancy features coming soon™.

---

## 🚀 What’s next?

- Authentication and Authorization (so randos can’t mess with your tasks).
- More endpoints (editing, filtering, searching — the usual stuff).
- A web interface — because not everyone enjoys Postman roleplay.

---

## 📝 Notes for developers

- Make sure PostgreSQL is actually running (seriously, double-check).
- If you're contributing: read, think, then code. Your future self will thank you.
- Feedback is welcome — especially the helpful kind.

---

## 📌 Project status

**Beta version — First stage complete.**  
This repo is part of a larger project. More features are planned and coming soon.

---
---

# 🇪🇸 TaskManagerApi: Porque el caos también necesita organización

Una API sencilla (pero poderosa) para gestionar tareas dentro de grupos de usuarios.  
Primera etapa del proyecto, en versión Beta. Sí, eso significa que algo puede explotar. Pero no debería... creemos.

---

## 🖋 Autor

- Pablo Prado (dev-prado89)

---

## 🧠 ¿Qué hace esto por vos?

- Crear, ver y eliminar tareas (no las hace por vos, eso sigue siendo tu problema).
- Asignar tareas a usuarios dentro de grupos (ideal para familias, equipos o gente que delega).
- Backend con PostgreSQL y Entity Framework Core.
- Uso de DTOs para mantener el código limpio (o al menos decente).
- Datos semilla para que no empieces de cero.
- Swagger UI para que juegues sin miedo.
- CORS habilitado, porque el encierro no es saludable ni para las APIs.

---

## ⚙️ Cómo hacerlo funcionar (sin romper nada)

1. Cloná el repo.
2. Abrí el archivo `appsettings.json` y poné tu cadena de conexión a PostgreSQL.
3. Hacé las migraciones y cargá los datos semilla (si usás el seeder).
4. Ejecutá el proyecto con `dotnet run`.
5. Accedé a los endpoints en:  
   `http://localhost:5000/api/task`  
   y al Swagger en:  
   `http://localhost:5000/swagger` (solo en modo Development).

---

## 🛑 Cosas que deberías saber

- Esto está en Beta, así que puede haber detalles que se ajusten más adelante.
- No muestra información de otros grupos: cada grupo ve lo suyo y nada más. Privacidad, viste.
- El foco está en la lógica básica de gestión de tareas. Otras funcionalidades vendrán después.

---

## 🚀 Qué se viene

- Autenticación y autorización (para que nadie te robe las tareas).
- Más endpoints (editar, buscar, etc.).
- Interfaz web para evitar vivir en Postman.

---

## 📝 Notas para developers

- Asegurate de que PostgreSQL esté corriendo (en serio, chequéalo).
- Si vas a colaborar, leé bien antes de meter mano. Nada personal, es solo por salud mental colectiva.
- Cualquier mejora o feedback es bienvenida (si viene con buena onda, mejor).

---

## 📌 Estado del proyecto

**Versión Beta — Primera etapa completada.**  
Este repo es parte de un proyecto más grande que se irá expandiendo en fases.

---
