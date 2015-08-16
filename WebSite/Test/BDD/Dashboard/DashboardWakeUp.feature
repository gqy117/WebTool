Feature: DashboardWakeUp

@DashboardWakeUp
@AlreadyLogOn
Scenario: Wake Up
When I open the page '~'
And I click the button by id 'home-wake-up'
And I wait for '2500'
Then I should see by id 'alertWakeUpSuccess'