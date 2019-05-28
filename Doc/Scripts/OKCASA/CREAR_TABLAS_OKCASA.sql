-- Generado por Oracle SQL Developer Data Modeler 18.3.0.268.1208
--   en:        2019-05-28 10:12:42 GMT-04:00
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g



CREATE TABLE equipo (
    id_equipo    NUMBER(4) NOT NULL,
    disponible   CHAR(1) NOT NULL
);

ALTER TABLE equipo ADD CONSTRAINT equipo_pk PRIMARY KEY ( id_equipo );

CREATE TABLE estadosol (
    id_estado   NUMBER(1) NOT NULL,
    nombre      VARCHAR2(20) NOT NULL
);

ALTER TABLE estadosol ADD CONSTRAINT estadosol_pk PRIMARY KEY ( id_estado );

CREATE TABLE inspeccion (
    id_inspeccion   NUMBER(4) NOT NULL,
    fecha_visita    DATE NOT NULL,
    observaciones   VARCHAR2(500) NOT NULL,
    monto           NUMBER(6) NOT NULL
);

ALTER TABLE inspeccion ADD CONSTRAINT inspeccion_pk PRIMARY KEY ( id_inspeccion );

CREATE TABLE servicio (
    id_servicio   NUMBER(1) NOT NULL,
    nombre        VARCHAR2(25) NOT NULL,
    descripcion   VARCHAR2(200) NOT NULL,
    costo         NUMBER(6) NOT NULL
);

ALTER TABLE servicio ADD CONSTRAINT servicio_pk PRIMARY KEY ( id_servicio );

CREATE TABLE solicitud (
    id_solicitud               NUMBER NOT NULL,
    direccion                  VARCHAR2(50) NOT NULL,
    creacion                   DATE NOT NULL,
    fin                        DATE,
    usuario                    VARCHAR2(10) NOT NULL,
    id_estado        		   NUMBER(1) NOT NULL,
    id_servicio       		   NUMBER(1) NOT NULL,
    id_equipo           	   NUMBER(4) NOT NULL,
    id_inspeccion   		   NUMBER(4) NOT NULL
);

CREATE UNIQUE INDEX solicitud__idx ON
    solicitud (
        id_inspeccion
    ASC );

ALTER TABLE solicitud ADD CONSTRAINT solicitud_pk PRIMARY KEY ( id_solicitud );

CREATE TABLE tipousuario (
    id_tipo       NUMBER(1) NOT NULL,
    nombre_tipo   VARCHAR2(20) NOT NULL
);

ALTER TABLE tipousuario ADD CONSTRAINT tipousuario_pk PRIMARY KEY ( id_tipo );

CREATE TABLE usuario (
    rut                   VARCHAR2(10) NOT NULL,
    nombre                VARCHAR2(250) NOT NULL,
    clave                 VARCHAR2(20) NOT NULL,
    email                 VARCHAR2(25) NOT NULL,
    fecha_nac             DATE NOT NULL,
    id_tipo   			  NUMBER(1) NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( rut );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_equipo_fk FOREIGN KEY ( id_equipo )
        REFERENCES equipo ( id_equipo );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_estadosol_fk FOREIGN KEY ( id_estado )
        REFERENCES estadosol ( id_estado );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_inspeccion_fk FOREIGN KEY ( id_inspeccion )
        REFERENCES inspeccion ( id_inspeccion );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_usuario_fk FOREIGN KEY ( usuario )
        REFERENCES usuario ( rut );

ALTER TABLE usuario
    ADD CONSTRAINT usuario_tipousuario_fk FOREIGN KEY ( id_tipo )
        REFERENCES tipousuario ( id_tipo );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_equipo_fk FOREIGN KEY ( id_equipo )
        REFERENCES equipo ( id_equipo );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_estadosol_fk FOREIGN KEY ( id_estado )
        REFERENCES estadosol ( id_estado );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_inspeccion_fk FOREIGN KEY ( id_inspeccion )
        REFERENCES inspeccion ( id_inspeccion );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_servicio_fk FOREIGN KEY ( id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE solicitud
    ADD CONSTRAINT solicitud_usuario_fk FOREIGN KEY ( usuario )
        REFERENCES usuario ( rut );

ALTER TABLE usuario
    ADD CONSTRAINT usuario_tipousuario_fk FOREIGN KEY ( id_tipo )
        REFERENCES tipousuario ( id_tipo );



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             7
-- CREATE INDEX                             1
-- ALTER TABLE                             19
-- CREATE VIEW                              0
-- ALTER VIEW                               0
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
-- CREATE MATERIALIZED VIEW LOG             0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
