﻿Feature: To Test the interaction Tab in DemoQA and test the droppable feature


@tag1
Scenario: Test the droppable tab area inside interaction
	Given We navigate to interaction tab
	When We click on droppable tab
	Then We drag and drop the element inside simple tab
	And We click on accept tab
	Then We drag and drop the element inside accept tab
	
