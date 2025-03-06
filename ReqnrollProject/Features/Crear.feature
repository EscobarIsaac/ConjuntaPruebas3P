Feature: Crear

A short summary of the feature

@tag1
Scenario: Crear un usuario
    Given la cedula "1724105661"
    And los apellidos "Perez Pereira"
    And los nombres "Jose Mario"
    And la fecha de nacimiento "1995-12-12"
    And el mail "Mario@gmail.com"
    And el telefono "0961216547"
    And la direccion "UPC via Daule"
    And el estado es "true"
    When se registra el usuario
    Then el usuario debe ser creado exitosamente