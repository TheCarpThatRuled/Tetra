namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class SilentArrange<TArrange> : IArrange<TArrange>
      where TArrange : IArranges
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrange<TArrange> Create(IArrange<TArrange> arrange)
         => new(arrange);

      /* ------------------------------------------------------------ */

      public static SilentArrange<TArrange> Create(Func<Disposables, TArrange> arrange)
         => new(AtomicArrange<TArrange>.Create(string.Empty,
                                               arrange));

      /* ------------------------------------------------------------ */
      // IArrangeAction<T0, T1> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TArrange Arrange(Disposables disposables)
         => _arrange
           .Arrange(disposables);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TArrange> _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrange(IArrange<TArrange> arrange)
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
   }
}