// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineWhen
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _given;
      private readonly IAction        _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineWhen
      (
         IInitialAction given,
         IAction        when
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
         IInitialAction given,
         IAction        when
      )
         => new(given,
                when);

      /* ------------------------------------------------------------ */
   }
}