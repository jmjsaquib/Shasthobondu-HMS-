/*
Navicat MySQL Data Transfer

Source Server         : hms_development
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : hms

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2016-09-09 05:02:42
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for admission
-- ----------------------------
DROP TABLE IF EXISTS `admission`;
CREATE TABLE `admission` (
  `admission_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `admission_date` varchar(255) DEFAULT NULL,
  `reffered_by` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `ward_id` int(11) DEFAULT NULL,
  `room_id` int(11) DEFAULT NULL,
  `received_by` int(11) DEFAULT NULL,
  `received_date` varchar(255) DEFAULT NULL,
  `received_time` varchar(255) DEFAULT NULL,
  `presscription_id` int(11) DEFAULT NULL,
  `bed_id` int(11) DEFAULT NULL,
  `bed_status` varchar(255) DEFAULT NULL,
  `payment_status` varchar(255) DEFAULT NULL,
  `daily_cost` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`admission_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of admission
-- ----------------------------
INSERT INTO `admission` VALUES ('4', '4', '8/16/2016', null, '2', '3', null, '2', '8/16/2016', '12:00 AM', '12', '3', 'assigned', 'due', '500');
INSERT INTO `admission` VALUES ('5', '4', '8/16/2016', '2', '2', '3', null, '2', '8/16/2016', '12:30 AM', '12', '4', 'assigned', 'confirmed', '300');
INSERT INTO `admission` VALUES ('6', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', null, '16', '2', 'assigned', 'confirmed', '200');
INSERT INTO `admission` VALUES ('7', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', '12:30 AM', '12', '2', 'blank', 'confirmed', '100');
INSERT INTO `admission` VALUES ('8', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', '12:30 AM', '12', '1', 'assigned', null, null);
INSERT INTO `admission` VALUES ('9', '4', '8/16/2016', '2', '2', '3', null, '2', '8/16/2016', '1:00 AM', '12', '12', 'assigned', null, null);
INSERT INTO `admission` VALUES ('10', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', '12:30 AM', '12', '1', 'assigned', null, null);
INSERT INTO `admission` VALUES ('11', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', '12:00 AM', '12', '2', 'blank', null, null);
INSERT INTO `admission` VALUES ('12', '4', '8/16/2016', '2', '2', null, '3', '2', '8/16/2016', '12:30 AM', '12', '1', 'assigned', null, null);
INSERT INTO `admission` VALUES ('13', '6', '8/25/2016', '2', '2', '3', null, '2', '8/25/2016', '12:30 AM', '13', '6', 'assigned', 'confirmed', '500');
INSERT INTO `admission` VALUES ('14', '5', '8/25/2016', '2', '2', '3', null, null, '8/25/2016', '12:30 AM', '16', '1', 'blank', null, null);
INSERT INTO `admission` VALUES ('15', '4', '8/25/2016', '2', '2', null, '3', '2', '8/25/2016', '12:30 AM', '12', '1', 'assigned', null, null);
INSERT INTO `admission` VALUES ('16', '4', '8/25/2016', '2', '2', null, '3', '2', '8/25/2016', '12:00 AM', '12', '2', 'assigned', null, null);
INSERT INTO `admission` VALUES ('17', '4', '8/25/2016', '2', '2', null, '3', null, '8/25/2016', null, '12', '2', 'blank', null, null);
INSERT INTO `admission` VALUES ('18', '4', '8/28/2016', '2', '2', '4', null, '2', '8/28/2016', '1:00 AM', '12', '1', 'blank', null, null);
INSERT INTO `admission` VALUES ('19', '6', '9/1/2016', '2', '2', null, '4', '2', '9/1/2016', '12:30 AM', '13', '1', 'blank', null, null);
INSERT INTO `admission` VALUES ('20', '7', '9/4/2016', '2', '2', null, '4', null, '9/4/2016', '12:30 AM', '19', '0', 'assigned', 'confirmed', '1000');
INSERT INTO `admission` VALUES ('21', '10', '9/4/2016', '2', '1', null, '1', '3', '9/4/2016', '12:00 AM', '24', '1', 'blank', 'confirmed', '500');
INSERT INTO `admission` VALUES ('22', '11', '9/5/2016', '2', '1', null, '2', '3', '9/5/2016', '3:00 AM', '25', '0', 'assigned', 'confirmed', '15000');
INSERT INTO `admission` VALUES ('23', '3', '9/6/2016', '2', '1', '1', null, '4', '9/6/2016', '12:00 AM', '21', '1', 'assigned', 'confirmed', '0');
INSERT INTO `admission` VALUES ('24', '12', '9/6/2016', '6', '4', null, '5', null, '9/6/2016', '12:30 AM', '27', '0', 'blank', 'confirmed', '10000');
INSERT INTO `admission` VALUES ('25', '8', '9/7/2016', '1', '1', null, '2', null, '9/7/2016', '12:30 AM', '28', '2', 'assigned', 'confirmed', '5000');
INSERT INTO `admission` VALUES ('26', '6', '9/7/2016', '2', '1', '1', null, null, '9/7/2016', '12:00 AM', '29', '2', 'assigned', 'confirmed', '0');
INSERT INTO `admission` VALUES ('27', '1', '9/8/2016', '2', '2', null, '4', null, '9/8/2016', null, '17', '2', 'assigned', 'confirmed', '500');

-- ----------------------------
-- Table structure for appoinment
-- ----------------------------
DROP TABLE IF EXISTS `appoinment`;
CREATE TABLE `appoinment` (
  `appoinment_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `appoinment_date` date DEFAULT NULL,
  `appoinment_time` varchar(255) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `doctor_id` int(11) DEFAULT NULL,
  `purpose` varchar(255) DEFAULT NULL,
  `patient_type` varchar(255) DEFAULT NULL,
  `appoinment_type` varchar(255) DEFAULT NULL,
  `appoinment_serial` int(11) DEFAULT NULL,
  PRIMARY KEY (`appoinment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of appoinment
-- ----------------------------
INSERT INTO `appoinment` VALUES ('1', '3', '2016-09-02', '10:00 AM', '1', '2', 'Test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('4', '2', '2016-09-02', '9:30 AM', '2', '2', 'test', 'new', 'priority', '2');
INSERT INTO `appoinment` VALUES ('5', '4', '2016-09-02', '3:30 AM', '2', '2', 'test', 'new', 'priority', '2');
INSERT INTO `appoinment` VALUES ('6', '5', '2016-09-02', '1:00 AM', '2', '2', null, 'new', 'priority', '2');
INSERT INTO `appoinment` VALUES ('7', '6', '2016-09-02', '1:30 AM', '2', '2', 'test', 'new', 'normal', '2');
INSERT INTO `appoinment` VALUES ('8', '1', '2016-09-02', '12:00 AM', '2', '2', null, 'new', 'priority', '2');
INSERT INTO `appoinment` VALUES ('9', '7', '2016-09-03', '3:00 AM', '2', '2', 'test', 'new', 'normal', '5');
INSERT INTO `appoinment` VALUES ('10', '6', '2016-09-02', '12:30 AM', '1', '2', 'test', 'new', 'priority', '1');
INSERT INTO `appoinment` VALUES ('11', '9', '2016-09-02', '1:00 AM', '1', '2', 'test', 'new', 'normal', '2');
INSERT INTO `appoinment` VALUES ('12', '9', '2016-09-02', '1:00 AM', '1', '2', null, null, null, '3');
INSERT INTO `appoinment` VALUES ('13', '9', '2016-09-03', '', '1', '2', null, null, null, '4');
INSERT INTO `appoinment` VALUES ('14', '8', '2016-03-09', '4:00 PM', '1', '1', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('15', '6', '2016-03-09', '4:00 PM', '1', '2', null, 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('16', '5', '2016-04-09', '4:00 PM', '1', '2', null, 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('17', '6', '2016-09-03', '4:30 PM', '1', '2', 'test', 'new', 'normal', '2');
INSERT INTO `appoinment` VALUES ('18', '5', '2016-09-03', '4:00 PM', '1', '2', 'trest', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('19', '2', '2016-09-03', '6:00 PM', '2', '1', null, 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('20', '6', '2016-09-03', '4:30 PM', '1', '2', 'test', 'new', 'normal', '6');
INSERT INTO `appoinment` VALUES ('21', '6', '2016-09-03', '4:30 PM', '1', '2', 'test', 'new', 'normal', '6');
INSERT INTO `appoinment` VALUES ('22', '6', '2016-09-03', '4:30 PM', '1', '2', 'test', 'new', 'normal', '3');
INSERT INTO `appoinment` VALUES ('23', '6', '2016-09-03', '4:30 PM', '1', '2', 'test', 'new', 'normal', '8');
INSERT INTO `appoinment` VALUES ('24', '6', '2016-09-03', '4:00 PM', '1', '2', 'test', 'new', 'normal', '7');
INSERT INTO `appoinment` VALUES ('25', '6', '2016-09-04', '4:00 PM', '1', '2', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('26', '6', '2016-09-04', '4:00 PM', '1', '2', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('27', '6', '2016-09-04', '4:30 PM', '1', '2', 'test', 'new', 'normal', '4');
INSERT INTO `appoinment` VALUES ('28', '6', '2016-09-04', '4:00 PM', '1', '2', 'test', 'new', 'normal', '6');
INSERT INTO `appoinment` VALUES ('29', '6', '2016-09-05', '4:30 PM', '1', '2', 'test', 'new', 'normal', '5');
INSERT INTO `appoinment` VALUES ('30', '6', '2016-09-06', '5:00 PM', '1', '2', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('31', '6', '2016-09-05', '4:00 PM', '1', '2', 'test', 'new', 'normal', '2');
INSERT INTO `appoinment` VALUES ('32', '6', '2016-09-09', '6:00 PM', '2', '1', 'test', 'new', 'normal', '3');
INSERT INTO `appoinment` VALUES ('33', '6', '2016-09-06', '4:00 PM', '1', '2', 'twest', 'new', 'normal', '3');
INSERT INTO `appoinment` VALUES ('34', '6', '2016-09-03', '2:00 PM', '1', '4', 'twest', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('35', '6', '2016-09-05', '4:30 PM', '1', '2', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('36', '6', '2016-09-08', '4:00 PM', '1', '2', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('37', '10', '2016-09-09', '4:30 PM', '1', '2', 'test', 'new', 'normal', '2');
INSERT INTO `appoinment` VALUES ('38', '11', '2016-09-09', '4:00 PM', '1', '2', 'Test', 'new', 'normal', '3');
INSERT INTO `appoinment` VALUES ('39', '12', '2016-09-06', '4:00 PM', '4', '6', 'test', 'new', 'normal', '1');
INSERT INTO `appoinment` VALUES ('40', '12', '2016-09-09', '5:00 PM', '2', '1', 'Test', 'new', 'normal', '1');

-- ----------------------------
-- Table structure for bank
-- ----------------------------
DROP TABLE IF EXISTS `bank`;
CREATE TABLE `bank` (
  `bank_id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_name` varchar(255) DEFAULT NULL,
  `branch_name` varchar(255) DEFAULT NULL,
  `branch_address` varchar(255) DEFAULT NULL,
  `bank_account_no` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`bank_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of bank
-- ----------------------------
INSERT INTO `bank` VALUES ('1', 'DBBL', 'Dhanmondi-dhka', 'panthopath, dhaka', '199-101');
INSERT INTO `bank` VALUES ('2', 'City bank', 'Dhanmondi', 'Panthopath, dhaka', '199920');
INSERT INTO `bank` VALUES ('3', 'HSBC', 'Uttara', 'Sector:11, Uttara', '123456789');

-- ----------------------------
-- Table structure for blood_donation
-- ----------------------------
DROP TABLE IF EXISTS `blood_donation`;
CREATE TABLE `blood_donation` (
  `blood_donation_id` int(11) NOT NULL AUTO_INCREMENT,
  `donor_id` int(11) DEFAULT NULL,
  `donation_place_id` int(11) DEFAULT NULL,
  `donation_date` date DEFAULT NULL,
  `donate_whom` int(11) DEFAULT NULL,
  `no_of_bag` int(11) DEFAULT NULL,
  PRIMARY KEY (`blood_donation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of blood_donation
-- ----------------------------
INSERT INTO `blood_donation` VALUES ('1', '11', '1', '2016-09-05', '11', '1');
INSERT INTO `blood_donation` VALUES ('2', '11', '3', '2016-09-05', '9', '1');
INSERT INTO `blood_donation` VALUES ('3', '10', '1', '2016-09-06', '5', '1');

-- ----------------------------
-- Table structure for department
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department` (
  `department_id` int(11) NOT NULL AUTO_INCREMENT,
  `department_name` varchar(255) DEFAULT NULL,
  `manged_by_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`department_id`),
  KEY `fk_6` (`manged_by_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES ('1', 'Medicine', null);
INSERT INTO `department` VALUES ('2', 'Gynacology', null);
INSERT INTO `department` VALUES ('3', 'Accident and Emergency', null);
INSERT INTO `department` VALUES ('4', 'Surgery', null);

-- ----------------------------
-- Table structure for discharge
-- ----------------------------
DROP TABLE IF EXISTS `discharge`;
CREATE TABLE `discharge` (
  `discharge_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `admission_id` int(11) DEFAULT NULL,
  `discharge_date` varchar(255) DEFAULT NULL,
  `discharge_type_id` int(11) DEFAULT NULL,
  `advice_on_discharge` varchar(255) DEFAULT NULL,
  `condition_during_discharge` varchar(255) DEFAULT NULL,
  `discharge_by_id` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`discharge_id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of discharge
-- ----------------------------
INSERT INTO `discharge` VALUES ('2', '4', '9', '8/24/2016', '2', 'test', 'test condition', '2', null);
INSERT INTO `discharge` VALUES ('3', '4', '6', '8/24/2016', '2', 'testr', 'test', '2', '2');
INSERT INTO `discharge` VALUES ('4', '4', '9', '8/24/2016', '2', 'teste', 'tesetsesr', '2', '2');
INSERT INTO `discharge` VALUES ('5', '4', '9', '8/24/2016', '2', 'teste', 'tesetsesr', '2', '2');
INSERT INTO `discharge` VALUES ('6', '4', '9', '8/24/2016', '2', 'teste', 'tesr', '2', '2');
INSERT INTO `discharge` VALUES ('7', '4', '11', '8/24/2016', '2', 'tertr', 'tetse', '2', '2');
INSERT INTO `discharge` VALUES ('8', '6', '13', '8/25/2016', '2', 'testr', 'okkk', '2', '2');
INSERT INTO `discharge` VALUES ('9', '4', '18', '8/28/2016', '2', 'tert', 'tetre', '2', '2');
INSERT INTO `discharge` VALUES ('10', '6', '19', '9/1/2016', '2', 'test', 'test', '2', '2');
INSERT INTO `discharge` VALUES ('11', '5', '14', '9/1/2016', '2', 'tests', 'teset', '2', '2');
INSERT INTO `discharge` VALUES ('12', '6', '19', '9/2/2016', '2', 'test', 'test', '2', '2');
INSERT INTO `discharge` VALUES ('13', '4', '17', '9/2/2016', '4', 'tests', 'test', '2', '2');
INSERT INTO `discharge` VALUES ('14', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('15', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('16', null, null, '9/6/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('17', null, null, '9/6/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('18', null, null, '9/6/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('19', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('20', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('21', null, null, '9/6/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('22', null, null, '9/6/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('23', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('24', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('25', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('26', null, null, '9/5/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('27', '10', '21', '9/5/2016', '3', 'teset', 'test', '3', '1');
INSERT INTO `discharge` VALUES ('28', '11', '22', '9/7/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('29', '12', '24', '9/7/2016', '2', 'Valo kore kha.', 'Test', '10', '4');
INSERT INTO `discharge` VALUES ('30', '3', '23', '9/7/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('31', '8', '25', '9/9/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('32', '6', '26', '9/9/2016', null, null, null, null, null);
INSERT INTO `discharge` VALUES ('33', '1', '27', '9/10/2016', null, null, null, null, null);

-- ----------------------------
-- Table structure for discharge_medicine_mapping
-- ----------------------------
DROP TABLE IF EXISTS `discharge_medicine_mapping`;
CREATE TABLE `discharge_medicine_mapping` (
  `discharge_medicine_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `discharge_id` int(11) DEFAULT NULL,
  `medicine_id` int(11) DEFAULT NULL,
  `medicine_power` varchar(255) DEFAULT NULL,
  `dosage` varchar(255) DEFAULT NULL,
  `how_long` varchar(255) DEFAULT NULL,
  `route_of_administration` varchar(255) DEFAULT NULL,
  `rules` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`discharge_medicine_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of discharge_medicine_mapping
-- ----------------------------
INSERT INTO `discharge_medicine_mapping` VALUES ('1', '1', '2', '20 mg', '1+1+1', 'Continue', null, 'After Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('2', '2', '2', '2 mg', '1+1+1', 'Continue', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('3', '8', '2', '20 mg', '1+1+1', 'Continue', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('4', '9', '2', '22 mg', '1+1+1', 'Continue', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('5', '10', '2', '500 mg', null, 'Continue', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('6', '11', '2', '360 mg', null, '6 months', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('7', '12', '2', '240 mg', null, '2 months', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('8', '13', '2', '360 mg', null, '6 months', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('9', '27', '3', '2 mg', '1+1+1', '2 Week', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('10', '27', '3', '2 mg', '1+1+1', '2 Week', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('11', '27', '3', '2 mg', '1+1+1', '2 Week', null, 'Before Meal');
INSERT INTO `discharge_medicine_mapping` VALUES ('12', '29', '3', '480 mg', '1+1+1', 'Continue', null, 'After Meal');

-- ----------------------------
-- Table structure for discharge_type
-- ----------------------------
DROP TABLE IF EXISTS `discharge_type`;
CREATE TABLE `discharge_type` (
  `discharge_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `discharge_type_name` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`discharge_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of discharge_type
-- ----------------------------
INSERT INTO `discharge_type` VALUES ('2', 'Regular Discharge', 'Regular Discharge.');
INSERT INTO `discharge_type` VALUES ('3', 'Self Discharge', 'Self Discharge');
INSERT INTO `discharge_type` VALUES ('4', 'Death of Patient', 'Death.');

-- ----------------------------
-- Table structure for disease
-- ----------------------------
DROP TABLE IF EXISTS `disease`;
CREATE TABLE `disease` (
  `disease_id` int(11) NOT NULL,
  `disease_name` varchar(255) DEFAULT NULL,
  `disease_description` varchar(255) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`disease_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of disease
-- ----------------------------

-- ----------------------------
-- Table structure for district
-- ----------------------------
DROP TABLE IF EXISTS `district`;
CREATE TABLE `district` (
  `district_id` int(11) NOT NULL AUTO_INCREMENT,
  `district_name` varchar(255) DEFAULT NULL,
  `division_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`district_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of district
-- ----------------------------
INSERT INTO `district` VALUES ('3', 'Gouripur', '3');
INSERT INTO `district` VALUES ('4', 'Test', '2');

-- ----------------------------
-- Table structure for division
-- ----------------------------
DROP TABLE IF EXISTS `division`;
CREATE TABLE `division` (
  `division_id` int(11) NOT NULL AUTO_INCREMENT,
  `division_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`division_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of division
-- ----------------------------
INSERT INTO `division` VALUES ('2', 'Dhaka');
INSERT INTO `division` VALUES ('3', 'Mymensingh');
INSERT INTO `division` VALUES ('4', 'Rangpur');

-- ----------------------------
-- Table structure for doctor
-- ----------------------------
DROP TABLE IF EXISTS `doctor`;
CREATE TABLE `doctor` (
  `doctor_id` int(11) NOT NULL AUTO_INCREMENT,
  `department_id` int(11) DEFAULT NULL,
  `doctor_fees` varchar(255) DEFAULT NULL,
  `doctor_appoinment_count` int(11) DEFAULT NULL,
  `doctor_available_time_from` varchar(255) DEFAULT NULL,
  `doctor_available_time_to` varchar(255) DEFAULT NULL,
  `available` varchar(255) DEFAULT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `doctor_registration_number` int(11) DEFAULT NULL,
  PRIMARY KEY (`doctor_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of doctor
-- ----------------------------
INSERT INTO `doctor` VALUES ('1', '2', '5000', '10', '5:00 PM', '9:00 PM', 'yes', '2', null);
INSERT INTO `doctor` VALUES ('2', '1', '300', '10', '4:00 PM', '8:30 PM', 'yes', '3', null);
INSERT INTO `doctor` VALUES ('4', '1', '500', '20', '2:00 PM', '5:30 PM', 'yes', '4', '123456789');
INSERT INTO `doctor` VALUES ('5', '3', '200', '2', '2:30 PM', '6:00 PM', 'yes', '5', '123456');
INSERT INTO `doctor` VALUES ('6', '4', '2000', '10', '3:30 PM', '7:00 PM', 'yes', '10', '123455');

-- ----------------------------
-- Table structure for doctor_roster
-- ----------------------------
DROP TABLE IF EXISTS `doctor_roster`;
CREATE TABLE `doctor_roster` (
  `doctor_roster_id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT NULL,
  `Start` datetime DEFAULT NULL,
  `End` date DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `RecurrenceID` int(11) DEFAULT NULL,
  `RecurrenceRule` varchar(255) DEFAULT NULL,
  `RecurrenceException` varchar(255) DEFAULT NULL,
  `doctor_id` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `IsAllDay` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`doctor_roster_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of doctor_roster
-- ----------------------------

-- ----------------------------
-- Table structure for drug_allergies
-- ----------------------------
DROP TABLE IF EXISTS `drug_allergies`;
CREATE TABLE `drug_allergies` (
  `drug_allergies_id` int(11) NOT NULL AUTO_INCREMENT,
  `drug_allergies_name` varchar(255) DEFAULT NULL,
  `drug_allergies_description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`drug_allergies_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of drug_allergies
-- ----------------------------

-- ----------------------------
-- Table structure for employee
-- ----------------------------
DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_name` varchar(255) DEFAULT NULL,
  `joining_date` varchar(255) DEFAULT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `role_type_id` int(11) DEFAULT NULL,
  `nid` int(11) DEFAULT NULL,
  `employee_code` varchar(255) DEFAULT NULL,
  `employee_user_name` varchar(255) DEFAULT NULL,
  `employee_password` varchar(255) DEFAULT NULL,
  `employee_email` varchar(255) DEFAULT NULL,
  `employee_address` varchar(255) DEFAULT NULL,
  `employee_serial` int(255) DEFAULT NULL,
  `hospital_id` int(11) DEFAULT NULL,
  `employee_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  KEY `fk_4` (`role_type_id`),
  KEY `fk_5` (`department_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of employee
-- ----------------------------
INSERT INTO `employee` VALUES ('1', 'Jakaria', 'Fri Jan 01 2016 00:00:00 GMT+0600 (Bangladesh Standard Time)', 'Manager Director', '3', '1', '1234567', null, 'jmj', '123456', null, null, null, '1', 'assigned');
INSERT INTO `employee` VALUES ('2', 'Rezwan', '8/11/2016', 'Professor', '2', '3', '1213456789', 'hms10001/2016', 'doctor', '1234', 'rezwan@gamil.com', null, '10001', '1', 'assigned');
INSERT INTO `employee` VALUES ('3', 'Test', '8/11/2016', 'test', '1', '3', '1234344', 'hms10002/2016', null, null, 'test@gmail.com', null, '10002', '1', 'assigned');
INSERT INTO `employee` VALUES ('4', 'Jobayed', '9/3/2016', 'Professor', '1', '3', null, 'hms10003/2016', null, null, 'jobayed@gmail.com', null, '10003', '1', 'assigned');
INSERT INTO `employee` VALUES ('5', 'Robi', '9/3/2016', 'Specialist', '3', '3', null, 'hms10004/2016', null, null, 'robi@gmail.com', null, '10004', '1', 'assigned');
INSERT INTO `employee` VALUES ('6', 'Smile', '9/3/2016', 'Intern Doctor', '1', '3', null, 'hms10005/2016', null, null, 'smile@gmail.com', null, '10005', '1', 'waiting');
INSERT INTO `employee` VALUES ('7', 'Tanvir', '9/3/2016', 'doctor', '2', '3', null, 'hms10006/2016', null, null, 'tan@gmail.com', 'Khulna', '10006', '1', 'waiting');
INSERT INTO `employee` VALUES ('8', 'Mainul', '9/3/2016', 'doctor', '3', '3', '123', 'hms10007/2016', null, null, 'mainul@gmail.com', 'tongi', '10007', '1', 'waiting');
INSERT INTO `employee` VALUES ('9', 'Wasse', '9/3/2016', 'Professor', '3', '3', null, 'hms10008/2016', null, null, 'wasse@gmail.com', 'mohamdpur', '10008', '1', 'waiting');
INSERT INTO `employee` VALUES ('10', 'Oshan', '9/6/2016', 'Doctor', '4', '3', null, 'hms10009/2016', null, null, 'oshan@gmail.com', 'Modupur', '10009', '1', 'assigned');
INSERT INTO `employee` VALUES ('11', null, null, null, null, null, null, 'hms10010/2016', null, null, null, null, '10010', null, 'waiting');

-- ----------------------------
-- Table structure for floor
-- ----------------------------
DROP TABLE IF EXISTS `floor`;
CREATE TABLE `floor` (
  `floor_id` int(11) NOT NULL AUTO_INCREMENT,
  `floor_name` varchar(255) DEFAULT NULL,
  `room_count` int(11) DEFAULT NULL,
  PRIMARY KEY (`floor_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of floor
-- ----------------------------
INSERT INTO `floor` VALUES ('1', 'First Floor', '20');
INSERT INTO `floor` VALUES ('2', 'Second Floor', '30');
INSERT INTO `floor` VALUES ('3', 'Third Floor', '10');

-- ----------------------------
-- Table structure for medicine
-- ----------------------------
DROP TABLE IF EXISTS `medicine`;
CREATE TABLE `medicine` (
  `medicine_id` int(11) NOT NULL AUTO_INCREMENT,
  `medicine_name` varchar(255) DEFAULT NULL,
  `company_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`medicine_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of medicine
-- ----------------------------
INSERT INTO `medicine` VALUES ('2', 'Napa', 'Saqure');
INSERT INTO `medicine` VALUES ('3', 'Napa Extra', 'Saqure');

-- ----------------------------
-- Table structure for medicine_power
-- ----------------------------
DROP TABLE IF EXISTS `medicine_power`;
CREATE TABLE `medicine_power` (
  `medicine_power_id` int(11) NOT NULL AUTO_INCREMENT,
  `medicine_power_value` varchar(255) DEFAULT NULL,
  `medicine_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`medicine_power_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of medicine_power
-- ----------------------------

-- ----------------------------
-- Table structure for meta_info
-- ----------------------------
DROP TABLE IF EXISTS `meta_info`;
CREATE TABLE `meta_info` (
  `meta_info_id` int(11) NOT NULL AUTO_INCREMENT,
  `hospital_id` int(11) DEFAULT NULL,
  `hospital_name` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `division_id` int(11) DEFAULT NULL,
  `district_id` int(11) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `fax` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `web` varchar(255) DEFAULT NULL,
  `logo_path` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`meta_info_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of meta_info
-- ----------------------------
INSERT INTO `meta_info` VALUES ('1', '1', 'JMJKollan Hospital', 'Gouripur', '3', '3', '01611011222', 'test34', 'jmjsaquib@gmail.com', 'test', '/Images/Uploads/Logo/index.png');
INSERT INTO `meta_info` VALUES ('2', '2', 'test', 'fsfds', '3', '3', 'sdfsd', 'sfd', 'sfsd', 'sfsd', '/Images/Uploads/Logo/java-logo-png-300x300.png');
INSERT INTO `meta_info` VALUES ('3', '3', 'gsdfg', 'fgsdfg', '2', '4', 'gsdfg', 'sgdfg', 'gsdfg', 'dfsg', '/Images/Uploads/Logo/java-logo-png-300x300.png');

-- ----------------------------
-- Table structure for module
-- ----------------------------
DROP TABLE IF EXISTS `module`;
CREATE TABLE `module` (
  `module_id` int(11) NOT NULL AUTO_INCREMENT,
  `module_name` varchar(255) DEFAULT NULL,
  `module_sort` int(11) DEFAULT NULL,
  `module_url` varchar(255) DEFAULT NULL,
  `module_parent_id` int(11) DEFAULT NULL,
  `module_alias` varchar(255) DEFAULT NULL,
  `module_icon` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`module_id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of module
-- ----------------------------
INSERT INTO `module` VALUES ('1', 'Dashboard', '1', 'dashboard/index', '0', 'dashboard', 'icon-projector-screen-line');
INSERT INTO `module` VALUES ('5', 'Disease', '6', '\'\'', '0', 'disease', 'fa fa-file-text');
INSERT INTO `module` VALUES ('6', 'Add New Disease', '5', 'userregistration/add', '5', 'addnewdiease', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('7', 'Employee Registration', '3', '\'\'', '0', 'userregistration', 'fa fa-user-md');
INSERT INTO `module` VALUES ('8', 'Add new Employee', '3', 'userregistration/add', '7', 'addnewuser', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('9', 'Employee List', '3', 'userregistration/list', '7', 'userlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('10', 'Division Entry', '4', 'division/index', '15', 'division', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('11', 'District Entry', '5', 'district/index', '15', 'district', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('12', 'Department', '6', 'department/index', '15', 'department', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('13', 'Cabin Type', '7', 'roomtype/index', '15', 'roomtype', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('14', 'Floor Entry', '8', 'floor/index', '15', 'floor', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('15', 'Hospital Design', '2', '\'\'', '0', 'hospitalDesing', 'glyphicon glyphicon-home');
INSERT INTO `module` VALUES ('16', 'Cabin Entry', '9', 'room/index', '15', 'room', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('17', 'Role Type Entry', '2', 'roletype/roletype', '15', 'roletype', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('18', 'Meta Information', '1', 'metainfo/index', '15', 'metainfo', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('19', 'Ward Management', '5', '\'\'', '0', 'ward', 'glyphicon glyphicon-book');
INSERT INTO `module` VALUES ('20', 'Ward List', '4', 'ward/index', '19', 'wardlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('21', 'Add new Ward', '4', 'ward/add', '19', 'wardadd', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('22', 'Patient Managment', '6', '\'\'', '0', 'patient', 'icon-group');
INSERT INTO `module` VALUES ('23', 'Patient List', '5', 'patient/index', '22', 'patientindex', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('24', 'Add New Patient', '5', 'patient/add', '22', 'patientadd', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('26', 'Appoinment', '5', 'appoinment/index', '22', 'appoinment', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('27', 'Doctor Management', '4', '\'\'', '0', 'doctor', 'fa fa-user-md');
INSERT INTO `module` VALUES ('28', 'Doctor List', '1', 'doctor/index', '27', 'doctorlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('29', 'Add New Doctor', '2', 'doctor/add', '27', 'doctoradd', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('31', 'Presscription Management', '8', '\'\'', '0', 'presscription', 'glyphicon glyphicon-book');
INSERT INTO `module` VALUES ('32', 'Medicine', '7', 'presscription/medicine', '31', 'presscriptionMedicine', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('33', 'Test Type', '7', 'presscription/testtype', '31', 'presscription', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('34', 'Presscription List', '7', 'presscription/index', '31', 'presscriptionindex', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('36', 'Ward Entry', '10', 'ward/home', '15', 'wardhome', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('37', 'Admission Management', '9', '\'\'', '0', 'admission', 'icon-shopping-cart');
INSERT INTO `module` VALUES ('38', 'Admission List', '8', 'admission/index', '37', 'admissionlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('39', 'Discharge Management', '11', '\'\'', '0', 'discharge', 'icon-shopping-cart');
INSERT INTO `module` VALUES ('40', 'Discharge List', '9', 'discharge/index', '39', 'dischargelist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('41', 'Discharge Type Entry', '9', 'discharge/dischargetype', '39', 'dischargetype', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('42', 'Bank Entry', '3', 'bank/index', '15', 'bank', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('43', 'Bill Management', '10', '\'\'', '0', 'bill', 'glyphicon glyphicon-list-alt');
INSERT INTO `module` VALUES ('44', 'Admission Bill', '1', 'payment/index', '43', 'billlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('45', 'Presscription', '5', 'patient/PresscriptionList', '22', 'presscription', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('46', 'Doctor Schedule', '3', 'doctor/DoctorSchedule', '27', 'doctorSchedule', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('47', 'Blood Donation', '12', '\'\'', '0', 'blood', 'fa fa-user-md');
INSERT INTO `module` VALUES ('48', 'Blood Donor List', '1', 'BloodDonation/index', '47', 'bloodlist', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('49', 'Add New Donor', '2', 'patient/add', '47', 'bloodAdd', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('50', 'Invoice List', '2', 'payment/invoicelist', '43', 'invoice', 'glyphicon glyphicon-hand-right');
INSERT INTO `module` VALUES ('51', 'Dashboard', '1', 'doctor/DoctorDashboard', '0', 'doctordashboard', 'icon-projector-screen-line');
INSERT INTO `module` VALUES ('52', 'Personal Roster', '2', 'doctor/DoctorPerosnalRoster', '0', 'doctorRoaser', 'glyphicon glyphicon-book');

-- ----------------------------
-- Table structure for nid
-- ----------------------------
DROP TABLE IF EXISTS `nid`;
CREATE TABLE `nid` (
  `nid_id` int(11) NOT NULL AUTO_INCREMENT,
  `nid_no` int(11) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`nid_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of nid
-- ----------------------------

-- ----------------------------
-- Table structure for patient
-- ----------------------------
DROP TABLE IF EXISTS `patient`;
CREATE TABLE `patient` (
  `patient_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `division_id` int(11) DEFAULT NULL,
  `district_id` int(11) DEFAULT NULL,
  `zip_code` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `nid_id` int(50) DEFAULT NULL,
  `role_type_id` int(11) DEFAULT NULL,
  `gender` varchar(255) DEFAULT NULL,
  `dob` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`patient_id`),
  KEY `fk_3` (`role_type_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of patient
-- ----------------------------
INSERT INTO `patient` VALUES ('1', 'jmj', '123456', 'Jakaria Muhammed Jakir', 'jmjsaquib@gmail.com', null, '2', '4', null, null, null, '1', 'male', '8/18/2016', 'admitted');
INSERT INTO `patient` VALUES ('2', null, null, 'JMJ', 'jmjsaquib@gmail.com', 'sdfd', '3', '3', '2270', '01611011222', '123456', null, 'male', '12/17/1991', 'appoinmented');
INSERT INTO `patient` VALUES ('3', null, null, 'Jobayed', 'shariya@gmail.com', 'Moghbazar', '2', '4', '90/80', '01979808808', '123456789', null, 'male', '6/21/1989', 'admitted');
INSERT INTO `patient` VALUES ('4', null, null, 'Tom', 'hh', 'USA', '2', '4', '110/20', '123', '123', '1', 'male', '8/12/2016', 'Death');
INSERT INTO `patient` VALUES ('5', null, null, 'Rezwan', 'rez@gmail.com', 'Dhanmondi', '2', '4', null, '123', null, '1', 'male', '8/1/2016', 'entry');
INSERT INTO `patient` VALUES ('6', null, null, 'Chekck', 'fg@gmail.com', 'Dhanmondi', '2', '4', '110/180', '123', '123456', '1', 'male', '8/18/2016', 'admitted');
INSERT INTO `patient` VALUES ('7', null, null, 'Test', 'test@gmail.com', 'tese', '2', '4', '111', '123', '123445', '1', 'male', '8/29/2016', 'admitted');
INSERT INTO `patient` VALUES ('8', null, null, 'tesf', 'fs@gmail.com', 'fsdsdf', '2', '4', null, '12345678901', null, '1', 'male', '9/3/2016', 'admitted');
INSERT INTO `patient` VALUES ('9', null, null, 'Test For all', 'gg@gmail.com', 'essd', '2', '4', '120', '01234567890', null, '1', 'male', '11/6/1993', 'presscribed');
INSERT INTO `patient` VALUES ('10', null, null, 'Ronnie', 'ronni@gmil.com', 'Ponchogor', '3', '3', '2270', '01611011222', '123456789', '1', 'male', '10/13/1989', 'entry');
INSERT INTO `patient` VALUES ('11', null, null, 'Oshan', 'oshan@gmail.com', 'Mymensingh', '3', '3', '2270', '01915487718', '123456789', '1', 'male', '6/5/1991', 'admitted');
INSERT INTO `patient` VALUES ('12', null, null, 'Shisho', 'shisho@gmail.com', 'Dhanmondi', '2', '4', null, '12112112112', null, '1', 'male', '9/6/2016', 'appoinmented');

-- ----------------------------
-- Table structure for patient_emergency_contact
-- ----------------------------
DROP TABLE IF EXISTS `patient_emergency_contact`;
CREATE TABLE `patient_emergency_contact` (
  `patient_emergency_id` int(11) NOT NULL AUTO_INCREMENT,
  `contact_person_name` varchar(255) DEFAULT NULL,
  `relation` varchar(255) DEFAULT NULL,
  `contact_person_mobile` varchar(255) DEFAULT NULL,
  `patient_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`patient_emergency_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of patient_emergency_contact
-- ----------------------------
INSERT INTO `patient_emergency_contact` VALUES ('1', 'Jobayed', 'brother', '01979088808', '2');
INSERT INTO `patient_emergency_contact` VALUES ('2', 'jmj', null, '016110111222', '3');
INSERT INTO `patient_emergency_contact` VALUES ('3', 'jerry', null, '123', '4');
INSERT INTO `patient_emergency_contact` VALUES ('4', 'shishu', null, '1123', '5');
INSERT INTO `patient_emergency_contact` VALUES ('5', 'folk', 'Brother', '12345678912', '6');
INSERT INTO `patient_emergency_contact` VALUES ('6', 'tesete', null, '1213123', '7');
INSERT INTO `patient_emergency_contact` VALUES ('7', 'tesrt', null, '12345678901', '8');
INSERT INTO `patient_emergency_contact` VALUES ('8', 'test', 'Relative', '01234567890', '9');
INSERT INTO `patient_emergency_contact` VALUES ('9', 'Jobayed', 'Relative', '01979008088', '10');
INSERT INTO `patient_emergency_contact` VALUES ('10', 'Jakaria', 'Brother', '01611011222', '11');
INSERT INTO `patient_emergency_contact` VALUES ('11', 'Borsho', 'Brother', '01914000000', '12');

-- ----------------------------
-- Table structure for patient_health_condition
-- ----------------------------
DROP TABLE IF EXISTS `patient_health_condition`;
CREATE TABLE `patient_health_condition` (
  `patient_health_condition_id` int(11) NOT NULL AUTO_INCREMENT,
  `health_condition_name` varchar(255) DEFAULT NULL,
  `health_condition_description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`patient_health_condition_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of patient_health_condition
-- ----------------------------

-- ----------------------------
-- Table structure for patient_health_info
-- ----------------------------
DROP TABLE IF EXISTS `patient_health_info`;
CREATE TABLE `patient_health_info` (
  `medical_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `blood_group` varchar(255) DEFAULT NULL,
  `blood_pressure` varchar(255) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `weight` double DEFAULT NULL,
  `height` double DEFAULT NULL,
  PRIMARY KEY (`medical_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of patient_health_info
-- ----------------------------
INSERT INTO `patient_health_info` VALUES ('1', '2', 'B+', '110/90', '23', '62', '65');
INSERT INTO `patient_health_info` VALUES ('2', '3', 'A+', '90/80', '26', '55', '64');
INSERT INTO `patient_health_info` VALUES ('3', '4', 'AB+', '110/20', '50', '60', '65');
INSERT INTO `patient_health_info` VALUES ('4', '5', 'A+', null, '24', '105', '72');
INSERT INTO `patient_health_info` VALUES ('5', '6', 'A+', '110/180', '26', '85', '65');
INSERT INTO `patient_health_info` VALUES ('6', '7', 'B+', '111', '22', '110', '65');
INSERT INTO `patient_health_info` VALUES ('7', '8', 'A+', null, '22', null, null);
INSERT INTO `patient_health_info` VALUES ('8', '9', 'A-', '120', '22', '62', '65');
INSERT INTO `patient_health_info` VALUES ('9', '10', 'B+', null, '26', '80', '65');
INSERT INTO `patient_health_info` VALUES ('10', '11', 'A+', null, '25', '60', '62');
INSERT INTO `patient_health_info` VALUES ('11', '12', 'O+', null, '0', '100', '73');

-- ----------------------------
-- Table structure for patient_tracking
-- ----------------------------
DROP TABLE IF EXISTS `patient_tracking`;
CREATE TABLE `patient_tracking` (
  `patient_tracking_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `entry_date` varchar(255) DEFAULT NULL,
  `appoinment_date` varchar(255) DEFAULT NULL,
  `presscription_date` varchar(255) DEFAULT NULL,
  `admission_date` varchar(255) DEFAULT NULL,
  `invoice_date` varchar(255) DEFAULT NULL,
  `discharge_date` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`patient_tracking_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of patient_tracking
-- ----------------------------

-- ----------------------------
-- Table structure for payment
-- ----------------------------
DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_type_id` int(11) DEFAULT NULL,
  `patient_id` int(11) DEFAULT NULL,
  `admission_id` int(11) DEFAULT NULL,
  `discharge_id` int(11) DEFAULT NULL,
  `payment_method_id` int(11) DEFAULT NULL,
  `payment_date` date DEFAULT NULL,
  `amount_without_adjustment` decimal(10,0) DEFAULT NULL,
  `adjustment_criteria` varchar(10) DEFAULT NULL,
  `adjustment_amount` decimal(10,0) DEFAULT NULL,
  `amount_with_adjustment` decimal(10,0) DEFAULT NULL,
  `chargable_days` int(11) DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payment
-- ----------------------------
INSERT INTO `payment` VALUES ('1', null, '7', null, '15', '1', '2016-09-02', '1000', '0', '5', '950', '2');
INSERT INTO `payment` VALUES ('2', null, '7', null, '16', '1', '2016-09-02', '2000', '0', '50', '1000', '3');
INSERT INTO `payment` VALUES ('3', null, '7', null, '17', '1', '2016-09-02', '2000', '0', '50', '1000', '2');
INSERT INTO `payment` VALUES ('4', null, '7', '20', '18', '1', '2016-09-01', '2000', '0', '5', '1900', '2');
INSERT INTO `payment` VALUES ('5', null, '7', '20', '19', '2', '2016-09-04', '1000', '0', '5', '950', '1');
INSERT INTO `payment` VALUES ('6', null, '6', '13', '20', '1', '2016-09-04', '5500', '0', '500', '5000', '2');
INSERT INTO `payment` VALUES ('7', null, '7', '20', '21', '1', '2016-09-04', '2000', '0', '500', '1500', '2');
INSERT INTO `payment` VALUES ('8', null, '4', '6', '22', '1', '2016-09-04', '4200', '0', '5', '3990', '2');
INSERT INTO `payment` VALUES ('9', null, '4', '7', '23', '1', '2016-09-04', '2000', '0', '5', '1900', '2');
INSERT INTO `payment` VALUES ('10', null, '4', '5', '24', '1', '2016-09-08', '6000', '0', '500', '5500', '2');
INSERT INTO `payment` VALUES ('11', null, '7', '20', '25', '1', '2016-09-04', '1000', '0', '5', '950', '2');
INSERT INTO `payment` VALUES ('12', null, '7', '20', '26', '2', '2016-09-08', '1000', '0', '5', '950', '2');
INSERT INTO `payment` VALUES ('13', null, '10', '21', '27', '1', '2016-09-01', '500', '0', '5', '475', '2');
INSERT INTO `payment` VALUES ('14', null, '11', '22', '28', '1', '2016-09-05', '30000', '0', '500', '29500', '2');
INSERT INTO `payment` VALUES ('15', null, '12', '24', '29', '1', '2016-09-06', '10000', 'Percentage', '5', '9500', '2');
INSERT INTO `payment` VALUES ('16', null, '3', '23', '30', '1', '2016-09-07', '0', 'Percentage', '20', '30', '2');
INSERT INTO `payment` VALUES ('17', null, '8', '25', '31', '1', '2016-09-07', '10000', 'Amount', '5', '9500', '2');
INSERT INTO `payment` VALUES ('19', null, '6', '26', '32', '1', '2016-08-31', '900', 'Percentage', '2', '882', '3');
INSERT INTO `payment` VALUES ('20', null, '1', '27', '33', '1', '2016-09-08', '2400', 'Percentage', '6', '2256', '3');

-- ----------------------------
-- Table structure for payment_cheque_details
-- ----------------------------
DROP TABLE IF EXISTS `payment_cheque_details`;
CREATE TABLE `payment_cheque_details` (
  `payment_cheque_details_id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_id` int(11) DEFAULT NULL,
  `cheque_no` int(11) DEFAULT NULL,
  `account_no` int(11) DEFAULT NULL,
  `check_date` date DEFAULT NULL,
  `payment_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`payment_cheque_details_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payment_cheque_details
-- ----------------------------
INSERT INTO `payment_cheque_details` VALUES ('1', null, null, null, null, '1');
INSERT INTO `payment_cheque_details` VALUES ('2', null, null, null, null, '2');
INSERT INTO `payment_cheque_details` VALUES ('3', null, null, null, null, '3');
INSERT INTO `payment_cheque_details` VALUES ('4', null, null, null, null, '4');
INSERT INTO `payment_cheque_details` VALUES ('5', '1', '123', '19999', '2016-09-06', '5');
INSERT INTO `payment_cheque_details` VALUES ('6', null, null, null, null, '6');
INSERT INTO `payment_cheque_details` VALUES ('7', null, null, null, null, '7');
INSERT INTO `payment_cheque_details` VALUES ('8', null, null, null, null, '8');
INSERT INTO `payment_cheque_details` VALUES ('9', null, null, null, null, '9');
INSERT INTO `payment_cheque_details` VALUES ('10', null, null, null, null, '10');
INSERT INTO `payment_cheque_details` VALUES ('11', null, null, null, null, '11');
INSERT INTO `payment_cheque_details` VALUES ('12', '2', '12345', '123456', '2016-09-06', '12');
INSERT INTO `payment_cheque_details` VALUES ('13', null, null, null, null, '13');
INSERT INTO `payment_cheque_details` VALUES ('14', null, null, null, null, '14');
INSERT INTO `payment_cheque_details` VALUES ('15', null, null, null, null, '15');
INSERT INTO `payment_cheque_details` VALUES ('16', null, null, null, null, '16');
INSERT INTO `payment_cheque_details` VALUES ('17', null, null, null, null, '17');
INSERT INTO `payment_cheque_details` VALUES ('18', null, null, null, null, '19');
INSERT INTO `payment_cheque_details` VALUES ('19', null, null, null, null, '20');

-- ----------------------------
-- Table structure for payment_method
-- ----------------------------
DROP TABLE IF EXISTS `payment_method`;
CREATE TABLE `payment_method` (
  `payment_method_id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_method_name` varchar(255) DEFAULT NULL,
  `payment_method_description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`payment_method_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payment_method
-- ----------------------------
INSERT INTO `payment_method` VALUES ('1', 'Cash', 'Total Cash');
INSERT INTO `payment_method` VALUES ('2', 'Personal Cheque', 'Cheque.');

-- ----------------------------
-- Table structure for payment_type
-- ----------------------------
DROP TABLE IF EXISTS `payment_type`;
CREATE TABLE `payment_type` (
  `payment_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_type_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`payment_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of payment_type
-- ----------------------------
INSERT INTO `payment_type` VALUES ('1', 'Inpatient');
INSERT INTO `payment_type` VALUES ('2', 'Outpatient');
INSERT INTO `payment_type` VALUES ('3', 'Physician Fees');
INSERT INTO `payment_type` VALUES ('4', 'Admission Fees');
INSERT INTO `payment_type` VALUES ('5', 'Discharge Fees');

-- ----------------------------
-- Table structure for presscription
-- ----------------------------
DROP TABLE IF EXISTS `presscription`;
CREATE TABLE `presscription` (
  `prescription_id` int(11) NOT NULL AUTO_INCREMENT,
  `patient_id` int(11) DEFAULT NULL,
  `appoinment_id` int(11) DEFAULT NULL,
  `presscription_date` varchar(255) DEFAULT NULL,
  `need_admission` varchar(255) DEFAULT NULL,
  `disease_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`prescription_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription
-- ----------------------------
INSERT INTO `presscription` VALUES ('11', '2', '4', '13/08/2016 04:21:14', 'no', null);
INSERT INTO `presscription` VALUES ('12', '4', '5', '15/08/2016 14:36:53', 'yes', null);
INSERT INTO `presscription` VALUES ('13', '6', '7', '25/08/2016 00:57:58', 'yes', null);
INSERT INTO `presscription` VALUES ('14', '5', '6', '25/08/2016 01:41:06', 'yes', null);
INSERT INTO `presscription` VALUES ('15', '5', '6', '25/08/2016 01:41:15', 'yes', null);
INSERT INTO `presscription` VALUES ('16', '5', '6', '25/08/2016 01:41:22', 'yes', null);
INSERT INTO `presscription` VALUES ('17', '1', '8', '27/08/2016 23:46:33', 'yes', null);
INSERT INTO `presscription` VALUES ('18', '7', '9', '28/08/2016 13:09:30', 'yes', null);
INSERT INTO `presscription` VALUES ('19', '7', '9', '28/08/2016 13:09:38', 'yes', null);
INSERT INTO `presscription` VALUES ('20', '3', '1', '01/09/2016 22:42:19', 'yes', null);
INSERT INTO `presscription` VALUES ('21', '3', '1', '01/09/2016 22:42:55', 'yes', null);
INSERT INTO `presscription` VALUES ('22', '6', '7', '01/09/2016 23:17:30', 'yes', null);
INSERT INTO `presscription` VALUES ('23', '9', '11', '02/09/2016 00:11:32', 'no', null);
INSERT INTO `presscription` VALUES ('24', '10', '37', '04/09/2016 20:41:08', 'yes', null);
INSERT INTO `presscription` VALUES ('25', '11', '38', '05/09/2016 17:35:20', 'yes', null);
INSERT INTO `presscription` VALUES ('26', '12', '39', '06/09/2016 16:52:08', 'yes', null);
INSERT INTO `presscription` VALUES ('27', '12', '39', '06/09/2016 16:52:14', 'yes', null);
INSERT INTO `presscription` VALUES ('28', '8', '14', '07/09/2016 01:56:03', 'yes', null);
INSERT INTO `presscription` VALUES ('29', '6', '10', '07/09/2016 05:32:04', 'yes', null);

-- ----------------------------
-- Table structure for presscription_complaints_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_complaints_mapping`;
CREATE TABLE `presscription_complaints_mapping` (
  `presscription_complaints_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `chief_complaints` varchar(255) DEFAULT NULL,
  `chief_complaints_duration` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`presscription_complaints_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_complaints_mapping
-- ----------------------------
INSERT INTO `presscription_complaints_mapping` VALUES ('1', '21', 'backpain', '6 months');
INSERT INTO `presscription_complaints_mapping` VALUES ('2', '21', 'Pain', '2 months');
INSERT INTO `presscription_complaints_mapping` VALUES ('3', '21', 'Headache', '4 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('4', '22', 'Fever', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('5', '23', 'Headache', '1 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('6', '24', 'Headache', '1 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('7', '25', 'Headache', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('8', '26', 'test', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('9', '26', 'Headache', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('10', '27', 'test', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('11', '27', 'Headache', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('12', '28', 'Headache', '2 Week');
INSERT INTO `presscription_complaints_mapping` VALUES ('13', '29', 'Headache', '1 Week');

-- ----------------------------
-- Table structure for presscription_drug_allergies_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_drug_allergies_mapping`;
CREATE TABLE `presscription_drug_allergies_mapping` (
  `presscription_drug_allergies_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `drug_allergies_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`presscription_drug_allergies_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_drug_allergies_mapping
-- ----------------------------
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('22', '11', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('23', '11', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('24', '12', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('25', '12', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('26', '13', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('27', '13', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('28', '13', 'Chemotherapy drugs');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('29', '16', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('30', '16', 'Chemotherapy drugs');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('31', '16', 'Other');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('32', '17', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('33', '19', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('34', '19', 'Anticonvulsants');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('35', '21', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('36', '21', 'Anticonvulsants');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('37', '22', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('38', '22', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('39', '23', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('40', '23', 'Anticonvulsants');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('41', '24', 'Penicillin and related antibiotics');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('42', '24', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('43', '25', 'Sulfa');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('44', '25', 'Anticonvulsants');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('45', '26', 'none');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('46', '27', 'none');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('47', '28', 'none');
INSERT INTO `presscription_drug_allergies_mapping` VALUES ('48', '29', 'Penicillin and related antibiotics');

-- ----------------------------
-- Table structure for presscription_health_condition_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_health_condition_mapping`;
CREATE TABLE `presscription_health_condition_mapping` (
  `presscription_health_condition_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `health_condition_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`presscription_health_condition_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_health_condition_mapping
-- ----------------------------
INSERT INTO `presscription_health_condition_mapping` VALUES ('8', '11', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('9', '11', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('10', '12', 'none');
INSERT INTO `presscription_health_condition_mapping` VALUES ('11', '12', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('12', '13', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('13', '13', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('14', '16', 'none');
INSERT INTO `presscription_health_condition_mapping` VALUES ('15', '16', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('16', '17', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('17', '19', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('18', '19', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('19', '21', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('20', '21', 'Kidney Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('21', '22', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('22', '22', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('23', '23', 'none');
INSERT INTO `presscription_health_condition_mapping` VALUES ('24', '24', 'none');
INSERT INTO `presscription_health_condition_mapping` VALUES ('25', '25', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('26', '26', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('27', '26', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('28', '27', 'asthma');
INSERT INTO `presscription_health_condition_mapping` VALUES ('29', '27', 'Liver Problem');
INSERT INTO `presscription_health_condition_mapping` VALUES ('30', '28', 'none');
INSERT INTO `presscription_health_condition_mapping` VALUES ('31', '29', 'Liver Problem');

-- ----------------------------
-- Table structure for presscription_medicine_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_medicine_mapping`;
CREATE TABLE `presscription_medicine_mapping` (
  `presscription_medicine_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `medicine_id` int(11) DEFAULT NULL,
  `medicine_power` varchar(255) DEFAULT NULL,
  `dosage` varchar(255) DEFAULT NULL,
  `how_long` varchar(255) DEFAULT NULL,
  `route_of_administration` varchar(255) DEFAULT NULL,
  `rules` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`presscription_medicine_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_medicine_mapping
-- ----------------------------
INSERT INTO `presscription_medicine_mapping` VALUES ('4', '11', '3', '10 mg', '1+1+0', '2 Week', null, null);
INSERT INTO `presscription_medicine_mapping` VALUES ('5', '11', '2', '20 mg', '1+1+1', '1 Week', null, null);
INSERT INTO `presscription_medicine_mapping` VALUES ('6', '12', '2', '20 mg', '1+1+1', '1 Week', null, null);
INSERT INTO `presscription_medicine_mapping` VALUES ('7', '13', '3', '26 mg', '1+1+0', '3 Week', null, 'After Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('8', '13', '2', '20 mg', '1+1+1', '2 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('9', '16', '2', '20 mg', '1+1+1', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('10', '17', '2', '20 mg', '1+1+1', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('11', '19', '2', '20 mg', '1+1+1', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('12', '21', '3', '10 mg', '1+1+0', '2 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('13', '21', '2', '10 mg', '1+1+0', '2 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('14', '22', '2', '480 mg', '1+1+0', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('15', '23', '2', '180 mg', '1+1+0', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('16', '24', '2', '2 mg', '1+1+0', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('17', '25', '2', '500 mg', '1+1+0', '2 Week', null, 'After Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('18', '26', '2', '500 mg', '1+0+1', '2 Week', null, 'After Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('19', '27', '2', '500 mg', '1+0+1', '2 Week', null, 'After Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('20', '28', '2', '10 mg', '1+1+0', '1 Week', null, 'Before Meal');
INSERT INTO `presscription_medicine_mapping` VALUES ('21', '29', '2', '2 mg', '1+0+0', '3 Week', null, 'Before Meal');

-- ----------------------------
-- Table structure for presscription_suggestion_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_suggestion_mapping`;
CREATE TABLE `presscription_suggestion_mapping` (
  `presscription_suggestion_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `suggestion_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`presscription_suggestion_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_suggestion_mapping
-- ----------------------------
INSERT INTO `presscription_suggestion_mapping` VALUES ('17', '11', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('18', '11', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('19', '12', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('20', '12', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('21', '13', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('22', '13', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('23', '13', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('24', '16', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('25', '16', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('26', '17', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('27', '18', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('28', '19', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('29', '21', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('30', '21', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('31', '22', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('32', '22', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('33', '23', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('34', '23', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('35', '24', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('36', '24', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('37', '25', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('38', '25', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('39', '26', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('40', '26', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('41', '27', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('42', '27', 'Eat Fruits');
INSERT INTO `presscription_suggestion_mapping` VALUES ('43', '28', 'Take Rest');
INSERT INTO `presscription_suggestion_mapping` VALUES ('44', '29', 'Walking');
INSERT INTO `presscription_suggestion_mapping` VALUES ('45', '29', 'Take Rest');

-- ----------------------------
-- Table structure for presscription_test_type_mapping
-- ----------------------------
DROP TABLE IF EXISTS `presscription_test_type_mapping`;
CREATE TABLE `presscription_test_type_mapping` (
  `prescription_test_type_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `presscription_id` int(11) DEFAULT NULL,
  `test_type_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`prescription_test_type_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of presscription_test_type_mapping
-- ----------------------------
INSERT INTO `presscription_test_type_mapping` VALUES ('5', '11', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('6', '11', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('7', '12', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('8', '12', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('9', '13', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('10', '13', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('11', '16', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('12', '17', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('13', '17', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('14', '19', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('15', '21', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('16', '21', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('17', '22', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('18', '22', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('19', '23', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('20', '23', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('21', '24', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('22', '24', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('23', '25', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('24', '26', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('25', '26', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('26', '27', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('27', '27', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('28', '28', '1');
INSERT INTO `presscription_test_type_mapping` VALUES ('29', '28', '4');
INSERT INTO `presscription_test_type_mapping` VALUES ('30', '29', '4');

-- ----------------------------
-- Table structure for role_permission
-- ----------------------------
DROP TABLE IF EXISTS `role_permission`;
CREATE TABLE `role_permission` (
  `role_permission_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_type_id` int(11) DEFAULT NULL,
  `module_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`role_permission_id`),
  KEY `fk_1` (`module_id`),
  KEY `fk_2` (`role_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of role_permission
-- ----------------------------
INSERT INTO `role_permission` VALUES ('1', '1', '1');
INSERT INTO `role_permission` VALUES ('4', '1', '4');
INSERT INTO `role_permission` VALUES ('5', '1', '5');
INSERT INTO `role_permission` VALUES ('6', '1', '6');
INSERT INTO `role_permission` VALUES ('7', '1', '7');
INSERT INTO `role_permission` VALUES ('8', '1', '8');
INSERT INTO `role_permission` VALUES ('9', '1', '9');
INSERT INTO `role_permission` VALUES ('10', '1', '16');
INSERT INTO `role_permission` VALUES ('11', '1', '17');
INSERT INTO `role_permission` VALUES ('12', '1', '10');
INSERT INTO `role_permission` VALUES ('13', '1', '11');
INSERT INTO `role_permission` VALUES ('14', '1', '12');
INSERT INTO `role_permission` VALUES ('15', '1', '13');
INSERT INTO `role_permission` VALUES ('16', '1', '14');
INSERT INTO `role_permission` VALUES ('17', '1', '15');
INSERT INTO `role_permission` VALUES ('18', '1', '18');
INSERT INTO `role_permission` VALUES ('19', '1', '19');
INSERT INTO `role_permission` VALUES ('20', '1', '20');
INSERT INTO `role_permission` VALUES ('21', '1', '21');
INSERT INTO `role_permission` VALUES ('22', '1', '22');
INSERT INTO `role_permission` VALUES ('23', '1', '23');
INSERT INTO `role_permission` VALUES ('24', '1', '24');
INSERT INTO `role_permission` VALUES ('26', '1', '26');
INSERT INTO `role_permission` VALUES ('27', '1', '27');
INSERT INTO `role_permission` VALUES ('28', '1', '28');
INSERT INTO `role_permission` VALUES ('29', '1', '29');
INSERT INTO `role_permission` VALUES ('31', '1', '31');
INSERT INTO `role_permission` VALUES ('32', '1', '32');
INSERT INTO `role_permission` VALUES ('33', '1', '33');
INSERT INTO `role_permission` VALUES ('34', '1', '34');
INSERT INTO `role_permission` VALUES ('36', '1', '36');
INSERT INTO `role_permission` VALUES ('37', '1', '37');
INSERT INTO `role_permission` VALUES ('38', '1', '38');
INSERT INTO `role_permission` VALUES ('39', '1', '39');
INSERT INTO `role_permission` VALUES ('40', '1', '40');
INSERT INTO `role_permission` VALUES ('41', '1', '41');
INSERT INTO `role_permission` VALUES ('42', '1', '42');
INSERT INTO `role_permission` VALUES ('43', '1', '43');
INSERT INTO `role_permission` VALUES ('44', '1', '44');
INSERT INTO `role_permission` VALUES ('45', '1', '45');
INSERT INTO `role_permission` VALUES ('46', '1', '46');
INSERT INTO `role_permission` VALUES ('47', '1', '47');
INSERT INTO `role_permission` VALUES ('48', '1', '48');
INSERT INTO `role_permission` VALUES ('49', '1', '49');
INSERT INTO `role_permission` VALUES ('50', '1', '50');
INSERT INTO `role_permission` VALUES ('51', '3', '51');
INSERT INTO `role_permission` VALUES ('52', '3', '52');

-- ----------------------------
-- Table structure for role_type
-- ----------------------------
DROP TABLE IF EXISTS `role_type`;
CREATE TABLE `role_type` (
  `role_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(255) DEFAULT NULL,
  `role_description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`role_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of role_type
-- ----------------------------
INSERT INTO `role_type` VALUES ('1', 'admin', 'this is admin role.');
INSERT INTO `role_type` VALUES ('2', 'patient', 'this is patient role.');
INSERT INTO `role_type` VALUES ('3', 'doctor', 'this is doctor role.');
INSERT INTO `role_type` VALUES ('5', 'Staff', 'this is staff role.');
INSERT INTO `role_type` VALUES ('6', 'Nurse', 'This is nurse role.');

-- ----------------------------
-- Table structure for room
-- ----------------------------
DROP TABLE IF EXISTS `room`;
CREATE TABLE `room` (
  `room_id` int(11) NOT NULL AUTO_INCREMENT,
  `room_no` varchar(255) DEFAULT NULL,
  `room_description` varchar(255) DEFAULT NULL,
  `room_type_id` int(11) DEFAULT NULL,
  `floor_id` int(11) DEFAULT NULL,
  `no_of_bed` int(11) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `room_assign_bed` int(11) DEFAULT NULL,
  `room_rest_bed` int(11) DEFAULT NULL,
  PRIMARY KEY (`room_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of room
-- ----------------------------
INSERT INTO `room` VALUES ('1', 'cabin101', 'No ac', '1', '1', '2', 'Waiting', '1', '-2', '4');
INSERT INTO `room` VALUES ('2', 'cabin102', 'ac', '2', '2', '3', 'full', '1', '3', '0');
INSERT INTO `room` VALUES ('3', 'cabin103', 'ac best', '3', '2', '2', 'Waiting', '2', '1', '1');
INSERT INTO `room` VALUES ('4', 'Cabin 101', 'dfd', '1', '1', '2', 'full', '2', '2', '0');
INSERT INTO `room` VALUES ('5', 'Surgery Cabin', 'fd', '2', '3', '2', 'Waiting', '4', '1', '1');

-- ----------------------------
-- Table structure for room_type
-- ----------------------------
DROP TABLE IF EXISTS `room_type`;
CREATE TABLE `room_type` (
  `room_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `room_type_name` varchar(255) DEFAULT NULL,
  `rent` decimal(10,0) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`room_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of room_type
-- ----------------------------
INSERT INTO `room_type` VALUES ('1', 'General', '500', 'Non AC, General ward');
INSERT INTO `room_type` VALUES ('2', 'VIP', '5000', 'Only for VIP patient.');
INSERT INTO `room_type` VALUES ('3', 'AC', '2000', 'AC room. For all.');

-- ----------------------------
-- Table structure for room_ward_mapping
-- ----------------------------
DROP TABLE IF EXISTS `room_ward_mapping`;
CREATE TABLE `room_ward_mapping` (
  `room_ward_mapping_id` int(11) NOT NULL AUTO_INCREMENT,
  `room_id` int(11) DEFAULT NULL,
  `ward_id` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `assigned_date` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`room_ward_mapping_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of room_ward_mapping
-- ----------------------------
INSERT INTO `room_ward_mapping` VALUES ('1', '1', '2', '1', '08/08/2016 14:41:19');
INSERT INTO `room_ward_mapping` VALUES ('2', '1', '3', '1', '08/08/2016 14:44:11');
INSERT INTO `room_ward_mapping` VALUES ('3', '2', '3', '1', '08/08/2016 14:44:25');
INSERT INTO `room_ward_mapping` VALUES ('4', '1', '4', '1', '08/08/2016 14:47:52');
INSERT INTO `room_ward_mapping` VALUES ('5', '2', '4', '1', '08/08/2016 14:48:06');
INSERT INTO `room_ward_mapping` VALUES ('6', '1', '5', '1', '08/08/2016 14:54:09');
INSERT INTO `room_ward_mapping` VALUES ('7', '2', '5', '1', '08/08/2016 14:54:24');
INSERT INTO `room_ward_mapping` VALUES ('8', '1', '6', '2', '08/08/2016 15:39:58');
INSERT INTO `room_ward_mapping` VALUES ('9', '2', '6', '2', '08/08/2016 15:39:58');
INSERT INTO `room_ward_mapping` VALUES ('10', '2', '7', '2', '10/08/2016 18:56:26');
INSERT INTO `room_ward_mapping` VALUES ('11', '3', '7', '2', '10/08/2016 18:56:26');

-- ----------------------------
-- Table structure for suggestion
-- ----------------------------
DROP TABLE IF EXISTS `suggestion`;
CREATE TABLE `suggestion` (
  `suggestion_id` int(11) NOT NULL AUTO_INCREMENT,
  `suggestion_name` varchar(255) DEFAULT NULL,
  `for_whom` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`suggestion_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of suggestion
-- ----------------------------

-- ----------------------------
-- Table structure for test_type
-- ----------------------------
DROP TABLE IF EXISTS `test_type`;
CREATE TABLE `test_type` (
  `test_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `test_type_name` varchar(255) DEFAULT NULL,
  `test_cost` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`test_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of test_type
-- ----------------------------
INSERT INTO `test_type` VALUES ('1', 'Blood', '500');
INSERT INTO `test_type` VALUES ('3', 'Urine', '1000');
INSERT INTO `test_type` VALUES ('4', 'MRI', '14000');

-- ----------------------------
-- Table structure for ward
-- ----------------------------
DROP TABLE IF EXISTS `ward`;
CREATE TABLE `ward` (
  `ward_id` int(11) NOT NULL AUTO_INCREMENT,
  `ward_no` varchar(255) DEFAULT NULL,
  `ward_name` varchar(255) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `total_bed` int(11) DEFAULT NULL,
  `ward_type` varchar(255) DEFAULT NULL,
  `ward_for_whom` varchar(255) DEFAULT NULL,
  `bed_cost` decimal(10,0) DEFAULT NULL,
  `floor_id` int(11) DEFAULT NULL,
  `wing` varchar(255) DEFAULT NULL,
  `assign_bed` int(11) DEFAULT NULL,
  `rest_bed` int(11) DEFAULT NULL,
  `ward_status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ward_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ward
-- ----------------------------
INSERT INTO `ward` VALUES ('1', 'ward101', 'ward101', '1', '50', 'general', 'male', '0', '1', 'right', '2', '48', 'waiting');
INSERT INTO `ward` VALUES ('2', 'ward102', 'ward102', '2', '60', 'paid', 'male', '500', '2', 'left', '0', '60', 'waiting');
INSERT INTO `ward` VALUES ('3', 'ward103', 'ward103', '2', '20', 'paid', 'female', '1000', '2', 'right', '-1', '21', 'waiting');
INSERT INTO `ward` VALUES ('4', 'Test2', 'Test', '2', '30', 'general', 'male', '0', '1', 'left', '0', '30', 'waiting');
INSERT INTO `ward` VALUES ('5', 'Surgery Ward', 'Surgery Ward', '4', '30', 'paid', 'male', '500', '3', 'right', '0', '30', 'waiting');
