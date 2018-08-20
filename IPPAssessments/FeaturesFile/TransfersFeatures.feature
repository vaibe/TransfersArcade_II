Feature: TransfersFeatures
	In order to ensure correct transfers
	I want to verify transfer detail entries

@runThis
Scenario: SC01_Login via Login page
	Given the user is at the Login page
	And the User enters "felab@gmail.com" as Username
	And the User enters "55555" as Password
	When the User clicks Continue
	Then the User is navigated to the Home page

Scenario: SC02_United Kingdom Ccy via Login page
	Given the user is at the Login page
	And the User enters "felab@gmail.com" as Username
	And the User enters "55555" as Password
	And the User clicks Continue
	When the User select "United Kingdom" as the From country
	Then the Ccy displayed for United Kingdom is "GBP - United Kingdom Pound"

@runThis
Scenario: SC03_United Kingdom Ccy via Home page
	Given the user is at the Home page	
	When the User select "United Kingdom" as the To country
	Then the Ccy displayed for United Kingdom is "GBP - United Kingdom Pound"

Scenario: SC04_Verify Details Review page
	Given the user is at the Login page
	And the User enters "felab@gmail.com" as Username
	And the User enters "55555" as Password
	And the User clicks Continue
	And the User clicks on the Scenarios page
	And the User navigates to Scenario A page
	And the User select "United Kingdom" as the From country
	And the User enters "1250" as the amount to send
	And the User clicks Proceed
	And the User selects Recepient "Miss Lamide Akinwumi"
	When the User clicks Continue on the Recepients page
	Then the User is navigated to the Details Review page

Scenario: SC05_Verify amount for sending
	Given the user is at the Login page
	And the User enters "felab@gmail.com" as Username
	And the User enters "55555" as Password
	And the User clicks Continue
	And the User clicks on the Scenarios page
	And the User navigates to Scenario A page
	And the User select "United Kingdom" as the From country
	And the User enters "1250" as the amount to send
	And the User clicks Proceed
	And the User selects Recepient "Mr Victor Abegunde"
	When the User clicks Continue on the Recepients page
	Then the amount entered on the Scenarios page is displayed on the Details Review page

Scenario: SC06_Verify to Country
	Given the user is at the Login page
	And the User enters "felab@gmail.com" as Username
	And the User enters "55555" as Password
	And the User clicks Continue
	And the User clicks on the Scenarios page
	And the User navigates to Scenario A page
	And the User select "United Kingdom" as the From country
	And the User enters "1250" as the amount to send
	And the User clicks Proceed
	And the User selects Recepient "Alhaja Kola Tafa"
	When the User clicks Continue on the Recepients page
	Then the to Country shown on the Scenarios page is displayed on the Details Review page

Scenario: SC07_VerifyDropDownOptions
	Given the user is at the Home page
	Then verify that the Transfer money from drop down list contains the following "3" options "Select country", "United Kingdom" and "Nigeria".

Scenario Outline: SC08_Complete Transaction
	Given the user is at the Login page
	And the User provides <username> as Username
	And the User provides <password> as Password
	And the User clicks Continue
	And the User clicks on the Scenarios page
	And the User navigates to Scenario A page
	And the User selects <from country> as the From country
	And the User provides <amount to send> as the amount to send
	And the User clicks Proceed
	And the User chooses Recepient <recepient>
	And the User clicks Continue on the Recepients page
	And the User clicks Continue on the Details Review page
	When the User clicks Pay with credit on the Payment Types page
	Then Transaction Complete is displayed on the Transfer Receipt page
	Examples: 
	| username             |password  | from country   |amount to send	|recepient		 |
	| felab@gmail.com      | 55555    | United Kingdom |11				|Alhaja Kola Tafa|
	| alb@gmail.com		   | 22222    | United Kingdom |12				|Miss Kike Davies|
	| leo.nnekky@yahoo.com | 11111    | United Kingdom |13				|Mr Kela Balogun |

