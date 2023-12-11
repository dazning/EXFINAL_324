<?php

session_start();
$ci=$_SESSION["ci"];

// Crear una conexión a la base de datos
$conexion = new mysqli("localhost", "u324", "123456", "academicofinal");

// Verificar la conexión
if ($conexion->connect_error) {
    die("Error de conexión a la base de datos: " . $conexion->connect_error);
}

// Realizar la consulta para obtener los datos de la tabla
$query = "SELECT * FROM archivos_pdf where nombre_archivo = 'informe_de_kardex'";
$resultado = $conexion->query($query);

// Verificar si la consulta fue exitosa
if (!$resultado) {
    die("Error al obtener los datos: " . $conexion->error);
}

// Mostrar los datos en una tabla HTML
echo "<table border='1' align='center'>
        <tr>
            <h1 align='center'>INFORME DE KARDEX</h1>
        </tr>
        <tr>
            <th>ID</th>
            <th>nombre</th>
            <th>Descargar</th>
        </tr>";

while ($fila = $resultado->fetch_assoc()) {
    echo "<tr>
            <td>{$fila['id']}</td>
            <td>{$fila['nombre_archivo']}</td>
            <td><a href='data:application/pdf;base64," . base64_encode($fila['nombre_archivo']) . "' download='{$fila['nombre_archivo']}'>{$fila['nombre_archivo']}</a></td>
          </tr>";
}
echo "</table>";


$conexion->close();
?>


