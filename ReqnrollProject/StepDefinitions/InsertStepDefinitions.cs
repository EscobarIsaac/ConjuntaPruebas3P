using System;
using Reqnroll;
using TDD.Models;
using FluentAssertions;
using TDD.Data;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("Llenar los campos dentro del formulario")]
        public void GivenLlenarLosCamposDentroDelFormulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count();
            //Assert.True(resultado > 0);
            resultado.Should().BeGreaterThanOrEqualTo(1);

        }

        [When("Registro ingresados en la BDD")]
        public void WhenRegistroIngresadosEnLaBDD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            Cliente cls = new Cliente();

            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Nombres = item.Nombres;
                cls.Apellidos = item.Apellidos;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
                _clienteDAL.AddCliente(cls);
            }
            _clienteDAL.AddCliente(cls);
        }

        [Then("Resultado del ingreso a la BDD")]
        public void ThenResultadoDelIngresoALaBDD(DataTable dataTable)
        {
            var clientesEsperados = dataTable.CreateSet<Cliente>().ToList();
            var clientesBD = _clienteDAL.getAllClientes();

            foreach (var clienteEsperado in clientesEsperados)
            {
                var clienteBD = clientesBD.FirstOrDefault(c => c.Cedula == clienteEsperado.Cedula);

                Assert.NotNull(clienteBD);
            }
        }
    }
}