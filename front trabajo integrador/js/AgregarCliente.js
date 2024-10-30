/*document.addEventListener("DOMContentLoaded", function(event) {
    console.info("Pruebas")
});
document.getElementById('clienteForm').addEventListener('submit', function (event) {
    event.preventDefault();
    const dni = document.getElementById('dni').value;
    const nombre = document.getElementById('nombre').value;
    const apellido = document.getElementById('apellido').value;
    const email = document.getElementById('email').value;
    const telefono = document.getElementById('telefono').value;
    const latitud = document.getElementById('latitud').value;
    const longitud = document.getElementById('longitud').value;
    const fechaNacimiento = document.getElementById('fecha_nacimiento').value;
    console.log('Datos obtenidos:' ,dni, nombre, apellido, email, telefono, latitud, longitud, fechaNacimiento);
    const datos = {
        DniCliente: dni,
        nombre: nombre,
        apellido: apellido,
        email: email,
        telefono: telefono,
        latitud: latitud,
        longitud: longitud,
        fechaNacimiento: fechaNacimiento
    };
    fetch('http://localhost:5247/Cliente/AgregarCliente', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    })
 
  .then(response => response.text()) 

    .then(data => {
        alert(data); // Muestra el mensaje de éxito
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });
   
   
});*/


    function llenarTablaclientes() {
        fetch(`http://localhost:5247/api/Clientes`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error en la red');
                }
                return response.json();
            })
            .then(data => {
                const tablaclientes = document.getElementById('tabla-clientes');
                tablaclientes.innerHTML = '';

                data.forEach(cliente => {
                    const fecha_nacimiento = new Date(cliente.fechaNacimiento).toLocaleDateString();
                    const fila = document.createElement('tr');
                    fila.innerHTML = `
                    <td>${cliente.dniCliente}</td>
                    <td>${cliente.nombre}</td>
                    <td>${cliente.apellido}</td>
                    <td>${cliente.email}</td>
                    <td>${cliente.telefono}</td>
                    <td>${cliente.latitud}</td>
                    <td>${cliente.longitud}</td>
                    <td>${fecha_nacimiento}</td>`;
                    tablaclientes.appendChild(fila);
                });
            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });


    }

    document.addEventListener("DOMContentLoaded", llenarTablaclientes);
