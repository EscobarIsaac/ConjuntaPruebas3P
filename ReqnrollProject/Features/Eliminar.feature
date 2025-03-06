Feature: Eliminar

A short summary of the feature

@tag1
Scenario: Eliminar un usuario
	Given la cedula del usuario a eliminar "1724105661"
	When se elimina el usuario
	Then el usuario debe ser eliminado exitosamente
