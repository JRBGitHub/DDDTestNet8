Feature: Consulta de acumulados de divisas por cliente y canal
  Como usuario del sistema
  Quiero consultar los acumulados de divisas de un cliente
  Para saber cuánto ha comprado por día, semana y mes, filtrando por canal si es necesario

  Scenario: Consultar todos los acumulados de un cliente
    Given existe un cliente con idhost 1 y canales "WEB1" y "APP2"
    When consulto los acumulados para el cliente con idhost 1
    Then obtengo 2 acumulados

  Scenario: Consultar acumulado filtrando por canal
    Given existe un cliente con idhost 1 y canales "WEB1" y "APP2"
    When consulto los acumulados para el cliente con idhost 1 y canal "WEB1"
    Then obtengo 1 acumulado con canal "WEB1"

  Scenario: Consultar acumulados de un cliente inexistente
    Given no existe un cliente con idhost 3
    When consulto los acumulados para el cliente con idhost 3
    Then obtengo 0 acumulados
