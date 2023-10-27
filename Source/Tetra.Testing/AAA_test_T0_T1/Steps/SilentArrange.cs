namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class SilentArrange : IArrange
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrange
      (
         IArrange arrange
      )
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrange Create
      (
         IArrange arrange
      )
         => new(arrange);

      /* ------------------------------------------------------------ */
      // IArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         TActions environment
      )
         => _arrange.Arrange(environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => string.Empty;

      /* ------------------------------------------------------------ */
   }
}