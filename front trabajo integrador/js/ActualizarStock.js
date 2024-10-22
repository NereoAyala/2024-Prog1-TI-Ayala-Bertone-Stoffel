

document.getElementById('formulario-actualizar-stock').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevenir el envío del formulario normal

    // Obtener los valores de los campos
    const id = document.getElementById('id').value;
    const stock = document.getElementById('stock').value;
    //agregar un console.log para verificar que los datos se estan obteniendo correctamente
    console.log('Datos obtenidos:', id, stock);

    // Enviar los datos a una API REST (sustituye la URL por la de tu API)
    fetch(`http://localhost:5247/Producto/ActualizarStock/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stock)

        
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