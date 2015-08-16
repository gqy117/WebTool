Feature: DashboardWakeUp

@DashboardWakeUp
@AlreadyLogOn
Scenario: Wake Up
When I already LogOn
And I click the button by name 'home-wake-up'
Then I should see by id 'alertWakeUpSuccess'