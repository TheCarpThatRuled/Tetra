using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public abstract class AAAPropertyTestDataSourceAttribute<TState> : Attribute,
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
      => (data!.First() as AAA_test)
       ?.BriefCharacterisation();

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected AAAPropertyTestDataSourceAttribute()
      => _tests = new(() => GetTests()
                           .Select(test => new[] {test,})
                           .Materialise());

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected abstract IEnumerable<AAA_property_test<TState>> GetTests();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Lazy<ISequence<object?[]>> _tests;

   /* ------------------------------------------------------------ */
}