using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Left)]
// ReSharper disable once InconsistentNaming
public class Wrap
{
   /* ------------------------------------------------------------ */
   // Func<Left<T>, TNew> Wrap<TNew>(Func<TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_int_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content, int newValue)
      {
         //Arrange
         var func = FakeFunction<int>.Create(newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left        = Left<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestClass content, TestClass newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestClass>.Create(args.newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left        = Left<TestClass>.Create(args.content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(args.newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)> (Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content, TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct>.Create(newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left        = Left<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(func));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Func<Left<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_int_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content, int newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass, int>.Create(newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left = Left<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestClass content, TestClass newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestClass, TestClass>.Create(args.newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left = Left<TestClass>.Create(args.content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(args.newValue,
                         actual)
           .And(WasInvokedOnce(args.content,
                               func));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content, TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass, TestStruct>.Create(newValue);

         var wrappedFunc = Left<TestClass>.Wrap(func.Func);
         var left = Left<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(newValue,
                         actual)
           .And(WasInvokedOnce(content,
                               func));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}