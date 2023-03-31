﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_Do
{
   /* ------------------------------------------------------------ */
   // IOption<T> Do(Action    whenNone,
   //               Action<T> whenSome);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Do_AND_whenNone_is_a_Action_AND_whenSome_is_a_Action_of_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_this_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Do_AND_whenNone_is_a_Action_AND_whenSome_is_a_Action_of_TestStruct_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_this_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenNone = FakeAction.Create();
         var whenSome = FakeAction<TestStruct>.Create();

         var option = Option.Some(value);

         //Act
         var actual = option.Do(whenSome.Action,
                                whenNone.Action);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         option,
                         actual)
               .And(WasNotInvoked(nameof(whenNone),
                                  whenNone))
               .And(WasInvokedOnce(nameof(whenSome),
                                   value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}