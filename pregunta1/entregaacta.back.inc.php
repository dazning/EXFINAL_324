<?php
session_start();
$ci = $_SESSION["ci"];

// Establecer la conexión a la base de datos
$conexion = new mysqli("localhost", "u324", "123456", "academicofinal");

// Verificar la conexión
if ($conexion->connect_error) {
    die("Error de conexión a la base de datos: " . $conexion->connect_error);
}

if (isset($_GET["pdf1"])) {
    // Obtener el contenido del archivo PDF desde la URL
    $base64_pdf1 = $_GET["pdf1"];
    
    // Decodificar el archivo PDF desde base64
    $contenido_pdf1 = base64_decode($base64_pdf1);

    // Verificar si la decodificación fue exitosa
    if ($contenido_pdf1 !== false) {
        // Preparar la consulta SQL
        $consulta = $conexion->prepare("INSERT INTO entrega_de_actas (ci, archivo_pdf) VALUES (?, ?)");
        $consulta->bind_param("ss", $ci, $contenido_pdf1);  // El tipo de dato de archivo_pdf es VARCHAR, no boolean

        // Ejecutar la consulta
        if ($consulta->execute()) {
            echo "El archivo PDF 1 se ha guardado correctamente en la base de datos.";
        } else {
            echo "Error al guardar el archivo PDF 1 en la base de datos: " . $conexion->error;
        }

        // Cerrar la consulta
        $consulta->close();
    } else {
        echo "Error al decodificar el archivo PDF desde base64.";
    }
} else {
    echo "Error: No se proporcionó el archivo PDF.";
}

// Cerrar la conexión a la base de datos
$conexion->close();
?>
