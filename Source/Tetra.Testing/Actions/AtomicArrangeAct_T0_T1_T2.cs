namespace Tetra.Testing;

public sealed class AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> : IArrangeAct<TInitialArranges, TNextArranges, TNextAsserts>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
   where TNextAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AtomicArrangeAct<TInitialArranges, TNextArranges, TNextAsserts> Create(Func<TInitialArranges, TNextArranges> arrange,
                                                                                        Func<TInitialArranges, TNextAsserts>  act,
                                                                                        string                                characterisation)
      => new(act,
             arrange,
             characterisation);

   /* ------------------------------------------------------------ */
   // IArrange<TArranges, TAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.WhenCharacteriser characteriser)
      => characteriser
        .AddClauseToBriefCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.WhenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TNextAsserts Act(TInitialArranges environment)
      => _act(environment);

   /* ------------------------------------------------------------ */
   // IAct<TInitialArranges, TNextAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => characteriser
        .AddClauseToBriefCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TNextArranges Arrange(TInitialArranges environment)
      => _arrange(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<TInitialArranges, TNextAsserts>  _act;
   private readonly Func<TInitialArranges, TNextArranges> _arrange;
   private readonly string                                _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AtomicArrangeAct(Func<TInitialArranges, TNextAsserts>  act,
                            Func<TInitialArranges, TNextArranges> arrange,
                            string                                characterisation)
   {
      _act              = act;
      _arrange          = arrange;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}