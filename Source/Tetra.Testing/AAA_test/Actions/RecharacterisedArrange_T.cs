namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class RecharacterisedArrange<TArranges> : IArrange<TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrange<TArranges> Create(string              characterisation,
                                                             IArrange<TArranges> arrange)
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
      // IArrange<TArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser)
         => _arrange
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TArranges Arrange(Disposables disposables)
         => _arrange
           .Arrange(disposables);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TArranges> _arrange;
      private readonly string              _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrange(IArrange<TArranges> arrange,
                                     string              characterisation)
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}