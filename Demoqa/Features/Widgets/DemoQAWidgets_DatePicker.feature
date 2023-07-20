Feature: To Test the widgets Tab in DemoQA and check the datepicker Tab
A short summary of the feature

@tag1
Scenario Outline: Test the datepicker tab inside widgets Tab
	Given We navigate to widgets tab
	When We click on date picker tab
	Then We add the number of days to the current date <number of days>
	Then We validate the provided date <number of days>
	And We set the date and time <number of days> and <hours>
	Then We validate provided date and time <number of days> and <hours>


Examples:
	| number of days | hours |
	| 50             | 17    |
