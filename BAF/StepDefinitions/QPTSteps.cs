using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BAF
{
    [TestFixture]
    [Binding]
    public class QPTSteps : Steps
    {
        //private UnitTestClassBase Utcb;
        public QPTPageUI QPTPage = new QPTPageUI();

        [Given(@"I verify season display")]
        public void verifySeasonDisplay()
        {
            QPTPage.QptExplorerWindow.TreeView.Highlight();
        }
        [When(@"I click on store")]
        public void clickStore()
        {
            QPTPage.QptExplorerWindow.StoreRadioButton.Click();
        }

        [When(@"I click on online")]
        public void clickOnline()
        {
            QPTPage.QptExplorerWindow.OnlineRadioButton.Click();
        }

        [When(@"I click on All")]
        public void clickAll()
        {
            QPTPage.QptExplorerWindow.AllRadioButton.Click();
        }

        [When(@"I click on File Menu")]
        public void clickOnFileMenu()
        {
            QPTPage.QptExplorerWindow.FileButton.Click();
        }

        [Then(@"I click on Exit")]
        public void clickOnExit()
        {
            QPTPage.QptExplorerWindow.closeQPTwindow.Click();
        }

    }
}
