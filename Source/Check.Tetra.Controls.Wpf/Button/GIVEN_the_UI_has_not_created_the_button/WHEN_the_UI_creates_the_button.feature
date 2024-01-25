@Unit
@Button
Feature: WHEN_the_UI_creates_the_button

# ------------------------------------------------------------ #

Scenario: The_UI_reflects_the_initial_state
   Given the UI has not created the button
   When the UI creates a button that is <isEnabled > and <visible>
   Then the button is <isEnabled > and <visible>

Examples:
   | isEnabled  | visible     |
   | "enabled"  | "collapsed" |
   | "disabled" | "collapsed" |
   | "enabled"  | "hidden"    |
   | "disabled" | "hidden"    |
   | "enabled"  | "visible"   |
   | "disabled" | "visible"   |

# ------------------------------------------------------------ #