using System.Diagnostics;

namespace Tetra.Testing;

public static class Log
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static void ToDebugOutput(string message)
   {
   #if DEBUG
      Debug.WriteLine(message);
   #endif
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(object? expected,
                                             object? actual)
   {
      ToDebugOutput($"Expected: {expected}, Actual: {actual}");
      ToDebugOutput(string.Empty);
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(string message,
                                             object? expected,
                                             object? actual)
   {
      ToDebugOutput(message);
      ToDebugOutput_AreEqual(expected,
                             actual);
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(DateTime expected,
                                             DateTime actual)
      => ToDebugOutput_AreEqual(expected.ToString("O"),
                                actual.ToString("O"));

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(string message,
                                             DateTime expected,
                                             DateTime actual)
      => ToDebugOutput_AreEqual(message,
                                expected.ToString("O"),
                                actual.ToString("O"));

   /* ------------------------------------------------------------ */
}