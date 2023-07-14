using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.CommonModels;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLabCorp.StepDefinitions
{
    [Binding]
    public class CareersAtLabCorpStepDefintions
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            // Set up the Chrome driver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            // Quit the browser after the test
            driver.Quit();
        }

        [Given(@"I am on the LabCorp website")]
        public void GivenIAmOnTheLabCorpWebsite()
        {
            driver.Navigate().GoToUrl("https://www.labcorp.com");
        }

        [When(@"I click on the Careers link")]
        public void WhenIClickOnTheCareersLink()
        {
            IWebElement logo = driver.FindElement(By.XPath("//a[@class='logo hide-for-print']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border = '5px solid Red'", logo);
            IWebElement careersLink = driver.FindElement(By.XPath("//a[@href='https://careers.labcorp.com/global/en']"));
            careersLink.Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.LinkText("Careers")).Click();
            //Find the Element
            IWebElement welcomeback = driver.FindElement(By.XPath("//span[text()='Get tailored job recommendations based on your interests.']"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border = '5px solid Red'", welcomeback);
            Thread.Sleep(5000);
            IWebElement searchInput = driver.FindElement(By.XPath("(//input[@type='text'])[1]"));
            searchInput.Click();
            searchInput.SendKeys("QA Test Automation Developer");
            Thread.Sleep(1000);
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            IWebElement Result = driver.FindElement(By.XPath("//div[@data-ph-id='ph-page-element-page11-luwKqP']//div[@class='job-title']//span[contains(text(), 'Test Automation Engineer')]"));
            Result.Click();
            Thread.Sleep(1000);
            IWebElement jobTitle = driver.FindElement(By.XPath("//div[@class='job-info au-target']//h1[text()='Test Automation Engineer']"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border = '5px solid Red'", jobTitle);
            Thread.Sleep(1000);

           // Add assertions to confirm information on the job posting

           // string expectedJobTitle = "Test Automation Engineer";
           // string expectedJobLocation = "Durham";
           // string expectedJobId = "2322968";


           // string expectedJobTitle = jobTitle.FindElement(By.XPath("//h1[@class='job-title' and text()='Test Automation Engineer']")).Text;
           // IWebElement expectedJobLocationlink = driver.FindElement(By.XPath("//button[contains(@class, 'see-multiple-loc-btn') and contains(@aria-label, 'See all')]"));
           // expectedJobLocationlink.Click();
           // Thread.Sleep(2000);
           // string expectedJobLocation = jobTitle.FindElement(By.XPath("//*[contains(text(),'Durham')]")).Text;
           // WebDriverWait record = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // IWebElement closeicon = driver.FindElement(By.XPath("//button[contains(@class, 'close') and contains(@aria-label, 'Close popup')]"));
           // closeicon.Click();

           // Thread.Sleep(1000);
           // button[contains(text(), 'Cancel')]
           // string expectedJobId = jobTitle.FindElement(By.XPath("//*[@data-ph-at-job-id-text='2322968']")).Text;


           // Assert that the job title is correct.
           //Assert.AreEqual("Test Automation Engineer", expectedJobTitle);

           // Assert that the job location is correct.
           //Assert.AreEqual("Durham, North Carolina, United States of America", expectedJobLocation);

           // Assert that the job ID is correct.
           //Assert.AreEqual("2322968", expectedJobId);

        }


         [Then(@"I should see the job details")]
        public void ThenIShouldSeeTheJobDetails()
        {
            Assert.AreEqual("Test Automation Engineer", driver.FindElement(By.XPath("//h1[@class='job-title' and text()='Test Automation Engineer']")).Text);
            IWebElement expectedJobLocationlink = driver.FindElement(By.XPath("//button[contains(@class, 'see-multiple-loc-btn') and contains(@aria-label, 'See all')]"));
            expectedJobLocationlink.Click();
            Thread.Sleep(2000);

           // Assert.AreEqual("Location: Durham", driver.FindElement(By.XPath("//*[contains(text(),'Durham')]")).Text);
           // WebDriverWait record = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement closeicon = driver.FindElement(By.XPath("//button[contains(@class, 'close') and contains(@aria-label, 'Close popup')]"));
            closeicon.Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Job ID: 2322968", driver.FindElement(By.XPath("//*[@data-ph-at-job-id-text='2322968']")).Text);

            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='job-description']//p[contains(text(), 'Promote continuous improvement and improve test cycle duration through the use of testing tools.')]")).Text.Contains("Promote continuous improvement and improve test cycle"));
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='job-description']//p[contains(text(), '5+ years hands-on experience building test automation solutions for UI or service and/or transferrable software development experience')]")).Text.Contains("5+ years hands-on experience building test automation solutions"));
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='job-description']//p[contains(text(), 'Automation tools: Selenium, Cucumber/Gherkin, TestNG, Jenkins/CICD pipeline integration')]")).Text.Contains("Selenium"));
            Thread.Sleep(1000);
            IWebElement Apply = driver.FindElement(By.XPath("//a[@ph-tevent='apply_click']"));
            Apply.Click();
            Thread.Sleep(1000);
            //a[@ph-tevent='apply_click']
        }





    }
}