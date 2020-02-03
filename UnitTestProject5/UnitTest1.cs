using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using UnitTestProject5;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;


namespace Stumped2
{
    class ImagesList
    {
        public string IMAGE { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver driver;
        private object extent;
       

        [TestMethod]
        public void TestMethod1()
        {

            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter =  new ExtentHtmlReporter("./ReportsHomepage/reports.html");
            
            var extend = new ExtentReports();

            extend.AttachReporter(reporter);

            var test = extend.CreateTest("stumped");

            IWebDriver driver = new ChromeDriver();

            //driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(60));
          
            driver.Navigate().GoToUrl("https://www.sportsadda.com/");

            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("cookiebtn")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//div[@class='close']")).Click();
            Thread.Sleep(2000);
  
            string handle = driver.CurrentWindowHandle;
           
            FunctionalLib.MouseOver(driver, "/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/a");

            for (int i = 2; i <= 4; i++)
            {
                FunctionalLib.clickAction(driver, "/html/body/div[1]/header/section[1]/div/div[2]/div[2]/nav/ul/li[" + i + "]/a/span", "xpath");
              
                Thread.Sleep(2000);

                string title = driver.FindElement(By.XPath("/html/body/div[1]/header/section[1]/div/div[2]/div[2]/nav/ul/li[" + i + "]/a/span")).Text;
        
                Console.WriteLine(title);
                if (title.Contains("Cricket"))

                {
                    for (int j = 2; j <= 7; j++)
                    {
                        FunctionalLib.clickAction(driver, "/html/body/div[1]/header/section[2]/div/div[2]/nav/ul/li[" + j + "]/a", "xpath");
                        Thread.Sleep(2000);
                        string title2 = driver.FindElement(By.XPath("/html/body/div[1]/header/section[2]/div/div[2]/nav/ul/li[" + j + "]/a")).Text;
                        Console.WriteLine(title2);
                        test.Log(Status.Pass, title2);

                    }

                }
                if (title.Contains("Football"))

                {
                    for (int k = 2; k <= 8; k++)
                    {

                        FunctionalLib.clickAction(driver, "/html/body/div[1]/header/section[3]/div/div[2]/nav/ul/li[" + k + "]/a", "xpath");

                        Thread.Sleep(2000);
                        string title3 = driver.FindElement(By.XPath("/html/body/div[1]/header/section[3]/div/div[2]/nav/ul/li[" + k + "]/a")).Text;
                        Console.WriteLine(title3);
                        test.Log(Status.Pass, title3);


                        if (title3.Equals("Score Predictor"))
                            {
                            driver.Navigate().Back();

                        }
                    }

                }

                if (title.Contains("Kabaddi"))

                {
                    for (int a = 2; a <= 8; a++)
                    {
                        FunctionalLib.clickAction(driver, "/html/body/div[1]/header/section[4]/div/div[2]/nav/ul/li[" + a + "]/a", "xpath");
                        Thread.Sleep(2000);
                        string title4 = driver.FindElement(By.XPath("/html/body/div[1]/header/section[4]/div/div[2]/nav/ul/li[" + a + "]/a")).Text;
                        Console.WriteLine(title4);
                        test.Log(Status.Pass, title4);
                    }

                }
            }
  
            extend.Flush();

        }


        [TestMethod]
        public static void onetimesetup()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.sportsadda.com/");

            driver.Manage().Window.Maximize();



            driver.FindElement(By.Id("cookiebtn")).Click();
            Thread.Sleep(2000);


            driver.FindElement(By.XPath("/html/body/div[1]/footer/section/div[2]/div/div[2]/div[2]/div/div[2]/span[2]")).Click();
            Thread.Sleep(2000);

            FunctionalLib.clickAction(driver, "identifierId", "Id");

            driver.FindElement(By.Id("identifierId")).SendKeys("testerppsi9@gmail.com");


            //click on nextbutton
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(4000);

            //pwdfield
            FunctionalLib.TypeAction(driver, "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input", "xpath", "ppsi1234");

            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(5000);
        }
        public void Homepage()

        {
            onetimesetup();

            //Homepage
            for (int i = 1; i <= 12; i++)
            {
                FunctionalLib.MouseOver(driver, "/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[" + i + "]/div/div/div[1]/div/a");
                Thread.Sleep(2000);
                FunctionalLib.clickAction(driver, "/html/body/div[1]/div/myapp/section[3]/div/div/div/div[1]/div/section[" + i + "]/div/div/div[1]/div/a", "xpath");
                driver.Navigate().Back();

            }
        }

        [TestMethod]

        public void Cricket()
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("./ReportsCricket/reports.html");

            var extend = new ExtentReports();

            extend.AttachReporter(reporter);

            var test = extend.CreateTest("stumped");

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.sportsadda.com/");

            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("cookiebtn")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@class='close']")).Click();


            /*driver.FindElement(By.XPath("/html/body/div[1]/footer/section/div[2]/div/div[2]/div[2]/div/div[2]/span[2]")).Click();
            Thread.Sleep(2000);

            FunctionalLib.clickAction(driver, "identifierId", "Id");

            driver.FindElement(By.Id("identifierId")).SendKeys("testerppsi9@gmail.com");

            //click on nextbutton
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(4000);

            //pwdfield
            FunctionalLib.TypeAction(driver, "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input", "xpath", "ppsi1234");

            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(5000);*/

     

            driver.FindElement(By.XPath("//*[@id='c1330d14-5a19-479b-b72b-e1c649a7fff6']/div/div[2]/div[2]/nav/ul/li[2]/a/span")).Click();
            Thread.Sleep(2000);


            FunctionalLib.Scrollto(driver, "/html/body/div[1]/div/myapp/section[3]/div/div/div/div/section/div/div/div[1]/div/a");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[1]/header/section[2]/div/div[2]/nav/ul/li[1]/a")).Click();
            Thread.Sleep(1000);

            var Cv = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div/section/div/div/div[1]/div/h2")).Text;
            var Cn = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[2]/div/div/div[1]/div/h2")).Text;
            var Cf = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[3]/div/div/div[1]/div/h2")).Text;
            var Co = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[4]/div/div/div[1]/div/h2")).Text;
            var Cs = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[5]/div/div/div[1]/div/h2")).Text;


            test.Log(Status.Pass, "Cricket Videos");

            for (int j = 2; j <= 5; j++)
            {
                Thread.Sleep(1000);

                FunctionalLib.Scrollto(driver, "/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[" + j + "]/div/div/div[1]/div/a");
                Thread.Sleep(1000);

                driver.Navigate().Back();
                if (Cn.Equals("Cricket News"))
                {

                    if (j == 2)
                    {
                        test.Log(Status.Pass, "Cricket News");

                    }
                }

                if (Cf.Equals("Cricket Features"))
                {

                    if (j == 3)
                    {
                        test.Log(Status.Pass, "Cricket Features");

                    }
                }

                if (Co.Equals("Cricket Opinions"))
                {

                    if (j == 4)
                    {
                        test.Log(Status.Pass, "Cricket Opinions");

                    }
                }

                if (Cs.Equals("Cricket Social Buzz"))
                {
                    if (j == 5)
                    {
                        test.Log(Status.Pass, "Cricket Social Buzz");

                    }
                }

            }
            extend.Flush();
        }

        [TestMethod]
        public void Football()
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("./ReportsFootball/reports.html");

            var extend = new ExtentReports();

            extend.AttachReporter(reporter);

            var test = extend.CreateTest("stumped");

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.sportsadda.com/");

            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("cookiebtn")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[1]/footer/section/div[2]/div/div[1]")).Click();


            /*driver.FindElement(By.XPath("/html/body/div[1]/footer/section/div[2]/div/div[2]/div[2]/div/div[2]/span[2]")).Click();
            Thread.Sleep(2000);

            FunctionalLib.clickAction(driver, "identifierId", "Id");

            driver.FindElement(By.Id("identifierId")).SendKeys("testerppsi9@gmail.com");

            //click on nextbutton
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(5000);

            //pwdfield
            FunctionalLib.WaitforElement(driver, "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input");

            FunctionalLib.TypeAction(driver, "/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input", "xpath", "ppsi1234");
            

            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/span/span")).Click();
            Thread.Sleep(5000);*/

            driver.FindElement(By.XPath("//*[text()='Football']")).Click();
            Thread.Sleep(2000);

            FunctionalLib.Scrollto(driver, "//*[text()=' View More ']//parent::div[@class='head-wrap' ]//h2[text()='Football Videos']");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[1]/header/section[3]/div/div[2]/nav/ul/li[1]/a")).Click();
            Thread.Sleep(1000);

            var Fv = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div/section/div/div/div[1]/div/h2")).Text;
            var Fn = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[5]/div/div/div[1]/div/h2")).Text;
            var Ff = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[6]/div/div/div[1]/div/h2")).Text;
            var Fo = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[7]/div/div/div[1]/div/h2")).Text; ;
            var Fs = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[8]/div/div/div[1]/div/h2")).Text;


            test.Log(Status.Pass, "Football Videos");


            for (int k = 5; k <= 8; k++)
            {
                Thread.Sleep(1000);

                FunctionalLib.Scrollto(driver, "/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[" + k + "]/div/div/div[1]/div/a");
                Thread.Sleep(1000);

                driver.Navigate().Back();



                if (Fn.Equals("Football News"))
                {
                    if (k == 5)
                    {
                        test.Log(Status.Pass, "Football News");
                    }
                }

                if (Ff.Equals("Football Features"))
                {
                    if (k == 6)
                    {
                        test.Log(Status.Pass, "Football Features");
                    }
                }

                if (Fo.Equals("Football Opinions"))
                {

                    if (k == 7)
                    {
                        test.Log(Status.Pass, "Football Opinions");
                    }
                }

                if (Fs.Equals("Football Social Buzz"))
                {
                    if (k == 8)
                    {
                        test.Log(Status.Pass, "Football Social Buzz");
                    }
                }
            }

            extend.Flush();
        }   
            
        [TestMethod]
        public void Kabaddi()
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("./ReportsKabaddi/reports.html");

            var extent = new ExtentReports();
            extent.AttachReporter(reporter);
            string hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;

            extent.AddSystemInfo("Operating System:", os.ToString());
            extent.AddSystemInfo("HostName:", hostname);
            extent.AddSystemInfo("Browser:", "Chrome");
            extent.AddSystemInfo("Website:", "Stumped");

            var test = extent.CreateTest("Stumped Kabaddi");

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.sportsadda.com/");

            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("cookiebtn")).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//div[@class='close']")).Click();

           
            driver.FindElement(By.XPath("//a[@title='Kabaddi']")).Click();
            Thread.Sleep(2000);

            FunctionalLib.Scrollto(driver, "//a[text()=' View More ']//parent::div[@class= 'head-wrap']//h2[text()='Kabaddi Videos']");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[1]/header/section[4]/div/div[2]/nav/ul/li[1]/a")).Click();
            Thread.Sleep(1000);
            try
            {
                var Kv = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[3]/div/div/div/div/section/div/div/div[1]/div/h2")).Text;
                var Kn = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[1]/div/div/div[1]/div/h2")).Text;
                var Kf = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[2]/div/div/div[1]/div/h2")).Text;
                var Ko = driver.FindElement(By.XPath("/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[3]/div/div/div[1]/div/h2")).Text;


                test.Log(Status.Pass, "Kabaddi Videos");

                for (int a = 1; a <= 3; a++)
                {
                    Thread.Sleep(1000);

                    FunctionalLib.Scrollto(driver, "/html/body/div[1]/div/myapp/section[4]/div/div/div/div[1]/div/section[" + a + "]/div/div/div[1]/div/a");
                    Thread.Sleep(1000);

                    driver.Navigate().Back();

                    if (Kn.Equals("Kabaddi News"))
                    {

                        if (a == 1)
                        {
                            test.Log(Status.Pass, "Kabaddi News");

                        }
                    }

                    if (Kf.Equals("Kabaddi Features"))
                    {

                        if (a == 2)
                        {
                            test.Log(Status.Pass, "Kabaddi Features");

                        }
                     

                    }

                    if (Ko.Equals("Kabaddi Opinions"))
                    {

                        if (a == 3)
                        {
                            test.Log(Status.Pass, "Kabaddi Opinions");

                        }
                    }
                }
            }
      
            catch(Exception)
            {
          Screenshot ss= ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile(@"C:\Users\shweta\source\Git\stumpedsanity\UnitTestProject5\Screenshot\\" + imgName +".png");



                test.Log(Status.Fail,driver.Title+ "Test case failed");
            }

            extent.Flush();
        }

        [TestMethod]
        public void BrokenImage()
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("./ReportsBrokenImage/reports.html");

            var extend = new ExtentReports();

            extend.AttachReporter(reporter);

            var test = extend.CreateTest("stumped");

            IWebDriver driver = new ChromeDriver();

            for (int k = 2; k <= 9; k++)
            {

                string url = FunctionalLib.ReadDataExcel(1, k, 1);

                driver.Navigate().GoToUrl(url);

                driver.Manage().Window.Maximize();
                int sum = (int)(driver.FindElements(By.TagName("img"))).Count;

                Console.WriteLine(sum);
                var Imageslist = new List<ImagesList>();
                var allImages = driver.FindElements(By.TagName("img"));
                foreach (var img in allImages)
                {
                    var imgSrc = img.GetAttribute("src");
                    Imageslist.Add(new ImagesList { IMAGE = imgSrc });
                    NUnit.Framework.TestContext.Out.WriteLine($"IMAGE:{imgSrc}");
                }
                foreach (var i in Imageslist)
                {
                    var link = i.IMAGE.ToString();

                    if (link == "")
                    {
                        Console.WriteLine("src empty");
                    }
                    else
                    {
                        string brokenlink = link.Substring(8, 2);
                        if (brokenlink.Equals("s3"))
                        {
                            Console.WriteLine(link);
                        }
                    }
                    test.Log(Status.Pass,driver.Title);

                    extend.Flush();
                }

            }
           
        }
       

    }
}


    



    



    


