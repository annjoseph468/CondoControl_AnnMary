using CondoControl_AnnMary.BaseClass;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoControl_AnnMary.PageClass
{
    public class HomePage : Base
    {
        //Webelements are initialized using page factory
        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }

        //All Webelements used in Home Page
        [FindsBy(How = How.XPath, Using = "//a[@class ='dropmenu' and @href='/my/unit']")]
        private IWebElement myAccountBtn;

        [FindsBy(How = How.Id, Using = "openLanguagePreferences")]
        private IWebElement languagebtn;

        [FindsBy(How = How.Id, Using = "LanguagePreference")]
        private IWebElement languageselectionbtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']/input[@type ='submit' and @class ='btn btn-large btn-primary']")]
        private IWebElement savebtn;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-md-7']/p/a/..")]
        private IWebElement lanuagedisply;


        //clickMyAccountbtn method is for clicking on My Account
        public void clickMyAccountBtn() {
           
            myAccountBtn.Click();
            System.Console.WriteLine("**************** User Clicked on My Account Button ************");
            //Calling clickLanguageBtn method from clickMyAccountbtn method
            clickLanguageBtn();
            

        }
        //clickLanguageBtn method is for updating the language preference
        public void clickLanguageBtn()
        {
            String parentWindow = driver.CurrentWindowHandle;
            languagebtn.Click();
            //Used Window Handle for new pop up window
            String childWindow = driver.CurrentWindowHandle;

            driver.SwitchTo().Window(childWindow);
            //Method in SelectElement class- 'SelectByValue' is used to select the Preffered language Test English
            SelectElement select = new SelectElement(languageselectionbtn);

            select.SelectByValue("qps-ploc");
            //After language selection clicking on save button
            savebtn.Click();

            System.Console.WriteLine("**************** User updated Language to Test English ************");
            Thread.Sleep(2000);
            //Switching back to parentwindow
            driver.SwitchTo().DefaultContent();
            //Validating if Test English is selected
            Assert.IsTrue(lanuagedisply.Displayed,"Element not displayed");

        }
    }
}
