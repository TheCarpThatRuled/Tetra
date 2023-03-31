using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Reduce
{
   /* ------------------------------------------------------------ */
   // public TNew Reduce<TNew>(Func<TNew>    whenSuccess,
   //                          Func<T, TNew> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_int_AND_whenFailure_is_a_Func_of_int_to_int
   //THEN
   //whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_int_AND_whenFailure_is_a_Func_of_int_to_int_THEN_whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((int whenSuccess, int whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<int>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, int>.Create(args.whenFailure);

         var result = Result<int>.Success();

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_TestClass_AND_whenFailure_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_TestClass_AND_whenFailure_is_a_Func_of_int_to_TestClass_THEN_whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestClass whenSuccess, TestClass whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<TestClass>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestClass>.Create(args.whenFailure);

         var result = Result<int>.Success();

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_AND_whenFailure_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenSuccess_is_a_Func_of_TestStruct_AND_whenFailure_is_a_Func_of_int_to_TestStruct_THEN_whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct whenSuccess, TestStruct whenFailure) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<TestStruct>.Create(args.whenSuccess);
         var whenFailure = FakeFunction<int, TestStruct>.Create(args.whenFailure);

         var result = Result<int>.Success();

         //Act
         var actual = result.Reduce(whenSuccess.Func,
                                    whenFailure.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSuccess,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}