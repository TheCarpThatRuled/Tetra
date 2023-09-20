﻿namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class RecharacterisedAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAct<TArranges, TAsserts> Create(string                    characterisation,
                                                                   IAct<TArranges, TAsserts> act)
         => new(act,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAct<TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser)
         => _act
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TAsserts Act(TArranges environment)
         => _act
           .Act(environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAct<TArranges, TAsserts> _act;
      private readonly string                    _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAct(IAct<TArranges, TAsserts> act,
                                 string                    characterisation)
      {
         _act              = act;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}