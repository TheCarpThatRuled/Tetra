namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class CompoundAction : IAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAction _first;
      private readonly IAction _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundAction
      (
         IAction first,
         IAction second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundAction Create
      (
         IAction first,
         IAction second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         TActions environment
      )
      {
         var intermediate = _first.Run(environment);
         Log.And();
         return _second.Run(intermediate);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => And(_first.Characterisation(),
                _second.Characterisation());

      /* ------------------------------------------------------------ */
   }
}