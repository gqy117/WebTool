Feature: Wol

@Wol

Scenario: Check Wol Tables

When LogOn to the website
And I open the page '~/Tool/WOL'
Then the result of the element '#WOLTable tbody tr:nth-child(1)' should be the same as the html 'Wol\WolTable.html'