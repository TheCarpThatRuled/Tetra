namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class AtomicArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TInitialArranges, TNextArranges> _arrange;
      private readonly string                                _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicArrange
      (
         Func<TInitialArranges, TNextArranges> arrange,
         string                                characterisation
      )
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IArrange<TInitialArranges, TNextArranges> Methods
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
         TInitialArranges environment
      )
         => _arrange(environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicArrange<TInitialArranges, TNextArranges> Create
      (
         string                                characterisation,
         Func<TInitialArranges, TNextArranges> arrange
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}