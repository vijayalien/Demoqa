Feature: To Test the book store application Tab in DemoQA and test the login feature


@tag1
Scenario Outline: Test the login tab area inside book store application
	Given We navigate to book store application tab
	When We click on login tab
	#Then We click on new user button
	#And We pass the <firstname> <lastname> <username> and <password>
	#And We accept user created successfull alert
	#Then We click on back to login
	Then We login into the book store with <username> and <password>
	Then We validate the login <username>
	
Examples:
	| firstname | lastname | username | password  |
	| vjtest    | testauto | vjtest3  | Test@1234 |