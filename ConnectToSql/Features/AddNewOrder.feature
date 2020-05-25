Feature: AddNewOrder
	In order to keep and manage order's data
	As a shop holder
	I want that buyer's orders data are updated in database

Scenario: Add order in DB
	When user with [ID=1] make a new order for amount 400
	Then the new row [1 | 400| Verona Lordic] should be created in DB

Scenario: Remove order from DB
	When user with [ID=3] deleted order for [amount=92]
	Then row [3	| 92 | Alex Shevko] should be removed from DB
