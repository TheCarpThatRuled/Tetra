namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class SilentAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
      where TArranges : IArranges
      where TAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentAct<TArranges, TAsserts> Create(IAct<TArranges, TAsserts> act)
         => new(act);

      /* ------------------------------------------------------------ */

      public static SilentAct<TArranges, TAsserts> Create(Func<TState, TArranges, TAsserts> act)
         => new(AtomicAct<TArranges, TAsserts>.Create(act,
                                                      ""));

      /* ------------------------------------------------------------ */
      // IAct<TState, TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser) { }

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

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentAct(IAct<TArranges, TAsserts> act)
         => _act = act;

      /* ------------------------------------------------------------ */
   }
}