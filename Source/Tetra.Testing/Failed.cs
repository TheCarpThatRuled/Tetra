using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public static class Failed
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AssertFailedException Assert(string message)
      => new(message);

   /* ------------------------------------------------------------ */

   public static AssertFailedException Assert(string message,
                                              object? actual)
      => new(Message(message,
                     actual));

   /* ------------------------------------------------------------ */

   public static AssertFailedException Assert(string message,
                                              object? expected,
                                              object? actual)
      => new(Message(message,
                     expected,
                     actual));

   /* ------------------------------------------------------------ */
   // InTest Functions
   /* ------------------------------------------------------------ */

   public static AssertFailedException InTest(string message)
      => Assert($"The test failed after the act: {message}");

   /* ------------------------------------------------------------ */

   public static AssertFailedException InTest(string  message,
                                              object? actual)
      => Assert($"The test failed after the act: {message}",
                actual);

   /* ------------------------------------------------------------ */

   public static AssertFailedException InTest(string  message,
                                              object? expected,
                                              object? actual)
      => Assert($"The test failed after the act: {message}",
                expected,
                actual);

   /* ------------------------------------------------------------ */
   // InTestSetup Functions
   /* ------------------------------------------------------------ */

   public static AssertFailedException InTestSetup(string message)
      => Assert($"The test failed during test set-up; the act was not performed: {message}");

   /* ------------------------------------------------------------ */

   public static AssertFailedException InTestSetup(string  message,
                                                   object? actual)
      => Assert($"The test failed during test set-up; the act was not performed: {message}",
                actual);

   /* ------------------------------------------------------------ */

   public static AssertFailedException InTestSetup(string  message,
                                                   object? expected,
                                                   object? actual)
      => Assert($"The test failed during test set-up; the act was not performed: {message}",
                expected,
                actual);

   /* ------------------------------------------------------------ */
   // Message Functions
   /* ------------------------------------------------------------ */

   public static string ExpectedActual(object? expected,
                                       object? actual)
      => $"Expected: {expected}, Actual: {actual}";

   /* ------------------------------------------------------------ */

   public static string ExpectedActual<T0, T1>(IReadOnlyCollection<T0>? expected,
                                               IReadOnlyCollection<T1>? actual)
      => $"Expected:\n{FormatSequence(expected)}\nActual: {FormatSequence(actual)}";

   /* ------------------------------------------------------------ */

   public static string ExpectedActual<T0, T1>(IReadOnlyCollection<T0>? expected,
                                               IReadOnlyCollection<T1>? actual,
                                               string description)
      => $"{description}; Expected:\n{FormatSequence(expected)}\nActual: {FormatSequence(actual)}";

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
   // Private Functions
   /* ------------------------------------------------------------ */

   private static string FormatSequence<T>(IEnumerable<T>? expected)
      => expected?.Aggregate(string.Empty,
                             (total,
                              next) => $"{total}{next}\n")
      ?? "null";

   /* ------------------------------------------------------------ */
}