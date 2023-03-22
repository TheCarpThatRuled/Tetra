﻿namespace Tetra.Testing;

public sealed class RecharacterisedAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
   where TInitialAsserts : IAsserts
   where TNextAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RecharacterisedAssert<TInitialAsserts, TNextAsserts> Create(IAssert<TInitialAsserts, TNextAsserts> assert,
                                                                             string                                 characterisation)
      => new(assert,
             characterisation);

   /* ------------------------------------------------------------ */
   // IAssert<TAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => _assert
        .AddBriefCharacterisation(characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TNextAsserts Assert(TInitialAsserts environment)
      => _assert
        .Assert(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IAssert<TInitialAsserts, TNextAsserts> _assert;
   private readonly string                                 _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private RecharacterisedAssert(IAssert<TInitialAsserts, TNextAsserts> assert,
                                 string                                 characterisation)
   {
      _assert           = assert;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}