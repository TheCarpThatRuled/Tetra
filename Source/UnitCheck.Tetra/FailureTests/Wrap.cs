using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FailureTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Failure)]
// ReSharper disable once InconsistentNaming
public class Wrap
{
   /* ------------------------------------------------------------ */
   // Func<Failure<T>, TNew> Wrap<TNew>(Func<TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_int_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, int newValue)
      {
         //Arrange
         var func = FakeFunction<int>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure        = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure        = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass> (Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure        = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Func<Failure<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_Message_to_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_Message_to_int_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, int newValue)
      {
         //Arrange
         var func = FakeFunction<Message, int>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_Message_to_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_Message_to_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<Message, TestClass>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Failure_Wrap_AND_func_is_Func_of_Message_to_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Failure
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Failure_Wrap_AND_func_is_Func_of_Message_to_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Failure_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(Message content, TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<Message, TestStruct>.Create(newValue);

         var wrappedFunc = Failure.Wrap(func.Func);
         var failure = Failure.Create(content);

         //Act
         var actual = wrappedFunc(failure);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}