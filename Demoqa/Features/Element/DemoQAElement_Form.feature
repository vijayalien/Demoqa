Feature: To Test the Element Tab in DemoQA and fill the form in text area

A short summary of the feature

@tag1
Scenario: Test the Text area inside Element Tab
	Given We open the browser and pass the URL
	When We navigate to Elements tab
	When We navigate to text box tab inside elements
	Then We pass value to text box form
	And We click on submit button
	Then We validate results of text box
