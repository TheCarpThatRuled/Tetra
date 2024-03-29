﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Open_Do
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Do(Action<Locked>  whenOpen,
   //                       Action<Missing> whenOpen,
   //                       Action<T>       whenOpen)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_int
   //WHEN
   //Do
   //THEN
   //whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_int_WHEN_Do_THEN_whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_this_is_returned()
   {
      static Property Property
      (
         int content
      )
      {
         //Arrange
         var whenLocked  = FakeAction<Locked>.Create();
         var whenMissing = FakeAction<Missing>.Create();
         var whenOpen    = FakeAction<int>.Create();

         var result = new OpenResult<int>(content);

         //Act
         var actual = result.Do(whenLocked.Action,
                                whenMissing.Action,
                                whenOpen.Action);

         //Assert
         return AreReferenceEqual(AssertMessages.ReturnValue,
                                  result,
                                  actual)
               .And(WasInvokedOnce(nameof(whenOpen),
                                   content,
                                   whenOpen))
               .And(WasNotInvoked(nameof(whenLocked),
                                  whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}