using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_Map
{
   /* ------------------------------------------------------------ */
   // public Option<TNew> Map<TNew>(Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, int>.Create(value);

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<int, TestClass>.Create(value);

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<int, TestStruct>.Create(value);

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_uint
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_uint_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(uint value)
      {
         //Arrange
         var whenSome = FakeFunction<int, uint>.Create(value);

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Prop.ForAll<uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<int, IOption<int>>.Create(Option<int>.None());

      var option = Option<int>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<int, IOption<TestClass>>.Create(Option<TestClass>.None());

      var option = Option<int>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<int, IOption<TestStruct>>.Create(Option<TestStruct>.None());

      var option = Option<int>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<int, IOption<uint>>.Create(Option<uint>.None());

      var option = Option<int>.None();

      //Act
      var actual = option.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_int_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSome = FakeFunction<int, IOption<int>>.Create(Option.Some(value));

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestClass_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<int, IOption<TestClass>>.Create(Option.Some(value));

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_TestStruct_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSome = FakeFunction<int, IOption<TestStruct>>.Create(Option.Some(value));

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */


   //GIVEN
   //None_of_int_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_int_to_Option_of_uint_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(uint value)
      {
         //Arrange
         var whenSome = FakeFunction<int, IOption<uint>>.Create(Option.Some(value));

         var option = Option<int>.None();

         //Act
         var actual = option.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Prop.ForAll<uint>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}