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
$query = "SELECT * FROM certificado_de_egreso";
$resultado = $conexion->query($query);

// Verificar si la consulta fue exitosa
if (!$resultado) {
    die("Error al obtener los datos: " . $conexion->error);
}

// Mostrar los datos en una tabla HTML
echo "<table border='1' align='center'>
        <tr>
            <h1 align='center'>1 Certificado de Grado con la 
            calificación, firmas y sellos</h1>
        </tr>
        <tr>
            <th>ID</th>
            <th>nombre</th>
            <th>Descargar</th>
        </tr>";

while ($fila = $resultado->fetch_assoc()) {
    echo "<tr>
            <td>{$fila['id']}</td>
            <td>{$fila['nombre']}</td>
            <td><a href='data:application/pdf;base64," . base64_encode($fila['nombre']) . "' download='{$fila['nombre']}'>{$fila['nombre']}</a></td>
          </tr>";
}
echo "</table>";


$conexion->close();
?>


