using CondoControl_AnnMary.PageClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CondoControl_AnnMary.BaseClass
{
    public class Base
    {
        //Initializing the webdriver object
        public static IWebDriver driver;
                
        //Using Setup attribute the method initBrowser will execute before each test case
        [SetUp]
       
        public void initBrowser() {
            //Initialiazing the Chromedriver. When using Webdriver Manager no need to update the chromeversion everytime
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //Maximizing the window
            driver.Manage().Window.Maximize();
            //Adding wait events to load page and elements
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        }
       
        //Navigating to URL.
        public static LoginPage openApplication(String url)
        {
            driver.Navigate().GoToUrl(url);
            return new LoginPage();
        }
        //Valiadting the Page title using Assert class function.
        public static void getTitle(string expectedtitle)
        {
            Assert.That(driver.Title, Does.Contain(expectedtitle));
            System.Console.WriteLine("**************** Page Title Verified ************");
        }
        //Using TearDown attribute the method tearDownBrowser will execute after each test case
        [TearDown] 
        public void tearDownBrowser() { 
        driver.Quit();
        }
    }
}
