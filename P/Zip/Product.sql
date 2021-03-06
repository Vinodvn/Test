Create database [Interview]

USE [Interview]
GO
/****** Object:  Table [dbo].[CatergoryMaster]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatergoryMaster](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CatergoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CatergoryMaster] ON 

INSERT [dbo].[CatergoryMaster] ([CategoryID], [CategoryName], [IsActive], [CreateDate], [UpdatedDate]) VALUES (1, N'Car 1', 1, CAST(N'2021-02-03 15:18:35.073' AS DateTime), CAST(N'2021-02-03 15:28:24.837' AS DateTime))
INSERT [dbo].[CatergoryMaster] ([CategoryID], [CategoryName], [IsActive], [CreateDate], [UpdatedDate]) VALUES (2, N'Mobile', 1, CAST(N'2021-02-03 15:28:44.020' AS DateTime), CAST(N'2021-02-03 15:28:44.020' AS DateTime))
SET IDENTITY_INSERT [dbo].[CatergoryMaster] OFF
SET IDENTITY_INSERT [dbo].[ProductMaster] ON 

INSERT [dbo].[ProductMaster] ([ProductID], [CategoryID], [ProductName], [IsActive], [CreatedDate], [UpdateDate]) VALUES (1, 2, N'sfd', 1, CAST(N'2021-02-03 16:22:18.393' AS DateTime), CAST(N'2021-02-03 16:58:06.017' AS DateTime))
INSERT [dbo].[ProductMaster] ([ProductID], [CategoryID], [ProductName], [IsActive], [CreatedDate], [UpdateDate]) VALUES (2, 2, N'Samsung', 1, CAST(N'2021-02-03 16:40:46.067' AS DateTime), CAST(N'2021-02-03 16:40:46.067' AS DateTime))
INSERT [dbo].[ProductMaster] ([ProductID], [CategoryID], [ProductName], [IsActive], [CreatedDate], [UpdateDate]) VALUES (3, 1, N'Tata', 1, CAST(N'2021-02-03 16:40:59.790' AS DateTime), CAST(N'2021-02-03 16:40:59.790' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductMaster] OFF
/****** Object:  StoredProcedure [dbo].[usp_AddUpdateCategory]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[usp_AddUpdateCategory]
@CategoryID int,
@CategoryName varchar(50),
@IsActive bit,
@MessageID nvarchar(10) output,
@Message nvarchar(100) output
As
BEGIN

BEGIN TRY
BEGIN TRAN
if(@CategoryID=0)
BEGIN
	if Not Exists(Select 1 from [CatergoryMaster] where IsActive=1 and CategoryName=@CategoryName)
	Begin 
	insert into [CatergoryMaster]
	select @CategoryName,@IsActive,GETDATE(),GETDATE()

	set @MessageID=1
	set @Message =''+@CategoryName+' Saved successfully'
	end
		else
			begin
				set @MessageID=2
				set @Message =''+@CategoryName+' already exists'
			end
END
Else
	BEGIN
		if Not Exists(Select 1 from [CatergoryMaster] where IsActive=1 and CategoryName=@CategoryName and CategoryID!=@CategoryID)
		Begin
			update [CatergoryMaster]
			set CategoryName=@CategoryName,
			IsActive=@IsActive,
			UpdatedDate=GETDATE()
			where CategoryID=@CategoryID 

			set @MessageID=1
			set @Message =''+@CategoryName+' Updated successfully'
		END	
		else
			begin
				set @MessageID=2
				set @Message =''+@CategoryName+' already exists'
			end
	END
commit tran	
 end try
	begin catch
	rollback Tran
				set @MessageID=2
			set @Message =''
	
	end Catch
end

GO
/****** Object:  StoredProcedure [dbo].[usp_AddUpdateProductMaster]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[usp_AddUpdateProductMaster]
@ProductID int,
@ProductName varchar(500),
@CategoryID int,
@IsActive bit,
@MessageID nvarchar(10) output,
@Message nvarchar(100) output
As
BEGIN

BEGIN TRY
BEGIN TRAN
if(@ProductID=0)
BEGIN
	if Not Exists(Select 1 from ProductMaster where IsActive=1 and ProductName=@ProductName)
	Begin 
	insert into [ProductMaster]
	select @CategoryID,@ProductName,@IsActive,GETDATE(),GETDATE()

	set @MessageID=1
	set @Message =''+@ProductName+' Saved successfully'
	end
		else
			begin
				set @MessageID=2
				set @Message =''+@ProductName+' already exists'
			end
END
Else
	BEGIN
		if Not Exists(Select 1 from ProductMaster where IsActive=1 and ProductName=@ProductName and ProductID!=@ProductID)
		Begin
			update ProductMaster
			set CategoryID=@CategoryID,
			ProductName=@ProductName,
			IsActive=@IsActive,
			UpdateDate=GETDATE()
			where ProductID=@ProductID 

			set @MessageID=1
			set @Message =''+@ProductName+' Updated successfully'
		END	
		else
			begin
				set @MessageID=2
				set @Message =''+@ProductName+' already exists'
			end
	END
commit tran	
 end try
	begin catch
	rollback Tran
				set @MessageID=2
			set @Message =''
	
	end Catch
end


GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategory]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetCategory]
As
BEGIN
select CategoryID,CategoryName from CatergoryMaster where IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategoryList]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetCategoryList]
As
BEGIN
select * from CatergoryMaster where IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductList]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetProductList]
AS
BEGIN
select PM.CategoryID,CategoryName,ProductID,ProductName,IsActive from ProductMaster PM
left join (select CategoryID,CategoryName from CatergoryMaster) CM on CM.CategoryID=PM.CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductMasterList]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetProductMasterList]
As
BEGIN
select PM.CategoryID,CategoryName,ProductID,IsActive,ProductName from ProductMaster PM
left join (select CategoryID,CategoryName from CatergoryMaster) CM on CM.CategoryID=PM.CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ProcuctSelectByPrimary]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ProcuctSelectByPrimary]
@PrimaryID int
As
BEGIN
select * from ProductMaster where  ProductID=@PrimaryID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectByPrimary]    Script Date: 2/3/2021 5:10:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SelectByPrimary]
@PrimaryID int
As
BEGIN
select * from [CatergoryMaster] where IsActive=1 and CategoryID=@PrimaryID
END
GO
