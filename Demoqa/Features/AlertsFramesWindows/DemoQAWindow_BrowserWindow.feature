Feature: To Test the Brwoser Window Tab in DemoQA and check the window tab
A short summary of the feature

@tag1
Scenario: Test the Window tab inside Alert Frames & Windows Tab
	Given We open the browser and pass URL
	When We navigate to alert frames and windows tab
	When We navigate to browser window tab
	And We click on new tab button
	And We switch to new tab 
	Then We validate the new tab url and message
	Then We close the new tab and switch back to original tab
	And We click on new window button
	And We validate the new window message
	Then We close the new window and switch back to original window
	

	

	
