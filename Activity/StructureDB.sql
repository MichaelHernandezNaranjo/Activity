USE [Activity]
--use [master]
--drop database  [Activity]
--create  database  [Activity]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create table Application(
	ApplicationId int NOT NULL,
	ApplicationName varchar(120) NOT NULL,
	Active bit NOT NULL,
	constraint PK_Application primary key clustered (ApplicationId asc),
	)
GO

insert into Application values (1,'Activity',1)

create table [Authorization](
	ApplicationId int NOT NULL,
	AuthorizationId int NOT NULL,
	UserName varchar(120) NOT NULL,
	password varchar(120) NOT NULL,
	Active bit NOT NULL,
	constraint PK_Authentication primary key clustered (ApplicationId asc, AuthorizationId asc),
	constraint FK_Authentication_Application foreign key (ApplicationId) references Application (ApplicationId),
	)
GO

insert into [Authorization] values (1,1,'/GkzTSkj4XXcfXrOn7+5bA64f+fH7wBdDRx4sIeFaFPYz6wh/eGbJSh66NZt4+YDvEgWgODwdLHp2eV4Mxy1/282v6BMzYmW','/GkzTSkj4XXcfXrOn7+5bA64f+fH7wBdDRx4sIeFaFPYz6wh/eGbJSh66NZt4+YDvEgWgODwdLHp2eV4Mxy1/282v6BMzYmW',1)

create table Company(
	CompanyId int NOT NULL,
	CompanyName varchar(120) NOT NULL,
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NULL,
	constraint PK_Company primary key clustered (CompanyId asc),
	)
GO

insert into Company values (1,'DevManager',1,GETDATE(),NULL)

create table Role(
	RoleId int NOT NULL,
	RoleName varchar(30) NOT NULL unique,
	Description varchar(200) NULL,
	constraint PK_Role primary key clustered (RoleId asc)
	)
GO

insert into Role values (1,'MANAGER','Tiene acceso a todos los proyectos y a todas las tareas (EDITAR)')
insert into Role values (2,'ADMIN','Tiene acceso a todas las tareas de los proyectos asignados (EDITAR)')
insert into Role values (3,'WORKER','Solo puede ver sus tareas (EDITAR)')
insert into Role values (4,'INVITED','Tiene acceso a todas las tareas de los proyectos asignados (VER)')

create table [User](
	CompanyId int NOT NULL,
	UserId int NOT NULL,
	UserName varchar(120) NOT NULL,
	Password varchar(max) NOT NULL,
	RoleId int NULL,
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NULL,
	constraint PK_User primary key clustered (CompanyId asc, UserId asc),
	constraint FK_User_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_User_Role foreign key (RoleId) references [Role] (RoleId),
	constraint FK_User_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

insert into [User] values (1,1,'SYSTEM ADMINISTRATOR','e10adc3949ba59abbe56e057f20f883e',1,1,GETDATE(),NULL)

create table UserEmail(
	CompanyId int NOT NULL,
	UserId int NOT NULL,
	Email varchar(100) NOT NULL,
	UserEmailType varchar(10) NOT NULL, --PRINCIPAL
	Verification bit NOT NULL,
	VerificationDate datetime NULL,
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_UserEmail primary key clustered (CompanyId asc, UserId asc, Email asc),
	constraint FK_UserEmail_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_UserEmail_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId),
	constraint FK_UserEmail_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO


insert into UserEmail values (1,1,'michaelhernandeznaranjo@gmail.com','PRINCIPAL',1,GETDATE(),1,GETDATE(),1)

create table UserImage(
	CompanyId int NOT NULL,
	UserId int NOT NULL,
	Image varchar(30) NOT NULL,--202104100957987
	UserImageType varchar(10) NOT NULL, --20X20
	Extension varchar(10) NOT NULL, --.JPG
	Route varchar(100) NOT NULL, --/ADJUNTOS/IMAGENES/USUARIOS
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_UserImage primary key clustered (CompanyId asc, UserId asc, Image asc),
	constraint FK_UserImage_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_UserImage_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId),
	constraint FK_UserImage_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

create table Project(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	ProjectName varchar(120) NOT NULL,-- PROYECTO X
	Description varchar(500) NULL,-- Descricpion del projecto
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_Project primary key clustered (CompanyId asc, ProjectId asc),
	constraint FK_Project_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_Project_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

insert into Project values (1,1,'Test project',null,1,GETDATE(),1)

--usuarios asignados al proyecto
create table ProjectUser(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	UserId int NOT NULL,
	constraint PK_ProjectUser primary key clustered (CompanyId asc, ProjectId asc,UserId asc),
	constraint FK_ProjectUser_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_ProjectUser_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId)
	)
GO

create table Sprint(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	SprintId int NOT NULL,
	SprintName varchar(120) NOT NULL,
	Description varchar(500) NULL,-- Descricpion del sprint
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_Sprint primary key clustered (CompanyId asc, ProjectId asc, SprintId asc),
	constraint FK_Sprint_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_Sprint_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_Sprint_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO


create table TaskStatus(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskStatusId int NOT NULL,
	TaskStatusName varchar(50) NOT NULL,
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_TaskStatus primary key clustered (CompanyId asc, ProjectId asc, TaskStatusId asc),
	constraint FK_TaskStatus_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskStatus_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_TaskStatus_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

insert into TaskStatus values (1,1,1,'Backlog',1,GETDATE(),1)
insert into TaskStatus values (1,1,2,'To do',1,GETDATE(),1)
insert into TaskStatus values (1,1,3,'Testing',1,GETDATE(),1)
insert into TaskStatus values (1,1,4,'In progress',1,GETDATE(),1)
insert into TaskStatus values (1,1,5,'Done',1,GETDATE(),1)

--Tareas
create table Task(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	TaskName varchar(120) NOT NULL,-- PROYECTO X
	Description varchar(500) NULL,-- Descricpion del tarea

	SprintId int NOT NULL,

	StartDate datetime NULL,-- Fecha de inicio
	EndDate datetime NULL,-- Fecha fin
	Duracion decimal NULL,--Duración
	DuracionUnit varchar(50) NULL,-- MIN

	TaskStatusId int NOT NULL, -- status

	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_Task primary key clustered (CompanyId asc,ProjectId asc, TaskId asc),
	constraint FK_Task_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_Task_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_Task_Sprint foreign key (CompanyId,ProjectId,SprintId) references Sprint (CompanyId,ProjectId,SprintId),
	constraint FK_Task_TaskStatus foreign key (CompanyId,ProjectId,TaskStatusId) references TaskStatus (CompanyId,ProjectId,TaskStatusId),
	constraint FK_Task_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

--tareas pedecesoras
create table TaskPredecessor(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	TaskPredecessorId int NOT NULL,
	constraint PK_TaskPredecessor primary key clustered (CompanyId asc, TaskId asc,ProjectId asc, TaskPredecessorId asc),
	constraint FK_TaskPredecessor_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskPredecessor_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_TaskPredecessor_Task foreign key (CompanyId,ProjectId,TaskId) references Task (CompanyId,ProjectId,TaskId),
	constraint FK_TaskPredecessor_PredecessorTask foreign key (CompanyId,ProjectId,TaskId) references Task (CompanyId,ProjectId,TaskId),
	)
GO

create table TaskUser(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	UserId int NOT NULL,
	constraint PK_TaskUser primary key clustered (CompanyId asc, TaskId asc,ProjectId asc, UserId asc),
	constraint FK_TaskUser_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskUser_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_TaskUser_Task foreign key (CompanyId,ProjectId,TaskId) references Task (CompanyId,ProjectId,TaskId),
	constraint FK_TaskUser_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId)
	)
GO

create table TaskTime(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	TaskTimeId int NOT NULL,
	StartDate datetime NOT NULL,-- Fecha de inicio
	StartUserId int NOT NULL,
	EndDate datetime NULL,-- Fecha fin
	EndUserId int NULL,
	constraint PK_TaskTime primary key clustered (CompanyId asc, TaskId asc,ProjectId asc, TaskTimeId asc),
	constraint FK_TaskTime_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskTime_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_TaskTime_Task foreign key (CompanyId,ProjectId,TaskId) references Task (CompanyId,ProjectId,TaskId),
	constraint FK_TaskTime_StartUser foreign key (CompanyId,StartUserId) references [User] (CompanyId,UserId),
	constraint FK_TaskTime_EndUser foreign key (CompanyId,EndUserId) references [User] (CompanyId,UserId),
	)
GO


create table TaskComment(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	CommentId int NOT NULL,
	UserId int NOT NULL, --Usuario
	Description varchar(500) NOT NULL,-- Descricpion del comentario
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_TaskComment primary key clustered (CompanyId asc,ProjectId asc, TaskId asc, CommentId asc),
	constraint FK_TaskComment_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskComment_Project foreign key (CompanyId,ProjectId) references Project (CompanyId,ProjectId),
	constraint FK_TaskComment_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId),
	constraint FK_TaskComment_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO

create table TaskAttach(
	CompanyId int NOT NULL,
	ProjectId int NOT NULL,
	TaskId int NOT NULL,
	TaskAttachId int NOT NULL,
	UserId int NOT NULL, --Usuario
	Name varchar(30) NOT NULL,--202104100957987
	Type varchar(10) NOT NULL, --20X20
	Extension varchar(10) NOT NULL, --.JPG
	Route varchar(100) NOT NULL, --/ADJUNTOS/IMAGENES/USUARIOS
	Active bit NOT NULL,
	CreationDate datetime NOT NULL,
	CreationUserId int NOT NULL,
	constraint PK_TaskAttach primary key clustered (CompanyId asc, ProjectId asc, TaskId asc, TaskAttachId asc),
	constraint FK_TaskAttach_Company foreign key (CompanyId) references Company (CompanyId),
	constraint FK_TaskAttach_User foreign key (CompanyId,UserId) references [User] (CompanyId,UserId),
	constraint FK_TaskAttach_CreationUser foreign key (CompanyId,CreationUserId) references [User] (CompanyId,UserId),
	)
GO
