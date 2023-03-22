﻿namespace Tetra.Testing;

public sealed class RoutingAssert<TInitialAsserts, TInnerAsserts> : IAssert<TInitialAsserts, TInitialAsserts>
   where TInitialAsserts : IAsserts
   where TInnerAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RoutingAssert<TInitialAsserts, TInnerAsserts> Create(IAssert<TInnerAsserts, TInitialAsserts> assert,
                                                                                    Func<TInitialAsserts, TInnerAsserts> map)
      => new(assert,
             map);

   /* ------------------------------------------------------------ */
   // IAssert<TInitialAsserts, TNextAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => _assert
        .AddBriefCharacterisation(characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => _assert
        .AddFullCharacterisation(characteriser);

   /* ------------------------------------------------------------ */

   public TInitialAsserts Assert(TInitialAsserts environment)
      => _assert
        .Assert(_map(environment));

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IAssert<TInnerAsserts, TInitialAsserts> _assert;
   private readonly Func<TInitialAsserts, TInnerAsserts>    _map;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private RoutingAssert(IAssert<TInnerAsserts, TInitialAsserts> assert,
                         Func<TInitialAsserts, TInnerAsserts> map)
   {
      _assert = assert;
      _map    = map;
   }

   /* ------------------------------------------------------------ */
}