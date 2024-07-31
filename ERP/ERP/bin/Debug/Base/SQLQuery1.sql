-- Creación de las tablas de la base de datos de ERP

-- Tabla Bancos 
CREATE TABLE [dbo].[Bancos] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Banco]    NVARCHAR (255) NULL,
    [Filial]   NVARCHAR (255) NULL,
    [Telefono] NVARCHAR (255) NULL,
    [Email]    NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Clientes 
CREATE TABLE [dbo].[Clientes] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [CUIT]      VARCHAR (255) NULL,
    [Razon]     VARCHAR (255) NULL,
    [Contacto]  VARCHAR (255) NULL,
    [Cargo]     VARCHAR (255) NULL,
    [Direccion] VARCHAR (255) NULL,
    [Ciudad]    VARCHAR (255) NULL,
    [Provincia] VARCHAR (255) NULL,
    [Pais]      VARCHAR (255) NULL,
    [Telefono]  VARCHAR (255) NULL,
    [Email]     VARCHAR (255) NULL,
    [Internet]  VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla CuentaCorriente
CREATE TABLE [dbo].[CuentaCorriente] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Referencia]       VARCHAR (15)    NULL,
    [FechaIngreso]     DATETIME        NULL,
    [FechaVencimiento] DATETIME        NULL,
    [Entidad]          VARCHAR (255)   NULL,
    [Detalle]          VARCHAR (255)   NULL,
    [Ingreso]          DECIMAL (18, 2) NULL,
    [Egreso]           DECIMAL (18, 2) NULL,
    [Saldo]            DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Tabla FacturaA 
CREATE TABLE [dbo].[FacturaA] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [FacturaASerie] VARCHAR (10)    NULL,
    [Fecha]         DATETIME        NULL,
    [Vendedor]      VARCHAR (255)   NULL,
    [Razon]         VARCHAR (255)   NULL,
    [Direccion]     VARCHAR (255)   NULL,
    [TipoFactura]   VARCHAR (2)     NULL,
    [TipoIVA]       VARCHAR (20)    NULL,
    [CUIT]          VARCHAR (30)    NULL,
    [TipoPago]      VARCHAR (30)    NULL,
    [Remito]        VARCHAR (10)    NULL,
    [Codigo1]       VARCHAR (10)    NULL,
    [Descripcion1]  VARCHAR (255)   NULL,
    [Cantidad1]     INT             DEFAULT ((0)) NULL,
    [Unitario1]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe1]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo2]       VARCHAR (10)    NULL,
    [Descripcion2]  VARCHAR (255)   NULL,
    [Cantidad2]     INT             DEFAULT ((0)) NULL,
    [Unitario2]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe2]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo3]       VARCHAR (10)    NULL,
    [Descripcion3]  VARCHAR (255)   NULL,
    [Cantidad3]     INT             DEFAULT ((0)) NULL,
    [Unitario3]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe3]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo4]       VARCHAR (10)    NULL,
    [Descripcion4]  VARCHAR (255)   NULL,
    [Cantidad4]     INT             DEFAULT ((0)) NULL,
    [Unitario4]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe4]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo5]       VARCHAR (10)    NULL,
    [Descripcion5]  VARCHAR (255)   NULL,
    [Cantidad5]     INT             DEFAULT ((0)) NULL,
    [Unitario5]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe5]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Subtotal1]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Impuesto]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Subtotal2]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [IVAInscripto]  DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Total]         DECIMAL (18, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla FacturaB 
CREATE TABLE [dbo].[FacturaB] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [FacturaBSerie] VARCHAR (10)    NULL,
    [Fecha]         DATETIME        NULL,
    [Vendedor]      VARCHAR (255)   NULL,
    [Razon]         VARCHAR (255)   NULL,
    [Direccion]     VARCHAR (255)   NULL,
    [TipoFactura]   VARCHAR (2)     NULL,
    [CUIT]          VARCHAR (30)    NULL,
    [TipoIVA]       VARCHAR (20)    NULL,
    [TipoPago]      VARCHAR (30)    NULL,
    [Remito]        VARCHAR (20)    NULL,
    [Codigo1]       VARCHAR (10)    NULL,
    [Descripcion1]  VARCHAR (255)   NULL,
    [Cantidad1]     INT             DEFAULT ((0)) NULL,
    [Unitario1]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe1]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo2]       VARCHAR (10)    NULL,
    [Descripcion2]  VARCHAR (255)   NULL,
    [Cantidad2]     INT             DEFAULT ((0)) NULL,
    [Unitario2]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe2]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo3]       VARCHAR (10)    NULL,
    [Descripcion3]  VARCHAR (255)   NULL,
    [Cantidad3]     INT             DEFAULT ((0)) NULL,
    [Unitario3]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe3]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo4]       VARCHAR (10)    NULL,
    [Descripcion4]  VARCHAR (255)   NULL,
    [Cantidad4]     INT             DEFAULT ((0)) NULL,
    [Unitario4]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe4]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Codigo5]       VARCHAR (10)    NULL,
    [Descripcion5]  VARCHAR (255)   NULL,
    [Cantidad5]     INT             DEFAULT ((0)) NULL,
    [Unitario5]     DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Importe5]      DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Total]         DECIMAL (18, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla FacturaSeriales
CREATE TABLE [dbo].[FacturaSeriales] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [SerieA] INT DEFAULT ((0)) NULL,
    [SerieB] INT DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Fiscal 
CREATE TABLE [dbo].[Fiscal] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [IVA]      VARCHAR (15)    NULL,
    [Alicuota] DECIMAL (11, 2) DEFAULT ((0)) NULL,
    [Impuesto] DECIMAL (11, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Logon 
CREATE TABLE [dbo].[Logon] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (16) NULL,
    [UserPass]  VARCHAR (16) NULL,
    [Privilege] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Productos 
CREATE TABLE [dbo].[Productos] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [CodigoBarra]   NVARCHAR (255)  NULL,
    [CodigoInterno] NVARCHAR (255)  NULL,
    [Producto]      NVARCHAR (255)  NULL,
    [Detalle]       NVARCHAR (255)  NULL,
    [Entrada]       INT             NULL,
    [Salida]        INT             NULL,
    [Existencia]    INT             NULL,
    [Costo]         DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Proveedores 
CREATE TABLE [dbo].[Proveedores] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [CUIT]      VARCHAR (255) NULL,
    [Razon]     VARCHAR (255) NULL,
    [Contacto]  VARCHAR (255) NULL,
    [Cargo]     VARCHAR (255) NULL,
    [Direccion] VARCHAR (255) NULL,
    [Ciudad]    VARCHAR (255) NULL,
    [Provincia] VARCHAR (255) NULL,
    [Pais]      VARCHAR (255) NULL,
    [Telefono]  VARCHAR (255) NULL,
    [Email]     VARCHAR (255) NULL,
    [Internet]  VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla Vendedores 
CREATE TABLE [dbo].[Vendedores] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Vendedor] VARCHAR (255) NULL,
    [Telefono] VARCHAR (255) NULL,
    [Email]    VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Creación de los Procedimientos Almaceados 

-- Procedure Bancos_CRUD 
CREATE PROCEDURE [dbo].[Bancos_CRUD]
	@operation varchar(15) = '',
	@id int  = 0, 
	@banco varchar(255) = '', 
	@filial varchar(255) = '', 
	@telefono varchar(255) = '', 
	@email varchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, Banco, Filial, Telefono, Email 
		FROM Bancos 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Bancos (Banco, Filial, Telefono, Email) 
		VALUES (@banco, @filial, @telefono, @email)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Bancos 
		SET Banco = @banco, Filial = @filial, Telefono = @telefono, Email = @email  
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Bancos 
		WHERE Id = @id
	END
END; 
GO

-- Procedure Clientes_CRUD 
CREATE PROCEDURE [dbo].[Clientes_CRUD]
	@operation varchar(15) = '',
	@id int  = 0, 
	@cuit varchar(255) = '',
	@razon varchar(255) = '', 
	@contacto varchar(255) = '', 
	@cargo varchar(255) = '', 
	@direccion varchar(255) = '', 
	@ciudad varchar(255) = '', 
	@provincia varchar(255) = '', 
	@pais varchar(255) = '', 
	@telefono varchar(255) = '', 
	@email varchar(255) = '', 
	@internet varchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, CUIT, Razon, Contacto, Cargo, Direccion, Ciudad, Provincia, 
		Pais, Telefono, Email, Internet 
		FROM Clientes 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Clientes (CUIT, Razon, Contacto, Cargo, Direccion, Ciudad, 
		Provincia, Pais, Telefono, Email, Internet) 
		VALUES (@cuit, @razon, @contacto, @cargo, @direccion, @ciudad, @provincia, 
		@pais, @telefono, @email, @internet)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Clientes 
		SET CUIT = @cuit, Razon = @razon, Contacto = @contacto, Cargo = @cargo, Direccion = @direccion, 
		Ciudad = @ciudad, Provincia = @provincia, Pais = @pais, Telefono = @telefono, 
		Email = @email, Internet = @internet 
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Clientes 
		WHERE Id = @id
	END
END;
GO

-- Procedure FacturaA_CRUD 
CREATE PROCEDURE [dbo].[FacturaA_CRUD]
	@operation varchar(15) = '',
	@id int = 0, 
	@facturaaserie varchar(10) = '', 
	@fecha datetime = null, 
	@vendedor varchar(255) = '',
	@razon varchar(255) = '',
	@direccion varchar(255) = '',
	@tipofactura varchar(2) = '', 
	@tipoiva varchar(255) = '', 
	@cuit varchar(255) = '', 
	@tipopago varchar(255) = '',
	@remito varchar(255) = '',
	@codigo1 varchar(255) = '', 
	@descripcion1 varchar(255) = '',
	@cantidad1 int = 0,
	@unitario1 decimal(18,2) = 0,
	@importe1 decimal(18,2) = 0, 
	@codigo2 varchar(255) = '', 
	@descripcion2 varchar(255) = '',
	@cantidad2 int = 0,
	@unitario2 decimal(18,2) = 0,
	@importe2 decimal(18,2) = 0,
	@codigo3 varchar(255) = '', 
	@descripcion3 varchar(255) = '',
	@cantidad3 int = 0,
	@unitario3 decimal(18,2) = 0,
	@importe3 decimal(18,2) = 0,
	@codigo4 varchar(255) = '', 
	@descripcion4 varchar(255) = '',
	@cantidad4 int = 0,
	@unitario4 decimal(18,2) = 0,
	@importe4 decimal(18,2) = 0,
	@codigo5 varchar(255) = '', 
	@descripcion5 varchar(255) = '',
	@cantidad5 int = 0,
	@unitario5 decimal(18,2) = 0,
	@importe5 decimal(18,2) = 0,
	@subtotal1 decimal(18,2) = 0,
	@impuesto decimal(18,2) = 0,
	@subtotal2 decimal(18,2) = 0,
	@ivainscripto decimal(18,2) = 0, 
	@total decimal(18,2) = 0
	
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, Vendedor, FacturaASerie, Fecha, Razon, 
		Direccion, TipoFactura, TipoIVA, CUIT, TipoPago, Remito, 
		Codigo1, Descripcion1, Cantidad1, Unitario1, Importe1, 
		Codigo2, Descripcion2, Cantidad2, Unitario2, Importe2, 
		Codigo3, Descripcion3, Cantidad3, Unitario3, Importe3, 
		Codigo4, Descripcion4, Cantidad4, Unitario4, Importe4, 
		Codigo5, Descripcion5, Cantidad5, Unitario5, Importe5, 
		Subtotal1, Impuesto, Subtotal2, IVAInscripto, Total 
		FROM FacturaA
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		BEGIN TRY
			-- Actualizar Serial de la Factura A.
			UPDATE FacturaSeriales  
			SET SerieA = (SerieA + 1)
			WHERE Id = 1; 

			-- Ingresar Nueva Factura A.
			INSERT INTO FacturaA (FacturaASerie, Fecha, Vendedor, Razon, 
			Direccion, TipoFactura, TipoIVA, CUIT, TipoPago, Remito, 
			Codigo1, Descripcion1, Cantidad1, Unitario1, Importe1, 
			Codigo2, Descripcion2, Cantidad2, Unitario2, Importe2, 
			Codigo3, Descripcion3, Cantidad3, Unitario3, Importe3, 
			Codigo4, Descripcion4, Cantidad4, Unitario4, Importe4, 
			Codigo5, Descripcion5, Cantidad5, Unitario5, Importe5, 
			Subtotal1, Impuesto, Subtotal2, IVAInscripto, Total ) 
			VALUES (@facturaaserie, @fecha, @vendedor, @razon,	@direccion,	@tipofactura, 
			@tipoiva, @cuit, @tipopago,@remito, 	@codigo1, @descripcion1, @cantidad1, 
			@unitario1,	@importe1, @codigo2, @descripcion2, @cantidad2,	@unitario2,	
			@importe2, @codigo3, @descripcion3, @cantidad3, @unitario3, @importe3, 
			@codigo4, @descripcion4, @cantidad4, @unitario4, @importe4, @codigo5, 
			@descripcion5, @cantidad5, @unitario5, @importe5, @subtotal1, @impuesto, 
			@subtotal2, @ivainscripto, @total);
		END TRY
		BEGIN CATCH
			-- No hacer nada si existe un error.
		END CATCH
	END
END;
GO

-- Procedure FacturaB_CRUD
CREATE PROCEDURE [dbo].[FacturaB_CRUD]
	@operation varchar(15) = '',
	@id int = 0, 
	@facturabserie varchar(10) = '', 
	@fecha datetime = null, 
	@vendedor varchar(255) = '',
	@razon varchar(255) = '',
	@direccion varchar(255) = '',
	@tipofactura varchar(2) = '', 
	@tipoiva varchar(255) = '', 
	@cuit varchar(255) = '', 
	@tipopago varchar(255) = '',
	@remito varchar(255) = '',
	@codigo1 varchar(255) = '', 
	@descripcion1 varchar(255) = '',
	@cantidad1 int = 0,
	@unitario1 decimal(18,2) = 0,
	@importe1 decimal(18,2) = 0, 
	@codigo2 varchar(255) = '', 
	@descripcion2 varchar(255) = '',
	@cantidad2 int = 0,
	@unitario2 decimal(18,2) = 0,
	@importe2 decimal(18,2) = 0,
	@codigo3 varchar(255) = '', 
	@descripcion3 varchar(255) = '',
	@cantidad3 int = 0,
	@unitario3 decimal(18,2) = 0,
	@importe3 decimal(18,2) = 0,
	@codigo4 varchar(255) = '', 
	@descripcion4 varchar(255) = '',
	@cantidad4 int = 0,
	@unitario4 decimal(18,2) = 0,
	@importe4 decimal(18,2) = 0,
	@codigo5 varchar(255) = '', 
	@descripcion5 varchar(255) = '',
	@cantidad5 int = 0,
	@unitario5 decimal(18,2) = 0,
	@importe5 decimal(18,2) = 0,
	@total decimal(18,2) = 0
	
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, Vendedor, FacturaBSerie, Fecha, Razon, 
		Direccion, TipoFactura, TipoIVA, CUIT, TipoPago, Remito, 
		Codigo1, Descripcion1, Cantidad1, Unitario1, Importe1, 
		Codigo2, Descripcion2, Cantidad2, Unitario2, Importe2, 
		Codigo3, Descripcion3, Cantidad3, Unitario3, Importe3, 
		Codigo4, Descripcion4, Cantidad4, Unitario4, Importe4, 
		Codigo5, Descripcion5, Cantidad5, Unitario5, Importe5, 
		Total 
		FROM FacturaB
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		BEGIN TRY
			-- Actualizar Serial de la Factura B.
			UPDATE FacturaSeriales  
			SET SerieB = (SerieB + 1)
			WHERE Id = 1; 

			-- Ingresar Nueva Factura B.
			INSERT INTO FacturaB (FacturaBSerie, Fecha, Vendedor, Razon, 
			Direccion, TipoFactura, TipoIVA, CUIT, TipoPago, Remito, 
			Codigo1, Descripcion1, Cantidad1, Unitario1, Importe1, 
			Codigo2, Descripcion2, Cantidad2, Unitario2, Importe2, 
			Codigo3, Descripcion3, Cantidad3, Unitario3, Importe3, 
			Codigo4, Descripcion4, Cantidad4, Unitario4, Importe4, 
			Codigo5, Descripcion5, Cantidad5, Unitario5, Importe5, 
			Total ) 
			VALUES (@facturabserie, @fecha, @vendedor, @razon,	@direccion,	@tipofactura, 
			@tipoiva, @cuit, @tipopago,@remito, 	@codigo1, @descripcion1, @cantidad1, 
			@unitario1,	@importe1, @codigo2, @descripcion2, @cantidad2,	@unitario2,	
			@importe2, @codigo3, @descripcion3, @cantidad3, @unitario3, @importe3, 
			@codigo4, @descripcion4, @cantidad4, @unitario4, @importe4, @codigo5, 
			@descripcion5, @cantidad5, @unitario5, @importe5, @total);
		END TRY
		BEGIN CATCH
			-- No hacer nada si existe un error.
		END CATCH
	END
END;
GO

-- Procedure FacturaSeriales_CRUD
CREATE PROCEDURE [dbo].[FacturaSeriales_CRUD]
	@operation varchar(15) = '',
	@id int = 0, 
	@seriea int = 0, 
	@serieb int = 0
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, SerieA, SerieB 
		FROM FacturaSeriales 
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE FacturaSeriales  
		SET SerieA = @seriea, SerieB = @serieb    
		WHERE Id = @id 
	END
END;
GO

-- Procedure Fiscal_CRUD 
CREATE PROCEDURE [dbo].[Fiscal_CRUD]
	@operation varchar(15) = '',
	@id int  = 0, 
	@iva varchar(15) = '', 
	@alicuota decimal(11,2) = 0, 
	@impuesto decimal(11,2) = 0
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, IVA, Alicuota, Impuesto 
		FROM Fiscal 
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Fiscal 
		SET IVA = @iva, Alicuota = @alicuota, Impuesto = @impuesto   
		WHERE Id = @id 
	END
END;
GO

-- Procedure Logon_CRUD 
CREATE PROCEDURE [dbo].[Logon_CRUD]
	@operation varchar(15) = '',
	@id int = 0, 
	@username varchar(255) = '', 
	@userpass varchar(255) = '', 
	@privilege int = 0
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, UserName, UserPass, Privilege 
		FROM Logon 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Logon (UserName, UserPass, Privilege) 
		VALUES (@username, @userpass, @privilege)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Logon 
		SET UserName = @username, UserPass = @userpass, Privilege = @privilege  
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Logon 
		WHERE Id = @id
	END
END; 
GO

-- Procedure Productos_CRUD 
CREATE PROCEDURE [dbo].[Productos_CRUD]
	@operation varchar(15) = '',
	@id int = 0, 
	@codigobarra varchar(255) = '', 
	@codigointerno varchar(255) = '', 
	@producto varchar(255) = '', 
	@detalle varchar(255) = '', 
	@entrada int = 0, 
	@salida int = 0, 
	@existencia int = 0, 
	@costo decimal(18,2) = 0
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT' 
	BEGIN
		SELECT Id, CodigoBarra, CodigoInterno, Producto, Detalle, 
		Entrada, Salida, Existencia, Costo 
		FROM Productos 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Productos (CodigoBarra, CodigoInterno, Producto, Detalle,  
		Entrada, Salida, Existencia, Costo) 
		VALUES (@codigobarra, @codigointerno, @producto, @detalle, 
		@entrada, @salida, @existencia, @costo)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Productos  
		SET CodigoBarra = @codigobarra, CodigoInterno = @codigointerno, 
		Producto = @producto, Detalle = @detalle, 
		Entrada = @entrada, Salida = @salida, Existencia = @existencia, 
		Costo = @costo  
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Productos  
		WHERE Id = @id
	END
END; 
GO

-- Procedure ProveedoresCRUD 
CREATE PROCEDURE [dbo].[Proveedores_CRUD]
	@operation varchar(15) = '',
	@id int  = 0, 
	@cuit varchar(255) = '', 
	@razon varchar(255) = '', 
	@contacto varchar(255) = '', 
	@cargo varchar(255) = '', 
	@direccion varchar(255) = '', 
	@ciudad varchar(255) = '', 
	@provincia varchar(255) = '', 
	@pais varchar(255) = '', 
	@telefono varchar(255) = '', 
	@email varchar(255) = '', 
	@internet varchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, CUIT, Razon, Contacto, Cargo, Direccion, Ciudad, Provincia, 
		Pais, Telefono, Email, Internet 
		FROM Proveedores 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Proveedores (CUIT, Razon, Contacto, Cargo, Direccion, Ciudad, 
		Provincia, Pais, Telefono, Email, Internet) 
		VALUES (@cuit, @razon, @contacto, @cargo, @direccion, @ciudad, @provincia, 
		@pais, @telefono, @email, @internet)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Proveedores 
		SET CUIT = @cuit, Razon = @razon, Contacto = @contacto, Cargo = @cargo, Direccion = @direccion, 
		Ciudad = @ciudad, Provincia = @provincia, Pais = @pais, Telefono = @telefono, 
		Email = @email, Internet = @internet 
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Proveedores 
		WHERE Id = @id
	END
END; 
GO

-- Procedure Vendedores_CRUD 
CREATE PROCEDURE [dbo].[Vendedores_CRUD]
	@operation varchar(15) = '',
	@id int  = 0, 
	@vendedor varchar(255) = '', 
	@telefono varchar(255) = '', 
	@email varchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		SELECT Id, Vendedor, Telefono, Email 
		FROM Vendedores 
	END

	--INSERT
    IF @operation = 'INSERT'
	BEGIN
		INSERT INTO Vendedores (Vendedor, Telefono, Email) 
		VALUES (@vendedor, @telefono, @email)
	END

	--UPDATE
    IF @operation = 'UPDATE'
	BEGIN
		UPDATE Vendedores 
		SET Vendedor = @vendedor, Telefono = @telefono, Email = @email 
		WHERE Id = @id 
	END

	--DELETE
    IF @operation = 'DELETE'
	BEGIN
		DELETE FROM Vendedores 
		WHERE Id = @id
	END
END; 
GO

-- Procedure Ventas_CRUD 
CREATE PROCEDURE [dbo].[Ventas_CRUD]
	@operation varchar(15) = ''

AS
BEGIN
	SET NOCOUNT ON;

	--SELECT
    IF @operation = 'SELECT'
	BEGIN
		---- Calcular Ventas de la Factua A y B por Vendedor.
		SELECT 
			DISTINCT fa.Vendedor, 'Factura A' AS Factura, 
			SUM(fa.Total) AS Total FROM FacturaA fa
			GROUP BY fa.Vendedor    
		UNION ALL
		SELECT 
			DISTINCT fb.Vendedor, 'Factura B' AS Factura, 
			SUM(fb.Total) AS Total FROM FacturaB fb 
			GROUP BY fb.Vendedor; 
	END
END;
GO 

-- Ingreso de Valores Predeterminados 

-- Ingresar Bancos 
INSERT INTO [dbo].[Bancos] ([Banco], [Filial], [Telefono], [Email]) VALUES (N'SUPERVIELLE', N'CABA', N'22-3344-5566', N'info@supervielle.com.ar')
GO 

-- Ingresar Clientes 
INSERT INTO [dbo].[Clientes] ([CUIT], [Razon], [Contacto], [Cargo], [Direccion], [Ciudad], [Provincia], [Pais], [Telefono], [Email], [Internet]) VALUES (N'20206331224', N'DON SATUR', N'Alberto', N'Jefe Compras', N'Av. Solaris 1234', N'Bellavista', N'Buenos Aires', N'Argentina', N'', N'', N'')
INSERT INTO [dbo].[Clientes] ([CUIT], [Razon], [Contacto], [Cargo], [Direccion], [Ciudad], [Provincia], [Pais], [Telefono], [Email], [Internet]) VALUES (N'1919445113', N'TRX SA', N'Ana y Jorge', N'Jefes', N'San Juan 44', N'CABA', N'Buenos Aires', N'Argentina', N'15-4452-4411', N'', N'')
GO 

-- Insertar FacturaA 
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'579', N'2018-10-28 00:00:00', N'José Álvarez', N'TRX SA', N'San Juan 44 CABA Buenos Aires Tel: 15-4452-4411', N'FA', N'', N'1919445113', N'FA', NULL, N'GC888', N'Galletitas de Chocolate', 2, CAST(22.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), N'GC777', N'Galletitas Dulces de Vainilla', 1, CAST(46.00 AS Decimal(18, 2)), CAST(46.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(89.56 AS Decimal(18, 2)), CAST(5.37 AS Decimal(18, 2)), CAST(94.93 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(112.02 AS Decimal(18, 2)))
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'580', N'2018-10-28 00:00:00', N'José Álvarez', N'TRX SA', N'San Juan 44 CABA Buenos Aires Tel: 15-4452-4411', N'FA', N'', N'1919445113', N'FA', NULL, N'GC888', N'Galletitas de Chocolate', 2, CAST(22.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), N'GC777', N'Galletitas Dulces de Vainilla', 1, CAST(46.00 AS Decimal(18, 2)), CAST(46.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(89.56 AS Decimal(18, 2)), CAST(5.37 AS Decimal(18, 2)), CAST(94.93 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(112.02 AS Decimal(18, 2)))
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'581', N'2018-10-28 00:00:00', N'Anabella Gutierrez', N'DON SATUR', N'Av. Solaris 1234 Bellavista Buenos Aires', N'FA', N'', N'20206331224', N'FA', NULL, N'GC777', N'Galletitas Dulces de Vainilla', 5, CAST(46.00 AS Decimal(18, 2)), CAST(228.00 AS Decimal(18, 2)), N'GC888', N'Galletitas de Chocolate', 8, CAST(22.00 AS Decimal(18, 2)), CAST(176.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(403.80 AS Decimal(18, 2)), CAST(24.23 AS Decimal(18, 2)), CAST(428.03 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(505.07 AS Decimal(18, 2)))
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'582', N'2018-10-28 00:00:00', N'José Álvarez', N'TRX SA', N'San Juan 44 CABA Buenos Aires Tel: 15-4452-4411', N'FA', N'', N'1919445113', N'FA', N'', N'GC888', N'Galletitas de Chocolate', 8, CAST(22.00 AS Decimal(18, 2)), CAST(176.00 AS Decimal(18, 2)), N'GC777', N'Galletitas Dulces de Vainilla', 12, CAST(46.00 AS Decimal(18, 2)), CAST(547.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(722.72 AS Decimal(18, 2)), CAST(43.36 AS Decimal(18, 2)), CAST(766.08 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(903.98 AS Decimal(18, 2)))
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'583', N'2018-10-28 00:00:00', N'Anabella Gutierrez', N'TRX SA', N'San Juan 44 CABA Buenos Aires Tel: 15-4452-4411', N'FA', N'', N'1919445113', N'FA', N'4567', N'GC888', N'Galletitas de Chocolate', 8, CAST(22.00 AS Decimal(18, 2)), CAST(176.00 AS Decimal(18, 2)), N'GC777', N'Galletitas Dulces de Vainilla', 15, CAST(46.00 AS Decimal(18, 2)), CAST(683.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(859.40 AS Decimal(18, 2)), CAST(51.56 AS Decimal(18, 2)), CAST(910.96 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1074.94 AS Decimal(18, 2)))
INSERT INTO [dbo].[FacturaA] ([FacturaASerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [TipoIVA], [CUIT], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Subtotal1], [Impuesto], [Subtotal2], [IVAInscripto], [Total]) VALUES (N'586', N'2018-11-02 00:00:00', N'José Álvarez', N'DON SATUR', N'Av. Solaris 1234 Bellavista Buenos Aires', N'FA', N'', N'20206331224', N'FA', N'4567', N'GC888', N'Galletitas de Chocolate', 5, CAST(22.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(6.60 AS Decimal(18, 2)), CAST(116.60 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(137.59 AS Decimal(18, 2)))
GO 

-- Insertar FacturaB 
INSERT INTO [dbo].[FacturaB] ([FacturaBSerie], [Fecha], [Vendedor], [Razon], [Direccion], [TipoFactura], [CUIT], [TipoIVA], [TipoPago], [Remito], [Codigo1], [Descripcion1], [Cantidad1], [Unitario1], [Importe1], [Codigo2], [Descripcion2], [Cantidad2], [Unitario2], [Importe2], [Codigo3], [Descripcion3], [Cantidad3], [Unitario3], [Importe3], [Codigo4], [Descripcion4], [Cantidad4], [Unitario4], [Importe4], [Codigo5], [Descripcion5], [Cantidad5], [Unitario5], [Importe5], [Total]) VALUES (N'', N'2018-10-31 00:00:00', N'José Álvarez', N'TRX SA', N'San Juan 44 CABA Buenos Aires Tel: 15-4452-4411', N'FA', N'1919445113', N'', N'FA', N'', N'GC888', N'Galletitas de Chocolate', 4, CAST(27.00 AS Decimal(18, 2)), CAST(106.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'', N'', 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(106.48 AS Decimal(18, 2)))
GO 

-- Insertar FacturaSeriales 
INSERT INTO [dbo].[FacturaSeriales] ([SerieA], [SerieB]) VALUES (586, 2)
GO 

-- Insertar Fiscal 
INSERT INTO [dbo].[Fiscal] ([IVA], [Alicuota], [Impuesto]) VALUES (N'RI', CAST(18.00 AS Decimal(11, 2)), CAST(6.00 AS Decimal(11, 2)))
INSERT INTO [dbo].[Fiscal] ([IVA], [Alicuota], [Impuesto]) VALUES (N'RNI', CAST(18.00 AS Decimal(11, 2)), CAST(8.00 AS Decimal(11, 2)))
INSERT INTO [dbo].[Fiscal] ([IVA], [Alicuota], [Impuesto]) VALUES (N'CF', CAST(21.00 AS Decimal(11, 2)), CAST(0.00 AS Decimal(11, 2)))
GO 

-- Insertar Logon 
INSERT INTO [dbo].[Logon] ([UserName], [UserPass], [Privilege]) VALUES (N'admin', N'1234', 1)
GO 

-- Insertar Productos 
INSERT INTO [dbo].[Productos] ([CodigoBarra], [CodigoInterno], [Producto], [Detalle], [Entrada], [Salida], [Existencia], [Costo]) VALUES (N'777', N'GC777', N'Galletitas', N'Galletitas Dulces de Vainilla', 80, 0, 80, CAST(45.56 AS Decimal(18, 2)))
INSERT INTO [dbo].[Productos] ([CodigoBarra], [CodigoInterno], [Producto], [Detalle], [Entrada], [Salida], [Existencia], [Costo]) VALUES (N'888', N'GC888', N'Chocolinas', N'Galletitas de Chocolate', 75, 0, 75, CAST(22.00 AS Decimal(18, 2)))
GO 

-- Insertar Proveedores 
INSERT INTO [dbo].[Proveedores] ([CUIT], [Razon], [Contacto], [Cargo], [Direccion], [Ciudad], [Provincia], [Pais], [Telefono], [Email], [Internet]) VALUES (N'2121332991', N'SEMILLA SA', N'Verónica', N'Jefa de Ventas', N'Av. Directorio 3412', N'CABA', N'Buenos Aires', N'Argentina', N'11-2233-4421', N'ventas@semilla.com.ar', N'semilla.com.ar')
GO 

-- Insertar Vendedores 
INSERT INTO [dbo].[Vendedores] ([Vendedor], [Telefono], [Email]) VALUES (N'Anabella Gutierrez', N'11-2211-3322', N'anabellagutierrez@gmail.com')
INSERT INTO [dbo].[Vendedores] ([Vendedor], [Telefono], [Email]) VALUES (N'José Álvarez', N'11-5641-8813', N'josealva1980@hotmail.com')
GO 