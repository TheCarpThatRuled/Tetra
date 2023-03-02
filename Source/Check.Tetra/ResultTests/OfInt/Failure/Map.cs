using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_int_to_int
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_int_to_int_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message content,
                               int     whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<int, int>.Create(whenSuccess);

         var result = Result<int>.Failure(content);

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
   //Failure_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_int_to_TestClass_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message   content,
                               TestClass whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<int, TestClass>.Create(whenSuccess);

         var result = Result<int>.Failure(content);

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
   //Failure_of_int
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_int_to_TestStruct_THEN_whenSuccess_was_not_invoked_AND_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message    content,
                               TestStruct whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<int, TestStruct>.Create(whenSuccess);

         var result = Result<int>.Failure(content);

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