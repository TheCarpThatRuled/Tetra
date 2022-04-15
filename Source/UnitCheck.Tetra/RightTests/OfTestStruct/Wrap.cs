using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class Wrap
{
   /* ------------------------------------------------------------ */
   // Func<Right<T>, TNew> Wrap<TNew>(Func<TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_int_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestStruct content, int newValue)
      {
         //Arrange
         var func = FakeFunction<int>.Create(newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right       = Right<TestStruct>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestStruct content, TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass>.Create(newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right        = Right<TestStruct>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, TestClass> (Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestStruct content, TestStruct newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestStruct>.Create(args.newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right        = Right<TestStruct>.Create(args.content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(args.newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Func<Right<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_int_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestStruct content, int newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct, int>.Create(newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right = Right<TestStruct>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestStruct content, TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct, TestClass>.Create(newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right = Right<TestStruct>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   //GIVEN
   //Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestStruct
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_Wrap_AND_func_is_Func_of_TestStruct_to_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestStruct_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestStruct content, TestStruct newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestStruct, TestStruct>.Create(args.newValue);

         var wrappedFunc = Right<TestStruct>.Wrap(func.Func);
         var right = Right<TestStruct>.Create(args.content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(args.newValue,
                         actual)
           .And(WasInvokedOnce(args.content,
                               func));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}