using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

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
   //Some_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_DateTime
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_DateTime_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value,
                               DateTime whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestStruct, DateTime>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(whenSome,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSomeFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_int_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value,
                               int whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestStruct, int>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(whenSome,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSomeFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value,
                               TestClass whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestStruct, TestClass>.Create(whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSomeFunc.Func);

         //Assert
         return IsASome(whenSome,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSomeFunc));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, TestStruct>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(args.whenSome,
                        actual)
           .And(WasInvokedOnce(args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_DateTime
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_DateTime_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<DateTime>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<int>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestClass>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestStruct>>.Create(Option.None());

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_DateTime
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_DateTime_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value,
                               DateTime newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<DateTime>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(newValue,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value, int newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<int>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(newValue,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestStruct value,
                               TestClass newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestClass>>.Create(newValue);

         var option = Option.Some(value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(newValue,
                        actual)
           .And(WasInvokedOnce(value,
                               whenSome));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property((TestStruct value, TestStruct newValue) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestStruct>>.Create(args.newValue);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsASome(args.newValue,
                        actual)
           .And(WasInvokedOnce(args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}