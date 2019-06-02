-- Generado por Oracle SQL Developer Data Modeler 4.0.0.833
--   en:        2019-06-02 15:27:28 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g




CREATE TABLE Banco
  (
    id_banco NUMBER (4) NOT NULL ,
    nombre   VARCHAR2 (100) NOT NULL
  ) ;
ALTER TABLE Banco ADD CONSTRAINT Banco_PK PRIMARY KEY ( id_banco ) ;

CREATE TABLE Cliente
  (
    rut    VARCHAR2 (12) NOT NULL ,
    nombre VARCHAR2 (200) NOT NULL
  ) ;
ALTER TABLE Cliente ADD CONSTRAINT Cliente_PK PRIMARY KEY ( rut ) ;

CREATE TABLE Clientev1
  (
    rut        VARCHAR2 (12) NOT NULL ,
    nombre     VARCHAR2 (100) NOT NULL ,
    nacimiento DATE NOT NULL
  ) ;

CREATE TABLE Cuenta
  (
    id_cuenta NUMBER (6) NOT NULL ,
    fondos    NUMBER (10) NOT NULL ,
    id_tipo   NUMBER (1) NOT NULL ,
    id_banco  NUMBER (4) NOT NULL ,
    rut       VARCHAR2 (12) NOT NULL
  ) ;
ALTER TABLE Cuenta ADD CONSTRAINT Cuenta_PK PRIMARY KEY ( id_cuenta ) ;

CREATE TABLE MedioPago
  (
    id_medio NUMBER (1) NOT NULL ,
    nombre   VARCHAR2 (50) NOT NULL
  ) ;
ALTER TABLE MedioPago ADD CONSTRAINT MedioPago_PK PRIMARY KEY ( id_medio ) ;

CREATE TABLE TipoCuenta
  (
    id_tipo NUMBER (1) NOT NULL ,
    nombre  VARCHAR2 (50) NOT NULL
  ) ;
ALTER TABLE TipoCuenta ADD CONSTRAINT TipoCuenta_PK PRIMARY KEY ( id_tipo ) ;

CREATE TABLE Transaccion
  (
    id_transaccion NUMBER (6) NOT NULL ,
    monto          NUMBER (6) NOT NULL ,
    fecha          DATE NOT NULL ,
    id_medio       NUMBER (1) NOT NULL ,
    rut            VARCHAR2 (12) NOT NULL
  ) ;
ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_PK PRIMARY KEY ( id_transaccion ) ;

ALTER TABLE Cuenta ADD CONSTRAINT Cuenta_Banco_FK FOREIGN KEY ( id_banco ) REFERENCES Banco ( id_banco ) ;

ALTER TABLE Cuenta ADD CONSTRAINT Cuenta_Cliente_FK FOREIGN KEY ( rut ) REFERENCES Cliente ( rut ) ;

ALTER TABLE Cuenta ADD CONSTRAINT Cuenta_TipoCuenta_FK FOREIGN KEY ( id_tipo ) REFERENCES TipoCuenta ( id_tipo ) ;

ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_Cliente_FK FOREIGN KEY ( rut ) REFERENCES Cliente ( rut ) ;

ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_MedioPago_FK FOREIGN KEY ( id_medio ) REFERENCES MedioPago ( id_medio ) ;


-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             7
-- CREATE INDEX                             0
-- ALTER TABLE                             11
-- CREATE VIEW                              0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
