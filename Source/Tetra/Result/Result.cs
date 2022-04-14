namespace Tetra;

public static class Result
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Result<T> Success<T>(T content)
      => content;

   /* ------------------------------------------------------------ */
}