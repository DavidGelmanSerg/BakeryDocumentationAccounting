SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `Flour`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Flour` ;

CREATE TABLE IF NOT EXISTS `Flour` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `humidity` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Materials`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Materials` ;

CREATE TABLE IF NOT EXISTS `Materials` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `flour` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Materials_Flour1_idx` (`flour` ASC) VISIBLE,
  CONSTRAINT `fk_Materials_Flour1`
    FOREIGN KEY (`flour`)
    REFERENCES `Flour` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Production`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Production` ;

CREATE TABLE IF NOT EXISTS `Production` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `weight` DECIMAL(10,2) NOT NULL,
  `restBeforeShift` INT NOT NULL,
  `prodAmount` INT NOT NULL,
  `prodKg` DECIMAL(10,2) NOT NULL,
  `defectAmount` INT NOT NULL,
  `defectKg` DECIMAL(10,2) NOT NULL,
  `output` INT NOT NULL,
  `restAfterShift` INT NOT NULL,
  `materials` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Production_Materials1_idx` (`materials` ASC) VISIBLE,
  CONSTRAINT `fk_Production_Materials1`
    FOREIGN KEY (`materials`)
    REFERENCES `Materials` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Ingridient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Ingridient` ;

CREATE TABLE IF NOT EXISTS `Ingridient` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `value` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Materials_has_Ingridient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Materials_has_Ingridient` ;

CREATE TABLE IF NOT EXISTS `Materials_has_Ingridient` (
  `Materials` INT NOT NULL,
  `Ingridient` INT NOT NULL,
  PRIMARY KEY (`Materials`, `Ingridient`),
  INDEX `fk_Materials_has_Ingridient_Ingridient1_idx` (`Ingridient` ASC) VISIBLE,
  INDEX `fk_Materials_has_Ingridient_Materials_idx` (`Materials` ASC) VISIBLE,
  CONSTRAINT `fk_Materials_has_Ingridient_Materials`
    FOREIGN KEY (`Materials`)
    REFERENCES `Materials` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Materials_has_Ingridient_Ingridient1`
    FOREIGN KEY (`Ingridient`)
    REFERENCES `Ingridient` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `EconomicParameter`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `EconomicParameter` ;

CREATE TABLE IF NOT EXISTS `EconomicParameter` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `value` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Production_has_EconomicParameter`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Production_has_EconomicParameter` ;

CREATE TABLE IF NOT EXISTS `Production_has_EconomicParameter` (
  `Production` INT NOT NULL,
  `EconomicParameter` INT NOT NULL,
  PRIMARY KEY (`Production`, `EconomicParameter`),
  INDEX `fk_Production_has_EconomicParameter_EconomicParameter1_idx` (`EconomicParameter` ASC) VISIBLE,
  INDEX `fk_Production_has_EconomicParameter_Production1_idx` (`Production` ASC) VISIBLE,
  CONSTRAINT `fk_Production_has_EconomicParameter_Production1`
    FOREIGN KEY (`Production`)
    REFERENCES `Production` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Production_has_EconomicParameter_EconomicParameter1`
    FOREIGN KEY (`EconomicParameter`)
    REFERENCES `EconomicParameter` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
