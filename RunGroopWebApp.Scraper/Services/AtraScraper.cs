using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RunGroopWebApp.Data;
using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Scraper.Data;
using RunGroopWebApp.Scraper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroopWebApp.Scraper.Services
{
    public class AtraScraper : IAtraScraper
    {
        private IRaceRepository _raceRepo;
        private IWebDriver _driver;
        public AtraScraper()
        {
            _driver = new ChromeDriver();
        }

        public void Run()
        {
            IterateOverElements();
        }

        public IReadOnlyCollection<IWebElement> GetElements()
        {
            _driver.Navigate().GoToUrl("https://trailrunner.com/race-calendar/");
            return _driver.FindElements(By.CssSelector("span[itemprop='name']"));
        }

        public object IterateOverElements()
        {
            var elements = GetElements();
            foreach (var element in elements)
            {
                element.Click();
                var race = new Race()
                {
                    Title = _driver.FindElement(By.CssSelector("h1[class='event-title']")).Text,
                    Description = _driver.FindElement(By.CssSelector("div[class='content-desc']")).Text,
                    StartTime = DateTime.Parse(_driver.FindElement(By.CssSelector("meta[itemprop='startDate']")).Text),
                    EntryFee = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                    Website = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                    Facebook = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                    Contact = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                    Address = new Address()
                    {  
                        City = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                        State = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                        Street = _driver.FindElement(By.CssSelector("span[itemprop='price']")).Text,
                    },
                    RaceCategory = RaceCategory.Ultra
                };
                using (var context = new ScraperDBContext())
                {
                    context.Races.Add(race);
                    context.SaveChanges();
                }
                _driver.Close();
            }
            return "Test";
        }
    }
}
