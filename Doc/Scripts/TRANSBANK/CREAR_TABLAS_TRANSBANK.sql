-- Generado por Oracle SQL Developer Data Modeler 4.0.0.833
--   en:        2019-05-24 19:52:56 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g




DROP TABLE Cliente CASCADE CONSTRAINTS ;

DROP TABLE MedioPago CASCADE CONSTRAINTS ;

DROP TABLE Transaccion CASCADE CONSTRAINTS ;

CREATE TABLE Cliente
  (
    rut    VARCHAR2 (12) NOT NULL ,
    nombre VARCHAR2 (200) NOT NULL
  ) ;
ALTER TABLE Cliente ADD CONSTRAINT Cliente_PK PRIMARY KEY ( rut ) ;

CREATE TABLE MedioPago
  (
    id_medio NUMBER (1) NOT NULL ,
    nombre   VARCHAR2 (50) NOT NULL
  ) ;
ALTER TABLE MedioPago ADD CONSTRAINT MedioPago_PK PRIMARY KEY ( id_medio ) ;

CREATE TABLE Transaccion
  (
    id      NUMBER (6) NOT NULL ,
    monto   NUMBER (6) NOT NULL ,
    fecha   DATE NOT NULL ,
    cliente VARCHAR2 (12) NOT NULL ,
    medio   NUMBER (1) NOT NULL
  ) ;
ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_PK PRIMARY KEY ( id ) ;

ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_Cliente_FK FOREIGN KEY ( cliente ) REFERENCES Cliente ( rut ) ;

ALTER TABLE Transaccion ADD CONSTRAINT Transaccion_MedioPago_FK FOREIGN KEY ( medio ) REFERENCES MedioPago ( id_medio ) ;


-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             3
-- CREATE INDEX                             0
-- ALTER TABLE                              5
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
