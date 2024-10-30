
document.getElementById('formulario-actualizar-stock').addEventListener('submit', function (event) {
    event.preventDefault();
    const id = document.getElementById('id').value;
    const stock = document.getElementById('stock').value;
    console.log('Datos obtenidos:', id, stock);
    fetch(`http://localhost:5247/api/Productos/ActualizarStock/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stock)
    })
      
        .then(response => {
            if (!response.ok) {
                // Si la respuesta no es exitosa, lanza un error con el mensaje del backend
                return response.text().then(errorMessage => {
                    throw new Error(errorMessage || 'Error al actualizar el stock');
                });
            }
            return response.text(); // Si es exitosa, procesa la respuesta como texto
        })
        .then(successMessage => {
            // Muestra el mensaje de éxito del backend
            alert(successMessage || 'Stock actualizado con éxito');
        })
        .catch(error => {
            // Muestra el mensaje de error capturado
            alert(error.message || 'Error al actualizar el stock');
        });
});

