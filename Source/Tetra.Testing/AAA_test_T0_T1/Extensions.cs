namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class AAA_test_Extensions
{

   /* ------------------------------------------------------------ */
   // IAction Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAction And<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAction first,
      AAA_test<TActions, TAsserts>.IAction      second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .CompoundAction
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAction Recharacterise<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAction action,
      string                                    characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .RecharacterisedAction
        .Create(characterisation,
                action);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAction Silence<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAction action
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .SilentAction
        .Create(action);

   /* ------------------------------------------------------------ */
   //  IAssert Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert And<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAssert first,
      AAA_test<TActions, TAsserts>.IAssert      second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .CompoundAssert
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Recharacterise<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAssert assert,
      string                                    characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .RecharacterisedAssert
        .Create(characterisation,
                assert);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IAssert Silence<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IAssert assert
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .SilentAssert
        .Create(assert);

   /* ------------------------------------------------------------ */
   //  IInitialAction Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IInitialAction And<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IInitialAction first,
      AAA_test<TActions, TAsserts>.IAction             second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .CompoundInitialAction
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IInitialAction Recharacterise<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IInitialAction action,
      string                                           characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .RecharacterisedInitialAction
        .Create(characterisation,
                action);

   /* ------------------------------------------------------------ */

   public static AAA_test<TActions, TAsserts>.IInitialAction Silence<TActions, TAsserts>
   (
      this AAA_test<TActions, TAsserts>.IInitialAction action
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      => AAA_test<TActions, TAsserts>
        .SilentInitialAction
        .Create(action);

   /* ------------------------------------------------------------ */
}