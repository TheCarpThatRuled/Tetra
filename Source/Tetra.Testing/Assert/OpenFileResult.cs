using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsALocked<T>(this Assert        assert,
                                     string             description,
                                     IOpenFileResult<T> actual)
      => actual switch
         {
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                            missing.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                      open.ToTestOutput()),
            not LockedResult<T> => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsALocked<T>(this Assert        assert,
                                     string             description,
                                     AbsoluteFilePath   expectedPath,
                                     Message            expectedMessage,
                                     IOpenFileResult<T> actual)
      => actual switch
         {
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                            missing.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                      open.ToTestOutput()),
            LockedResult<T> locked => assert.AreEqual(description,
                                                      expectedPath,
                                                      expectedMessage,
                                                      locked),
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsALockedAnd<T>(this Assert        assert,
                                        string             description,
                                        Func<Locked, bool> property,
                                        IOpenFileResult<T> actual)
      => actual switch
         {
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                            missing.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                      open.ToTestOutput()),
            LockedResult<T> locked => !property(locked.Content)
                                         ? throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
                                         : assert,
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissing<T>(this Assert        assert,
                                      string             description,
                                      IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                          locked.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                      open.ToTestOutput()),
            not MissingResult<T> => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissing<T>(this Assert        assert,
                                      string             description,
                                      AbsoluteFilePath   expectedPath,
                                      Message            expectedMessage,
                                      IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                          locked.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                      open.ToTestOutput()),
            MissingResult<T> missing => assert.AreEqual(description,
                                                        expectedPath,
                                                        expectedMessage,
                                                        missing),
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissingAnd<T>(this Assert         assert,
                                         string              description,
                                         Func<Missing, bool> property,
                                         IOpenFileResult<T>  actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                          locked.ToTestOutput()),
            OpenResult<T> open => throw Failed.Assert(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                      open.ToTestOutput()),
            MissingResult<T> missing => !property(missing.Content)
                                           ? throw Failed.Assert(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedContent<T>(description))
                                           : assert,
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpen<T>(this Assert        assert,
                                    string             description,
                                    IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                          locked.ToTestOutput()),
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                            missing.ToTestOutput()),
            not OpenResult<T> => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpen<T>(this Assert        assert,
                                    string             description,
                                    T                  expected,
                                    IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                          locked.ToTestOutput()),
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                            missing.ToTestOutput()),
            OpenResult<T> open => assert.AreEqual(description,
                                                  expected,
                                                  open.Content),
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpenAnd<T>(this Assert        assert,
                                       string             description,
                                       Func<T, bool>      property,
                                       IOpenFileResult<T> actual)
      => actual switch
         {
            LockedResult<T> locked => throw Failed.Assert(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                          locked.ToTestOutput()),
            MissingResult<T> missing => throw Failed.Assert(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                            missing.ToTestOutput()),
            OpenResult<T> open => !property(open.Content)
                                     ? throw Failed.Assert(TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>(description))
                                     : assert,
            _ => throw Failed.Assert(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description)),
         };

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */

   internal static Assert AreEqual<T>(this Assert      assert,
                                      string           description,
                                      AbsoluteFilePath expectedPath,
                                      Message          expectedMessage,
                                      LockedResult<T>  actual)
   {
      assert.AreEqual(TheOpenFileResultIsALockedButDoesNotContainTheExpectedMessage<T>(description),
                      expectedMessage,
                      actual.Content
                            .Message());

      assert.AreEqual(TheOpenFileResultIsALockedButDoesNotContainTheExpectedPath<T>(description),
                      expectedPath,
                      actual.Content
                            .Path());

      return assert;
   }

   /* ------------------------------------------------------------ */

   internal static Assert AreEqual<T>(this Assert      assert,
                                      string           description,
                                      AbsoluteFilePath expectedPath,
                                      Message          expectedMessage,
                                      MissingResult<T> actual)
   {
      assert.AreEqual(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedMessage<T>(description),
                      expectedMessage,
                      actual.Content
                            .Message());

      assert.AreEqual(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedPath<T>(description),
                      expectedPath,
                      actual.Content
                            .Path());

      return assert;
   }

   /* ------------------------------------------------------------ */
}