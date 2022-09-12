using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property IsALocked<T>(string             description,
                                       IOpenFileResult<T> actual)
      => actual switch
         {
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                             missing.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                       open.ToTestOutput())),
            not LockedResult<T> => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsALocked<T>(string             description,
                                       AbsoluteFilePath   expectedPath,
                                       Message            expectedMessage,
                                       IOpenFileResult<T> actual)
      => actual switch
         {
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                             missing.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                       open.ToTestOutput())),
            LockedResult<T> locked => AreEqual(TheOpenFileResultIsALockedButDoesNotContainTheExpectedPath<T>(description),
                                               expectedPath,
                                               locked.Content.Path())
              .And(AreEqual(TheOpenFileResultIsALockedButDoesNotContainTheExpectedMessage<T>(description),
                            expectedMessage,
                            locked.Content.Message())),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsALockedAnd<T>(string                         description,
                                          Func<string, Locked, Property> property,
                                          IOpenFileResult<T>             actual)
      => actual switch
         {
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                             missing.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                       open.ToTestOutput())),
            LockedResult<T> locked => property(TheOpenFileResultIsALockedButDoesNotContainTheExpectedContent<T>(description),
                                               locked.Content),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
         };

   /* ------------------------------------------------------------ */

   public static Property IsAMissing<T>(string             description,
                                        IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                           locked.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                       open.ToTestOutput())),
            not MissingResult<T> => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsAMissing<T>(string             description,
                                        AbsoluteFilePath   expectedPath,
                                        Message            expectedMessage,
                                        IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                           locked.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                       open.ToTestOutput())),
            MissingResult<T> missing => AreEqual(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedPath<T>(description),
                                                 expectedPath,
                                                 missing.Content.Path())
              .And(AreEqual(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedMessage<T>(description),
                            expectedMessage,
                            missing.Content.Message())),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsAMissingAnd<T>(string                          description,
                                           Func<string, Missing, Property> property,
                                           IOpenFileResult<T>              actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                           locked.ToTestOutput())),
            OpenResult<T> open => False(Failed.Message(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                       open.ToTestOutput())),
            MissingResult<T> missing => property(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedContent<T>(description),
                                                 missing.Content),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsAnOpen<T>(string             description,
                                      IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                           locked.ToTestOutput())),
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                             missing.ToTestOutput())),
            not OpenResult<T> => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),

            _ => True(),
         };

   /* ------------------------------------------------------------ */

   public static Property IsAnOpen<T>(string             description,
                                      T expected,
                                      IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                           locked.ToTestOutput())),
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                             missing.ToTestOutput())),
            OpenResult<T> open => AreEqual(TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>(description),
                                           expected,
                                           open.Content),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Property IsAnOpenAnd<T>(string                    description,
                                         Func<string, T, Property> property,
                                         IOpenFileResult<T>        actual)
      => actual switch
         {
            LockedResult<T> locked => False(Failed.Message(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                           locked.ToTestOutput())),
            MissingResult<T> missing => False(Failed.Message(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                             missing.ToTestOutput())),
            OpenResult<T> open => property(TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>(description),
                                           open.Content),
            _ => False(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),
         };

   /* ------------------------------------------------------------ */
}