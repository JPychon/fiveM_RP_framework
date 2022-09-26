
using CitizenFX.Core;
using System.Threading.Tasks;
using Client.Models.Player;
using Client.Controllers;
using static CitizenFX.Core.Native.API;

namespace Client.Utility
{
	public class SpawnManager : BaseScript
	{
		public static void FreezePlayer(int playerId, bool freeze)
		{
			var ped = GetPlayerPed(playerId);
			SetPlayerControl(playerId, !freeze, 0);

			if (!freeze)
			{
				if (!IsEntityVisible(ped))
					SetEntityVisible(ped, true, false);

				if (!IsPedInAnyVehicle(ped, true))
					SetEntityCollision(ped, true, true);

				FreezeEntityPosition(ped, false);
				SetPlayerInvincible(playerId, false);
			}
			else
			{
				if (IsEntityVisible(ped))
					SetEntityVisible(ped, false, false);

				SetEntityCollision(ped, false, true);
				FreezeEntityPosition(ped, true);
				SetPlayerInvincible(playerId, true);

				if (IsPedFatallyInjured(ped))
					ClearPedTasksImmediately(ped);
			}
		}

		public static async Task<Models.Player.Character> SpawnPlayer(Character charInfo)
		{
			DoScreenFadeOut(500);

			while (IsScreenFadingOut() && HasModelLoaded((uint)GetHashKey(charInfo.charModel)))
			{
				await Delay(1);

			}

			FreezePlayer(PlayerId(), true);
			await Game.Player.ChangeModel(GetHashKey(charInfo.charModel));
			charInfo.renderPlayerCharacter();

			//---------------------------------// 

			if (charInfo.firstSpawn == false) // char last saved position
			{

				RequestCollisionAtCoord(charInfo.PosX, charInfo.PosY, charInfo.PosZ);

				var ped = GetPlayerPed(-1);

				SetEntityCoordsNoOffset(ped, charInfo.PosX, charInfo.PosY, charInfo.PosZ, false, false, false);
				NetworkResurrectLocalPlayer(charInfo.PosX, charInfo.PosY, charInfo.PosZ, charInfo.heading, true, true);
				ClearPedTasksImmediately(ped);
				RemoveAllPedWeapons(ped, false);
				ClearPlayerWantedLevel(PlayerId());
				SetEntityHealth(GetPlayerPed(-1), charInfo.Health);
				SetPedArmour(GetPlayerPed(-1), charInfo.Armor);
				Game.PlayerPed.Health = charInfo.Health;
				Game.PlayerPed.Armor = charInfo.Armor;
				Game.PlayerPed.Heading = charInfo.heading;



				while (!HasCollisionLoadedAroundEntity(ped))
				{
					await Delay(1);
				}
			}

			else if(charInfo.firstSpawn == true) // new player at spawn points
            {
				var x = -360.91F;
				var y = -129.46F;
				var z = 38.70F;
				var heading = 0F;

				RequestCollisionAtCoord(x, y, z);

				var ped = GetPlayerPed(-1);

				SetEntityCoordsNoOffset(ped, x, y, z, false, false, false);
				NetworkResurrectLocalPlayer(x, y, z, heading, true, true);
				ClearPedTasksImmediately(ped);
				RemoveAllPedWeapons(ped, false);
				ClearPlayerWantedLevel(PlayerId());
				charInfo.firstSpawn = false;
				charInfo.Alive = true;

				Game.PlayerPed.Health = Game.PlayerPed.MaxHealth;
				Game.PlayerPed.Armor = 0;

				charInfo.Health = Game.PlayerPed.Health;
				charInfo.Armor = Game.PlayerPed.Armor;

				SetEntityHealth(GetPlayerPed(-1), GetEntityMaxHealth(GetPlayerPed(-1)));
				SetPedArmour(GetPlayerPed(-1), 0);

				while (!HasCollisionLoadedAroundEntity(ped))
				{
					await Delay(1);
				}
			}

			ShutdownLoadingScreen();
			DoScreenFadeIn(500);

			while (IsScreenFadingIn())
			{
				await Delay(1);
			}

			FreezePlayer(PlayerId(), false);
			await Delay(100);

			return await Task.FromResult(charInfo);
		}
	}
}
