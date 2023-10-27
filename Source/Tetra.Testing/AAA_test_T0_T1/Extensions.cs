namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class AAA_test_Extensions
{
    /* ------------------------------------------------------------ */
    //  IAct Extensions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAct And<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAct first,
       AAA_test<TActions, TAsserts>.IAct second
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .CompoundAct
         .Create(first,
                 second);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAct Recharacterise<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAct act,
       string characterisation
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .RecharacterisedAct
         .Create(characterisation,
                 act);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAct Silence<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAct act
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .SilentAct
         .Create(act);

    /* ------------------------------------------------------------ */
    //   IArrange Extensions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrange And<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrange first,
       AAA_test<TActions, TAsserts>.IArrange second
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .CompoundArrange
         .Create(first,
                 second);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrange Recharacterise<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrange arrange,
       string characterisation
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .RecharacterisedArrange
         .Create(characterisation,
                 arrange);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrange Silence<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrange arrange
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .SilentArrange
         .Create(arrange);

    /* ------------------------------------------------------------ */
    // IArrangeAct Extensions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrangeAct And<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrangeAct first,
       AAA_test<TActions, TAsserts>.IArrangeAct second
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .CompoundArrangeAct
         .Create(first,
                 second);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrangeAct Recharacterise<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrangeAct arrangeAct,
       string characterisation
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .RecharacterisedArrangeAct
         .Create(characterisation,
                 arrangeAct);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IArrangeAct Silence<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IArrangeAct arrangeAct
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .SilentArrangeAct
         .Create(arrangeAct);

    /* ------------------------------------------------------------ */
    //  IAssert Extensions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert And<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAssert first,
       AAA_test<TActions, TAsserts>.IAssert second
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .CompoundAssert
         .Create(first,
                 second);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert Recharacterise<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAssert assert,
       string characterisation
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .RecharacterisedAssert
         .Create(characterisation,
                 assert);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IAssert Silence<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IAssert assert
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .SilentAssert
         .Create(assert);

    /* ------------------------------------------------------------ */
    //  IInitialArrange Extensions
    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IInitialArrange And<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IInitialArrange first,
       AAA_test<TActions, TAsserts>.IArrange second
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .CompoundInitialArrange
         .Create(first,
                 second);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IInitialArrange Recharacterise<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IInitialArrange arrange,
       string characterisation
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .RecharacterisedInitialArrange
         .Create(characterisation,
                 arrange);

    /* ------------------------------------------------------------ */

    public static AAA_test<TActions, TAsserts>.IInitialArrange Silence<TActions, TAsserts>
    (
       this AAA_test<TActions, TAsserts>.IInitialArrange arrange
    )
       where TActions : ITestEnvironment<TAsserts>
       => AAA_test<TActions, TAsserts>
         .SilentInitialArrange
         .Create(arrange);

    /* ------------------------------------------------------------ */
}