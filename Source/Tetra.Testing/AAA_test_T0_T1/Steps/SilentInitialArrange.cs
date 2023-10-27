namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class SilentInitialArrange : IInitialArrange
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialArrange _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentInitialArrange
      (
         IInitialArrange arrange
      )
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentInitialArrange Create
      (
         IInitialArrange arrange
      )
         => new(arrange);

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
         => string.Empty;

      /* ------------------------------------------------------------ */
   }
}