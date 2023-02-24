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
public class None_Reduce
{
   /* ------------------------------------------------------------ */
   // public T Reduce(T whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_an_TestClass
   //THEN
   //whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_an_TestClass_THEN_whenNone_is_returned()
   {
      static Property Property(TestClass whenNone)
      {
         //Arrange
         var option = Option<TestClass>.None();

         //Act
         var actual = option.Reduce(whenNone);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         whenNone,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public T Reduce(Func<T> whenNone)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass
   //THEN
   //whenNone_was_invoked_once_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_THEN_whenNone_was_invoked_once_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(TestClass whenNone)
      {
         //Arrange
         var whenNoneFunc = FakeFunction<TestClass>.Create(whenNone);

         var option = Option<TestClass>.None();

         //Act
         var actual = option.Reduce(whenNoneFunc.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         whenNone,
                         actual)
           .And(WasInvokedOnce(nameof(whenNone),
                               whenNoneFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public TNew Reduce<TNew>(Func<TNew>    whenNone,
   //                          Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenSome_was_not_invoked_AND_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_an_int_AND_whenSome_is_a_Func_of_TestClass_to_int_THEN_whenSome_was_not_invoked_AND_whenNone_is_returned()
   {
      static Property Property((int whenNone, int whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, int>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSome_was_not_invoked_AND_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass_THEN_whenSome_was_not_invoked_AND_whenNone_is_returned()
   {
      static Property Property((TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, TestClass>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenSome_was_not_invoked_AND_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct_THEN_whenSome_was_not_invoked_AND_whenNone_is_returned()
   {
      static Property Property((TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<TestClass, TestStruct>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestClass_to_int
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_TestClass_to_int_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((int whenNone, int whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, int>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestClass_AND_whenSome_is_a_Func_of_TestClass_to_TestClass_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestClass whenNone, TestClass whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, TestClass>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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
   //None_of_TestClass
   //WHEN
   //Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_of_TestClass_WHEN_Reduce_AND_whenNone_is_a_Func_of_TestStruct_AND_whenSome_is_a_Func_of_TestClass_to_TestStruct_THEN_whenNone_was_invoked_once_AND_whenSome_was_not_invoked_AND_the_return_value_of_whenNone_is_returned()
   {
      static Property Property((TestStruct whenNone, TestStruct whenSome) args)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(args.whenNone);
         var whenSome = FakeFunction<TestClass, TestStruct>.Create(args.whenSome);

         var option = Option<TestClass>.None();

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