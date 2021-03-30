using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LidijaSportVision
{
    class HelperLidija
    {
        #region Metode za klik

        public void simpleClick(IWebElement element)
        {
            element.Click();
        }
        public void javaScriptClick(ChromeDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jse = driver;
            jse.ExecuteScript("arguments[0].click()", element);
        }
        public void actionsClick(ChromeDriver x, IWebElement element)
        {
            Actions action = new Actions(x);
            action.MoveToElement(element).Click().Build().Perform();
        }
        #endregion
        #region Metode za unos teksta

        public void unos(IWebElement element, string unos)
        {
            element.SendKeys(unos);
        }
        public void sporijiUnos(IWebElement element, string unos)
        {
            //unos => "milos3773@gmail.com"
            List<char> slova = new List<char>(); //prazna lista
            foreach(char c in unos)
            {
                slova.Add(c);
            }
            //sta je "c" u prvoj iteraciji foreach-a? c = "m"
            //ovde imamo listu "slova" popunjenu na sl.nacin:
            //"m","i","l","o","s","3","7","7","3","@","g","m","a","i","l",".","c","o","m"

            Random random = new Random();
            for(int i=0; i<slova.Count; i++)
            {
                //element.SendKeys(neki string) => sluzi da u neki "element" unese taj neki string
                element.SendKeys(slova[i].ToString()); //m
                int nasumicanBroj = random.Next(300, 700);
                Thread.Sleep(nasumicanBroj);
            }
        }

        #endregion
        #region Metode za selektovanje u listi
        public void SelektujPoTekstu(IWebElement element, string tekst)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(tekst);
            /*
             Ako imamo u html-u
             Drzava:
             <select>
             <option>Srbija</option>
             <option>Makedonija</option>
             <option>Engleska</option>
            </select>

            selektujPoTekstu(element,"Srbija");
            selenium ce selektovati option koji ima taj tekst
             */
        }
            public void selektujPoIndeksu(IWebElement element, int index)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByIndex(index);
        }

        public void selektujPoVrednosti(IWebElement element, string value)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByValue(value);
            //<option value=21319>Beograd</option> ->value atribut
        }
        #endregion
    }
}
