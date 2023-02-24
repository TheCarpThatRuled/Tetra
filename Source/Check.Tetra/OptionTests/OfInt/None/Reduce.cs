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
public class None_Reduce
{
   /* ------------------------------------------------------------ */
   // public T Reduce(T whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_an_int
   //THEN
   //whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_an_int_THEN_whenNone_is_returned()
   {
      static Property Property(int whenNone)
      {
         //Arrange
         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(whenNone);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         whenNone,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce(Func<T> whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int
   //THEN
   //whenNone_was_invoked_once_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_THEN_whenNone_was_invoked_once_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(int whenNone)
      {
         //Arrange
         var whenNoneFunc = FakeFunction<int>.Create(whenNone);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(whenNoneFunc.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         whenNone,
                         actual)
           .And(WasInvokedOnce(nameof(whenNone),
                               whenNoneFunc));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public TNew Reduce<TNew>(TNew          whenNone,
   //                          Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenSome_was_not_invoked_AND_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_int_to_int_THEN_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((int whenNone, int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<int, int>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_int_to_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_int_to_TestClass_THEN_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<int, TestClass>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_int_to_TestStruct_THEN_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<int, TestStruct>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(args.whenNone,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
           .And(WasNotInvoked(nameof(whenSome),
                              whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public TNew Reduce<TNew>(Func<TNew>    whenNone,
   //                          Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_int_to_int_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((int whenNone, int whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(args.whenNone);
         var whenSome = FakeFunction<int, int>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
               .And(WasInvokedOnce(nameof(whenNone),
                                   whenNone))
               .And(WasNotInvoked(nameof(whenSome),
                                  whenSome));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_int_to_TestClass
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_int_to_TestClass_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);
         var whenSome = FakeFunction<int, TestClass>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
               .And(WasInvokedOnce(nameof(whenNone),
                                   whenNone))
               .And(WasNotInvoked(nameof(whenSome),
                                  whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_int_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_int_to_TestStruct_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);
         var whenSome = FakeFunction<int, TestStruct>.Create(args.whenSome);

         var option = Option<int>.None();

         //Act
         var actual = option.Reduce(whenNone.Func,
                                    whenSome.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenNone,
                         actual)
               .And(WasInvokedOnce(nameof(whenNone),
                                   whenNone))
               .And(WasNotInvoked(nameof(whenSome),
                                  whenSome));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}