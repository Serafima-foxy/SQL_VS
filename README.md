# SQL_VS
Connect Sql DB to VS

Connected SQL database Users_Orders to Visual Stidio 2019 and get result from request:

SELECT Persons.ID, FirstName, LastName, Age, City, OrderSum
FROM Persons
INNER JOIN Orders
ON Persons.ID=Orders.ID
