using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LidijaSportVision
{
    class sportVision
    {
        #region Polja
        private ChromeDriver driver;
        private string adresa;
        private Dictionary<string, string> testPodaci;
        private HelperLidija helper;
        #endregion
        #region Konstruktori
        public sportVision()
        {
            driver = new ChromeDriver();
            adresa = "http://sportvision.rs";
            helper = new HelperLidija();
            testPodaci = new Dictionary<string, string>();
            testPodaci.Add("ime", "Jovana");
            testPodaci.Add("prezime", "Petrovic");
            testPodaci.Add("email", "lidaveljkovic@gmail.com");
            testPodaci.Add("telefon", "0642155789");
            testPodaci.Add("grad", "Beograd");
            testPodaci.Add("postanskiBroj", "11185");
            testPodaci.Add("ulica","Banatska");
            testPodaci.Add("brojUlice","24");
            testPodaci.Add("lozinka", "provera959");
            testPodaci.Add("antiSpam", "7");
            
        }
        #endregion

        public void otvoriStranicuIModal()
        {
            driver.Url = adresa;

            IWebElement link = driver.FindElement(By.XPath("/html/body/header/div[1]/div/div[2]/div[2]/div/nav[2]/ul/li[2]/a"));
            Thread.Sleep(5000);
            link.Click();

        }   
        public void popuniFormular()
        {
            IWebElement ime = driver.FindElement(By.Id("reg_firstname"));
            IWebElement prezime = driver.FindElement(By.Id("reg_lastname"));
            IWebElement email = driver.FindElement(By.Id("reg_email"));
            IWebElement telefon = driver.FindElement(By.Id("reg_phone"));
            IWebElement grad = driver.FindElement(By.Id("reg_city"));
            IWebElement postanskiBroj = driver.FindElement(By.Id("reg_postcode"));
            IWebElement ulica = driver.FindElement(By.Id("reg_address"));
            IWebElement brojUlice = driver.FindElement(By.Id("reg_street_no"));
            IWebElement lozinka = driver.FindElement(By.Id("reg_password"));
            IWebElement ponoviteLozinku = driver.FindElement(By.Id("reg_password_repeat"));

            IWebElement zensko = driver.FindElement(By.Id("reg_gender_2"));
            IWebElement antiSpam = driver.FindElement(By.Id("reg_anti"));
            IWebElement uslovi = driver.FindElement(By.Id("reg_confirm"));
            IWebElement registracija = driver.FindElement(By.Name("back_url"));

            helper.unos(ime, testPodaci["ime"]);
            helper.unos(prezime, testPodaci["prezime"]);
            helper.unos(email, testPodaci["email"]);
            helper.sporijiUnos(telefon, testPodaci["telefon"]);
            helper.unos(grad, testPodaci["grad"]);
            helper.unos(ulica, testPodaci["ulica"]);
            helper.unos(brojUlice, testPodaci["brojUlice"]);
            helper.unos(lozinka, testPodaci["lozinka"]);
            helper.sporijiUnos(postanskiBroj, testPodaci["postanskiBroj"]);
            helper.unos(ponoviteLozinku, testPodaci["lozinka"]);
            helper.javaScriptClick(driver, zensko);
            helper.selektujPoVrednosti(antiSpam,testPodaci["antiSpam"]);
            helper.javaScriptClick(driver, uslovi);
            helper.javaScriptClick(driver, registracija);

        }     
    }
}
