﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestStruct.OnOuterPush;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Push
{
   /* ------------------------------------------------------------ */
   // public void Push(T value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //OnOuterPush
   //WHEN
   //Push
   //THEN
   //onOuterPush_was_invoked_once_with_pushedValue_AND_updated_was_not_invoked_AND_Pull_returns_pushedValue

   [TestMethod]
   public void GIVEN_OnOuterPush_WHEN_Push_THEN_onOuterPush_was_invoked_once_with_pushedValue_AND_updated_was_not_invoked_AND_Pull_returns_pushedValue()
   {
      static Property Property
      (
         (TestStruct initalValue, TestStruct pushedValue) args
      )
      {
         //Arrange
         var onOuterPush = FakeAction<TestStruct>.Create();
         var updated     = FakeAction.Create();

         var binding = Bind
                      .To(args.initalValue)
                      .OnOuterPush(onOuterPush.Action);

         binding.OnUpdated(updated.Action);

         //Act
         binding.Push(args.pushedValue);

         //Assert
         return WasInvokedOnce(nameof(onOuterPush),
                               args.pushedValue,
                               onOuterPush)
               .And(WasNotInvoked(nameof(updated),
                                  updated))
               .And(AreEqual(nameof(ITwoWayBinding<TestStruct>.Pull),
                             args.pushedValue,
                             binding.Pull()));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}