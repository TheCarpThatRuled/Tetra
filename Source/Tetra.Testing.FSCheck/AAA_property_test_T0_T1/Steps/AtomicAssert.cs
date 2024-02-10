using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class AtomicAssert : IAssert
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Parameters, TAsserts, TAsserts> _assert;
      private readonly string                               _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAssert
      (
         Func<Parameters, TAsserts, TAsserts> assert,
         string                               characterisation
      )
      {
         _assert           = assert;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAssert Create
      (
         string                               characterisation,
         Func<Parameters, TAsserts, TAsserts> assert
      )
         => new(assert,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAssert Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         Parameters parameters,
         TAsserts   environment
      )
      {
         Log.TestStep(parameters.SubstituteParametersForValues(_characterisation));
         return _assert(parameters,
                        environment);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}