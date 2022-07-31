using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_Reduce
{
   /* ------------------------------------------------------------ */
   // T Reduce(T whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_an_TestClass
   //THEN
   //the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_an_TestClass_THEN_the_content_is_returned()
   {
      static Property Property((TestClass value, TestClass whenNone) args)
      {
         //Arrange
         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(args.whenNone);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.value,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // T Reduce(Func<T> whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass
   //THEN
   //whenNone_was_not_invoked_AND_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_THEN_whenNone_was_not_invoked_AND_the_content_is_returned()
   {
      static Property Property((TestClass value, TestClass whenNone) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(whenNone.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.value,
                         actual)
           .And(WasNotInvoked(nameof(whenNone),
                              whenNone));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(TNew whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_TestClass_to_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, int>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasInvokedOnce(nameof(whenSome),
                                   value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestClass, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestClass value, TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, TestClass>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasInvokedOnce(nameof(whenSome),
                                   args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value, (TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, TestStruct>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasInvokedOnce(nameof(whenSome),
                                   value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<TestClass, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestClass_to_int_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, int>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasNotInvoked(nameof(whenNone),
                                  whenNone))
               .And(WasInvokedOnce(nameof(whenSome),
                                   value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestClass, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestClass value, TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, TestClass>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasNotInvoked(nameof(whenNone),
                                  whenNone))
               .And(WasInvokedOnce(nameof(whenSome),
                                   args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestClass value,(TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, TestStruct>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenSome,
                         actual)
               .And(WasNotInvoked(nameof(whenNone),
                                  whenNone))
               .And(WasInvokedOnce(nameof(whenSome),
                                   value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll< TestClass, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}