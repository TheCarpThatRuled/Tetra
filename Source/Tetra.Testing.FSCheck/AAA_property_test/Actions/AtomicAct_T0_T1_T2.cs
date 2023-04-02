namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class AtomicAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicAct<TArranges, TAsserts> Create(Func<TState, TArranges, TAsserts> act,
                                                          string                            characterisation)
         => new(act,
                characterisation);

      /* ------------------------------------------------------------ */
      // IArrange<TState, TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser)
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TAsserts Act(TState    state,
                          TArranges environment)
         => _act(state,
                 environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TState, TArranges, TAsserts> _act;
      private readonly string                            _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicAct(Func<TState, TArranges, TAsserts> act,
                        string                            characterisation)
      {
         _act              = act;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}