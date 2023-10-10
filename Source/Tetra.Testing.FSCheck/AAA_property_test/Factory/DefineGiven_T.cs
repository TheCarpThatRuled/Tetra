// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_property_test<TState>
{
   public sealed class DefineGiven<TGiven>
      where TGiven : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TGiven> _given;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineGiven
      (
         IArrange<TGiven> given
      )
         => _given = given;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineGiven<TNewGiven> And<TNewGiven>
      (
         IArrange<TGiven, TNewGiven> given
      )
         where TNewGiven : IArranges
         => DefineGiven<TNewGiven>
           .Create(_given.And(given));

      /* ------------------------------------------------------------ */

      public DefineWhen<TGiven, TWhen> WHEN<TWhen>
      (
         IAct<TGiven, TWhen> when
      )
         where TWhen : IAsserts
         => DefineWhen<TGiven, TWhen>
           .Create(_given,
                   when);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineGiven<TGiven> Create
      (
         IArrange<TGiven> given
      )
         => new(given);

      /* ------------------------------------------------------------ */
   }
}