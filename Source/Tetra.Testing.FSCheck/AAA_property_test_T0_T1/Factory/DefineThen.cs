// ReSharper disable InconsistentNaming

using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class DefineThen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction        _given;
      private readonly Arbitrary<Parameters> _library;
      private readonly IAssert               _then;
      private readonly IAction               _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineThen
      (
         IInitialAction        given,
         Arbitrary<Parameters> library,
         IAssert               then,
         IAction               when
      )
      {
         _given   = given;
         _library = library;
         _then    = then;
         _when    = when;
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

      public AAA_property_test Crystallise()
         => AAA_property_test
           .Create($"GIVEN {_given.Characterisation()} WHEN {_when.Characterisation()} THEN {_then.Characterisation()}",
                   _library,
                   (
                      parameters,
                      disposables
                   ) =>
                   {
                      Log.Given();
                      var given = _given.Run(parameters,
                                             disposables);
                      return () =>
                      {
                         Log.When();
                         var when = _when.Run(parameters,
                                              given.Finalise());

                         return () =>
                         {
                            Log.Then();
                            var property = _then
                                          .Run(parameters,
                                               when.Asserts())
                                          .ToProperty();
                            Log.ToStandardOutput(string.Empty);
                            return property;
                         };
                      };
                   });

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineThen Create
      (
         Arbitrary<Parameters> library,
         IInitialAction        given,
         IAction               when,
         IAssert               then
      )
         => new(given,
                library,
                then,
                when);

      /* ------------------------------------------------------------ */
   }
}