using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
   //                   Func<Success<T>, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_Success_of_int_to_int
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_Success_of_int_to_int_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((int value, int whenFailure, int whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, int>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<int>, int>.Create(args.whenSuccess);

         var result = Result.Success(args.value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenSuccess,
                         actual)
               .And(WasNotInvoked(whenFailure))
               .And(WasInvokedOnce(args.value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestClass
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestClass_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(int value, (TestClass whenFailure, TestClass whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestClass>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<int>, TestClass>.Create(args.whenSuccess);

         var result = Result.Success(value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenSuccess,
                         actual)
               .And(WasNotInvoked(whenFailure))
               .And(WasInvokedOnce(value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<int, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestStruct
   //THEN
   //whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestStruct_THEN_whenFailure_was_not_invoked_AND_whenSuccess_was_invoked_once_with_the_content_AND_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(int value, (TestStruct whenFailure, TestStruct whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestStruct>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<int>, TestStruct>.Create(args.whenSuccess);

         var result = Result.Success(value);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenSuccess,
                         actual)
               .And(WasNotInvoked(whenFailure))
               .And(WasInvokedOnce(value,
                                   whenSuccess));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<int, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}