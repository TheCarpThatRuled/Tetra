using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfInt.MapOneWay;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_mapped_with_a_Func_of_int_to_int
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_int_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((int innerValue, int outerValue) args)
      {
         //Arrange
         var innerBinding = Bind.To(args.innerValue);
         var mapFrom      = FakeFunction<int, int>.Create(args.outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               args.innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<int>.Pull),
                         args.outerValue,
                         actual));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_AND_a_Func_of_int_to_TestClass
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_TestClass_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property(int       innerValue,
                               TestClass outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<int, TestClass>.Create(outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<TestClass>.Pull),
                         outerValue,
                         actual));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_AND_a_Func_of_int_to_TestStruct
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_int_mapped_with_a_Func_of_int_to_TestStruct_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property(int        innerValue,
                               TestStruct outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<int, TestStruct>.Create(outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                         outerValue,
                         actual));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}