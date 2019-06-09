CREATE USER servidor_test_ok IDENTIFIED BY servidor123;
CREATE USER servidor_test_be IDENTIFIED BY servidor123;
CREATE USER servidor_test_tb IDENTIFIED BY servidor123;

GRANT CONNECT, RESOURCE, DBA TO servidor_test_ok;
GRANT CONNECT, RESOURCE, DBA TO servidor_test_be;
GRANT CONNECT, RESOURCE, DBA TO servidor_test_tb;