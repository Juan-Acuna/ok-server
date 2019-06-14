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

insert into estadosol values(1,'creada');
insert into ESTADOSOL values(2,'aprovada');
insert into estadosol values(3,'terminada');

commit

select * from usuario
SELECT * FROM Equipo 
