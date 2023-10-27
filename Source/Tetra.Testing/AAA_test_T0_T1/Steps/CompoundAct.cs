namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class CompoundAct : IAct
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAct _first;
      private readonly IAct _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundAct
      (
         IAct first,
         IAct second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundAct Create
      (
         IAct first,
         IAct second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IAct Methods
      /* ------------------------------------------------------------ */

      public TActions Act
      (
         TActions environment
      )
         => _second
           .Act(_first.Act(environment));

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => And(_first.Characterisation(),
                _second.Characterisation());

      /* ------------------------------------------------------------ */
   }
}