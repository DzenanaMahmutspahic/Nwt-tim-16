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
	@Email VARCHAR(250),
	@GUID VARCHAR(38)
AS
BEGIN
	INSERT INTO PrivremeniKorisnik(
		Username,
		Password,
		Ime,
		Prezime,
		Email,
		GUID
	)VALUES(
		@Username,
		@Password,
		@Ime,
		@Prezime,
		@Email,
		@GUID
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO
	
CREATE PROCEDURE PotvrdiRegistraciju
	@ID INT,
	@GUID VARCHAR(38)
AS
BEGIN
	DECLARE 
	@Username VARCHAR(25),
	@Password VARCHAR(25),
	@Ime	  VARCHAR(35),
	@Prezime  VARCHAR(35),
	@Email VARCHAR(250);

	SELECT 
		@Username = Username,
		@Password = Password,
		@Ime = Ime,
		@Prezime = Prezime,
		@Email = Email
	FROM PrivremeniKorisnik
	WHERE ID = @ID
		AND GUID = @GUID

	IF @@ROWCOUNT = 1
	BEGIN
		INSERT INTO Korisnik(
			Username,
			Password,
			Ime,
			Prezime,
			Email
		)VALUES(
			@Username,
			@Password,
			@Ime,
			@Prezime,
			@Email
		)
		SELECT SCOPE_IDENTITY();
		RETURN SCOPE_IDENTITY();
	END
END
GO

IF OBJECT_ID('PromjeniLozinku', 'P') IS NOT NULL
	DROP PROCEDURE PromjeniLozinku;
GO	
CREATE PROCEDURE PromjeniLozinku
	@Username VARCHAR(25),
	@Password VARCHAR(25),
	@NewPassword VARCHAR(25)
AS
BEGIN
	UPDATE Korisnik
	SET Password = @NewPassword
	WHERE Username = @Username
		AND Password = @Password;

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

IF OBJECT_ID('DajKorisnika_Email', 'P') IS NOT NULL
	DROP PROCEDURE DajKorisnika_Email;
GO	
CREATE PROCEDURE DajKorisnika_Email
	@Email VARCHAR(250)
AS
BEGIN
	SELECT * 
	FROM Korisnik
	WHERE
		Email= @Email
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
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO



IF OBJECT_ID('DajZavrsenePoslove', 'P') IS NOT NULL
	DROP PROCEDURE DajZavrsenePoslove;
GO	
CREATE PROCEDURE DajZavrsenePoslove
	--@ID INT
AS
BEGIN
	SELECT * 
	FROM Posao
	WHERE
		Status_posla = 1
END
GO


IF OBJECT_ID('UnesiDTP', 'P') IS NOT NULL
	DROP PROCEDURE UnesiDTP;
GO	
CREATE PROCEDURE UnesiDTP
		@DTP_ID INT,
		@Korisnik_ID INT,
		@Status_DTP BIT,
		@Sofp_materijal VARCHAR,
		@Sofp_sati DECIMAL,
		@Sofp_cijena DECIMAL,
		@Fotografija_materijal VARCHAR,
		@Fotografija_sati DECIMAL,
		@Fotografija_cijena DECIMAL,
		@Ukupno_sati DECIMAL,
		@Ukupno_cijena DECIMAL,
		@Vrijeme_pocetka DATETIME,
		@Vrijeme_zavrsetka DATETIME,
		@Vrijeme_cekanja TIME,
		@Komentar VARCHAR

	
AS
BEGIN
	INSERT INTO Posao(
		DTP_ID,
		Korisnik_ID,
		Status_DTP,
		Sofp_materijal,
		Sofp_sati,
		Sofp_cijena,
		Fotografija_materijal,
		Fotografija_sati,
		Fotografija_cijena,
		Ukupno_sati,
		Ukupno_cijena,
		Vrijeme_pocetka,
		Vrijeme_zavrsetka,
		Vrijeme_cekanja,
		Komentar

	)VALUES(

	@DTP_ID,
		@Korisnik_ID,
		@Status_DTP,
		@Sofp_materijal,
		@Sofp_sati,
		@Sofp_cijena,
		@Fotografija_materijal,
		@Fotografija_sati,
		@Fotografija_cijena,
		@Ukupno_sati,
		@Ukupno_cijena,
		@Vrijeme_pocetka,
		@Vrijeme_zavrsetka,
		@Vrijeme_cekanja,
		@Komentar

	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO


select * from privremeniKorisnik
select * from Korisnik