using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.ToTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Bind)]
public class Push
{
   /* ------------------------------------------------------------ */
   // public void Push(T value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_ITwoWayBinding_of_int
   //WHEN
   //Push
   //THEN
   //Update_is_fired_AND_Pull_returns_value

   [TestMethod]
   public void GIVEN_a_ITwoWayBinding_of_int_WHEN_Push_THEN_Update_is_fired_AND_Pull_returns_value()
   {
      static Property Property((int initalValue, int pushedValue) args)
      {
         //Arrange
         var binding = Bind.To(args.initalValue);
         var updated = FakeEventHandler.Create(handler => binding.Updated += handler);

         //Act
         binding.Push(args.pushedValue);

         //Assert
         return WasFireOnce(nameof(updated),
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

   //GIVEN
   //a_ITwoWayBinding_of_TestClass
   //WHEN
   //Push
   //THEN
   //Update_is_fired_AND_Pull_returns_value

   [TestMethod]
   public void GIVEN_a_ITwoWayBinding_of_TestClass_WHEN_Push_THEN_Update_is_fired_AND_Pull_returns_value()
   {
      static Property Property((TestClass initalValue, TestClass pushedValue) args)
      {
         //Arrange
         var binding = Bind.To(args.initalValue);
         var updated = FakeEventHandler.Create(handler => binding.Updated += handler);

         //Act
         binding.Push(args.pushedValue);

         //Assert
         return WasFireOnce(nameof(updated),
                            updated)
           .And(AreEqual(nameof(ITwoWayBinding<TestClass>.Pull),
                         args.pushedValue,
                         binding.Pull()));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_ITwoWayBinding_of_TestStruct
   //WHEN
   //Push
   //THEN
   //Update_is_fired_AND_Pull_returns_value

   [TestMethod]
   public void GIVEN_a_ITwoWayBinding_of_TestStruct_WHEN_Push_THEN_Update_is_fired_AND_Pull_returns_value()
   {
      static Property Property((TestStruct initalValue, TestStruct pushedValue) args)
      {
         //Arrange
         var binding = Bind.To(args.initalValue);
         var updated = FakeEventHandler.Create(handler => binding.Updated += handler);

         //Act
         binding.Push(args.pushedValue);

         //Assert
         return WasFireOnce(nameof(updated),
                            updated)
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