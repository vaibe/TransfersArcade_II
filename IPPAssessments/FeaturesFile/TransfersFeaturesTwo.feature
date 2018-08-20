Feature: TransfersFeaturesTwo
	In order to verify data retention integrity
	I want to verify certain customer details

Background: 
	Given I am at the Transfer Arcade Home page
	And I click the Sign In button

@mytag
Scenario: Add two numbers
	And I enter the username in the Email Username field
	And I enter a password in the Password field
	And I click the Continue button
	When I click the My Account link on the resultant Home page
	Then the email address shown in the Email box is that used for logging in
