using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class AAATestDataSource : Attribute,
                                          ITestDataSource
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Lazy<IReadOnlyList<object?[]>> _tests;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AAATestDataSource()
      => _tests = new(() => GetTests()
                           .Select(test => new[]
                            {
                               test,
                            })
                           .ToList());

   /* ------------------------------------------------------------ */
   // ITestDataSource Methods
   /* ------------------------------------------------------------ */

   public IEnumerable<object?[]> GetData
   (
      MethodInfo _
   )
      => _tests
        .Value;

   /* ------------------------------------------------------------ */

   public string? GetDisplayName
   (
      MethodInfo _,
      object?[]? data
   )
      => (data!.First() as AAA_test)
       ?.Characterisation();

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract IEnumerable<AAA_test> GetTests();

   /* ------------------------------------------------------------ */
}