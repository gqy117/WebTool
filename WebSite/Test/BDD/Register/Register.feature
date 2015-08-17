Feature: Register

@Register

Scenario: Try to register an existing user

	Given the information
	| UserName | Password | ConfirmPassword |
	| 1        | 1        | 1               |

	When I open the page '~/Register/Index'

	And I fill all the following elements by name
	| UserName | Password | ConfirmPassword |
	| UserName | Password | ConfirmPassword |

	And I click the button by id 'login-btn'

	And I wait for '1000'

	Then I should see by name 'alert-error'