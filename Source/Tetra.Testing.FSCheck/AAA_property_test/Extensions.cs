namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class AAA_property_test_Extensions
{
   /* ------------------------------------------------------------ */
   //  AAA_property_test<TState>.IAct<TState, TArranges, TAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAct<TArranges, TAsserts> Recharacterise<TState, TArranges, TAsserts>(this AAA_property_test<TState>.IAct<TArranges, TAsserts> act,
                                                                                                                 string characterisation)
      where TArranges : IArranges
      where TAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .RecharacterisedAct<TArranges, TAsserts>
        .Create(act,
                characterisation);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAct<TArranges, TAsserts> Silence<TState, TArranges, TAsserts>(this AAA_property_test<TState>.IAct<TArranges, TAsserts> act)
      where TArranges : IArranges
      where TAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .SilentAct<TArranges, TAsserts>
        .Create(act);

   /* ------------------------------------------------------------ */
   //  AAA_property_test<TState>.IArrange<TState, TArranges> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TNextArranges> And<TState, TInitialArranges, TNextArranges>(this AAA_property_test<TState>.IArrange<TInitialArranges> first,
                                                                                                                AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges>
                                                                                                                   second)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_property_test<TState>
        .CompoundArrange<TInitialArranges, TNextArranges>
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TArranges> Recharacterise<TState, TArranges>(this AAA_property_test<TState>.IArrange<TArranges> arrange,
                                                                                                 string                                             characterisation)
      where TArranges : IArranges
      => AAA_property_test<TState>
        .RecharacterisedArrange<TArranges>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TArranges> Silence<TState, TArranges>(this AAA_property_test<TState>.IArrange<TArranges> arrange)
      where TArranges : IArranges
      => AAA_property_test<TState>
        .SilentArrange<TArranges>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //   AAA_property_test<TState>.IArrange<TState, TInitialArranges, TNextArranges> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges> And<TState, TInitialArranges, TMiddleArranges, TNextArranges>(
      this AAA_property_test<TState>.IArrange<TInitialArranges, TMiddleArranges> first,
      AAA_property_test<TState>.IArrange<TMiddleArranges, TNextArranges>         second)
      where TInitialArranges : IArranges
      where TMiddleArranges : IArranges
      where TNextArranges : IArranges
      => AAA_property_test<TState>
        .CompoundArrange<TInitialArranges, TMiddleArranges, TNextArranges>
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges> Recharacterise<TState, TInitialArranges, TNextArranges>(
      this AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges> arrange,
      string                                                                   characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_property_test<TState>
        .RecharacterisedArrange<TInitialArranges, TNextArranges>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges> Silence<TState, TInitialArranges, TNextArranges>(
      this AAA_property_test<TState>.IArrange<TInitialArranges, TNextArranges> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_property_test<TState>
        .SilentArrange<TInitialArranges, TNextArranges>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //   AAA_property_test<TState>.IArrangeAct<TState, TInitialArranges, TNextArranges, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Recharacterise<TState, TInitialArranges, TNextArranges, TNextAsserts>(
      this AAA_property_test<TState>.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange,
      string                                                                                    characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Silence<TState, TInitialArranges, TNextArranges, TNextAsserts>(
      this AAA_property_test<TState>.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //  AAA_property_test<TState>.IAssert<TState, TInitialAsserts, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAssert<TInitialAsserts, TNextAsserts> And<TState, TInitialAsserts, TMiddleAsserts, TNextAsserts>(
      this AAA_property_test<TState>.IAssert<TInitialAsserts, TMiddleAsserts> first,
      AAA_property_test<TState>.IAssert<TMiddleAsserts, TNextAsserts>         second)
      where TInitialAsserts : AAA_property_test<TState>.IAsserts
      where TMiddleAsserts : AAA_property_test<TState>.IAsserts
      where TNextAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .CompoundAssert<TInitialAsserts, TMiddleAsserts, TNextAsserts>
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAssert<TInitialAsserts, TNextAsserts> Recharacterise<TState, TInitialAsserts, TNextAsserts>(
      this AAA_property_test<TState>.IAssert<TInitialAsserts, TNextAsserts> assert,
      string                                                                characterisation)
      where TInitialAsserts : AAA_property_test<TState>.IAsserts
      where TNextAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .RecharacterisedAssert<TInitialAsserts, TNextAsserts>
        .Create(assert,
                characterisation);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAssert<TInitialAsserts, TInitialAsserts> Route<TInitialAsserts, TInnerAsserts, TState>(
      this AAA_property_test<TState>.IAssert<TInnerAsserts, TInitialAsserts> assert,
      Func<TInitialAsserts, TInnerAsserts>                                   map)
      where TInitialAsserts : AAA_property_test<TState>.IAsserts
      where TInnerAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .RoutingAssert<TInitialAsserts, TInnerAsserts>
        .Create(assert,
                map);

   /* ------------------------------------------------------------ */

   public static AAA_property_test<TState>.IAssert<TInitialAsserts, TNextAsserts> Silence<TState, TInitialAsserts, TNextAsserts>(
      this AAA_property_test<TState>.IAssert<TInitialAsserts, TNextAsserts> assert)
      where TInitialAsserts : AAA_property_test<TState>.IAsserts
      where TNextAsserts : AAA_property_test<TState>.IAsserts
      => AAA_property_test<TState>
        .SilentAssert<TInitialAsserts, TNextAsserts>
        .Create(assert);

   /* ------------------------------------------------------------ */
}