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

