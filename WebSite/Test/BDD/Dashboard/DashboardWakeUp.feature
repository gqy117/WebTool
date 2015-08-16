Feature: DashboardWakeUp

@DashboardWakeUp
@AlreadyLogOn
Scenario: Wake Up
When LogOn to the website
And I click the button by id 'home-wake-up'
And I wait for '2500'
Then I should see by id 'alertWakeUpSuccess'