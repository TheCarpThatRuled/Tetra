using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public static class Failed
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static AssertFailedException Assert(string message)
      => new(message);

   /* ------------------------------------------------------------ */

   public static string ExpectedActual(object? expected,
                                       object? actual)
      => $"Expected: {expected}, Actual: {actual}";

   /* ------------------------------------------------------------ */

   public static string Message(string message,
                                object? actual)
      => $"{message}; Actual: {actual}";

   /* ------------------------------------------------------------ */

   public static string Message(string message,
                                object? expected,
                                object? actual)
      => $"{message}; {ExpectedActual(expected, actual)}";

   /* ------------------------------------------------------------ */
}