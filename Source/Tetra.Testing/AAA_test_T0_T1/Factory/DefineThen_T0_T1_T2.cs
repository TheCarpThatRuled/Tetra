// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineThen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialArrange _given;
      private readonly IAssert         _then;
      private readonly IAct            _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineThen
      (
         IInitialArrange given,
         IAssert         then,
         IAct            when
      )
      {
         _given = given;
         _then  = then;
         _when  = when;
      }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen And
      (
         IAssert assert
      )
         => Create(_given,
                   _when,
                   _then.And(assert));

      /* ------------------------------------------------------------ */

      public AAA_test1 Crystallise()
         => AAA_test1
           .Create($"GIVEN {_given.Characterisation()} WHEN {_when.Characterisation()} THEN {_then.Characterisation()}",
                   disposables =>
                   {
                      var given = _given.Arrange(disposables);
                      given.FinishArrange();
                      return () =>
                      {
                         var when = _when.Act(given);

                         return () => _then.Assert(when.Asserts());
                      };
                   });

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineThen Create
      (
         IInitialArrange given,
         IAct            when,
         IAssert         then
      )
         => new(given,
                then,
                when);

      /* ------------------------------------------------------------ */
   }
}