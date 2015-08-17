Feature: LanguageBar

@LanguageBar

Scenario: LanguageBar should change the language

When LogOn to the website

And I click the button by id 'change-language-dropdown'

And I click the button by id 'language-icon'

And I wait for '1000'

Then the result of the element '[name="current-language-text"]' should be the same as '&#20013;&#25991;'