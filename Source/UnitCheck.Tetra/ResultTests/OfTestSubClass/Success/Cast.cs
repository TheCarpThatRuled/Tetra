using Check.Data;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestSubClass;

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
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_int
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_int_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestSubClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>();

         //Assert
         return IsAFailure(Messages.CastFailed<TestSubClass, int>(),
                           actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestClass_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestStruct_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestSubClass  content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>();

         //Assert
         return IsAFailure(Messages.CastFailed<TestSubClass, TestStruct>(),
                           actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestSubClass_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>();

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Message whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_int_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFails);

         //Assert
         return IsAFailure(whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Message_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFails);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
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
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Message_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFails);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Func<Success<T>, Message> whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_int_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<TestSubClass>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(whenCastFails,
                           actual)
           .And(WasInvokedOnce(content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<TestSubClass>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFailsFunc.Func);

         //Assert
         return IsASuccess(content,
                           actual)
           .And(WasNotInvoked(whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<TestSubClass>, Message>.Create(whenCastFails);

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
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestSubClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_Success_of_TestSubClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<Success<TestSubClass>, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFailsFunc.Func);

         //Assert
         return IsASuccess(content,
                           actual)
           .And(WasNotInvoked(whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}