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
	@Password VARCHAR(32),
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

IF OBJECT_ID('DajLogove', 'P') IS NOT NULL
	DROP PROCEDURE DajLogove;
GO	
ALTER PROCEDURE DajLogove
AS
BEGIN
	SELECT * 
	FROM Logovi
END
GO


IF OBJECT_ID('DodajLog', 'P') IS NOT NULL
	DROP PROCEDURE DodajLog;
GO	
CREATE PROCEDURE DodajLog
	@Sadrzaj VARCHAR(5120),
	@Tip INT = 0,
	@Datum DATETIME = NULL
AS
BEGIN
	INSERT INTO Logovi(
		Sadrzaj,
		Tip,
		Datum
	)
	VALUES(
		@Sadrzaj,
		@Tip,
		ISNULL(@Datum, CURRENT_TIMESTAMP)
	)
END
GO

IF OBJECT_ID('DajLogZadnjiMinute', 'P') IS NOT NULL
	DROP PROCEDURE DajLogZadnjiMinute;
GO	
CREATE PROCEDURE DajLogZadnjiMinute
	@Minute INT
AS
BEGIN
	SELECT *
	FROM Logovi
	WHERE DATEDIFF(minute, Datum, CURRENT_TIMESTAMP) <=  @Minute
END
GO

IF OBJECT_ID('PromijeniLozinku', 'P') IS NOT NULL
	DROP PROCEDURE PromijeniLozinku;
GO	
CREATE PROCEDURE PromijeniLozinku
	@Id INT,
	@GUID VARCHAR(38),
	@NovaLozinka VARCHAR(250)
AS
BEGIN
	IF EXISTS (SELECT * FROM PromjenaLozinke WHERE ID = @Id AND GUID = @GUID AND Enabled = 1)
	BEGIN
		DECLARE @KorisnikId INT;
		
		SELECT @KorisnikId = KorisnikId
		FROM PromjenaLozinke
		WHERE GUID = @GUID

		IF EXISTS (SELECT * FROM Korisnik WHERE ID = @KorisnikId)
		BEGIN
			UPDATE Korisnik
			SET Password = @NovaLozinka
			WHERE ID = @KorisnikId

			UPDATE PromjenaLozinke
			SET Enabled = 0
			WHERE ID = @Id
		END
		ELSE
			SELECT 'Pogresan korisnik' AS Greska
	END
	ELSE
		SELECT 'Pogresan zahtjev!' AS Greska
END



CREATE PROCEDURE  dbo . DodajMontazu 
		@Korisnik_ID INT,
	 @Snimanje_materijal VARCHAR(25),
	@Snimanje_sati decimal (18, 0),
	@Snimanje_cijena decimal(18, 0),
	@Montaza_materijal varchar(50),
	@Montaza_sati decimal(18, 0),
	@Montaza_cijena decimal(18, 0),
	@Ukupno_sati  decimal (18, 0),
	@Ukupno_cijena  decimal (18, 0),
	@Status_montaze int,
	@Vrijeme_cekanja  time (7),
	@Komentar  varchar (1)
		
AS
BEGIN
	INSERT INTO Montaza(
		
		Korisnik_ID,
	 Snimanje_materijal,
	Snimanje_sati,
	Snimanje_cijena,
	Montaza_materijal,
	Montaza_sati,
	Montaza_cijena,
	Ukupno_sati,
	Ukupno_cijena,
	Status_montaze,
	Vrijeme_cekanja,
	Komentar

	)VALUES(
		
		@Korisnik_ID,
	 @Snimanje_materijal,
	@Snimanje_sati,
	@Snimanje_cijena,
	@Montaza_materijal,
	@Montaza_sati,
	@Montaza_cijena,
	@Ukupno_sati,
	@Ukupno_cijena,
	@Status_montaze,
	@Vrijeme_cekanja,
	@Komentar
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE  dbo . DodajRepromaterijal 
	@Korisnik_ID  int,
	@Papir1_materijal  varchar,
	@Papir1_sati  decimal ,
	@Papir1_cijena  decimal  ,
	@Papir2_materijal  varchar,
	@Papir2_sati  decimal(18, 0)  ,
	@Papir2_cijena decimal(18, 0)  ,
	@PapirZK_materijal  varchar(50)  ,
	@PapirZK_sati  decimal(18, 0)  ,
	@PapirZK_cijena  decimal(18, 0)  ,
	@MaterijalZXM_materijal  varchar(50)  ,
	@MaterijalZXM_sati  decimal(18, 0)  ,
	@MaterijalZXM_cijena   decimal (18, 0)  ,
	@MZXMBoja_materijal   varchar (50)  ,
	@MZXMBoja_sati   decimal (18, 0)  ,
	@MZXMBoja_cijena   decimal (18, 0)  ,
	 @MZXMB3_materijal   varchar (50)  ,
	 @MZXMB3_sati   decimal (18, 0)  ,
	 @MZXMB3_cijena   decimal (18, 0)  ,
	 @MZXMFilmB2_materijal   varchar (50)  ,
	 @MZXMFilmB2_sati   decimal (18, 0)  ,
	 @MZXMFilmB2_cijena   decimal (18, 0)  ,
	 @MZXMFilmB3_materijal   varchar (50)  ,
	 @MZXMFilmB3_sati   decimal (18, 0),
	 @MZXMFilmB3_cijena   decimal (18, 0),
	 @OffsetPloceB5_materijal   varchar (50),
	 @OffsetPloceB5_sati   decimal (18, 0),
	 @OffsetPloceB5_cijena   decimal (18, 0),
	 @OffsetPloceB3_materijal   varchar (50),
	 @OffsetPloceB3_sati   decimal (18, 0),
	 @OffsetPloceB3_cijena   decimal (18, 0),
	 @OffsetPloceB2_materijal   varchar (50),
	 @OffsetPloceB2_sati   decimal (18, 0),
	 @OffsetPloceB2_cijena   decimal (18, 0),
	 @Folija_materijal   varchar (25),
	 @Folija_sati   decimal (18, 0),
	 @Folija_cijena   decimal (18, 0),
	 @Toner_materijal   varchar (25),
	 @Toner_sati   decimal (18, 0),
	 @Toner_cijena   decimal (18, 0),
	 @Ostalo_materijal   varchar (25),
	 @Ostalo_sati   decimal (18, 0),
	 @Ostalo_cijena   decimal (18, 0),
	 @Vrijeme_pocetka   datetime ,
	 @Vrijeme_zavrsetka   datetime ,
	 @Ukupno_sati   decimal (18, 0)  ,
	 @Ukupno_cijena   decimal (18, 0)  ,
	 @Status_rada   int,
	 @Vrijeme_cekanja   time (7),
	 @Komentar   varchar (1)
		
AS
BEGIN
	INSERT INTO Repromaterijal(
		
		 Korisnik_ID ,
	 Papir1_materijal   ,
	 Papir1_sati    ,
	 Papir1_cijena     ,
	 Papir2_materijal   ,
	 Papir2_sati      ,
	 Papir2_cijena     ,
	 PapirZK_materijal      ,
	 PapirZK_sati      ,
	 PapirZK_cijena      ,
	 MaterijalZXM_materijal      ,
	 MaterijalZXM_sati      ,
	 MaterijalZXM_cijena        ,
	 MZXMBoja_materijal        ,
	 MZXMBoja_sati        ,
	 MZXMBoja_cijena        ,
	  MZXMB3_materijal        ,
	  MZXMB3_sati        ,
	  MZXMB3_cijena        ,
	  MZXMFilmB2_materijal        ,
	  MZXMFilmB2_sati        ,
	  MZXMFilmB2_cijena        ,
	  MZXMFilmB3_materijal        ,
	  MZXMFilmB3_sati      ,
	  MZXMFilmB3_cijena      ,
	  OffsetPloceB5_materijal      ,
	  OffsetPloceB5_sati      ,
	  OffsetPloceB5_cijena      ,
	  OffsetPloceB3_materijal      ,
	  OffsetPloceB3_sati      ,
	  OffsetPloceB3_cijena      ,
	  OffsetPloceB2_materijal,
	  OffsetPloceB2_sati,
	  OffsetPloceB2_cijena,
	  Folija_materijal,
	  Folija_sati,
	  Folija_cijena,
	  Toner_materijal,
	  Toner_sati,
	  Toner_cijena,
	  Ostalo_materijal,
	  Ostalo_sati,
	  Ostalo_cijena,
	  Vrijeme_pocetka,
	  Vrijeme_zavrsetka,
	  Ukupno_sati,
	  Ukupno_cijena,
	  Status_rada,
	  Vrijeme_cekanja,
	  Komentar 

	)VALUES(
		
		@Korisnik_ID,
	@Papir1_materijal,
	@Papir1_sati,
	@Papir1_cijena,
	@Papir2_materijal,
	@Papir2_sati,
	@Papir2_cijena,
	@PapirZK_materijal,
	@PapirZK_sati,
	@PapirZK_cijena,
	@MaterijalZXM_materijal,
	@MaterijalZXM_sati,
	@MaterijalZXM_cijena,
	@MZXMBoja_materijal,
	@MZXMBoja_sati,
	@MZXMBoja_cijena,
	 @MZXMB3_materijal,
	 @MZXMB3_sati,
	 @MZXMB3_cijena,
	 @MZXMFilmB2_materijal,
	 @MZXMFilmB2_sati,
	 @MZXMFilmB2_cijena,
	 @MZXMFilmB3_materijal,
	 @MZXMFilmB3_sati,
	 @MZXMFilmB3_cijena,
	 @OffsetPloceB5_materijal,
	 @OffsetPloceB5_sati,
	 @OffsetPloceB5_cijena,
	 @OffsetPloceB3_materijal,
	 @OffsetPloceB3_sati,
	 @OffsetPloceB3_cijena      ,
	 @OffsetPloceB2_materijal      ,
	 @OffsetPloceB2_sati      ,
	 @OffsetPloceB2_cijena      ,
	 @Folija_materijal      ,
	 @Folija_sati      ,
	 @Folija_cijena      ,
	 @Toner_materijal      ,
	 @Toner_sati      ,
	 @Toner_cijena      ,
	 @Ostalo_materijal      ,
	 @Ostalo_sati      ,
	 @Ostalo_cijena      ,
	 @Vrijeme_pocetka     ,
	 @Vrijeme_zavrsetka     ,
	 @Ukupno_sati        ,
	 @Ukupno_cijena        ,
	 @Status_rada    ,
	 @Vrijeme_cekanja      ,
	 @Komentar
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END

GO


CREATE PROCEDURE  dbo.DodajRucniRad

	@Korisnik_ID   int ,
	 @Slaganje_materijal   varchar (25)  ,
	 @Slaganje_sati   decimal (18, 0)  ,
	 @Slaganje_cijena   decimal (18, 0)  ,
	 @Savijanje_materijal   varchar (50)  ,
	 @Savijanje_sati   decimal (18, 0)  ,
	 @Savijanje_cijena   decimal (18, 0)  ,
	 @Lijepljenje_materijal   varchar (50)  ,
	 @Lijepljenje_sati   decimal (18, 0)  ,
	 @Lijepljenje_cijena   decimal (18, 0)  ,
	 @Pakovanje_materijal   varchar (50)  ,
	 @Pakovanje_sati   decimal (18, 0)  ,
	 @Pakovanje_cijena   decimal (18, 0)  ,
	 @Razno_materijal   varchar (50)  ,
	 @Razno_sati   decimal (18, 0)  ,
	 @Razno_cijena   decimal (18, 0)  ,
	 @Ukupno_sati   decimal (18, 0)  ,
	 @Ukupno_cijena   decimal (18, 0)  ,
	 @Vrijeme_pocetka   datetime   ,
	 @Vrijeme_zavrsetka   datetime   ,
	 @Status_rada   int   ,
	 @Vrijeme_cekanja   time (7)  ,
	 @Komentar   varchar (1)  
		
AS
BEGIN
	INSERT INTO Rucni_rad(
		
		 Korisnik_ID     ,
	  Slaganje_materijal        ,
	  Slaganje_sati        ,
	  Slaganje_cijena        ,
	  Savijanje_materijal        ,
	  Savijanje_sati        ,
	  Savijanje_cijena        ,
	  Lijepljenje_materijal        ,
	  Lijepljenje_sati        ,
	  Lijepljenje_cijena        ,
	  Pakovanje_materijal        ,
	  Pakovanje_sati        ,
	  Pakovanje_cijena        ,
	  Razno_materijal        ,
	  Razno_sati        ,
	  Razno_cijena        ,
	  Ukupno_sati        ,
	  Ukupno_cijena        ,
	  Vrijeme_pocetka        ,
	  Vrijeme_zavrsetka        ,
	  Status_rada       ,
	  Vrijeme_cekanja        ,
	  Komentar        


	)VALUES(
		
		@Korisnik_ID     ,
	 @Slaganje_materijal        ,
	 @Slaganje_sati        ,
	 @Slaganje_cijena        ,
	 @Savijanje_materijal        ,
	 @Savijanje_sati        ,
	 @Savijanje_cijena        ,
	 @Lijepljenje_materijal        ,
	 @Lijepljenje_sati        ,
	 @Lijepljenje_cijena        ,
	 @Pakovanje_materijal        ,
	 @Pakovanje_sati        ,
	 @Pakovanje_cijena        ,
	 @Razno_materijal        ,
	 @Razno_sati        ,
	 @Razno_cijena        ,
	 @Ukupno_sati        ,
	 @Ukupno_cijena        ,
	 @Vrijeme_pocetka       ,
	 @Vrijeme_zavrsetka       ,
	 @Status_rada       ,
	 @Vrijeme_cekanja        ,
	 @Komentar        
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO


CREATE PROCEDURE  dbo.DodajStampu

	@Korisnik_ID   int ,
	 @Priprema4b_materijal   varchar (25)  ,
	 @Priprema4b_sati   decimal (18, 0)  ,
	 @Priprema4b_cijena   decimal (18, 0)  ,
	 @GTO1_materijal   varchar (50)  ,
	 @GTO1_sati   decimal (18, 0)  ,
	 @GTO1_cijena   decimal (18, 0)  ,
	 @PripremaB2_materijal   varchar (25)  ,
	 @PripremaB2_sati   decimal (18, 0)  ,
	 @PripremaB2_cijena   decimal (18, 0)  ,
	 @HOB2_materijal   varchar (25)  ,
	 @HOB2_sati   decimal (18, 0)  ,
	 @HOB2_cijena   decimal (18, 0)  ,
	 @GTO2_materijal   varchar (50)  ,
	 @GTO2_sati   decimal (18, 0)  ,
	 @GTO2_cijena   decimal (18, 0)  ,
	 @PripremaGTO_materijal   varchar (25)  ,
	 @PripremaGTO_sati   decimal (18, 0)  ,
	 @PripremaGTO_cijena   decimal (18, 0)  ,
	 @PripremaNiG_materijal   varchar (25)  ,
	 @PripremaNiG_sati   decimal (18, 0)  ,
	 @PripremaNiG_cijena   decimal (18, 0)  ,
	 @Numeracija_materijal   varchar (25)  ,
	 @Numeracija_sati   decimal (18, 0)  ,
	 @Numeracija_cijena   decimal (18, 0)  ,
	 @Grafopres_materijal   varchar (25)  ,
	 @Grafopres_sati   decimal (18, 0)  ,
	 @Grafopres_cijena   decimal (18, 0)  ,
	 @Xeicon_materijal   varchar (25)  ,
	 @Xeicon_sati   decimal (18, 0)  ,
	 @Xeicon_cijena   decimal (18, 0)  ,
	 @Xerox_materijal   varchar (25)  ,
	 @Xerox_sati   decimal (18, 0)  ,
	 @Xerox_cijena   decimal (18, 0)  ,
	 @Ukupno_sati   decimal (18, 0)  ,
	 @Ukupno_cijena   decimal (18, 0)  ,
	 @Vrijeme_pocetka   datetime   ,
	 @Vrijeme_zavrsetka   datetime   ,
	 @Status_stampe   int   ,
	 @Vrijeme_cekanja   time (7)  ,
	 @Komentar   varchar    
		
AS
BEGIN
	INSERT INTO Stampa(
		
		  Korisnik_ID,
	  Priprema4b_materijal        ,
	  Priprema4b_sati        ,
	  Priprema4b_cijena        ,
	  GTO1_materijal        ,
	  GTO1_sati        ,
	  GTO1_cijena        ,
	  PripremaB2_materijal        ,
	  PripremaB2_sati        ,
	  PripremaB2_cijena        ,
	  HOB2_materijal        ,
	  HOB2_sati        ,
	  HOB2_cijena        ,
	  GTO2_materijal        ,
	  GTO2_sati        ,
	  GTO2_cijena        ,
	  PripremaGTO_materijal        ,
	  PripremaGTO_sati        ,
	  PripremaGTO_cijena        ,
	  PripremaNiG_materijal        ,
	  PripremaNiG_sati        ,
	  PripremaNiG_cijena        ,
	  Numeracija_materijal        ,
	  Numeracija_sati        ,
	  Numeracija_cijena        ,
	  Grafopres_materijal        ,
	  Grafopres_sati        ,
	  Grafopres_cijena        ,
	  Xeicon_materijal        ,
	  Xeicon_sati        ,
	  Xeicon_cijena        ,
	  Xerox_materijal        ,
	  Xerox_sati        ,
	  Xerox_cijena        ,
	  Ukupno_sati        ,
	  Ukupno_cijena        ,
	  Vrijeme_pocetka       ,
	  Vrijeme_zavrsetka       ,
	  Status_stampe       ,
	  Vrijeme_cekanja        ,
	  Komentar        


	)VALUES(
		
		@Korisnik_ID     ,
	 @Priprema4b_materijal        ,
	 @Priprema4b_sati        ,
	 @Priprema4b_cijena        ,
	 @GTO1_materijal        ,
	 @GTO1_sati        ,
	 @GTO1_cijena        ,
	 @PripremaB2_materijal        ,
	 @PripremaB2_sati        ,
	 @PripremaB2_cijena        ,
	 @HOB2_materijal        ,
	 @HOB2_sati        ,
	 @HOB2_cijena        ,
	 @GTO2_materijal        ,
	 @GTO2_sati        ,
	 @GTO2_cijena        ,
	 @PripremaGTO_materijal        ,
	 @PripremaGTO_sati        ,
	 @PripremaGTO_cijena        ,
	 @PripremaNiG_materijal        ,
	 @PripremaNiG_sati        ,
	 @PripremaNiG_cijena        ,
	 @Numeracija_materijal        ,
	 @Numeracija_sati        ,
	 @Numeracija_cijena        ,
	 @Grafopres_materijal        ,
	 @Grafopres_sati        ,
	 @Grafopres_cijena        ,
	 @Xeicon_materijal        ,
	 @Xeicon_sati        ,
	 @Xeicon_cijena        ,
	 @Xerox_materijal        ,
	 @Xerox_sati        ,
	 @Xerox_cijena        ,
	 @Ukupno_sati        ,
	 @Ukupno_cijena        ,
	 @Vrijeme_pocetka       ,
	 @Vrijeme_zavrsetka       ,
	 @Status_stampe       ,
	 @Vrijeme_cekanja        ,
	 @Komentar        
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END


GO


CREATE PROCEDURE  dbo.DodajVanjskuUslugu  
		@Korisnik_ID INT,
	 	@Obracun_kalkulacije_materijal   varchar (25)  ,
	 @Obracun_kalkulacije_sati   decimal (18, 0)  ,
	 @Obracun_kalkulacije_cijena   decimal (18, 0)  ,
	 @Prevoz_materijal   varchar (50)  ,
	 @Prevoz_sati   decimal (18, 0)  ,
	 @Prevoz_cijena   decimal (18, 0),
	@Vrijeme_pocetka datetime,
	@Vrijeme_zavrsetka datetime,
	@Ukupno_sati  decimal (18, 0),
	@Ukupno_cijena  decimal (18, 0),
	@Status_dorade int,
	@Vrijeme_cekanja  time (7),
	@Komentar  varchar (1)
AS
BEGIN
	INSERT INTO Vanjska_usluga(
		
		
		 Korisnik_ID,
	 	 Obracun_kalkulacije_materijal ,
	  Obracun_kalkulacije_sati   ,
	  Obracun_kalkulacije_cijena     ,
	  Prevoz_materijal  ,
	  Prevoz_sati  ,
	  Prevoz_cijena   ,
	 Vrijeme_pocetka ,
	 Vrijeme_zavrsetka ,
	 Ukupno_sati ,
	 Ukupno_cijena ,
	 Status_dorade,
	 Vrijeme_cekanja ,
	 Komentar 

	)VALUES(
		
		@Korisnik_ID,
	 	@Obracun_kalkulacije_materijal ,
	 @Obracun_kalkulacije_sati   ,
	 @Obracun_kalkulacije_cijena     ,
	 @Prevoz_materijal  ,
	 @Prevoz_sati  ,
	 @Prevoz_cijena   ,
	@Vrijeme_pocetka ,
	@Vrijeme_zavrsetka ,
	@Ukupno_sati ,
	@Ukupno_cijena ,
	@Status_dorade,
	@Vrijeme_cekanja ,
	@Komentar 
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO


CREATE PROCEDURE  dbo.DodajKnjigovodstvenuDoradu 
	
	 @Korisnik_ID   int ,
	 @Noz_materijal   varchar (25)  ,
	 @Noz_sati   decimal (18, 0)  ,
	 @Noz_cijena   decimal (18, 0)  ,
	 @Falc_materijal   varchar (50)  ,
	 @Falc_sati   decimal (18, 0)  ,
	 @Falc_cijena   decimal (18, 0)  ,
	 @Klamerica_materijal   varchar (25)  ,
	 @Klamerica_sati   decimal (18, 0)  ,
	 @Klamerica_cijena   decimal (18, 0)  ,
	 @Perforirka_materijal   varchar (25)  ,
	 @Perforirka_sati   decimal (18, 0)  ,
	 @Perforirka_cijena   decimal (18, 0)  ,
	 @Plastificiranje_materijal   varchar (50)  ,
	 @Plastificiranje_sati   decimal (18, 0)  ,
	 @Plastificiranje_cijena   decimal (18, 0)  ,
	 @Blinder_materijal   varchar (25)  ,
	 @Blinder_sati   decimal (18, 0)  ,
	 @Blinder_cijena   decimal (18, 0)  ,
	 @Spiralni_materijal   varchar (25)  ,
	 @Spiralni_sati   decimal (18, 0)  ,
	 @Spiralni_cijena   decimal (18, 0)  ,
	 @Ukupno_sati   decimal (18, 0)  ,
	 @Ukupno_cijena   decimal (18, 0)  ,
	 @Vrijeme_pocetka   datetime   ,
	 @Vrijeme_zavrsetka   datetime   ,
	 @Status_dorade   int   ,
	 @Vrijeme_cekanja   time (7)  ,
	 @Komentar   varchar (1)  
AS
BEGIN
	INSERT INTO Knjigovodstvena_dorada(
		
		 Korisnik_ID       ,
	  Noz_materijal        ,
	  Noz_sati        ,
	  Noz_cijena        ,
	  Falc_materijal        ,
	  Falc_sati        ,
	  Falc_cijena        ,
	  Klamerica_materijal        ,
	  Klamerica_sati        ,
	  Klamerica_cijena        ,
	  Perforirka_materijal        ,
	  Perforirka_sati        ,
	  Perforirka_cijena        ,
	  Plastificiranje_materijal        ,
	  Plastificiranje_sati        ,
	  Plastificiranje_cijena        ,
	  Blinder_materijal        ,
	  Blinder_sati        ,
	  Blinder_cijena        ,
	  Spiralni_materijal        ,
	  Spiralni_sati        ,
	  Spiralni_cijena        ,
	  Ukupno_sati        ,
	  Ukupno_cijena        ,
	  Vrijeme_pocetka        ,
	  Vrijeme_zavrsetka        ,
	  Status_dorade       ,
	  Vrijeme_cekanja        ,
	  Komentar      
 

	)VALUES(
		
		@Korisnik_ID       ,
	 @Noz_materijal        ,
	 @Noz_sati        ,
	 @Noz_cijena        ,
	 @Falc_materijal        ,
	 @Falc_sati        ,
	 @Falc_cijena        ,
	 @Klamerica_materijal        ,
	 @Klamerica_sati        ,
	 @Klamerica_cijena        ,
	 @Perforirka_materijal        ,
	 @Perforirka_sati        ,
	 @Perforirka_cijena        ,
	 @Plastificiranje_materijal        ,
	 @Plastificiranje_sati        ,
	 @Plastificiranje_cijena        ,
	 @Blinder_materijal        ,
	 @Blinder_sati        ,
	 @Blinder_cijena        ,
	 @Spiralni_materijal        ,
	 @Spiralni_sati        ,
	 @Spiralni_cijena        ,
	 @Ukupno_sati        ,
	 @Ukupno_cijena        ,
	 @Vrijeme_pocetka        ,
	 @Vrijeme_zavrsetka        ,
	 @Status_dorade       ,
	 @Vrijeme_cekanja        ,
	 @Komentar   
	)
	SELECT SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END
GO