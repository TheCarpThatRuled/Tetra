﻿using Check.Check_Button;

// ReSharper disable InconsistentNaming

namespace Check.Button;

internal static class Buttons
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly The_UI_creates_a_button Create_enabled_and_visible = The_UI_creates_a_button
                                                                              .Factory()
                                                                              .IsEnabled_is_enabled()
                                                                              .Visibility_is_visible();

   /* ------------------------------------------------------------ */

   public static readonly Expected_button Enabled_and_visible = Expected_button
                                                               .Factory()
                                                               .IsEnabled_is_enabled()
                                                               .Visibility_is_visible();

   /* ------------------------------------------------------------ */
}