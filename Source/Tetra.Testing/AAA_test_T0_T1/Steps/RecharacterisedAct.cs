namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class RecharacterisedAct : IAct
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAct   _act;
      private readonly string _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAct
      (
         IAct   act,
         string characterisation
      )
      {
         _act              = act;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAct Create
      (
         string characterisation,
         IAct   act
      )
         => new(act,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAct Methods
      /* ------------------------------------------------------------ */

      public TActions Act
      (
         TActions environment
      )
         => _act.Act(environment);

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => _characterisation;

      /* ------------------------------------------------------------ */
   }
}