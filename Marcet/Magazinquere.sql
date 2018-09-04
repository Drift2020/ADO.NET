--Вывести самые дорогие продукты из разных фирм

WITH Max_prices AS
(select Firm.id,  max(Price.Price) as max_price
 from Price,Firm,Product
 where Product.FirmID = Firm.ID and
 Price.ProductID=Product.ID
 group by Firm.ID)

Select Product.Name , max(Price.Price)
from Product, Firm,Price,Max_prices
where Product.FirmID = Firm.ID and
		Price.ProductID=Product.ID and
		Max_prices.max_price = Price.Price and
		max_prices.ID = Product.FirmID
group by  Product.Name


go

alter table  Adressa_link
ADD CONSTRAINT fk_adress_link_adress
FOREIGN KEY (AdressaID)
REFERENCES Adressa (ID)
ON DELETE CASCADE;

alter table  Adressa_link
ADD CONSTRAINT fk_adress_link_firm
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;



go


alter table  Product_life_link
ADD CONSTRAINT fk_Product_life_link_Product_life_m
FOREIGN KEY (DateID)
REFERENCES Product_life (ID)
ON DELETE CASCADE;

alter table  Product_life_link
ADD CONSTRAINT fk_Product_life_link_Product_m
FOREIGN KEY (ProductID)
REFERENCES Product (ID)
ON DELETE CASCADE;



go


alter table  Product_category_link
ADD CONSTRAINT fk_category
FOREIGN KEY (CategoryID)
REFERENCES Product_category (ID)
ON DELETE CASCADE;


alter table  Product_category_link
ADD CONSTRAINT fk_Product
FOREIGN KEY (ProductID)
REFERENCES Product (ID)
ON DELETE CASCADE;

go


alter table  Fio_link
ADD CONSTRAINT fk_fio
FOREIGN KEY (FioID)
REFERENCES Fio_Person (ID)
ON DELETE CASCADE;


alter table  Fio_link
ADD CONSTRAINT fk_prod
FOREIGN KEY (ProductID)
REFERENCES Product (ID)
ON DELETE CASCADE;
go


alter table  Phone
ADD CONSTRAINT fk_firm_del
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;
go

alter table  Price
ADD CONSTRAINT fk_prod_del
FOREIGN KEY (ProductID)
REFERENCES Product (ID)
ON DELETE CASCADE;
go

alter table  Product
ADD CONSTRAINT fk_prod_del_firm
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;
go



alter table Вoss_link
ADD CONSTRAINT fk_boss_link_boss_m
FOREIGN KEY (BossID)
REFERENCES Boss (ID)
ON DELETE CASCADE;

alter table Вoss_link
ADD CONSTRAINT fk_boss_link_firm_m
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;

go

alter table Country_link
ADD CONSTRAINT fk_Country_link_Country_m
FOREIGN KEY (CountryID)
REFERENCES Country (ID)
ON DELETE CASCADE;

alter table Country_link
ADD CONSTRAINT fk_Country_link_firm_m
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;



go

alter table City_link
ADD CONSTRAINT fk_City_link_City_m
FOREIGN KEY (CityID)
REFERENCES City (ID)
ON DELETE CASCADE;

alter table City_link
ADD CONSTRAINT fk_City_link_firm_m
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
ON DELETE CASCADE;

go

