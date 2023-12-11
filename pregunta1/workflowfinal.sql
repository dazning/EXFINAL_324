-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 11-12-2023 a las 09:25:33
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `workflowfinal`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujo`
--

CREATE TABLE `flujo` (
  `flujo` varchar(20) DEFAULT NULL,
  `proceso` varchar(20) DEFAULT NULL,
  `proceso_siguiente` varchar(20) DEFAULT NULL,
  `tipo` varchar(20) DEFAULT NULL,
  `rol` varchar(20) DEFAULT NULL,
  `pantalla` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `flujo`
--

INSERT INTO `flujo` (`flujo`, `proceso`, `proceso_siguiente`, `tipo`, `rol`, `pantalla`) VALUES
('F1', 'P1', 'P2', 'D', 'estudiante', 'calificaciones'),
('F1', 'P2', 'P3', 'D', 'estudiante', 'informekardex'),
('F1', 'P3', 'P4', 'E', 'estudiante', 'entregainfcal'),
('F1', 'P4', 'P5', 'R', 'estudiante', 'requisitosGAR'),
('F1', 'P5', 'P6', 'E', 'estudiante', 'envioinformacion'),
('F1', 'P6', 'P7', 'R', 'estudiante', 'recepcion'),
('F1', 'P7', 'P8', 'D', 'estudiante', 'defensa'),
('F1', 'P8', 'P9', 'E', 'estudiante', 'entregaacta'),
('F1', 'P9', 'P10', 'P', 'estudiante', 'legayemision'),
('F1', 'P10', 'P10', 'E', 'estudiante', 'entrega');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seguimiento`
--

CREATE TABLE `seguimiento` (
  `secuencia` int(11) NOT NULL,
  `usuario` varchar(20) DEFAULT NULL,
  `fecha_de_inicio` datetime DEFAULT NULL,
  `fecha_fin` datetime DEFAULT NULL,
  `flujo` varchar(20) DEFAULT NULL,
  `proceso` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `seguimiento`
--
ALTER TABLE `seguimiento`
  ADD PRIMARY KEY (`secuencia`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
