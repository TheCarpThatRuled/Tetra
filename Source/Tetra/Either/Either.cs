namespace Tetra;

public static class Either
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Left<T> Left<T>(T content)
   => content;

   /* ------------------------------------------------------------ */

   public static Right<T> Right<T>(T content)
      => content;

   /* ------------------------------------------------------------ */
}