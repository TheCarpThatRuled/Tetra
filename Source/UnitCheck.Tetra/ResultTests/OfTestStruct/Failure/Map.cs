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
public class Failure_Map
{
   /* ------------------------------------------------------------ */
   // Result<T> Reduce(Func<Failure, Message> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenFailure_is_a_Func_of_Failure_to_Message
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Map_AND_whenFailure_is_a_Func_of_Failure_to_Message_THEN_whenFailure_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((Message content, Message whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, Message>.Create(args.whenFailure);

         var result = Result<TestStruct>.Failure(args.content);

         //Act
         var actual = result.Map(whenFailure.Func);

         //Assert
         return IsAFailure(args.whenFailure,
                           actual)
           .And(WasInvokedOnce(args.content,
                               whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Reduce<TNew>(Func<Success<T>, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_int_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message content,
                               int     whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<TestStruct>, int>.Create(whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(content,
                           actual)
           .And(WasNotInvoked(whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestClass_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message   content,
                               TestClass whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<TestStruct>, TestClass>.Create(whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(content,
                           actual)
           .And(WasNotInvoked(whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_Success_of_TestStruct_to_TestStruct_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message    content,
                               TestStruct whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<Success<TestStruct>, TestStruct>.Create(whenSuccess);

         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(content,
                           actual)
           .And(WasNotInvoked(whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}