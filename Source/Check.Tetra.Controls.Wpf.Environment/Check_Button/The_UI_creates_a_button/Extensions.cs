// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Button;

public static class The_UI_creates_a_button_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_button.DefineVisibility IsEnabled_is_enabled(this The_UI_creates_a_button.DefineIsEnabled factory)
      => factory
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_button.DefineVisibility IsEnabled_is_disabled(this The_UI_creates_a_button.DefineIsEnabled factory)
      => factory
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_button Visibility_is_collapsed(this The_UI_creates_a_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_button Visibility_is_hidden(this The_UI_creates_a_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_button Visibility_is_visible(this The_UI_creates_a_button.DefineVisibility factory)
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}