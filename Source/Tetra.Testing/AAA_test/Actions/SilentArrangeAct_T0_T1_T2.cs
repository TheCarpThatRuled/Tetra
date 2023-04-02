namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
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

      public static SilentArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(Func<TInitialArranges, TNextArranges> arrange,
                                                                                           Func<TInitialArranges, TNextAsserts>  act)
         => new(AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>.Create(arrange,
                                                                                       act,
                                                                                       ""));

      /* ------------------------------------------------------------ */
      // IArrange<TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TInitialArranges environment)
         => _arrangeAct
           .Arrange(environment);

      /* ------------------------------------------------------------ */
      // IAct<TInitialArranges, TNextAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.WhenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.WhenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextAsserts Act(TInitialArranges environment)
         => _arrangeAct
           .Act(environment);

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