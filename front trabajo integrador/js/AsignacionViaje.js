document.getElementById('Asignacion-Viaje').addEventListener('submit', function (event) {
    event.preventDefault();
    const fechaDesde = document.getElementById('fecha-desde').value;
    const fechaHasta = document.getElementById('fecha-hasta').value;
    const datos = {
        FechaEntregaDesde: fechaDesde,
        FechaEntregaHasta: fechaHasta
    };
    fetch('http://localhost:5247/Viaje/AgregarViaje', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    })
    
    .then(response => {
        if (!response.ok) {
            // Si la respuesta no es exitosa, intenta obtener el cuerpo del error
            return response.json().then(body => {
                // Verifica si hay errores en el cuerpo de la respuesta
                if (body && body[""]) {
                    // Muestra todos los mensajes de error en un alert
                    alert('Errores:\n' + body[""].join('\n'));
                } else {
                    alert("Se ha producido un error desconocido.");
                }
                throw new Error('Errores en la solicitud'); // Lanza un error para manejar el catch
            });
        }

        // Si la respuesta es exitosa, maneja el resultado
        return response.json(); 
    })
    .then(data => {
        alert(data.mensaje );
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });


});

