using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_Reduce
{
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
         var actual = option.Reduce(whenSome.Func,
                                    whenNone.Func);

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
         var actual = option.Reduce(whenSome.Func,
                                    whenNone.Func);

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
         var actual = option.Reduce(whenSome.Func,
                                    whenNone.Func);

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