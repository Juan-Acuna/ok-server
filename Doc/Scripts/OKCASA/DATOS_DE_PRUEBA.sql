insert into tipousuario values(1,'Cliente');
insert into tipousuario values(2,'Administrador');
insert into tipousuario values(3,'operario');

insert into usuario values('199159542','Juan','clave123','juan@gmail.com','09/08/1998',1);
insert into usuario values('199114846','Jose','clave123','jose@gmail.com','21/12/1998',2);
insert into usuario values('195464602','Joaquin','clave123','jqin@gmail.com','03/05/1998',3);
insert into usuario values('194545687','Javier','clave123','jvier@gmail.com','12/09/1998',1);

insert into equipo values(1,'Julio','1');
insert into equipo values(2,'raul','0');
insert into equipo values(3,'franco','1');

INSERT INTO ESTADOSOL VALUES(1,'Pendiente');
INSERT INTO ESTADOSOL VALUES(2,'Cancelado');
INSERT INTO ESTADOSOL VALUES(3,'Aprobado');
INSERT INTO ESTADOSOL VALUES(4,'En seguimiento');
INSERT INTO ESTADOSOL VALUES(5,'Finalizado');

INSERT INTO SERVICIO VALUES(1,'Verificaci�n instalaciones','Mediante la verificaci�n de instalaciones puedes ver si tu casa cumple los requerimientos arquitect�nicos prometidos, as� como los est�ndares de calidad y seguridad del mercado actual.',20000);
INSERT INTO SERVICIO VALUES(2,'Medici�n vivienda','La medici�n de vivienda te permite asegurar que tu casa cumple el tama�o prometido, as� como la estimaci�n de espacios disponibles para ti y tu familia.',20000);
INSERT INTO SERVICIO VALUES(3,'Inspecci�n Infraestructura','La inspeccion de infraestructura asegura que tu vivienda cumple todos los est�ndares de instalaci�n de luminaria, agua potable y tuber�as de gas, para que te sientas seguro en tu nuevo hogar.',20000);
INSERT INTO SERVICIO VALUES(4,'Termograf�a','A trav�s de la termograf�a prometemos comodidad , entregando espacios con una temperatura de acorde a las necesidades de ti y tus seres queridos, en todo momento.',20000);


COMMIT;