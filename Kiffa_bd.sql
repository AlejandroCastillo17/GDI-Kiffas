-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: kiffas
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `configuraciontarifas`
--

DROP TABLE IF EXISTS `configuraciontarifas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `configuraciontarifas` (
  `TipoVehiculo` varchar(20) NOT NULL,
  `TarifaPorHora` decimal(10,2) NOT NULL,
  `TarifaPorDia` decimal(10,2) NOT NULL,
  `TarifaMensual` decimal(10,2) NOT NULL,
  `TarifaLavada` decimal(10,2) NOT NULL,
  PRIMARY KEY (`TipoVehiculo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuraciontarifas`
--

LOCK TABLES `configuraciontarifas` WRITE;
/*!40000 ALTER TABLE `configuraciontarifas` DISABLE KEYS */;
INSERT INTO `configuraciontarifas` VALUES ('Camioneta',4000.00,15000.00,70000.00,20000.00),('Carro',4000.00,15000.00,70000.00,20000.00),('Miscelaneo',0.00,0.00,70000.00,0.00),('Moto',1500.00,15000.00,50000.00,15000.00);
/*!40000 ALTER TABLE `configuraciontarifas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) NOT NULL,
  `codigo_barras` varchar(50) DEFAULT NULL,
  `precio_unitario` decimal(10,2) unsigned NOT NULL,
  `Costo_lote` decimal(10,2) unsigned NOT NULL,
  `cantidad_inicial` int NOT NULL,
  `cantidad_actual` int NOT NULL,
  `foto` longblob,
  `fecha` date DEFAULT (curdate()),
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo_barras` (`codigo_barras`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (12,'Trago ron','003',15000.00,8000.00,13,2,_binary 'ÿ\Øÿ\à\0JFIF\0\0\0\0\0\0ÿ\Û\0„\0	( \Z\Z%!1!%)+...383-7(-.+\n\n\n\r\Z\Z-  ----++----------------------------------+----7--2-ÿÀ\0\0¨+\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0\0\0\0ÿ\Ä\0:\0\0\0\0\0!1AQaq\"‘2¡±ÁðB\Ñ\á#Rbñ3r‚’\âÿ\Ä\0\0\0\0\0\0\0\0\0\0\0\0\0\0ÿ\Ä\0.\0\0\0\0\0\0\0\0!1\"2AQa#35q$4Brÿ\Ú\0\0\0?\0©^!jÿ\0\é\îoZ£\ÛU¡\Ä\0\æ\êG\Ý\Ûò¨F=\Ï¦\êõ+OS±¬\à\Í6\Ñ\äI\0ù1\Î7W6ž¬úN­ \ë\êló4H‚u\Óe}ÿ\0QjÕµ4\Å´\é\íZ\Æ\æ\âd‰\Ôk¡Hø?’\áU\Î~q•ÙŒ\èv\'ù\Å=F)á€§Ôµ\Õ\êCdenh†º@\×]øÌ€~\Ê%>!G#\Ü\Ýa®su\ßC\Zü%Âò\Ò\Ø\çZlõBi`„.8„%8{\Øû\'x~Ç¸N¯\é\ßÐ‰\àÅŸ\Ý-^9ÃŠõ^xJ\ä6»XX\ÏTú‹Ip;À;jÙ¸G¹,€t\Õ+lQ\Î\n\ëL.µMZ\ÃŒ@ö\'Oº–ó©L÷Ò¦O’\ã}\r}Š\Ü\âØ½\rj\Õc?÷9­\'¶º¬½ö9gx?\Ñ~sHŒÞ—•þ™\ë\ÉZ›g¾64•t½<_–\ìÏœ„\ÇfiÁ\Zñ€uºñp)ùnu\r%\Í\ì\ã+´B\íL­«Óµ\Å\0BžS!	N\0¤\\\Ú\Êõÿ\0tMF\â@œ±\Ã*\ÖÖ›ds:7\ä\î”[L\í‚Õ†Z\Ð	i×Œz’€\×\Øv8l\ÏU´´¤ñN\â\í™Î…Œõ8¼~Bg°³eX> \Ê\à	€\íN€¸@\Ómz¬Ÿ\Øt\Ê\íÚ k§«t?º½º½›Z”\äEZD\ëÁ\í‡\ê@?\nÇ¤°E\êy4\Ä4\Üq\Ô/R¸m\\\Ô\ÚzG\Âh*of:/+ „! \àB¸\àB¸\â…;ƒ\â¡PUa\0—n—\Øû$ˆ&\Ñ\ìAN,\Ö^\Û\Ý^²}o:i\03¿”\ØW…+Q‡VsApŒ!\Ï#¼€;\Ì-‡qvºƒ\\¹$“³cIùA¼û¯.œ*^cH­W5\Æs7p\Ñ\0\àU˜\Æ-d\Ã]©œf\ëK	\ÜRÒ†g7;Q\Ú875B\Â`\ê‚\02Gôó\ÕcH‚G¡î¾•ú\Õnƒ+@0\ÚgË¦Ù™—D¸\ìL\r¬>?jYY\Ó\Æ\ï\ÇX¨)–$·ô]K\îu\ÉòW!P\ZpB¸\àB”\áü;c\Ü&\ÊS\Ø÷	²µý;ú<ø·û¥ ¦±s\ÅjE’Hx\ÐjH:)‹\ZÅ•ñÁÀýÕ«`À:w\Ûb±¿ø>¥\å\ÃjS\Ê\ß@k‹§B9\0	”¾\á:V\Ï9«’NŽ\r-¥J9=\îž<«c\â°\Ö\î}@h\Ø\Ìg€»¬±ª	kª5p:2©Q³Àõ¹W\Ï\Ò\ìOckT—w%† \Ûjy¥•\Îh’ö\Óxo§‡˜\éŸhYÕ»m…G³3‹\â6\'\ËiÐ)´¼,5FA#‘#\á?¦\Ú\äœ_À#¯\é\Ôg¯“•\âŠ°B”\ãÐ¤Q…\Ú\Êõÿ\0tMF\âA\naõ\ë×¢\ÚfCI$ciS¦°ËŒ•\Z\î_\ÎRI†\ÜS4µ¼B¨o\ê\ç†j\Z4Nú$)n¨Z2–FÒ¢\Ö\ë©“·¤:\\\ç%9ú\Ü\à‰‘ô\é¬\Z‡`$m¹H\\0— :¦Ÿ\ê—†”›·I\àˆ\à¿M\ÛcÚŒ.vH‰S4Æ£€:\íu\ØO\â\ØmJO\Î\ìú€=oÿ\0õhóÁ\"‡\ÛH¯|%„BD „!qÀ„!q\Å\n…|öSS\àú\í ±\ÍÍ‘\ÒÀ‡h\ãö<@[Š4«\Þ\à¡“¦`ÍŸ¥ƒ–\æNÁ|«	¸}:­-\ã\é\×mO\Æ5>\ËS‹\Ò%¹ª<’u\Õ\Çñ°øR+\Ô|q¹’\êZß”ñ“Eu\â»ZL 8¾84Hù\Z}\×\Ï|AŒ²\å\Ò\Êe™gRDg—÷\\²°2\Î	:öE¦[¨\è›;\\–	´zHi\çÞ¹D¯Bð„Ì¦hkµLõBR`B”\á\Ü;c\Ü\'˜v\Ç\Ù8µ\Ý?j\"xño÷KAzW¬a;	Ux«Ý«f u=ù.£Q\Z£–\Ðtû5SIl¾Ï¢\ÛW­©¼NR\ÂDzxÁ\'amN‘§@6Ì¬\æ\ê´mrf!¥\Å\Ñ1\Õ&\ê¦sIž|~U*(w.\îºW\â¿Mo“\ëWa\ã&²±\'ÃB±‘\év ðžAE„cu[¦b{\ë÷ZºX\Å†ùu@<5\çß‚da==™\\	l¡­«·‡ð`P®ñ¯ºœ¾—®žý[\ÝRB+U±±e‹¨2\í’<B¥!=µÀ]¬¯_÷D\Ðtn$\Ö ¯³¨8lpˆ-#\Òc?ŸY\ç3\é\êžeõ&\Zð\'ù\Ãì–°·\r·ixõ‘:\Ì\ê«n*¶§’·m²ŠO(±\ë58“À\Êû¬uz.c‹\\ ‚¯\ío\Ü\Ó\ZAVW4(Ü¶õpwõ~*›³/r7‰nŒP+\Ô\î%…Ô }Z´\ì\á±H\ÊB6š!	N!Ž(P„\"²\ä¶ðý°só»fþy¦ñ›²òdúFœµý‚òÂ˜§NN\ä*ºõI\'©•ž@¶2\Þ\æp\\\'}$\Ý*\â2\Çoži\'{Gó’õ’&+ŽK7\Ù\Óx\ZÁ\"zJV¥©n‡P‹wñ)\Ï\Õ‚\ç¥È•µ“½N†ý\Ï@ž«VÕ¢< zñùI\Õ-\n£¾/Í–t\á\Ù.X²”\ì’\Ür¹nc“n•\ÃJD­5\Ë;c\Ü&j\Ô\rŽ\Ãt®±\î‰“—(\â´ú{}=\"—\èñ>¹§üŽ·8~\ÑË±—ºZÁ‘½7÷K\Ù[º­@\Ñ\Ä\ëÛš\r±kz­g‡p¿*˜¬\è\Ìñ§D\'¾V\Ï\É\ä\ÐöCOV\"±±\"C@cvhSTb¶\Ä\ZKŠY´§mÖ‚ŒW©ƒ¶mZ‡¡tû§¨Vv\ç\Ïu;Z„\ê$«*V\Üþû¦\ÝtSdú],›_\Æˆ–u—8¶\0Ê­5­÷\Z¹¿\Î*ª­\ÐfK‡\ãN¦\ì\Í=\Ç0„½C…\ÐÏ§\Æ\êûf¿ô¡p Á\Ò‹wy‡\ÙV¹¹÷p1ó\'‹a \è:´ý.ýÑ>¶»^8fSYÒ­Ó§,e\Ú\à.\Ð.¿\î‰o£q VX\r—›Tô·\ÔO\à}•j\Ù`–¢•	?Sý^\Ü\Â\Ï \äNñK®\0\íý¡g\ê¾T·÷>¢’5†r\îcf÷Á)z’\Ùi\Ý&JM\Z›F¦\ÇnG€gBª«À\ÃA©K\éÜ·x\ê:$m«•£±¼–O)l\Ìhi;9¤n\î´÷9hK\é¶$“\ï¼tU-ö\"jˆv¥¤A\ãwOø,þ#ôœò\"„!)LG\Ã\Ö\Ì}`%¡¥\ÝC@ù*|DPó=#(\Z\é´(0‡eó*p#ÜŸð«MÁ$’e\\”›g¦\ê&\ÕÍ§ú-\î\ïs@ƒŠ\å».\ÈQ¶rG\0)\é\Òæ¼¥H»e5\Ã\ÛL/;>\éQ\Òj(ò­V´(©ù\Ø{F§²—\Â+\\>H¹?\Ò\ßò´x­“›M Ty0\ã\"Y3ÿ\0\Èšt`\ä\Êjcû3xZA®sKCŒk\ÏR ²¥\ç<0@<\ÏkYU\Õ/póR­<µ\ZK€ \Ú§\Òac)8±Ù›¼%”;Giµ.K+l\Þ\á\ï¦u‚9¤\áAÿ\0ys\ÎW)šR¦\Ò\Ù)GÈ°\ÃFý\Â{ô¡\ÎU\ß,N\Ê\ß¯\'^(¥·¿ÇŒ\Ô\è\Ôz•¶³\Æ\Úf¨\Ô-¥KHkX8Ha6@\Öjª\ÑužJ/,Wÿ\06ü2F\Ê‡†\î¯.®D¬\æ%‹0q“\È+ÿ\0‘)\ì\ëKo#«Š¬h\ÑU]\â<Š®¼¿¨\í6	&Q.:\Ê\î\ÉK\Üð:6\ÂEdr½\ÌñO\àöÏªF@\\v\ÐH÷KY\ØRi—óÂ›xž¥h\ím¯^\"[mKƒX!\ÄuPO±q»,\ÇÔ–ò\ÄPS¤\æÒ­Aó¶€ð*·\Ä*½¡X\Ë2»_ö‘±žð=Õ¥\ÍN£i—HN\åYxc\rò\Ë\Éõ‡8ˆôõUó\é\Í4K%\Ó8=\Ö2\íZx¢Á´kœ¢\Zñ˜\\þ\ê­IÖ§Ü¡/´d:|sœ_\Ã\Âm¼Ú¬g7k\ØjV»|hw\Â\çýi\ä\×Âº½2€M\âAx™Û“%A	‹\ÆÁ)\n•%3rä˜¼Çœ®0\ÜG™T\åg\ÅÝ“\ã![ Ç¼úZ¯¬mœ\ØÌž³±f%1¬ô\Z™	\Û[»CPPc\Ã\Þ\æy‚5–h\'6\ß\ÔˆÐ°Z…nU\âTQ€NP˜\Þ8ªk»K\\¤Qq\Ì$3\Z«š\ìô\Ôo#\ßøV\nÞ¡mM\ÅTr\å´ñR­\ÂC‹\Õë†½8/\Ó\Ê8\áµôuŠ±”-ü©—\Ï3\Ícsò*\ë\Ä\æ¸T¸uH.9~\ê\ìr£¹\èM8\Ë\É\îh…©\ÓN1C\ryt»mÖƒµeF5ý§¸Ð¬\æ3Œ\Õ{\ÝB“K2¹\Í$j\çA=¡1!«|#\ÜFõ”‡—O\Ôþ\\‡2½ð\ï‡\ßXù\ÕL0}O\'M8S¸7†\Z\Æy÷N`õ\Æ	\'1;v\è–\Åñ\ßTý\r°-£;€9\í\Ìÿ\0ø\ÆzxŠŠj\ëožú^øO,‹\ÜW©R\Î\Ð7,ºƒ\00þ¡;ýT\Þ\Ò{B³f\rFØ‚z\Ò3«Cˆn\Äó-\Z\îT¯};b\ê´À{š¡oõ8\å.\å¡\ÍWtK-[š»³\Õp¶gP\0\ì5O”’X‰Zª²ûž\ï\è{\r7{PM\Í:†\Ñy\ÊùõZ•\ÝJt-\Þt\àg´+kÄ•j’3\ÃN\Í>J «P\æ\Íü\ÝGœ¢ýppm½¿ÀýÇ‡2?\ÌmPFð@ý”QÁ+^ù\ì‰:\ä)h\Ö\Î3$A­ŸUö\Õ\Î\à*š\ãéž¡=‚\×\ÔJ·%˜#/®ž5sÉ¿\Â_k¹y\\–VÂ®_Š’\Ð\åYE?\"—Ä—m9iuì°µfV\Ï\Ä5X\Ö8<\Ä\í\ÝchÐ©X\Å6Àÿ\0qý‡z‹c¸>ú\'d\×nH\ßZ7ÿ\0*\Ãµ«WQ\rhúœt\rþ\ëA‚x9­µÁ\ÊÁ«‰ÜÇ K\âøˆº³±¤\r0K§)sKˆ–ôª{¶V<|…p£\äKk‰\Ú\Ú6iV¨\àN\ÐL=‡M\ÔT}v\\÷¸R`{jL³[\ZÄ‰÷^Q²·²—©q\ÌKt\Ì\Z>üÓ´p\ê\Õf«\êdk¡\ÚÀ`ý;o\Í5X£²C•N~SeŽ<\Ñ4ª5Ù·8ñ•ˆTmr\Ò}\'_•\Ý\ÍE´i¿9k´#nºðL`¾O%þ²\0h\à\0UlÝ¦M\\\\#%ú(1«\ÓZ³Ào`”ZO\á\ìc\ÙQ€\0\íNò³i\ÝViÂ¼qƒ/D%¦¥ö?‚¸Š¡Àh$\Ýhª	Y\ê7~] \î$ž\Û+L\Z¶p@A\'Àc\Ð\Ä;\Å1jZ…X(\ëMˆQlAtwU4Á.Š ¸\í<–º\ÊR\Æw&¡`\Êm*j\ãô³÷*|Oe°+ýNkœ\Ê|Y‰\ì\Ç\\^\ÞQ²a­Xù•x\0Fš8\Ì„4™\è«mpª—Že\Ý\íR\Z\r@)å‰‡\ß,ÿ\0±\Ís§‰\Ñ^…*Üš\Ë\ÄF\ëbwù\ÛnE:sšLX\Z‚O˜pÀS¸kj\æT—¾£Zi’Nh†‰h\ä	ûc\æ\Å:T\Ãi4¹DwˆpS¶\nd\ëw¦x“œ8&9¾W£ùrT¢³‡\0G¾„ü¯ŸWÁ\ë°ù„:dÆ‡e¿¿¹\Ìö>#vý\Ç÷XœVþ«+–¸úAˆ\éÿ\0„6]½ÌŸN²\ß\ì\à…â°©jÚŒói¥‡q§ôž?\å º\r`}r„\Ú)®*\Í 50cî“§Cˆß¢³Ã„µ\ÃN\ä¾¡\ÇH\á‘|\íW…\Ø-¼?Š–I\Çq#¿§ÁiQ›Q¬¤pú¾“¾Ÿe„¨vpÝ¦z¯ü/|Yr:T¾ó#û{¥‚ò(ja˜·™Ô±ºV\æ­\'Tm0gÖ¼8<hCkšzmh\ß,y> i“2_ Q\Ä\rŒDð\n\áøej¬\Òì´PÌ“ ˆp,\èvŽŠ¯Ç¨Z°Ó·úŒ‚ý\Ì 3ž¦:)e7ÁJªW<³œOÈ´h$\æ®c\ê%¬:Äž0u…“¸»©]\Þc‰×‰\ÜûpIÖ®\ç»=NðLû“\ÍMN¸;(¾K\Ð\ÂX#ª\ÝTµ^¼\×!.Ap\"~’=\Âp’xc–ô¨\Ô?\ê‚r\í¬o§ŸE€z6\nªkJf‹\Ï\Ò&8”\Æ\Ð6\å„Ksô{„\Æ¼¥\ë»H\æS¸x»ÿ\0gºŽ®y58}HW¶\Õ\äd÷Y\Ë\'b\ç+ž\ê&ˆó˜\ÝY²±\ÞH2!%s‹[X\×ý?”	4ó±\ä‰/\0œ°v\ÙXÃ»[\â\Zt›Y•HU\Ì\0pt»\Ò\Ó ´p‚S\áŽY\å7\â™AW½\ÄFcU¬¤\'0aÑ¿ñ#úœAû+{g¶“?Oh\ÂI5IŒ\ê\í}û)\ì0Š•5\re\ZMqps&ò’Ø–-BÙ¾U£Av \Ô;ö9Û\ê´ñ[½\ØR¯FÙ¹ê´º¼Àa3¨\Ó1\å(¦\ç\Ü8:\á\î\ÜRg„òU8{\Þ|×»\ê‚K¦U\Õ8—a\Ïe=t÷\ï-‘£R£´7eöZbÔšTšÆ“”\è	\"4×š s\ZÚŒªL@‚­°‹œ\ì­H}ÀN©Kzy©\Õ\êh\Ì=µüJd\ã/\Ò!Sœ¸{Šø‡ó\Ü\Ð\ÐC<O–\Ã\íV ¦\Þ;žC‰]\Ý\Zu)6¨nGL8p:n\rE\Ô\Þ\Ñ\',\çóeRqpƒŠ\Û\0Jk²\Z™\Æ×—’o:•,¬f\à\Ç!\Äû¦üS1p\ãð°•\ï_Uùœuêµž¯\å\Õo#¡\ìPY½$ ½>\ÞM}|1•_™òtÛX\ÌW\Å5)~¦Ú›ZÇ±\ÄSsAÕ€\å$\éõ‚A\ìW\ÓjÐ!fnY\å\Ö{)S\í]\rl‡¼Ns;\Ìk\Ù\ÒI*óò	žŸ33>\Â[usQ\ÕI\Ê\àÇ‚iq!õ<\Î#”¢p«XyŽp¦\Ö\í-ˆ>“§b=Ô®·m!\æV9œF\ßx$GÓ–‰z\Ï{\Îzš\rI}˜÷+\Ù\â/ì±¥p÷´5ƒ#\0ú€‚yÀJ\ÜTsj`nw\Ô\ÂY˜‡«WCFÀm§El\Ú9ÀsÀ\Äé¡ˆ$p\ØüªN\î\ç±?¤\ëyšÈ¥\ë§%Q³š>v:,×‹lj¹\â­6“\éOð\×\\¹\rƒ\å¼\Zý³ø\Í\Ë\Ø\Z\á´Æ›¨,Â‘r”ž0fmn†IsLð\ÞGDó\îõúœÖ‚Ê­³\ØEF\çn\è4\ÜrTu\èCˆk´NÉ™\Ë+j`ûŠ¬=“˜s§i[F¼T{H$\ÌÁ\ìžÁ¿õ=¿pœÄ«ù`€\0\'s2\è\ëÌ¢™ò6E110À&@“öKÓª[Vö\Ô.)\ÝI\Ùzñ\êsGÏ¸ÿ\0\ÊR¾<F1Ÿ\\\×ôL4ÎƒFûÊ¤4Œ\æq“ö‚’\á°3´\É\ì7R\Êrûev’\Ù-…+Q%IglBv…	\Ñt\àÖŸQ„­Œù\ÉFI¼F‰ê¹ˆô´\Ç3§ÀJ~”\îJLK½\ìANœ§i´)©r¦wo€®–›L^»v)\Ë†\ë\ÆQ\ÌVv\Ð\í‘\nŸ˜\ê\ëýT™yfLj¢\Ä*ú€7RÒ–T©\'M\Ó,\ã%z[f–\Ð\æcOD†+Ð ýi—UkbN€÷…c…@Hø–Æ™¦\ê¹%\Í\0\Ï@TPyB\Ë	å¬™\ë¼f\î\ïF¬¤0u\è<¹$\æw?\ì”\å\Ê:U[yDTõV\äö\ÍBQ\Ë\ÙŽÄžD\Íj÷;Mº®…³g}ô\ÙMM€§n”Z½;\Æ\æ~\írŒüK\ß	6¨\Þ$ó¹©\í\Ý\å\\e;8–]†—9ñLA˜†‚™\'EeŽe5ZA\Ù\Ò5\É/\ã\ÅÉ¬|~d¥•þ#–\Õ4 ·\é\ê²«Õž:\àöS¨wŒ§\ÛoÊ¬GUXP_D\ZYJVÍ·“5v<ª\äm:¢\n¸µ½\Ô\ÉY\çfqõ3^\áTY\Þm\'m\Ð9Á\Ée´\×|{\Ãn\Ã\è±Ó»ù?Š;6Z,õl\\Fñ¢‹\Âw9­Xgb\æüœ¸|A\Ï\çB£¯Q:üI\å¦Wnž\nŸÒºs\Ô\Ôõà¡¬òJz\í\Î*² *[)\Ï\É\ì^®¨\×Ø£‹ª 	\×võýª9®ºÕ•2`5¤\é\ÃÛŠ“þ¢\Éaa–8S‰%¦=m#\ßp>\å,úÀ±\ÃC¡L\Òha{¢ÀÔ¥k]\âFÛ„\ë\"ˆ\â²\Þ­z¥Q\ÌË :kÁ+v\Ç\ç0òes\â\n.c\Û\Z‚ô2?\'\à%2sQ möµ,\n\à3\æiÁ¤ýÂƒ¬3lœÁ¨S„eš\ÌcWuI\à:\Â(½\Æ\ïW%9¶†)W\Õ5N /oY!RÒ©¬qN:¾G5Ó±Ÿ‚ž\ÊñY‰gZ\Üj#¢‚`\0¢69I?r­ü°a\Ü‘Ø¯E4©•fŠö\Ù;úª8ô\Ñö¦£fÁ¨\çSòuOÓ T\â\Þ6F\"\æi%T\r•…\ÝzM\Ó8‘ÀjU{\ÜÓ¨ûÿ\0„\ÒÞž;\ç4©I\ÑOVÌµ¹ øPþ£ù°^W¹sÀi\ØpH¢\Û\ÈR\Í\ïÀ\ÖÀA\î­­!*³W²\Ð[°~½¢dú·û™W¢UŒ\à=Õ…FIPµšÆƒ™R(9, b½W»/ð¦MOsL9®i\âIX\âL\éƒ$ì¼©ve:­\Ó\Ý`†Þ¡^O%1j,¦\çÃ›-\"24U\Õñp\íc\Ø;÷C{O6«;qAÀ\Ìi\Ù£O€5š\ÙKd¶mÓ§@@ø]‡ž:§…Tte ­l\æ9•w¶`¹[4¸97Oˆ\Ìc\Ð}•…\Ø\r2u…V\à\Îž\Í1÷…5¡\Zc´~\é\Ò\í\ÆÈŽË»-ŽV¬\\Æ·\Ýp3ª\ì,\Ç[Xq	ô\Û;Ü™\ÍFƒ¡\Ùdñ,%\Ô\êÆ¸·rN\Âx\Ï\ìµÊ·g¤8’I\Ð7H¦¼\Ð(Ë´1W½\Z\0U›W4™\"¡öÒ¯k2B\È\ÓÛ°\rJ\'ˆÆ‡ö[X•V\Äû²ƒT¼Iýµœcd¡h;\è­\ëPJmvMm/Ë‹ÝŠ\0\Ñý2z\íð¤«uPŒ£\Ò97EaG\r;º\Z9’\åv\ë:`Ç˜=?\á*œ¾9Ar\Ê0…Ài;-,C„€ORG\É\Óî¢¦m\ØKJf8f\Ôp\ÒRJ#•ñ\ÆOŠ²\Ï\ÙT§±{ÁV¦`!£A \Z$”•Å¤º}\Ól¶¿\r\ÊÑ —%ó\ÜU\Î%£_\Ý}\n\ãY‚G¦$\è¯%¾M\Ô&±ƒ1N\åÓ·À\ÕKZ¼Bô¤\ÌO\íì ­Fv\ÙHM‹obÀÿ\0¥PÀIŸ\ï\ì´o,§\êyX7.\Éÿ\0Ö¼ˆ\Ìt\çªN™¦­Ž˜\ÐÑ°\'yçª­­›G\ï\Ç\Æê%=BœjWrZ£§\'»\'kG%\êœ^\Â	„\âB\ë\Ã\ì\î\á_\å…Gá¡£û\Ýh©ÓŸ\ÝY¯}ŒXx\ÔM‰\Ü<4f>Êª¥Ru*lB\ç;´úF9û¥¥i4šUeòy§T\êºÆ¢öGL¨An5[>¦Kaµ\Ô\ÉütX\ÔS{še¤ƒ\ÌS\ê)\ï\Ý<2¦“V\é{¬£Syh\ÆHs¢8G\îtHU¼¤6h\Ú8\ÄOR«œe\Î.=LþW2£¯Lù“,\Û\Ôû½±Áiÿ\0w\Ê\ÂÆ³~&?\r…OZq—)\nž\Æ/?e;uvO“†\Ów^©TpV\ËgH£]¬·_÷D?Ñ½¬\é#†ŠM1¬‘§tò‚ò\Ø>™\Ì$4\ÉÔø\Ì,\àz¶”Œ\îz\êUYQ‡V™ö\âBØ°Ëªu©Š\"H\"¾=S\ÈC\\GfûÆŠ\ã\Æ\Å? ¹¼õ™\î\'·8\És“\êMqÑ€;Ü‘ð¢m\\¢R›y\ÄføW\Ï\î<AY\ã\ëwFÎŸ•=ƒ\Èlgs\ÝD—\Ë-Â·>Y¯¹½¢oS\Ï| üIT÷~!¨Sk)õ\r—|¹.k»ªÛ§Jtf¢M*a–EwqUÞº¯p\êO\ØpS6h‘»†£ŸU\Å©§\\›Ÿøjo^Øž!S›¹­\Ä*œDK·™Ÿ\Ú>\èB¶\Ì\nŠ‘À$.\"O„\'+Y\"SVôI\Ò=ø!‹õEd°¡nÖŽªD!9 ‚X=B¸PB¸\ãAá£ûÁV˜¥\ÎV†«†½\ÝE:tT¬Y<¿ø²\ÉA\Ï*…¨<¼õx½BQ„.„%„.8õv„,·^÷D\ÐtdJ´u‰m\ÕPOfð\Óùº³ú\ÒlÁb˜s©ºgB”¦ø<„…\ÈðYY¿ò®-\êõBRAjxDÏªW€J¢e=m²[\"I\Ò…b\rœ‚õN8ÿ\Ù','2025-05-30');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turnos`
--

DROP TABLE IF EXISTS `turnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turnos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `encargado` varchar(100) NOT NULL,
  `base` decimal(10,2) NOT NULL,
  `fecha_inicio` datetime NOT NULL,
  `fecha_cierre` datetime DEFAULT NULL,
  `total_ventas` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turnos`
--

LOCK TABLES `turnos` WRITE;
/*!40000 ALTER TABLE `turnos` DISABLE KEYS */;
INSERT INTO `turnos` VALUES (1,'Alejo',200000.00,'2025-06-03 21:21:10',NULL,0.00),(2,'Alejo',200000.00,'2025-06-03 21:23:33','2025-06-03 21:24:59',12000.00),(3,'puta',20000.00,'2025-06-03 21:35:02',NULL,0.00),(4,'Alejo',200000.00,'2025-06-03 21:48:06',NULL,0.00),(5,'Alejo',512000.00,'2025-06-03 21:54:28','2025-06-03 21:57:58',26000.00),(6,'Alejo',500000.00,'2025-06-03 22:04:12',NULL,0.00),(7,'Alejo',300000.00,'2025-06-03 22:10:01','2025-06-03 22:12:09',13000.00),(8,'Azufre',400000.00,'2025-06-03 22:12:31',NULL,0.00),(9,'Alejo',8.00,'2025-06-03 22:17:13','2025-06-03 22:17:27',NULL),(10,'Alejo',200000.00,'2025-06-06 19:02:13',NULL,0.00),(11,'alejo1',200000.00,'2025-06-06 19:10:53',NULL,0.00),(12,'alejo1',200000.00,'2025-06-06 19:15:53',NULL,0.00),(13,'alejo',200000.00,'2025-06-06 19:21:17',NULL,0.00),(14,'alejo12',200000.00,'2025-06-06 19:26:30','2025-06-06 19:30:06',30000.00),(15,'rata',420.00,'2025-06-06 19:30:17',NULL,0.00),(16,'kaka',5000.00,'2025-06-06 19:31:29',NULL,0.00),(17,'dssds',5464.00,'2025-06-06 19:34:40',NULL,0.00),(18,'rata',4.00,'2025-06-06 19:51:05',NULL,0.00),(19,'goku',23456.00,'2025-06-06 19:56:06',NULL,0.00),(20,'vegeuta',456987.00,'2025-06-06 20:04:39',NULL,0.00),(21,'goku',232.00,'2025-06-06 20:06:32',NULL,0.00),(22,'alsfpsa4',56.00,'2025-06-06 20:07:56',NULL,0.00),(23,'dvsd',232.00,'2025-06-06 20:08:50',NULL,0.00),(24,'wfewfw',5116.00,'2025-06-06 20:09:34',NULL,0.00),(25,'dfsdvs546',546.00,'2025-06-06 20:10:13',NULL,0.00),(26,'goku',54200.00,'2025-06-06 20:24:57',NULL,0.00),(27,'RATA',323.00,'2025-06-06 20:40:23',NULL,0.00),(28,'Alejo',200500.00,'2025-06-06 21:30:59','2025-06-06 21:32:22',NULL),(29,'alejo',44242424.00,'2025-06-12 19:52:33',NULL,0.00),(30,'alejo',232323.00,'2025-06-12 19:54:38',NULL,0.00),(31,'alejo2323',232323.00,'2025-06-17 22:08:47',NULL,0.00),(32,'alejo',20000.00,'2025-06-17 22:34:03',NULL,0.00),(33,'alejo',23232.00,'2025-06-17 22:38:00',NULL,0.00),(34,'alejo',300000.00,'2025-06-17 22:47:04',NULL,0.00),(35,'alejo',400000.00,'2025-06-17 22:58:46',NULL,0.00),(36,'putas',54656546.00,'2025-07-17 18:04:29',NULL,0.00),(37,'sfmakonf',20000.00,'2025-07-17 18:05:36',NULL,0.00),(38,'giovan2025',500000.00,'2026-02-06 19:17:34',NULL,0.00),(39,'alejo',200000.00,'2026-02-06 19:20:45',NULL,0.00),(40,'rata',2000.00,'2026-02-06 20:26:22','2026-02-06 20:28:41',60000.00),(41,'asofnao',636565.00,'2026-02-06 20:28:55',NULL,0.00),(42,'mpdpssd',6564646.00,'2026-02-06 20:36:17','2026-02-06 20:38:41',6657507.00),(43,'dsggs5',6646464.00,'2026-02-06 22:31:07','2026-02-06 22:31:39',116846.00);
/*!40000 ALTER TABLE `turnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_pedido` int NOT NULL,
  `producto` varchar(255) NOT NULL,
  `cantidad` int NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `fecha` date DEFAULT (curdate()),
  `mesa` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (1,1,'cerveza',2,8000.00,'2025-05-22',0),(2,1,'guaro',3,15000.00,'2025-05-22',0),(3,2,'Guaro',4,20000.00,'2025-05-26',0),(4,3,'Guaro',1,5000.00,'2025-05-26',0),(5,4,'Guaro',1,5000.00,'2025-05-26',0),(6,5,'Guaro',4,20000.00,'2025-05-26',0),(7,5,'cerveza',1,4000.00,'2025-05-26',0),(8,5,'ron',1,4500.00,'2025-05-26',0),(9,6,'guaro',2,10000.00,'2025-05-26',0),(10,6,'cerveza',2,8000.00,'2025-05-26',0),(11,6,'Guaro',4,20000.00,'2025-05-26',0),(12,6,'ron',1,4500.00,'2025-05-26',0),(13,7,'Guaro',4,20000.00,'2025-05-26',0),(14,8,'cerveza',1,4000.00,'2025-05-26',0),(15,8,'ron',1,4500.00,'2025-05-26',0),(16,8,'Guaro',1,5000.00,'2025-05-26',0),(17,9,'cerveza',2,8000.00,'2025-05-26',0),(18,9,'ron',1,4500.00,'2025-05-26',0),(19,9,'Guaro',5,25000.00,'2025-05-26',0),(20,10,'cerveza',2,8000.00,'2025-05-26',0),(21,11,'Guaro',2,10000.00,'2025-05-26',0),(22,12,'ron',2,9000.00,'2025-05-28',0),(23,12,'cerveza',1,4000.00,'2025-05-28',0),(24,12,'Guaro',2,10000.00,'2025-05-28',0),(30,13,'cerveza',2,12000.00,'2025-06-03',0),(31,14,'cerveza',2,12000.00,'2025-06-03',0),(32,14,'ron',2,14000.00,'2025-06-03',0),(33,15,'Guaro',2,10000.00,'2025-06-03',0),(34,16,'cerveza',1,6000.00,'2025-06-03',0),(35,16,'ron',1,7000.00,'2025-06-03',0),(36,17,'Trago ron',3,15000.00,'2025-06-06',0),(37,17,'Trago Aguardiente',3,15000.00,'2025-06-06',0),(38,18,'cerveza',1,6000.00,'2025-06-17',0),(42,20,'ron',3,24000.00,'2025-06-17',0),(43,20,'Guaro',1,5000.00,'2025-06-17',0),(44,21,'Trago ron',2,30000.00,'2025-06-17',0),(45,22,'cerveza',2,12000.00,'2025-06-17',0),(48,23,'cerveza',5,30000.00,'2025-06-17',0),(51,24,'Trago ron',2,30000.00,'2026-02-06',0),(52,25,'Trago ron',2,30000.00,'2026-02-06',0),(53,26,'Trago ron',1,15000.00,'2026-02-06',0),(54,27,'Trago ron',2,30000.00,'2026-02-06',0),(55,28,'Trago ron',4,60000.00,'2026-02-06',0);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas_turno`
--

DROP TABLE IF EXISTS `ventas_turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas_turno` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_turno` int DEFAULT NULL,
  `producto` varchar(100) DEFAULT NULL,
  `cantidad` int DEFAULT NULL,
  `ingreso` decimal(10,2) DEFAULT NULL,
  `hora` datetime DEFAULT NULL,
  `id_pedido` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_turno` (`id_turno`),
  KEY `id_pedido` (`id_pedido`),
  CONSTRAINT `ventas_turno_ibfk_1` FOREIGN KEY (`id_turno`) REFERENCES `turnos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas_turno`
--

LOCK TABLES `ventas_turno` WRITE;
/*!40000 ALTER TABLE `ventas_turno` DISABLE KEYS */;
INSERT INTO `ventas_turno` VALUES (1,2,'cerveza',2,12000.00,'2025-06-03 21:23:58',0),(2,5,'cerveza',2,12000.00,'2025-06-03 21:57:27',0),(3,5,'ron',2,14000.00,'2025-06-03 21:57:27',0),(4,6,'Guaro',2,10000.00,'2025-06-03 22:05:29',0),(5,7,'cerveza',1,6000.00,'2025-06-03 22:10:11',0),(6,7,'ron',1,7000.00,'2025-06-03 22:10:11',0),(7,14,'Trago ron',3,15000.00,'2025-06-06 19:29:57',0),(8,14,'Trago Aguardiente',3,15000.00,'2025-06-06 19:29:57',0),(9,26,'Descorche',1,20000.00,'2025-06-06 20:25:09',0),(10,26,'Descorche',1,40500.00,'2025-06-06 20:25:29',0),(11,31,'cerveza',1,6000.00,'2025-06-17 22:09:10',0),(12,31,'cerveza',4,24000.00,'2025-06-17 22:10:36',0),(13,31,'cerveza',2,12000.00,'2025-06-17 22:12:23',0),(14,33,'cerveza',2,12000.00,'2025-06-17 22:38:04',19),(15,33,'ron',3,24000.00,'2025-06-17 22:39:12',20),(16,33,'Guaro',1,5000.00,'2025-06-17 22:39:12',20),(17,33,'Trago ron',2,30000.00,'2025-06-17 22:42:37',21),(18,34,'cerveza',2,12000.00,'2025-06-17 22:47:10',22),(21,35,'cerveza',5,30000.00,'2025-06-17 22:58:55',23),(24,40,'Trago ron',2,30000.00,'2026-02-06 20:26:35',24),(25,40,'Trago ron',2,30000.00,'2026-02-06 20:27:43',25),(26,42,'Trago ron',1,15000.00,'2026-02-06 20:36:21',26),(27,42,'Descorche',1,65656.00,'2026-02-06 20:36:28',27),(28,42,'Descorche',1,6546846.00,'2026-02-06 20:36:35',27),(29,42,'Descorche',1,5.00,'2026-02-06 20:36:39',27),(30,42,'Trago ron',2,30000.00,'2026-02-06 20:37:13',27),(31,43,'Descorche',1,56846.00,'2026-02-06 22:31:12',28),(32,43,'Trago ron',4,60000.00,'2026-02-06 22:31:18',28);
/*!40000 ALTER TABLE `ventas_turno` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-02-26 19:09:29
