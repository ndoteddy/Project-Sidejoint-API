-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 20, 2021 at 01:56 PM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbsidejoint`
--

-- --------------------------------------------------------

--
-- Table structure for table `masteritems`
--

DROP TABLE IF EXISTS `masteritems`;
CREATE TABLE IF NOT EXISTS `masteritems` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `todayopenvalue` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `masteritems`
--

INSERT INTO `masteritems` (`id`, `name`, `email`, `todayopenvalue`) VALUES
(1, 'NANDOZ', 'admin@nandoz.co.ltd', '200000'),
(2, 'CHICKEN', 'admin@momo.co.ltd', '100000');

-- --------------------------------------------------------

--
-- Table structure for table `pricetracker`
--

DROP TABLE IF EXISTS `pricetracker`;
CREATE TABLE IF NOT EXISTS `pricetracker` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `itemid` int(11) NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `createdat` timestamp NOT NULL,
  `createdby` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=120 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pricetracker`
--

INSERT INTO `pricetracker` (`id`, `itemid`, `price`, `createdat`, `createdby`) VALUES
(1, 1, '250000', '2021-06-03 08:31:18', 1),
(2, 1, '178000', '2021-06-03 08:31:18', 1),
(3, 1, '230000', '2020-01-10 02:01:02', 1),
(4, 1, '100000', '2020-01-10 02:01:02', 1),
(5, 1, '110000', '2020-01-10 02:01:02', 1),
(6, 2, '120000', '2020-01-10 02:01:02', 1),
(7, 2, '115000', '2020-01-10 02:01:02', 1),
(8, 1, '12000', '2020-01-10 02:01:02', 1),
(9, 1, '12000', '2020-01-10 02:01:02', 1),
(10, 2, '12000', '2020-01-10 02:01:02', 1),
(11, 2, '12000', '2020-01-10 02:01:02', 1),
(12, 2, '12000', '2020-01-10 02:01:02', 1),
(13, 2, '10000', '2020-01-10 02:01:02', 1),
(14, 2, '410000', '2020-01-10 02:01:02', 1),
(15, 2, '4100000', '2020-01-10 02:01:02', 1),
(16, 2, '10000', '2020-01-10 02:01:02', 1),
(17, 2, '30000', '2020-01-10 02:01:02', 1),
(18, 1, '30000', '2020-01-10 02:01:02', 1),
(19, 1, '30000', '2020-01-10 02:01:02', 1),
(20, 1, '10000', '2020-01-10 02:01:02', 1),
(21, 1, '12000', '2020-01-10 02:01:02', 1),
(22, 1, '12000', '2020-01-10 02:01:02', 1),
(23, 1, '12000', '2020-01-10 02:01:02', 1),
(24, 1, '12000', '2020-01-10 02:01:02', 1),
(25, 1, '12000', '2020-01-10 02:01:02', 1),
(26, 1, '12000', '2020-01-10 02:01:02', 1),
(27, 1, '143731', '2021-06-20 10:33:02', 1),
(28, 1, '111467', '2021-06-20 10:33:04', 1),
(29, 1, '114090', '2021-06-20 10:33:05', 1),
(30, 1, '114950', '2021-06-20 10:33:07', 1),
(31, 1, '105851', '2021-06-20 10:33:08', 1),
(32, 1, '142675', '2021-06-20 10:33:37', 1),
(33, 1, '139631', '2021-06-20 10:35:26', 1),
(34, 1, '113640', '2021-06-20 10:35:39', 1),
(35, 2, '149667', '2021-06-20 10:36:58', 1),
(36, 2, '117246', '2021-06-20 10:37:14', 1),
(37, 1, '141486', '2021-06-20 10:37:15', 1),
(38, 1, '104959', '2021-06-20 10:37:22', 1),
(39, 2, '115765', '2021-06-20 10:37:24', 1),
(40, 2, '115422', '2021-06-20 10:37:26', 1),
(41, 1, '131156', '2021-06-20 10:37:28', 1),
(42, 2, '131564', '2021-06-20 10:37:28', 1),
(43, 2, '119369', '2021-06-20 10:37:29', 1),
(44, 2, '132004', '2021-06-20 10:37:29', 1),
(45, 2, '102008', '2021-06-20 10:37:30', 1),
(46, 1, '113479', '2021-06-20 10:37:30', 1),
(47, 2, '102307', '2021-06-20 10:37:31', 1),
(48, 1, '105839', '2021-06-20 10:37:33', 1),
(49, 1, '139123', '2021-06-20 10:37:34', 1),
(50, 2, '111554', '2021-06-20 10:37:36', 1),
(51, 2, '104053', '2021-06-20 10:37:37', 1),
(52, 1, '131924', '2021-06-20 10:37:39', 1),
(53, 2, '103425', '2021-06-20 10:37:40', 1),
(54, 1, '105744', '2021-06-20 10:37:41', 1),
(55, 2, '131614', '2021-06-20 10:37:43', 1),
(56, 2, '137531', '2021-06-20 10:37:47', 1),
(57, 1, '132582', '2021-06-20 10:37:50', 1),
(58, 2, '113153', '2021-06-20 10:37:51', 1),
(59, 2, '118858', '2021-06-20 10:37:54', 1),
(60, 2, '117005', '2021-06-20 10:37:55', 1),
(61, 2, '117110', '2021-06-20 10:37:58', 1),
(62, 1, '136005', '2021-06-20 10:37:58', 1),
(63, 1, '113518', '2021-06-20 10:38:00', 1),
(64, 2, '137968', '2021-06-20 10:38:02', 1),
(65, 1, '116124', '2021-06-20 10:38:03', 1),
(66, 2, '107852', '2021-06-20 10:46:52', 1),
(67, 1, '136467', '2021-06-20 10:46:54', 1),
(68, 2, '140125', '2021-06-20 10:46:55', 1),
(69, 1, '101507', '2021-06-20 10:46:58', 1),
(70, 2, '132611', '2021-06-20 10:46:59', 1),
(71, 1, '109139', '2021-06-20 10:47:00', 1),
(72, 2, '104689', '2021-06-20 10:47:01', 1),
(73, 1, '122824', '2021-06-20 10:47:01', 1),
(74, 2, '110649', '2021-06-20 10:47:02', 1),
(75, 2, '131424', '2021-06-20 10:47:03', 1),
(76, 1, '107098', '2021-06-20 10:47:05', 1),
(77, 1, '103290', '2021-06-20 10:47:06', 1),
(78, 2, '137863', '2021-06-20 10:47:07', 1),
(79, 2, '121258', '2021-06-20 10:47:08', 1),
(80, 2, '125920', '2021-06-20 10:47:09', 1),
(81, 2, '145907', '2021-06-20 10:47:10', 1),
(82, 2, '118484', '2021-06-20 10:47:11', 1),
(83, 1, '127136', '2021-06-20 10:47:13', 1),
(84, 2, '108330', '2021-06-20 10:47:13', 1),
(85, 1, '146663', '2021-06-20 10:47:15', 1),
(86, 2, '146135', '2021-06-20 10:47:16', 1),
(87, 2, '101249', '2021-06-20 10:47:17', 1),
(88, 2, '130564', '2021-06-20 10:47:19', 1),
(89, 1, '141922', '2021-06-20 10:47:20', 1),
(90, 1, '106031', '2021-06-20 10:47:20', 1),
(91, 2, '119469', '2021-06-20 10:47:21', 1),
(92, 1, '139655', '2021-06-20 10:47:21', 1),
(93, 2, '144581', '2021-06-20 10:47:21', 1),
(94, 2, '129010', '2021-06-20 10:47:21', 1),
(95, 2, '109384', '2021-06-20 10:47:21', 1),
(96, 1, '107314', '2021-06-20 10:47:22', 1),
(97, 1, '145123', '2021-06-20 10:47:22', 1),
(98, 2, '106338', '2021-06-20 10:47:23', 1),
(99, 1, '138344', '2021-06-20 10:47:23', 1),
(100, 1, '127069', '2021-06-20 10:47:23', 1),
(101, 1, '106317', '2021-06-20 10:47:24', 1),
(102, 2, '114298', '2021-06-20 10:47:24', 1),
(103, 2, '145639', '2021-06-20 10:47:54', 1),
(104, 1, '108566', '2021-06-20 10:49:41', 1),
(105, 1, '121558', '2021-06-20 10:49:43', 1),
(106, 2, '119636', '2021-06-20 10:49:45', 1),
(107, 2, '101320', '2021-06-20 10:49:48', 1),
(108, 2, '141841', '2021-06-20 10:49:49', 1),
(109, 2, '128020', '2021-06-20 10:49:51', 1),
(110, 1, '141863', '2021-06-20 10:49:53', 1),
(111, 2, '105001', '2021-06-20 10:49:55', 1),
(112, 2, '137696', '2021-06-20 10:49:57', 1),
(113, 2, '138760', '2021-06-20 10:49:59', 1),
(114, 2, '114510', '2021-06-20 11:21:18', 1),
(115, 2, '102132', '2021-06-20 11:21:20', 1),
(116, 2, '100811', '2021-06-20 11:21:21', 1),
(117, 1, '147068', '2021-06-20 11:21:23', 1),
(118, 1, '104219', '2021-06-20 11:21:34', 1),
(119, 1, '127572', '2021-06-20 11:21:36', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
