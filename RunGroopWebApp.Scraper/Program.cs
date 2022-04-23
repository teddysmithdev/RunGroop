// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Scraper.Interfaces;
using RunGroopWebApp.Scraper.Services;



MeetupScraper scraper = new MeetupScraper();
scraper.Run();

//AtraScraper scraper = new AtraScraper();


//scraper.Run();