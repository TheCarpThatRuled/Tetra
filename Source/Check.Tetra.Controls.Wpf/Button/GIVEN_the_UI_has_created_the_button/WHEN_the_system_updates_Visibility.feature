@Unit
@Button
Feature: WHEN_the_system_updates_Visibility

Scenario: THEN_the_button_reflects_the_new_value
   Given the UI has created a button that is "enabled" and <initialVisibility>
   When the system updates Visibility to <newVisibility>
   Then the button is "enabled" and <newVisibility>

Examples:
   | initialVisibility | newVisibility |
   | "collapsed"       | "collapsed"   |
   | "hidden"          | "collapsed"   |
   | "visible"         | "collapsed"   |
   | "collapsed"       | "hidden"      |
   | "hidden"          | "hidden"      |
   | "visible"         | "hidden"      |
   | "collapsed"       | "visible"     |
   | "hidden"          | "visible"     |
   | "visible"         | "visible"     |