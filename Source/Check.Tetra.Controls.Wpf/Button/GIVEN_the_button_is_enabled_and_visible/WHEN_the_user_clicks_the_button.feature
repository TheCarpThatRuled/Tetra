﻿@Unit
@Button
Feature: WHEN_the_user_clicks_the_button

Scenario: THEN_the_click_callback_was_invoked_once
   Given the UI has created an enabled, visible button
   When the user clicks the button
   Then the click callback was invoked once
   And the button is "enabled" and "visible"
   And the system contains "enabled" and "visible"