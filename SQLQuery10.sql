SELECT * FROM SIGNUP;
SELECT * FROM LOGIN_TBL;
SELECT * FROM ADMIN_LOGIN_TBL;
SELECT * FROM USER_DETAILS_TBL;

ALTER TABLE SIGNUP2
ADD PICTURE IMAGE;



CREATE TABLE ADMIN_LOGIN_TBL
(
USERNAME VARCHAR(50) NOT NULL,
PASS NVARCHAR(50) NOT NULL
);
SELECT * FROM ADMIN_LOGIN_TBL;
insert into ADMIN_LOGIN_TBL values('admin1@gmail.com','admin1');

CREATE TABLE USER_DETAILS_TBL
(
ID INT PRIMARY KEY,
NAME VARCHAR(50),
AGE INT,
PICTURE IMAGE,
HEIGHT FLOAT,
CITY VARCHAR(50),
INTEREST VARCHAR(50),
PROFESSION VARCHAR(50),
);

CREATE TABLE SIGNUP2
(
ID INT PRIMARY KEY,
NAME VARCHAR(50) NOT NULL,
AGE INT NOT NULL,
GENDER VARCHAR(50) NOT NULL,
EMAIL NVARCHAR(50) NOT NULL,
PROFESSION VARCHAR(50) NOT NULL,
INTEREST VARCHAR(50) NOT NULL,
CITY VARCHAR(50) NOT NULL,
HEIGHT INT NOT NULL,
PASS NVARCHAR(50) NOT NULL
);
SELECT * FROM SIGNUP2;


ALTER TABLE SIGNUP2
DROP COLUMN PICTURE;


CREATE TABLE SIGNUP3
(
ID INT PRIMARY KEY,
NAME VARCHAR(50) NOT NULL,
AGE INT NOT NULL,
GENDER VARCHAR(50) NOT NULL,
EMAIL NVARCHAR(50) NOT NULL,
PROFESSION VARCHAR(50) NOT NULL,
INTEREST VARCHAR(50) NOT NULL,
CITY VARCHAR(50) NOT NULL,
HEIGHT INT NOT NULL,
PASS NVARCHAR(50) NOT NULL,
PICTURE IMAGE NOT NULL
);
SELECT * FROM SIGNUP3;


SELECT * FROM USER_DETAILS_TBL;
ALTER TABLE USER_DETAILS_TBL
ADD EMAIL NVARCHAR(50);