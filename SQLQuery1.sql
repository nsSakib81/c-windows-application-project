/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [USERNAME]
      ,[PASS]
  FROM [BIBAHO_DB].[dbo].[LOGIN_TBL]

SELECT * FROM LOGIN_TBL;
insert into LOGIN_TBL values('saeedullah123@gmail.com','saeedullah');
insert into LOGIN_TBL values('sakib123@gmail.com','sakib123');

CREATE TABLE SIGNUP
(
FNAME VARCHAR(50) PRIMARY KEY NOT NULL,
LNAME VARCHAR(50) NOT NULL,
GENDER VARCHAR(50) NOT NULL,
EMAIL NVARCHAR(50) NOT NULL,
PROFESSION VARCHAR(50) NOT NULL,
CITY VARCHAR(50) NOT NULL,
MOBILE INT NOT NULL,
PASS NVARCHAR(50) NOT NULL,
);

SELECT * FROM SIGNUP;