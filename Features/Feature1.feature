Feature: Testing Functionality of Swag Labs site


Background:
	Given user navigates to the url

Scenario: Verifying HomePage is displayed

	Then verify whether the home page is displayed with title "Swag Labs"

Scenario Outline: Testing Swag Labs Login

	When User enters username "<User Name>" and password "<Password>"
	Then verify the user is logged in successfully

Examples:

	| User Name     | Password     |
	| standard_user | secret_sauce |
	| standard_user | secretsauce  |

Scenario: Testing Products Dropdown

	When User enters username "standard_user" and password "secret_sauce"
	And user selects first product before changing dropdown
	And user changes the dropdown
	And user selects first product after changing dropdown
	Then verify dropdown is working properly

Scenario: Testing Logout functionality

	When User enters username "standard_user" and password "secret_sauce"
	Then verify the user is logged in successfully
	And User click on Logout
	Then verify user logged out successfully

Scenario: Testing Purchasing Product Functionality

	When User enters username "standard_user" and password "secret_sauce"
	Then verify the user is logged in successfully
	When User added products to cart
	And User click on purchase 
	And user click on checkout
	And user fill the form and click on continue
	And User click on finish
	Then verify purchase is completed successfully





