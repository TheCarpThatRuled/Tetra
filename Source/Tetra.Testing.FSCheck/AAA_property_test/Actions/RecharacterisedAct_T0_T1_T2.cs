namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class RecharacterisedAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedAct<TArranges, TAsserts> Create(IAct<TArranges, TAsserts> act,
                                                                   string                    characterisation)
         => new(act,
                characterisation);

      /* ------------------------------------------------------------ */
      // IAct<TState, TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser)
         => _act
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TAsserts Act(TState    state,
                          TArranges environment)
         => _act
           .Act(state,
                environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IAct<TArranges, TAsserts> _act;
      private readonly string                    _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedAct(IAct<TArranges, TAsserts> act,
                                 string                    characterisation)
      {
         _act              = act;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}