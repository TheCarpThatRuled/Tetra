using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TNew>    whenSuccess,
   //                   Func<T, TNew> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_int_AND_whenFailure_is_a_Func_of_int_to_int
   //THEN
   //whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_int_AND_whenFailure_is_a_Func_of_int_to_int_THEN_whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((int value, int whenSuccess, int whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<int>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, int>.Create(args.whenFailure);

         var result = Tetra.Result.Failure(args.value);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   args.value,
                                   whenFailure));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_TestClass_AND_whenFailure_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_TestClass_AND_whenFailure_is_a_Func_of_int_to_TestClass_THEN_whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int                                            value,
                               (TestClass whenSuccess, TestClass whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<TestClass>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestClass>.Create(args.whenFailure);

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   value,
                                   whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<int, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_AND_whenFailure_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_AND_whenFailure_is_a_Func_of_int_to_TestStruct_THEN_whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(int                                              value,
                               (TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<TestStruct>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestStruct>.Create(args.whenFailure);

         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenFailure,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   value,
                                   whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<int, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}