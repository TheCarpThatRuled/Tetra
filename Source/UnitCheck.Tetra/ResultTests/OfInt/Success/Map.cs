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
public class Success_Map
{
   /* ------------------------------------------------------------ */
   // Result<T> Reduce(Func<Failure, Message> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_Failure_to_Message
   //THEN
   //whenFailure_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Map_AND_whenFailure_is_a_Func_of_Failure_to_Message_THEN_whenFailure_was_not_invoked_AND_this_is_returned()
   {
      static Property Property(int     content,
                               Message whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<Failure, Message>.Create(whenFailure);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenFailureFunc.Func);

         //Assert
         return AreReferenceEqual(result,
                                  actual)
           .And(WasNotInvoked(whenFailureFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Reduce<TNew>(Func<Success<T>, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_int
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_int_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((int content, int whenSuccess) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<Success<int>, int>.Create(args.whenSuccess);

         var result = Result.Success(args.content);

         //Act
         var actual = result.Map(whenSuccess.Func);

         //Assert
         return IsASuccess(args.whenSuccess,
                           actual)
           .And(WasInvokedOnce(args.content,
                               whenSuccess));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestClass
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestClass_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(int       content,
                               TestClass whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<int>, TestClass>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(whenSuccess,
                           actual)
           .And(WasInvokedOnce(content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_int_to_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(int        content,
                               TestStruct whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<int>, TestStruct>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(whenSuccess,
                           actual)
           .And(WasInvokedOnce(content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}