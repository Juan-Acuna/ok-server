SET SERVEROUTPUT ON;
DEFINE
  res BOOLEAN:=FAlSE;
  rol INTEGER:=0;
  msg VARCHAR2(100):='';
BEGIN
  SP_AUTENTICAR('199159542','sada',res,rol,msg);
  DBMS_OUTPUT.PUT_LINE('Rol: '||TO_CHAR(rol)||', Msg: '||msg);
EXCEPTION
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Rol: '||TO_CHAR(rol)||', Msg: '||msg);
END;



/*FINAL ---------------------------------------------------*/
CREATE OR REPLACE PROCEDURE sp_autenticar(usr IN VARCHAR2, pwd IN VARCHAR2, res OUT BOOLEAN, rol OUT INTEGER,msg OUT VARCHAR2) AS
  CURSOR c_auth IS SELECT clave, id_tipo from usuario WHERE rut=usr;
  v_clave USUARIO.clave%TYPE;
  v_rol USUARIO.id_tipo%TYPE;
BEGIN
  OPEN c_auth;
  LOOP
    FETCH c_auth INTO v_clave, v_rol;
    EXIT WHEN c_auth%NOTFOUND;
  END LOOP;
  CLOSE c_auth;
  IF v_clave IS NOT NULL THEN
    IF v_clave=pwd THEN
      res:=TRUE;
      rol:=v_rol;
    ELSE
      msg:='Contraseña incorrecta.';
    END IF;
  ELSE
    msg:='Usuario incorrecto.';
  END IF;
  DBMS_OUTPUT.PUT_LINE('Rut: '||usr||', Clave: '||v_clave||', Rol: '||TO_CHAR(v_rol)||', Msg: '||msg);
EXCEPTION
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('Rut: '||usr||', Clave: '||v_clave||', Rol: '||TO_CHAR(rol)||', Msg: '||msg);
END sp_autenticar;