// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Label;

public static class The_UI_creates_a_label_Extensions
{
   /* ------------------------------------------------------------ */
   // Factory Extensions
   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_label Visibility_is_collapsed
   (
      this The_UI_creates_a_label.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Collapsed);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_label Visibility_is_hidden
   (
      this The_UI_creates_a_label.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Hidden);

   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_label Visibility_is_visible
   (
      this The_UI_creates_a_label.DefineVisibility factory
   )
      => factory
        .Visibility_is(Visibility.Visible);

   /* ------------------------------------------------------------ */
}