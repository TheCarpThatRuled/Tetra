namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class RecharacterisedAssert : IAssert
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert _assert;
      private readonly string  _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAssert
      (
         IAssert assert,
         string  characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAssert Create
      (
         string  characterisation,
         IAssert assert
      )
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAssert Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         TAsserts environment
      )
         => _assert.Run(environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}