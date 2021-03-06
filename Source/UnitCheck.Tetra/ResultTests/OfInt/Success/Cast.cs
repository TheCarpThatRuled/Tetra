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
public class Success_Cast
{
   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_int
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_int_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>();

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestClass_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsAFailure(Messages.CastFailed<int, TestClass>(),
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestStruct_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>();

         //Assert
         return IsAFailure(Messages.CastFailed<int, TestStruct>(),
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestSubClass_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>();

         //Assert
         return IsAFailure(Messages.CastFailed<int, TestSubClass>(),
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_uint
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_uint_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<uint>();

         //Assert
         return IsAFailure(Messages.CastFailed<int, uint>(),
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Message whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Message
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_int_AND_whenCastFails_is_a_Message_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFails);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFails);

         //Assert
         return IsAFailure(whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>(whenCastFails);

         //Assert
         return IsAFailure(whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFails);

         //Assert
         return IsAFailure(whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_uint_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_uint_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<uint>(whenCastFails);

         //Assert
         return IsAFailure(whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Func<Success<T>, Message> whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_int_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<int>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFailsFunc.Func);

         //Assert
         return IsASuccess(content,
                           actual)
           .And(WasNotInvoked(whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<int>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(whenCastFails,
                           actual)
           .And(WasInvokedOnce(content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<int>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(whenCastFails,
                           actual)
           .And(WasInvokedOnce(content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<int>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(whenCastFails,
                           actual)
           .And(WasInvokedOnce(content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //Cast_to_uint_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_Cast_to_uint_AND_whenCastFails_is_a_Func_of_Success_of_int_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(int content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<int>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<uint>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(whenCastFails,
                           actual)
           .And(WasInvokedOnce(content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}