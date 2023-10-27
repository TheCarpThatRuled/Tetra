// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test<TActions, TAsserts>
{
   public sealed class DefineGiven
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialArrange _given;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineGiven
      (
         IInitialArrange given
      )
         => _given = given;

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineGiven Create
      (
         IInitialArrange given
      )
         => new(given);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineGiven And
      (
         IArrange given
      )
         => Create(_given.And(given));

      /* ------------------------------------------------------------ */

      public DefineWhen WHEN
      (
         IAct when
      )
         => DefineWhen
           .Create(_given,
                   when);

      /* ------------------------------------------------------------ */
   }
}