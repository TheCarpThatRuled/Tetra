namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class RecharacterisedArrange : IArrange
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange _arrange;
      private readonly string   _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrange
      (
         IArrange arrange,
         string   characterisation
      )
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrange Create
      (
         string   characterisation,
         IArrange arrange
      )
         => new(arrange,
                characterisation);

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
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}