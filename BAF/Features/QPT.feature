Feature: QPT

@ignore("QPT is not launching due to Authorization issues, hence ignoring the scenario")
Scenario: QPT Flow
	Given I verify season display
	When I click on store
	And I click on online
	And I click on All
	And I click on File Menu
	Then I click on Exit
