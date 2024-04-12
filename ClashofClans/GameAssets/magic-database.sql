-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 26, 2021 at 06:51 PM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `magic-database`
--

-- --------------------------------------------------------

--
-- Table structure for table `alliances`
--

CREATE TABLE `alliances` (
  `Id` bigint(20) NOT NULL,
  `Name` text NOT NULL,
  `Trophies` bigint(20) NOT NULL,
  `RequiredTrophies` bigint(20) NOT NULL,
  `Type` bigint(20) NOT NULL,
  `Region` text NOT NULL,
  `Data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `Id` bigint(20) NOT NULL,
  `IsOnline` tinyint(1) NOT NULL,
  `Trophies` bigint(20) NOT NULL,
  `PreviousSeasonMonth` bigint(20) NOT NULL,
  `PreviousSeasonTrophies` bigint(20) NOT NULL,
  `Language` text NOT NULL,
  `FacebookId` text DEFAULT NULL,
  `Home` text NOT NULL,
  `Objects` text NOT NULL,
  `Sessions` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for table `alliances`
--
ALTER TABLE `alliances`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
