
document.getElementById('formulario-actualizar-stock').addEventListener('submit', function (event) {
    event.preventDefault();  
    const id = document.getElementById('id').value;
    const stock = document.getElementById('stock').value;
    console.log('Datos obtenidos:', id, stock);
    fetch(`http://localhost:5247/Producto/ActualizarStock/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(stock) 
    })
        .then(response => response.text())
        .then(data => {
        
                console.log("Respuesta recibida:", data);
                alert(data)
        })
            .catch(error => {
                // Manejo de errores
                console.error("Ocurrió un error:", error.message);
            });
            

           
            
        
        
    console.log('Datos enviados:', id, stock);
});