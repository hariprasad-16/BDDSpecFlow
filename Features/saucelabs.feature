Feature: Testing the functionality of saucelabs
Background:
	Given User navigates into the URL

Scenario: Testing the URL is valid
	Then verify user navigates to the URL successfully
Scenario: Testing sign-in functionality

	When User click on sign in button
	And User enter a username "hariprasad19990916@gmail.com" and password "Sauce@123"
	And User click on log-in button
	Then verify that the user is logged in successfully

Scenario: Testing test completed count is working

	Then Verify the test completed count is working


Scenario: Testing Parallel test dropdown

	When User click on price tag
	And user selected the "3" parallel test from dropdown
	Then verify parallel test is selected successfully

Scenario: Testing Pricing Plan Checkbox

	When User click on price tag
	And user change the pricing plan to Monthly
	Then verify the prie plan status is "Billed monthly"

Scenario: Testing the Logo
	Then verify the log's are displayed

Scenario: Testing the video is playing

	When user click on play button
	Then verify the video is playing successfully

Scenario: Testing Live web test

	When User click on sign in button
	And User enter a username "hariprasad19990916@gmail.com" and password "Sauce@123"
	And User click on log-in button
	Then verify that the user is logged in successfully
	When user click on new live web test
	And user selects browser
	And user start the new web test
	And user takes the screenshot
	And user ends the test
	Then verify the test was completed successfully

