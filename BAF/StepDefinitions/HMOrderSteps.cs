using HP.LFT.Report;
using HP.LFT.SDK;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace BAF.StepDefinitions
{
    [Binding]
    public sealed class HMOrderSteps : Steps
    {
        // private UnitTestClassBase Utcb;
        public HMOrderPageUI HMOrderPage = new HMOrderPageUI();

        [Given(@"Scenario 03 SIT SmokeTest HMOrder depends on '(.*)'")]
        public void verifyScenarioDependency(string ScenarioName)
        {
            if (!(TestInitiator.dependsOnScenario[ScenarioName].Equals("Pass")))
            {
                Assert.Ignore("Scenario is skipped as dependent scenario ===> '" + ScenarioName + "' has failed");
            }
        }

        [Given("I am in HMOrder HomePage")]
        public void GivenIAmInHMOrderHomePage()
        {
            Thread.Sleep(30000);
            HMOrderPage.HMOrderWindow.Exists(10);
            HMOrderPage.HMOrderWindow.Activate();
        }

        [When("I select season '(.*)'"), Scope(Tag = "HMOrderExecution")]
        public void WhenISelectSeason(String Season)
        {
            //Selection of Season
            HMOrderPage.HMOrderWindow.Activate();
            var Season_x = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.ToolbarsManager.Ribbon.Tabs[0].Groups[2].Tools[2].Bounds.X;
            var Season_y = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.ToolbarsManager.Ribbon.Tabs[0].Groups[2].Tools[2].Bounds.Y;
            System.Drawing.Point Seasonpoint = new System.Drawing.Point(Season_x + 80, Season_y + 15);
            Mouse.Move(Seasonpoint);
            Thread.Sleep(5000);
            Mouse.Click(Seasonpoint, MouseButton.Left);
            Thread.Sleep(1000);
            Keyboard.SendString(Season);
            Thread.Sleep(3000);
        }


        [When("I select department '(.*)'"), Scope(Tag = "HMOrderExecution")]
        public void ThenISelectDepartment(String Department)
        {
            //Selection of Department
            HMOrderPage.HMOrderWindow.Activate();
            HMOrderPage.HMOrderWindow.OrderExplorerWindow.UltraTreeDepartmentsUiObject.Click();
            string sNodeName = "";
            Thread.Sleep(1000);
            var sNodemebers1 = HMOrderPage.HMOrderWindow.OrderExplorerWindow.UltraTreeDepartmentsUiObject.NativeObject.MEMBERS;
            var vNodes = HMOrderPage.HMOrderWindow.OrderExplorerWindow.UltraTreeDepartmentsUiObject.NativeObject.Nodes[0].Nodes;
            var scount = vNodes.Count;
            Thread.Sleep(2000);
            bool bNodefound = false;

            for (int i = 0; i <= scount - 1; i++)
            {

                sNodeName = vNodes[i].Key;
                if (sNodeName == Department)
                {
                    HMOrderPage.HMOrderWindow.OrderExplorerWindow.UltraTreeDepartmentsUiObject.NativeObject.Nodes[0].Nodes[i].Selected = true;
                    bNodefound = true;
                    break;
                }
            }
            if (bNodefound == true)
            {
                Reporter.ReportEvent("HMOrder Node Selection", "HMOrder Node Selected - " + Department, HP.LFT.Report.Status.Passed);
            }
            else
            {
                Reporter.ReportEvent("HMOrder Node Selection", "HMOrder Node Selected - " + Department, HP.LFT.Report.Status.Failed);
            }
        }

        [When("I open new order window having castor options")]
        public void IOpenNewOrderhavingCastorOptions()
        {
            Thread.Sleep(1000);
            HMOrderPage.HMOrderWindow.Activate();
            // appModel.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.Click();
            var stabmem = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.MEMBERS;
            var GrouptoolMem = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.ToolbarsManager.Ribbon.Tabs[0].Groups[0].Tools.MEMBERS;
            var nx1 = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.ToolbarsManager.Ribbon.Tabs[0].Groups[0].Tools[0].Bounds.X;
            var ny1 = HMOrderPage.HMOrderWindow.BaseFormToolbarsDockAreaTopUiObject.NativeObject.ToolbarsManager.Ribbon.Tabs[0].Groups[0].Tools[0].Bounds.Y;

            System.Drawing.Point Newordpoint1 = new System.Drawing.Point(nx1 + 20, ny1 + 20);
            Mouse.Move(Newordpoint1);
            Mouse.Click(Newordpoint1, MouseButton.Left);
            Thread.Sleep(5000);
            Newordpoint1 = new System.Drawing.Point(nx1 + 80, ny1 + 80);
            Mouse.Move(Newordpoint1);
            Mouse.Click(Newordpoint1, MouseButton.Left);
            Thread.Sleep(5000);
        }

    }
}



