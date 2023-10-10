namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class AtomicArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TState, TInitialArranges, TNextArranges> _arrange;
      private readonly string                                        _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicArrange
      (
         Func<TState, TInitialArranges, TNextArranges> arrange,
         string                                        characterisation
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
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         TState           state,
         TInitialArranges environment
      )
         => _arrange(state,
                     environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicArrange<TInitialArranges, TNextArranges> Create
      (
         Func<TState, TInitialArranges, TNextArranges> arrange,
         string                                        characterisation
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}