// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineGiven
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _given;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineGiven
      (
         IInitialAction given
      )
         => _given = given;

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineGiven Create
      (
         IInitialAction given
      )
         => new(given);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineGiven And
      (
         IAction given
      )
         => Create(_given.And(given));

      /* ------------------------------------------------------------ */

      public DefineWhen WHEN
      (
         IAction when
      )
         => DefineWhen
           .Create(_given,
                   when);

      /* ------------------------------------------------------------ */
   }
}