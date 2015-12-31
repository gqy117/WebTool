Feature: Register

@Register

Scenario: Try to register an existing user

	Given the information
	| UserName | Password | ConfirmPassword |
	| 1        | 1        | 1               |

	When I GotoRegisterPage

	And I fill the username, passport and confirm password
	| UserName | Password | ConfirmPassword |
	| UserName | Password | ConfirmPassword |

	And I click register button

	And I wait for '1000'

	Then I should see an error