namespace Tetra.Testing;

public sealed class AtomicAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
   where TArranges : IArranges
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AtomicAct<TArranges, TAsserts> Create(Func<TArranges, TAsserts> act,
                                                       string                    characterisation)
      => new(act,
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

   public TAsserts Act(TArranges environment)
      => _act(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<TArranges, TAsserts> _act;
   private readonly string                    _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AtomicAct(Func<TArranges, TAsserts> act,
                     string                    characterisation)
   {
      _act              = act;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}