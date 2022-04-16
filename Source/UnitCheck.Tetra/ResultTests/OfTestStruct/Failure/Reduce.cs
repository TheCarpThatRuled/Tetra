using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
   //                   Func<Success<T>, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_int_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_THEN_whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(Message content, (int whenFailure, int whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, int>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<TestStruct>, int>.Create(args.whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenFailure,
                         actual)
               .And(WasInvokedOnce(content,
                                   whenFailure))
               .And(WasNotInvoked(whenSuccess));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<Message,(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestClass_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_THEN_whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(Message content, (TestClass whenFailure, TestClass whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestClass>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<TestStruct>, TestClass>.Create(args.whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenFailure,
                         actual)
               .And(WasInvokedOnce(content,
                                   whenFailure))
               .And(WasNotInvoked(whenSuccess));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<Message, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_whenFailure_is_a_Func_of_Failure_to_TestStruct_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_THEN_whenFailure_was_invoked_once_with_the_content_AND_whenSuccess_was_not_invoked_AND_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property(Message content, (TestStruct whenFailure, TestStruct whenSuccess) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, TestStruct>.Create(args.whenFailure);
         var whenSuccess = FakeFunction<Success<TestStruct>, TestStruct>.Create(args.whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Reduce(whenFailure.Func,
                                    whenSuccess.Func);

         //Assert
         return AreEqual(args.whenFailure,
                         actual)
               .And(WasInvokedOnce(content,
                                   whenFailure))
               .And(WasNotInvoked(whenSuccess));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<Message, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}