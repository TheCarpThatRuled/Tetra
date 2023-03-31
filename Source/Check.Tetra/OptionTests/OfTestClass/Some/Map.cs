using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_Map
{
   /* ------------------------------------------------------------ */
   // public Option<TNew> Map<TNew>(Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_int_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value,
                               int       whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestClass, int>.Create(whenSome);

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

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_string
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_string_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value,
                               string    whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestClass, string>.Create(whenSome);

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

      Prop.ForAll<TestClass, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_TestClass_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestClass value, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, TestClass>.Create(args.whenSome);

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

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass  value,
                               TestStruct whenSome)
      {
         //Arrange
         var whenSomeFunc = FakeFunction<TestClass, TestStruct>.Create(whenSome);

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
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<int>>.Create(Option<int>.None());

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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<string>>.Create(Option<string>.None());

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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<TestClass>>.Create(Option<TestClass>.None());

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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<TestStruct>>.Create(Option<TestStruct>.None());

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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value,
                               int       newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<int>>.Create(Option.Some(newValue));

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

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_string_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass value,
                               string    newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<string>>.Create(Option.Some(newValue));

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

      Prop.ForAll<TestClass, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property((TestClass value, TestClass newValue) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<TestClass>>.Create(Option.Some(args.newValue));

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

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_TestClass_to_Option_of_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(TestClass  value,
                               TestStruct newValue)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, IOption<TestStruct>>.Create(Option.Some(newValue));

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
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}