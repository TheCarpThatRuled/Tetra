namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class LabelAsserts_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T Matches<T>(this LabelAssertsInstance<T> asserts,
                              Expected_label               expected)
      => asserts
        .Content_is(expected.Content())
        .Visibility_is(expected.Visibility())
        .ReturnToParent();


   /* ------------------------------------------------------------ */
}