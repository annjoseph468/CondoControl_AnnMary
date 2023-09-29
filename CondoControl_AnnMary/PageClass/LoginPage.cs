using CondoControl_AnnMary.BaseClass;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoControl_AnnMary.PageClass
{
    public class LoginPage : Base
    {
        /*For POM model design patttern, using PageFactory, the webelements are initialized using initElements
        method added in Constructor. When object is created the constructor will be called.*/
        public LoginPage() {
            PageFactory.InitElements(driver, this);
        }
        //All Webelements used in Login Page
        [FindsBy(How = How.Id, Using = "Username")]
        private IWebElement userNameElement;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passWordElement;

        [FindsBy(How = How.Id, Using = "loginBtn")]
        private IWebElement loginBtn;

        //Login method is created to pass UserName and password
        public void clickLogin(String username, String password) {
            userNameElement.SendKeys(username);
            passWordElement.SendKeys(password);
            loginBtn.Click();
            System.Console.WriteLine("**************** User Logged in Successfully ************");

        }
    }
}
