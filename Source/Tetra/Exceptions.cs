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

   internal static Func<Message, T> ThrowArgumentException<T>(string parameter)
   {
      T Throw(Message message)
         => throw new ArgumentException(message.Content(),
                                        parameter);

      return Throw;
   }

   /* ------------------------------------------------------------ */
}