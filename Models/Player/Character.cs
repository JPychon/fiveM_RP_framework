using System;
using System.Collections.Generic;
using CitizenFX.Core;


namespace Server.Models
{
	public class Character
	{
		public Guid Id { get; set; } // primary key to connect player char & user.
		public string Forename { get; set; } = "None"; // first name
		public string Middlename { get; set; } = "None"; // middle name
		public string Surname { get; set; } = "None"; // last name
		public DateTime DateOfBirth { get; set; } // DOB
		public bool Gender { get; set; } = true; // true = male / false = female.
		public bool Alive { get; set; } // health status
		public int Health { get; set; } // HP
		public int Armor { get; set; } // Armor
		public string Ssn { get; set; } = "0000"; // SSN
		public float PosX { get; set; } // X value for position
		public float PosY { get; set; } // Y value for position
		public float PosZ { get; set; } // Z value for position
		public string Model { get; set; } = "None"; // char model
		public string WalkingStyle { get; set; } = "None"; // char walking style
		public DateTime LastPlayed { get; set; } // logoff date.
		public int cash { get; set; } // cash value
		public int level { get; set; } // player level
		public int playTime { get; set; } // player hours
		public DateTime Created { get; set; } // char creation time

		public Vector3 Position // position vector
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

		public int maskStyle { get; set; } = 0; // comp ID 1
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
		public List<KeyValuePair<string, string>> TorsoTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> LeftArmTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> RightArmTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> LeftLegTattoos = new List<KeyValuePair<string, string>>();
		public List<KeyValuePair<string, string>> RightLegTattoos = new List<KeyValuePair<string, string>>();

		//--------------------------------------------------------//

		public string charModel { get; set; }
		public float heading { get; set; }
		public bool firstSpawn { get; set; }



		public Character()
		{
			this.Alive = false;
			this.Created = DateTime.UtcNow;
			this.charModel = "mp_m_freemode_01";
			this.firstSpawn = true;
			this.PosX = -355.622F;
			this.PosY = -124.8791F;
			this.PosZ = 39.42346F;
			this.Health = 100;
			this.Armor = 0;
		}
	}
}
