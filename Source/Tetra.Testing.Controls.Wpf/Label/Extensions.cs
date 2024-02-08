namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Label_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static T Matches<T>
   (
      this LabelAsserts<T> then,
      Expected_label        expected
   )
      => then
        .ContentEquals(expected.Content())
        .VisibilityEquals(expected.Visibility())
        .Next();

   /* ------------------------------------------------------------ */
}