IF DB_ID('NWT') IS NULL
	CREATE DATABASE NWT
GO

USE NWT

EXEC RegistrujKorisnika 
	@Username = 'Sudo',
	@Password = 'lozinka',
	@Ime = '�ahbaz',
	@Prezime = 'Administratovi�',
	@Pozicija = 'Priviligovani korisnik';
GO

EXEC RegistrujKorisnika
	@Username = 'dmahmutspa',
	@Password = 'password',
	@Ime = 'D�enana',
	@Prezime = 'Mahmutspahi�',
	@Pozicija = '�efica';
GO

select * from korisnik

