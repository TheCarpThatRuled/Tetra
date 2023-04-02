namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> : IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(Func<TState, TInitialArranges, TNextArranges> arrange,
                                                                                           Func<TState, TInitialArranges, TNextAsserts>  act,
                                                                                           string                                        characterisation)
         => new(act,
                arrange,
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

      public TNextAsserts Act(TState           state,
                              TInitialArranges environment)
         => _act(state,
                 environment);

      /* ------------------------------------------------------------ */
      // IAct<TInitialArranges, TNextAsserts, TState> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TState           state,
                                   TInitialArranges environment)
         => _arrange(state,
                     environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<TState, TInitialArranges, TNextAsserts>  _act;
      private readonly Func<TState, TInitialArranges, TNextArranges> _arrange;
      private readonly string                                        _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicArrangeAct(Func<TState, TInitialArranges, TNextAsserts>  act,
                               Func<TState, TInitialArranges, TNextArranges> arrange,
                               string                                        characterisation)
      {
         _act              = act;
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}