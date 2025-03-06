Feature: Editar

A short summary of the feature

@tag1
Scenario: Editar un usuario
    Given la cedula del anterior usuario "1724105661"
    And la cedula editar "1725650056"
    And los apellidos editar "Lopez Casa"
    And los nombres editar "Scarlett Liz"
    And la fecha de nacimiento editar "1995-11-11"
    And el mail editar "Lopz@gmail.com"
    And el telefono editar "0987654321"
    And la direccion editar "Argelia"
    And el estado es editar "false"
    When se edita el usuario
    Then el usuario debe ser editado exitosamente