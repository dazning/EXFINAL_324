<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Formulario de Pagos</title>
</head>
<body>

<h2>Seleccione un tipo de pago:</h2>

<form action="backend.php" method="get">
    <?php
    session_start();
    $ci = $_SESSION["ci"];
    
    // Establecer la conexión a la base de datos
    $conexion = new mysqli("localhost", "u324", "123456", "academicofinal");
    
    // Verificar la conexión
    if ($conexion->connect_error) {
        die("Error de conexión a la base de datos: " . $conexion->connect_error);
    }
    // Obtener tipos de pago desde la base de datos
    $result = $conexion->query("SELECT id, nombre_pago, monto FROM pagos");

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            $id = $row["id"];
            $nombrePago = $row["nombre_pago"];
            $monto = $row["monto"];

            echo '<label>';
            echo '<input type="checkbox" name="tipo_pago[]" value="' . $id . '"> ' . $nombrePago . ' - Monto: $' . $monto;
            echo '</label><br>';
        }
    } else {
        echo "No hay tipos de pago disponibles.";
    }

    // Cerrar la conexión
    $conexion->close();
    ?>

    <br>
   


</body>
</html>
