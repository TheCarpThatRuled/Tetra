namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class CompoundArrangeAct : IArrangeAct
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrangeAct _first;
      private readonly IArrangeAct _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundArrangeAct
      (
         IArrangeAct first,
         IArrangeAct second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundArrangeAct Create
      (
         IArrangeAct first,
         IArrangeAct second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         TActions environment
      )
         => _second
           .Arrange(_first.Arrange(environment));

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