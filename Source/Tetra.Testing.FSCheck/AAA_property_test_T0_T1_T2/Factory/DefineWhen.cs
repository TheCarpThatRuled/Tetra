// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class DefineWhen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _given;
      private readonly Type           _library;
      private readonly IAction        _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineWhen
      (
         IInitialAction given,
         Type           library,
         IAction        when
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
         Type           library,
         IInitialAction given,
         IAction        when
      )
         => new(given,
                library,
                when);

      /* ------------------------------------------------------------ */
   }
}