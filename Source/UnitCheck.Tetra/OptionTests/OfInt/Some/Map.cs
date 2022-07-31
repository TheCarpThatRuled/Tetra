using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_Map
{
   /* ------------------------------------------------------------ */
   // Option<TNew> Map<TNew>(Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_int_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((int value,int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<int, int>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        args.whenSome,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int,int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_TestClass_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(int value, TestClass whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<int, TestClass>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        whenSome,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSomeFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_TestStruct_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(int value, TestStruct whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<int, TestStruct>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        whenSome,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSomeFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_uint
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_uint_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(int value, uint whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<int, uint>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        whenSome,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSomeFunc));
      }

      Prop.ForAll<int, uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<int>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<TestClass>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<TestStruct>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<uint>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property((int value, int newValue) args)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<int>>.Create(args.newValue);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        args.newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int,int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value,
                               TestClass newValue)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<TestClass>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value,
                               TestStruct newValue)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<TestStruct>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(int value, uint newValue)
      {
         //Arrange
         var whenSome = FakeFunction<int, Option<uint>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Prop.ForAll<int, uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}