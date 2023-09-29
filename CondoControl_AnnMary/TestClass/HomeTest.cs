using CondoControl_AnnMary.BaseClass;
using CondoControl_AnnMary.PageClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoControl_AnnMary.TestClass
{
    public class HomeTest :Base
    {
        LoginPage loginPage;
        HomePage homePage;

        /*Test is created for updating the language preference.
        Parameters are passed using TestCase attribute*/

        [TestCase("chrome", "https://qa.app.condocontrol.com:500/login", "test@user1.com", "123456") ]
        public void updateLanguagePreference(String browser, String url, String userName, String password)
        {
            //Return type of openApplication method is LoginPage. Value stored in loginpage object.
            loginPage = Base.openApplication(url);
            homePage = new HomePage(); 
            //clickLogin Method is called for logging into application
            loginPage.clickLogin(userName, password);
            //Page Title is verified
            Base.getTitle("| Condo Control Central");
            //clickLogin Method is called for updating language preference
            homePage.clickMyAccountBtn();
            

        }
    }
}
