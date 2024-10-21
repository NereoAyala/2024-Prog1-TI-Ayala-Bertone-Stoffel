
document.getElementById('cargar-compra-form').addEventListener('submit', function(event) {
    event.preventDefault();

    const id = document.getElementById('id').value;
    const cantidad = document.getElementById('cantidad').value;
    const fecha = document.getElementById('fecha_entrega').value;

    console.log('Datos obtenidos:', id, cantidad, fecha);

    const datos = {
        id: id,
        cantidad: cantidad,
        fecha_entrega: fecha
    };

});