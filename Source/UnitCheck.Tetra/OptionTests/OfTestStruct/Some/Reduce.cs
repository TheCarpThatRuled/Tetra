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
public class Some_Reduce
{
   /* ------------------------------------------------------------ */
   // T Reduce(T whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_an_TestStruct
   //THEN
   //the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_an_TestStruct_THEN_the_content_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenNone) args)
      {
         //Arrange
         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(args.whenNone);

         //Assert
         return AreEqual(args.value,
                         actual);
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // T Reduce(Func<T> whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_THEN_whenNone_was_not_invoked_AND_the_content_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenNone) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(whenNone.Func);

         //Assert
         return AreEqual(args.value,
                         actual)
           .And(WasNotInvoked(whenNone));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(TNew whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_int_AND_whenSome_is_a_Func_of_TestStruct_to_int_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, int>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestStruct, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value, (TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, TestClass>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<TestStruct, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestStruct value, TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestStruct, TestStruct>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasInvokedOnce(args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestStruct_to_int_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value, (int whenNone, int whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(args.whenNone);
         var whenSome = FakeFunction<TestStruct, int>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestStruct, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestStruct_to_TestClass_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property(TestStruct value, (TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);
         var whenSome = FakeFunction<TestStruct, TestClass>.Create(args.whenSome);

         var option = Option.Some(value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<TestStruct, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_TestStruct_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((TestStruct value,TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);
         var whenSome = FakeFunction<TestStruct, TestStruct>.Create(args.whenSome);

         var option = Option.Some(args.value);

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(args.value,
                                   whenSome));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll< (TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}