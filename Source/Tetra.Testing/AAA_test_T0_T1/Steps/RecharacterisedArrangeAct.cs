namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class RecharacterisedArrangeAct : IArrangeAct
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrangeAct _arrangeAct;
      private readonly string      _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrangeAct
      (
         IArrangeAct arrangeAct,
         string      characterisation
      )
      {
         _arrangeAct       = arrangeAct;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrangeAct Create
      (
         string      characterisation,
         IArrangeAct arrangeAct
      )
         => new(arrangeAct,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAct Methods
      /* ------------------------------------------------------------ */

      public TActions Act
      (
         TActions environment
      )
         => _arrangeAct.Act(environment);

      /* ------------------------------------------------------------ */
      // IArrange Methods
      /* ------------------------------------------------------------ */

      public TActions Arrange
      (
         TActions environment
      )
         => _arrangeAct.Arrange(environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}