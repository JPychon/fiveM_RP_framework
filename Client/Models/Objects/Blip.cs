using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Client.Utility;

namespace Client.Models.Objects
{
	public class Blip : BaseScript
	{
		public string BlipTitle { get; set; } // Title on the radar
		public int BlipColor { get; set; } // Color ID

		public BlipSprite BlipSpriteID { get; set; } // BlipSpriteID ID 

		public int BlipCategory { get; set; } // Category type (INDEX: OWNED/FORSALE/VISIBLE TO ALL PLAYERS) 
		public float BlipX { get; set; } // blip X location
		public float BlipY { get; set; } // blip Y location
		public float BlipZ { get; set; } // blip Z location

		public int BlipCustomID { get; set; } // used to store the BlipID assigned to the current instance.
		public object BlipSrite { get; set; }

		public int BlipDisplay { get; set; }

		//private bool BlipVisualRange = true;

		public Vector3 Position { get; set; }

		public static int BlipID = 140; // static blip ID to assign to each created new blip (++)

		public static List<Blip> CustomBlips { get; set; } = new List<Blip>();


		public Blip()
		{
			EventHandlers["dFRP:ReloadBlips"] += new Action(LoadBlipData);
			EventHandlers["dFRP:LoadStaticBlips"] += new Action(LoadStaticBlips);
		}

		public Blip(BlipSprite S, int BC, int C, float posX, float posY, float posZ, string T, int D) // Constuctor to initialize all properties.
		{
			this.BlipSpriteID = S;
			this.BlipCategory = BC;
			this.BlipColor = C;
			this.BlipX = posX;
			this.BlipY = posY;
			this.BlipZ = posZ;
			this.BlipTitle = T;
			this.BlipDisplay = D;
		}

		public void CreateBlipObject() // Object creation method to add the blip to the map.
		{

			BlipCustomID = BlipID;

			CustomBlips.Add(this);

			BlipID++;

			CommFuncs.DisplayMessage("SUCCESS", $"You have created a new blip with the current properties [Blip ID: {this.BlipCustomID}, BlipSpriteID ID: {this.BlipSpriteID}, Category ID: {this.BlipCategory}, Color ID: {this.BlipColor}, Title: {this.BlipTitle}", 255, 0, 0);


			TriggerServerEvent("dFRP:UpdateBlipData");


		}

		public void LoadBlipData()
		{
			foreach (var blip in CustomBlips)
			{
				if (CustomBlips != null)
				{

					blip.BlipCustomID = API.AddBlipForCoord(blip.BlipX, blip.BlipY, blip.BlipZ);
					API.SetBlipSprite(blip.BlipCustomID, (int)blip.BlipSpriteID);
					API.SetBlipCategory(blip.BlipCustomID, blip.BlipCategory);
					API.SetBlipColour(blip.BlipCustomID, blip.BlipColor);
					API.SetBlipDisplay(blip.BlipCustomID, blip.BlipDisplay);
					API.SetBlipAsShortRange(blip.BlipCustomID, true);


					API.BeginTextCommandSetBlipName("STRING");
					API.AddTextComponentSubstringPlayerName(blip.BlipTitle);
					API.EndTextCommandSetBlipName(blip.BlipCustomID);
				}

			}

			Debug.WriteLine("[SERVER] Loading Blip Data function has finished executing.");

		}

		public static List<Blip> StaticBlips = new List<Blip>
		{
			new Blip // LSC Burton
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-337, -135, 39),
				BlipCustomID = 0
			},
			new Blip // LSC by airport
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-1155, -2007, 13),
				BlipCustomID = 1
			},
			new Blip // LSC La Mesa
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(734, -1085, 22),
				BlipCustomID = 2
			},
			new Blip // LSC Harmony
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(1177, 2640, 37),
				BlipCustomID = 3
			},
			new Blip // LSC Paleto Bay
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(108, 6624, 31),
				BlipCustomID = 4
			},
			new Blip // Mechanic Hawic
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(538, -183, 54),
				BlipCustomID = 5
			},
			new Blip // Mechanic Sandy Shores Airfield
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(1774, 3333, 41),
				BlipCustomID = 6
			},
			new Blip // Mechanic Mirror Park
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(1143, -776, 57),
				BlipCustomID = 7
			},
			new Blip // Mechanic East Joshua Rd.
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(2508, 4103, 38),
				BlipCustomID = 8
			},
			new Blip // Mechanic Sandy Shores gas station
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(2006, 3792, 32),
				BlipCustomID = 9
			},
			new Blip // Hayes Auto, Little Bighorn Ave.
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(484, -1316, 29),
				BlipCustomID = 10
			},
			new Blip // Hayes Auto Body Shop, Del Perro
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-1419, -450, 36),
				BlipCustomID = 11
			},
			new Blip // Hayes Auto Body Shop, Davis
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(268, -1810, 27),
				BlipCustomID = 12
			},
			new Blip // Otto's Auto Parts, Sandy Shores
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(1915, 3729, 32),
				BlipCustomID = 13
			},
			new Blip // Mosley Auto Service, Strawberry
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-29, -1665, 29),
				BlipCustomID = 14
			},
			new Blip // Glass Heroes, Strawberry
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-212, -1378, 31),
				BlipCustomID = 15
			},
			new Blip // Mechanic Harmony
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(258, 2594, 44),
				BlipCustomID = 16
			},
			new Blip // Simeons
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-32, -1090, 26),
				BlipCustomID = 17
			},
			new Blip // Bennys
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(-211, -1325, 31),
				BlipCustomID = 18
			},
			new Blip // Auto Repair, Grand Senora Desert
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(903, 3563, 34),
				BlipCustomID = 19
			},
			new Blip // Auto Shop, Grand Senora Desert
			{
				BlipTitle = "Mechanic",
				BlipSpriteID = BlipSprite.Repair,
				Position = new Vector3(437, 3568, 38),
				BlipCustomID = 20
			},

			// Hospitals
			new Blip // Mount Zonah
			{
				BlipTitle = "Hospital",
				BlipSpriteID = BlipSprite.Hospital,
				//SpriteScale = 0.8f,
				Position = new Vector3(-448, -340, 0),
				BlipCustomID = 21
			},
			new Blip // Pillbox Hill
			{
				BlipTitle = "Hospital",
				BlipSpriteID = BlipSprite.Hospital,
				//SpriteScale = 0.8f,
				Position = new Vector3(375, -596, 0),
				BlipCustomID = 22
			},
			new Blip // Central Los Santos
			{
				BlipTitle = "Hospital",
				BlipSpriteID = BlipSprite.Hospital,
				//SpriteScale = 0.8f,
				Position = new Vector3(340, -1400, 0),
				BlipCustomID = 23
			},
			new Blip // Sandy Shores
			{
				BlipTitle = "Hospital",
				BlipSpriteID = BlipSprite.Hospital,
				//SpriteScale = 0.8f,
				Position = new Vector3(1854, 3700, 0),
				BlipCustomID = 24
			},
			new Blip // Paleto Bay
			{
				BlipTitle = "Hospital",
				BlipSpriteID = BlipSprite.Hospital,
				//SpriteScale = 0.8f,
				Position = new Vector3(-245, 6328, 0),
				BlipCustomID = 25
			},
			//new Blip // St. Fiacre
			//{
			//	BlipTitle = "Hospital",
			//	BlipSpriteID = BlipSprite.Hospital,
			//  SpriteScale = 0.8f,
			//	Position = new Vector3(1152, -1525, 0)
			//}

			// Police Stations
			new Blip // La Mesa
			{
				BlipTitle = "Police Station",
				BlipSpriteID = BlipSprite.PoliceStation,
				//SpriteScale = 0.8f,
				Position = new Vector3(850.156677246094f, -1283.92004394531f, 28.0047378540039f),
				BlipCustomID = 26
			},
			new Blip // Mission Row
			{
				BlipTitle = "Police Station",
				BlipSpriteID = BlipSprite.PoliceStation,
				//SpriteScale = 0.8f,
				Position = new Vector3(457.956909179688f, -992.72314453125f, 30.6895866394043f),
				BlipCustomID = 27
			},
			new Blip // Sandy Shores
			{
				BlipTitle = "Police Station",
				BlipSpriteID = BlipSprite.PoliceStation,
				//SpriteScale = 0.8f,
				Position = new Vector3(1856.91320800781f, 3689.50073242188f, 34.2670783996582f),
				BlipCustomID = 28
			},
			new Blip // Paleto Bay
			{
				BlipTitle = "Police Station",
				BlipSpriteID = BlipSprite.PoliceStation,
				//SpriteScale = 0.8f,
				Position = new Vector3(-450.063201904297f, 6016.5751953125f, 31.7163734436035f),
				BlipCustomID = 29
			},


			// Airport and Airfield
			new Blip { BlipCustomID = 30, BlipTitle = "Airport", BlipSpriteID = BlipSprite.Airport, Position = new Vector3(-1032.690f, -2728.141f, 13.757f) },
			new Blip { BlipCustomID = 31, BlipTitle = "Airport", BlipSpriteID = BlipSprite.Airport, Position = new Vector3(1743.6820f, 3286.2510f, 40.087f) },

			// Barbers
			new Blip { BlipCustomID = 32, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(-827.333f, -190.916f, 37.599f) },
			new Blip { BlipCustomID = 33, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(130.512f, -1715.535f, 29.226f) },
			new Blip { BlipCustomID = 34, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(-1291.472f, -1117.230f, 6.641f) },
			new Blip { BlipCustomID = 35, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(1936.451f, 3720.533f, 32.638f) },
			new Blip { BlipCustomID = 36, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(1200.214f, -468.822f, 66.268f) },
			new Blip { BlipCustomID = 37, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(-30.109f, -141.693f, 57.041f) },
			new Blip { BlipCustomID = 38, BlipTitle = "Barber", BlipSpriteID = BlipSprite.Barber, Position = new Vector3(-285.238f, 6236.365f, 31.455f) },

			// Stores
			new Blip { BlipCustomID = 39, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(28.463f, -1353.033f, 29.34f) },
			new Blip { BlipCustomID = 40, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-54.937f, -1759.108f, 29.005f) },
			new Blip { BlipCustomID = 41, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(375.858f, 320.097f, 103.433f) },
			new Blip { BlipCustomID = 42, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(1143.813f, -980.601f, 46.205f) },
			new Blip { BlipCustomID = 43, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(1695.284f, 4932.052f, 42.078f) },
			new Blip { BlipCustomID = 44, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(2686.051f, 3281.089f, 55.241f) },
			new Blip { BlipCustomID = 45, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(1967.648f, 3735.871f, 32.221f) },
			new Blip { BlipCustomID = 46, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-2977.137f, 390.652f, 15.024f) },
			new Blip { BlipCustomID = 47, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(1160.269f, -333.137f, 68.783f) },
			new Blip { BlipCustomID = 48, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-1492.784f, -386.306f, 39.798f) },
			new Blip { BlipCustomID = 49, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-1229.355f, -899.230f, 12.263f) },
			new Blip { BlipCustomID = 50, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-712.091f, -923.820f, 19.014f) },
			new Blip { BlipCustomID = 51, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(-1816.544f, 782.072f, 137.6f) },
			new Blip { BlipCustomID = 52, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(1729.689f, 6405.970f, 34.453f) },
			new Blip { BlipCustomID = 53, BlipTitle = "Store", BlipSpriteID = BlipSprite.Store, Position = new Vector3(2565.705f, 385.228f, 108.463f) },

			// Clothing
			new Blip { BlipCustomID = 54, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(88.291f, -1391.929f, 29.2f) },
			new Blip { BlipCustomID = 55, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-718.985f, -158.059f, 36.996f) },
			new Blip { BlipCustomID = 56, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-151.204f, -306.837f, 38.724f) },
			new Blip { BlipCustomID = 57, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(414.646f, -807.452f, 29.338f) },
			new Blip { BlipCustomID = 58, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-815.193f, -1083.333f, 11.022f) },
			new Blip { BlipCustomID = 59, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-1208.098f, -782.020f, 17.163f) },
			new Blip { BlipCustomID = 60, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-1457.954f, -229.426f, 49.185f) },
			new Blip { BlipCustomID = 61, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-2.777f, 6518.491f, 31.533f) },
			new Blip { BlipCustomID = 62, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(1681.586f, 4820.133f, 42.046f) },
			new Blip { BlipCustomID = 63, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(130.216f, -202.940f, 54.505f) },
			new Blip { BlipCustomID = 64, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(618.701f, 2740.564f, 41.905f) },
			new Blip { BlipCustomID = 65, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(1199.169f, 2694.895f, 37.866f) },
			new Blip { BlipCustomID = 66, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-3164.172f, 1063.927f, 20.674f) },
			new Blip { BlipCustomID = 67, BlipTitle = "Clothing", BlipSpriteID = BlipSprite.Clothes, Position = new Vector3(-1091.373f, 2702.356f, 19.422f) },

			// Ammunation
			new Blip { BlipCustomID = 68, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(1701.292f, 3750.450f, 34.365f) },
			new Blip { BlipCustomID = 69, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(237.428f, -43.655f, 69.698f) },
			new Blip { BlipCustomID = 71, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(843.604f, -1017.784f, 27.546f) },
			new Blip { BlipCustomID = 72, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(-321.524f, 6072.479f, 31.299f) },
			new Blip { BlipCustomID = 73, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(-664.218f, -950.097f, 21.509f) },
			new Blip { BlipCustomID = 74, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(-1320.983f, -389.260f, 36.483f) },
			new Blip { BlipCustomID = 75, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(-1109.053f, 2686.300f, 18.775f) },
			new Blip { BlipCustomID = 76, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(2568.379f, 309.629f, 108.461f) },
			new Blip { BlipCustomID = 77, BlipTitle = "Weapon store", BlipSpriteID = BlipSprite.AmmuNation, Position = new Vector3(-3157.450f, 1079.633f, 20.692f) },

			// Gas stations
			new Blip { BlipCustomID = 78, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(49.4187f, 2778.793f, 58.043f) },
			new Blip { BlipCustomID = 79, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(263.894f, 2606.463f, 44.983f) },
			new Blip { BlipCustomID = 80, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1039.958f, 2671.134f, 39.55f) },
			new Blip { BlipCustomID = 81, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1207.260f, 2660.175f, 37.899f) },
			new Blip { BlipCustomID = 82, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(2539.685f, 2594.192f, 37.944f) },
			new Blip { BlipCustomID = 83, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(2679.858f, 3263.946f, 55.24f) },
			new Blip { BlipCustomID = 84, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(2005.055f, 3773.887f, 32.403f) },
			new Blip { BlipCustomID = 85, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1687.156f, 4929.392f, 42.078f) },
			new Blip { BlipCustomID = 86, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1701.314f, 6416.028f, 32.763f) },
			new Blip { BlipCustomID = 87, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(179.857f, 6602.839f, 31.868f) },
			new Blip { BlipCustomID = 88, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-94.4619f, 6419.594f, 31.489f) },
			new Blip { BlipCustomID = 89, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-2554.996f, 2334.40f, 33.078f) },
			new Blip { BlipCustomID = 90, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-1800.375f, 803.661f, 138.651f) },
			new Blip { BlipCustomID = 91, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-1437.622f, -276.747f, 46.207f) },
			new Blip { BlipCustomID = 92, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-2096.243f, -320.286f, 13.168f) },
			new Blip { BlipCustomID = 93, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-724.619f, -935.1631f, 19.213f) },
			new Blip { BlipCustomID = 94, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-526.019f, -1211.003f, 18.184f) },
			new Blip { BlipCustomID = 95, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(-70.2148f, -1761.792f, 29.534f) },
			new Blip { BlipCustomID = 96, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(265.648f, -1261.309f, 29.292f) },
			new Blip { BlipCustomID = 97, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(819.653f, -1028.846f, 26.403f) },
			new Blip { BlipCustomID = 98, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1208.951f, -1402.567f, 35.224f) },
			new Blip { BlipCustomID = 99, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(1181.381f, -330.847f, 69.316f) },
			new Blip { BlipCustomID = 100, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(620.843f, 269.100f, 103.089f) },
			new Blip { BlipCustomID = 101, BlipTitle = "Gas Station", BlipSpriteID = BlipSprite.JerryCan, Position = new Vector3(2581.321f, 362.039f, 108.468f) },

			// Police Stations
			new Blip { BlipCustomID = 102, BlipTitle = "Police Station", BlipSpriteID = BlipSprite.PoliceStation, Position = new Vector3(425.130f, -979.558f, 30.711f) },
			new Blip { BlipCustomID = 103, BlipTitle = "Police Station", BlipSpriteID = BlipSprite.PoliceStation, Position = new Vector3(1859.234f, 3678.742f, 33.69f) },
			new Blip { BlipCustomID = 104, BlipTitle = "Police Station", BlipSpriteID = BlipSprite.PoliceStation, Position = new Vector3(-438.862f, 6020.768f, 31.49f) },
			new Blip { BlipCustomID = 105, BlipTitle = "Police Station", BlipSpriteID = BlipSprite.PoliceStation, Position = new Vector3(818.221f, -1289.883f, 26.3f) },

			//new Blip { BlipTitle = "Prison", id=285, Position = new Vector3(1679.049f, 2513.711f, 45.565f) },

			// Hospitals
			new Blip { BlipCustomID = 106, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(1839.6f, 3672.93f, 34.28f) },
			new Blip { BlipCustomID = 107, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(-247.76f, 6331.23f, 32.43f) },
			new Blip { BlipCustomID = 108, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(-449.67f, -340.83f, 34.5f) },
			new Blip { BlipCustomID = 109, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(357.43f, -593.36f, 28.79f) },
			new Blip { BlipCustomID = 110, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(295.83f, -1446.94f, 29.97f) },
			new Blip { BlipCustomID = 111, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(-676.98f, 310.68f, 83.08f) },
			new Blip { BlipCustomID = 112, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(1151.21f, -1529.62f, 35.37f) },
			new Blip { BlipCustomID = 113, BlipTitle = "Hospital", BlipSpriteID = BlipSprite.Hospital, Position = new Vector3(-874.64f, -307.71f, 39.58f) },

			// Vehicle Shop (Simeon)
			//new Blip { BlipTitle = "Simeon", id=120, Position = new Vector3(-33.803f, -1102.322f, 25.422f) },

			// LS Customs
			new Blip { BlipCustomID = 114, BlipTitle = "LS Customs", BlipSpriteID = BlipSprite.LosSantosCustoms, Position = new Vector3(-362.796f, -132.400f, 38.252f) },
			new Blip { BlipCustomID = 115, BlipTitle = "LS Customs", BlipSpriteID = BlipSprite.LosSantosCustoms, Position = new Vector3(-1140.19f, -1985.478f, 12.729f) },
			new Blip { BlipCustomID = 116, BlipTitle = "LS Customs", BlipSpriteID = BlipSprite.LosSantosCustoms, Position = new Vector3(716.464f, -1088.869f, 21.929f) },
			new Blip { BlipCustomID = 117, BlipTitle = "LS Customs", BlipSpriteID = BlipSprite.LosSantosCustoms, Position = new Vector3(1174.81f, 2649.954f, 37.371f) },
			new Blip { BlipCustomID = 118, BlipTitle = "LS Customs", BlipSpriteID = BlipSprite.LosSantosCustoms, Position = new Vector3(118.485f, 6619.560f, 31.802f) },


			// Survivals
			new Blip { BlipCustomID = 119, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(2351.331f, 3086.969f, 48.057f) },
			new Blip { BlipCustomID = 120, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(-1695.803f, -1139.190f, 13.152f) },
			new Blip { BlipCustomID = 121, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(1532.52f, -2138.682f, 77.12f) },
			new Blip { BlipCustomID = 122, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(-593.724f, 5283.231f, 70.23f) },
			new Blip { BlipCustomID = 123, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(1891.436f, 3737.409f, 32.513f) },
			new Blip { BlipCustomID = 124, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(195.572f, -942.493f, 30.692f) },
			new Blip { BlipCustomID = 125, BlipTitle = "Survival", BlipSpriteID = BlipSprite.GTAOSurvival, Position = new Vector3(1488.579f, 3582.804f, 35.345f) },

			new Blip { BlipCustomID = 126, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-952.35943603516f, -1077.5021972656f, 2.6772258281708f) },
			new Blip { BlipCustomID = 127, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-59.124889373779f, -616.55456542969f, 37.356777191162f) },
			new Blip { BlipCustomID = 128, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-255.05390930176f, -943.32885742188f, 31.219989776611f) },
			new Blip { BlipCustomID = 129, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-771.79888916016f, 351.59423828125f, 87.998191833496f) },
			new Blip { BlipCustomID = 130, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-3086.428f, 339.252f, 6.371f) },
			new Blip { BlipCustomID = 131, BlipTitle = "Safehouse", BlipSpriteID = BlipSprite.Garage, Position = new Vector3(-917.289f, -450.206f, 39.6f) },

			new Blip { BlipCustomID = 132, BlipTitle = "Race", BlipSpriteID = BlipSprite.RaceSea, Position = new Vector3(-1277.629f, -2030.913f, 1.2823f) },
			new Blip { BlipCustomID = 133, BlipTitle = "Race", BlipSpriteID = BlipSprite.RaceSea, Position = new Vector3(2384.969f, 4277.583f, 30.379f) },
			new Blip { BlipCustomID = 134, BlipTitle = "Race", BlipSpriteID = BlipSprite.RaceSea, Position = new Vector3(1577.881f, 3836.107f, 30.7717f) },

			// Yacht
			new Blip { BlipCustomID = 135, BlipTitle = "Yacht", BlipSpriteID = BlipSprite.Boat, Position = new Vector3(-2045.800f, -1031.200f, 11.9f) },
			new Blip { BlipCustomID = 136, BlipTitle = "Cargoship", BlipSpriteID = BlipSprite.Boat, Position = new Vector3(-90f, -2365.800f, 14.3f) },

			// Bahama Mamas West
			new Blip { BlipCustomID = 137, BlipTitle = "Bahama Mamas West", BlipSpriteID = BlipSprite.Bar, Position = new Vector3(-1387.975f, -587.7377f, 30.21593f) }
		};

		public void LoadStaticBlips()
		{
			foreach (var blip in StaticBlips)
			{
				if (StaticBlips != null)
				{
					if (blip.BlipX == 0 || blip.BlipY == 0 || blip.BlipZ == 0)
					{
						blip.BlipCustomID = API.AddBlipForCoord(blip.Position.X, blip.Position.Y, blip.Position.Z);
						API.SetBlipSprite(blip.BlipCustomID, (int)blip.BlipSpriteID);


						API.BeginTextCommandSetBlipName("STRING");
						API.AddTextComponentSubstringPlayerName(blip.BlipTitle);
						API.EndTextCommandSetBlipName(blip.BlipCustomID);
						API.SetBlipDisplay(blip.BlipCustomID, 2);
						API.SetBlipCategory(blip.BlipCustomID, 1);
						API.SetBlipAsShortRange(blip.BlipCustomID, true);
					}
				}
			}
		}
	}
}
