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
	Email VARCHAR(250)
	CONSTRAINT unique_Username UNIQUE (Username)
)

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE PrivremeniKorisnik
GO
CREATE TABLE PrivremeniKorisnik(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR(25) NOT NULL UNIQUE,
	Password VARCHAR(25) NOT NULL,
	Ime VARCHAR(35) NOT NULL,
	Prezime VARCHAR(35) NOT NULL,
	Pozicija VARCHAR(50),
	Email VARCHAR(250),
	GUID VARCHAR(38)
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
	Priprema4b_materijal VARCHAR(25),
	Priprema4b_sati DECIMAL,
	Priprema4b_cijena DECIMAL,
	GTO1_materijal VARCHAR(50),
	GTO1_sati DECIMAL,
	GTO1_cijena DECIMAL,
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
	Status_usluge INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)


IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Rucni_rad
GO
CREATE TABLE Rucni_rad(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Slaganje_materijal VARCHAR(25) NOT NULL,
	Slaganje_sati DECIMAL NOT NULL,
	Slaganje_cijena DECIMAL NOT NULL,
	Savijanje_materijal VARCHAR(50) NOT NULL,
	Savijanje_sati DECIMAL NOT NULL,
	Savijanje_cijena DECIMAL NOT NULL,
	Lijepljenje_materijal VARCHAR(50) NOT NULL,
	Lijepljenje_sati DECIMAL NOT NULL,
	Lijepljenje_cijena DECIMAL NOT NULL,
	Pakovanje_materijal VARCHAR(50) NOT NULL,
	Pakovanje_sati DECIMAL NOT NULL,
	Pakovanje_cijena DECIMAL NOT NULL,
	Razno_materijal VARCHAR(50) NOT NULL,
	Razno_sati DECIMAL NOT NULL,
	Razno_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_rada INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)



IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Repromaterijal
GO
CREATE TABLE Repromaterijal(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Papir1_materijal VARCHAR(25),
	Papir1_sati DECIMAL,
	Papir1_cijena DECIMAL,
	Papir2_materijal VARCHAR(50) NOT NULL,
	Papir2_sati DECIMAL NOT NULL,
	Papir2_cijena DECIMAL NOT NULL,
	PapirZK_materijal VARCHAR(50) NOT NULL,
	PapirZK_sati DECIMAL NOT NULL,
	PapirZK_cijena DECIMAL NOT NULL,
	MaterijalZXM_materijal VARCHAR(50) NOT NULL,
	MaterijalZXM_sati DECIMAL NOT NULL,
	MaterijalZXM_cijena DECIMAL NOT NULL,
	MZXMBoja_materijal VARCHAR(50) NOT NULL,
	MZXMBoja_sati DECIMAL NOT NULL,
	MZXMBoja_cijena DECIMAL NOT NULL,
	MZXMB3_materijal VARCHAR(50) NOT NULL,
	MZXMB3_sati DECIMAL NOT NULL,
	MZXMB3_cijena DECIMAL NOT NULL,
	MZXMFilmB2_materijal VARCHAR(50) NOT NULL,
	MZXMFilmB2_sati DECIMAL NOT NULL,
	MZXMFilmB2_cijena DECIMAL NOT NULL,
	MZXMFilmB3_materijal VARCHAR(50) NOT NULL,
	MZXMFilmB3_sati DECIMAL NOT NULL,
	MZXMFilmB3_cijena DECIMAL NOT NULL,
	OffsetPloceB5_materijal VARCHAR(50) NOT NULL,
	OffsetPloceB5_sati DECIMAL NOT NULL,
	OffsetPloceB5_cijena DECIMAL NOT NULL,
	OffsetPloceB3_materijal VARCHAR(50) NOT NULL,
	OffsetPloceB3_sati DECIMAL NOT NULL,
	OffsetPloceB3_cijena DECIMAL NOT NULL,
	OffsetPloceB2_materijal VARCHAR(50) NOT NULL,
	OffsetPloceB2_sati DECIMAL NOT NULL,
	OffsetPloceB2_cijena DECIMAL NOT NULL,
	Folija_materijal VARCHAR(25) NOT NULL,
	Folija_sati DECIMAL NOT NULL,
	Folija_cijena DECIMAL NOT NULL,
	Toner_materijal VARCHAR(25) NOT NULL,
	Toner_sati DECIMAL NOT NULL,
	Toner_cijena DECIMAL NOT NULL,
	Ostalo_materijal VARCHAR(25) NOT NULL,
	Ostalo_sati DECIMAL NOT NULL,
	Ostalo_cijena DECIMAL NOT NULL,
	Ukupno_sati DECIMAL NOT NULL,
	Ukupno_cijena DECIMAL NOT NULL,
	Vrijeme_pocetka DATETIME NOT NULL,
	Vrijeme_zavrsetka DATETIME NOT NULL,
	Status_rada INT NOT NULL,
	Vrijeme_cekanja TIME NOT NULL,
    Komentar VARCHAR NOT NULL
)


IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Posao
GO
CREATE TABLE Posao(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Korisnik_ID INT FOREIGN KEY(Korisnik_ID) REFERENCES [dbo].[Korisnik]([ID]),
	Repromaterijal_ID INT FOREIGN KEY(Repromaterijal_ID) REFERENCES [dbo].[Repromaterijal]([ID]),
	DTP_ID INT FOREIGN KEY(DTP_ID) REFERENCES [dbo].[DTP]([DTP_ID]),
	Montaza_ID INT FOREIGN KEY(Montaza_ID) REFERENCES [dbo].[Montaza]([ID]),
	Knjigovodstvena_dorada_ID INT FOREIGN KEY(Knjigovodstvena_dorada_ID) REFERENCES [dbo].[Knjigovodstvena_dorada]([ID]),
	Rucni_rad_ID INT FOREIGN KEY(Rucni_rad_ID) REFERENCES [dbo].[Rucni_rad]([ID]),
	Stampa_ID INT FOREIGN KEY(Stampa_ID) REFERENCES [dbo].[Stampa]([Stampa_ID]),
	DTP BIT NOT NULL,
	Stampa BIT NOT NULL, 
	Knjigovodstvena_usluga BIT NOT NULL,
	Vanjska_usluga BIT NOT NULL,
    Montaza BIT NOT NULL, 
	Rucni_rad BIT NOT NULL,
	Status_posla BIT NOT NULL,
	Repromaterijal BIT NOT NULL,
	Materijalni_troskovi DECIMAL NOT NULL,
	Rad DECIMAL NOT NULL,
	Popust BIT NOT NULL,
	Ukupna_cijena DECIMAL NOT NULL,
	Cijena_komad DECIMAL NOT NULL,
	Vrsta_posla VARCHAR(50) NOT NULL,
	Obim_posla DECIMAL NOT NULL,
	Datum DATE NOT NULL,
	Papir VARCHAR(50),
	Dorada VARCHAR(50),
	Montaza_posla VARCHAR(50),
	Cijena_kom_PDV DECIMAL NOT NULL,
	Ukupna_cijena_PDV DECIMAL NOT NULL
)



IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Radni_nalog
GO
CREATE TABLE Radni_nalog(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Posao_ID INT FOREIGN KEY(Posao_ID) REFERENCES [dbo].[Posao]([ID]),
	Repromaterijal_ID INT FOREIGN KEY(Repromaterijal_ID) REFERENCES [dbo].[Repromaterijal]([ID]),
	DTP_ID INT FOREIGN KEY(DTP_ID) REFERENCES [dbo].[DTP]([DTP_ID]),
	Montaza_ID INT FOREIGN KEY(Montaza_ID) REFERENCES [dbo].[Montaza]([ID]),
	Knjigovodstvena_dorada_ID INT FOREIGN KEY(Knjigovodstvena_dorada_ID) REFERENCES [dbo].[Knjigovodstvena_dorada]([ID]),
	Vanjska_usluga_ID INT FOREIGN KEY(Vanjska_usluga_ID) REFERENCES [dbo].[Vanjska_usluga]([ID]),
	Rucni_rad_ID INT FOREIGN KEY(Rucni_rad_ID) REFERENCES [dbo].[Rucni_rad]([ID]),
	Stampa_ID INT FOREIGN KEY(Stampa_ID) REFERENCES [dbo].[Stampa]([Stampa_ID]),
	Ukupno_sati DECIMAL NOT NULL,
	Status_naloga INT NOT NULL,
    Komentar VARCHAR NOT NULL
)


if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE Logovi
GO
CREATE TABLE Logovi(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Sadrzaj VARCHAR(5120),
	Datum DATETIME,
	Tip INT
)

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE PromjenaLozinke
GO
CREATE TABLE PromjenaLozinke(
	ID INT IDENTITY(1,1),
	KorisnikId INT NOT NULL,
	GUID VARCHAR(38) NOT NULL,
	Datum DATETIME NOT NULL,
	Email VARCHAR(250) NOT NULL
)


if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE KorisnikSlika
GO
CREATE TABLE KorisnikSlika(
	KorisnikId INT NOT NULL,
	Putanja VARCHAR(350) NOT NULL
)

if 1=2 -- Nece se nikad izvrsiti. Korisno za rucno brisanje tabele (Selektovanjem komande i F5
	DROP TABLE PodaciZaGraf
GO
CREATE TABLE PodaciZaGraf(
	ID INT IDENTITY(1,1),
	Vrsta VARCHAR(20) NOT NULL,
	VrijemeUpisa DATETIME DEFAULT GETUTCDATE(),
	Podaci VARCHAR(20)
)