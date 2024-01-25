namespace Tetra.Testing;

public static class Extensions
{

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static T Matches<T>
   (
      this ButtonAsserts<T> then,
      ExpectedButton       expected
   )
      => then
        .IsEnabledEquals(expected.IsEnabled())
        .VisibilityEquals(expected.Visibility())
        .Next();

   /* ------------------------------------------------------------ */
}