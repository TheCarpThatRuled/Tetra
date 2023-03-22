namespace Tetra.Testing;

public sealed class AtomicArrange<TArranges> : IArrange<TArranges>
   where TArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AtomicArrange<TArranges> Create(Func<AAA_test.Disposables, TArranges> arrange,
                                                 string                               characterisation)
      => new(arrange,
             characterisation);

   /* ------------------------------------------------------------ */
   // IArrange<TArranges> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => characteriser
        .AddClauseToBriefCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TArranges Arrange(AAA_test.Disposables disposables)
      => _arrange(disposables);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<AAA_test.Disposables, TArranges> _arrange;
   private readonly string                               _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AtomicArrange(Func<AAA_test.Disposables, TArranges> arrange,
                         string                               characterisation)
   {
      _arrange          = arrange;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}