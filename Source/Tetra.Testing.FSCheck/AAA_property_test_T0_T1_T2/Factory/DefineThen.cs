// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class DefineThen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _given;
      private readonly Type           _library;
      private readonly IAssert        _then;
      private readonly IAction        _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineThen
      (
         IInitialAction given,
         Type           library,
         IAssert        then,
         IAction        when
      )
      {
         _given        = given;
         _library = library;
         _then         = then;
         _when         = when;
      }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen And
      (
         IAssert assert
      )
         => Create(_library,
                   _given,
                   _when,
                   _then.And(assert));

      /* ------------------------------------------------------------ */

      public AAA_property_test<TParameters> Crystallise()
         => AAA_property_test<TParameters>
           .Create($"GIVEN {_given.Characterisation()} WHEN {_when.Characterisation()} THEN {_then.Characterisation()}",
                   _library,
                   (
                      parameters,
                      disposables
                   ) =>
                   {
                      var given = _given.Run(parameters,
                                             disposables);
                      return () =>
                      {
                         var when = _when.Run(given.Finalise());

                         return () => _then
                                     .Run(when.Asserts())
                                     .ToProperty();
                      };
                   });

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineThen Create
      (
         Type           library,
         IInitialAction given,
         IAction        when,
         IAssert        then
      )
         => new(given,
                library,
                then,
                when);

      /* ------------------------------------------------------------ */
   }
}