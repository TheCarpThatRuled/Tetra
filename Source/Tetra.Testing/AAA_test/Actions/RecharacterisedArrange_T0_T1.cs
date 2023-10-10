namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
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
         => _arrange
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         TInitialArranges environment
      )
         => _arrange
           .Arrange(environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrange<TInitialArranges, TNextArranges> Create
      (
         string                                    characterisation,
         IArrange<TInitialArranges, TNextArranges> arrange
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}