create proc CheckCity
	@IDDrzava int,
	@Naziv nvarchar(50)
as
select count(*) from Grad
inner join Drzava on Grad.DrzavaID = Drzava.IDDrzava
where Drzava.IDDrzava = @IDDrzava AND Grad.Naziv = @Naziv
go

create proc CheckState
	@Naziv nvarchar(50)
as
select count(*) from Drzava where Drzava.Naziv = @Naziv
go

create proc CreateCategory
	@Naziv nvarchar(50)
as
insert into Kategorija(Naziv)
values(@Naziv)
go

create proc CreateCustomer
	@Ime nvarchar(50),
	@Prezime nvarchar(50),
	@Email nvarchar(50),
	@Telefon nvarchar(25),
	@GradID int
as
insert into Kupac(Ime, Prezime, Email, Telefon, GradID)
values(@Ime, @Prezime, @Email, @Telefon, @GradID)
go

create proc CreateProduct
	@Naziv nvarchar(50),
	@Broj nvarchar(25),
	@Boja nvarchar(15),
	@Min smallint,
	@Cijena money,	
	@Potkategorija int
as
insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, PotkategorijaID)
values(@Naziv, @Broj, @Boja, @Min, @Cijena, @Potkategorija)
go

create proc CreateSubcategory
	@Naziv nvarchar(50),
	@KategorijaID int
as
insert into Potkategorija(KategorijaID, Naziv)
values(@KategorijaID, @Naziv)
go

create proc DeleteCategory
	@IDKategorija int
as
delete from Stavka where Stavka.ProizvodID IN(select Proizvod.IDProizvod from Proizvod where Proizvod.PotkategorijaID IN(select Potkategorija.IDPotkategorija from Potkategorija where Potkategorija.KategorijaID = @IDKategorija))
delete from Proizvod where Proizvod.PotkategorijaID IN(select Potkategorija.IDPotkategorija from Potkategorija where Potkategorija.KategorijaID = @IDKategorija)
delete from Potkategorija where Potkategorija.KategorijaID = @IDKategorija
delete from Kategorija where Kategorija.IDKategorija = @IDKategorija
go

create proc DeleteCustomer
	@IDKupac int
as
delete from Stavka where Stavka.IDStavka IN(select Stavka.IDStavka where Stavka.RacunID IN(select Racun.IDRacun from Racun where Racun.KupacID=@IDKupac))
delete from Racun where Racun.KupacID = @IDKupac
delete from Kupac where Kupac.IDKupac = @IDKupac
go

create proc DeleteProduct
	@IDProizvod int
as
delete from Stavka where Stavka.ProizvodID = @IDProizvod
delete from Proizvod where Proizvod.IDProizvod = @IDProizvod
go

create proc DeleteSubcategory
@IDPotkategorija int
as
delete from Stavka where Stavka.ProizvodID IN(select Proizvod.IDProizvod from Proizvod where Proizvod.PotkategorijaID = @IDPotkategorija)
delete from Proizvod where Proizvod.PotkategorijaID = @IDPotkategorija
delete from Potkategorija where Potkategorija.IDPotkategorija = @IDPotkategorija
go

create proc GetAllCategories
as
select * from Kategorija
go

create proc GetAllCustomers
as
select Kupac.IDKupac, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon, Drzava.IDDrzava,  Drzava.Naziv as Drzava,Grad.IDGrad, Grad.Naziv as Grad
from Kupac
left join Grad on Kupac.GradID = Grad.IDGrad
left join Drzava on Grad.DrzavaID = Drzava.IDDrzava
order by Kupac.IDKupac
go

create proc GetAllProducts
as
select Proizvod.IDProizvod, Proizvod.Naziv, Proizvod.BrojProizvoda, Proizvod.CijenaBezPDV,Proizvod.Boja, Proizvod.MinimalnaKolicinaNaSkladistu as Kolicina, Proizvod.PotkategorijaID, Potkategorija.Naziv as Potkategorija from Proizvod
left join Potkategorija on Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija
order by Proizvod.IDProizvod
go

create proc GetAllSubcategories
as
select Potkategorija.IDPotkategorija,Potkategorija.Naziv, Potkategorija.KategorijaID, Kategorija.Naziv as Kategorija from  Potkategorija
inner join Kategorija on Potkategorija.KategorijaID = Kategorija.IDKategorija
order by Potkategorija.Naziv
go

create proc GetCategory
@IDKategorija int
as
select * from Kategorija
where Kategorija.IDKategorija = @IDKategorija
go

create proc GetKomercijalist
	@IDRacun int
as
select Komercijalist.Ime, Komercijalist.Prezime
from Komercijalist
inner join Racun on Komercijalist.IDKomercijalist = Racun.KomercijalistID
where Racun.IDRacun = @IDRacun
go

create proc GetKreditnaKartica
	@IDRacun int
as
select KreditnaKartica.Tip, KreditnaKartica.Broj
from KreditnaKartica
inner join Racun on KreditnaKartica.IDKreditnaKartica = Racun.KreditnaKarticaID
where Racun.IDRacun = @IDRacun
go

create proc GetProduct
  @IDProizvod int
as
select Proizvod.IDProizvod, Proizvod.Naziv, Proizvod.BrojProizvoda, Proizvod.CijenaBezPDV,Proizvod.Boja, Proizvod.MinimalnaKolicinaNaSkladistu as Kolicina, Proizvod.PotkategorijaID, Potkategorija.Naziv as Potkategorija from Proizvod
left join Potkategorija on Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija
where Proizvod.IDProizvod = @IDProizvod
go

create proc GetReceipt
 @IDRacun int
 as
 select Racun.IDRacun,Racun.BrojRacuna from Racun
 where Racun.IDRacun = @IDRacun
 go

 create proc GetSubcategory
@IDPotkategorija int
as 
select * from Potkategorija
where Potkategorija.IDPotkategorija = @IDPotkategorija
go

create proc InsertCity
	@GradNaziv nvarchar(50),
	@IDDrzava int
as
insert into Grad(Naziv, DrzavaID)
values(@GradNaziv,@IDDrzava)
go

create proc InsertState
	@Naziv nvarchar(50)
as
insert into Drzava(Naziv)
values (@Naziv)
go

create proc MoreInfoCustomer
	@IDKupac int
as
select Kupac.IDKupac, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon, Drzava.IDDrzava,  Drzava.Naziv as Drzava,Grad.IDGrad, Grad.Naziv as Grad
from Kupac
left join Grad on Kupac.GradID = Grad.IDGrad
left join Drzava on Grad.DrzavaID = Drzava.IDDrzava
where Kupac.IDKupac = @IDKupac
go

create proc ShowCities
	@DrzavaID int
as
select *
from Grad
where Grad.DrzavaID = @DrzavaID
order by Grad.Naziv
go

create proc ShowCustomerFromState
	@IDDrzava int,
	@Param int
as
select Filter.IDKupac, Filter.Ime, Filter.Prezime, Filter.Email, Filter.Telefon, Drzava.IDDrzava,  Drzava.Naziv as Drzava,Grad.IDGrad, Grad.Naziv as Grad from
(select top (@Param) Kupac.IDKupac,Kupac.GradID, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon from Kupac ) as Filter
inner join Grad on Filter.GradID = Grad.IDGrad
inner join Drzava on Grad.DrzavaID = Drzava.IDDrzava
where Drzava.IDDrzava = @IDDrzava
order by Filter.IDKupac
go

create proc ShowCustomerFromStateAndCity
	@IDDrzava int,
	@Param int,
	@Param1 int
as
select Filter.IDKupac, Filter.Ime, Filter.Prezime, Filter.Email, Filter.Telefon, Drzava.IDDrzava,  Drzava.Naziv as Drzava,Grad.IDGrad, Grad.Naziv as Grad from
(select top (@Param) Kupac.IDKupac,Kupac.GradID, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon from Kupac) as Filter
inner join Grad on Filter.GradID = Grad.IDGrad
inner join Drzava on Grad.DrzavaID = Drzava.IDDrzava 
where Drzava.IDDrzava = @IDDrzava AND Grad.IDGrad = @Param1
order by Filter.IDKupac
go

create proc ShowCustomers
	@TopCount int
as
select top (@TopCount) Kupac.IDKupac, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon, Drzava.IDDrzava,  Drzava.Naziv as Drzava,Grad.IDGrad, Grad.Naziv as Grad
from Kupac
left join Grad on Kupac.GradID = Grad.IDGrad
left join Drzava on Grad.DrzavaID = Drzava.IDDrzava
order by Kupac.IDKupac
go

create proc ShowMax
as
select count (*) from Kupac
go

create proc ShowReceipt
	@IDKupac int
as
select Racun.IDRacun,Racun.BrojRacuna, Racun.DatumIzdavanja
from Racun
inner join Kupac on Racun.KupacID = Kupac.IDKupac
where Kupac.IDKupac = @IDKupac
go

create proc ShowReceiptDetails
	@IDRacun int
as
select Proizvod.Naziv as Ime,Kategorija.Naziv as Kategorija, Potkategorija.Naziv as Potkategorija, Stavka.Kolicina, Stavka.CijenaPoKomadu, Stavka. UkupnaCijena
from Stavka
inner join Proizvod on Stavka.ProizvodID = Proizvod.IDProizvod
inner join Potkategorija on Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija
inner join Kategorija on Potkategorija.KategorijaID = Kategorija.IDKategorija
where  Stavka.RacunID = @IDRacun
go

create proc ShowStates
as
select * from Drzava
order by Drzava.Naziv
go

create proc UpdateCategory
	@IDCategory int,
	@Naziv nvarchar(50)

as
update Kategorija
set Naziv = @Naziv
where Kategorija.IDKategorija = @IDCategory
go

create proc UpdateCustomer
	@IDKupac int,
	@Ime nvarchar(50),
	@Prezime nvarchar(50),
	@Email nvarchar(50),
	@Telefon nvarchar(25),
	@GradID int
as
update Kupac
set Ime = @Ime, Prezime = @Prezime,Email= @Email, Telefon=@Telefon, GradID = @GradID
where Kupac.IDKupac = @IDKupac
go

create proc UpdateProduct
	@IDProizvod int,
	@Naziv nvarchar(50),
	@Broj nvarchar(25),
	@Boja nvarchar(15),
	@Min smallint,
	@Cijena money,	
	@Potkategorija int
as
update Proizvod
set Naziv=@Naziv,BrojProizvoda=@Broj,Boja= @Boja,MinimalnaKolicinaNaSkladistu=@Min,CijenaBezPDV=@Cijena,PotkategorijaID=@Potkategorija
where Proizvod.IDProizvod = @IDProizvod
go

create proc UpdateSubcategory
	@IDSubcategory int,
	@Naziv nvarchar(50),
	@KategorijaID int

as
update Potkategorija
set Naziv = @Naziv,KategorijaID=@KategorijaID
where Potkategorija.IDPotkategorija = @IDSubcategory
go









