using BAF.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace BAF.StepDefinitions
{
    [Binding]
    public sealed class ProductPlanSteps : Steps
    {
        private IWebDriver driver;
        private ProductPlanPageUI productPlanPage;

        public ProductPlanSteps(IWebDriver driver)
        {
            productPlanPage = new ProductPlanPageUI(driver);
            this.driver = driver;
        }

        [Given(@"I Launch '(.*)' in '(.*)'")]
        public void givenINavigateToApplication(string ApplicationName, string Environment)
        {
            productPlanPage.launchApplication(ApplicationName, Environment);
            productPlanPage.waitForPageTitle("Product Plan", 30);
            handleSpinner();
        }
        [Given(@"I Launch the (.*) in (.*)")]
        public void givenINavigateToApplicationB(string ApplicationName, string Environment)
        {
            productPlanPage.launchApplication(ApplicationName, Environment);
            productPlanPage.waitForPageTitle("Product Plan", 30);
            handleSpinner();
        }

        [When(@"I have navigated to Home Page"), Scope(Tag = "SmokeSuite")]
        public void selectFullMode()
        {
            productPlanPage.waitForPageTitle("Product Plan", 150000);
            productPlanPage.waitLong(5);
            productPlanPage.get_FullMode().Click();
            handleSpinner();
        }

        [When(@"I select section '(.*)'"), Scope(Tag = "ProductPlanSingleDataSetExecution")]
        public void selectSection(string section)
        {
            productPlanPage.SelectElementFromDropdown(productPlanPage.get_SectionDropdown(), "visibleText", section);
            handleSpinner();
        }

        [When(@"I select sections (.*)")]
        public void selectSections(string section)
        {
            productPlanPage.SelectElementFromDropdown(productPlanPage.get_SectionDropdown(), "visibleText", section);
            handleSpinner();
        }

        [When(@"I select season '(.*)'"), Scope(Tag = "ProductPlanSingleDataSetExecution")]
        public void selectSeason(string season)
        {
            productPlanPage.get_Season(season).Click();
            handleSpinner();
            productPlanPage.checkWeekSliderSpinnerToDisappear();

        }

        [When(@"I select seasons (.*)")]
        public void selectSeasons(string season)
        {
            productPlanPage.get_Season(season).Click();
            handleSpinner();
            productPlanPage.checkWeekSliderSpinnerToDisappear();
        }

        [When(@"I select department '(.*)'"), Scope(Tag = "ProductPlanSingleDataSetExecution")]
        public void selectDepartment(string department)
        {
            handleSpinner();
            productPlanPage.get_Department(department).Click();
            handleSpinner();
        }

        [When(@"I select departments (.*)")]
        public void selectDepartments(string department)
        {
            handleSpinner();
            productPlanPage.get_Department(department).Click();
            handleSpinner();
        }

        [When(@"I enter the product '(.*)'"), Scope(Tag = "ProductPlanSingleDataSetExecution")]
        public void enterProductName(string ProductName)
        {
            getProductNameByScrollingDown();
            productPlanPage.checkWeekSliderSpinnerToAppear();
            String productName = GenerateUniqueProductNumber(ProductName);
            if (productPlanPage.get_CreateProduct_Editor().Displayed)
            {
                productPlanPage.checkWeekSliderSpinnerToAppear();
                productPlanPage.type(productPlanPage.get_CreateProduct_Editor(), productName);
            }

        }

        [When(@"I enter the products (.*)")]
        public void enterProductNames(string ProductName)
        {
            getProductNameByScrollingDown();
            productPlanPage.checkWeekSliderSpinnerToAppear();
            String productName = GenerateUniqueProductNumber(ProductName);
            if (productPlanPage.get_CreateProduct_Editor().Displayed)
            {
                productPlanPage.checkWeekSliderSpinnerToAppear();
                productPlanPage.type(productPlanPage.get_CreateProduct_Editor(), productName);
            }

        }

        [When(@"I select the sellprice '(.*)'"), Scope(Tag = "ProductPlanSingleDataSetExecution")]
        public void selectSellPriceA(string Sellprice)
        {
            var ProductName = System.Environment.GetEnvironmentVariable("Product");
            productPlanPage.get_SelectedTab_Editor().Click();
            productPlanPage.doubleClick(productPlanPage.get_SellPrice(ProductName));
            productPlanPage.get_SellPriceDropdownSelect(ProductName).SendKeys(Sellprice);
        }

        [When(@"I select the sellprices (.*)")]
        public void selectSellPrices(string Sellprice)
        {
            var ProductName = System.Environment.GetEnvironmentVariable("Product");
            productPlanPage.get_SelectedTab_Editor().Click();
            productPlanPage.doubleClick(productPlanPage.get_SellPrice(ProductName));
            productPlanPage.get_SellPriceDropdownSelect(ProductName).SendKeys(Sellprice);
        }

        [Then(@"I save product from context menu"), Scope(Tag = "SmokeSuite")]
        public void saveProduct()
        {
            productPlanPage.rightClickOptionSelect(productPlanPage.get_ProductNameLink(System.Environment.GetEnvironmentVariable("Product")), "Save Product");
            if (productPlanPage.get_LoadSpinner().Displayed)
            {
                productPlanPage.checkProductPlanSpinnerToDisappear();
            }
        }

        [Then(@"I click on saved product")]
        public void SelectCreatedProduct()
        {
            productPlanPage.get_ProductNameLink(System.Environment.GetEnvironmentVariable("Product")).Click();
        }

        [Then(@"I add product classification '(.*)'")]
        public void AddProductClassification(String productClassification)
        {
            productPlanPage.get_ProductClassificationMissing().Click();
            productPlanPage.get_ProductClassificationDropdown().Click();
            productPlanPage.get_ProductClassificationDropdown().SendKeys(productClassification);
            selectDropdownOption(productPlanPage.get_ProductClassificationDropdown());
        }
        [Then(@"I add articles '(.*)' '(.*)'")]
        public void AddArticles(String article1, String article2)
        {
            productPlanPage.get_ExpandShowArticleList().Click();
            productPlanPage.get_PleaseAddArticles().Click();
            productPlanPage.get_ColorCodeTextBoxEditable().SendKeys(article1);
            productPlanPage.checkProductPlanSpinnerToDisappear();
            selectDropdownOption(productPlanPage.get_SelectColorCode(article1));
            productPlanPage.get_ColorCodeTextBoxEditable().SendKeys(article2);
            productPlanPage.checkProductPlanSpinnerToDisappear();
            selectDropdownOption(productPlanPage.get_SelectColorCode(article2));
        }
        [Then(@"I add graphicle appearance '(.*)' for article '(.*)'")]
        public void AddGraphicalAppearance(String graphicalAppearance, String article1)
        {
            productPlanPage.get_ArticleGraphicalAppearanceMissing().Click();
            productPlanPage.doubleClick(productPlanPage.get_GraphicalAppearanceTextBox(article1));
            productPlanPage.get_GraphicalAppearanceTextBoxEditable().SendKeys(graphicalAppearance);
            productPlanPage.checkWeekSliderSpinnerToAppear();
            selectDropdownOption(productPlanPage.get_GraphicalAppearanceTextBoxSelect(graphicalAppearance));
            productPlanPage.switchToActiveElement();
            productPlanPage.get_AllArticlesCheckbox().Click();
            productPlanPage.get_ApplyButton().Click();
        }
        [Then(@"I add ISW for weekno '(.*)'")]
        public void AddISWs(String weekNo)
        {
            productPlanPage.get_PleaseSelectISWs().Click();
            productPlanPage.get_WeekSelect1(weekNo).Click();
            productPlanPage.waitLong(3);
            productPlanPage.get_WeekSelect2(weekNo).Click();
        }

        [Then(@"I add article type '(.*)' for article '(.*)'")]
        public void AddArticleType(String salesType, String article1)
        {
            productPlanPage.get_ArticleTypeMissing().Click();
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.doubleClick(productPlanPage.get_SalesTypeTextBox(article1));
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.get_SalesTypeTextBoxEditable().SendKeys(salesType);
            selectDropdownOption(productPlanPage.get_SalesTypeTextBoxSelect(salesType));
            productPlanPage.switchToActiveElement();
            productPlanPage.get_AllArticlesCheckbox().Click();
            productPlanPage.get_ApplyButton().Click();
            productPlanPage.waitLong(3);
        }
        [Then(@"I set FM '(.*)' for article:'(.*)'")]
        public void AddFM(String fmValue, String article1)
        {
            productPlanPage.doubleClick(productPlanPage.get_FMTextbox(article1));
            productPlanPage.get_FMTextBoxEditable().SendKeys(fmValue);
            productPlanPage.checkWeekSliderSpinnerToAppear();
            selectDropdownOption(productPlanPage.get_FMTextBoxSelect(fmValue));
            productPlanPage.switchToActiveElement();
            productPlanPage.get_AllArticlesCheckbox().Click();
            productPlanPage.get_ApplyButton().Click();
        }

        [Then(@"I add Product details'(.*)' and Customs Customer Group'(.*)'")]
        public void AddProductDetailsAndCustomsCustomerGroup(String productDetails, String customsCustomerGroup)
        {
            productPlanPage.get_ExpandShowProductDetails().Click();
            productPlanPage.SelectElementFromDropdown(productPlanPage.get_ExpandShowProductDetails(), "visibleText", productDetails);
            productPlanPage.SelectElementFromDropdown(productPlanPage.get_CustomsCustomerGroupId(), "visibleText", customsCustomerGroup);
        }

        [Then(@"I save the product")]
        public void SaveProduct()
        {
            productPlanPage.get_SaveProduct().Click();
            handleSpinner();
            productPlanPage.checkProductPlanSpinnerToDisappear();
            productPlanPage.waitLong(3);
        }

        public void AddQuantity(String Quantity1)
        {
            productPlanPage.doubleClick(productPlanPage.get_Total_excl1());
            productPlanPage.get_Total_excl1Editable().SendKeys(Quantity1);
            productPlanPage.keyBoardActions("enter");
            handleSpinner();
        }

        [Then(@"I add quantites '(.*)' and '(.*)'")]
        public void AddQuantity(String Quantity1, String Quantity2)
        {
            if (productPlanPage.get_Total_excl1().Displayed)
            {
                productPlanPage.doubleClick(productPlanPage.get_Total_excl1());
            }
            productPlanPage.get_Total_excl1Editable().SendKeys(Quantity1);
            productPlanPage.keyBoardActions("enter");
            handleSpinner();
            productPlanPage.waitLong(3);
            productPlanPage.checkWeekSliderSpinnerToDisappear();
            if (productPlanPage.get_Total_excl2().Displayed)
            {
                productPlanPage.doubleClick(productPlanPage.get_Total_excl2());
            }
            if (productPlanPage.get_Total_excl2Editable().Displayed)
                productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.get_Total_excl2Editable().SendKeys(Quantity2);
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.type(productPlanPage.get_Total_excl2Editable(), Quantity2);
            productPlanPage.keyBoardActions("enter");
            productPlanPage.checkWeekSliderSpinnerToAppear();
        }

        [Then(@"I add version")]
        public void AddVersion()
        {
            productPlanPage.get_Version().Click();
            productPlanPage.checkWeekSliderSpinnerToDisappear();
            productPlanPage.doubleClick(productPlanPage.get_VersionCell());
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.get_VersionCellEditable().Clear();
            productPlanPage.get_VersionCellEditable().SendKeys("1");
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.get_VersionCellAutocomplete("1").Click();
            productPlanPage.get_allMarketsIsChecked().Click();
            productPlanPage.get_allArticlesIsChecked().Click();
            productPlanPage.get_Apply().Click();
        }

        [Then(@"I wait for article number display")]
        public void WaitForArticleNumberDisplay()
        {
            waitForElementPresentWithPageRefresh();
        }

        [Then(@"I click on Ready To Order")]
        public void ReadyToOrder()
        {
            productPlanPage.get_SelectPlan().Click();
            productPlanPage.get_FormatCheckbox().Click();
            productPlanPage.get_BuyAllPMs().Click();
            productPlanPage.checkProductPlanSpinnerToDisappear();
            productPlanPage.checkWeekSliderSpinnerToAppear();
            try
            {
                productPlanPage.get_ReadyToOrder().Click();
                productPlanPage.checkProductPlanSpinnerToDisappear();
            }
            catch
            {
                productPlanPage.waitLong(5);
                productPlanPage.get_ReadyToOrder().Click();
            }

            handleSpinner();
        }

        [Then(@"I close order")]
        public void CloseOrder()
        {
            productPlanPage.get_ProductClose().Click();
        }


        public void AddArticleRoughPlan(String productName, String weekno1, String weekno2, String Quantity1, String Quantity2)
        {
            getProductNameByScrollingDown();
            productPlanPage.get_Arrow(productName).Click();
            productPlanPage.checkProductPlanSpinnerToDisappear();
            for (int i = 0; i <= 3; i++)
            {
                productPlanPage.keyBoardActions("down");
            }

            IWebElement temp = driver.FindElement(By.XPath("(//*[contains(@class,'ag-pinned')]//*[contains(@class,'-row') and contains(.,'" + productName + "')])[1]"));
            int rowNo = Int32.Parse(temp.GetAttribute("row"));
            IWebElement rowclick1 = driver.FindElement(By.XPath("//*[@row='" + (rowNo + 1) + "']//*[@colid='w" + weekno1 + "']//*[contains(@class,'-quantity')]"));
            Actions act = new Actions(driver);
            act.DoubleClick(rowclick1).Build().Perform();

            driver.FindElement(By.XPath("//*[@row='" + (rowNo + 1) + "']//*[@colid='w" + weekno1 + "']//*[contains(@class,'-quantity')]")).SendKeys(Quantity1);
            productPlanPage.keyBoardActions("tab");

            rowclick1 = driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]"));
            act = new Actions(driver);
            act.DoubleClick(rowclick1).Build().Perform();
            driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]")).SendKeys(Quantity2);
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.type(driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]")), Quantity2);
            productPlanPage.keyBoardActions("tab");

        }


        // TODO update week1 to week 2

        public void AddArticleRoughPlan(String productName, String weekno2, String Quantity2)
        {
            getProductNameByScrollingDown();
            productPlanPage.get_Arrow(productName).Click();
            productPlanPage.checkProductPlanSpinnerToDisappear();
            for (int i = 0; i <= 3; i++)
            {
                productPlanPage.keyBoardActions("down");
            }

            IWebElement temp = driver.FindElement(By.XPath("(//*[contains(@class,'ag-pinned')]//*[contains(@class,'-row') and contains(.,'" + productName + "')])[1]"));
            int rowNo = Int32.Parse(temp.GetAttribute("row"));
            IWebElement rowclick1 = driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]"));
            Actions act = new Actions(driver);
            act.DoubleClick(rowclick1).Build().Perform();
            driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]")).SendKeys(Quantity2);
            productPlanPage.checkWeekSliderSpinnerToAppear();
            productPlanPage.type(driver.FindElement(By.XPath("//*[@row='" + (rowNo + 2) + "']//*[@colid='w" + weekno2 + "']//*[contains(@class,'-quantity')]")), Quantity2);
            productPlanPage.keyBoardActions("tab");
            productPlanPage.get_Arrow(productName).Click();
        }

        public void SaveProductAfterAddingRoughPlan(String productName)
        {
            productPlanPage.waitLong(2);
            productPlanPage.get_ProductNameLink(productName).Click();
            productPlanPage.get_SaveProduct().Click();
            productPlanPage.checkProductPlanSpinnerToDisappear();
            productPlanPage.waitLong(3);
        }
        /*============================================================================================================================================
                                                        PRODUCT PLAN CUSTOM FUNCTIONS
        ==============================================================================================================================================*/
        public String GenerateUniqueProductNumber(String product)
        {
            DateTime now = DateTime.Now;
            var timestamp = now.ToString("yyyyMMddHHmmss");
            var productname = product + timestamp;
            System.Environment.SetEnvironmentVariable("Product", productname.ToString());
            return productname.ToString();
        }
        public void handleSpinner()
        {
            try
            {
                if (productPlanPage.get_LoadSpinner().Displayed)
                {
                    productPlanPage.checkProductPlanSpinnerToDisappear();
                }
            }
            catch
            {
                productPlanPage.checkProductPlanSpinnerToDisappear();
            }

        }

        public void getProductNameByScrollingDown()
        {
            try
            {
                if (productPlanPage.get_scroller().Displayed)
                {
                    productPlanPage.checkProductPlanSpinnerToDisappear();
                    productPlanPage.get_scroller().Click();
                    for (int i = 0; i < 200; i++)
                    {
                        productPlanPage.keyBoardActions("up");
                    }
                    productPlanPage.waitLong(3);
                    productPlanPage.doubleClick(productPlanPage.get_CreateProduct_1());
                }

            }

            catch
            {
                for (int i = 0; i < 200; i++)
                {
                    productPlanPage.keyBoardActions("down");
                }
                productPlanPage.waitLong(3);
                productPlanPage.doubleClick(productPlanPage.get_CreateProduct_1());
            }
        }

        public void selectDropdownOption(IWebElement selectElement)
        {
            productPlanPage.waitLong(1);

            try
            {
                productPlanPage.keyBoardActions("down");
                productPlanPage.keyBoardActions("enter");

            }
            catch
            {
                selectElement.Click();
            }

        }
        public void waitForElementPresentWithPageRefresh()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromMinutes(15);
            wait.PollingInterval = TimeSpan.FromSeconds(20);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = wait.Until<IWebElement>((driver) =>
            {
                driver.Navigate().Refresh();
                handleSpinner();
                return driver.FindElement(By.XPath("//*[@class='slick-cell l7 r7 sales-product-number']//*[contains(text(),'0')]"));
            });
        }

    }
}






