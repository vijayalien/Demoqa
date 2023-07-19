Feature: To Test the Element Tab in DemoQA and check the Button Tab
A short summary of the feature

@tag1
Scenario: Test the Button tab inside Element Tab
	Given We open the browser and pass the URL
	When We navigate to Elements tab
	When We navigate to buttons tab inside elements
	And We click double click button
	Then We validate the double click message
	And We click right click button
	Then We validate the right click message
	And We click dynamic click button
	Then We validate the dynamic click message
