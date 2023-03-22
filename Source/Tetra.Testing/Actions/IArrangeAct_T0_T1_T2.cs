namespace Tetra.Testing;

public interface IArrangeAct<in TInitialArranges, out TNextArranges, out TNextAsserts>
   : IArrange<TInitialArranges, TNextArranges>,
     IAct<TInitialArranges, TNextAsserts>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
   where TNextAsserts : IAsserts { }