@SmokeSuite
Feature: SmokeTest
	Create a Product with sell price and save the product

@ProductPlanSingleDataSetExecution
Scenario: 01 ProductPlan with Single Data Set Chrome
Given I Launch 'ProductPlan' in 'SIT'
When I have navigated to Home Page
And I select section '19 - Ladies Jacket'
And I select season '9-2019'
And I select department '1201 - Outwear'
And I enter the product 'Auto'
And I select the sellprice '24.99'
Then I save product from context menu
And I click on saved product
And I add product classification 'Othertop - Top'
And I add articles '09-090' '10-201'
And I add graphicle appearance 'Lace' for article '09-090'
And I add ISW for weekno '21'
And I add article type '990 -' for article '09-090'
And I set FM '*' for article:'09-090'
And I add Product details'Woven' and Customs Customer Group'Women'
And I save the product
And I add quantites '55000' and '45000'
And I add version
And I save the product
And I wait for article number display
And I click on Ready To Order
And I close order

@ProductPlanMultipleDataSetExecution
Scenario Outline: 02 ProductPlan with Multiple Data Set Chrome
Given I Launch the <ApplicationName> in <Environment>
When I have navigated to Home Page
And I select sections <sections>
And I select seasons <seasons>
And I select departments <departments>
And I enter the products <products>
And I select the sellprices <sellprices>
Then I save product from context menu
Examples:
| ApplicationName | Environment | sections           | seasons | departments   | products | sellprices |
| ProductPlan     | SIT         |19 - Ladies Jacket  | 9-2018  |1201 - Outwear | AutoTest | 24.99      |
| ProductPlan     | SIT         | 06 - Ladies Casual | 8-2018  | 4043 - Woven  | AutoTest | 19.00      |


@HMOrderExecution
Scenario: 03 SIT SmokeTest HMOrder
	Given Scenario 03 SIT SmokeTest HMOrder depends on '01 ProductPlan with Single Data Set Chrome'
	Given I am in HMOrder HomePage
	When I select season '8-2018'
	And I select department '1024'
	And I open new order window having castor options

