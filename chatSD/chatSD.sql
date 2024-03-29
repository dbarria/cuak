IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'MSmerge_PAL_role' AND type = 'R')
CREATE ROLE [MSmerge_PAL_role]
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'MSmerge_830D0464E9514D0CB8B3C6C3E74B1043' AND type = 'R')
CREATE ROLE [MSmerge_830D0464E9514D0CB8B3C6C3E74B1043]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'MSmerge_PAL_role')
EXEC sys.sp_executesql N'CREATE SCHEMA [MSmerge_PAL_role] AUTHORIZATION [MSmerge_PAL_role]'

GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'MSmerge_830D0464E9514D0CB8B3C6C3E74B1043')
EXEC sys.sp_executesql N'CREATE SCHEMA [MSmerge_830D0464E9514D0CB8B3C6C3E74B1043] AUTHORIZATION [MSmerge_830D0464E9514D0CB8B3C6C3E74B1043]'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](32) NOT NULL,
	[ip] [varchar](32) NULL,
	[puerto] [varchar](32) NULL,
	[conectado] [nchar](1) NULL,
	[clave] [varchar](32) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enviar]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Enviar](
	[identificador] [int] NOT NULL,
	[tipo] [int] NULL,
	[cadena] [varchar](1000) NULL,
	[Usuario] [varchar](50) NULL,
	[ip] [varchar](50) NULL,
	[port] [varchar](50) NULL,
	[mensaje] [varchar](250) NULL,
	[pendientes] [varchar](50) NULL,
 CONSTRAINT [PK_Enviar] PRIMARY KEY CLUSTERED 
(
	[identificador] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mensajes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Mensajes](
	[i] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[texto] [varchar](50) NULL,
	[Ip] [varchar](50) NULL,
	[Puerto] [varchar](50) NULL,
	[UsuarioA] [varchar](50) NULL,
	[UsuarioB] [varchar](50) NULL,
	[entregado] [int] NULL CONSTRAINT [DF_Mensajes_entregado]  DEFAULT ((0)),
 CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED 
(
	[i] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuarioStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'







CREATE PROCEDURE [dbo].[usuarioStatus]
@usuario varchar(32),
@Ip varchar(32),
@Puerto varchar(32),
@conectado varchar(2)
AS

BEGIN
update Usuarios set Ip=@Ip,Puerto=@Puerto,conectado=@conectado where usuario=@usuario
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuarioStatusDesc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [dbo].[usuarioStatusDesc]
@Ip varchar(32),
@Puerto varchar(32),
@conectado varchar(2)
AS

BEGIN
update Usuarios set conectado=@conectado where Ip=@Ip and Puerto=@Puerto
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mostrarconectados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE PROCEDURE [dbo].[mostrarconectados]
AS


select usuario from Usuarios where conectado=1









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioDesconecto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






Create PROCEDURE [dbo].[UsuarioDesconecto]
@ip varchar(32),
@puerto varchar(32)
AS


select usuario from Usuarios where ip=@ip and puerto=@puerto' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegistrarUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




create PROCEDURE [dbo].[RegistrarUsuario]
@Usuario varchar(32),
@Ip varchar(32),
@Puerto varchar(32),
@conectado nchar(1),
@clave varchar(32)
AS

BEGIN
insert into Usuarios (Usuario,ip,puerto,conectado,clave) values(@Usuario,@Ip,@Puerto,@conectado,@clave)
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegistrarUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




create PROCEDURE [dbo].[RegistrarUser]
@Usuario varchar(32),
@Ip varchar(32),
@Puerto varchar(32),
@conectado nchar(1),
@clave varchar(32)
AS

BEGIN
insert into Usuarios (Usuario,ip,puerto,conectado,clave) values(@Usuario,@Ip,@Puerto,@conectado,@clave)
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mostrarNoconectados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






create PROCEDURE [dbo].[mostrarNoconectados]
AS
select usuario from Usuarios where conectado=0










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GuardaMsjeaTodos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'











CREATE PROCEDURE [dbo].[GuardaMsjeaTodos]
@msje varchar(1500)
AS

BEGIN
update Enviar set cadena=@msje,pendientes=''todos'' where identificador=1
update Enviar set cadena=@msje,pendientes=''todos'' where identificador=2
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GuardaMsjeaUno]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'











CREATE PROCEDURE [dbo].[GuardaMsjeaUno]
@usuarioD varchar(50),
@Msje varchar(1500)
AS

BEGIN
update Enviar set cadena=@Msje,Usuario=@usuarioD,pendientes=''uno'' where identificador=1
update Enviar set cadena=@Msje,Usuario=@usuarioD,pendientes=''uno'' where identificador=2
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GuardaMsje]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [dbo].[GuardaMsje]
@Mensaje varchar(32),
@Ip varchar(32),
@Puerto varchar(32),
@UsuarioA varchar(32),
@UsuarioB varchar(32),
@entreg int
AS

BEGIN
insert into Mensajes (texto,Ip,Puerto,UsuarioA,UsuarioB,entregado) values(@Mensaje,@Ip,@Puerto,@UsuarioA,@UsuarioB,@entreg)
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mensajespend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[mensajespend]
@user varchar(32)
AS


select texto from Mensajes where entregado=0 and usuarioB=@user' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [MSmerge_tr_alterschemaonly] on database for ALTER_FUNCTION, ALTER_PROCEDURE as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MSmerge_ddldispatcher @EventData, 3


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ENABLE TRIGGER [MSmerge_tr_alterschemaonly] ON DATABASE
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [MSmerge_tr_altertable] on database for ALTER_TABLE as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MSmerge_ddldispatcher @EventData, 1


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ENABLE TRIGGER [MSmerge_tr_altertable] ON DATABASE
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [MSmerge_tr_altertrigger] on database for ALTER_TRIGGER as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MSmerge_ddldispatcher @EventData, 4


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ENABLE TRIGGER [MSmerge_tr_altertrigger] ON DATABASE
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [MSmerge_tr_alterview] on database for ALTER_VIEW as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MSmerge_ddldispatcher @EventData, 2


GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ENABLE TRIGGER [MSmerge_tr_alterview] ON DATABASE
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[repl_identity_range_E7EC030C_1214_4549_9F0E_7055C810699B]') AND parent_object_id = OBJECT_ID(N'[dbo].[Mensajes]'))
ALTER TABLE [dbo].[Mensajes]  WITH NOCHECK ADD  CONSTRAINT [repl_identity_range_E7EC030C_1214_4549_9F0E_7055C810699B] CHECK NOT FOR REPLICATION (([i]>(783) AND [i]<=(1783) OR [i]>(1783) AND [i]<=(2783)))
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [repl_identity_range_E7EC030C_1214_4549_9F0E_7055C810699B]

INSERT INTO Enviar
           (identificador
           ,tipo
           ,cadena
           ,Usuario
           ,ip
           ,port
           ,mensaje
           ,pendientes)
     VALUES
           (1
           ,NULL
           ,'/des:test1:::FIN::::FIN::::FIN::'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,'nada');
INSERT INTO Enviar
           (identificador
           ,tipo
           ,cadena
           ,Usuario
           ,ip
           ,port
           ,mensaje
           ,pendientes)
     VALUES
           (2
           ,NULL
           ,'/des:test1:::FIN::::FIN::::FIN::'
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,'todos');
