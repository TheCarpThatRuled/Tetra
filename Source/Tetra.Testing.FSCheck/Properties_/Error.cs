using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone(string description,
                                  IError actual)
      => actual switch
         {
            Error.SomeError some => False(Failed.Message(TheErrorIsASomeWhenWeExpectedItToBeANone(description),
                                                         some.ToTestOutput())),
            not Error.NoneError => False(TheErrorIsUnrecognisedWhenWeExpectedItToBeANone(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASome(string description,
                                  IError actual)
      => actual switch
         {
            Error.NoneError     => False(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            not Error.SomeError => False(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASome(string  description,
                                  Message expected,
                                  IError  actual)
      => actual switch
         {
            Error.NoneError => False(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            Error.SomeError some => AreEqual(description,
                                             expected,
                                             some.Content),

            _ => False(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd(string                          description,
                                     Func<string, Message, Property> property,
                                     IError                          actual)
      => actual switch
         {
            Error.NoneError => False(TheErrorIsANoneWhenWeExpectedItToBeASome(description)),
            Error.SomeError some => property(TheErrorIsASomeButDoesNotContainTheExpectedContent(description),
                                             some.Content),

            _ => False(TheErrorIsUnrecognisedWhenWeExpectedItToBeASome(description)),
         };

   /* ------------------------------------------------------------ */
}