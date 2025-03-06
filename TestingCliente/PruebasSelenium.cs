using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestingCliente
{
    public class PruebasSelenium : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string BaseUrl = "http://localhost:5015/Cliente";

        public PruebasSelenium()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void Create_ReturnCreateView()
        {
            _driver.Navigate().GoToUrl("http://localhost:5015/Cliente/Create");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("inputCedula")).SendKeys("1724105661");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputApellidos")).SendKeys("Coloma");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputNombres")).SendKeys("Kevin");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputFechaNacimiento")).SendKeys("01/01/2002");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputMail")).SendKeys("Kevin@gmail.com");
            _driver.FindElement(By.Id("inputTelefono")).SendKeys("0961216222");
            _driver.FindElement(By.Id("inputDireccion")).SendKeys("Ecuador Quito");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("botonGuardar")).Click();
            Thread.Sleep(1000);
            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }

        [Fact]
        public void Test_ActualizarCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);

            var editarBoton = _wait.Until(d => d.FindElement(By.XPath("//a[contains(@href, '/Cliente/Edit')]")));
            editarBoton.Click();

            _wait.Until(d => d.FindElement(By.TagName("form"))); 
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).Clear();
            _driver.FindElement(By.Name("Cedula")).SendKeys("1724105661");
            _driver.FindElement(By.Name("Apellidos")).Clear();
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Coloma");
            _driver.FindElement(By.Name("Nombres")).Clear();
            _driver.FindElement(By.Name("Nombres")).SendKeys("Kevin");
            _driver.FindElement(By.Name("FechaNacimiento")).Clear();
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("02/02/2000");
            _driver.FindElement(By.Name("Mail")).Clear();
            _driver.FindElement(By.Name("Mail")).SendKeys("Kevin.Coloma@example.com");
            _driver.FindElement(By.Name("Telefono")).Clear();
            _driver.FindElement(By.Name("Telefono")).SendKeys("0961216222");
            _driver.FindElement(By.Name("Direccion")).Clear();
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);

            var submitButton = _wait.Until(d => d.FindElement(By.Id("actualizar")));
            Thread.Sleep(1000);
            submitButton.SendKeys(Keys.PageDown);
            submitButton.SendKeys(Keys.PageDown);
            submitButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            submitButton.Click();
            Thread.Sleep(1000);

            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }

        [Fact]
        public void Test_EliminarCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            Thread.Sleep(1000);
            var eliminarBoton = _wait.Until(d => d.FindElement(By.XPath("//a[contains(@href, '/Cliente/Delete')]")));
            Thread.Sleep(1000);
            eliminarBoton.SendKeys(Keys.PageDown);
            eliminarBoton.SendKeys(Keys.PageDown);
            eliminarBoton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            eliminarBoton.Click();


            var confirmDeleteButton = _wait.Until(d => d.FindElement(By.Id("delete-button")));
            Thread.Sleep(1000);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            confirmDeleteButton.Click();
            Thread.Sleep(1000);

            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }
        [Fact]
        public void Test_VerDetallesCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);

            // Buscar y hacer clic en el botón de detalles de un cliente específico
            var detallesBoton = _wait.Until(d => d.FindElement(By.XPath("//a[contains(@href, '/Cliente/Details')]")));
            // Asegurar que el botón sea visible antes de hacer clic
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", detallesBoton);
            detallesBoton.Click();
            // Esperar a que la URL cambie a la de detalles
            _wait.Until(d => d.Url.Contains("/Cliente/Details"));
            Thread.Sleep(3000);


            // Validar que la URL contiene '/Cliente/Details'
            Assert.Contains("/Cliente/Details", _driver.Url);
        }

    }
}
