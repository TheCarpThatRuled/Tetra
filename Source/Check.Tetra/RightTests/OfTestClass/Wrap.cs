﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class Wrap
{
   /* ------------------------------------------------------------ */
   // public static Func<Right<T>, TNew> Wrap<TNew>(Func<TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_int_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content,
                               int       newValue)
      {
         //Arrange
         var func = FakeFunction<int>.Create(newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestClass content, TestClass newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestClass>.Create(args.newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(args.content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass  content,
                               TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct>.Create(newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Func<Right<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_int_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass content,
                               int       newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass, int>.Create(newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               content,
                               func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((TestClass content, TestClass newValue) args)
      {
         //Arrange
         var func = FakeFunction<TestClass, TestClass>.Create(args.newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(args.content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               args.content,
                               func));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Right_of_TestClass
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Right_of_TestClass_Wrap_AND_func_is_Func_of_TestClass_to_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Right_of_TestClass_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(TestClass  content,
                               TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass, TestStruct>.Create(newValue);

         var wrappedFunc = Right<TestClass>.Wrap(func.Func);
         var right       = Right<TestClass>.Create(content);

         //Act
         var actual = wrappedFunc(right);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               content,
                               func));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}