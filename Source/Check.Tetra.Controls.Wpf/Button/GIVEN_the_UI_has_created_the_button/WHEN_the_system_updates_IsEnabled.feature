@Unit
@Button
Feature: WHEN_the_system_updates_IsEnabled

Scenario: THEN_the_button_reflects_the_new_value
   Given the UI has created a button that is <initialIsEnabled> and "visible"
   When the system updates IsEnabled to <newIsEnabled>
   Then the button is <newIsEnabled> and "visible"
   And the system contains <newIsEnabled> and "visible"

Examples:
   | initialIsEnabled | newIsEnabled |
   | "enabled"        | "enabled"    |
   | "disabled"       | "enabled"    |
   | "enabled"        | "disabled"   |
   | "disabled"       | "disabled"   |