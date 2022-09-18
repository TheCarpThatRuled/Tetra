using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsANone<T>(string     description,
                                     IOption<T> actual)
      => actual switch
         {
            Option<T>.SomeOption some => False(Failed.Message(TheOptionIsASomeWhenWeExpectedItToBeANone<T>(description),
                                                              some.ToTestOutput())),
            not Option<T>.NoneOption => False(TheOptionIsUnrecognisedWhenWeExpectedItToBeANone<T>(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string     description,
                                     IOption<T> actual)
      => actual switch
         {
            Option<T>.NoneOption     => False(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            not Option<T>.SomeOption => False(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASome<T>(string     description,
                                     T          expected,
                                     IOption<T> actual)
      => actual switch
         {
            Option<T>.NoneOption => False(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            Option<T>.SomeOption some => AreEqual(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                                  expected,
                                                  some),

            _ => False(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsASomeAnd<T>(string                    description,
                                        Func<string, T, Property> property,
                                        IOption<T>                actual)
      => actual switch
         {
            Option<T>.NoneOption => False(TheOptionIsANoneWhenWeExpectedItToBeASome<T>(description)),
            Option<T>.SomeOption some => property(TheOptionIsASomeButDoesNotContainTheExpectedContent<T>(description),
                                                  some.Content),

            _ => False(TheOptionIsIUnrecognisedWhenWeExpectedItToBeASome<T>(description)),
         };

   /* ------------------------------------------------------------ */
}