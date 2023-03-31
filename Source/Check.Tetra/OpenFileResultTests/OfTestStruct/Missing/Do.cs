using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Missing_Do
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Do(Action<Locked>  whenMissing,
   //                       Action<Missing> whenMissing,
   //                       Action<T>       whenOpen)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Missing_of_TestStruct
   //WHEN
   //Do
   //THEN
   //whenMissing_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenOpen_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Missing_of_TestStruct_WHEN_Do_THEN_whenMissing_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenOpen_was_not_invoked_AND_this_is_returned()
   {
      static Property Property(AbsoluteFilePath path,
                               Message          message)
      {
         //Arrange
         var whenLocked  = FakeAction<Locked>.Create();
         var whenMissing = FakeAction<Missing>.Create();
         var whenOpen    = FakeAction<TestStruct>.Create();

         var result = MissingResult<TestStruct>.Create(message,
                                                       path);

         //Act
         var actual = result.Do(whenLocked.Action,
                                whenMissing.Action,
                                whenOpen.Action);

         //Assert
         return AreReferenceEqual(AssertMessages.ReturnValue,
                                  result,
                                  actual)
               .And(WasInvokedOnce(nameof(whenMissing),
                                   path,
                                   message,
                                   whenMissing))
               .And(WasNotInvoked(nameof(whenLocked),
                                  whenLocked))
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