Feature: Insert

A short summary of the feature

@tag1
Scenario: Insertar clientes
	Given Llenar los campos dentro del formulario
		| Cedula | Apellidos | Nombres | FechaNacimiento | Mail | Telefono | Direccion | Estado |
		| 1724105661 | Coloma Erazo | Kevin Bladimir | 2001-02-03 | Coloma@gmail.com | 0961216222 | Lucha de los pobres | true |
	When Registro ingresados en la BDD
		| Cedula | Apellidos | Nombres | FechaNacimiento | Mail | Telefono | Direccion | Estado |
		| 1724105661 | Coloma Erazo | Kevin Bladimir | 2001-02-03 | Coloma@gmail.com | 0961216222 | Lucha de los pobres | true |
	Then Resultado del ingreso a la BDD
		| Cedula | Apellidos | Nombres | FechaNacimiento | Mail | Telefono | Direccion | Estado |
		| 1724105661 | Coloma Erazo | Kevin Bladimir | 2001-02-03 | Coloma@gmail.com | 0961216222 | Lucha de los pobres | true |
