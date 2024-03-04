-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: kino
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sale` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NazwaSali` varchar(255) DEFAULT NULL,
  `Dzien` varchar(50) DEFAULT NULL,
  `Godzina` varchar(50) DEFAULT NULL,
  `Film` varchar(255) DEFAULT NULL,
  `MiejscaZajete` text,
  `MiejscaWolne` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale`
--

LOCK TABLES `sale` WRITE;
/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
INSERT INTO `sale` VALUES (1,'Poniedziałek_10:00_Akademia Pana Kleksa','Poniedziałek','10:00','Akademia Pana Kleksa','Przycisk16,Przycisk17,Przycisk18,Przycisk10,Przycisk9,Przycisk8,Przycisk19,Przycisk29,Przycisk39,Przycisk40,Przycisk50,Przycisk49,Przycisk48,Przycisk38,Przycisk28,Przycisk30Przycisk29Przycisk28,Przycisk48,Przycisk47,Przycisk46,Przycisk27,Przycisk37,Przycisk26,Przycisk36,Przycisk25,Przycisk24,Przycisk23,Przycisk35,Przycisk34,Przycisk33',''),(2,'Poniedziałek_10:00_Aquaman i Zaginione Królestwo','Poniedziałek','10:00','Aquaman i Zaginione Królestwo',',Przycisk1,Przycisk40,Przycisk28,Przycisk27,Przycisk26,Przycisk39,Przycisk38,Przycisk37,Przycisk27,Przycisk38,Przycisk28,Przycisk29',''),(3,'Wtorek_10:00_Wonka','Wtorek','10:00','Wonka','Przycisk8,Przycisk7,Przycisk9,Przycisk8,Przycisk7,Przycisk9',''),(4,'Środa_20:00_Aquaman i Zaginione Królestwo','Środa','20:00','Aquaman i Zaginione Królestwo',',Przycisk18,Przycisk17,Przycisk16,Przycisk30,Przycisk29,Przycisk28',''),(5,'Poniedziałek_16:00_Akademia Pana Kleksa','Poniedziałek','16:00','Akademia Pana Kleksa','Przycisk30,Przycisk50,Przycisk38,Przycisk37,Przycisk36,Przycisk35,Przycisk45,Przycisk46,Przycisk47',''),(7,'Poniedziałek_10:00_Wonka','Poniedziałek','10:00','Wonka','Przycisk51,',NULL),(8,'Środa_17:00_Aquaman i Zaginione Królestwo','Środa','17:00','Aquaman i Zaginione Królestwo','Przycisk51,',NULL),(9,'Poniedziałek_10:00_Piep.zyć Mickiewicza','Poniedziałek','10:00','Piep.zyć Mickiewicza','Przycisk51,,Przycisk26,Przycisk27,Przycisk28,Przycisk50,Przycisk40',NULL),(10,'Piątek_20:00_Piep.zyć Mickiewicza','Piątek','20:00','Piep.zyć Mickiewicza','Przycisk51,',NULL),(11,'Wtorek_16:00_Akademia Pana Kleksa','Wtorek','16:00','Akademia Pana Kleksa',',Przycisk28,Przycisk27,Przycisk26,Przycisk25',NULL),(12,'Czwartek_10:00_Piep.zyć Mickiewicza','Czwartek','10:00','Piep.zyć Mickiewicza',',Przycisk28,Przycisk27,Przycisk26',NULL),(13,'Piątek_20:00_Aquaman i Zaginione Królestwo','Piątek','20:00','Aquaman i Zaginione Królestwo','Przycisk51,',NULL),(15,'Czwartek_10:00_Wonka','Czwartek','10:00','Wonka','Przycisk51,',NULL),(16,'Poniedziałek_21:00_Akademia Pana Kleksa','Poniedziałek','21:00','Akademia Pana Kleksa',',Przycisk27',NULL),(17,'Czwartek_10:00_Aquaman i Zaginione Królestwo','Czwartek','10:00','Aquaman i Zaginione Królestwo',',Przycisk37,Przycisk36,Przycisk39',NULL),(18,'Czwartek_21:00_Piep.zyć Mickiewicza','Czwartek','21:00','Piep.zyć Mickiewicza',NULL,NULL),(19,'Piątek_17:00_Aquaman i Zaginione Królestwo','Piątek','17:00','Aquaman i Zaginione Królestwo',',Przycisk49,Przycisk48,Przycisk47',NULL),(20,'Wtorek_21:00_Wonka','Wtorek','21:00','Wonka',',Przycisk39,Przycisk40,Przycisk38',NULL),(21,'Wtorek_10:00_Piep.zyć Mickiewicza','Wtorek','10:00','Piep.zyć Mickiewicza',NULL,NULL),(22,'Wtorek_16:00_Aquaman i Zaginione Królestwo','Wtorek','16:00','Aquaman i Zaginione Królestwo',',Przycisk39,Przycisk37,Przycisk38',NULL),(23,'Środa_20:00_Piep.zyć Mickiewicza','Środa','20:00','Piep.zyć Mickiewicza',',Przycisk36,Przycisk37,Przycisk38',NULL);
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-21 22:27:22
