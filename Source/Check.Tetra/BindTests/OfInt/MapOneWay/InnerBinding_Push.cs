using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfInt.MapOneWay;

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
   //a_Binding_of_int_mapped_with_a_Func_of_int_to_int_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_int_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((int firstInnerValue, int secondInnerValue, int outerValue) args)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom = FakeFunction<int, int>.Create(args.outerValue);
         var updated = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<int>.Pull),
                             args.outerValue,
                             actual));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_mapped_with_a_Func_of_int_to_TestClass_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_TestClass_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((int firstInnerValue, int secondInnerValue) args,
                               TestClass outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom = FakeFunction<int, TestClass>.Create(outerValue);
         var updated = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<TestClass>.Pull),
                             outerValue,
                             actual));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int), TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_mapped_with_a_Func_of_int_to_TestStruct_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_TestStruct_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((int firstInnerValue, int secondInnerValue) args,
                               TestStruct outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom = FakeFunction<int, TestStruct>.Create(outerValue);
         var updated = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                             outerValue,
                             actual));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int), TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}