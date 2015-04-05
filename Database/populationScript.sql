IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

EXEC RegistrujKorisnika 
	@Username = 'Sudo',
	@Password = 'lozinka',
	@Ime = 'Šahbaz',
	@Prezime = 'Administratoviæ',
	@Pozicija = 'Priviligovani korisnik';
GO

EXEC RegistrujKorisnika
	@Username = 'dmahmutspa',
	@Password = 'password',
	@Ime = 'Dženana',
	@Prezime = 'Mahmutspahiæ',
	@Pozicija = 'Šefica';
GO

select * from korisnik

select top 1 * from repromaterijal
insert into Reprometerijal() values()

exec UnesiPosao
		@DTP =1,
		@Korisnik_ID =1,
		@Repromaterijal_ID =0,
		@DTP_ID =2,
		@Montaza_ID =2,
		@Knjigovodstvena_dorada_ID =2,
		@Rucni_rad_ID =2,
		@Stampa_ID =2,
		@Stampa =1, 
		@Knjigovodstvena_usluga =1,
		@Vanjska_usluga =1,
		@Montaza =1, 
		@Rucni_rad =1,
		@Status_posla =1,
		@Repromaterijal =1,
		@Materijalni_troskovi =3,
		@Rad =3,
		@Popust =1,
		@Ukupna_cijena =3,
		@Cijena_komad =3,
		@Vrsta_posla ='neki string od 50',
		@Obim_posla =3,
		@Datum ='2015-3-31 1:1',
		@Papir ='neki string od 50',
		@Dorada ='neki string od 50',
		@Montaza_posla ='neki string od 50',
		@Cijena_kom_PDV =3,
		@Ukupna_cijena_PDV =3