namespace Tetra.Testing;

public sealed class AtomicArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AtomicArrange<TInitialArranges, TNextArranges> Create(Func<TInitialArranges, TNextArranges> arrange,
                                                                       string                                characterisation)
      => new(arrange,
             characterisation);

   /* ------------------------------------------------------------ */
   // IArrange<TInitialArranges, TNextArranges> Methods
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

   private readonly Func<TInitialArranges, TNextArranges> _arrange;
   private readonly string                                _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AtomicArrange(Func<TInitialArranges, TNextArranges> arrange,
                         string                                characterisation)
   {
      _arrange          = arrange;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}