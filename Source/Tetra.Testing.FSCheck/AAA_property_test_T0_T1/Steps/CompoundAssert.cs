namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class CompoundAssert : IAssert
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAssert _first;
      private readonly IAssert _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundAssert
      (
         IAssert first,
         IAssert second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundAssert Create
      (
         IAssert first,
         IAssert second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IAssert Methods
      /* ------------------------------------------------------------ */

      public TAsserts Run
      (
         AAA_property_test.Parameters parameters,
         TAsserts                     environment
      )
      {
         var intermediate = _first.Run(parameters,
                                       environment);
         Log.And();
         return _second.Run(parameters,
                            intermediate);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => And(_first.Characterisation(),
                _second.Characterisation());

      /* ------------------------------------------------------------ */
   }
}