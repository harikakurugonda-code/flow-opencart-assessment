using OpenCart.UIControllers.Common;

namespace OpenCart.UIControllers.Controllers
{
   public class ControllerBase
   {
      protected static void WaitForPageLoad(int timeoutSeconds = 10)
      {
         ControllerCommon.WaitForPageLoad(timeoutSeconds);
      }
   }
}