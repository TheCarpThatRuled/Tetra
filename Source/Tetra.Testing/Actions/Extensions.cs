namespace Tetra.Testing;

public static class Extensions
{
   /* ------------------------------------------------------------ */
   //  IAct<TArranges, TAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static IAct<TArranges, TAsserts> Recharacterise<TArranges, TAsserts>(this IAct<TArranges, TAsserts> act,
                                                                               string                         characterisation)
      where TArranges : IArranges
      where TAsserts : IAsserts
      => RecharacterisedAct<TArranges, TAsserts>
        .Create(act,
                characterisation);

   /* ------------------------------------------------------------ */

   public static IAct<TArranges, TAsserts> Silence<TArranges, TAsserts>(this IAct<TArranges, TAsserts> act)
      where TArranges : IArranges
      where TAsserts : IAsserts
      => SilentAct<TArranges, TAsserts>
        .Create(act);

   /* ------------------------------------------------------------ */
   //  IArrange<TArranges> Extensions
   /* ------------------------------------------------------------ */

   public static IArrange<TNextArranges> And<TInitialArranges, TNextArranges>(this IArrange<TInitialArranges>           first,
                                                                              IArrange<TInitialArranges, TNextArranges> second)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => CompoundArrange<TInitialArranges, TNextArranges>
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static IArrange<TArranges> Recharacterise<TArranges>(this IArrange<TArranges> arrange,
                                                               string                   characterisation)
      where TArranges : IArranges
      => RecharacterisedArrange<TArranges>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static IArrange<TArranges> Silence<TArranges>(this IArrange<TArranges> arrange)
      where TArranges : IArranges
      => SilentArrange<TArranges>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //   IArrange<TInitialArranges, TNextArranges> Extensions
   /* ------------------------------------------------------------ */

   public static IArrange<TInitialArranges, TNextArranges> Recharacterise<TInitialArranges, TNextArranges>(this IArrange<TInitialArranges, TNextArranges> arrange,
                                                                                                           string                                         characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => RecharacterisedArrange<TInitialArranges, TNextArranges>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static IArrange<TInitialArranges, TNextArranges> Silence<TInitialArranges, TNextArranges>(this IArrange<TInitialArranges, TNextArranges> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => SilentArrange<TInitialArranges, TNextArranges>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //   IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Recharacterise<TInitialArranges, TNextArranges, TNextAsserts>(
      this IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange,
      string                                                          characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
      => RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
        .Create(arrange,
                characterisation);

   /* ------------------------------------------------------------ */

   public static IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Silence<TInitialArranges, TNextArranges, TNextAsserts>(
      this IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
      => SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
        .Create(arrange);

   /* ------------------------------------------------------------ */
   //  IAssert<TInitialAsserts, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static IAssert<TInitialAsserts, TNextAsserts> And<TInitialAsserts, TMiddleAsserts, TNextAsserts>(this IAssert<TInitialAsserts, TMiddleAsserts> first,
                                                                                                           IAssert<TMiddleAsserts, TNextAsserts>         second)
      where TInitialAsserts : IAsserts
      where TMiddleAsserts : IAsserts
      where TNextAsserts : IAsserts
      => CompoundAssert<TInitialAsserts, TMiddleAsserts, TNextAsserts>
        .Create(first,
                second);

   /* ------------------------------------------------------------ */

   public static IAssert<TInitialAsserts, TNextAsserts> Recharacterise<TInitialAsserts, TNextAsserts>(this IAssert<TInitialAsserts, TNextAsserts> assert,
                                                                                                      string                                      characterisation)
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
      => RecharacterisedAssert<TInitialAsserts, TNextAsserts>
        .Create(assert,
                characterisation);

   /* ------------------------------------------------------------ */

   public static IAssert<TInitialAsserts, TInitialAsserts> Route<TInitialAsserts, TInnerAsserts>(this IAssert<TInnerAsserts, TInitialAsserts> assert,
                                                                                                 Func<TInitialAsserts, TInnerAsserts>         map)
      where TInitialAsserts : IAsserts
      where TInnerAsserts : IAsserts
      => RoutingAssert<TInitialAsserts, TInnerAsserts>
        .Create(assert,
                map);

   /* ------------------------------------------------------------ */

   public static IAssert<TInitialAsserts, TNextAsserts> Silence<TInitialAsserts, TNextAsserts>(this IAssert<TInitialAsserts, TNextAsserts> assert)
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
      => SilentAssert<TInitialAsserts, TNextAsserts>
        .Create(assert);

   /* ------------------------------------------------------------ */
}