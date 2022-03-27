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
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //Reduce AND whenNone_is_a_Func_of_int AND whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenNone_was_invoked_once AND whenSome_was_not_invoked AND the_return_value_of_whenNone_is_returned

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
         return AreEqual(args.whenNone,
                         actual)
               .And(WasInvokedOnce(whenNone))
               .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}