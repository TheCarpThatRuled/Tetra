// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Text_Box;

public static class The_UI_creates_a_text_box_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box.DefineVisibility IsEnabled_is_enabled
   (
      this The_UI_creates_a_text_box.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(true);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box.DefineVisibility IsEnabled_is_disabled
   (
      this The_UI_creates_a_text_box.DefineIsEnabled factory
   )
      => factory
        .IsEnabled_is(false);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box Visibility_is_collapsed
   (
      this The_UI_creates_a_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box Visibility_is_hidden
   (
      this The_UI_creates_a_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box Visibility_is_visible
   (
      this The_UI_creates_a_text_box.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}