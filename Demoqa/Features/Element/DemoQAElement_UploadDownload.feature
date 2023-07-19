Feature: To Test the Element Tab in DemoQA and check the Upload Download Tab
A short summary of the feature

@tag1
Scenario: Test the Upload & Download tab inside Element Tab
	Given We open the browser and pass the URL
	When We navigate to Elements tab
	When We navigate to upload and download tab inside element
	And We click on download button
	Then We upload a sample file
	Then We validate the file path location

