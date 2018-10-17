using OpenQA.Selenium;
using System;

namespace BAF.PageObjects
{
    public class ProductPlanPageUI : BasePage
    {
        /* The driver. */
        IWebDriver driver;
        public ProductPlanPageUI(IWebDriver driver) : base(driver)
        {
            //PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public IWebElement get_FullMode()
        {
            return expWait.getWhenClickable(By.XPath("//button[contains(text(),'Full')]"), 50);
        }
        public IWebElement get_LoadSpinner()
        {
            return expWait.getWhenClickable(By.XPath("//div[@id='loadingSpinner']"), 5);
        }
        public IWebElement get_SectionDropdown()
        {
            return expWait.getWhenClickable(By.XPath("//*[@ng-model='sectionModel']"), 30);
        }
        public IWebElement get_Season(String season)
        {
            return expWait.getWhenClickable(By.XPath("//*[contains(text(),'" + season + "')]"), 30);
        }
        public IWebElement get_Department(String department)
        {
            return expWait.getWhenClickable(By.XPath("//*[contains(text(),'" + department + "')]"), 30);
        }
        public IWebElement get_CreateProduct_Editor()
        {
            return expWait.getWhenClickable(By.XPath("//div[@colid='productName']//input"), 30);
        }
        public IWebElement get_SelectedTab_Editor()
        {
            return expWait.getWhenClickable(By.XPath("//*[@class='active']/a"), 30);
        }
        public IWebElement get_SellPrice(String productName)
        {
            return expWait.getWhenClickable(By.XPath("//*[contains(text(),'" + productName + "')]//parent::span//parent::span//parent::div//following-sibling::div[@colid='sellPrice']/span"), 30);
        }
        public IWebElement get_SellPriceDropdownSelect(String productName)
        {
            return expWait.getWhenClickable(By.XPath("//*[contains(text(),'" + productName + "')]//parent::span//parent::span//parent::div//following-sibling::div[@colid='sellPrice']/input"), 30);
        }
        public IWebElement get_scroller()
        {
            return expWait.getWhenClickable(By.XPath("(//div[contains(@colid,'w2') or contains(@colid,'w0') or contains(@colid,'w1') or contains(@colid,'w3') or contains(@colid,'w4')]/span)[1]"), 60);
        }
        public IWebElement get_CreateProduct_1()
        {
            return expWait.getWhenClickable(By.XPath(".//*[@id='center']//*[@class='ag-pinned-left-cols-container']//*[text()='Create product']"), 30);
        }
        public IWebElement get_ProductNameLink(String productName)
        {
            return expWait.getWhenClickable(By.XPath("//div[@colid='productName']//span[contains(text(),'" + productName + "')]"), 30);
        }
        public IWebElement get_ProductClassificationMissing()
        {
            return expWait.getWhenClickable(By.XPath("//a[contains(text(),'Product Classification missing')]"), 30);
        }

        public IWebElement get_PleaseAddArticles()
        {
            return expWait.getWhenClickable(By.XPath("//a[contains(text(),'Please add Articles')]"), 30);
        }

        public IWebElement get_PleaseSelectISWs()
        {
            return expWait.getWhenClickable(By.XPath("//a[contains(text(),'Please select ISWs')]"), 30);
        }

        public IWebElement get_ArticleGraphicalAppearanceMissing()
        {
            return expWait.getWhenClickable(By.XPath("//a[contains(text(),'Article Graphical Appearance missing')]"), 30);
        }

        public IWebElement get_ArticleTypeMissing()
        {
            return expWait.getWhenClickable(By.XPath("//a[contains(text(),'Article Type missing')]"), 30);
        }

        public IWebElement get_ColorCodeTextBox()
        {
            return expWait.getWhenClickable(By.XPath("//span[@class='article-name-container']"), 30);
        }

        public IWebElement get_Arrow(String productName)
        {
            return expWait.getWhenClickable(By.XPath("//div[contains(.,'" + productName + "') and contains(@class,'ag-cell')]/preceding-sibling::*[1]/*"), 30);
        }


        public IWebElement get_ColorCodeTextBoxEditable()
        {
            return expWait.getWhenClickable(By.XPath("//*[@class='slick-cell l1 r1 colour-code active editable']/input[1]"), 30);


        }
        public IWebElement get_SelectColorCode(String Article)
        {
            //return expWait.getWhenClickable(By.XPath("//*[contains(@class,'colour-editor')]//*[text()='"+Article+"']"), 30);
            return expWait.getWhenClickable(By.XPath("//ul[contains(@class,'ui-autocomplete')]//li[contains(.,'" + Article + "')]"), 30);

        }
        public IWebElement get_ProductClassificationDropdown()
        {
            return expWait.getWhenClickable(By.XPath("//*[@class='product-classification']/input"), 30);
        }
        public IWebElement get_GraphicalAppearanceTextBox(String articleName)
        {
            return expWait.getWhenClickable(By.XPath("//span[contains(text(),'" + articleName + "')]//parent::span//parent::div//following::div[@class='slick-cell l6 r6 graphical-appearance']/span"), 30);
        }

        public IWebElement get_GraphicalAppearanceTextBoxEditable()
        {
            return expWait.getWhenClickable(By.XPath("//input[@class='editor-text ui-autocomplete-input']"), 30);
        }

        public IWebElement get_GraphicalAppearanceTextBoxSelect(String graphicalName)
        {
            //return expWait.getWhenClickable(By.XPath("//a[text()='"+graphicalName+"']"), 30);
            return expWait.getWhenClickable(By.XPath("//ul[contains(@class,'ui-autocomplete')]//li[contains(.,'" + graphicalName + "')]"), 30);
        }

        public IWebElement get_AllArticlesCheckbox()
        {
            return expWait.getWhenClickable(By.XPath("//input[@class='check-all-box']"), 30);
        }

        public IWebElement get_ApplyButton()
        {
            return expWait.getWhenClickable(By.XPath("//button[contains(text(),'Apply')]"), 30);
        }

        public IWebElement get_WeekSelect1(String weekNo)
        {
            return expWait.getWhenClickable(By.XPath("//div[@class='ui-widget-content slick-row even article-row']//span[contains(text(),'" + weekNo + "')]"), 30);
        }
        public IWebElement get_WeekSelect2(String weekNo)
        {
            return expWait.getWhenClickable(By.XPath("//div[@class='ui-widget-content slick-row odd article-row']//span[contains(text(),'" + weekNo + "')]"), 30);
        }

        public IWebElement get_ArticleTypeTextBox(String weekNo)
        {
            return expWait.getWhenClickable(By.XPath("//div[@class='ui-widget-content slick-row odd article-row']//span[contains(text(),'" + weekNo + "')]"), 30);
        }
        public IWebElement get_SalesTypeTextBox(String articleName)
        {
            //return expWait.getWhenClickable(By.XPath("//span[contains(text(),'"+articleName+"')]//parent::span//parent::div//following::div[@class='slick-cell l9 r9 sales-type']/span"), 30);
            return expWait.getWhenClickable(By.XPath("//span[contains(text(),'" + articleName + "')]//parent::span//parent::div//following::div[@class='slick-cell l9 r9 sales-type']/span"), 30);
        }
        public IWebElement get_SalesTypeTextBoxEditable()
        {
            return expWait.getWhenClickable(By.XPath("//input[@class='editor-text ui-autocomplete-input']"), 30);
        }

        public IWebElement get_SalesTypeTextBoxSelect(String salestype)
        {
            return expWait.getWhenClickable(By.XPath("//a[text()='" + salestype + "']"), 30);
        }

        public IWebElement get_FMTextbox(String articleName)
        {
            return expWait.getWhenClickable(By.XPath("//span[contains(text(),'" + articleName + "')]//parent::span//parent::div//following::div[@class='slick-cell l10 r10 flow-matrix']/span"), 30);
        }

        public IWebElement get_FMTextBoxEditable()
        {
            return expWait.getWhenClickable(By.XPath("//input[@class='editor-text ui-autocomplete-input']"), 30);
        }

        public IWebElement get_FMTextBoxSelect(String FMvalue)
        {
            return expWait.getWhenClickable(By.XPath("//a[text()='" + FMvalue + "']"), 30);
        }

        public IWebElement get_ExpandShowProductDetails()
        {
            return expWait.getWhenClickable(By.XPath("//select[contains(@ng-change,'changeTypeOfConstructionId')]"), 30);
        }

        public IWebElement get_ExpandShowArticleList()
        {
            return expWait.getWhenClickable(By.XPath("(//span[@title='Show Article List'])[1]"), 30);
        }

        public IWebElement get_TypeOfConstructionId()
        {
            return expWait.getWhenClickable(By.XPath("//*[@ng-model='product.typeOfConstructionId']"), 30);
        }

        public IWebElement get_CustomsCustomerGroupId()
        {
            return expWait.getWhenClickable(By.XPath("//*[@ng-model='product.customsCustomerGroupId']"), 30);

        }
        public IWebElement get_Total_excl1()
        {
            return expWait.getWhenClickable(By.XPath("(//*[contains(@class,'ag-cell-value sum-article-quantity')])[1]"), 30);
        }
        public IWebElement get_Total_excl1Editable()
        {
            return expWait.getWhenClickable(By.XPath("(//*[contains(@class,'ag-cell-value sum-article-quantity')])[1]/input"), 30);
        }

        public IWebElement get_Total_excl2()
        {
            return expWait.getWhenClickable(By.XPath("(//*[contains(@class,'ag-cell-value sum-article-quantity')])[2]"), 30);
        }

        public IWebElement get_Total_excl2Editable()
        {
            return expWait.getWhenClickable(By.XPath("(//*[contains(@class,'ag-cell-value sum-article-quantity')])[2]/input"), 30);
        }
        public IWebElement get_SaveProduct()
        {
            return expWait.getWhenClickable(By.XPath("//*[@ng-click='saveProduct()']"), 30);
        }
        public IWebElement get_Version()
        {
            return expWait.getWhenClickable(By.XPath("//button[contains(text(),' Version')]"), 30);
        }

        public IWebElement get_VersionCell()
        {
            return expWait.getWhenClickable(By.XPath("(//*[@class='ag-body-container']//*[contains(@class,'version-column')])[1]"), 30);
        }
        public IWebElement get_VersionCellEditable()
        {
            return expWait.getWhenClickable(By.XPath("(//*[@class='ag-body-container']//*[contains(@class,'version-column')])[1]/input"), 30);
        }
        public IWebElement get_VersionCellAutocomplete(String option)
        {
            return expWait.getWhenClickable(By.XPath("//ul[contains(@class,'ui-autocomplete')]//li[contains(.,'" + option + "')]"), 30);
        }
        public IWebElement get_allMarketsIsChecked()
        {
            return expWait.getWhenClickable(By.XPath("//*[@id='ArticleMultiApplyModal']//input[@ng-checked='allMarketsIsChecked']"), 30);
        }
        public IWebElement get_allArticlesIsChecked()
        {
            return expWait.getWhenClickable(By.XPath("//*[@id='ArticleMultiApplyModal']//input[@ng-checked='allArticlesIsChecked']"), 30);
        }
        public IWebElement get_Apply()
        {
            return expWait.getWhenClickable(By.XPath("//*[@id='ArticleMultiApplyModal']//button[text()='Apply']"), 30);
        }
        public IWebElement get_SelectPlan()
        {
            return expWait.getWhenClickable(By.XPath("//button//*[contains(text(),'Select Plan')]"), 30);
        }

        public IWebElement get_FormatCheckbox()
        {
            return expWait.getWhenClickable(By.XPath("(//*[@id='agHeaderCellLabel']//*[@type='checkbox'])[1]"), 30);
        }

        public IWebElement get_BuyAllPMs()
        {
            return expWait.getWhenClickable(By.XPath("//button//*[contains(text(),'Buy all PMs')]"), 30);
        }

        public IWebElement get_ReadyToOrder()
        {
            return expWait.getWhenClickable(By.XPath("//button[text()='Ready to Order']"), 30);
        }

        public IWebElement get_ArticleDisplay()
        {
            return driver.FindElement(By.XPath("(//div[@class='slick-cell l7 r7 sales-product-number']//span[contains(text(),'00')])[1]"));
        }
        public IWebElement get_ProductClose()
        {
            return expWait.getWhenClickable(By.XPath("//button[@id='product-card-close']"), 30);
        }

        public IWebElement get_Save()
        {
            return expWait.getWhenClickable(By.LinkText("Save"), 30);
        }


    }
}
