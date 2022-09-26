using CitizenFX.Core;
using CitizenFX.Core.Native;
using Client.Controllers;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Client.Models.Player
{
	public class Character
	{
		public Guid Id { get; set; }
		public string Forename { get; set; } = "None";
		public string Middlename { get; set; } = "None";
		public string Surname { get; set; } = "None";
		public DateTime DateOfBirth { get; set; }
		public bool Gender { get; set; } = true;
		public bool Alive { get; set; }
		public int Health { get; set; }
		public int Armor { get; set; }
		public string Ssn { get; set; } = "0000";
		public float PosX { get; set; }
		public float PosY { get; set; }
		public float PosZ { get; set; }
		public string Model { get; set; } = "None";
		public string WalkingStyle { get; set; } = "None";
		public DateTime LastPlayed { get; set; }

		public DateTime Created { get; set; }
		public int cash { get; set; } // cash value
		public int level { get; set; } // player level
		public int playTime { get; set; } // player hours

		public Vector3 Position
		{
			get => new Vector3(this.PosX, this.PosY, this.PosZ);
			set
			{
				this.PosX = value.X;
				this.PosY = value.Y;
				this.PosZ = value.Z;
			}
		}


		//---------------------------- Character details & features. -----------------------

		// Heritage
		public int motherIndex { get; set; } = 0;
		public int fatherIndex { get; set; } = 0;
		public float skinMixFloat { get; set; } = 0;
		public float shapeMixFloat { get; set; } = 0;

		// Facial features

		public float NoseWidth { get; set; } = 0;
		public float NosePeak { get; set; } = 0;
		public float NosePeakLength { get; set; } = 0;
		public float NoseBoneHeight { get; set; } = 0;
		public float NosePeakLowering { get; set; } = 0;
		public float NoseBoneTwist { get; set; } = 0;
		public float EyeBrowDepth { get; set; } = 0;
		public float EyeBrowHeight { get; set; } = 0;
		public float CheekBoneHeight { get; set; } = 0;
		public float CheekBoneWidth { get; set; } = 0;
		public float CheeksWidth { get; set; } = 0;
		public float EyesOpening { get; set; } = 0;
		public float LipsThickness { get; set; } = 0;
		public float JawBoneWidth { get; set; } = 0;
		public float JawBoneDepth { get; set; } = 0;
		public float ChinHeight { get; set; } = 0;
		public float ChinDepth { get; set; } = 0;
		public float ChinWidth { get; set; } = 0;
		public float ChinHoleSize { get; set; } = 0;
		public float NeckThickness { get; set; } = 0;

		// Face Details

		public int hairStyle { get; set; } = 0;
		public int hairStyleColor { get; set; } = 0;
		public int eyeBrowStyle { get; set; } = 0;
		public int eyeBrowColor { get; set; } = 0;
		public float eyeBrowOpacity { get; set; } = 0.5f;
		public int beardStyle { get; set; } = 0;
		public int beardColor { get; set; } = 0;
		public float beardOpacity { get; set; } = 0.5f;
		public int blemishesStyle { get; set; } = 0;
		public float blemishesOpacity { get; set; } = 0.5f;
		public int skinAgingStyle { get; set; } = 0;
		public float skinAgingOpacity { get; set; } = 0.5f;
		public int complexionStyle { get; set; } = 0;
		public float complexionOpacity { get; set; } = 0.5f;
		public int molesStyle { get; set; } = 0;
		public float molesOpacity { get; set; } = 0.5f;
		public int sunDamageStyle { get; set; } = 0;
		public float sunDamageOpacity { get; set; } = 0.5f;
		public int eyeColorStyle { get; set; } = 0;
		public int makeupStyle { get; set; } = 0;
		public int makeupColor { get; set; } = 0;
		public float makeupOpacity { get; set; } = 0.5f;
		public int lipStickStyle { get; set; } = 0;
		public int lipStickColor { get; set; } = 0;
		public float lipStickOpacity { get; set; } = 0.5f;
		public int chestHairStyle { get; set; } = 0;
		public int chestHairColor { get; set; } = 0;
		public float chestHairOpacity { get; set; } = 0.5f;
		public int blushStyle { get; set; } = 0;
		public int blushColor { get; set; } = 0;
		public float blushOpacity { get; set; } = 0.0f;

		// Clothes

		public int maskStyle { get; set; } = 1; // comp ID 1
		public int maskColor { get; set; } = 0;
		public int armStyle { get; set; } = 0; // comp ID 3
		public int armColor { get; set; } = 0;
		public int pantStyle { get; set; } = 1; // comp ID 4
		public int pantColor { get; set; } = 0;
		public int shoeStyle { get; set; } = 1; // comp ID 6
		public int shoeColor { get; set; } = 0;
		public int chainStyle { get; set; } = 1; // comp ID 7
		public int chainColor { get; set; } = 0;
		public int tShirtStyle { get; set; } = 1; // comp ID 8
		public int tShirtColor { get; set; } = 0;
		public int bArmorStyle { get; set; } = 1; // comp ID 9
		public int bArmorColor { get; set; } = 0;
		public int torsoStyle { get; set; } = 1; // comp ID 11
		public int torsoColor { get; set; } = 0;


		//------------------------------------------------------//


		public int hatID { get; set; } = -1;
		public int hatColor { get; set; } = 0;
		public int glassesID { get; set; } = -1;
		public int glassesColor { get; set; } = 0;
		public int earringID { get; set; } = -1;
		public int earringColor { get; set; } = 0;
		public int watchID { get; set; } = -1;
		public int watchColor { get; set; } = 0;
		public int braceletID { get; set; } = -1;
		public int braceletColor { get; set; } = 0;

		//--------------------------------------------------------//

		public List<KeyValuePair<string, string>> HeadTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> TorsoTattoos =new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> LeftArmTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> RightArmTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> LeftLegTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> RightLegTattoos = new List<KeyValuePair<string, string>>();

		//--------------------------------------------------------//

		public string charModel { get; set; }
		public float heading { get; set; }
		public bool firstSpawn { get; set; }

		public void renderPlayerCharacter() // 
        {

			API.SetPedHeadBlendData(API.GetPlayerPed(-1), this.motherIndex, this.fatherIndex, 0, this.motherIndex, this.fatherIndex, 0, this.shapeMixFloat, this.skinMixFloat, 0, true); // Heritage
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 0, this.NoseWidth);  // Facial features
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 1, this.NosePeak);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 2, this.NosePeakLength);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 3, this.NoseBoneHeight);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 4, this.NosePeakLowering);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 5, this.NoseBoneTwist);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 6, this.EyeBrowDepth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 7, this.EyeBrowHeight);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 8, this.CheekBoneWidth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 9, this.CheekBoneHeight);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 10, this.CheeksWidth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 11, this.EyesOpening);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 12, this.LipsThickness);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 13, this.JawBoneWidth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 14, this.JawBoneDepth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 15, this.ChinHeight);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 16, this.ChinDepth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 17, this.ChinWidth);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 18, this.ChinHoleSize);
			API.SetPedFaceFeature(API.GetPlayerPed(-1), 19, this.NeckThickness);

			API.SetPedComponentVariation(API.GetPlayerPed(-1), 2, this.hairStyle, 0, 2); // hairstyle
			API.SetPedHairColor(API.GetPlayerPed(-1), this.hairStyleColor, 0);
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 2, this.eyeBrowStyle, this.eyeBrowOpacity); // eyebrows
			API.SetPedHeadOverlayColor(API.GetPlayerPed(-1), 2, 1, this.eyeBrowColor, 0);
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 1, this.beardStyle, this.beardOpacity); // beard
			API.SetPedHeadOverlayColor(API.GetPlayerPed(-1), 1, 1, this.beardColor, 0);
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 11, this.blemishesStyle, this.blemishesOpacity); // blemishes
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 3, this.skinAgingStyle, this.skinAgingOpacity); // skin aging
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 6, this.complexionStyle, this.complexionOpacity); // skin complexion
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 9, this.molesStyle, this.molesOpacity); // moles & freckles
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 7, this.sunDamageStyle, this.sunDamageOpacity); // sun damage
			API.SetPedEyeColor(API.GetPlayerPed(-1), this.eyeColorStyle); // eye color
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 4, this.makeupStyle, this.makeupOpacity); // makeup
			API.SetPedHeadOverlayColor(API.GetPlayerPed(-1), 4, 0, this.makeupColor, 0);
			API.SetPedHeadOverlay(API.GetPlayerPed(-1), 8, this.lipStickStyle, this.lipStickOpacity); // lipstick
			API.SetPedHeadOverlayColor(API.GetPlayerPed(-1), 8, 2, this.lipStickColor, 0);

			API.SetPedComponentVariation(API.GetPlayerPed(-1), 1, this.maskStyle, this.maskColor, 2); // Masks
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 3, this.armStyle, this.armColor, 2); // Arms/upper body
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 4, this.pantStyle, this.pantColor, 2); // Pants
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 6, this.shoeStyle, this.shoeColor, 2); // Shoes
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 7, this.tShirtStyle, this.tShirtColor, 2); // acessories
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 8, this.bArmorStyle, this.bArmorColor, 2); // undershirt
			API.SetPedComponentVariation(API.GetPlayerPed(-1), 11, this.torsoStyle, this.torsoColor, 2); // jackets

			API.SetPedPropIndex(API.GetPlayerPed(-1), 0, this.hatID, this.hatColor, true); // hats/helmets
			API.SetPedPropIndex(API.GetPlayerPed(-1), 1, this.glassesID, this.glassesColor, true); // glasses
			API.SetPedPropIndex(API.GetPlayerPed(-1), 2, this.earringID, this.earringColor , true); // earrings
			API.SetPedPropIndex(API.GetPlayerPed(-1), 6, this.watchID, this.watchColor, true); // watches
			API.SetPedPropIndex(API.GetPlayerPed(-1), 7, this.braceletID, this.braceletColor, true); // bracelets

			API.ClearPedDecorations(Game.PlayerPed.Handle);
			foreach (var tattoo in this.HeadTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}
			foreach (var tattoo in this.TorsoTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}
			foreach (var tattoo in this.LeftArmTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}
			foreach (var tattoo in this.RightArmTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}
			foreach (var tattoo in this.LeftLegTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}
			foreach (var tattoo in this.RightLegTattoos)
			{
				API.SetPedDecoration(Game.PlayerPed.Handle, (uint)API.GetHashKey(tattoo.Key), (uint)API.GetHashKey(tattoo.Value));
			}

		}
		private PedHeadBlendData GetHeadBlend(int pedHandle)
		{
			if (API.DoesEntityExist(pedHandle) && API.IsEntityAPed(pedHandle))
			{
				if (API.HasPedHeadBlendFinished(pedHandle))
				{
					Ped p = (Ped)Entity.FromHandle(pedHandle);
					return p.GetHeadBlendData();
				}
			}
			return new PedHeadBlendData();
		}

		public async Task<Player.Character> getPedRenderLocation()
        {
			Position = API.GetEntityCoords(Game.PlayerPed.Handle, false); // Player Ped Position
			heading = API.GetEntityHeading(Game.PlayerPed.Handle);
			Health = API.GetEntityHealth(Game.PlayerPed.Handle); // Health
			Armor = API.GetPedArmour(Game.PlayerPed.Handle); // Armor
			LastPlayed = DateTime.Now; // Last Played

			return await Task.FromResult(this);
		}

		public async Task<Player.Character> getPedRenderValues()
        {
			//------------------------------[ ref vars ]------------------------------------------//

			var colorOverlayType = 1;
			var colorOverlaySecondType = 2;
			var colorOverlayThirdType = 0;
			var StyleRef = 0;
			var ColorRef = 0;
			var SecondColorRef = 0;
			float OpacityRef = 0;



			PedHeadBlendData pedBlendData = GetHeadBlend(Game.PlayerPed.Handle); // Head Blend Data
			motherIndex = pedBlendData.FirstFaceShape;
			fatherIndex = pedBlendData.SecondFaceShape;
			shapeMixFloat = pedBlendData.ParentFaceShapePercent;
			skinMixFloat = pedBlendData.ParentSkinTonePercent;



			charModel = API.GetEntityModel(Game.PlayerPed.Handle).ToString();
			Model = API.GetEntityModel(Game.PlayerPed.Handle).ToString();

			//-------------------[ Facial Features ]-----------------------------------//

			NoseWidth = API.GetPedFaceFeature(Game.Player.Handle, 0);
			NosePeak = API.GetPedFaceFeature(Game.Player.Handle, 1);
			NosePeakLength = API.GetPedFaceFeature(Game.Player.Handle, 2);
			NoseBoneHeight = API.GetPedFaceFeature(Game.Player.Handle, 3);
			NosePeakLowering = API.GetPedFaceFeature(Game.Player.Handle, 4);
			NoseBoneTwist = API.GetPedFaceFeature(Game.Player.Handle, 5);
			EyeBrowDepth = API.GetPedFaceFeature(Game.Player.Handle, 6);
			EyeBrowHeight = API.GetPedFaceFeature(Game.Player.Handle, 7);
			CheekBoneWidth = API.GetPedFaceFeature(Game.Player.Handle, 8);
			CheekBoneHeight = API.GetPedFaceFeature(Game.Player.Handle, 9);
			CheeksWidth = API.GetPedFaceFeature(Game.Player.Handle, 10);
			EyesOpening = API.GetPedFaceFeature(Game.Player.Handle, 11);
			LipsThickness = API.GetPedFaceFeature(Game.Player.Handle, 12);
			JawBoneWidth = API.GetPedFaceFeature(Game.Player.Handle, 13);
			JawBoneDepth = API.GetPedFaceFeature(Game.Player.Handle, 14);
			ChinHeight = API.GetPedFaceFeature(Game.Player.Handle, 15);
			ChinDepth = API.GetPedFaceFeature(Game.Player.Handle, 16);
			ChinWidth = API.GetPedFaceFeature(Game.Player.Handle, 17);
			ChinHoleSize = API.GetPedFaceFeature(Game.Player.Handle, 18);
			NeckThickness = API.GetPedFaceFeature(Game.Player.Handle, 19);

			//--------------------------[ Overlay Data]---------------------------------//

			for(int i = 0; i <= 11; ++i)
            {
				if (i == 1 || i == 2)
				{
					API.GetPedHeadOverlayData(Game.PlayerPed.Handle, i, ref StyleRef, ref colorOverlayType, ref ColorRef, ref SecondColorRef, ref OpacityRef); // beard
					switch (i)
					{
						case 1:
							beardStyle = StyleRef;
							beardColor = ColorRef;
							beardOpacity = OpacityRef;
							break;
						case 2:
							eyeBrowStyle = StyleRef;
							eyeBrowColor = ColorRef;
							eyeBrowOpacity = OpacityRef;
							break;
					}
				}
				if (i == 8)
				{
					API.GetPedHeadOverlayData(Game.PlayerPed.Handle, i, ref StyleRef, ref colorOverlaySecondType, ref ColorRef, ref SecondColorRef, ref OpacityRef); // beard
					lipStickStyle = StyleRef;
					lipStickColor = ColorRef;
					lipStickOpacity = OpacityRef;
				}
				else
				{
					API.GetPedHeadOverlayData(Game.PlayerPed.Handle, i, ref StyleRef, ref colorOverlayThirdType, ref ColorRef, ref SecondColorRef, ref OpacityRef); // beard
					switch (i)
					{
						case 3:
							skinAgingStyle = StyleRef;
							skinAgingOpacity = OpacityRef;
							break;
						case 4:
							makeupStyle = StyleRef;
							makeupColor = ColorRef;
							makeupOpacity = OpacityRef;
							break;
						case 6:
							complexionStyle = StyleRef;
							complexionOpacity = OpacityRef;
							break;
						case 7:
							sunDamageStyle = StyleRef;
							sunDamageOpacity = OpacityRef;
							break;
						case 9:
							molesStyle = StyleRef;
							molesOpacity = OpacityRef;
							break;
						case 11:
							blemishesStyle = StyleRef;
							blemishesOpacity = OpacityRef;
							break;
						default:
							break;
					}
				}
			}

			//----------------------[Drawable Variations]-------------------------------------------//

			eyeColorStyle = API.GetPedEyeColor(Game.Player.Handle);

			maskStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 1);
			maskColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 1);

			hairStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 2);
			hairStyleColor = API.GetPedHairColor(Game.Player.Handle);

			armStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 3);
			armColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 3);

			pantStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 4);
			pantColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 4);

			shoeStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 6);
			shoeColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 6);

			tShirtStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 7);
			tShirtColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 7);

			bArmorStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 8);
			bArmorColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 8);

			torsoStyle = API.GetPedDrawableVariation(Game.PlayerPed.Handle, 11);
			torsoColor = API.GetPedTextureVariation(Game.PlayerPed.Handle, 11);

			//----------------------------------[ Props ]----------------------------------------------------//

			hatID = API.GetPedPropIndex(Game.PlayerPed.Handle, 0);
			hatColor = API.GetPedPropTextureIndex(Game.PlayerPed.Handle, 0);

			glassesID = API.GetPedPropIndex(Game.PlayerPed.Handle, 1);
			glassesColor = API.GetPedPropTextureIndex(Game.PlayerPed.Handle, 1);

			earringID = API.GetPedPropIndex(Game.PlayerPed.Handle, 2);
			earringColor = API.GetPedPropTextureIndex(Game.PlayerPed.Handle, 2);

			watchID = API.GetPedPropIndex(Game.PlayerPed.Handle, 6);
			watchColor = API.GetPedPropTextureIndex(Game.PlayerPed.Handle, 6);

			braceletID = API.GetPedPropIndex(Game.PlayerPed.Handle, 7);
			braceletColor = API.GetPedPropTextureIndex(Game.PlayerPed.Handle, 7);

			return await Task.FromResult(this);
		}
	}
}
