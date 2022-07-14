namespace Tetra;

internal static class Exceptions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Func<Failure, T> ThrowArgumentException<T>(string parameter)
   {
      T Throw(Failure failure)
         => throw new ArgumentException(failure.Content()
                                               .Content(),
                                        parameter);

      return Throw;
   }

   /* ------------------------------------------------------------ */
}