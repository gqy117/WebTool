Feature: LogOnToTheWebsite

@LogOnToTheWebsite
Scenario: LogOn

	Given the information
		| UserName | Password |
		| 1				| 1        |

	When I goto logon page

	And I fill the username and password

	And I start logon

	And I wait for '1000'

	Then I should see the url is base url