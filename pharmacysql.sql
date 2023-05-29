--Aliþan Kahraman
create database eczane1;
use eczane1;


create table satis
(satis_id int primary key not null,
ilac_id int foreign key references ilac(ilac_id) not null,
miktar int not null,
satis_tarih datetime not null,
fiyat decimal not null,
satanper_id int foreign key references personel(personel_id) not null)

create table hasta
(hasta_id int primary key not null,
h_ad varchar(20) not null,
h_soyad varchar(20) not null,
cinsiyet_id int foreign key references cinsiyet(cinsiyet_id) not null,
telefon varchar(10) not null,
email varchar,
adres varchar, 
TC_no varchar(11) not null);

create table recete
(rct_id int primary key not null,
yazan_doktor_id int foreign key references doktor(dr_id) not null,
hastaid int foreign key references hasta(hasta_id) not null,
tarih datetime not null,
satan_pers_id int foreign key references personel(personel_id) not null,
ilac_id int not null);

create table doktor
(dr_id int primary key not null,
dr_ad varchar(20) not null,
dr_soyad varchar(20) not null,
hastane_id int foreign key references hastane(hastane_id) not null,
alan_id int foreign key references alan(alan_id) not null);

create table alan
(alan_id int primary key not null,
alan_ad varchar(30) not null);

create table hastane
(hastane_id int primary key not null,
hastane_ad varchar(30) not null);

create table personel
(personel_id int primary key not null,
pers_ad varchar(20) not null,
pers_soyad varchar(20) not null,
pers_tel nvarchar(10) not null,
pers_isealim datetime not null,
kullanici_adi nvarchar(10) not null,
sifre varchar(10) not null);

create table ilac
(ilac_id int primary key not null,
ilac_ad varchar(30) not null,
kullanim_gün int not null,
ilac_fiyat decimal not null,
firma_id int foreign key references firma(firma_id) not null);

create table firma
(firma_id int primary key not null,
firma_ad varchar(20) not null,
firma_adres varchar(30) not null);

create table cinsiyet
(cinsiyet_id int primary key not null,
cinsiyet_ad varchar(5) not null);


