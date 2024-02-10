using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class AAAPropertyTestSource : Attribute,
                                                  ITestDataSource
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Lazy<ISequence<object?[]>> _tests;

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AAAPropertyTestSource()
      => _tests = new(() => GetTests()
                           .Select(test => new[]
                            {
                               test,
                            })
                           .Materialise());

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
      => (data!.First() as AAA_property_test)
       ?.Characterisation();

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract IEnumerable<AAA_property_test> GetTests();

   /* ------------------------------------------------------------ */
}