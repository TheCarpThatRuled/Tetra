using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfInt.To;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Push
{
   /* ------------------------------------------------------------ */
   // public void Push(T value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //To
   //WHEN
   //Push
   //THEN
   //updated_was_invoked_once_AND_Pull_returns_pushedValue

   [TestMethod]
   public void GIVEN_To_WHEN_Push_THEN_updated_was_invoked_once_AND_Pull_returns_pushedValue()
   {
      static Property Property((int initalValue, int pushedValue) args)
      {
         //Arrange
         var binding = Bind.To(args.initalValue);
         var updated = FakeAction.Create();

         binding.OnUpdated(updated.Action);

         //Act
         binding.Push(args.pushedValue);

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
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