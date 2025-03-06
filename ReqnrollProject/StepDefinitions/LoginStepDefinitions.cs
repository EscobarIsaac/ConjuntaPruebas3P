using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using ReqnrollProject1.Utilities;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extent = new ExtentReports(); // Inicializa _extent antes de usarlo
            var sparkReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("chrome"); // Corrección de sintaxis
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("que el usuario esta en la pagina de login")]
        public void GivenQueElUsuarioEstaEnLaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login"); // URL corregida
            _test.Log(Status.Pass, "Usuario navega al login");
        }

        [When("ingresa el correo {string} y la contraseña {string}")]
        public void WhenIngresaElCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario ingresa correo: {email} y contraseña: {password}");
        }

        [When("hacer click en el boton de inicio de sesión")]
        public void WhenHacerClickEnElBotonDeInicioDeSesion()
        {
            _driver.FindElement(By.Name("loginButton")).Click(); // Asegúrate de que el selector es correcto

            try
            {
                bool isLoggedIn = _driver.FindElement(By.ClassName("user-info")) != null;
                _test.Log(Status.Pass, "Inicio de sesión exitoso");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "Error en inicio de sesión");
            }
        }

        [Then("debería ver un mensaje de error")]
        public void ThenDeberiaVerUnMensajeDeError()
        {
            try
            {
                bool isError = _driver.FindElement(By.ClassName("login_error")) != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostró el mensaje de error");
            }
        }

        [AfterScenario]
        public void Down()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
