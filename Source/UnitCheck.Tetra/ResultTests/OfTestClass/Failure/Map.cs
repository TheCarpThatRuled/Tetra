using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_int
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_int_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message content,
                               int     whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestClass, int>.Create(whenSuccess);

         var result = Result<TestClass>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenSuccess),
                              whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestClass_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message   content,
                               TestClass whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestClass, TestClass>.Create(whenSuccess);

         var result = Result<TestClass>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenSuccess),
                              whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestStruct_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message    content,
                               TestStruct whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestClass, TestStruct>.Create(whenSuccess);

         var result = Result<TestClass>.Failure(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenSuccess),
                              whenSuccessFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}