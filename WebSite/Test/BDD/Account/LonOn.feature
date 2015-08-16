Feature: LonOn

@LonOn
Scenario: LogOn to the website
	Given the information
	|UserName	|Password	|
	|1			|1			|

	When I open the page '~/Account/Login'

	And I fill all the following elements by name
	|UserName	|Password	|
	|UserName	|Password	|

	And I click the submit button by id 'login-btn'

	Then the current url should be '~/'
