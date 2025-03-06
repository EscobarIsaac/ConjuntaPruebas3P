using System;
using Xunit;
using Reqnroll;
using TDD.Models;
using TDD.Data;


namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class CrearStepDefinitions
    {
        private Cliente _cliente = new Cliente();
        private readonly ClienteDataAccessLayer _servicioCliente = new ClienteDataAccessLayer();




        [Given("la cedula {string}")]
        public void GivenLaCedula(string cedula)
        {
            _cliente.Cedula = cedula;
        }

        [Given("los apellidos {string}")]
        public void GivenLosApellidos(string apellidos)
        {
            _cliente.Apellidos = apellidos;
        }

        [Given("los nombres {string}")]
        public void GivenLosNombres(string nombres)
        {
            _cliente.Nombres = nombres;
        }

        [Given("la fecha de nacimiento {string}")]
        public void GivenLaFechaDeNacimiento(string fechaNacimiento)
        {
            _cliente.FechaNacimiento = DateTime.Parse(fechaNacimiento);
        }

        [Given("el mail {string}")]
        public void GivenElMail(string mail)
        {
            _cliente.Mail = mail;
        }

        [Given("el telefono {string}")]
        public void GivenElTelefono(string telefono)
        {
            _cliente.Telefono = telefono;
        }

        [Given("la direccion {string}")]
        public void GivenLaDireccion(string direccion)
        {
            _cliente.Direccion = direccion;
        }

        [Given("el estado es {string}")]
        public void GivenElEstadoEsTrue(string estado)
        {
            _cliente.Estado = estado.ToLower() == "true";
        }


        [When("se registra el usuario")]
        public void WhenSeRegistraElUsuario()
        {
            _servicioCliente.AddCliente(_cliente);
        }

        [Then("el usuario debe ser creado exitosamente")]
        public void ThenElUsuarioDebeSerCreadoExitosamente()
        {
            List<Cliente> clientes = _servicioCliente.getAllClientes();

            Cliente? usuarioCreado = clientes.FirstOrDefault(c => c.Cedula == _cliente.Cedula);

            _cliente.Cedula.CompareTo(usuarioCreado.Cedula);
            _cliente.Apellidos.CompareTo(usuarioCreado.Apellidos);
            _cliente.Nombres.CompareTo(usuarioCreado.Nombres);
            _cliente.FechaNacimiento.CompareTo(usuarioCreado.FechaNacimiento);
            _cliente.Mail.CompareTo(usuarioCreado.Mail);
            _cliente.Telefono.CompareTo(usuarioCreado.Telefono);
            _cliente.Direccion.CompareTo(usuarioCreado.Direccion);
            _cliente.Estado.CompareTo(usuarioCreado.Estado);
        }
    }
}