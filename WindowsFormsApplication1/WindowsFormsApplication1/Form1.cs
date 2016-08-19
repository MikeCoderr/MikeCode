using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using OpenQA.Selenium.Interactions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static string con = "";
        static IWebDriver driver;
        static IWebElement element = null;
        static IWebElement finalElement = null;
        static String value1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
                this.WindowState = FormWindowState.Minimized;
                Int16 abc = Convert.ToInt16(textBox1.Text);
                // con = conString();
                driver.Manage().Window.Maximize();
                driver.Url = "https://www.interactivebrokers.com.hk/sso/Login?SERVICE=AM.LOGIN";
                driver.FindElement(By.Id("user_name")).SendKeys("agora105");
                Thread.Sleep(100);
                driver.FindElement(By.Id("password")).SendKeys("98a4ZDf");
                Thread.Sleep(100);
                driver.FindElement(By.Id("submitForm")).Click();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));

                Thread.Sleep(10000);

                Actions a = new Actions(driver);
                for (int i = 0; i <= 100; i++)
                {
                    try
                    {
                        driver.SwitchTo().DefaultContent();
                        driver.SwitchTo().Frame(0);


                        finalElement = driver.FindElement(By.Id("manageClients"));
                        if (finalElement != null)
                        {

                            //element = driver.FindElement(By.Id("manageClients"));

                            //a.MoveToElement(element.FindElements(By.TagName("adf"))[0]);
                            Thread.Sleep(2000);
                            a.MoveToElement(driver.FindElement(By.XPath("//*[@id='manageClients']/a"))).Perform();
                            Thread.Sleep(2000);
                            break;

                        }
                        else
                        {
                            Thread.Sleep(2000);
                        }
                    }
                    catch (Exception ex)
                    {

                        Thread.Sleep(1000);
                        finalElement = null;
                    }

                }

                for (int i = 0; i <= 100; i++)
                {
                    try
                    {

                        finalElement = driver.FindElement(By.XPath("//*[@id='clientFees']/a"));
                        if (finalElement != null)
                        {
                            Thread.Sleep(2000);
                            element = driver.FindElement(By.Id("clientFees"));
                            element.FindElements(By.TagName("a"))[0].Click();
                            Thread.Sleep(2000);
                            element.FindElements(By.TagName("a"))[0].Click();
                            Thread.Sleep(2000);
                            element.FindElements(By.TagName("a"))[0].Click();

                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    catch (Exception ex)
                    {

                        Thread.Sleep(1000);
                        finalElement = null;
                    }

                }





                for (int i = 0; i <= 100; i++)
                {
                    try
                    {

                        finalElement = driver.FindElement(By.Id("feeTemplate"));
                        if (finalElement != null)
                        {
                            element = driver.FindElement(By.Id("feeTemplate"));
                            element.FindElements(By.TagName("a"))[0].Click();
                            break;
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    catch (Exception ex)
                    {

                        Thread.Sleep(1000);
                        finalElement = null;
                    }
                }



               

            }



              
            catch (Exception ex)
            {
                MessageBox.Show("There was some error." + ex);
            }

        }

        public static string conString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            return connectionString;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();
            MessageBox.Show("Good bye");
            Application.Exit();
            driver.Close();
            driver.Quit();
        }
        public static void driverCloseFun()
        {

            DataSet ds = new DataSet();


            driver.Close();
            driver.Quit();
        }

    
    public static string GenerateRandomAlphaNumericCode(int length)
    {
        string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        string randomCode = new string(Enumerable.Repeat(characterSet, length).Select(set => set[random.Next(set.Length)]).ToArray());
        return randomCode;
    }

}
}