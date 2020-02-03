using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using excel = Microsoft.Office.Interop.Excel;


namespace UnitTestProject5
{
    class FunctionalLib
    {
        public static void clickAction(IWebDriver driver, string LocaterValue, string LocaterType)
        {
            if (LocaterType == "id")
            {
                driver.FindElement(By.Id(LocaterValue)).Click();

            }
            if (LocaterType == "xpath")
            {
                driver.FindElement(By.XPath(LocaterValue)).Click();
            }
        }

        public static void MouseOver1(IWebDriver driver, string LocaterValue)

        {
            IWebElement element = driver.FindElement(By.XPath(LocaterValue));

            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();
           
        }

        public static void MouseOver(IWebDriver driver, string LocaterValue)
        {
            IWebElement element = driver.FindElement(By.XPath(LocaterValue));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(); ", element);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }


        public static void WaitforElement(IWebDriver driver, string LocaterValue)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocaterValue)));

        }

        
        public static void TypeAction(IWebDriver driver, string LocaterValue, string LocaterType, string Value)
        {
            if (LocaterType == "id")
            {
                driver.FindElement(By.Id(LocaterValue)).Clear();
                driver.FindElement(By.Id(LocaterValue)).SendKeys(Value);
            }
            if (LocaterType == "xpath")
            {
                driver.FindElement(By.XPath(LocaterValue)).Clear();
                driver.FindElement(By.XPath(LocaterValue)).SendKeys(Value);
            }
        }

        
        public static void DragandDrop(IWebDriver driver, string LocaterValue,int i,int j)
        {
            IWebElement element = driver.FindElement(By.XPath(LocaterValue));
            Actions move = new Actions(driver);
            move.DragAndDropToOffset(element, i, j).Perform();
        }

        public static void Scrollto(IWebDriver driver, string LocatorValue)
        {
            var Uploadphotobutton1 = driver.FindElement(By.XPath(LocatorValue));
            var action3 = new Actions(driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
            action3.MoveToElement(Uploadphotobutton1);
            action3.Perform();
            Uploadphotobutton1 = new WebDriverWait(driver, new TimeSpan(0, 1, 0))
                        .Until(driver1 => driver.FindElement(By.XPath(LocatorValue)));
            Uploadphotobutton1.Click();
            Thread.Sleep(5000);
        }

                    
        public static string ReadDataExcel(int S, int i, int j)
        {
            excel.Application xlapp = new excel.Application();
            excel.Workbook xlworkbook = xlapp.Workbooks.Open(@"D:\FindingBrokenImages\TestInput1.xlsx");
            excel._Worksheet xlworksheet = xlworkbook.Sheets[S];
            excel.Range xlrange = xlworksheet.UsedRange;
            string data = xlrange.Cells[i][j].value2;
            return data;


        }

        public static void screenShot(IWebDriver driver)
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("D:\\ISLproject\\ScreenShots\\" + imgName + ".png");
        }

    }
}