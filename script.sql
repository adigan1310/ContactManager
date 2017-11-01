/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [ContactManager]    Script Date: 10/29/2017 8:08:02 AM ******/
CREATE DATABASE [ContactManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.ADITHYA\MSSQL\DATA\ContactManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.ADITHYA\MSSQL\DATA\ContactManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ContactManager] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManager] SET RECOVERY FULL 
GO
ALTER DATABASE [ContactManager] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManager] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactManager', N'ON'
GO
ALTER DATABASE [ContactManager] SET QUERY_STORE = OFF
GO
USE [ContactManager]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ContactManager]
GO
/****** Object:  Table [dbo].[CONTACT]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACT](
	[contactid] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](15) NOT NULL,
	[minit] [varchar](1) NULL,
	[lastname] [varchar](30) NOT NULL,
	[dateofbirth] [date] NULL,
	[occupation] [varchar](15) NULL,
	[gender] [varchar](6) NOT NULL,
	[dateofcreation] [datetime] NOT NULL,
 CONSTRAINT [pk_contactid] PRIMARY KEY CLUSTERED 
(
	[contactid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADDR]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDR](
	[contact_id] [int] NOT NULL,
	[addr_id] [int] IDENTITY(1,1) NOT NULL,
	[city] [varchar](20) NULL,
	[state] [varchar](20) NULL,
	[country] [varchar](20) NULL,
	[zipcode] [varchar](12) NULL,
	[addr_type] [char](1) NULL,
 CONSTRAINT [pk_addressid] PRIMARY KEY CLUSTERED 
(
	[addr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADDRLINES]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRLINES](
	[addr_id] [int] NOT NULL,
	[linenumber] [int] NOT NULL,
	[addr_descr] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ADDRLINES] PRIMARY KEY CLUSTERED 
(
	[addr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[address_descr]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[address_descr] as 
	select c.contactid,
	Case when a.country = ' ' then 
	concat(b.addr_descr,',',a.city,',',a.state,',',a.zipcode)
	Else concat(b.addr_descr,',',a.city,',',a.state,',',a.zipcode,',',a.country)
	End
	as contact_address from ADDR as a,CONTACT as c,ADDRLINES as b where c.contactid = a.contact_id
	and a.addr_id = b.addr_id;

GO
/****** Object:  Table [dbo].[EMAIL]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMAIL](
	[contact_id] [int] NOT NULL,
	[emailid] [varchar](50) NOT NULL,
	[emailtype] [char](1) NOT NULL,
 CONSTRAINT [PK_EMAIL] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONENUMBER]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONENUMBER](
	[contact_id] [int] NOT NULL,
	[number] [varchar](14) NOT NULL,
	[numbertype] [char](1) NOT NULL,
 CONSTRAINT [PK_PHONENUMBER] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[get_data]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[get_data] as 
select 
c.contactid,c.firstname,c.minit,c.lastname,c.dateofbirth,c.gender,a.contact_address,p.number,e.emailid,c.occupation
from contact as c 
join address_descr as a on c.contactid = a.contactid
join email as e on c.contactid = e.contact_id
join phonenumber as p on c.contactid = p.contact_id
GO
/****** Object:  Table [dbo].[DEPENDENT]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPENDENT](
	[contact_id] [int] NOT NULL,
	[group_id] [int] NULL,
	[relation_id] [int] NULL,
	[dependent_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EVENTSNREMINDERS]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVENTSNREMINDERS](
	[contact_id] [int] NOT NULL,
	[datentime] [datetime] NULL,
	[event_type] [varchar](9) NULL,
	[location] [varchar](10) NULL,
	[event_descr] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GROUPS]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUPS](
	[groupid] [int] IDENTITY(111,1) NOT NULL,
	[category] [varchar](20) NOT NULL,
 CONSTRAINT [pk_groupid] PRIMARY KEY CLUSTERED 
(
	[groupid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOGS]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOGS](
	[contact_id] [int] NOT NULL,
	[logtype] [varchar](10) NULL,
	[log_descr] [varchar](255) NULL,
	[datentime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RELATIONSHIP]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RELATIONSHIP](
	[relationid] [int] IDENTITY(1111,1) NOT NULL,
	[reltype] [varchar](20) NULL,
 CONSTRAINT [pk_relateid] PRIMARY KEY CLUSTERED 
(
	[relationid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PLACE]    Script Date: 10/29/2017 8:08:03 AM ******/
CREATE NONCLUSTERED INDEX [PLACE] ON [dbo].[ADDR]
(
	[city] ASC,
	[state] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CONTACT_NAME]    Script Date: 10/29/2017 8:08:03 AM ******/
CREATE NONCLUSTERED INDEX [CONTACT_NAME] ON [dbo].[CONTACT]
(
	[firstname] ASC,
	[lastname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20171028-030703]    Script Date: 10/29/2017 8:08:03 AM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20171028-030703] ON [dbo].[PHONENUMBER]
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CONTACT] ADD  DEFAULT (getdate()) FOR [dateofcreation]
GO
ALTER TABLE [dbo].[ADDR]  WITH CHECK ADD  CONSTRAINT [fk_address_contact] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[ADDR] CHECK CONSTRAINT [fk_address_contact]
GO
ALTER TABLE [dbo].[ADDRLINES]  WITH CHECK ADD  CONSTRAINT [fk_addresslines_address] FOREIGN KEY([addr_id])
REFERENCES [dbo].[ADDR] ([addr_id])
GO
ALTER TABLE [dbo].[ADDRLINES] CHECK CONSTRAINT [fk_addresslines_address]
GO
ALTER TABLE [dbo].[DEPENDENT]  WITH CHECK ADD  CONSTRAINT [fk_dependent_contactid] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[DEPENDENT] CHECK CONSTRAINT [fk_dependent_contactid]
GO
ALTER TABLE [dbo].[DEPENDENT]  WITH CHECK ADD  CONSTRAINT [fk_dependent_dependentid] FOREIGN KEY([dependent_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[DEPENDENT] CHECK CONSTRAINT [fk_dependent_dependentid]
GO
ALTER TABLE [dbo].[DEPENDENT]  WITH CHECK ADD  CONSTRAINT [fk_dependent_groupid] FOREIGN KEY([group_id])
REFERENCES [dbo].[GROUPS] ([groupid])
GO
ALTER TABLE [dbo].[DEPENDENT] CHECK CONSTRAINT [fk_dependent_groupid]
GO
ALTER TABLE [dbo].[DEPENDENT]  WITH CHECK ADD  CONSTRAINT [fk_dependent_relationship] FOREIGN KEY([relation_id])
REFERENCES [dbo].[RELATIONSHIP] ([relationid])
GO
ALTER TABLE [dbo].[DEPENDENT] CHECK CONSTRAINT [fk_dependent_relationship]
GO
ALTER TABLE [dbo].[EMAIL]  WITH CHECK ADD  CONSTRAINT [fk_emailid] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[EMAIL] CHECK CONSTRAINT [fk_emailid]
GO
ALTER TABLE [dbo].[EVENTSNREMINDERS]  WITH CHECK ADD  CONSTRAINT [fk_reminderid] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[EVENTSNREMINDERS] CHECK CONSTRAINT [fk_reminderid]
GO
ALTER TABLE [dbo].[LOGS]  WITH CHECK ADD  CONSTRAINT [fk_logsid] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[LOGS] CHECK CONSTRAINT [fk_logsid]
GO
ALTER TABLE [dbo].[PHONENUMBER]  WITH CHECK ADD  CONSTRAINT [fk_phonenumberid] FOREIGN KEY([contact_id])
REFERENCES [dbo].[CONTACT] ([contactid])
GO
ALTER TABLE [dbo].[PHONENUMBER] CHECK CONSTRAINT [fk_phonenumberid]
GO
ALTER TABLE [dbo].[CONTACT]  WITH CHECK ADD CHECK  ((datepart(year,[dateofbirth])>(datepart(year,getdate())-(100)) AND datepart(year,[dateofbirth])<datepart(year,getdate())))
GO
ALTER TABLE [dbo].[CONTACT]  WITH CHECK ADD CHECK  (([gender]='Female' OR [gender]='Male'))
GO
ALTER TABLE [dbo].[EVENTSNREMINDERS]  WITH CHECK ADD CHECK  (([datentime]>getdate()))
GO
ALTER TABLE [dbo].[LOGS]  WITH CHECK ADD CHECK  (([datentime]<getdate()))
GO
/****** Object:  StoredProcedure [dbo].[AddAddress]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[AddAddress](
	@contactid int,
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12)
)
As
Declare @addrid int
Begin
	insert into ADDR(contact_id,city,state,country,zipcode,addr_type) values 
	(@contactid,@city,@state,@country,@zipcode,'P');
	select @addrid=addr_id from ADDR where contact_id = @contactid;
	insert into ADDRLINES values (@addrid,1,@street);
End
GO
/****** Object:  StoredProcedure [dbo].[Adddata]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[Adddata](
	@firstname varchar(15),
	@lastname varchar(30),
	@dateofbirth date,
	@gender varchar(6),
	@email varchar(50),
	@occupation varchar(15),
	@minit varchar(3),
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12),
	@number varchar(14)
	)
As
Declare 
@contactid int
Begin
	insert into CONTACT values(@firstname,@minit,@lastname,@dateofbirth,@occupation,@gender,GETDATE());
	select @contactid = contactid from CONTACT where firstname=@firstname and lastname=@lastname;
	execute AddNumber @contactid,@number
	execute AddEmail @contactid,@email
	execute AddAddress @contactid,@street,@city,@state,@country,@zipcode
End
GO
/****** Object:  StoredProcedure [dbo].[AddEmail]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddEmail](
@contactid int,
@email varchar(50)
)
As
Begin
insert into EMAIL values(@contactid,@email,'P');
End
GO
/****** Object:  StoredProcedure [dbo].[AddNumber]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[AddNumber](
@contactid int,
@number varchar(14)
)
As
Begin
insert into PHONENUMBER values(@contactid,@number,'P');
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteData]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteData](
	@ID int
)
As
Declare @out int
Declare @addrid int
Begin
	select @addrid=addr_id from ADDR where contact_id = @ID;
	delete from ADDRLINES where addr_id = @addrid;
	delete from ADDR where contact_id = @ID;
	delete from EMAIL where contact_id = @ID;
	delete from PHONENUMBER where contact_id = @ID;
	delete from CONTACT where contactid = @ID;
	select @out = count(contactid) from CONTACT;
	if @out = 0 
		DBCC CHECKIDENT (Contact, RESEED, 0); 
		DBCC CHECKIDENT (Addr, RESEED, 0);
End
GO
/****** Object:  StoredProcedure [dbo].[GetData]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetData]
As
Begin
	select firstname,minit,lastname,dateofbirth,gender,contact_address,number,emailid,occupation from get_data
End
GO
/****** Object:  StoredProcedure [dbo].[GetID]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[GetID](
	@firstname varchar(15),
	@lastname varchar(30),
	@number varchar(12)
	)
As
Begin
	select contactid from get_data
	where firstname = @firstname
	and lastname = @lastname
	and number = @number
End
GO
/****** Object:  StoredProcedure [dbo].[SaveAddr]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[SaveAddr](
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12),
	@ID int
)
As
Declare @addrid int
Begin
		update ADDR set
		city = @city,
		state = @state,
		country = @country,
		zipcode = @zipcode
		where contact_id = @ID;
		select @addrid=addr_id from ADDR where contact_id = @ID;
		update ADDRLINES set
		addr_descr = @street
		where addr_id = @addrid;

End
GO
/****** Object:  StoredProcedure [dbo].[SaveData]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[SaveData](
	@firstname varchar(15),
	@lastname varchar(30),
	@dateofbirth date,
	@gender varchar(6),
	@email varchar(50),
	@occupation varchar(15),
	@minit varchar(3),
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12),
	@number varchar(14),
	@ID int
	)
AS
Begin
	Update Contact set firstname = @firstname,
	lastname = @lastname,
	minit = @minit,
	dateofbirth = @dateofbirth,
	occupation = @occupation,
	gender = @gender
	where contactid = @ID;
	execute SaveAddr @street,@city,@state,@country,@zipcode,@ID;
	execute SaveNumber @number,@ID;
	execute SaveEmail @email,@ID;
End

GO
/****** Object:  StoredProcedure [dbo].[SaveEmail]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SaveEmail](
	@email varchar(50),
	@ID int
)
As
Begin
	update EMAIL set emailid = @email where contact_id = @ID;
End
GO
/****** Object:  StoredProcedure [dbo].[SaveNumber]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SaveNumber](
	@number varchar(14),
	@ID int
)
As
Begin
	update PHONENUMBER set number = @number where contact_id = @ID;
End
GO
/****** Object:  StoredProcedure [dbo].[SearchData]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[SearchData](
	@firstname varchar(15),
	@lastname varchar(30),
	@dateofbirth varchar(4),
	@gender varchar(6),
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12),
	@number char(12),	
	@email varchar(50),
	@occupation varchar(15),
	@minit varchar(3)
)
As
declare @addr varchar(max)
Begin
set @addr = 'select firstname,minit,lastname,dateofbirth,gender,contact_address,number,emailid,occupation from get_data where ';
if @firstname != '' 
	set @addr = @addr + ' firstname = ''' + @firstname + ''' and';
if @lastname != ''
	set @addr = @addr + ' lastname = ''' + @lastname + ''' and';
if @gender != ''
	set @addr = @addr + ' gender = ''' + @gender + ''' and';	
if @street != ''
	set @addr = @addr + ' contact_address like ''' + @street + '%''' + ' and';
if @city != ''
	set @addr = @addr + ' contact_address like ''%' + @city + '%''' + ' and';
if @state != ''
	set @addr = @addr + ' contact_address like ''%' + @state + '%''' + ' and';
if @country != ''
	set @addr = @addr + ' contact_address like ''%' + @country + '''' + ' and';
if @zipcode != ''
	set @addr = @addr + ' contact_address like ''%' + @zipcode + '%''' + ' and';
if @number != ''
	set @addr = @addr + ' number = ''' + @number + ''' and';
if @email != ''
	set @addr = @addr + ' emailid = ''' + @email + ''' and';
if @occupation != ''
	set @addr = @addr + ' occupation = ''' + @occupation + ''' and';
if @minit != ''
	set @addr = @addr + ' minit = ''' + @minit + ''' and';
if @dateofbirth != ''
	set @addr = @addr + ' YEAR(dateofbirth) = ''' + @dateofbirth + ''' and';
set @addr = SUBSTRING(@addr,1,LEN(@addr)-4);
execute(@addr)
End
GO
/****** Object:  StoredProcedure [dbo].[SearchID]    Script Date: 10/29/2017 8:08:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[SearchID](
	@firstname varchar(15),
	@lastname varchar(30),
	@dateofbirth date,
	@gender char(6),
	@email varchar(50),
	@occupation varchar(15),
	@minit varchar(3),
	@street varchar(50),
	@city varchar(20),
	@state varchar(20),
	@country varchar(20),
	@zipcode varchar(12),
	@number varchar(14)
	)
As
declare @addr varchar(max)
Begin
set @addr = 'select contactid from get_data where ';
if @firstname != '' 
	set @addr = @addr + ' firstname = ''' + @firstname + ''' and';
if @lastname != ''
	set @addr = @addr + ' lastname = ''' + @lastname + ''' and';
if @gender != ''
	set @addr = @addr + ' gender = ''' + @gender + ''' and';	
if @street != ''
	set @addr = @addr + ' contact_address like ''' + @street + '%''' + ' and';
if @city != ''
	set @addr = @addr + ' contact_address like ''%' + @city + '%''' + ' and';
if @state != ''
	set @addr = @addr + ' contact_address like ''%' + @state + '%''' + ' and';
if @country != ''
	set @addr = @addr + ' contact_address like ''%' + @country + '''' + ' and';
if @zipcode != ''
	set @addr = @addr + ' contact_address like ''%' + @zipcode + '%''' + ' and';
if @number != ''
	set @addr = @addr + ' number = ''' + @number + ''' and';
if @email != ''
	set @addr = @addr + ' emailid = ''' + @email + ''' and';
if @occupation != ''
	set @addr = @addr + ' occupation = ''' + @occupation + ''' and';
if @minit != ''
	set @addr = @addr + ' minit = ''' + @minit + ''' and';
set @addr = SUBSTRING(@addr,1,LEN(@addr)-4);
execute(@addr)
End
GO
USE [master]
GO
ALTER DATABASE [ContactManager] SET  READ_WRITE 
GO
