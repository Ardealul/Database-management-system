use Restaurant
go

--1. DIRTY READS
/*
	Dirty Reads - tranzactia 1 (update -> delay -> rollback)
*/
create or alter procedure DirtyReadsT1
as
begin
	begin transaction
		update Ingredient
		set ValoareCalorica = 200
		where Iid = 1
	waitfor delay '00:00:15'
	rollback transaction
end

/*
	Dirty Reads - tranzactia 2 (select -> delay -> select)
	PROBLEM: set transaction isolation level read uncommitted
*/
create or alter procedure DirtyReadsT2Problem
as
begin
	set transaction isolation level read uncommitted
	begin transaction
		select * from Ingredient
		waitfor delay '00:00:15'
		select * from Ingredient
	commit transaction
end

/*
	Dirty Reads - tranzactia 2 (select -> delay -> select)
	SOLUTION: set transaction isolation level read committed
*/
create or alter procedure DirtyReadsT2Solution
as
begin
	set transaction isolation level read committed
	begin transaction
		select * from Ingredient
		waitfor delay '00:00:15'
		select * from Ingredient
	commit transaction
end

--exec DirtyReadsT1


--2. NON-REPEATABLE READS
/*
	Non-Repeatable Reads - tranzactia 1 (delay -> update -> commit)
*/
create or alter procedure NonRepeatableReadsT1
as
begin
	insert into Ingredient(Denumire, ValoareCalorica) values('Guacamole', 100)
	begin transaction
	waitfor delay '00:00:15'
	update Ingredient
	set ValoareCalorica = 200
	where Denumire = 'Guacamole'
	commit transaction
end

/*
	Non-Repeatable Reads - tranzactia 2 (select -> delay -> select)
	PROBLEM: set transaction isolation level read committed
*/
create or alter procedure NonRepeatableReadsT2Problem
as
begin
	set transaction isolation level read committed
	begin transaction
	select * from Ingredient
	waitfor delay '00:00:15'
	select * from Ingredient
	commit transaction
end

/*
	Non-Repeatable Reads - tranzactia 2 (select -> delay -> select)
	SOLUTION: set transaction isolation level repeatable read
*/
create or alter procedure NonRepeatableReadsT2Solution
as
begin
	set transaction isolation level repeatable read
	begin transaction
	select * from Ingredient
	waitfor delay '00:00:15'
	select * from Ingredient
	commit transaction
end

--exec NonRepeatableReadsT1


--3. PHANTOM READS
/*
	Phantom Reads - tranzactia 1 (delay -> insert -> commit)
*/
create or alter procedure PhantomReadsT1
as
begin
	begin transaction
	waitfor delay '00:00:15'
	insert into Ingredient(Denumire, ValoareCalorica) values('Tarhon', 100)
	commit transaction
end

/*
	Phantom Reads - tranzactia 2 (select -> delay -> select)
	PROBLEM: set transaction isolation level repeatable read
*/
create or alter procedure PhantomReadsT2Problem
as
begin
	set transaction isolation level repeatable read
	begin transaction
	select * from Ingredient
	waitfor delay '00:00:15'
	select * from Ingredient
	commit transaction
end

/*
	Phantom Reads - tranzactia 2 (select -> delay -> select)
	SOLUTION: set transaction isolation level serializable
*/
create or alter procedure PhantomReadsT2Solution
as
begin
	set transaction isolation level serializable
	begin transaction
	select * from Ingredient
	waitfor delay '00:00:15'
	select * from Ingredient
	commit transaction
end

--exec PhantomReadsT1


--4. DEADLOCK
/*
	Deadlock - tranzactia 1 (update Ingredient -> delay -> update Preparat)
*/
create or alter procedure DeadlockT1
as
begin
	begin transaction
	update Ingredient
	set Denumire='Prune T1'
	where Iid=27

	waitfor delay '00:00:15'

	update Preparat
	set Denumire='Placinte T1'
	where Prid=17
	commit transaction
end

/*
	Deadlock - tranzactia 2 (update Preparat -> delay -> update Ingredient)
	PROBLEM: lipseste "set deadlock_priority HIGH", victima fiind aceasta tranzactie
*/
create or alter procedure DeadlockT2Problem
as
begin
	begin transaction
	update Preparat
	set Denumire='Placinte T2'
	where Prid=17

	waitfor delay '00:00:15'

	update Ingredient
	set Denumire='Prune T2'
	where Iid=27
	commit transaction
end

/*
	Deadlock - tranzactia 2 (update Preparat -> delay -> update Ingredient)
	SOLUTION: "set deadlock_priority HIGH", astfel ca se stabileste ca victima sa fie T1(cea care va avea prioritatea mai mica)
*/
create or alter procedure DeadlockT2Solution
as
begin
	set deadlock_priority HIGH
	begin transaction
	update Preparat
	set Denumire='Placinte T2'
	where Prid=17

	waitfor delay '00:00:15'

	update Ingredient
	set Denumire='Prune T2'
	where Iid=27
	commit transaction
end

--exec DeadlockT1
