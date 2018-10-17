jsonPWrapper ({
  "Features": [
    {
      "RelativeFolder": "Login.feature",
      "Feature": {
        "Name": "Login Test",
        "Description": "Check if login functionality works",
        "FeatureElements": [
          {
            "Name": "01 Login Demo chrome",
            "Slug": "01-login-demo-chrome",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I navigate to application",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I login with user credentials",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click login",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I should see user logged in to the application",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@LoginDemoGroup",
              "@LoginDemo"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "02 Login Demo firefox",
            "Slug": "02-login-demo-firefox",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I navigate to application",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I enter username and password",
                "TableArgument": {
                  "HeaderRow": [
                    "UserName",
                    "Password"
                  ],
                  "DataRows": [
                    [
                      "admin",
                      "admin"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click login",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I should see user logged in to the application",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@LoginDemo"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "03 Login Demo firefox",
            "Slug": "03-login-demo-firefox",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I navigate to application",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I enter username and password",
                "TableArgument": {
                  "HeaderRow": [
                    "UserName",
                    "Password"
                  ],
                  "DataRows": [
                    [
                      "admin",
                      "admin"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click login",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I should see user logged in to the application",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@LoginDemoGroup",
              "@LoginDemo"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@DemoLoginSuite"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "QPT.feature",
      "Feature": {
        "Name": "QPT",
        "Description": "",
        "FeatureElements": [
          {
            "Name": "QPT Flow",
            "Slug": "qpt-flow",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I verify season display",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I click on store",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click on online",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click on All",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click on File Menu",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I click on Exit",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@ignore(\"QPT",
              "is",
              "not",
              "launching",
              "due",
              "to",
              "Authorization",
              "issues,",
              "hence",
              "ignoring",
              "the",
              "scenario\")"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": []
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "SITSmoke.feature",
      "Feature": {
        "Name": "SmokeTest",
        "Description": "Create a Product with sell price and save the product",
        "FeatureElements": [
          {
            "Name": "01 ProductPlan with Single Data Set Chrome",
            "Slug": "01-productplan-with-single-data-set-chrome",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I Launch 'ProductPlan' in 'SIT'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I have navigated to Home Page",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select section '19 - Ladies Jacket'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select season '9-2019'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select department '1201 - Outwear'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I enter the product 'Auto'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select the sellprice '24.99'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I save product from context menu",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click on saved product",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add product classification 'Othertop - Top'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add articles '09-090' '10-201'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add graphicle appearance 'Lace' for article '09-090'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add ISW for weekno '21'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add article type '990 -' for article '09-090'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I set FM '*' for article:'09-090'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add Product details'Woven' and Customs Customer Group'Women'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the product",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add quantites '55000' and '45000'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I add version",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the product",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I wait for article number display",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I click on Ready To Order",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I close order",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@ProductPlanSingleDataSetExecution"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Examples": [
              {
                "Name": "",
                "TableArgument": {
                  "HeaderRow": [
                    "ApplicationName",
                    "Environment",
                    "sections",
                    "seasons",
                    "departments",
                    "products",
                    "sellprices"
                  ],
                  "DataRows": [
                    [
                      "ProductPlan",
                      "SIT",
                      "19 - Ladies Jacket",
                      "9-2018",
                      "1201 - Outwear",
                      "AutoTest",
                      "24.99"
                    ],
                    [
                      "ProductPlan",
                      "SIT",
                      "06 - Ladies Casual",
                      "8-2018",
                      "4043 - Woven",
                      "AutoTest",
                      "19.00"
                    ]
                  ]
                },
                "Tags": [],
                "NativeKeyword": "Examples"
              }
            ],
            "Name": "02 ProductPlan with Multiple Data Set Chrome",
            "Slug": "02-productplan-with-multiple-data-set-chrome",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I Launch the <ApplicationName> in <Environment>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I have navigated to Home Page",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select sections <sections>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select seasons <seasons>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select departments <departments>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I enter the products <products>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select the sellprices <sellprices>",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "I save product from context menu",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@ProductPlanMultipleDataSetExecution"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "03 SIT SmokeTest HMOrder",
            "Slug": "03-sit-smoketest-hmorder",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "Scenario 03 SIT SmokeTest HMOrder depends on '01 ProductPlan with Single Data Set Chrome'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I am in HMOrder HomePage",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I select season '8-2018'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I select department '1024'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I open new order window having castor options",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [
              "@HMOrderExecution"
            ],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@SmokeSuite"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    }
  ],
  "Summary": {
    "Tags": [
      {
        "Tag": "@DemoLoginSuite",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      },
      {
        "Tag": "@SmokeSuite",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      },
      {
        "Tag": "@LoginDemoGroup",
        "Total": 2,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 2
      },
      {
        "Tag": "@LoginDemo",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      },
      {
        "Tag": "@ignore(\"QPT",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "is",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "not",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "launching",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "due",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "to",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "Authorization",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "issues,",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "hence",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "ignoring",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "the",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "scenario\")",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "@ProductPlanSingleDataSetExecution",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "@ProductPlanMultipleDataSetExecution",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Tag": "@HMOrderExecution",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      }
    ],
    "Folders": [
      {
        "Folder": "Login.feature",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      },
      {
        "Folder": "QPT.feature",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      },
      {
        "Folder": "SITSmoke.feature",
        "Total": 3,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 3
      }
    ],
    "NotTestedFolders": [
      {
        "Folder": "Login.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "QPT.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "SITSmoke.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      }
    ],
    "Scenarios": {
      "Total": 7,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 7
    },
    "Features": {
      "Total": 3,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 3
    }
  },
  "Configuration": {
    "GeneratedOn": "19 februari 2018 12:26:19"
  }
});