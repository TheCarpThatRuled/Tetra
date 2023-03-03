using System.Diagnostics.CodeAnalysis;

namespace Tetra.Testing;


[ExcludeFromCodeCoverage]
public static partial class AssertMessages
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public const string ReturnValue = "Return value";

   /* ------------------------------------------------------------ */
   // Private Primitive Constants
   /* ------------------------------------------------------------ */

   //Articles
   private const string A   = "a";
   private const string An  = "an";
   private const string The = "the";

   //Conjunctives
   private const string But     = "but";
   private const string DoesNot = "does not";
   private const string Is      = "is";
   private const string With    = "with";

   //Counting
   private const string MoreThan      = "more than";
   private const string NumberOfTimes = "number of times";
   private const string Once          = "once";

   //Identity
   private const string Argument     = "argument";
   private const string Expected     = "expected";
   private const string Content      = "content";
   private const string Message      = "message";
   private const string Path         = "path";
   private const string Unexpected   = "unexpected";
   private const string Unrecognised = "unrecognised";

   //Firing
   private const string WasFired    = "was fired";
   private const string WasNotFired = "was not fired";

   //Invocation
   private const string WasInvoked    = "was invoked";
   private const string WasNotInvoked = "was not invoked";

   //Verbs
   private const string Be   = "be";
   private const string Been = "been";
   private const string Have = "have";

   /* ------------------------------------------------------------ */
   // Private Compound Constants
   /* ------------------------------------------------------------ */

   //Contents
   private const string ButDoesNotContain = $"{But} {DoesNot} contain";

   //Expectations
   private const string AnUnexpectedArgument          = $"{An} {Unexpected} {Argument}";
   private const string TheExpectedContent            = $"{The} {Expected} {Content}";
   private const string TheExpectedMessage            = $"{The} {Expected} {Message}";
   private const string TheExpectedPath               = $"{The} {Expected} {Path}";
   private const string WhenWeExpected                = $"when we {Expected}";
   private const string WhenWeExpectedItToBe          = $"{WhenWeExpected} it to {Be}";
   private const string WhenWeExpectedItToHaveBeen    = $"{WhenWeExpected} it to {Have} {Been}";
   private const string WhenWeExpectedItNotToBe       = $"{WhenWeExpected} it not to {Be}";
   private const string WhenWeExpectedItNotToHaveBeen = $"{WhenWeExpected} it not to {Have} {Been}";

   //Firing
   private const string WasFiredAnUnexpectedNumberOfTimes     = $"{WasFired} {An} {Unexpected} {NumberOfTimes}";
   private const string WasFiredMoreThanOnce                  = $"{WasFired}, {MoreThan} {Once}";
   private const string WasFiredWhenWeExpectedItNotToHaveBeen = $"{WasFired}, {WhenWeExpectedItNotToHaveBeen}";
   private const string WasFiredWithAnUnexpectedArgument      = $"{WasFired}, {With} {AnUnexpectedArgument}";
   private const string WasNotFiredWhenWeExpectedItToHaveBeen = $"{WasNotFired}, {WhenWeExpectedItToHaveBeen}";

   //Invocation
   private const string WasInvokedAnUnexpectedNumberOfTimes     = $"{WasInvoked} {An} {Unexpected} {NumberOfTimes}";
   private const string WasInvokedMoreThanOnce                  = $"{WasInvoked} {MoreThan} {Once}";
   private const string WasInvokedWhenWeExpectedItNotToHaveBeen = $"{WasInvoked}, {WhenWeExpectedItNotToHaveBeen}";
   private const string WasInvokedWithAnUnexpectedArgument      = $"{WasInvoked}, {With} {AnUnexpectedArgument}";
   private const string WasNotInvokedWhenWeExpectedItToHaveBeen = $"{WasNotInvoked}, {WhenWeExpectedItToHaveBeen}";

   /* ------------------------------------------------------------ */
}