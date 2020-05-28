/*
	functia valideaza pretul unui preparat
	returneaza 1 daca e valid
			   0 dace e invalid
*/
create or alter function ValidarePret(@pret int) returns int as
begin
declare @return int
set @return = 1
if @pret <= 0
	set @return = 0
return @return
end


/*
	functia valideaza valoarea calorica unui ingredient
	returneaza 1 daca e valida
			   0 dace e invalida
*/
create or alter function ValidareValoareCalorica(@val int) returns int as
begin
declare @return int
set @return = 1
if @val <= 0
	set @return = 0
return @return
end


/*
	cream tabelul corespunzator sistemului de logare
*/
create table LogTable(
	Lid int identity primary key,
	TypeOperation varchar(50),
	TableOperation varchar(50),
	ExecutionDate datetime
)


/*
	1. Procedura de inserare cu rollback total(o singura tranzactie)
*/
create or alter procedure inserareCuRollbackTotal
	@denumirePreparat varchar(50),
	@pret int,
	@denumireIngredient varchar(50),
	@valoareCalorica int
as
begin
	declare @IngredientID int
	declare @PreparatID int

	delete from LogTable;

	begin tran;
	begin try
		--validare campuri
		if(dbo.ValidarePret(@pret) = 0)
		begin
			raiserror('Pretul trebuie sa fie strict pozitiv', 14, 1);
		end
		if(dbo.ValidareValoareCalorica(@valoareCalorica) = 0)
		begin
			raiserror('Valoarea calorica trebuie sa fie strict pozitiva', 14, 1);
		end

		--adaugare Preparat
		set @PreparatID = (select max(Prid) from Preparat) + 1
		insert into Preparat(Prid, Denumire, Pret) values(@PreparatID, @denumirePreparat, @pret);
		insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'Preparat', GETDATE())

		--adaugare Ingredient
		insert into Ingredient(Denumire, ValoareCalorica) values(@denumireIngredient, @valoareCalorica);
		set @IngredientID = (select SCOPE_IDENTITY())
		insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'Ingredient', GETDATE())

		--adaugare IngredientPreparat
		insert into IngredientPreparat(Iid, Prid) values(@IngredientID, @PreparatID);
		insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'IngredientPreparat', GETDATE())
	commit tran;
	select 'Transaction committed'
	select * from LogTable;
	end try

	begin catch
		rollback tran;
		select 'Transaction rollbacked'
		select ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage
		select * from LogTable;
	end catch
end

/*	2. Procedura de inserare cu rollback partial(3 tranzactii)*/
create or alter procedure inserareCuRollbackPartial
	@denumirePreparat varchar(50),
	@pret int,
	@denumireIngredient varchar(50),
	@valoareCalorica int
as
begin
	declare @IngredientID int = -1
	declare @PreparatID int = -1

	delete from LogTable;
	begin tran;
		--adaugare Preparat
		if(dbo.ValidarePret(@pret) = 1)
		begin
			set @PreparatID = (select max(Prid) from Preparat) + 1
			insert into Preparat(Prid, Denumire, Pret) values(@PreparatID, @denumirePreparat, @pret);
			insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'Preparat', GETDATE())
			commit tran;
			select 'Transaction(Preparat) committed'
		end
		else
		begin
			rollback tran
			select 'Pretul preparatului trebuie sa fie strict pozitiv'
		end

	begin tran;
		--adaugare Ingredient
		if(dbo.ValidareValoareCalorica(@valoareCalorica) = 1)
		begin
			insert into Ingredient(Denumire, ValoareCalorica) values(@denumireIngredient, @valoareCalorica);
			set @IngredientID = (select SCOPE_IDENTITY())
			insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'Ingredient', GETDATE())
			commit tran;
			select 'Transaction(Ingredient) committed'
		end
		else
		begin
			rollback tran
			select 'Valoarea calorica a ingredientului trebuie sa fie strict pozitiva'
		end

	begin tran;
		--adaugare IngredientPreparat
		if(@IngredientID <> -1 and @PreparatID <> -1)
		begin
			insert into IngredientPreparat(Iid, Prid) values(@IngredientID, @PreparatID);
			insert into LogTable(TypeOperation, TableOperation, ExecutionDate) values('insert', 'IngredientPreparat', GETDATE())
			commit tran;
			select 'Transaction(IngredientPreparat) committed'
		end
		else
		begin
			rollback tran
			select 'Transaction(IngredientPreparat) denied'
		end

	select * from LogTable;
end

select columnproperty(object_id('Preparat'),'Prid','IsIdentity') -- PreparatID NU e cu identity
select columnproperty(object_id('Ingredient'),'Iid','IsIdentity') --IngredientID e cu identity


/*
	teste:
	->pt prima procedura(inserareCuRollbackTotal)
		-scenariu cu succes:
			exec inserareCuRollbackTotal 'Tochitura de porc', 10, 'Carne veritabila de porc', 200
		-scenariu cu eroare(pretul preparatului este negativ, astfel ca NU se va efectua tranzactia):
			exec inserareCuRollbackTotal 'Tochitura de porc', -10, 'Carne veritabila de porc', 200

	->pt a doua procedura(inserareCuRollback)
		-scenariu cu succes:
			exec inserareCuRollback 'Orez cu fasole', 15, 'Orez oriental', 100
		-scenariu cu eroare(valoarea calorica a ingredientului este negativa, astfel ca NU se va efectua tranzactia adaugarii ingredientului):
			exec inserareCuRollback 'Orez cu fasole', 15, 'Orez oriental', -100
*/


