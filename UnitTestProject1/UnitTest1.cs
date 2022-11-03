using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DemoQATextBox()
        {
            ChromeDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/");
            IWebElement el1 = cd.FindElement(By.ClassName("card-up"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)cd;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", el1);
            el1.Click();

            IWebElement testBoxButton = cd.FindElement(By.Id("item-0"));
            testBoxButton.Click();
            IWebElement name = cd.FindElement(By.Id("userName"));
            name.SendKeys("Squiddy Luna");
            IWebElement email = cd.FindElement(By.Id("userEmail"));
            email.SendKeys("rimapanja@gmail.com");
            IWebElement currentAddress = cd.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys("Kolkata");
            IWebElement permanentAddress = cd.FindElement(By.Id("permanentAddress"));
            permanentAddress.SendKeys("Kolkata");

            IWebElement submitButton = cd.FindElement(By.Id("submit"));
            //Actions action = new Actions(cd);
            //action.MoveToElement(el).Perform(); // move to the button
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)cd; 
            js1.ExecuteScript("arguments[0].scrollIntoView(true);", submitButton); //move or scroll into view the required button
            submitButton.Click();
        }

        [TestMethod]
        public void CheckBox()
        {
            ChromeDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/checkbox");
            IWebElement checkboxHome = cd.FindElement(By.ClassName("rct-checkbox"));
            checkboxHome.Click();
        }

        [TestMethod]
        public void RadioButton()
        {
            ChromeDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/radio-button");
            IList<IWebElement> radioButton = cd.FindElements(By.ClassName("custom-control-label"));
            radioButton.ElementAt(0).Click(); //To click first radio button
            radioButton.ElementAt(1).Click(); // To click second radio button

        }

        [TestMethod]
        public void StringBuilderDemo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hello, I am Rima");
            System.IO.File.WriteAllText(@"C:\Users\HP\source\repos\UnitTestProject1\UnitTestProject1\bin\Debug\stringdemo.txt", sb.ToString());
        }

        [TestMethod]
        public void BrowserWindows()
        {
            IWebDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            // It will return the parent window name as a String
            String parent = cd.CurrentWindowHandle;
            cd.FindElement(By.Id("tabButton")).Click();
            cd.SwitchTo().Window(parent);
            cd.FindElement(By.Id("windowButton")).Click();
            cd.SwitchTo().Window(parent);
            cd.FindElement(By.Id("messageWindowButton")).Click();
        }

        [TestMethod]
        public void AlertsWindows()
        {
            IWebDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/alerts");
            
            cd.FindElement(By.Id("alertButton")).Click();
            
            cd.SwitchTo().Alert().Accept();
            Console.WriteLine("Ok is selected");


            cd.FindElement(By.Id("timerAlertButton")).Click();
            Thread.Sleep(5000);
            cd.SwitchTo().Alert().Accept();

            cd.FindElement(By.Id("confirmButton")).Click();
            cd.SwitchTo().Alert().Accept();
            Console.WriteLine("Ok is selected");
            cd.FindElement(By.Id("confirmButton")).Click();
            cd.SwitchTo().Alert().Dismiss();
            Console.WriteLine("Cancel is selected");

            cd.FindElement(By.Id("promtButton")).Click();
            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlert = cd.SwitchTo().Alert();
            // '.SendKeys()' to enter the text in to the textbox of alert
            promptAlert.SendKeys("Squiddy Luna");
            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promptAlert.Accept();

        }

        [TestMethod]
        public void FramesHandle()
        {
            IWebDriver cd = new ChromeDriver();
            //one browser window gets opened

            cd.Navigate().GoToUrl("https://demoqa.com/frames");
            cd.SwitchTo().Frame("frame1");
            Console.WriteLine("I am in Frame 1");
            cd.SwitchTo().DefaultContent();
            Console.WriteLine("I am in Main Content");
            cd.SwitchTo().Frame("frame2");
            Console.WriteLine("I am in Frame 2");
        }

        [TestMethod]
        public void CriticalSearch()
        {
            IWebDriver cd = new ChromeDriver();
            cd.Navigate().GoToUrl("https://www.automation.com/");
            cd.FindElement(By.CssSelector("#cookie-alert > div > div > form > input")).Click();
            cd.FindElement(By.LinkText("Products")).Click();
            cd.FindElement(By.CssSelector("#app-1 > div > dynamic-html > div:nth-child(1) > widget > div > dynamic-html > div > div > div > div:nth-child(1) > div > label")).SendKeys("Weidmuller");
            cd.FindElement(By.CssSelector("#app-1 > div > dynamic-html > div:nth-child(1) > widget > div > dynamic-html > div > div > div > div:nth-child(1) > div > input")).Click();

            Thread.Sleep(9000);
           // IJavaScriptExecutor js2 = (IJavaScriptExecutor)cd;
            //js2.ExecuteScript("window.scrollBy(0,500)");
            IList<IWebElement> bakeries = cd.FindElements(By.ClassName("sj-rs-item"));

            Console.WriteLine(bakeries.Count);
            for(int i=0; i<bakeries.Count; i++)
            {
                Console.WriteLine(i + " " + bakeries.ElementAt(i).Text.Contains("Weidmuller"));
            }
            

    }

    }
}
