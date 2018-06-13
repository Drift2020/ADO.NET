--¬ывести самые дорогие продукты из разных фирм

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
ADD CONSTRAINT fk_adress
FOREIGN KEY (AdressaID)
REFERENCES Adressa (ID)
ON DELETE CASCADE;

alter table  Adressa_link
ADD CONSTRAINT fk_firm
FOREIGN KEY (FirmID)
REFERENCES Firm (ID)
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
ADD CONSTRAINT fk_category
FOREIGN KEY (CategoryID)
REFERENCES Product_category (ID)
ON DELETE CASCADE;


alter table  Product_category_link
ADD CONSTRAINT fk_category
FOREIGN KEY (ProductID)
REFERENCES Product (ID)
ON DELETE CASCADE;
go