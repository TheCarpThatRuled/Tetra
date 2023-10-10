using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestStruct.MapOneWay;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestStruct_mapped_with_a_Func_of_TestStruct_to_int
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestStruct_mapped_with_a_Func_of_TestStruct_to_int_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property
      (
         TestStruct innerValue,
         int        outerValue
      )
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<TestStruct, int>.Create(outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<int>.Pull),
                         outerValue,
                         actual));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestStruct_AND_a_Func_of_TestStruct_to_TestClass
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestStruct_mapped_with_a_Func_of_TestStruct_to_TestClass_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property
      (
         TestStruct innerValue,
         TestClass  outerValue
      )
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<TestStruct, TestClass>.Create(outerValue);

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
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestStruct_AND_a_Func_of_TestStruct_to_TestStruct
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestStruct_mapped_with_a_Func_of_TestStruct_to_TestStruct_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property
      (
         (TestStruct innerValue, TestStruct outerValue) args
      )
      {
         //Arrange
         var innerBinding = Bind.To(args.innerValue);
         var mapFrom      = FakeFunction<TestStruct, TestStruct>.Create(args.outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               args.innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                         args.outerValue,
                         actual));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}