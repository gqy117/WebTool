Feature: DashboardWakeUp

@DashboardWakeUp
@AlreadyLogOn

Scenario: Wake Up

When I LogOn to the website

And I click home-wake-up button

Then I should see alertWakeUpSuccess