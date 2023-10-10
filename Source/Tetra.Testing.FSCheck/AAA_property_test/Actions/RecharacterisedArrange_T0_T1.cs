namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class RecharacterisedArrange<TArranges> : IArrange<TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TArranges> _arrange;
      private readonly string              _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrange
      (
         IArrange<TArranges> arrange,
         string              characterisation
      )
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IArrange<TState, TArranges> Methods
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

      public TArranges Arrange
      (
         Disposables disposables,
         TState      state
      )
         => _arrange
           .Arrange(disposables,
                    state);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrange<TArranges> Create
      (
         IArrange<TArranges> arrange,
         string              characterisation
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}