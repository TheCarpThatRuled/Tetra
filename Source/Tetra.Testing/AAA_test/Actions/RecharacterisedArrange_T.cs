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

      public static RecharacterisedArrange<TArranges> Create(IArrange<TArranges> arrange,
                                                             string              characterisation)
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
      // IArrange<TArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser)
         => _arrange
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TArranges Arrange(AAA_test.Disposables disposables)
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