Feature: Wol

@Wol
Scenario: Check Wol Tables

When LogOn to the website
And I open the page '~/Tool/WOL'
Then the result should be the same as the html 'Wol\WolTable.html', and the element '#WOLTable'