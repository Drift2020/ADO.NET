Create Procedure [Save]
as
external name Milion.StoredProcedures.[Save] -- имя_сборки.имя_класса.имя_процедуры

drop table Questios
create table Questios ( Questio nvarchar(255)
      ,Answer_1 nvarchar(255)
      ,Answer_2 nvarchar(255)
      ,Answer_3 nvarchar(255)
      ,Answer_4 nvarchar(255))