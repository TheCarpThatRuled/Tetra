#if DEBUG
using System.Diagnostics;
#endif

namespace Tetra.Testing;

public static class Log
{
   /* ------------------------------------------------------------ */
   // ToDebugOutput Functions
   /* ------------------------------------------------------------ */

   public static void ToDebugOutput(string message)
   {
#if DEBUG
      Debug.WriteLine(message);
#endif
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(string  message,
                                             object? expected,
                                             object? actual)
   {
      ToDebugOutput(message);
      ToDebugOutput($"Test are equal; Expected: '{expected}', Actual: '{actual}'");
      ToDebugOutput_NewLine();
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_AreEqual(string   message,
                                             DateTime expected,
                                             DateTime actual)
      => ToDebugOutput_AreEqual(message,
                                expected.ToString("O"),
                                actual.ToString("O"));

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_IsFalse(string message,
                                            bool   actual)
   {
      ToDebugOutput(message);
      ToDebugOutput($"Test is false;'{actual}'");
      ToDebugOutput_NewLine();
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_IsTrue(string message,
                                           bool   actual)
   {
      ToDebugOutput(message);
      ToDebugOutput($"Test is true;'{actual}'");
      ToDebugOutput_NewLine();
   }

   /* ------------------------------------------------------------ */

   public static void ToDebugOutput_NewLine()
      => ToDebugOutput(string.Empty);

   /* ------------------------------------------------------------ */
   // ToStandardOutput Functions
   /* ------------------------------------------------------------ */

   public static void And()
      => TestStep("And");

   /* ------------------------------------------------------------ */

   public static void Given()
      => TestStep("GIVEN <<<");

   /* ------------------------------------------------------------ */

   public static void TestStep(string message)
      => ToStandardOutput(">>> " + message);

   /* ------------------------------------------------------------ */

   public static void Then()
      => TestStep("THEN <<<");

   /* ------------------------------------------------------------ */

   public static void ToStandardOutput(string message)
      => Console
        .WriteLine(message);

   /* ------------------------------------------------------------ */

   public static void When()
      => TestStep("WHEN <<<");

   /* ------------------------------------------------------------ */
}