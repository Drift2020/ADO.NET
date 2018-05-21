Create Procedure [Save] @q nvarchar(255), @a1 nvarchar(255),  @a2  nvarchar(255), @a3  nvarchar(255), @a4  nvarchar(255)
as
external name Milion.StoredProcedures.[Save] -- ���_������.���_������.���_���������
go
execute [Save] 'Hi','This','World','Is','crazy'
go

drop table Questios
create table Questios ( Questio nvarchar(255)
      ,Answer_1 nvarchar(255)
      ,Answer_2 nvarchar(255)
      ,Answer_3 nvarchar(255)
      ,Answer_4 nvarchar(255))

DELETE FROM Questios where Questio like '%��� ���������� ����� �� ������, ��� ������� ������?%';
go

Create Procedure Delete_Questio @Questio nvarchar(255)
as
external name Milion.StoredProcedures.Delete_Questio -- ���_������.���_������.���_���������
go
 
update Questios set Answer_1 = '0' where Questio like '%��� ������� ������ �������� �������-�������� �������������� �������� ������?%'
go

Create Procedure Update_Questio @Questio nvarchar(255), @Answer_1 nvarchar(255), @Answer_2 nvarchar(255), @Answer_3 nvarchar(255) , @Answer_4 nvarchar(255)
as
external name Milion.StoredProcedures.Update_Questio -- ���_������.���_������.���_���������
go