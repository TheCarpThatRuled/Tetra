namespace Tetra.Testing;

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

   //Invocation
   private const string WasInvoked    = "was invoked";
   private const string WasNotInvoked = "was not invoked";

   /* ------------------------------------------------------------ */
   // Private Compound Constants
   /* ------------------------------------------------------------ */

   //Contents
   private const string ButDoesNotContain = $"{But} {DoesNot} contain";

   //Expectations
   private const string AnUnexpectedArgument    = $"{An} {Unexpected} {Argument}";
   private const string TheExpectedContent      = $"{The} {Expected} {Content}";
   private const string TheExpectedMessage      = $"{The} {Expected} {Message}";
   private const string TheExpectedPath         = $"{The} {Expected} {Path}";
   private const string WhenWeExpectedItToBe    = $"when we {Expected} it to be";
   private const string WhenWeExpectedItNotToBe = $"when we {Expected} it not to be";

   //Invocation
   private const string WasInvokedAnUnexpectedNumberOfTimes = $"{WasInvoked} {An} {Unexpected} {NumberOfTimes}";
   private const string WasInvokedMoreThanOnce              = $"{WasInvoked} {MoreThan} {Once}";
   private const string WasInvokedWhenWeExpectedItNotToBe   = $"{WasInvoked}, {WhenWeExpectedItNotToBe}";
   private const string WasInvokedWithAnUnexpectedArgument  = $"{WasInvoked}, {With} {AnUnexpectedArgument}";
   private const string WasNotInvokedWhenWeExpectedItToBe   = $"{WasNotInvoked}, {WhenWeExpectedItToBe}";

   /* ------------------------------------------------------------ */
}