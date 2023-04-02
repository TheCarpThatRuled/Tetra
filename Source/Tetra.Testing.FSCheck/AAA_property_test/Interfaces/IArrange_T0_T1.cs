namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public interface IArrange<out TArranges>
      where TArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser);

      /* ------------------------------------------------------------ */

      public TArranges Arrange(Disposables disposables,
                               TState      state);

      /* ------------------------------------------------------------ */
   }
}