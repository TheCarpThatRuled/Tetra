namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Button_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static T Matches<T>
   (
      this ButtonAsserts<T> then,
      Expected_button       expected
   )
      => then
        .IsEnabledEquals(expected.IsEnabled())
        .VisibilityEquals(expected.Visibility())
        .Next();

   /* ------------------------------------------------------------ */
}