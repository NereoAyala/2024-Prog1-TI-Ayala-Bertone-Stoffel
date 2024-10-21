

document.getElementById('formulario-actualizar-stock').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevenir el envío del formulario normal

    // Obtener los valores de los campos
    const id = document.getElementById('id').value;
    const stock = document.getElementById('stock').value;
    //agregar un console.log para verificar que los datos se estan obteniendo correctamente
    console.log('Datos obtenidos:', id, stock);

    // Crear un objeto con los datos
    const datos = {
        id: id,
        stockNuevo: stock
    };

    // Enviar los datos a una API REST (sustituye la URL por la de tu API)
    fetch('http://localhost:5247/Producto/ActualizarStock', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)

        
    })
    
        .then(response => response.json())
        .then(data => {
              // Manejar la respuesta de la API aquí
        console.log('Respuesta de la API:', data);
        alert('Registro exitoso');
    })
    .catch(error => {
        // Manejar errores aquí
        console.error('Error al enviar los datos:', error);
        alert('Hubo un error al procesar el registro');
    });

    console.log('Datos enviados:', datos);
});