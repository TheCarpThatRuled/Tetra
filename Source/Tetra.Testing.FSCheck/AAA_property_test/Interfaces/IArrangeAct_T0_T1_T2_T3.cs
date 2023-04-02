namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public interface IArrangeAct<in TInitialArranges, out TNextArranges, out TNextAsserts>
      : IArrange<TInitialArranges, TNextArranges>,
        IAct<TInitialArranges, TNextAsserts>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
      where TNextAsserts : IAsserts { }
}