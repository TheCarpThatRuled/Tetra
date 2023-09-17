namespace Tetra.Testing;

public static class Extensions
{
   /* ------------------------------------------------------------ */
   //  IAct<TArranges, TAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<TArranges, TAsserts> Recharacterise<TArranges, TAsserts>(this AAA_test.IAct<TArranges, TAsserts> act,
                                                                                        string                                  characterisation)
      where TArranges : IArranges
      where TAsserts : IAsserts
      => AAA_test.RecharacterisedAct<TArranges, TAsserts>
                 .Create(characterisation,
                         act);

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<TArranges, TAsserts> Silence<TArranges, TAsserts>(this AAA_test.IAct<TArranges, TAsserts> act)
      where TArranges : IArranges
      where TAsserts : IAsserts
      => AAA_test.SilentAct<TArranges, TAsserts>
                 .Create(act);

   /* ------------------------------------------------------------ */
   //  IArrange<TArranges> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TNextArranges> And<TInitialArranges, TNextArranges>(this AAA_test.IArrange<TInitialArranges>           first,
                                                                                       AAA_test.IArrange<TInitialArranges, TNextArranges> second)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_test.CompoundArrange<TInitialArranges, TNextArranges>
                 .Create(first,
                         second);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TArranges> Recharacterise<TArranges>(this AAA_test.IArrange<TArranges> arrange,
                                                                        string                            characterisation)
      where TArranges : IArranges
      => AAA_test.RecharacterisedArrange<TArranges>
                 .Create(characterisation,
                         arrange);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TArranges> Silence<TArranges>(this AAA_test.IArrange<TArranges> arrange)
      where TArranges : IArranges
      => AAA_test.SilentArrange<TArranges>
                 .Create(arrange);

   /* ------------------------------------------------------------ */
   //   IArrange<TInitialArranges, TNextArranges> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TInitialArranges, TNextArranges> And<TInitialArranges, TMiddleArranges, TNextArranges>(
      this AAA_test.IArrange<TInitialArranges, TMiddleArranges> first,
      AAA_test.IArrange<TMiddleArranges, TNextArranges>         second)
      where TInitialArranges : IArranges
      where TMiddleArranges : IArranges
      where TNextArranges : IArranges
      => AAA_test.CompoundArrange<TInitialArranges, TMiddleArranges, TNextArranges>
                 .Create(first,
                         second);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TInitialArranges, TNextArranges> Recharacterise<TInitialArranges, TNextArranges>(this AAA_test.IArrange<TInitialArranges, TNextArranges> arrange,
                                                                                                                    string characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_test.RecharacterisedArrange<TInitialArranges, TNextArranges>
                 .Create(characterisation,
                         arrange);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TInitialArranges, TNextArranges> Silence<TInitialArranges, TNextArranges>(this AAA_test.IArrange<TInitialArranges, TNextArranges> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      => AAA_test.SilentArrange<TInitialArranges, TNextArranges>
                 .Create(arrange);

   /* ------------------------------------------------------------ */
   //   IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Recharacterise<TInitialArranges, TNextArranges, TNextAsserts>(
      this AAA_test.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange,
      string                                                                   characterisation)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
      => AAA_test.RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
                 .Create(characterisation,
                         arrange);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Silence<TInitialArranges, TNextArranges, TNextAsserts>(
      this AAA_test.IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange)
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
      => AAA_test.SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
                 .Create(arrange);

   /* ------------------------------------------------------------ */
   //  IAssert<TInitialAsserts, TNextAsserts> Extensions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TInitialAsserts, TNextAsserts> And<TInitialAsserts, TMiddleAsserts, TNextAsserts>(this AAA_test.IAssert<TInitialAsserts, TMiddleAsserts> first,
                                                                                                                    AAA_test.IAssert<TMiddleAsserts, TNextAsserts>         second)
      where TInitialAsserts : IAsserts
      where TMiddleAsserts : IAsserts
      where TNextAsserts : IAsserts
      => AAA_test.CompoundAssert<TInitialAsserts, TMiddleAsserts, TNextAsserts>
                 .Create(first,
                         second);

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TInitialAsserts, TNextAsserts> Recharacterise<TInitialAsserts, TNextAsserts>(this AAA_test.IAssert<TInitialAsserts, TNextAsserts> assert,
                                                                                                               string characterisation)
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
      => AAA_test.RecharacterisedAssert<TInitialAsserts, TNextAsserts>
                 .Create(characterisation,
                         assert);

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TInitialAsserts, TInitialAsserts> Route<TInitialAsserts, TInnerAsserts>(this AAA_test.IAssert<TInnerAsserts, TInitialAsserts> assert,
                                                                                                          Func<TInitialAsserts, TInnerAsserts>                  map)
      where TInitialAsserts : IAsserts
      where TInnerAsserts : IAsserts
      => AAA_test.RoutingAssert<TInitialAsserts, TInnerAsserts>
                 .Create(assert,
                         map);

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TInitialAsserts, TNextAsserts> Silence<TInitialAsserts, TNextAsserts>(this AAA_test.IAssert<TInitialAsserts, TNextAsserts> assert)
      where TInitialAsserts : IAsserts
      where TNextAsserts : IAsserts
      => AAA_test.SilentAssert<TInitialAsserts, TNextAsserts>
                 .Create(assert);

   /* ------------------------------------------------------------ */
}