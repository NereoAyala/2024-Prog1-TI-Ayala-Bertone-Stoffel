/*const formulario = document.getElementById('VerStock');
const tablaproductos = document.getElementById('TablaStock');

formularioStock.addEventListener('submit', function (event) {
    event.preventDefault();

    const limiteStock = document.getElementById('limiteStock').value;


    function llenarTablaStock() {
        fetch(`http://localhost:5247/Producto/FiltrarProductos?limite=${limiteStock}`)


            .then(response => response.json())
            .then(data => {
                var tablaproductos = document.getElementById('TablaStock');


                tablaproductos.innerHTML = '';
                data.forEach(producto => {
                    var fila = document.createElement('tr');
                    fila.innerHTML =

                        `
                    <td>${producto.nombre}</td>
                    <td>${producto.stockDisponible}</td>
                    <td>${producto.stockMinimo}</td>`;
                    tablaproductos.appendChild(fila);

                });

            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });

    }

    // Llama a la función para llenar la tabla cuando el DOM esté listo
    document.addEventListener("DOMContentLoaded", llenarTablaStock);
});*/
const formularioStock = document.getElementById('VerStock');
const tablaproductos = document.getElementById('TablaStock');

formularioStock.addEventListener('submit', function (event) {
    event.preventDefault(); // Evita el comportamiento por defecto del formulario

    // Obtén el límite de stock ingresado por el usuario
    const limiteStock = document.getElementById('limiteStock').value;

    // Llama a la función para llenar la tabla con los productos filtrados
    llenarTablaStock(limiteStock);
});

// Función para llenar la tabla de stock
function llenarTablaStock(limiteStock) {
    fetch(`http://localhost:5247/Producto/FiltrarProductos?limite=${limiteStock}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la red');
            }
            return response.json();
        })
        .then(data => {
            tablaproductos.innerHTML = ''; // Limpiar la tabla antes de llenarla

            // Llenar la tabla con los productos filtrados
            data.forEach(producto => {
                const fila = document.createElement('tr');
                fila.innerHTML = `
                    <td>${producto.nombre}</td>
                    <td>${producto.stockDisponible}</td>
                    <td>${producto.stockMinimo}</td>
                `;
                tablaproductos.appendChild(fila);
            });
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
}
