using Tetra;
using Tetra.Testing;

namespace Check;
public static partial class TheOptionHasBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public DoWasCalled.Asserts Do()
      {
         var whenSome = FakeAction<FakeType>.Create();
         var whenNone = FakeAction.Create();

         var returnValue = _option.Do(whenSome.Action,
                                      whenNone.Action);

         return new(_option,
                    whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public DoWasCalledWithExternalState.Asserts Do(FakeExternalState externalState)
      {
         var whenSome = FakeAction<FakeExternalState,FakeType>.Create();
         var whenNone = FakeAction<FakeExternalState>.Create();

         var returnValue = _option.Do(externalState,
                                      whenSome.Action,
                                      whenNone.Action);

         return new(_option,
                    whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act(IOption<FakeType> option)
         => _option = option;

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType> _option;

      /* ------------------------------------------------------------ */
   }
}
