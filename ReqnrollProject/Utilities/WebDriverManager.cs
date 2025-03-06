using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Utilities
{
    public static class WebDriverManager
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                _ => throw new ArgumentException("Navegador no soportado")
            };


        }

    }
}
