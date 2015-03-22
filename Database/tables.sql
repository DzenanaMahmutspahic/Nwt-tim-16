IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Korisnik
GO
CREATE TABLE Korisnik(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(25) NOT NULL UNIQUE,
	Password VARCHAR(25) NOT NULL,
	Ime VARCHAR(35) NOT NULL,
	Prezime VARCHAR(35) NOT NULL,
	Pozicija VARCHAR(50),
	CONSTRAINT unique_Username UNIQUE (Username)
)
