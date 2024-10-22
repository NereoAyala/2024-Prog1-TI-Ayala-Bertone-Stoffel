
document.addEventListener("DOMContentLoaded", function(event) {
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

    .then(response => response.json())
    .then(data => {
        console.log(data);
       
        alert(data.mensaje);
    })
    .catch(error => {
        console.log('Error:', error);
    });
        
               

    console.log('Datos enviados:', datos);

    
});
