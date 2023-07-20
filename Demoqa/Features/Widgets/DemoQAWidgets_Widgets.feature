Feature: To Test the Widgets Tab in DemoQA and check the Auto complete option
A short summary of the feature

@tag1
Scenario Outline: Test the Auto complete option inside Widgets Tab
	Given We navigate to widgets tab
	When We click on auto complete tab
	When We input multiple color options inside text <Color number 1> and <Color number 2>
	And We remove the individual color from the container <Color number 1>
	And We input single color option inside text <Color number 2>
	Then We validate the single color inside the container <Color number 2>

Examples:
	| Color number 1 | Color number 2 | 
	| White          | black          |


