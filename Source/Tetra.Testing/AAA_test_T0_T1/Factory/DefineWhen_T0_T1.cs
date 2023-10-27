// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineWhen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialArrange _given;
      private readonly IAct            _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineWhen
      (
         IInitialArrange given,
         IAct            when
      )
      {
         _given = given;
         _when  = when;
      }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen THEN
      (
         IAssert then
      )
         => DefineThen
           .Create(_given,
                   _when,
                   then);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineWhen Create
      (
         IInitialArrange given,
         IAct            when
      )
         => new(given,
                when);

      /* ------------------------------------------------------------ */
   }
}