IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

IF OBJECT_ID('RegistrujKorisnika', 'P') IS NOT NULL
	DROP PROCEDURE RegistrujKorisnika;
GO	
CREATE PROCEDURE RegistrujKorisnika
	@Username VARCHAR(25),
	@Password VARCHAR(25),
	@Ime	  VARCHAR(35),
	@Prezime  VARCHAR(35),
	@Pozicija VARCHAR(50)
AS
BEGIN
	INSERT INTO Korisnik(
		Username,
		Password,
		Ime,
		Prezime,
		Pozicija
	)VALUES(
		@Username,
		@Password,
		@Ime,
		@Prezime,
		@Pozicija
	)
	RETURN SCOPE_IDENTITY();
END
GO

IF OBJECT_ID('DajKorisnika', 'P') IS NOT NULL
	DROP PROCEDURE DajKorisnika;
GO	
CREATE PROCEDURE DajKorisnika
	@Username VARCHAR(25),
	@Password VARCHAR(25)
AS
BEGIN
	SELECT * 
	FROM Korisnik
	WHERE
		Username = @Username
		AND Password = @Password
END
GO

IF OBJECT_ID('DajKorisnika_ID', 'P') IS NOT NULL
	DROP PROCEDURE DajKorisnika_ID;
GO	
CREATE PROCEDURE DajKorisnika_ID
	@ID INT
AS
BEGIN
	SELECT * 
	FROM Korisnik
	WHERE
		ID= @ID
END
GO



IF OBJECT_ID('UnesiPosao', 'P') IS NOT NULL
	DROP PROCEDURE UnesiPosao;
GO	
CREATE PROCEDURE UnesiPosao

		@DTP BIT,
		@Korisnik_ID INT,
		@Repromaterijal_ID INT,
		@DTP_ID INT,
		@Montaza_ID INT,
		@Knjigovodstvena_dorada_ID INT,
		@Rucni_rad_ID INT,
		@Stampa_ID INT,
		@Stampa BIT, 
		@Knjigovodstvena_usluga BIT,
		@Vanjska_usluga BIT,
		@Montaza BIT, 
		@Rucni_rad BIT,
		@Status_posla BIT,
		@Repromaterijal BIT,
		@Materijalni_troskovi DECIMAL,
		@Rad DECIMAL,
		@Popust BIT,
		@Ukupna_cijena DECIMAL,
		@Cijena_komad DECIMAL,
		@Vrsta_posla VARCHAR(50),
		@Obim_posla DECIMAL,
		@Datum DATE,
		@Papir VARCHAR(50),
		@Dorada VARCHAR(50),
		@Montaza_posla VARCHAR(50),
		@Cijena_kom_PDV DECIMAL,
		@Ukupna_cijena_PDV DECIMAL
AS
BEGIN
	INSERT INTO Posao(
		DTP,
		Korisnik_ID,
		Repromaterijal_ID,
		DTP_ID,
		Montaza_ID,
		Knjigovodstvena_dorada_ID,
		Rucni_rad_ID,
		Stampa_ID,
		Stampa, 
		Knjigovodstvena_usluga,
		Vanjska_usluga,
		Montaza, 
		Rucni_rad,
		Status_posla,
		Repromaterijal,
		Materijalni_troskovi,
		Rad,
		Popust,
		Ukupna_cijena,
		Cijena_komad,
		Vrsta_posla,
		Obim_posla,
		Datum,
		Papir,
		Dorada,
		Montaza_posla,
		Cijena_kom_PDV,
		Ukupna_cijena_PDV

	)VALUES(
		@DTP,
		@Korisnik_ID,
		@Repromaterijal_ID,
		@DTP_ID,
		@Montaza_ID,
		@Knjigovodstvena_dorada_ID,
		@Rucni_rad_ID,
		@Stampa_ID,
		@Stampa, 
		@Knjigovodstvena_usluga,
		@Vanjska_usluga,
		@Montaza, 
		@Rucni_rad,
		@Status_posla,
		@Repromaterijal,
		@Materijalni_troskovi,
		@Rad,
		@Popust,
		@Ukupna_cijena,
		@Cijena_komad,
		@Vrsta_posla,
		@Obim_posla,
		@Datum,
		@Papir,
		@Dorada,
		@Montaza_posla,
		@Cijena_kom_PDV,
		@Ukupna_cijena_PDV
	)
	RETURN SCOPE_IDENTITY();
END
GO



IF OBJECT_ID('DajPosao_ID', 'P') IS NOT NULL
	DROP PROCEDURE DajPosao_ID;
GO	
CREATE PROCEDURE DajPosao_ID
	@ID INT
AS
BEGIN
	SELECT * 
	FROM Posao
	WHERE
		ID= @ID
END
GO