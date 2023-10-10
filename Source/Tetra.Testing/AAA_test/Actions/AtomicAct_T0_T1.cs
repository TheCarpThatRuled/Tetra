namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class AtomicAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TArranges, TAsserts> _act;
      private readonly string                    _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAct
      (
         Func<TArranges, TAsserts> act,
         string                    characterisation
      )
      {
         _act              = act;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
      // IArrange<TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         WhenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         WhenCharacteriser characteriser
      )
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TAsserts Act
      (
         TArranges environment
      )
         => _act(environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAct<TArranges, TAsserts> Create
      (
         string                    characterisation,
         Func<TArranges, TAsserts> act
      )
         => new(act,
                characterisation);

      /* ------------------------------------------------------------ */
   }
}