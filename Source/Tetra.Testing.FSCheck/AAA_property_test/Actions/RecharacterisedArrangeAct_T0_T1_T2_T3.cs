namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> :
      IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> _arrangeAct;
      private readonly string                                                     _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrangeAct
      (
         IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrangeAct,
         string                                                     characterisation
      )
      {
         _arrangeAct       = arrangeAct;
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
         => _arrangeAct
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         TState           state,
         TInitialArranges environment
      )
         => _arrangeAct
           .Arrange(state,
                    environment);

      /* ------------------------------------------------------------ */
      // IArrange<TState, TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         WhenCharacteriser characteriser
      )
         => _arrangeAct
           .AddBriefCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         WhenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TNextAsserts Act
      (
         TState           state,
         TInitialArranges environment
      )
         => _arrangeAct
           .Act(state,
                environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create
      (
         IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange,
         string                                                     characterisation
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}