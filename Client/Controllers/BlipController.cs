using CitizenFX.Core;

namespace Client.Controllers
{
	public class BlipController : BaseScript
	{
		public BlipController()
		{
			TriggerEvent("dFRP:LoadStaticBlips");
		}
	}
}