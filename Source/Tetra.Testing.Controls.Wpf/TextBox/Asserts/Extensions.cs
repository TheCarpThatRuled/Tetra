namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TextBoxAsserts_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T Matches<T>(this TextBoxAssertsInstance<T> asserts,
                              Expected_text_box              expected)
      => asserts
        .IsEnabled_is(expected.IsEnabled())
        .Text_is(expected.Text())
        .Visibility_is(expected.Visibility())
        .ReturnToParent();


   /* ------------------------------------------------------------ */
}