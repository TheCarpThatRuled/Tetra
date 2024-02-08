namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class AAA_property_test_Extensions
{

   /* ------------------------------------------------------------ */
   // IAction Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAction And<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAction first,
      AAA_property_test<TParameters, TActions, TAsserts>.IAction      second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .CompoundAction
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAction Recharacterise<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAction action,
      string                                                          characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .RecharacterisedAction
        .Create(characterisation,
                action);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAction Silence<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAction action
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .SilentAction
        .Create(action);

   /* ------------------------------------------------------------ */
   //  IAssert Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAssert And<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAssert first,
      AAA_property_test<TParameters, TActions, TAsserts>.IAssert      second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .CompoundAssert
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAssert Recharacterise<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAssert assert,
      string                                                          characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .RecharacterisedAssert
        .Create(characterisation,
                assert);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IAssert Silence<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IAssert assert
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .SilentAssert
        .Create(assert);

   /* ------------------------------------------------------------ */
   //  IInitialAction Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction And<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction first,
      AAA_property_test<TParameters, TActions, TAsserts>.IAction             second
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .CompoundInitialAction
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction Recharacterise<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction action,
      string                                                                 characterisation
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .RecharacterisedInitialAction
        .Create(characterisation,
                action);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction Silence<TParameters, TActions, TAsserts>
   (
      this AAA_property_test<TParameters, TActions, TAsserts>.IInitialAction action
   )
      where TActions : TestEnvironment<TActions, TAsserts>
      where TAsserts : IPropertyAsserts
      => AAA_property_test<TParameters, TActions, TAsserts>
        .SilentInitialAction
        .Create(action);

   /* ------------------------------------------------------------ */
}