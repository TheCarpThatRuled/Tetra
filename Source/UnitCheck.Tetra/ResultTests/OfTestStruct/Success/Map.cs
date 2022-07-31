using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Map
{
   /* ------------------------------------------------------------ */
   // Result<T> Reduce(Func<Failure, Message> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_Failure_to_Message
   //THEN
   //whenFailure_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_Failure_to_Message_THEN_whenFailure_was_not_invoked_AND_this_is_returned()
   {
      static Property Property(TestStruct content,
                               Message    whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<Failure, Message>.Create(whenFailure);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenFailureFunc.Func);

         //Assert
         return AreReferenceEqual(AssertMessages.ReturnValue,
                                  result,
                                  actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailureFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<TestStruct, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Reduce<TNew>(Func<Success<T>, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct content,
                               int        whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<TestStruct>, int>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestStruct content,
                               TestClass  whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<TestStruct>, TestClass>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestStruct content,
                                  TestStruct whenSuccess) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<Success<TestStruct>, TestStruct>.Create(args.whenSuccess);

         var result = Result.Success(args.content);

         //Act
         var actual = result.Map(whenSuccess.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               args.content,
                               whenSuccess));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}