# 🚚 Sistema de Gestión de Compras y Envíos

Aplicación WebAPI REST que permite gestionar productos, clientes, compras, viajes y envíos para una empresa local con alcance nacional. Se desarrolló bajo una arquitectura por capas y uso de archivos JSON para almacenamiento persistente.

---

## 🛠️ Configuración del Proyecto

1. Clonar el repositorio:  
   `git clone https://github.com/NereoAyala/2024-Prog1-TI-Ayala-Bertone-Stoffel`

2. Ejecutar la solución en Visual Studio.

3. Verificar que los archivos `.json` se encuentren correctamente ubicados en la carpeta de datos.

---

## 📁 Estructura del Proyecto

- `Entidades/`: Modelos de dominio (Producto, Cliente, Compra, Camioneta, Viaje).
- `DTO/`: Objetos de transferencia de datos para inputs y responses.
- `Negocio/`: Lógica de negocio para cada caso de uso.
- `AccesoADatos/`: Lectura y escritura de archivos JSON (sin listas instanciadas).
- `Presentacion/`: Archivos HTML requeridos para interacción básica.
- `Tests/`: Pruebas unitarias de la aplicación.

---

## ✨ Funcionalidades Principales

### 🔹 Gestión de Productos
- Alta de productos con POST.
- Actualización de stock con PUT `/producto/:id_producto`.
- Validaciones completas en el alta.

### 🔹 Gestión de Clientes
- Alta, baja lógica, modificación y listado de clientes.
- Validación obligatoria de todos los campos.
- Datos almacenados en archivo JSON.

### 🔹 Gestión de Camionetas
- Carga fija desde archivo JSON.
- No se realiza ABM, solo lectura.

### 🔹 Gestión de Compras
- Alta de compras con validación de stock.
- Cálculo de monto total con IVA (21%) y descuento por cantidad (> 4 unidades).
- Cambio de estado a `READY_TO_DISPATCH` cuando se asigna un viaje.

### 🔹 Gestión de Viajes
- Endpoint POST que recibe fechas `desde` y `hasta`.
- Asignación automática de camiones disponibles según distancia y carga.
- Reprogramación automática (+14 días) de entregas no asignadas.

---

## 🖥️ HTML y Funcionalidades Visuales

- Página de productos con stock bajo mínimo.
- Página para actualizar stock (formulario).
- Alta de compras nuevas (formulario y validación).
- Página para ejecutar proceso de asignación de viajes.

---

## 🧪 Pruebas

- Se realizaron al menos 8 tests unitarios.
- Incluye test de asignación de camiones a viajes.
- Lógica cubierta por capas específicas de negocio.

---

## 📌 Notas Técnicas

- Todos los datos se persisten mediante archivos `.json`.
- Las eliminaciones son **lógicas** (fecha de eliminación, no eliminación física).
- Todas las entidades tienen: `FechaCreacion`, `FechaEliminacion` y `FechaModificacion`.
- El sistema está diseñado para escalar funcionalidades fácilmente.
- El código sigue principios de separación de responsabilidades.

---

## 🧑‍🤝‍🧑 Equipo de Trabajo

- Ayala, Nereo  
- Bertone, Zoe  
- Stoffel, Francisco

