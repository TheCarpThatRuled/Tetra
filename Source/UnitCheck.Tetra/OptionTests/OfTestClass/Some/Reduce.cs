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
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce AND whenNone_is_a_Func_of_int AND whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenNone_was_not_invoked AND whenSome_was_invoked_once_with_the_content AND the_return_value_of_whenSome_is_returned

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
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Library_TestClass_AND_TwoUniqueInt32s>();

      Prop.ForAll<TestClass, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_TestClass_AND_TwoUniqueInt32s
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<TestClass> TestClass()
         => Generators
           .TestClass()
           .ToArbitrary();

      /* ------------------------------------------------------------ */

      public static Arbitrary<(int, int)> TwoUniqueInt32s()
         => Generators
           .TwoUniqueInt32s()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Reduce AND whenNone_is_a_Func_of_TestClass AND whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenNone_was_not_invoked AND whenSome_was_invoked_once_with_the_content AND the_return_value_of_whenSome_is_returned

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
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(args.value,
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
   //Reduce AND whenNone_is_a_Func_of_TestStruct AND whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenNone_was_not_invoked AND whenSome_was_invoked_once_with_the_content AND the_return_value_of_whenSome_is_returned

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
         return AreEqual(args.whenSome,
                         actual)
               .And(WasNotInvoked(whenNone))
               .And(WasInvokedOnce(value,
                                   whenSome));
      }

      Arb.Register<Library_TestClass_AND_TwoUniqueTestStructs>();

      Prop.ForAll< TestClass, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_TestClass_AND_TwoUniqueTestStructs
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<TestClass> TestClass()
         => Generators
           .TestClass()
           .ToArbitrary();

      /* ------------------------------------------------------------ */

      public static Arbitrary<(TestStruct, TestStruct)> TwoUniqueTestStructs()
         => Generators
           .TwoUniqueTestStructs()
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}