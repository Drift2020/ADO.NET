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
 
update Questios set Answer_1 = '0',Answer_2 = '0' where Questio like '%Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?%'
go

Create Procedure Update_Questio @Questio_old nvarchar(255), @Questio nvarchar(255), @Answer_1 nvarchar(255), @Answer_2 nvarchar(255), @Answer_3 nvarchar(255) , @Answer_4 nvarchar(255)
as
external name Milion.StoredProcedures.Update_Questio -- имя_сборки.имя_класса.имя_процедуры
go

CREATE ASSEMBLY Milion authorization dbo from 'E:\Program\GitHub\ADO.NET\MilionerV2_1513174412\Milion\bin\Debug\Milion.dll'
with permission_set = safe

use master
Execute sp_configure 'clr_enable', 1
RECONFIGURE

EXEC sp_configure 'show advanced options', 1
RECONFIGURE;
EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;