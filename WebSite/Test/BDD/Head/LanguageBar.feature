Feature: LanguageBar

@LanguageBar

Scenario: LanguageBar should change the language

When I LogOn to the website

And I click the change-language-dropdown button

And I click the language-icon button

And I wait for '1000'

Then the current language text should be cn.