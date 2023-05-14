USE TSQL;
GO
IF (OBJECT_ID('dbo.Klijenti') IS NOT NULL) DROP TABLE dbo.Klijenti;
GO
CREATE TABLE dbo.Klijenti (
KlijentId int IDENTITY PRIMARY KEY NOT NULL,
Naziv nvarchar(40) NOT NULL,
Kontakt nvarchar(30) NOT NULL,
Grad nvarchar (15) NOT NULL,
Zemlja nvarchar(15) NOT NULL);
GO
INSERT INTO dbo.Klijenti
(Naziv, Kontakt, Grad, Zemlja)
SELECT companyname, contactname, city, country
FROM Sales.Customers, Sales.OrderDetails;

-----------------------------------
-- Procedura SelectAll ------------
-----------------------------------

go
create procedure dbo.PrikaziSve
as
set lock_timeout 3000
begin try
	select KlijentId, Naziv, Kontakt, Grad, Zemlja
	from Klijenti
end try
begin catch
	return error_number()
end catch
go

exec dbo.PrikaziSve -- test


-----------------------------------
-- Procedura Insert ---------------
-----------------------------------

go
create procedure dbo.InsertKlijent
@naziv nvarchar(40),
@kontakt nvarchar(30),
@grad nvarchar(15),
@zemlja nvarchar(15)
as
set lock_timeout 3000
begin try
	insert into dbo.Klijenti
	(Naziv, Kontakt, Grad, Zemlja)
	values
	(@naziv, @kontakt, @grad, @zemlja)
	return 0
end try
begin catch
	return error_number()
end catch
go

-- test
declare @Ret int
exec @Ret = dbo.InsertKlijent N'Novi klijent123', N'Prezime, Ime', N'Beograd', N'Srbija'

select * from dbo.Klijenti order by KlijentId desc

-----------------------------------
-- Procedura Update ---------------
-----------------------------------

go
create procedure dbo.UpdateKlijent
@klijentid int, 
@naziv nvarchar(40),
@kontakt nvarchar(30),
@grad nvarchar(15),
@zemlja nvarchar(15)
as
set lock_timeout 3000
if not exists (select KlijentId from dbo.Klijenti where KlijentId = @klijentid)
begin
	return -1
end
begin try
	update dbo.Klijenti
	set
		naziv = @naziv,
		kontakt = @kontakt,
		grad = @grad,
		zemlja = @zemlja
	where klijentid = @klijentid
	return 0
end try
begin catch
	return error_number()
end catch
go

-- test
declare @Ret int
exec @Ret = dbo.UpdateKlijent 1, N'Najnoviji klijent', N'Prezime, Ime', N'Novi Sad', ''
print @Ret

exec @Ret = dbo.UpdateKlijent 1, N'Najnoviji klijent', N'Prezime, Ime', N'Novi Sad', N'Srbija'

select * from dbo.Klijenti

-----------------------------------
-- Procedura Delete ---------------
-----------------------------------

go
create procedure dbo.DeleteKlijent
@klijentid int
as
set lock_timeout 3000
if not exists (select KlijentId from dbo.Klijenti where KlijentId = @klijentid)
begin
	return -1
end
begin try
	delete from dbo.Klijenti
	where KlijentId = @klijentid
	return 0
end try
begin catch
	return error_number()
end catch
go

-- test

select * from dbo.Klijenti order by KlijentId desc

declare @Ret int
exec @Ret = dbo.DeleteKlijent 196106

