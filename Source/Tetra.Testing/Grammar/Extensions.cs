namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Grammar_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T And<T>(this T grammar)
      where T : IGrammar
   {
      Log.And();

      return grammar;
   }

   /* ------------------------------------------------------------ */
}