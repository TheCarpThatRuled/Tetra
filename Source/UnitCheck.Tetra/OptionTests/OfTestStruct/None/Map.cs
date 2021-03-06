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
public class None_Map
{
   /* ------------------------------------------------------------ */
   // Option<TNew> Map<TNew>(Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_DateTime
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_DateTime_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(DateTime value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, DateTime>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Prop.ForAll<DateTime>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, int>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, TestClass>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_Map_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, TestStruct>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<TestStruct, Option<int>>.Create(Option.None());

      var option = Option<TestStruct>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(actual)
            .WasNotInvoked(whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<TestStruct, Option<string>>.Create(Option.None());

      var option = Option<TestStruct>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(actual)
            .WasNotInvoked(whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<TestStruct, Option<TestStruct>>.Create(Option.None());

      var option = Option<TestStruct>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(actual)
            .WasNotInvoked(whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<TestStruct, Option<TestStruct>>.Create(Option.None());

      var option = Option<TestStruct>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(actual)
            .WasNotInvoked(whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<int>>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<string>>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestClass>>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestStruct_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, Option<TestStruct>>.Create(value);

         var option = Option<TestStruct>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}