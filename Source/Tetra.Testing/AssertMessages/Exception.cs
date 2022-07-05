namespace Tetra.Testing;

public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string ArgumentExceptionMessage(string message,
                                                 string parameterName)
      => $"{message} (Parameter '{parameterName}')";

   /* ------------------------------------------------------------ */
}