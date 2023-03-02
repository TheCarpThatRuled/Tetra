using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Cast
{
   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_int
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_int_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Messages.CastFailed<TestClass, int>(),
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_string
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_string_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<string>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Messages.CastFailed<TestClass, string>(),
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass_AND_the_content_is_a_TestClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_TestClass_AND_the_content_is_a_TestClass_WHEN_Cast_to_TestClass_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass_AND_the_content_is_a_TestSubClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_TestClass_AND_the_content_is_a_TestSubClass_WHEN_Cast_to_TestClass_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass content)
      {
         //Arrange
         var result = Result<TestClass>.Success(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestStruct_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Messages.CastFailed<TestClass, TestStruct>(),
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_failure_containing_cast_failed_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestSubClass_THEN_a_failure_containing_cast_failed_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>();

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Messages.CastFailed<TestClass, TestSubClass>(),
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Message whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_int_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_string_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_string_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<string>(whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Message_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFails);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>(whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Message
   //THEN
   //a_failure_containing_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Message_THEN_a_failure_containing_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFails);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>(Func<T, Message> whenCastFails)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_int_AND_whenCastFails_is_a_Func_of_TestClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_int_AND_whenCastFails_is_a_Func_of_TestClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<TestClass, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<int>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual)
           .And(WasInvokedOnce(nameof(whenCastFails),
                               content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_string_AND_whenCastFails_is_a_Func_of_TestClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_string_AND_whenCastFails_is_a_Func_of_TestClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<TestClass, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<string>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual)
           .And(WasInvokedOnce(nameof(whenCastFails),
                               content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_TestClass_to_Message
   //THEN
   //whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestClass_AND_whenCastFails_is_a_Func_of_TestClass_to_Message_THEN_whenCastFails_was_not_invoked_AND_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<TestClass, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestClass>(whenCastFailsFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenCastFails),
                              whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_TestClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestStruct_AND_whenCastFails_is_a_Func_of_TestClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<TestClass, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestStruct>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual)
           .And(WasInvokedOnce(nameof(whenCastFails),
                               content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_TestClass_to_Message
   //THEN
   //whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned

   [TestMethod]
   public void GIVEN_TestClass_WHEN_Cast_to_TestSubClass_AND_whenCastFails_is_a_Func_of_TestClass_to_Message_THEN_whenCastFails_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_whenCastFails_is_returned()
   {
      static Property Property(TestClass content, Message whenCastFails)
      {
         //Arrange
         var whenCastFailsFunc = FakeFunction<TestClass, Message>.Create(whenCastFails);

         var result = Result.Success(content);

         //Act
         var actual = result.Cast<TestSubClass>(whenCastFailsFunc.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenCastFails,
                           actual)
           .And(WasInvokedOnce(nameof(whenCastFails),
                               content,
                               whenCastFailsFunc));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}