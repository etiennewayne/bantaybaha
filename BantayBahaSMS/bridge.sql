/*
SQLyog Ultimate v12.14 (64 bit)
MySQL - 10.1.32-MariaDB : Database - bridge
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bridge` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bridge`;

/*Table structure for table `measures` */

DROP TABLE IF EXISTS `measures`;

CREATE TABLE `measures` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `distance` int(11) NOT NULL,
  `nDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=569 DEFAULT CHARSET=latin1;

/*Data for the table `measures` */

insert  into `measures`(`id`,`distance`,`nDate`) values 
(568,46,'2020-01-26 17:25:12'),
(567,40,'2020-01-26 17:24:56'),
(566,43,'2020-01-26 17:24:48'),
(565,45,'2020-01-26 17:23:53'),
(564,0,'2020-01-26 17:23:33'),
(562,45,'2020-01-26 17:23:05'),
(561,61,'2020-01-26 17:22:17'),
(560,60,'2020-01-26 17:22:06'),
(559,45,'2020-01-26 17:21:57'),
(558,42,'2020-01-26 17:21:50'),
(557,41,'2020-01-26 17:21:00'),
(556,40,'2020-01-26 17:20:44'),
(555,19,'2020-01-26 17:18:23'),
(554,0,'2020-01-26 12:36:49'),
(553,24,'2020-01-26 12:00:33'),
(552,20,'2020-01-26 12:00:28'),
(551,43,'2020-01-26 12:00:13'),
(550,20,'2020-01-26 11:59:39'),
(549,0,'2020-01-26 11:59:21'),
(548,25,'2020-01-26 11:58:16'),
(547,20,'2020-01-26 11:57:42'),
(546,0,'2020-01-15 23:58:50'),
(545,0,'2020-01-15 23:58:42'),
(544,0,'2020-01-15 23:58:35'),
(543,0,'2020-01-15 23:58:27'),
(542,0,'2020-01-15 23:58:19'),
(541,0,'2020-01-15 23:58:11'),
(540,0,'2020-01-15 23:58:04'),
(539,0,'2020-01-15 23:57:56'),
(538,0,'2020-01-15 23:57:48'),
(537,0,'2020-01-15 23:57:40'),
(536,0,'2020-01-15 23:57:33'),
(535,0,'2020-01-15 23:57:25'),
(534,0,'2020-01-15 23:57:17'),
(533,0,'2020-01-15 23:57:09'),
(532,65,'2020-01-15 23:57:00'),
(531,40,'2020-01-15 23:56:42'),
(530,36,'2020-01-15 23:56:39'),
(529,0,'2020-01-15 23:56:31'),
(528,27,'2020-01-15 23:56:28'),
(527,28,'2020-01-15 23:56:24'),
(526,42,'2020-01-15 23:56:06'),
(525,44,'2020-01-15 23:55:48'),
(524,0,'2020-01-15 23:55:40'),
(523,43,'2020-01-15 23:55:29'),
(522,0,'2020-01-15 23:55:11'),
(521,0,'2020-01-15 23:55:04'),
(520,0,'2020-01-15 23:54:56'),
(519,0,'2020-01-15 23:54:48'),
(518,0,'2020-01-15 23:54:40'),
(517,0,'2020-01-15 23:54:33'),
(516,25,'2020-01-15 23:54:29'),
(515,32,'2020-01-15 23:54:25'),
(514,27,'2020-01-15 23:54:22'),
(513,59,'2020-01-15 23:54:14'),
(512,70,'2020-01-15 23:54:05'),
(511,51,'2020-01-15 23:53:44'),
(510,0,'2020-01-15 23:53:25'),
(509,0,'2020-01-15 23:52:41'),
(508,0,'2020-01-15 23:52:33'),
(507,0,'2020-01-15 23:52:26'),
(506,0,'2020-01-15 23:52:18'),
(505,0,'2020-01-15 23:52:10'),
(504,0,'2020-01-15 23:51:50'),
(503,0,'2020-01-15 23:51:29'),
(502,0,'2020-01-15 23:51:22'),
(501,0,'2020-01-15 23:51:14'),
(500,0,'2020-01-15 23:51:05'),
(499,0,'2020-01-15 23:50:57'),
(498,0,'2020-01-15 23:50:49'),
(497,0,'2020-01-15 23:50:42'),
(496,0,'2020-01-15 23:50:34'),
(495,0,'2020-01-15 23:50:25'),
(494,0,'2020-01-15 23:50:17'),
(493,0,'2020-01-15 23:49:55'),
(492,0,'2020-01-15 23:49:47'),
(491,0,'2020-01-15 23:49:39'),
(490,1,'2020-01-15 23:48:07');

/*Table structure for table `messages` */

DROP TABLE IF EXISTS `messages`;

CREATE TABLE `messages` (
  `messageID` int(11) NOT NULL AUTO_INCREMENT,
  `mobileNo` varchar(20) DEFAULT '',
  `msg` varchar(255) DEFAULT '',
  `isSent` tinyint(1) DEFAULT '0',
  `dateTimeSent` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `dateTimeLog` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`messageID`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=latin1;

/*Data for the table `messages` */

insert  into `messages`(`messageID`,`mobileNo`,`msg`,`isSent`,`dateTimeSent`,`dateTimeLog`) values 
(112,'+639167789585','Water level is now in high.',1,'2020-01-26 17:21:06','2020-01-26 17:21:06'),
(113,'+639078767814','Water level is now in high.',1,'2020-01-26 17:21:11','2020-01-26 17:21:11'),
(114,'+639120636277','Water level is now in high.',1,'2020-01-26 17:21:16','2020-01-26 17:21:16'),
(115,'+639487595475','Water level is now in high.',1,'2020-01-26 17:21:21','2020-01-26 17:21:21'),
(116,'+639167789585','Water level is critical. Force evacuation will be implemented.',1,'2020-01-26 17:22:26','2020-01-26 17:22:26'),
(117,'+639078767814','Water level is critical. Force evacuation will be implemented.',1,'2020-01-26 17:22:31','2020-01-26 17:22:31'),
(118,'+639120636277','Water level is critical. Force evacuation will be implemented.',1,'2020-01-26 17:22:36','2020-01-26 17:22:36'),
(119,'+639487595475','Water level is critical. Force evacuation will be implemented.',1,'2020-01-26 17:22:41','2020-01-26 17:22:41'),
(120,'+639167789585','Water level is now in high.',1,'2020-01-26 17:24:03','2020-01-26 17:24:03'),
(121,'+639078767814','Water level is now in high.',1,'2020-01-26 17:24:08','2020-01-26 17:24:08'),
(122,'+639120636277','Water level is now in high.',1,'2020-01-26 17:24:13','2020-01-26 17:24:13'),
(123,'+639487595475','Water level is now in high.',1,'2020-01-26 17:24:18','2020-01-26 17:24:18'),
(124,'+639167789585','Water level is now in high.',1,'2020-01-26 17:25:23','2020-01-26 17:25:23'),
(125,'+639078767814','Water level is now in high.',1,'2020-01-26 17:25:28','2020-01-26 17:25:28'),
(126,'+639120636277','Water level is now in high.',1,'2020-01-26 17:25:33','2020-01-26 17:25:33'),
(127,'+639487595475','Water level is now in high.',1,'2020-01-26 17:25:38','2020-01-26 17:25:38'),
(128,'+639167789585','Water level is now in high.',1,'2020-01-26 17:27:08','2020-01-26 17:27:08'),
(129,'+639078767814','Water level is now in high.',1,'2020-01-26 17:33:27','2020-01-26 17:33:27'),
(130,'+639120636277','Water level is now in high.',1,'2020-01-26 17:33:52','2020-01-26 17:33:52'),
(131,'+639487595475','Water level is now in high.',1,'2020-01-26 17:40:07','2020-01-26 17:40:07'),
(132,'+639167789585','Water level is now in high.',1,'2020-01-26 17:39:37','2020-01-26 17:39:37'),
(133,'+639078767814','Water level is now in high.',1,'2020-01-26 17:37:00','2020-01-26 17:37:00'),
(134,'+639120636277','Water level is now in high.',1,'2020-01-26 17:37:24','2020-01-26 17:37:24'),
(135,'+639487595475','Water level is now in high.',1,'2020-01-26 17:37:44','2020-01-26 17:37:44');

/*Table structure for table `phonebook` */

DROP TABLE IF EXISTS `phonebook`;

CREATE TABLE `phonebook` (
  `phonebookID` int(11) NOT NULL AUTO_INCREMENT,
  `lname` varchar(30) DEFAULT '',
  `fname` varchar(30) DEFAULT '',
  `mname` varchar(30) DEFAULT '',
  `gender` varchar(10) DEFAULT '',
  `contactNo` varchar(20) DEFAULT '',
  PRIMARY KEY (`phonebookID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `phonebook` */

insert  into `phonebook`(`phonebookID`,`lname`,`fname`,`mname`,`gender`,`contactNo`) values 
(2,'AMPARADO','','','MALE','+639167789585'),
(4,'CANLO','','','MALE','+639078767814'),
(5,'DUERME','','','FEMALE','+639120636277'),
(6,'CABASAG','','','FEMALE','+639487595475');

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) DEFAULT '',
  `pwd` varchar(30) DEFAULT '',
  `lname` varchar(30) DEFAULT '',
  `fname` varchar(30) DEFAULT '',
  `mname` varchar(30) DEFAULT '',
  `position` varchar(30) DEFAULT '',
  `gender` varchar(10) DEFAULT '',
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `users` */

insert  into `users`(`userid`,`username`,`pwd`,`lname`,`fname`,`mname`,`position`,`gender`) values 
(1,'admin','admin','canulo','jc','','ADMINISTRATOR','MALE');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
