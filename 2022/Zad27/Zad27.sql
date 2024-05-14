create database if not exists OnlineShop;
use OnlineShop;

create table Laptops
(
	ID int primary key auto_increment,
	Марка varchar(50),
    Модел varchar(50),
    Наличност int,
    Цена decimal(15, 2)
);

insert into Laptops (Марка, Модел, Наличност, Цена) values 
	('Laptop1', 'L29KAS', 10, 1100),
	('Laptop2', '15FD7', 14, 1350),
	('Laptop1', 'L29GTA', 12, 1500),
	('Laptop1', 'L29DFT', 8, 1499),
	('Laptop2', '15FDMS', 11, 1600);

delete from Laptops where Модел = '15FD7';

select Модел, (Наличност * Цена) * 1.2 as Общо from Laptops;

select Марка, SUM(Наличност) from Laptops
where Марка = 'Laptop1';
