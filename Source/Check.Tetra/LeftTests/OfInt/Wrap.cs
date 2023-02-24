using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Left)]
// ReSharper disable once InconsistentNaming
public class Wrap
{
   /* ------------------------------------------------------------ */
   // public static Func<Left<T>, TNew> Wrap<TNew>(Func<TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_int_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((int content, int newValue) args)
      {
         //Arrange
         var func = FakeFunction<int>.Create(args.newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(args.content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(int       content,
                               TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<TestClass>.Create(newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(int        content,
                               TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<TestStruct>.Create(newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               func));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Func<Left<T>, TNew> Wrap<TNew>(Func<T, TNew> func)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_int_to_int
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_int_to_int_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property((int content, int newValue) args)
      {
         //Arrange
         var func = FakeFunction<int, int>.Create(args.newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(args.content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               args.content,
                               func));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_int_to_TestClass
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_int_to_TestClass_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(int       content,
                               TestClass newValue)
      {
         //Arrange
         var func = FakeFunction<int, TestClass>.Create(newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               content,
                               func));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_int_Wrap_AND_func_is_Func_of_int_to_TestStruct
   //WHEN
   //the_wrapped_func_is_invoked_with_a_Left_of_int
   //THEN
   //func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_int_Wrap_AND_func_is_Func_of_int_to_TestStruct_WHEN_the_wrapped_func_is_invoked_with_a_Left_of_int_THEN_func_is_invoked_once_with_the_content_AND_the_return_value_of_func_is_returned()
   {
      static Property Property(int        content,
                               TestStruct newValue)
      {
         //Arrange
         var func = FakeFunction<int, TestStruct>.Create(newValue);

         var wrappedFunc = Left<int>.Wrap(func.Func);
         var left        = Left<int>.Create(content);

         //Act
         var actual = wrappedFunc(left);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         newValue,
                         actual)
           .And(WasInvokedOnce(nameof(func),
                               content,
                               func));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}