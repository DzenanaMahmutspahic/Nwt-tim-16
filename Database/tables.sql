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


IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Montaza
GO
CREATE TABLE Montaza(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Snimanje_materijal VARCHAR(25) NOT NULL,
	Snimanje_sati DECIMAL NOT NULL,
	Snimanje_cijena DECIMAL NOT NULL,
	Montaza_materijal VARCHAR(50) NOT NULL,
	Montaza_sati DECIMAL NOT NULL,
	Montaza_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Status_montaze INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)

IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE DTP
GO
CREATE TABLE DTP(
	DTP_ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Sofp_materijal VARCHAR(25) NOT NULL,
	Sofp_sati DECIMAL NOT NULL,
	Sofp_cijena DECIMAL NOT NULL,
	Fotografija_materijal VARCHAR(50) NOT NULL,
	Fotografija_sati DECIMAL NOT NULL,
	Fotografija_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_DTP INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)

IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Stampa
GO
CREATE TABLE Stampa(
	Stampa_ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Priprema4b_materijal VARCHAR(25) NOT NULL,
	Priprema4b_sati DECIMAL NOT NULL,
	Priprema4b_cijena DECIMAL NOT NULL,
	GTO1_materijal VARCHAR(50) NOT NULL,
	GTO1_sati DECIMAL NOT NULL,
	GTO1_cijena DECIMAL NOT NULL,
	PripremaB2_materijal VARCHAR(25) NOT NULL,
	PripremaB2_sati DECIMAL NOT NULL,
	PripremaB2_cijena DECIMAL NOT NULL,
	HOB2_materijal VARCHAR(25) NOT NULL,
	HOB2_sati DECIMAL NOT NULL,
	HOB2_cijena DECIMAL NOT NULL,
	GTO2_materijal VARCHAR(50) NOT NULL,
	GTO2_sati DECIMAL NOT NULL,
	GTO2_cijena DECIMAL NOT NULL,
	PripremaGTO_materijal VARCHAR(25) NOT NULL,
	PripremaGTO_sati DECIMAL NOT NULL,
	PripremaGTO_cijena DECIMAL NOT NULL,
	PripremaNiG_materijal VARCHAR(25) NOT NULL,
	PripremaNiG_sati DECIMAL NOT NULL,
	PripremaNiG_cijena DECIMAL NOT NULL,
	Numeracija_materijal VARCHAR(25) NOT NULL,
	Numeracija_sati DECIMAL NOT NULL,
	Numeracija_cijena DECIMAL NOT NULL,
	Grafopres_materijal VARCHAR(25) NOT NULL,
	Grafopres_sati DECIMAL NOT NULL,
	Grafopres_cijena DECIMAL NOT NULL,
	Xeicon_materijal VARCHAR(25) NOT NULL,
	Xeicon_sati DECIMAL NOT NULL,
	Xeicon_cijena DECIMAL NOT NULL,
	Xerox_materijal VARCHAR(25) NOT NULL,
	Xerox_sati DECIMAL NOT NULL,
	Xerox_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_stampe INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)

IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Knjigovodstvena_dorada
GO
CREATE TABLE Knjigovodstvena_dorada(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Noz_materijal VARCHAR(25) NOT NULL,
	Noz_sati DECIMAL NOT NULL,
	Noz_cijena DECIMAL NOT NULL,
	Falc_materijal VARCHAR(50) NOT NULL,
	Falc_sati DECIMAL NOT NULL,
	Falc_cijena DECIMAL NOT NULL,
	Klamerica_materijal VARCHAR(25) NOT NULL,
	Klamerica_sati DECIMAL NOT NULL,
	Klamerica_cijena DECIMAL NOT NULL,
	Perforirka_materijal VARCHAR(25) NOT NULL,
	Perforirka_sati DECIMAL NOT NULL,
	Perforirka_cijena DECIMAL NOT NULL,
	Plastificiranje_materijal VARCHAR(50) NOT NULL,
	Plastificiranje_sati DECIMAL NOT NULL,
	Plastificiranje_cijena DECIMAL NOT NULL,
	Blinder_materijal VARCHAR(25) NOT NULL,
	Blinder_sati DECIMAL NOT NULL,
	Blinder_cijena DECIMAL NOT NULL,
	Spiralni_materijal VARCHAR(25) NOT NULL,
	Spiralni_sati DECIMAL NOT NULL,
	Spiralni_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_dorade INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)



IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Vanjska_usluga
GO
CREATE TABLE Vanjska_usluga(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Obracun_kalkulacije_materijal VARCHAR(25) NOT NULL,
	Obracun_kalkulacije_sati DECIMAL NOT NULL,
	Obracun_kalkulacije_cijena DECIMAL NOT NULL,
	Prevoz_materijal VARCHAR(50) NOT NULL,
	Prevoz_sati DECIMAL NOT NULL,
	Prevoz_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_dorade INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)