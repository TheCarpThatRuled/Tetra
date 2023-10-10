using Check.Check_TextBox;

// ReSharper disable InconsistentNaming

namespace Check.TextBox;

internal static class Text_boxes
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box Create_enabled_and_visible
   (
      string text
   )
      => The_UI_creates_a_text_box
        .Factory()
        .Text_is(text)
        .IsEnabled_is_enabled()
        .Visibility_is_visible();

   /* ------------------------------------------------------------ */

   public static Expected_text_box Enabled_and_visible
   (
      string text
   )
      => Expected_text_box
        .Factory()
        .Text_is(text)
        .IsEnabled_is_enabled()
        .Visibility_is_visible();

   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static The_UI_creates_a_text_box.DefineIsEnabled Text_is_default
   (
      this The_UI_creates_a_text_box.DefineText factory
   )
      => factory
        .Text_is("Some text");

   /* ------------------------------------------------------------ */

   public static Expected_text_box.DefineIsEnabled Text_is_default
   (
      this Expected_text_box.DefineText factory
   )
      => factory
        .Text_is("Some text");

   /* ------------------------------------------------------------ */
}