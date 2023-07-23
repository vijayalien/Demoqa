Feature: To Test the interaction Tab in DemoQA and test the sortable feature


@tag1
Scenario: Test the sortable tab area inside interaction
	Given We navigate to interaction tab
	When We click on sortable tab
	Then We sort the list items
	Then We log the values inside list items
	
