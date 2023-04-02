namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> : IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrangeAct)
         => new(arrangeAct);

      /* ------------------------------------------------------------ */

      public static SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(Func<TState, TInitialArranges, TNextArranges> arrange,
                                                                                           Func<TState, TInitialArranges, TNextAsserts>    act)
         => new(AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>.Create(arrange,
                                                                                       act,
                                                                                       ""));

      /* ------------------------------------------------------------ */
      // IArrange<TState, TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TState           state,
                                   TInitialArranges environment)
         => _arrangeAct
           .Arrange(state,
                    environment);

      /* ------------------------------------------------------------ */
      // IAct<TInitialArranges, TNextAsserts, TState> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextAsserts Act(TState           state,
                              TInitialArranges environment)
         => _arrangeAct
           .Act(state,
                environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> _arrangeAct;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrangeAct(IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrangeAct)
         => _arrangeAct = arrangeAct;

      /* ------------------------------------------------------------ */
   }
}