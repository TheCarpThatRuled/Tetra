// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test
{
   public sealed class DefineWhen<TGiven, TWhen>
      where TGiven : IArranges
      where TWhen : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen<TGiven, TWhen, TThen> THEN<TThen>(IAssert<TWhen, TThen> then)
         where TThen : IAsserts
         => DefineThen<TGiven, TWhen, TThen>
           .Create(_given,
                   _when,
                   then);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineWhen<TGiven, TWhen> Create(IArrange<TGiven>    given,
                                                       IAct<TGiven, TWhen> when)
         => new(given,
                when);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TGiven>    _given;
      private readonly IAct<TGiven, TWhen> _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineWhen(IArrange<TGiven>    given,
                         IAct<TGiven, TWhen> when)
      {
         _given = given;
         _when  = when;
      }

      /* ------------------------------------------------------------ */
   }
}