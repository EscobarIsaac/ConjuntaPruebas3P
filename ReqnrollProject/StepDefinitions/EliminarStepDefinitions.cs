using System;
using Reqnroll;
using TDD.Data;
using TDD.Models;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class EliminarStepDefinitions
    {
        private Cliente _cliente = new Cliente();
        private readonly ClienteDataAccessLayer _servicioCliente = new ClienteDataAccessLayer();

        [Given("la cedula del usuario a eliminar {string}")]
        public void GivenLaCedulaDelUsuarioAEliminar(string cedula)
        {
            List<Cliente> clientes = _servicioCliente.getAllClientes();

            _cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);

        }


        [When("se elimina el usuario")]
        public void WhenSeEliminaElUsuario()
        {
            _servicioCliente.DeleteCliente(_cliente.Codigo);
        }

        [Then("el usuario debe ser eliminado exitosamente")]
        public void ThenElUsuarioDebeSerEliminadoExitosamente()
        {
            List<Cliente> clientes = _servicioCliente.getAllClientes();

            for (int i = 0; i < clientes.Count; i++)
            {
                Assert.NotEqual(_cliente.Codigo, clientes[i].Codigo);
            }



        }
    }
}