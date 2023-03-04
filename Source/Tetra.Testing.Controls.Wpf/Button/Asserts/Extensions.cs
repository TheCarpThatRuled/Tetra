namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class ButtonAsserts_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T Matches<T>(this ButtonAssertsInstance<T> asserts,
                              Expected_button               expected)
      => asserts
        .IsEnabled_is(expected.IsEnabled())
        .Visibility_is(expected.Visibility())
        .ReturnToParent();


   /* ------------------------------------------------------------ */
}