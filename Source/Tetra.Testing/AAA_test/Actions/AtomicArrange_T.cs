namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class AtomicArrange<TArranges> : IArrange<TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static AtomicArrange<TArranges> Create(string                       characterisation,
                                                    Func<Disposables, TArranges> arrange)
         => new(arrange,
                characterisation);

      /* ------------------------------------------------------------ */
      // IArrange<TArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToBriefCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser)
         => characteriser
           .AddClauseToFullCharacterisation(_characterisation);

      /* ------------------------------------------------------------ */

      public TArranges Arrange(Disposables disposables)
         => _arrange(disposables);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Disposables, TArranges> _arrange;
      private readonly string                       _characterisation;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private AtomicArrange(Func<Disposables, TArranges> arrange,
                            string                       characterisation)
      {
         _arrange          = arrange;
         _characterisation = characterisation;
      }

      /* ------------------------------------------------------------ */
   }
}