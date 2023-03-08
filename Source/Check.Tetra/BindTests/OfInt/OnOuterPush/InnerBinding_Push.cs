using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfInt.OnOuterPush;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
// ReSharper disable once InconsistentNaming
public class InnerBinding_Push
{
   /* ------------------------------------------------------------ */
   // public void Push(T value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //OnOuterPush
   //WHEN
   //innerBinding_is_Pushed
   //THEN
   //onOuterPush_was_not_invoked_AND_updated_was_invoked_once_AND_Pull_returns_pushedValue

   [TestMethod]
   public void GIVEN_OnOuterPush_WHEN_innerBinding_is_Pushed_THEN_onOuterPush_was_not_invoked_AND_updated_was_invoked_once_AND_Pull_returns_pushedValue()
   {
      static Property Property((int initalValue, int pushedValue) args)
      {
         //Arrange
         var innerBinding = Bind.To(args.initalValue);
         var onOuterPush  = FakeAction<int>.Create();
         var updated      = FakeAction.Create();

         var binding = innerBinding.OnOuterPush(onOuterPush.Action);

         binding.OnUpdated(updated.Action);

         //Act
         innerBinding.Push(args.pushedValue);

         //Assert
         return WasNotInvoked(nameof(onOuterPush),
                              onOuterPush)
               .And(WasInvokedOnce(nameof(updated),
                                   updated))
               .And(AreEqual(nameof(ITwoWayBinding<int>.Pull),
                             args.pushedValue,
                             binding.Pull()));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}