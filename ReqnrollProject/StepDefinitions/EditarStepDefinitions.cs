using System;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Reqnroll;
using TDD.Data;
using TDD.Models;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class EditarStepDefinitions
    {
        private Cliente _cliente = new Cliente();
        private readonly ClienteDataAccessLayer _servicioCliente = new ClienteDataAccessLayer();


        [Given("la cedula del anterior usuario {string}")]
        public void GivenlaCedulaDelAnteriorUsuario(string cedulaAnterior)
        {
            List<Cliente> clientes = _servicioCliente.getAllClientes();

            _cliente = clientes.FirstOrDefault(c => c.Cedula == cedulaAnterior);

        }


        [Given("la cedula editar {string}")]
        public void GivenLaCedulaEdiar(string cedula)
        {

            _cliente.Cedula = cedula;
        }

        [Given("los apellidos editar {string}")]
        public void GivenLosApellidosEditar(string apellidos)
        {
            _cliente.Apellidos = apellidos;
        }

        [Given("los nombres editar {string}")]
        public void GivenLosNombresEditar(string nombres)
        {
            _cliente.Nombres = nombres;
        }

        [Given("la fecha de nacimiento editar {string}")]
        public void GivenLaFechaDeNacimientoEditar(string fechaNacimiento)
        {
            _cliente.FechaNacimiento = DateTime.Parse(fechaNacimiento);
        }

        [Given("el mail editar {string}")]
        public void GivenElMailEditar(string mail)
        {
            _cliente.Mail = mail;
        }

        [Given("el telefono editar {string}")]
        public void GivenElTelefonoEditar(string telefono)
        {
            _cliente.Telefono = telefono;
        }

        [Given("la direccion editar {string}")]
        public void GivenLaDireccionEditar(string direccion)
        {
            _cliente.Direccion = direccion;
        }

        [Given("el estado es editar {string}")]
        public void GivenElEstadoEsEditar(string estado)
        {
            _cliente.Estado = estado.ToLower() == "true";
        }

        [When("se edita el usuario")]
        public void WhenSeEditaElUsuario()
        {
            _servicioCliente.UpdateCliente(_cliente);
        }

        [Then("el usuario debe ser editado exitosamente")]
        public void ThenElUsuarioDebeSerEditadoExitosamente()
        {
            List<Cliente> clientes = _servicioCliente.getAllClientes();

            Cliente? usuarioEditado = clientes.FirstOrDefault(c => c.Cedula == _cliente.Cedula);


            //Assert.NotNull(usuarioCreado);

            //Assert.Equal(_cliente.Cedula, usuarioCreado.Cedula);
            //Assert.Equal(_cliente.Apellidos, usuarioCreado.Apellidos);
            //Assert.Equal(_cliente.Nombres, usuarioCreado.Nombres);
            //Assert.Equal(_cliente.FechaNacimiento, usuarioCreado.FechaNacimiento);
            //Assert.Equal(_cliente.Mail, usuarioCreado.Mail);
            //Assert.Equal(_cliente.Telefono, usuarioCreado.Telefono);
            //Assert.Equal(_cliente.Direccion, usuarioCreado.Direccion);
            //Assert.Equal(_cliente.Estado, usuarioCreado.Estado);

            _cliente.Cedula.CompareTo(usuarioEditado.Cedula);
            _cliente.Apellidos.CompareTo(usuarioEditado.Apellidos);
            _cliente.Nombres.CompareTo(usuarioEditado.Nombres);
            _cliente.FechaNacimiento.CompareTo(usuarioEditado.FechaNacimiento);
            _cliente.Mail.CompareTo(usuarioEditado.Mail);
            _cliente.Telefono.CompareTo(usuarioEditado.Telefono);
            _cliente.Direccion.CompareTo(usuarioEditado.Direccion);
            _cliente.Estado.CompareTo(usuarioEditado.Estado);

        }
    }
}