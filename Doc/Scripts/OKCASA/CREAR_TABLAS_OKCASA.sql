-- Generado por Oracle SQL Developer Data Modeler 4.0.0.833
--   en:        2019-05-24 18:49:12 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g




DROP TABLE Equipo CASCADE CONSTRAINTS ;

DROP TABLE EstadoSeg CASCADE CONSTRAINTS ;

DROP TABLE EstadoSol CASCADE CONSTRAINTS ;

DROP TABLE Factura CASCADE CONSTRAINTS ;

DROP TABLE Inspeccion CASCADE CONSTRAINTS ;

DROP TABLE Seguimiento CASCADE CONSTRAINTS ;

DROP TABLE Servicio CASCADE CONSTRAINTS ;

DROP TABLE Solicitud CASCADE CONSTRAINTS ;

DROP TABLE TipoPago CASCADE CONSTRAINTS ;

DROP TABLE TipoUsuario CASCADE CONSTRAINTS ;

DROP TABLE Usuario CASCADE CONSTRAINTS ;

CREATE TABLE Equipo
  (
    id_equipo  NUMBER (4) NOT NULL ,
    disponible CHAR (1) NOT NULL
  ) ;
ALTER TABLE Equipo ADD CONSTRAINT Equipo_PK PRIMARY KEY ( id_equipo ) ;

CREATE TABLE EstadoSeg
  (
    id_estado NUMBER (1) NOT NULL ,
    nombre    VARCHAR2 (20) NOT NULL
  ) ;
ALTER TABLE EstadoSeg ADD CONSTRAINT EstadoSeg_PK PRIMARY KEY ( id_estado ) ;

CREATE TABLE EstadoSol
  (
    id_estado NUMBER (1) NOT NULL ,
    nombre    VARCHAR2 (20) NOT NULL
  ) ;
ALTER TABLE EstadoSol ADD CONSTRAINT EstadoSol_PK PRIMARY KEY ( id_estado ) ;

CREATE TABLE Factura
  (
    id_factura    NUMBER (4) NOT NULL ,
    monto_factura NUMBER (6) NOT NULL ,
    fecha_emision DATE NOT NULL ,
    cuotas        NUMBER (2) ,
    id_solicitud  NUMBER (4) NOT NULL ,
    id_tipo       NUMBER (1) NOT NULL
  ) ;
CREATE UNIQUE INDEX Factura__IDX ON Factura
  (
    id_solicitud ASC
  )
  ;
  ALTER TABLE Factura ADD CONSTRAINT Factura_PK PRIMARY KEY ( id_factura ) ;

CREATE TABLE Inspeccion
  (
    id_inspeccion  NUMBER (4) NOT NULL ,
    fecha_visita   DATE NOT NULL ,
    observaciones  VARCHAR2 (500) NOT NULL ,
    seguimiento    NUMBER (4) NOT NULL ,
    id_seguimiento NUMBER (4) NOT NULL ,
    id_equipo      NUMBER (4) NOT NULL
  ) ;
ALTER TABLE Inspeccion ADD CONSTRAINT Inspeccion_PK PRIMARY KEY ( id_inspeccion, id_seguimiento ) ;

CREATE TABLE Seguimiento
  (
    id_seguimiento  NUMBER (4) NOT NULL ,
    inicio_servicio DATE NOT NULL ,
    fin_servicio    DATE ,
    numero_visitas  NUMBER (4) NOT NULL ,
    id_estado       NUMBER (1) NOT NULL ,
    id_solicitud    NUMBER (4) NOT NULL
  ) ;
CREATE UNIQUE INDEX Seguimiento__IDX ON Seguimiento
  (
    id_solicitud ASC
  )
  ;
  ALTER TABLE Seguimiento ADD CONSTRAINT Seguimiento_PK PRIMARY KEY ( id_seguimiento ) ;

CREATE TABLE Servicio
  (
    id_servicio NUMBER (1) NOT NULL ,
    nombre      VARCHAR2 (25) NOT NULL ,
    descripcion VARCHAR2 (200) NOT NULL ,
    costo       NUMBER (6) NOT NULL
  ) ;
ALTER TABLE Servicio ADD CONSTRAINT Servicio_PK PRIMARY KEY ( id_servicio ) ;

CREATE TABLE Solicitud
  (
    id_solicitud NUMBER (4) NOT NULL ,
    fecha_sol    DATE NOT NULL ,
    monto        NUMBER (6) NOT NULL ,
    direccion    VARCHAR2 (250) NOT NULL ,
    rut          VARCHAR2 (10) NOT NULL ,
    id_estado    NUMBER (1) NOT NULL ,
    id_servicio  NUMBER (1) NOT NULL
  ) ;
ALTER TABLE Solicitud ADD CONSTRAINT Solicitud_PK PRIMARY KEY ( id_solicitud ) ;

CREATE TABLE TipoPago
  (
    id_tipo NUMBER (1) NOT NULL ,
    nombre  VARCHAR2 (25) NOT NULL
  ) ;
ALTER TABLE TipoPago ADD CONSTRAINT TipoPago_PK PRIMARY KEY ( id_tipo ) ;

CREATE TABLE TipoUsuario
  (
    id_tipo     NUMBER (1) NOT NULL ,
    nombre_tipo VARCHAR2 (20) NOT NULL
  ) ;
ALTER TABLE TipoUsuario ADD CONSTRAINT TipoUsuario_PK PRIMARY KEY ( id_tipo ) ;

CREATE TABLE Usuario
  (
    rut       VARCHAR2 (10) NOT NULL ,
    nombre    VARCHAR2 (250) NOT NULL ,
    clave     VARCHAR2 (20) NOT NULL ,
    email     VARCHAR2 (25) NOT NULL ,
    fecha_nac DATE NOT NULL ,
    id_tipo   NUMBER (1) NOT NULL
  ) ;
ALTER TABLE Usuario ADD CONSTRAINT Usuario_PK PRIMARY KEY ( rut ) ;

ALTER TABLE Factura ADD CONSTRAINT Factura_Solicitud_FK FOREIGN KEY ( id_solicitud ) REFERENCES Solicitud ( id_solicitud ) ;

ALTER TABLE Factura ADD CONSTRAINT Factura_TipoPago_FK FOREIGN KEY ( id_tipo ) REFERENCES TipoPago ( id_tipo ) ;

ALTER TABLE Inspeccion ADD CONSTRAINT Inspeccion_Equipo_FK FOREIGN KEY ( id_equipo ) REFERENCES Equipo ( id_equipo ) ;

ALTER TABLE Inspeccion ADD CONSTRAINT Inspeccion_Seguimiento_FK FOREIGN KEY ( id_seguimiento ) REFERENCES Seguimiento ( id_seguimiento ) ;

ALTER TABLE Seguimiento ADD CONSTRAINT Seguimiento_EstadoSeg_FK FOREIGN KEY ( id_estado ) REFERENCES EstadoSeg ( id_estado ) ;

ALTER TABLE Seguimiento ADD CONSTRAINT Seguimiento_Solicitud_FK FOREIGN KEY ( id_solicitud ) REFERENCES Solicitud ( id_solicitud ) ;

ALTER TABLE Solicitud ADD CONSTRAINT Solicitud_EstadoSol_FK FOREIGN KEY ( id_estado ) REFERENCES EstadoSol ( id_estado ) ;

ALTER TABLE Solicitud ADD CONSTRAINT Solicitud_Servicio_FK FOREIGN KEY ( id_servicio ) REFERENCES Servicio ( id_servicio ) ;

ALTER TABLE Solicitud ADD CONSTRAINT Solicitud_Usuario_FK FOREIGN KEY ( rut ) REFERENCES Usuario ( rut ) ;

ALTER TABLE Usuario ADD CONSTRAINT Usuario_TipoUsuario_FK FOREIGN KEY ( id_tipo ) REFERENCES TipoUsuario ( id_tipo ) ;


-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            11
-- CREATE INDEX                             2
-- ALTER TABLE                             21
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
