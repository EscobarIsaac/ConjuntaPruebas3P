using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
namespace TestingCliente
{
    public class UnitTest1 : IDisposable
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;


        public UnitTest1()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
            //options.AddArgument("--user-data-dir=C:\\ruta\\ale\\nuevo\\perfil");
           // options.AddArgument("--profile-directory=TestProfile");

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.End);
        }


        [Fact]
        public void Test_Form_Vacio()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);

            var submitButton = _driver.FindElement(By.Id("submit"));
            submitButton.SendKeys(Keys.PageDown);
            submitButton.Click();
            Thread.Sleep(3000);

            var firstName = _driver.FindElement(By.Id("firstName"));
            string color = firstName.GetCssValue("border-color");
            Assert.True(color == "rgb(220, 53, 69)", "El borde del campo 'firstName' no es rojo.");

            Thread.Sleep(1000);

            var lastName = _driver.FindElement(By.Id("lastName"));
            color = lastName.GetCssValue("border-color");
            Assert.True(color == "rgb(220, 53, 69)", "El borde del campo 'lastName' no es rojo.");

            Thread.Sleep(1000);

            var userEmail = _driver.FindElement(By.Id("userEmail"));
            color = userEmail.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'userEmail' no es verde.");

            Thread.Sleep(1000);

            var userNumber = _driver.FindElement(By.Id("userNumber"));
            color = userNumber.GetCssValue("border-color");
            Assert.True(color == "rgb(220, 53, 69)", "El borde del campo 'userNumber' no es rojo.");

            Thread.Sleep(1000);

            var dateOfBirthInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            color = dateOfBirthInput.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'dateOfBirthInput' no es verde.");

            Thread.Sleep(1000);

            var currentAddress = _driver.FindElement(By.Id("currentAddress"));
            color = currentAddress.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'currentAddress' no es verde.");
        }




        [Fact]
        public void Test_Form_Incorrecto()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);

            string color;

            var firstName = _driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Kevin");

            Thread.Sleep(1000);

            var lastName = _driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Coloma");

            Thread.Sleep(1000);

            var userEmail = _driver.FindElement(By.Id("userEmail"));
            userEmail.SendKeys("c.c.c");

            Thread.Sleep(1000);

            var gender_radio_1 = _driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
            gender_radio_1.Click();

            var gender_radio_2 = _driver.FindElement(By.CssSelector("label[for='gender-radio-2']"));

            var gender_radio_3 = _driver.FindElement(By.CssSelector("label[for='gender-radio-3']"));

            Thread.Sleep(1000);

            var userNumber = _driver.FindElement(By.Id("userNumber"));
            userNumber.SendKeys("12345");

            Thread.Sleep(1000);

            var dateOfBirthInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            dateOfBirthInput.SendKeys("");

            Thread.Sleep(1000);

            var hobbies_checkbox_1 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
            hobbies_checkbox_1.Click();

            var hobbies_checkbox_2 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']"));
            hobbies_checkbox_2.Click();

            var hobbies_checkbox_3 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']"));

            Thread.Sleep(1000);

            var currentAddress = _driver.FindElement(By.Id("currentAddress"));
            currentAddress.SendKeys("Quito,Chillogallo");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);

            color = firstName.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'firstName' no es verde.");

            color = lastName.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'lastName' no es verde.");

            color = userEmail.GetCssValue("border-color");
            Assert.True(color == "rgb(220, 53, 69)", "El borde del campo 'userEmail' no es rojo.");

            color = userNumber.GetCssValue("border-color");
            Assert.True(color == "rgb(220, 53, 69)", "El borde del campo 'userNumber' no es rojo.");

            color = dateOfBirthInput.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'dateOfBirthInput' no es verde.");

            color = currentAddress.GetCssValue("border-color");
            Assert.True(color == "rgb(40, 167, 69)", "El borde del campo 'currentAddress' no es verde.");

            var confirmacion = _driver.FindElements(By.ClassName("modal-content"));
            Assert.False(confirmacion.Count > 0, "Se envio el formulario.");

            Thread.Sleep(3000);
        }



        [Fact]
        public void Test_Form_Correcto()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(3000);

            _driver.FindElement(By.Id("firstName")).SendKeys("Kevin");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("lastName")).SendKeys("Coloma");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("userEmail")).SendKeys("Kevin@hotmail.com");

            Thread.Sleep(1000);

            var gender_radio_1 = _driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
            gender_radio_1.Click();

            var gender_radio_2 = _driver.FindElement(By.CssSelector("label[for='gender-radio-2']"));

            var gender_radio_3 = _driver.FindElement(By.CssSelector("label[for='gender-radio-3']"));

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("userNumber")).SendKeys("0989562378");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("userNumber")).SendKeys("0989562378");

            Thread.Sleep(1000);

            var hobbies_checkbox_1 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
            hobbies_checkbox_1.Click();

            var hobbies_checkbox_2 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']"));
            hobbies_checkbox_2.Click();

            var hobbies_checkbox_3 = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']"));

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("currentAddress")).SendKeys("Santa Monica,Conocoto");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);

            var modalTitle = _wait.Until(d => d.FindElement(By.Id("example-modal-sizes-title-lg")));

            Assert.True(modalTitle.Displayed, "El modal no está visible en la página.");

            Thread.Sleep(2000);

        }




        [Theory]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("test@empresa.com", true)]
        [InlineData("correo@.prueba.com", true)] //deberia se invalido
        [InlineData("test@organizacion.com", true)]
        [InlineData("sin_arrobanicomcom", false)]
        public void Test_Maill_Pgina(string email, bool esperado)
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            Thread.Sleep(1000);

            string color;


            var userEmail = _driver.FindElement(By.Id("userEmail"));
            userEmail.SendKeys(email);



            Thread.Sleep(5000);

            var submitButton = _driver.FindElement(By.Id("submit"));
            submitButton.SendKeys(Keys.PageDown);
            submitButton.Click();
            Thread.Sleep(5000);


            color = userEmail.GetCssValue("border-color");

            bool valido;

            if (color == "rgb(40, 167, 69)")
            {
                valido = true;
            }
            else
            {
                valido = false;
            }

            Assert.Equal(esperado, valido);

        }




        [Theory]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("test@empresa.com", true)]
        [InlineData("correo@.prueba.com", false)]
        [InlineData("test@organizacion.com", true)]
        [InlineData("sin_arrobanicomcom", false)]
        public void Test_Mail_Codigo(string email, bool esperado)
        {
            bool resultado = Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Thread.Sleep(5000);
            Assert.Equal(esperado, resultado);
        }


        [Theory]
        [InlineData("1703102135", true)]
        [InlineData("170372", false)]
        [InlineData("1704240982", false)]
        [InlineData("1414344544", false)]
        [InlineData("1707830228", true)]
        [InlineData("17039014", false)]
        [InlineData("1723342224043", false)]
        public void Test_Cedula(string cedula, bool esperado)
        {



            bool resultado = EsCedulaValida(cedula);
            Thread.Sleep(5000);
            Assert.Equal(esperado, resultado);
        }

        private static bool EsCedulaValida(string cedula)
        {
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                return false;
            }

            int provincia = int.Parse(cedula.Substring(0, 2));
            if ((provincia < 1 || provincia > 24) && provincia != 30)
            {
                return false;
            }

            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;
            for (int i = 0; i < coeficientes.Length; i++)
            {
                int valor = coeficientes[i] * int.Parse(cedula[i].ToString());
                suma += valor >= 10 ? valor - 9 : valor;
            }

            int digitoVerificador = int.Parse(cedula[9].ToString());
            int residuo = suma % 10;
            int resultado = residuo == 0 ? 0 : 10 - residuo;
            return resultado == digitoVerificador;
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}