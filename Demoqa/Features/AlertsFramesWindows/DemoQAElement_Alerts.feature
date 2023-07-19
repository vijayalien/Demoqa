Feature: To Test the Alert Frames & Windows Tab in DemoQA and check the Alerts Tab
A short summary of the feature

@tag1
Scenario Outline: Test the Alerts tab inside  Alert Frames & Windows Tab
	Given We open the browser and pass URL
	When We navigate to alert frames and windows tab
	When We navigate to alerts tab
	Then We click on alert button and close the alert popup
	And We click on delayed alert button and close the alert popup
	And We click on third alert box and perform confirm action
	Then We validate the ok message
	And We click on third alert box and perform cancel action
	Then We validate the cancel message
	And We click on prompt alert box and enter text <Prompt text>
	Then we validate the prompt alert text <Prompt text>

	Examples: 
	| Prompt text	  |
	| automation test |
