namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class SilentArrange<TArranges> : IArrange<TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TArranges> _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrange
      (
         IArrange<TArranges> arrange
      )
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // IArrangeAction<T0, T1> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         GivenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         GivenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public TArranges Arrange
      (
         Disposables disposables,
         TState      state
      )
         => _arrange
           .Arrange(disposables,
                    state);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrange<TArranges> Create
      (
         IArrange<TArranges> arrange
      )
         => new(arrange);

      /* ------------------------------------------------------------ */

      public static SilentArrange<TArranges> Create
      (
         Func<Disposables, TState, TArranges> arrange
      )
         => new(AtomicArrange<TArranges>.Create(arrange,
                                                string.Empty));

      /* ------------------------------------------------------------ */
   }
}