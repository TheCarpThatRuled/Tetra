// ReSharper disable InconsistentNaming

using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class DefineWhen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction        _given;
      private readonly Arbitrary<Parameters> _library;
      private readonly IAction               _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineWhen
      (
         IInitialAction        given,
         Arbitrary<Parameters> library,
         IAction               when
      )
      {
         _library = library;
         _given   = given;
         _when    = when;
      }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen THEN
      (
         IAssert then
      )
         => DefineThen
           .Create(_library,
                   _given,
                   _when,
                   then);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineWhen Create
      (
         Arbitrary<Parameters> library,
         IInitialAction        given,
         IAction               when
      )
         => new(given,
                library,
                when);

      /* ------------------------------------------------------------ */
   }
}