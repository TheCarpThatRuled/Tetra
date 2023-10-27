using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class AAATestDataSource1 : Attribute,
                                          ITestDataSource
{
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
      => (data!.First() as AAA_test1)
       ?.Characterisation();

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AAATestDataSource1()
      => _tests = new(() => GetTests()
                           .Select(test => new[] { test, })
                           .ToList());

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract IEnumerable<AAA_test1> GetTests();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Lazy<IReadOnlyList<object?[]>> _tests;

   /* ------------------------------------------------------------ */
}