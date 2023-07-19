Feature: To Test the Element Tab in DemoQA and validate the webtable
A short summary of the feature

@tag1
Scenario: Test the webtable tab inside Element Tab
	Given We open the browser and pass the URL
	When We navigate to Elements tab
	When We navigate to webtable tab inside elements
	Then We log the values inside the table
	And We edit value "Cantrell" with "Vijay"
	Then We log the values inside the table
	
