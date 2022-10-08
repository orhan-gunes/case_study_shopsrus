# ShopsRUs Case Study

ShopsRUs Retail Store Discounts

ShopsRUs is an existing retail outlet. They would like to provide discount to their customers on all their web/mobile platforms. They require a set of APIs to be built that provide capabilities to calculate discounts, generate the total costs and generate the invoices for customers

The following discounts apply:
1.	If the user is an employee of the store, he gets a 30% discount
2.	If the user is an affiliate of the store, he gets a 10% discount
3.	If the user has been a customer for over 2 years, he gets a 5% discount.
4.	For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
5.	The percentage based discounts do not apply on groceries.
6.	A user can get only one of the percentage based discounts on a bill.

Write a program in a programming language of your choice with test cases such that given a bill, it finds the net payable amount. Create an RESTful API which when given a bill it returns the final invoice amount including the discount. Please note the stress is on object oriented approach and test coverage. User interface is not required. 

What we care about:

Required Activities
•	Very clear data model for customers, invoices and discounts
•	Object oriented programming approach, provide a high level UML class diagram of all the key classes in your solution. This can either be on paper or using a CASE tool
•	Unit tests to achieve good code coverage, good use of Mocking
•	Code to be generic and simple
•	Leverage today's best coding practices
•	Clear README.md that explains how the code and the test can be run and how the coverage reports can be generated
