namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TextBox_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static T Matches<T>
   (
      this TextBoxAsserts<T> then,
      Expected_text_box      expected
   )
      => then
        .TextEquals(expected.Text())
        .IsEnabledEquals(expected.IsEnabled())
        .VisibilityEquals(expected.Visibility())
        .Next();

   /* ------------------------------------------------------------ */
}