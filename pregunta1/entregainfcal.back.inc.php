<?php
session_start();
$ci = $_SESSION["ci"];

// Establecer la conexión a la base de datos
$conexion = new mysqli("localhost", "u324", "123456", "academicofinal");

// Verificar la conexión
if ($conexion->connect_error) {
    die("Error de conexión a la base de datos: " . $conexion->connect_error);
}

if (isset($_GET["pdf1"]) && isset($_GET["pdf2"])) {
    // Obtener el contenido de los archivos PDF desde la URL
    $base64_pdf1 = $_GET["pdf1"];
    $base64_pdf2 = $_GET["pdf2"];

    // Decodificar los archivos PDF desde base64
    $contenido_pdf1 = base64_decode($base64_pdf1);
    $contenido_pdf2 = base64_decode($base64_pdf2);

    // Preparar la consulta SQL
    $sql = "INSERT INTO entrega_archivos_pdf (ci, pdf1, pdf2) VALUES (?, ?, ?)";

    // Preparar la declaración
    $stmt = $conexion->prepare($sql);

    // Vincular parámetros
    $stmt->bind_param("iss", $ci, $contenido_pdf1, $contenido_pdf2);

    // Ejecutar la consulta
    if ($stmt->execute()) {
        echo "Los archivos PDF se subieron y guardaron en la base de datos correctamente.";
    } else {
        echo "Error al subir y guardar los archivos PDF: " . $stmt->error;
    }

    // Cerrar la declaración
    $stmt->close();
} else {
    echo "Error al subir los archivos. Asegúrate de proporcionar ambos archivos PDF.";
}

// Cerrar la conexión a la base de datos
$conexion->close();
?>
