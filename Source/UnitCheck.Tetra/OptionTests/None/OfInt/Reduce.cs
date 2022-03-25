using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_OfInt_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<TNew> whenNone,
   //                   Func<T, TNew> whenSome)
   /* ------------------------------------------------------------ */


   //GIVEN
   //Some_of_int
   //WHEN
   //Reduce AND whenNone_is_a_Func_of_int AND whenSome_is_a_Func_of_int_to_int
   //THEN
   //whenNone_was_not_invoked AND whenSome_was_invoked_once_with_the_content AND a_some_containing_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_of_int_WHEN_Reduce_AND_whenNone_is_a_Func_of_int_AND_whenSome_is_a_Func_of_int_to_int_THEN_whenNone_was_not_invoked_AND_whenSome_was_invoked_once_with_the_content_AND_a_some_containing_content_is_returned()
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

      Arb.Register<TwoUniqueInts>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }
   /* -------------------------------------------------- */

   // ReSharper disable once ClassNeverInstantiated.Local
   public sealed class TwoUniqueInts
   {
      /* -------------------------------------------------- */

      // ReSharper disable once UnusedMember.Local
      public static Arbitrary<(int, int)> Type()
         => Arb
           .Default
           .Int32()
           .Generator
           .Two()
           .Where(tuple => tuple.Item1 != tuple.Item2)
           .Select(tuple => (tuple.Item1,
                             tuple.Item2))
           .ToArbitrary();

      /* -------------------------------------------------- */
   }

   /* ------------------------------------------------------------ */
}