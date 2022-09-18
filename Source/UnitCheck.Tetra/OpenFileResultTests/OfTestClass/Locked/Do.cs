using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Locked_Do
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Do(Action<Locked>  whenLocked,
   //                       Action<Missing> whenMissing,
   //                       Action<T>       whenOpen)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_TestClass
   //WHEN
   //Do
   //THEN
   //whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_TestClass_WHEN_Do_THEN_whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_this_is_returned()
   {
      static Property Property(AbsoluteFilePath path,
                               Message          message)
      {
         //Arrange
         var whenLocked  = FakeAction<Locked>.Create();
         var whenMissing = FakeAction<Missing>.Create();
         var whenOpen    = FakeAction<TestClass>.Create();

         var result = LockedResult<TestClass>.Create(message,
                                                     path);

         //Act
         var actual = result.Do(whenLocked.Action,
                                whenMissing.Action,
                                whenOpen.Action);

         //Assert
         return AreReferenceEqual(AssertMessages.ReturnValue,
                                  result,
                                  actual)
               .And(WasInvokedOnce(nameof(whenLocked),
                                   path,
                                   message,
                                   whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing))
               .And(WasNotInvoked(nameof(whenOpen),
                                  whenOpen));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();

      Prop.ForAll<AbsoluteFilePath, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}