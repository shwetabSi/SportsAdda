using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UnitTestProject5;

namespace Stumped2
{
    class Homepage
    {
        private IWebDriver driver;



        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        public void NewHomepage()
        {

            string handle = driver.CurrentWindowHandle;

            var comment2 = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/a"));

            //string title = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/h2")).Text;


            var action1 = new OpenQA.Selenium.Interactions.Actions(driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
            action1.MoveToElement(comment2);
            action1.Perform();

            comment2 = new WebDriverWait(driver, new TimeSpan(0, 1, 0))
                        .Until(driver => driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/a")));
            Thread.Sleep(2000);
            comment2.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Window(handle);


            /*if (title.Contains("Cricket News"))

            {
                driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/a")).Click();

            }*/
















        }
    }
}
