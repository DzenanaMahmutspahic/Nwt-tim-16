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
