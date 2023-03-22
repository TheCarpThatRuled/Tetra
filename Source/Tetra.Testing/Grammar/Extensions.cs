namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Grammar_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T And<T>(this T grammar)
      where T : IGrammar
      => grammar;

   /* ------------------------------------------------------------ */

   public static T Where<T>(this T grammar)
      where T : IGrammar
      => grammar;

   /* ------------------------------------------------------------ */

   public static T While<T>(this T grammar)
      where T : IGrammar
      => grammar;

   /* ------------------------------------------------------------ */

   public static T With<T>(this T grammar)
      where T : IGrammar
      => grammar;

   /* ------------------------------------------------------------ */
}