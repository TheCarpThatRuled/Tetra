﻿namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class RecharacterisedArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TInitialArranges, TNextArranges> _arrange;
      private readonly string                                    _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrange
      (
         IArrange<TInitialArranges, TNextArranges> arrange,
         string                                    characterisation
      )
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IArrange<TState, TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         GivenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         GivenCharacteriser characteriser
      )
         => _arrange
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         TState           state,
         TInitialArranges environment
      )
         => _arrange
           .Arrange(state,
                    environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrange<TInitialArranges, TNextArranges> Create
      (
         IArrange<TInitialArranges, TNextArranges> arrange,
         string                                    characterisation
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}