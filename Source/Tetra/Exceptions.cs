using System.Runtime.CompilerServices;

namespace Tetra;

public static class Exceptions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static NotImplementedException NotImplemented([CallerMemberName] string? memberName = null,
                                                        [CallerFilePath]   string? filePath   = null,
                                                        [CallerLineNumber] int     lineNumber = 0)
      => new($@"{memberName} on line {lineNumber} of <{filePath}> has not been implemented");

   /* ------------------------------------------------------------ */
   // Internal Functions
   /* ------------------------------------------------------------ */

   internal static Func<Failure, T> ThrowArgumentException<T>(string parameter)
   {
      T Throw(Failure failure)
         => throw new ArgumentException(failure.Content()
                                               .Content(),
                                        parameter);

      return Throw;
   }

   /* ------------------------------------------------------------ */
}