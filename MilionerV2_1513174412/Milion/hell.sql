Create Procedure [Save] @q nvarchar(255), @a1 nvarchar(255),  @a2  nvarchar(255), @a3  nvarchar(255), @a4  nvarchar(255)
as
external name Milion.StoredProcedures.[Save] -- имя_сборки.имя_класса.имя_процедуры
go
execute [Save] 'Hi','This','World','Is','crazy'
go

drop table Questios
create table Questios ( Questio nvarchar(255)
      ,Answer_1 nvarchar(255)
      ,Answer_2 nvarchar(255)
      ,Answer_3 nvarchar(255)
      ,Answer_4 nvarchar(255))

DELETE FROM Questios where Questio like '%Как называется место на берегу, где обитают тюлени?%';
go

Create Procedure Delete_Questio @Questio nvarchar(255)
as
external name Milion.StoredProcedures.Delete_Questio -- имя_сборки.имя_класса.имя_процедуры
go
 
update Questios set Questio = '',Answer_1 = '',Answer_2 = '',Answer_3 = '',Answer_4 = '' where Questio like ''