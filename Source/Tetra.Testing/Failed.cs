using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

[ExcludeFromCodeCoverage]
public static class Failed
{
   /* ------------------------------------------------------------ */
   // Private Constants
   /* ------------------------------------------------------------ */

   private const string TheTestFailedInTheAsserts = "The test failed in the asserts.";
   private const string TheTestFailedInTheActions = "The test failed in the actions.";

   /* ------------------------------------------------------------ */
   // Extension
   /* ------------------------------------------------------------ */

   public static AssertFailedException ToAssertFailedException
   (
      this string message
   )
      => new(message);

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string InTheActions
   (
      string message
   )
      => Message(TheTestFailedInTheActions,
                 message);

   /* ------------------------------------------------------------ */

   public static string InTheActions
   (
      string          message0,
      params string[] messages
   )
      => Message([
         TheTestFailedInTheActions,
         message0,
         .. messages,
      ]);

   /* ------------------------------------------------------------ */

   public static string InTheActions
   (
      string              message0,
      IEnumerable<string> messages
   )
      => Message([
         TheTestFailedInTheActions,
         message0,
         .. messages,
      ]);

   /* ------------------------------------------------------------ */

   public static string InTheAsserts
   (
      string message
   )
      => Message(TheTestFailedInTheAsserts,
                 message);

   /* ------------------------------------------------------------ */

   public static string InTheAsserts
   (
      string          message0,
      params string[] messages
   )
      => Message([
         TheTestFailedInTheAsserts,
         message0,
         .. messages,
      ]);

   /* ------------------------------------------------------------ */

   public static string InTheAsserts
   (
      string              message0,
      IEnumerable<string> messages
   )
      => Message([
         TheTestFailedInTheAsserts,
         message0,
         .. messages,
      ]);

   /* ------------------------------------------------------------ */

   public static string InTheAsserts
   (
      string              message0,
      IEnumerable<string> messages1,
      IEnumerable<string> messages2
   )
      => Message([
         TheTestFailedInTheAsserts,
         message0,
         .. messages1,
         ..messages2
      ]);

   /* ------------------------------------------------------------ */
   // Formatted Message Functions
   /* ------------------------------------------------------------ */

   public static IEnumerable<string> Actual
   (
      object? actual
   )
      =>
      [
         "\tActual:",
         ..Format(actual),
      ];

   /* ------------------------------------------------------------ */

   public static IEnumerable<string> Actual<T>
   (
      IEnumerable<T>? expected
   )
      => Actual((object?) expected);

   /* ------------------------------------------------------------ */

   public static string CannotPerformAnAction
   (
      string action,
      string reason
   )
      => InTheActions($"Cannot {action}; {reason}.");

   /* ------------------------------------------------------------ */

   public static string CannotPerformAnActionBecauseADependencyHasNotBeenCreated
   (
      string action,
      string dependency
   )
      => CannotPerformAnAction(action,
                               $"{dependency} has not been created");

   /* ------------------------------------------------------------ */

   public static string CannotPerformAnActionOn
   (
      string target,
      string reason
   )
      => CannotPerformAnAction($"perform an action on {target}",
                               reason);

   /* ------------------------------------------------------------ */

   public static string CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated
   (
      string target,
      string dependency
   )
      => CannotPerformAnActionBecauseADependencyHasNotBeenCreated($"perform an action on {target}",
                                                                  dependency);

   /* ------------------------------------------------------------ */

   public static string CannotPerformAnAssert
   (
      string action,
      string reason
   )
      => InTheAsserts($"Cannot {action}; {reason}.");

   /* ------------------------------------------------------------ */

   public static string CannotProgressToTheAsserts
   (
      string reason
   )
      => CannotPerformAnAssert("progress to the asserts",
                               reason);

   /* ------------------------------------------------------------ */

   public static string CannotProgressToTheAssertsBecauseNoActionsHaveBeenPerformed()
      => CannotProgressToTheAsserts("no actions have been performed");

   /* ------------------------------------------------------------ */

   public static IEnumerable<string> Expected
   (
      object? expected
   )
      =>
      [
         "\tExpected:",
         .. Format(expected),
      ];

   /* ------------------------------------------------------------ */

   public static IEnumerable<string> Expected<T>
   (
      IEnumerable<T>? expected
   )
      => Expected((object?) expected);

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   private static IEnumerable<string> Format
   (
      object? actual
   )
      => actual switch
         {
            IEnumerable<byte> b                             => Format(b),
            not string and System.Collections.IEnumerable e => Format(e),
            _ =>
            [
               $"\t\t{actual}",
            ],
         };

   /* ------------------------------------------------------------ */

   private static IEnumerable<string> Format
   (
      System.Collections.IEnumerable source
   )
   {
      var       enumerator = source.GetEnumerator();
      using var disposable = enumerator as IDisposable;

      while (enumerator.MoveNext())
      {
         yield return enumerator
                     .Current
                    ?.ToString()
                   ?? "null";
      }
   }
   /* ------------------------------------------------------------ */

   private static IEnumerable<string> Format
   (
      IEnumerable<byte> source
   )
      => source
        .Chunk(10)
        .Select(chunk => chunk
                        .Aggregate(new StringBuilder(),
                                   (
                                      total,
                                      next
                                   ) => total.Append(next.ToString("X")))
                        .ToString());

   /* ------------------------------------------------------------ */

   private static string Message
   (
      params string[] lines
   )
      => lines
        .WithIndices()
        .Aggregate(new StringBuilder(),
                   (
                      total,
                      next
                   ) => next.index != lines.Length - 1
                           ? total.AppendLine(next.item)
                           : total.Append(next.item))
        .ToString();

   /* ------------------------------------------------------------ */
}