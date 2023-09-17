namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> : IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static RecharacterisedArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(string                                                     characterisation,
                                                                                                    IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrange)
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
      // IArrange<TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser)
         => _arrangeAct
           .AddFullCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TInitialArranges environment)
         => _arrangeAct
           .Arrange(environment);

      /* ------------------------------------------------------------ */
      // IArrange<TInitialArranges, TNextArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(WhenCharacteriser characteriser)
         => _arrangeAct
           .AddBriefCharacterisation(characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(WhenCharacteriser characteriser)
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TNextAsserts Act(TInitialArranges environment)
         => _arrangeAct
           .Act(environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> _arrangeAct;
      private readonly string                                                     _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private RecharacterisedArrangeAct(IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> arrangeAct,
                                        string                                                     characterisation)
      {
         _arrangeAct       = arrangeAct;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}