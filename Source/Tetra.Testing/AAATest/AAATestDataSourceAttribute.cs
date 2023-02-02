using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class AAATestDataSource : Attribute,
                                          ITestDataSource
{
   /* ------------------------------------------------------------ */
   // ITestDataSource Methods
   /* ------------------------------------------------------------ */

   public IEnumerable<object?[]> GetData(MethodInfo _)
      => _tests
        .Value;

   /* ------------------------------------------------------------ */

   public string? GetDisplayName(MethodInfo _,
                                 object?[]? data)
      => (data!.First() as AAATest)
       ?.Characterisation();

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AAATestDataSource()
      => _tests = new(() => GetTests()
                           .Select(test => new[] {test,})
                           .Materialise());

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract IEnumerable<AAATest> GetTests();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Lazy<ISequence<object?[]>> _tests;

   /* ------------------------------------------------------------ */
}