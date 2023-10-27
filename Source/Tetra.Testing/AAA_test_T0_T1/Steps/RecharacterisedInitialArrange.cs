namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class RecharacterisedInitialArrange : IInitialArrange
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialArrange _arrange;
      private readonly string          _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedInitialArrange
      (
         IInitialArrange arrange,
         string          characterisation
      )
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedInitialArrange Create
      (
         string          characterisation,
         IInitialArrange arrange
      )
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
      // IInitialArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         AAA_test1.Disposables disposables
      )
         => _arrange.Arrange(disposables);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}