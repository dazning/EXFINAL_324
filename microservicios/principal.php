<?php
	include 'conexion.php';
	
	$pdo = new Conexion();
	
	//Listar registros y consultar registro
	if($_SERVER['REQUEST_METHOD'] == 'GET')
	{
		if (isset($_GET["id"]))
		{
			$sqlp="SELECT * FROM docente where id=:id";
			$sql = $pdo->prepare($sqlp);
			$sql->bindValue(':id', $_GET["id"]);
			$sql->execute();
			$sql->setFetchMode(PDO::FETCH_ASSOC);
			echo json_encode($sql->fetchAll());
			header("HTTP/1.1 200 hay datos");		
			exit;		
		}
		else
		{
			$sqlp="SELECT * FROM docente";
			$sql = $pdo->prepare($sqlp);
			$sql->execute();
			$sql->setFetchMode(PDO::FETCH_ASSOC);
			echo json_encode($sql->fetchAll());
			header("HTTP/1.1 200 hay datos");
			exit;		
		}
			
	}
	
	//Insertar registro
	if($_SERVER['REQUEST_METHOD'] == 'POST')
	{
		$sqlp="insert into docente values(:id,:nombre,:apellido,:materia)";
		$sql = $pdo->prepare($sqlp);
		$sql->bindValue(':id', $_GET["id"]);
		$sql->bindValue(':nombre', $_GET["nombre"]);
		$sql->bindValue(':apellido', $_GET["apellido"]);
		$sql->bindValue(':materia', $_GET["materia"]);
		$sql->execute();
		echo json_encode('realizado');
		header("HTTP/1.1 200 ejecucion correcta");
		exit;
	}
	
	if ($_SERVER['REQUEST_METHOD'] == 'PUT') {
		$sqlp = "UPDATE docente SET nombre=:nombre, apellido=:apellido, materia=:materia WHERE id=:id";
		$sql = $pdo->prepare($sqlp);
		$sql->bindValue(':id', $_GET["id"]);  // Aquí, nuevamente, $_PUT es un valor inventado. Puedes usar $_REQUEST o $_POST según sea necesario.
		$sql->bindValue(':nombre', $_GET["nombre"]);
		$sql->bindValue(':apellido', $_GET["apellido"]);
		$sql->bindValue(':materia', $_GET["materia"]);
		$sql->execute();
		echo json_encode('realizado');
		header("HTTP/1.1 200 ejecucion correcta");
		exit;
	}
	
	
	if($_SERVER['REQUEST_METHOD'] == 'DELETE')
	{
		
		 $sqlp = "DELETE FROM docente WHERE id=:id";
		 $sql = $pdo->prepare($sqlp);
		 $sql->bindValue(':id', $_GET["id"]); 
		 $sql->execute();
		 echo json_encode('realizado');
		 header("HTTP/1.1 200 ejecucion correcta");
		 exit;
	}
	
	header("HTTP/1.1 400 Bad Request");
?>