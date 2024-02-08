// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineThen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _given;
      private readonly IAssert        _then;
      private readonly IAction        _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineThen
      (
         IInitialAction given,
         IAssert        then,
         IAction        when
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

      public AAA_test Crystallise()
         => AAA_test
           .Create($"GIVEN {_given.Characterisation()} WHEN {_when.Characterisation()} THEN {_then.Characterisation()}",
                   disposables =>
                   {
                      var given = _given.Run(disposables);
                      return () =>
                      {
                         var when = _when.Run(given.Finalise());

                         return () => _then.Run(when.Asserts());
                      };
                   });

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineThen Create
      (
         IInitialAction given,
         IAction        when,
         IAssert        then
      )
         => new(given,
                then,
                when);

      /* ------------------------------------------------------------ */
   }
}