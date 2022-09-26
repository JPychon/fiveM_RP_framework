using CitizenFX.Core;
using MySqlConnector;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBAcesss
{
    public class DB_Character : BaseScript
    {
        public DB_Character() {  }

        public static async Task<List<Character>> load_Characters()
        {
            List<Character> charList = new List<Character>();
            string userQuery = " SELECT * FROM  characters"; // SQL query-string to hold execute in the DB

            MySqlCommand charCommand = new MySqlCommand(userQuery, DB_Connection.DBConnection); // command object to execute the query

            await DB_Connection.DBConnection.OpenAsync(); //
            using(var charList_Reader = await charCommand.ExecuteReaderAsync())

            if (await charList_Reader.ReadAsync())
            {
                Guid id = charList_Reader.GetGuid(0);
                string fName = charList_Reader["forename"].ToString();
                string mName = charList_Reader["middlename"].ToString();
                string lName = charList_Reader["surname"].ToString();
                DateTime DOB = charList_Reader.GetDateTime(4);
                bool gender = charList_Reader.GetBoolean(5);
                bool alive = charList_Reader.GetBoolean(6);
                int health = charList_Reader.GetInt32(7);
                int armor = charList_Reader.GetInt32(8);
                string SSN = charList_Reader["ssn"].ToString();
                float posX = charList_Reader.GetFloat(10);
                float posY = charList_Reader.GetFloat(11);
                float posZ = charList_Reader.GetFloat(12);
                string model = charList_Reader["model"].ToString();
                string walkingStyle = charList_Reader["walkingstyle"].ToString();
                DateTime lastPlayed = charList_Reader.GetDateTime(15);
                int cash = charList_Reader.GetInt32(16);
                int level = charList_Reader.GetInt32(17);
                int playTime = charList_Reader.GetInt32(18);
                DateTime created = charList_Reader.GetDateTime(19);

                // Character Details

                int motherIndex = charList_Reader.GetInt32(20);
                int fatherIndex = charList_Reader.GetInt32(21);
                float skinMixFloat = charList_Reader.GetFloat(22);
                float shapeMixFloat = charList_Reader.GetFloat(23);
                float NoseWidth = charList_Reader.GetFloat(24);
                float NosePeak = charList_Reader.GetFloat(25);
                float NosePeakLength = charList_Reader.GetFloat(26);
                float NoseBoneHeight = charList_Reader.GetFloat(27);
                float NosePeakLowering = charList_Reader.GetFloat(28);
                float NoseBoneTwist = charList_Reader.GetFloat(29);
                float EyeBrowDepth = charList_Reader.GetFloat(30);
                float EyeBrowHeight = charList_Reader.GetFloat(31);
                float CheekBoneHeight = charList_Reader.GetFloat(32);
                float CheekBoneWidth = charList_Reader.GetFloat(33);
                float CheeksWidth = charList_Reader.GetFloat(34);
                float EyesOpening = charList_Reader.GetFloat(35);
                float LipsThickness = charList_Reader.GetFloat(36);
                float JawBoneWidth = charList_Reader.GetFloat(37);
                float JawBoneDepth = charList_Reader.GetFloat(38);
                float ChinHeight = charList_Reader.GetFloat(39);
                float ChinDepth = charList_Reader.GetFloat(40);
                float ChinWidth = charList_Reader.GetFloat(41);
                float ChinHoleSize = charList_Reader.GetFloat(42);
                float NeckThickness = charList_Reader.GetFloat(43);
                int hairStyle = charList_Reader.GetInt32(44);
                int hairStyleColor = charList_Reader.GetInt32(45);
                int eyeBrowStyle = charList_Reader.GetInt32(46);
                int eyeBrowColor = charList_Reader.GetInt32(47);
                float eyeBrowOpacity = charList_Reader.GetFloat(48);
                int beardStyle = charList_Reader.GetInt32(49);
                int beardColor = charList_Reader.GetInt32(50);
                float beardOpacity = charList_Reader.GetFloat(51);
                int blemishesStyle = charList_Reader.GetInt32(52);
                float blemishesOpacity = charList_Reader.GetFloat(53);
                int skinAgingStyle = charList_Reader.GetInt32(54);
                float skinAgingOpacity = charList_Reader.GetFloat(55);
                int complexionStyle = charList_Reader.GetInt32(56);
                float complexionOpacity = charList_Reader.GetFloat(57);
                int molesStyle = charList_Reader.GetInt32(58);
                float molesOpacity = charList_Reader.GetFloat(59);
                int sunDamageStyle = charList_Reader.GetInt32(60);
                float sunDamageOpacity = charList_Reader.GetFloat(61);
                int eyeColorStyle = charList_Reader.GetInt32(62);
                int makeupStyle = charList_Reader.GetInt32(63);
                int makeupColor = charList_Reader.GetInt32(64);
                float makeupOpacity = charList_Reader.GetFloat(65);
                int lipStickStyle = charList_Reader.GetInt32(66);
                int lipStickColor = charList_Reader.GetInt32(67);
                float lipStickOpacity = charList_Reader.GetFloat(68);
                int chestHairStyle = charList_Reader.GetInt32(69);
                int chestHairColor = charList_Reader.GetInt32(70);
                float chestHairOpacity = charList_Reader.GetFloat(71);
                int blushStyle = charList_Reader.GetInt32(72);
                int blushColor = charList_Reader.GetInt32(73);
                float blushOpacity = charList_Reader.GetFloat(74);
                int maskStyle = charList_Reader.GetInt32(75);
                int maskColor = charList_Reader.GetInt32(76);
                int armStyle = charList_Reader.GetInt32(77);
                int armColor = charList_Reader.GetInt32(78);
                int pantStyle = charList_Reader.GetInt32(79);
                int pantColor = charList_Reader.GetInt32(80);
                int shoeStyle = charList_Reader.GetInt32(81);
                int shoeColor = charList_Reader.GetInt32(82);
                int chainStyle = charList_Reader.GetInt32(83);
                int chainColor = charList_Reader.GetInt32(84);
                int tShirtStyle = charList_Reader.GetInt32(85);
                int tShirtColor = charList_Reader.GetInt32(86);
                int bArmorStyle = charList_Reader.GetInt32(87);
                int bArmorColor = charList_Reader.GetInt32(88);
                int torsoStyle = charList_Reader.GetInt32(89);
                int torsoColor = charList_Reader.GetInt32(90);
             
                string charModel = charList_Reader["charModel"].ToString();
                float heading = charList_Reader.GetFloat(92);
                bool firstSpawn = charList_Reader.GetBoolean(93);

                int hatID = charList_Reader.GetInt32(94);
                int hatColor = charList_Reader.GetInt32(95);
                int glassesID = charList_Reader.GetInt32(96);
                int glassesColor = charList_Reader.GetInt32(97);
                int earringID = charList_Reader.GetInt32(98);
                int earringColor = charList_Reader.GetInt32(99);
                int watchID = charList_Reader.GetInt32(100);
                int watchColor = charList_Reader.GetInt32(101);
                int braceletID = charList_Reader.GetInt32(102);
                int braceletColor = charList_Reader.GetInt32(103);

                string HeadTattoos = charList_Reader.GetString(104);
                string TorsoTattoos = charList_Reader.GetString(105);
                string LeftArmTattoos = charList_Reader.GetString(106);
                string RightArmTattoos = charList_Reader.GetString(107);
                string LeftLegTattoos = charList_Reader.GetString(108);
                string RightLegTattoos = charList_Reader.GetString(109);
                    //

                    Character charInfo = new Character
                    {
                        Id = id,
                        Forename = fName,
                        Middlename = mName,
                        Surname = lName,
                        DateOfBirth = DOB,
                        Gender = gender,
                        Alive = alive,
                        Health = health,
                        Armor = armor,
                        Ssn = SSN,
                        PosX = posX,
                        PosY = posY,
                        PosZ = posZ,
                        Model = model,
                        WalkingStyle = walkingStyle,
                        LastPlayed = lastPlayed,
                        cash = cash,
                        level = level,
                        playTime = playTime,
                        Created = created,
                        motherIndex = motherIndex,
                        fatherIndex = fatherIndex,
                        skinMixFloat = skinMixFloat,
                        shapeMixFloat = shapeMixFloat,
                        NoseWidth = NoseWidth,
                        NosePeak = NosePeak,
                        NosePeakLength = NosePeakLength,
                        NoseBoneHeight = NoseBoneHeight,
                        NosePeakLowering = NosePeakLowering,
                        NoseBoneTwist = NoseBoneTwist,
                        EyeBrowDepth = EyeBrowDepth,
                        EyeBrowHeight = EyeBrowHeight,
                        CheekBoneHeight = CheekBoneHeight,
                        CheekBoneWidth = CheekBoneWidth,
                        CheeksWidth = CheeksWidth,
                        EyesOpening = EyesOpening,
                        LipsThickness = LipsThickness,
                        JawBoneWidth = JawBoneWidth,
                        JawBoneDepth = JawBoneDepth,
                        ChinHeight = ChinHeight,
                        ChinDepth = ChinDepth,
                        ChinWidth = ChinWidth,
                        ChinHoleSize = ChinHoleSize,
                        NeckThickness = NeckThickness,
                        hairStyle = hairStyle,
                        hairStyleColor = hairStyleColor,
                        eyeBrowStyle = eyeBrowStyle,
                        eyeBrowColor = eyeBrowColor,
                        eyeBrowOpacity = eyeBrowOpacity,
                        beardStyle = beardStyle,
                        beardColor = beardColor,
                        beardOpacity = beardOpacity,
                        blemishesStyle = blemishesStyle,
                        blemishesOpacity = blemishesOpacity,
                        skinAgingStyle = skinAgingStyle,
                        skinAgingOpacity = skinAgingOpacity,
                        complexionStyle = complexionStyle,
                        complexionOpacity = complexionOpacity,
                        molesStyle = molesStyle,
                        molesOpacity = molesOpacity,
                        sunDamageStyle = sunDamageStyle,
                        sunDamageOpacity = sunDamageOpacity,
                        eyeColorStyle = eyeColorStyle,
                        makeupStyle = makeupStyle,
                        makeupColor = makeupColor,
                        makeupOpacity = makeupOpacity,
                        lipStickStyle = lipStickStyle,
                        lipStickColor = lipStickColor,
                        lipStickOpacity = lipStickOpacity,
                        chestHairStyle = chestHairStyle,
                        chestHairColor = chestHairColor,
                        chestHairOpacity = chestHairOpacity,
                        blushStyle = blushStyle,
                        blushColor = blushColor,
                        blushOpacity = blushOpacity,
                        maskStyle = maskStyle,
                        maskColor = maskColor,
                        armStyle = armStyle,
                        armColor = armColor,
                        pantStyle = pantStyle,
                        pantColor = pantColor,
                        shoeStyle = shoeStyle,
                        shoeColor = shoeColor,
                        chainStyle = chainStyle,
                        chainColor = chainColor,
                        tShirtStyle = tShirtStyle,
                        tShirtColor = tShirtColor,
                        bArmorStyle = bArmorStyle,
                        bArmorColor = bArmorColor,
                        torsoStyle = torsoStyle,
                        torsoColor = torsoColor,
                        charModel = charModel,
                        heading = heading,
                        firstSpawn = firstSpawn,
                        hatID = hatID,
                        hatColor = hatColor,
                        glassesID = glassesID,
                        glassesColor = glassesColor,
                        earringID = earringID,
                        earringColor = earringColor,
                        watchID = watchID,
                        watchColor = watchColor,
                        braceletID = braceletID,
                        braceletColor = braceletColor,
                        HeadTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(HeadTattoos),
                        TorsoTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(TorsoTattoos),
                        LeftArmTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(LeftArmTattoos),
                        RightArmTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(RightArmTattoos),
                        LeftLegTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(LeftLegTattoos),
                        RightLegTattoos = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(RightLegTattoos)
                    };

                charList.Add(charInfo);
            }



            await DB_Connection.DBConnection.CloseAsync();

            return charList;
        }

        public static async Task insert_character(Character charInfo)
        {
            string DateCreatedFormatted = (charInfo.Created).ToString("yyyy-MM-dd H:mm:ss");
            string LastPlayedFormatted = (charInfo.LastPlayed).ToString("yyyy-MM-dd H:mm:ss");
            string DOBFormatted = (charInfo.DateOfBirth).ToString("yyyy-MM-dd H:mm:ss");

            var HeadTattoos = JsonConvert.SerializeObject(charInfo.HeadTattoos);
            var TorsoTattoos = JsonConvert.SerializeObject(charInfo.TorsoTattoos);
            var LeftArmTattoos = JsonConvert.SerializeObject(charInfo.LeftArmTattoos);
            var RightArmTattoos = JsonConvert.SerializeObject(charInfo.RightArmTattoos);
            var LeftLegTattoos = JsonConvert.SerializeObject(charInfo.LeftLegTattoos);
            var RightLegTattoos = JsonConvert.SerializeObject(charInfo.RightLegTattoos);

            

            string insertQuery = string.Format("INSERT INTO characters (id, forename, middlename, surname, dateofbirth, gender, alive, health, armor, ssn, posx, posy, posz, " +
            "model, walkingstyle, lastplayed, cash, level, playtime, created, motherIndex, fatherIndex, skinMixFloat,shapeMixFloat, NoseWidth, NosePeak, NosePeakLength," +
            "NoseBoneHeight, NosePeakLowering, NoseBoneTwist, EyeBrowDepth, EyeBrowHeight, CheekBoneHeight, CheekBoneWidth, CheeksWidth, EyesOpening, LipsThickness, " +
            "JawBoneWidth, JawBoneDepth, ChinHeight, ChinDepth, ChinWidth, ChinHoleSize, NeckThickness, hairStyle, hairStyleColor, eyeBrowStyle, eyeBrowColor, eyeBrowOpacity," +
            "beardStyle, beardColor, beardOpacity, blemishesStyle, blemishesOpacity, skinAgingStyle, skinAgingOpacity, complexionStyle, complexionOpacity, molesStyle, molesOpacity," +
            "sunDamageStyle, sunDamageOpacity, eyeColorStyle, makeupStyle, makeupColor, makeupOpacity, lipStickStyle, lipStickColor, lipStickOpacity, chestHairStyle, chestHairColor," +
            "chestHairOpacity, blushStyle, blushColor, blushOpacity, maskStyle, maskColor, armStyle, armColor, pantStyle, pantColor, shoeStyle, shoeColor, chainStyle, chainColor," +
            "tShirtStyle, tShirtColor, bArmorStyle, bArmorColor, torsoStyle, torsoColor, charModel, heading, firstSpawn, hatID, hatColor, glassesID, glassesColor, earringID, earringColor," +
            "watchID, watchColor, braceletID, braceletColor, HeadTattoos, TorsoTattoos, LeftArmTattoos, RightArmTattoos, LeftLegTattoos, RightLegTattoos)" +
            "VALUES (@id, @forename, @middlename, @surname, @dateofbirth, @gender, @alive, @health, @armor, @ssn, @posx, @posy, @posz, @model, @walkingstyle, @lastplayed, @cash, @level," +
            "@playtime, @created, @motherIndex, @fatherIndex, @skinMixFloat, @shapeMixFloat, @NoseWidth, @NosePeak, @NosePeakLength, @NoseBoneHeight, @NosePeakLowering, @NoseBoneTwist," +
            "@EyeBrowDepth, @EyeBrowHeight, @CheekBoneHeight, @CheekBoneWidth, @CheeksWidth, @EyesOpening, @LipsThickness, @JawBoneWidth, @JawBoneDepth, @ChinHeight, @ChinDepth, @ChinWidth," +
            "@ChinHoleSize, @NeckThickness, @hairStyle, @hairStyleColor, @eyeBrowStyle, @eyeBrowColor, @eyeBrowOpacity, @beardStyle, @beardColor, @beardOpacity, @blemishesStyle, @blemishesOpacity," +
            "@skinAgingStyle, @skinAgingOpacity, @complexionStyle, @complexionOpacity, @molesStyle, @molesOpacity, @sunDamageStyle, @sunDamageOpacity, @eyeColorStyle, @makeupStyle, @makeupColor," +
            "@makeupOpacity, @lipStickStyle, @lipStickColor, @lipStickOpacity, @chestHairStyle, @chestHairColor, @chestHairOpacity, @blushStyle, @blushColor, @blushOpacity, @maskStyle," +
            "@maskColor, @armStyle, @armColor, @pantStyle, @pantColor, @shoeStyle, @shoeColor, @chainStyle, @chainColor, @tShirtStyle, @tShirtColor, @bArmorStyle, @bArmorColor, @torsoStyle," +
            "@torsoColor, @charModel, @heading, @firstSpawn, @hatID, @hatColor, @glassesID, @glassesColor, @earringID, @earringColor, @watchID, @watchColor, @braceletID, @braceletColor," +
            "@HeadTattoos, @TorsoTattoos, @LeftArmTattoos, @RightArmTattoos, @LeftLegTattoos, @RightLegTattoos)");

            MySqlCommand insertCommand = new MySqlCommand(insertQuery, DB_Connection.DBConnection); // insertion command
            insertCommand.Parameters.AddWithValue("@id", charInfo.Id);
            insertCommand.Parameters.AddWithValue("@forename", charInfo.Forename);
            insertCommand.Parameters.AddWithValue("@middlename", charInfo.Middlename);
            insertCommand.Parameters.AddWithValue("@surname", charInfo.Surname);
            insertCommand.Parameters.AddWithValue("@dateofbirth", DOBFormatted);
            insertCommand.Parameters.AddWithValue("@gender", charInfo.Gender);
            insertCommand.Parameters.AddWithValue("@alive", charInfo.Alive);
            insertCommand.Parameters.AddWithValue("@health", charInfo.Health);
            insertCommand.Parameters.AddWithValue("@armor", charInfo.Armor);
            insertCommand.Parameters.AddWithValue("@ssn", charInfo.Ssn);
            insertCommand.Parameters.AddWithValue("@posx", charInfo.PosX);
            insertCommand.Parameters.AddWithValue("@posy", charInfo.PosY);
            insertCommand.Parameters.AddWithValue("@posz", charInfo.PosZ);
            insertCommand.Parameters.AddWithValue("@model", charInfo.Model);
            insertCommand.Parameters.AddWithValue("@walkingstyle", charInfo.WalkingStyle);
            insertCommand.Parameters.AddWithValue("@lastplayed", LastPlayedFormatted);
            insertCommand.Parameters.AddWithValue("@cash", charInfo.cash);
            insertCommand.Parameters.AddWithValue("@level", charInfo.level);
            insertCommand.Parameters.AddWithValue("@playtime", charInfo.playTime);
            insertCommand.Parameters.AddWithValue("@created", DateCreatedFormatted);
            insertCommand.Parameters.AddWithValue("@motherIndex", charInfo.motherIndex);
            insertCommand.Parameters.AddWithValue("@fatherIndex", charInfo.fatherIndex);
            insertCommand.Parameters.AddWithValue("@skinMixFloat", charInfo.skinMixFloat);
            insertCommand.Parameters.AddWithValue("@shapeMixFloat", charInfo.shapeMixFloat);
            insertCommand.Parameters.AddWithValue("@NoseWidth", charInfo.NoseWidth);
            insertCommand.Parameters.AddWithValue("@NosePeak", charInfo.NosePeak);
            insertCommand.Parameters.AddWithValue("@NosePeakLength", charInfo.NosePeakLength);
            insertCommand.Parameters.AddWithValue("@NoseBoneHeight", charInfo.NoseBoneHeight);
            insertCommand.Parameters.AddWithValue("@NosePeakLowering", charInfo.NosePeakLowering);
            insertCommand.Parameters.AddWithValue("@NoseBoneTwist", charInfo.NoseBoneTwist);
            insertCommand.Parameters.AddWithValue("@EyeBrowDepth", charInfo.EyeBrowDepth);
            insertCommand.Parameters.AddWithValue("@EyeBrowHeight", charInfo.EyeBrowHeight);
            insertCommand.Parameters.AddWithValue("@CheekBoneHeight", charInfo.CheekBoneHeight);
            insertCommand.Parameters.AddWithValue("@CheekBoneWidth", charInfo.CheekBoneWidth);
            insertCommand.Parameters.AddWithValue("@CheeksWidth", charInfo.CheeksWidth);
            insertCommand.Parameters.AddWithValue("@EyesOpening", charInfo.EyesOpening);
            insertCommand.Parameters.AddWithValue("@LipsThickness", charInfo.LipsThickness);
            insertCommand.Parameters.AddWithValue("@JawBoneWidth", charInfo.JawBoneWidth);
            insertCommand.Parameters.AddWithValue("@JawBoneDepth", charInfo.JawBoneDepth);
            insertCommand.Parameters.AddWithValue("@ChinHeight", charInfo.ChinHeight);
            insertCommand.Parameters.AddWithValue("@ChinDepth", charInfo.ChinDepth);
            insertCommand.Parameters.AddWithValue("@ChinWidth", charInfo.ChinWidth);
            insertCommand.Parameters.AddWithValue("@ChinHoleSize", charInfo.ChinHoleSize);
            insertCommand.Parameters.AddWithValue("@NeckThickness", charInfo.NeckThickness);
            insertCommand.Parameters.AddWithValue("@hairStyle", charInfo.hairStyle);
            insertCommand.Parameters.AddWithValue("@hairStyleColor", charInfo.hairStyleColor);
            insertCommand.Parameters.AddWithValue("@eyeBrowStyle", charInfo.eyeBrowStyle);
            insertCommand.Parameters.AddWithValue("@eyeBrowColor", charInfo.eyeBrowColor);
            insertCommand.Parameters.AddWithValue("@eyeBrowOpacity", charInfo.eyeBrowOpacity);
            insertCommand.Parameters.AddWithValue("@beardStyle", charInfo.beardStyle);
            insertCommand.Parameters.AddWithValue("@beardColor", charInfo.beardColor);
            insertCommand.Parameters.AddWithValue("@beardOpacity", charInfo.beardOpacity);
            insertCommand.Parameters.AddWithValue("@blemishesStyle", charInfo.blemishesStyle);
            insertCommand.Parameters.AddWithValue("@blemishesOpacity", charInfo.blemishesOpacity);
            insertCommand.Parameters.AddWithValue("@skinAgingStyle", charInfo.skinAgingStyle);
            insertCommand.Parameters.AddWithValue("@skinAgingOpacity", charInfo.skinAgingOpacity);
            insertCommand.Parameters.AddWithValue("@complexionStyle", charInfo.complexionStyle);
            insertCommand.Parameters.AddWithValue("@complexionOpacity", charInfo.complexionOpacity);
            insertCommand.Parameters.AddWithValue("@molesStyle", charInfo.molesStyle);
            insertCommand.Parameters.AddWithValue("@molesOpacity", charInfo.molesOpacity);
            insertCommand.Parameters.AddWithValue("@sunDamageStyle", charInfo.sunDamageStyle);
            insertCommand.Parameters.AddWithValue("@sunDamageOpacity", charInfo.sunDamageOpacity);
            insertCommand.Parameters.AddWithValue("@eyeColorStyle", charInfo.eyeColorStyle);
            insertCommand.Parameters.AddWithValue("@makeupStyle", charInfo.makeupStyle);
            insertCommand.Parameters.AddWithValue("@makeupColor", charInfo.makeupColor);
            insertCommand.Parameters.AddWithValue("@makeupOpacity", charInfo.makeupOpacity);
            insertCommand.Parameters.AddWithValue("@lipStickStyle", charInfo.lipStickStyle);
            insertCommand.Parameters.AddWithValue("@lipStickColor", charInfo.lipStickColor);
            insertCommand.Parameters.AddWithValue("@lipStickOpacity", charInfo.lipStickOpacity);
            insertCommand.Parameters.AddWithValue("@chestHairStyle", charInfo.chestHairStyle);
            insertCommand.Parameters.AddWithValue("@chestHairColor", charInfo.chestHairColor);
            insertCommand.Parameters.AddWithValue("@chestHairOpacity", charInfo.chestHairOpacity);
            insertCommand.Parameters.AddWithValue("@blushStyle", charInfo.blushStyle);
            insertCommand.Parameters.AddWithValue("@blushColor", charInfo.blushColor);
            insertCommand.Parameters.AddWithValue("@blushOpacity", charInfo.blushOpacity);
            insertCommand.Parameters.AddWithValue("@maskStyle", charInfo.maskStyle);
            insertCommand.Parameters.AddWithValue("@maskColor", charInfo.maskColor);
            insertCommand.Parameters.AddWithValue("@armStyle", charInfo.armStyle);
            insertCommand.Parameters.AddWithValue("@armColor", charInfo.armColor);
            insertCommand.Parameters.AddWithValue("@pantStyle", charInfo.pantStyle);
            insertCommand.Parameters.AddWithValue("@pantColor", charInfo.pantColor);
            insertCommand.Parameters.AddWithValue("@shoeStyle", charInfo.shoeStyle);
            insertCommand.Parameters.AddWithValue("@shoeColor", charInfo.shoeColor);
            insertCommand.Parameters.AddWithValue("@chainStyle", charInfo.chainStyle);
            insertCommand.Parameters.AddWithValue("@chainColor", charInfo.chainColor);
            insertCommand.Parameters.AddWithValue("@tShirtStyle", charInfo.tShirtStyle);
            insertCommand.Parameters.AddWithValue("@tShirtColor", charInfo.tShirtColor);
            insertCommand.Parameters.AddWithValue("@bArmorStyle", charInfo.bArmorStyle);
            insertCommand.Parameters.AddWithValue("@bArmorColor", charInfo.bArmorColor);
            insertCommand.Parameters.AddWithValue("@torsoStyle", charInfo.torsoStyle);
            insertCommand.Parameters.AddWithValue("@torsoColor", charInfo.torsoColor);
            insertCommand.Parameters.AddWithValue("@charModel", charInfo.charModel);
            insertCommand.Parameters.AddWithValue("@heading", charInfo.heading);
            insertCommand.Parameters.AddWithValue("@firstSpawn", charInfo.firstSpawn);
            insertCommand.Parameters.AddWithValue("@hatID", charInfo.hatID);
            insertCommand.Parameters.AddWithValue("@hatColor", charInfo.hatColor);
            insertCommand.Parameters.AddWithValue("@glassesID", charInfo.glassesID);
            insertCommand.Parameters.AddWithValue("@glassesColor", charInfo.glassesColor);
            insertCommand.Parameters.AddWithValue("@earringID", charInfo.earringID);
            insertCommand.Parameters.AddWithValue("@earringColor", charInfo.earringColor);
            insertCommand.Parameters.AddWithValue("@watchID", charInfo.watchID);
            insertCommand.Parameters.AddWithValue("@watchColor", charInfo.watchColor);
            insertCommand.Parameters.AddWithValue("@braceletID", charInfo.braceletID);
            insertCommand.Parameters.AddWithValue("@braceletColor", charInfo.braceletColor);
            insertCommand.Parameters.AddWithValue("@HeadTattoos", HeadTattoos);
            insertCommand.Parameters.AddWithValue("@TorsoTattoos", TorsoTattoos);
            insertCommand.Parameters.AddWithValue("@LeftArmTattoos", LeftArmTattoos);
            insertCommand.Parameters.AddWithValue("@RightArmTattoos", RightArmTattoos);
            insertCommand.Parameters.AddWithValue("@LeftLegTattoos", LeftLegTattoos);
            insertCommand.Parameters.AddWithValue("@RightLegTattoos", RightLegTattoos);

            await DB_Connection.DBConnection.OpenAsync();
            await insertCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }


        public static async Task delete_character(Character charInfo)
        {
            string deleteQuery = string.Format("DELETE characters  WHERE ID={0}", charInfo.Id); // delete query string
            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, DB_Connection.DBConnection); // delete command

            await DB_Connection.DBConnection.OpenAsync();
            await deleteCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }

        public static async Task update_character_runtime_values(Character charInfo)
        {
            string updateQuery = "UPDATE characters SET posx=@posx, posy=@posy, posz=@posz, heading=@heading, health=@health, armor=@armor, lastplayed=@lastplayed WHERE id=@id";
            await DB_Connection.DBConnection.OpenAsync();

            charInfo.PosX = charInfo.Position.X;
            charInfo.PosY = charInfo.Position.Y;
            charInfo.PosZ = charInfo.Position.Z;
            string LastPlayedFormatted = (charInfo.LastPlayed).ToString("yyyy-MM-dd H:mm:ss");

            MySqlCommand updateCommand = new MySqlCommand(updateQuery, DB_Connection.DBConnection);
            updateCommand.Parameters.AddWithValue("@posx", charInfo.PosX);
            updateCommand.Parameters.AddWithValue("@posy", charInfo.PosY);
            updateCommand.Parameters.AddWithValue("@posz", charInfo.PosZ);
            updateCommand.Parameters.AddWithValue("@heading", charInfo.heading);
            updateCommand.Parameters.AddWithValue("@health", charInfo.Health);
            updateCommand.Parameters.AddWithValue("@armor", charInfo.Armor);
            updateCommand.Parameters.AddWithValue("@id", charInfo.Id);
            updateCommand.Parameters.AddWithValue("@lastplayed", LastPlayedFormatted);

            await updateCommand.ExecuteNonQueryAsync();
            await DB_Connection.DBConnection.CloseAsync();
        }
    }
}
