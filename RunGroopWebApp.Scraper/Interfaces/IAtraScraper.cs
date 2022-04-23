using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroopWebApp.Scraper.Interfaces
{
    internal interface IAtraScraper
    {
        IReadOnlyCollection<IWebElement> GetElements();
        object IterateOverElements();
        void Run();
    }
}
