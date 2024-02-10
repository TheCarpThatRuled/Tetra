using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsALocked<T>
   (
      this Assert        assert,
      string             description,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            not LockedResult<T> => throw Failed
                                        .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
                                        .ToAssertFailedException(),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsALocked<T>
   (
      this Assert        assert,
      string             description,
      AbsoluteFilePath   expectedPath,
      Message            expectedMessage,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            LockedResult<T> locked => assert.AreEqual(description,
                                                      expectedPath,
                                                      expectedMessage,
                                                      locked),
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsALockedAnd<T>
   (
      this Assert        assert,
      string             description,
      Func<Locked, bool> property,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeALocked<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeALocked<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            LockedResult<T> locked => !property(locked.Content)
                                         ? throw Failed
                                                .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
                                                .ToAssertFailedException()
                                         : assert,
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeALocked<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissing<T>
   (
      this Assert        assert,
      string             description,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            not MissingResult<T> => throw Failed
                                         .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description))
                                         .ToAssertFailedException(),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissing<T>
   (
      this Assert        assert,
      string             description,
      AbsoluteFilePath   expectedPath,
      Message            expectedMessage,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            MissingResult<T> missing => assert.AreEqual(description,
                                                        expectedPath,
                                                        expectedMessage,
                                                        missing),
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAMissingAnd<T>
   (
      this Assert         assert,
      string              description,
      Func<Missing, bool> property,
      IOpenFileResult<T>  actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAMissing<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            OpenResult<T> open => throw Failed
                                       .InTheAsserts(TheOpenFileResultIsAnOpenWhenWeExpectedItToBeAMissing<T>(description),
                                                     Failed.Actual(open.ToTestOutput()))
                                       .ToAssertFailedException(),
            MissingResult<T> missing => !property(missing.Content)
                                           ? throw Failed
                                                  .InTheAsserts(TheOpenFileResultIsAMissingButDoesNotContainTheExpectedContent<T>(description))
                                                  .ToAssertFailedException()
                                           : assert,
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAMissing<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpen<T>
   (
      this Assert        assert,
      string             description,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            not OpenResult<T> => throw Failed
                                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description))
                                      .ToAssertFailedException(),

            _ => assert,
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpen<T>
   (
      this Assert        assert,
      string             description,
      T                  expected,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            OpenResult<T> open => assert.AreEqual(description,
                                                  expected,
                                                  open.Content),
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */

   public static Assert IsAnOpenAnd<T>
   (
      this Assert        assert,
      string             description,
      Func<T, bool>      property,
      IOpenFileResult<T> actual
   )
      => actual switch
         {
            LockedResult<T> locked => throw Failed
                                           .InTheAsserts(TheOpenFileResultIsALockedWhenWeExpectedItToBeAnOpen<T>(description),
                                                         Failed.Actual(locked.ToTestOutput()))
                                           .ToAssertFailedException(),
            MissingResult<T> missing => throw Failed
                                             .InTheAsserts(TheOpenFileResultIsAMissingWhenWeExpectedItToBeAnOpen<T>(description),
                                                           Failed.Actual(missing.ToTestOutput()))
                                             .ToAssertFailedException(),
            OpenResult<T> open => !property(open.Content)
                                     ? throw Failed
                                            .InTheAsserts(TheOpenFileResultIsAnOpenButDoesNotContainTheExpectedContent<T>(description))
                                            .ToAssertFailedException()
                                     : assert,
            _ => throw Failed
                      .InTheAsserts(TheOpenFileResultIsUnrecognisedWhenWeExpectedItToBeAnOpen<T>(description))
                      .ToAssertFailedException(),
         };

   /* ------------------------------------------------------------ */
   // Internal Extensions
   /* ------------------------------------------------------------ */

   internal static Assert AreEqual<T>
   (
      this Assert      assert,
      string           description,
      AbsoluteFilePath expectedPath,
      Message          expectedMessage,
      LockedResult<T>  actual
   )
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

   internal static Assert AreEqual<T>
   (
      this Assert      assert,
      string           description,
      AbsoluteFilePath expectedPath,
      Message          expectedMessage,
      MissingResult<T> actual
   )
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