using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using ScaleformUI;
using Client.Controllers;
using static CitizenFX.Core.Native.API;
using Client.Models.Objects;
using System.Linq;

namespace Client.Models.Menus
{
    public class charFactory : BaseScript
    {

        public static UIMenu cHeritageMenu;

        public static UIMenu cFaceShapeMenu;

        public static UIMenu cFaceApperanceMenu;

        public static UIMenu cClothesMenu;

        public static UIMenu cPropsMenu;

        public static UIMenu cTattoosMenu;

        private static bool inCreation { get; set; }
        private static bool inHeritage { get; set; }
        private static bool inFaceShape { get; set; }
        private static bool inFaceApperance { get; set; }
        private static bool inClothes { get; set; }
        private static bool inProps { get; set; }
        private static bool inTattoos { get; set; }



        private readonly List<string> textureNames = new List<string>()
        {
            "Head",
            "Masks & Headgear",
            "Hair Style / Color",
            "Hands / Upperbody",
            "Pants & Shorts",
            "Bags & Parachutes",
            "Shoes",
            "Acessories",
            "Undershirt",
            "Body Armor",
            "Badges / Logos",
            "Shirt Overlay & Jackets",
        };

        private readonly List<string> propNames = new List<string>()
        {
            "Hats & Helmets",
            "Glasses",
            "Earrings",
            "Watches",
            "Bracelets"
        };

        private static List<dynamic> maleHairStyles = new List<dynamic>()
        {
            GetLabelText("CC_M_HS_0"),
            GetLabelText("CC_M_HS_1"),
            GetLabelText("CC_M_HS_2"),
            GetLabelText("CC_M_HS_3"),
            GetLabelText("CC_M_HS_4"),
            GetLabelText("CC_M_HS_5"),
            GetLabelText("CC_M_HS_6"),
            GetLabelText("CC_M_HS_7"),
            GetLabelText("CC_M_HS_8"),
            GetLabelText("CC_M_HS_9"),
            GetLabelText("CC_M_HS_10"),
            GetLabelText("CC_M_HS_11"),
            GetLabelText("CC_M_HS_12"),
            GetLabelText("CC_M_HS_13"),
            GetLabelText("CC_M_HS_14"),
            GetLabelText("CC_M_HS_15"),
            GetLabelText("CC_M_HS_16"),
            GetLabelText("CC_M_HS_17"),
            GetLabelText("CC_M_HS_18"),
            GetLabelText("CC_M_HS_19"),
            GetLabelText("CC_M_HS_20"),
            GetLabelText("CC_M_HS_21"),
            GetLabelText("CC_M_HS_22")
        };
        private static List<dynamic> femaleHairStyles = new List<dynamic>()
        {
            GetLabelText("CC_F_HS_0"),
            GetLabelText("CC_F_HS_1"),
            GetLabelText("CC_F_HS_2"),
            GetLabelText("CC_F_HS_3"),
            GetLabelText("CC_F_HS_4"),
            GetLabelText("CC_F_HS_5"),
            GetLabelText("CC_F_HS_6"),
            GetLabelText("CC_F_HS_7"),
            GetLabelText("CC_F_HS_8"),
            GetLabelText("CC_F_HS_9"),
            GetLabelText("CC_F_HS_10"),
            GetLabelText("CC_F_HS_11"),
            GetLabelText("CC_F_HS_12"),
            GetLabelText("CC_F_HS_13"),
            GetLabelText("CC_F_HS_14"),
            GetLabelText("CC_F_HS_15"),
            GetLabelText("CC_F_HS_16"),
            GetLabelText("CC_F_HS_17"),
            GetLabelText("CC_F_HS_18"),
            GetLabelText("CC_F_HS_19"),
            GetLabelText("CC_F_HS_20"),
            GetLabelText("CC_F_HS_21"),
            GetLabelText("CC_F_HS_22"),
            GetLabelText("CC_F_HS_23")
        };
        private static List<dynamic> beardStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_BEARD_0"),
            GetLabelText("CC_BEARD_1"),
            GetLabelText("CC_BEARD_2"),
            GetLabelText("CC_BEARD_3"),
            GetLabelText("CC_BEARD_4"),
            GetLabelText("CC_BEARD_5"),
            GetLabelText("CC_BEARD_6"),
            GetLabelText("CC_BEARD_7"),
            GetLabelText("CC_BEARD_8"),
            GetLabelText("CC_BEARD_9"),
            GetLabelText("CC_BEARD_10"),
            GetLabelText("CC_BEARD_11"),
            GetLabelText("CC_BEARD_12"),
            GetLabelText("CC_BEARD_13"),
            GetLabelText("CC_BEARD_14"),
            GetLabelText("CC_BEARD_15"),
            GetLabelText("CC_BEARD_16"),
            GetLabelText("CC_BEARD_17"),
            GetLabelText("CC_BEARD_18"),
            GetLabelText("CC_BEARD_19"),
            GetLabelText("CC_BEARD_20"),
            GetLabelText("CC_BEARD_21"),
            GetLabelText("CC_BEARD_22"),
            GetLabelText("CC_BEARD_23"),
            GetLabelText("CC_BEARD_24"),
            GetLabelText("CC_BEARD_25"),
            GetLabelText("CC_BEARD_26"),
            GetLabelText("CC_BEARD_27"),
            GetLabelText("CC_BEARD_28")
        };
        private static List<dynamic> eyebrowStyles = new List<dynamic>()
        {
            GetLabelText("CC_EYEBRW_0"),
            GetLabelText("CC_EYEBRW_1"),
            GetLabelText("CC_EYEBRW_2"),
            GetLabelText("CC_EYEBRW_3"),
            GetLabelText("CC_EYEBRW_4"),
            GetLabelText("CC_EYEBRW_5"),
            GetLabelText("CC_EYEBRW_6"),
            GetLabelText("CC_EYEBRW_7"),
            GetLabelText("CC_EYEBRW_8"),
            GetLabelText("CC_EYEBRW_9"),
            GetLabelText("CC_EYEBRW_10"),
            GetLabelText("CC_EYEBRW_11"),
            GetLabelText("CC_EYEBRW_12"),
            GetLabelText("CC_EYEBRW_13"),
            GetLabelText("CC_EYEBRW_14"),
            GetLabelText("CC_EYEBRW_15"),
            GetLabelText("CC_EYEBRW_16"),
            GetLabelText("CC_EYEBRW_17"),
            GetLabelText("CC_EYEBRW_18"),
            GetLabelText("CC_EYEBRW_19"),
            GetLabelText("CC_EYEBRW_20"),
            GetLabelText("CC_EYEBRW_21"),
            GetLabelText("CC_EYEBRW_22"),
            GetLabelText("CC_EYEBRW_23"),
            GetLabelText("CC_EYEBRW_24"),
            GetLabelText("CC_EYEBRW_25"),
            GetLabelText("CC_EYEBRW_26"),
            GetLabelText("CC_EYEBRW_27"),
            GetLabelText("CC_EYEBRW_28"),
            GetLabelText("CC_EYEBRW_29"),
            GetLabelText("CC_EYEBRW_30"),
            GetLabelText("CC_EYEBRW_31"),
            GetLabelText("CC_EYEBRW_32"),
            GetLabelText("CC_EYEBRW_33")
        };
        private static List<dynamic> blemishesStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_SKINBLEM_0"),
            GetLabelText("CC_SKINBLEM_1"),
            GetLabelText("CC_SKINBLEM_2"),
            GetLabelText("CC_SKINBLEM_3"),
            GetLabelText("CC_SKINBLEM_4"),
            GetLabelText("CC_SKINBLEM_5"),
            GetLabelText("CC_SKINBLEM_6"),
            GetLabelText("CC_SKINBLEM_7"),
            GetLabelText("CC_SKINBLEM_8"),
            GetLabelText("CC_SKINBLEM_9"),
            GetLabelText("CC_SKINBLEM_10"),
            GetLabelText("CC_SKINBLEM_11"),
            GetLabelText("CC_SKINBLEM_11"),
            GetLabelText("CC_SKINBLEM_13"),
            GetLabelText("CC_SKINBLEM_14"),
            GetLabelText("CC_SKINBLEM_15"),
            GetLabelText("CC_SKINBLEM_16"),
            GetLabelText("CC_SKINBLEM_17"),
            GetLabelText("CC_SKINBLEM_18"),
            GetLabelText("CC_SKINBLEM_19"),
            GetLabelText("CC_SKINBLEM_20"),
            GetLabelText("CC_SKINBLEM_21"),
            GetLabelText("CC_SKINBLEM_22"),
            GetLabelText("CC_SKINBLEM_23")
        };
        private static List<dynamic> agingStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_SKINAGE_0"),
            GetLabelText("CC_SKINAGE_2"),
            GetLabelText("CC_SKINAGE_3"),
            GetLabelText("CC_SKINAGE_4"),
            GetLabelText("CC_SKINAGE_5"),
            GetLabelText("CC_SKINAGE_6"),
            GetLabelText("CC_SKINAGE_7"),
            GetLabelText("CC_SKINAGE_8"),
            GetLabelText("CC_SKINAGE_9"),
            GetLabelText("CC_SKINAGE_10"),
            GetLabelText("CC_SKINAGE_11"),
            GetLabelText("CC_SKINAGE_12"),
            GetLabelText("CC_SKINAGE_13"),
            GetLabelText("CC_SKINAGE_14")
        };
        private static List<dynamic> complexionStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_SKINCOM_0"),
            GetLabelText("CC_SKINCOM_1"),
            GetLabelText("CC_SKINCOM_2"),
            GetLabelText("CC_SKINCOM_3"),
            GetLabelText("CC_SKINCOM_4"),
            GetLabelText("CC_SKINCOM_5"),
            GetLabelText("CC_SKINCOM_6"),
            GetLabelText("CC_SKINCOM_7"),
            GetLabelText("CC_SKINCOM_8"),
            GetLabelText("CC_SKINCOM_9"),
            GetLabelText("CC_SKINCOM_10"),
            GetLabelText("CC_SKINCOM_11")
        };
        private static List<dynamic> molesStyle = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_MOLEFRECK_0"),
            GetLabelText("CC_MOLEFRECK_1"),
            GetLabelText("CC_MOLEFRECK_2"),
            GetLabelText("CC_MOLEFRECK_3"),
            GetLabelText("CC_MOLEFRECK_4"),
            GetLabelText("CC_MOLEFRECK_5"),
            GetLabelText("CC_MOLEFRECK_6"),
            GetLabelText("CC_MOLEFRECK_7"),
            GetLabelText("CC_MOLEFRECK_8"),
            GetLabelText("CC_MOLEFRECK_9"),
            GetLabelText("CC_MOLEFRECK_10"),
            GetLabelText("CC_MOLEFRECK_11"),
            GetLabelText("CC_MOLEFRECK_12"),
            GetLabelText("CC_MOLEFRECK_13"),
            GetLabelText("CC_MOLEFRECK_14"),
            GetLabelText("CC_MOLEFRECK_15"),
            GetLabelText("CC_MOLEFRECK_16"),
            GetLabelText("CC_MOLEFRECK_17")
        };
        private static List<dynamic> skinDamageStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_SUND_0"),
            GetLabelText("CC_SUND_1"),
            GetLabelText("CC_SUND_2"),
            GetLabelText("CC_SUND_3"),
            GetLabelText("CC_SUND_4"),
            GetLabelText("CC_SUND_5"),
            GetLabelText("CC_SUND_6"),
            GetLabelText("CC_SUND_7"),
            GetLabelText("CC_SUND_8"),
            GetLabelText("CC_SUND_9"),
            GetLabelText("CC_SUND_10")
        };
        private static List<dynamic> eyeColorStyles = new List<dynamic>()
        {
            GetLabelText("FACE_E_C_0"),
            GetLabelText("FACE_E_C_1"),
            GetLabelText("FACE_E_C_2"),
            GetLabelText("FACE_E_C_3"),
            GetLabelText("FACE_E_C_4"),
            GetLabelText("FACE_E_C_5"),
            GetLabelText("FACE_E_C_6"),
            GetLabelText("FACE_E_C_7"),
            GetLabelText("FACE_E_C_8")
        };
        private static List<dynamic> eyeMakeupStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_MKUP_0"),
            GetLabelText("CC_MKUP_1"),
            GetLabelText("CC_MKUP_2"),
            GetLabelText("CC_MKUP_3"),
            GetLabelText("CC_MKUP_4"),
            GetLabelText("CC_MKUP_5"),
            GetLabelText("CC_MKUP_6"),
            GetLabelText("CC_MKUP_7"),
            GetLabelText("CC_MKUP_8"),
            GetLabelText("CC_MKUP_9"),
            GetLabelText("CC_MKUP_10"),
            GetLabelText("CC_MKUP_11"),
            GetLabelText("CC_MKUP_12"),
            GetLabelText("CC_MKUP_13"),
            GetLabelText("CC_MKUP_14"),
            GetLabelText("CC_MKUP_15"),
            GetLabelText("CC_MKUP_32"),
            GetLabelText("CC_MKUP_34"),
            GetLabelText("CC_MKUP_35"),
            GetLabelText("CC_MKUP_36"),
            GetLabelText("CC_MKUP_37"),
            GetLabelText("CC_MKUP_38"),
            GetLabelText("CC_MKUP_39"),
            GetLabelText("CC_MKUP_40"),
            GetLabelText("CC_MKUP_41")
        };
        private static List<dynamic> blushStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_BLUSH_0"),
            GetLabelText("CC_BLUSH_1"),
            GetLabelText("CC_BLUSH_2"),
            GetLabelText("CC_BLUSH_3"),
            GetLabelText("CC_BLUSH_4"),
            GetLabelText("CC_BLUSH_5"),
            GetLabelText("CC_BLUSH_6")
        };
        private static List<dynamic> lipStickStyles = new List<dynamic>()
        {
            GetLabelText("FACE_F_P_OFF"),
            GetLabelText("CC_LIPSTICK_0"),
            GetLabelText("CC_LIPSTICK_1"),
            GetLabelText("CC_LIPSTICK_2"),
            GetLabelText("CC_LIPSTICK_3"),
            GetLabelText("CC_LIPSTICK_4"),
            GetLabelText("CC_LIPSTICK_5"),
            GetLabelText("CC_LIPSTICK_6"),
            GetLabelText("CC_LIPSTICK_7"),
            GetLabelText("CC_LIPSTICK_8"),
            GetLabelText("CC_LIPSTICK_9")
        };

        private static readonly List<dynamic> motherFacePictures = new List<dynamic>() { "Hannah", "Audrey", "Jasmine", "Giselle", "Amelia", "Isabella", "Zoe", "Ava", "Camilla", "Violet", "Sophia", "Eveline", "Nicole", "Ashley", "Grace", "Brianna", "Natalie", "Olivia", "Elizabeth", "Charlotte", "Emma", "Misty" };
        private static readonly List<dynamic> fatherFacePictures = new List<dynamic>() { "Benjamin", "Daniel", "Joshua", "Noah", "Andrew", "Joan", "Alex", "Isaac", "Evan", "Ethan", "Vincent", "Angel", "Diego", "Adrian", "Gabriel", "Michael", "Santiago", "Kevin", "Louis", "Samuel", "Anthony", "Claude", "Niko", "John" };

        public static float Denormalize(float normalized, float min, float max)
        {
            return (normalized * (max - min) + min);
        }


        private static void updatePlayerChar(int overlayID, int index, float opacity)
        {
            var pHandle = GetPlayerPed(-1);
            SetPedHeadOverlay(pHandle, overlayID, index, opacity);
        }

        private static void updatePlayerChar(Player.Character pChar, int overlayID, float opacity)
        {
            var pHandle = GetPlayerPed(-1);
            if (overlayID == 0)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.blemishesStyle, opacity);
            }
            if (overlayID == 1)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.beardStyle, opacity);
            }
            if (overlayID == 2)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.eyeBrowStyle, opacity);
            }
            if (overlayID == 3)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.skinAgingStyle, opacity);
            }
            if (overlayID == 4)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.makeupStyle, opacity);
            }
            if (overlayID == 6)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.complexionStyle, opacity);
            }
            if (overlayID == 7)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.sunDamageStyle, opacity);
            }
            if (overlayID == 8)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.lipStickStyle, opacity);
            }
            if (overlayID == 9)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.molesStyle, opacity);
            }
        }

        private static void updatePlayerChar(Player.Character pChar, int overlayID, int colorType, int colorID, int secondColorID)
        {
            var pHandle = GetPlayerPed(-1);
            if (overlayID == 1)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.beardStyle, pChar.beardOpacity);
                SetPedHeadOverlayColor(pHandle, overlayID, colorType, colorID, 0);
            }
            if (overlayID == 2)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.eyeBrowStyle, pChar.eyeBrowOpacity);
                SetPedHeadOverlayColor(pHandle, overlayID, colorType, colorID, 0);
            }
            if (overlayID == 4)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.makeupStyle, pChar.makeupOpacity);
                SetPedHeadOverlayColor(pHandle, overlayID, colorType, colorID, 0);
            }
            if (overlayID == 8)
            {
                SetPedHeadOverlay(pHandle, overlayID, pChar.lipStickStyle, pChar.lipStickOpacity);
                SetPedHeadOverlayColor(pHandle, overlayID, colorType, colorID, 0);
            }
        }



        public void charHeritageMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cHeritageMenu = new UIMenu("Heritage Mixture", "Character's family heritage", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"),  false);
            MenuController.AddMenu(cHeritageMenu);


            cHeritageMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cHeritageMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cHeritageMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cHeritageMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));


            var cHeritageWindow = new UIMenuHeritageWindow(0, 0);
            cHeritageMenu.AddWindow(cHeritageWindow);

            List<dynamic> parentsPictures = new List<dynamic>();
            for (int i = 0; i < 101; i++) parentsPictures.Add(i);

            cHeritageMenu.EnableAnimation = true;
            cHeritageMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;
            
            
            

            var motherItem = new UIMenuListItem("Mother", motherFacePictures, 0);
            var fatherItem = new UIMenuListItem("Father", fatherFacePictures, 0);

            var cResemblanceSlider = new UIMenuSliderItem("Resemblance", "Parent resemblance strength", true);
            var cSkinToneSlider = new UIMenuSliderItem("Skin Tone", "Skin tone", true);

            cHeritageMenu.AddItem(motherItem);
            cHeritageMenu.AddItem(fatherItem);
            cHeritageMenu.AddItem(cResemblanceSlider);
            cHeritageMenu.AddItem(cSkinToneSlider);

            int motherIndex = 0;
            int fatherIndex = 0;

            float skinMixFloat = 0.5F;
            float ShapeMixFloat = 0.5F;


            cHeritageMenu.OnListChange +=  (_sender, _listItem, _newIndex) =>
            {
                if (_listItem == motherItem) // Mother Heritage
                {
                    motherIndex = _newIndex;
                    cHeritageWindow.Index(motherIndex, fatherIndex);
                    SetPedHeadBlendData(GetPlayerPed(-1), motherIndex, fatherIndex, 0, motherIndex, fatherIndex, 0, ShapeMixFloat, skinMixFloat, 0, true);
                    pChar.motherIndex = motherIndex;
                }
                else if (_listItem == fatherItem) // Father Heritage
                {
                    fatherIndex = _newIndex;
                    cHeritageWindow.Index(motherIndex, fatherIndex);
                    SetPedHeadBlendData(GetPlayerPed(-1), motherIndex, fatherIndex, 0, motherIndex, fatherIndex, 0, ShapeMixFloat, skinMixFloat, 0, true);
                    pChar.fatherIndex = fatherIndex;
                }
            };

            cHeritageMenu.OnSliderChange += (_sender, _listItem, _newIndex) =>
            {
                if(_listItem == cResemblanceSlider) // Shape Mix float
                {
                    ShapeMixFloat = _newIndex / 100.0F;
                    SetPedHeadBlendData(GetPlayerPed(-1), motherIndex, fatherIndex, 0, motherIndex, fatherIndex, 0, ShapeMixFloat, skinMixFloat, 0, true);
                    pChar.shapeMixFloat = ShapeMixFloat;
                }
                if(_listItem == cSkinToneSlider) // Skin Tone mix float
                {
                    skinMixFloat = _newIndex / 100.0F;
                    SetPedHeadBlendData(GetPlayerPed(-1), motherIndex, fatherIndex, 0, motherIndex, fatherIndex, 0, ShapeMixFloat, skinMixFloat, 0, true);
                    pChar.skinMixFloat = skinMixFloat;
                }
            };

            var charHeritageMenuConfirm = new UIMenuItem("Next", "Go to the ~r~facial shape~s~ menu.");

            cHeritageMenu.AddItem(charHeritageMenuConfirm);

            cHeritageMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == charHeritageMenuConfirm)
                {
                    MenuController.CloseAllMenus();
                    charFaceShapeMenu(pChar);
                    inHeritage = false;
                }
            };

            cHeritageMenu.Visible = true;
            inCreation = true;
            inHeritage = true;
        }
        

        public void charFaceShapeMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cFaceApperanceMenu = new UIMenu("Face Shape", "Character's facial shape.", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"), false);
            MenuController.AddMenu(cFaceApperanceMenu);

            cFaceApperanceMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cFaceApperanceMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cFaceApperanceMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cFaceApperanceMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));

            cFaceApperanceMenu.EnableAnimation = true;
            cFaceApperanceMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;


            var GridNoseItem = new UIMenuListItem("Nose", new List<object> { string.Empty }, 1); // Nose
            var GridNosePanel = new UIMenuGridPanel("Up", "Narrow", "Wide", "Down", new PointF(150, 150));

            var GridNoseProfileItem = new UIMenuListItem("Nose Profile", new List<object> { string.Empty }, 1); // Nose Profile
            var GridNoseProfilePanel = new UIMenuGridPanel("Up", "Narrow", "Wide", "Down", new PointF(150, 150));

            var GridNoseTipItem = new UIMenuListItem("Nose Tip", new List<object> { string.Empty }, 1); // Nose Tip
            var GridNoseTipPanel = new UIMenuGridPanel("Up", "Narrow", "Wide", "Down", new PointF(150, 150));

            var GridEyeBrowsItem = new UIMenuListItem("Eye Brows", new List<object> { string.Empty }, 1); // Eye Brows
            var GridEyeBrowsPanel = new UIMenuGridPanel("Up", "Narrow", "Wide", "Down", new PointF(150, 150));

            var GridCheekBonesItem = new UIMenuListItem("Cheek Bones", new List<object> { string.Empty }, 1); // Cheek Bones
            var GridCheekBonesPanel = new UIMenuGridPanel("Up", "Narrow", "Wide", "Down", new PointF(150, 150));

            var GridCheeksItem = new UIMenuListItem("Cheeks", new List<object> { string.Empty }, 1); // Cheeks
            var GridCheeksPanel = new UIMenuGridPanel("Gaunt", "Puffed", new PointF(150, 150));

            var GridEyesItem = new UIMenuListItem("Eyes", new List<object> { string.Empty }, 1); // Eyes
            var GridEyesPanel = new UIMenuGridPanel("Squint", "Wide", new PointF(150, 150));

            var GridLipsItem = new UIMenuListItem("Lips", new List<object> { string.Empty }, 1); // Lips 
            var GridLipsPanel = new UIMenuGridPanel("Thin", "Fat", new PointF(150, 150));

            var GridJawBoneItem = new UIMenuListItem("Jaw", new List<object> { string.Empty }, 1); // Jaw Bone
            var GridJawBonePanel = new UIMenuGridPanel("Round", "Narrow", "Wide", "Square", new PointF(150, 150));

            var GridChinItem = new UIMenuListItem("Chin", new List<object> { string.Empty }, 1); // Chin
            var GridChinPanel = new UIMenuGridPanel("Up", "In", "Out", "Down", new PointF(150, 150));

            var GridChinShapeItem = new UIMenuListItem("Chin Shape", new List<object> { string.Empty }, 1); // Chin Shape
            var GridChinShapePanel = new UIMenuGridPanel("Rounded", "Square", "Pointed", "Bum", new PointF(150, 150));

            var GridNeckThicknessItem = new UIMenuListItem("Neck Thickness", new List<object> { string.Empty }, 1); // Neck Thickness
            var GridNeckThicknessPanel = new UIMenuGridPanel("Thin", "Fat", new PointF(150, 150));

            var charFaceShapeMenuConfirm = new UIMenuItem("Next", "Go to the ~r~facial apperance~s~ menu."); // Finish
            var charFaceShapeMenuBack = new UIMenuItem("Back", "Go back to the ~r~heritage~ menu."); // Back


            cFaceApperanceMenu.AddItem(GridNoseItem);
            GridNoseItem.AddPanel(GridNosePanel);
            

            cFaceApperanceMenu.AddItem(GridNoseProfileItem);
            GridNoseProfileItem.AddPanel(GridNoseProfilePanel);

            cFaceApperanceMenu.AddItem(GridNoseTipItem);
            GridNoseTipItem.AddPanel(GridNoseTipPanel);

            cFaceApperanceMenu.AddItem(GridEyeBrowsItem);
            GridEyeBrowsItem.AddPanel(GridEyeBrowsPanel);

            cFaceApperanceMenu.AddItem(GridCheekBonesItem);
            GridCheekBonesItem.AddPanel(GridCheekBonesPanel);

            cFaceApperanceMenu.AddItem(GridCheeksItem);
            GridCheeksItem.AddPanel(GridCheeksPanel);

            cFaceApperanceMenu.AddItem(GridEyesItem);
            GridEyesItem.AddPanel(GridEyesPanel);

            cFaceApperanceMenu.AddItem(GridLipsItem);
            GridLipsItem.AddPanel(GridLipsPanel);
            GridLipsPanel.GridType = GridType.Horizontal;

            cFaceApperanceMenu.AddItem(GridJawBoneItem);
            GridJawBoneItem.AddPanel(GridJawBonePanel);

            cFaceApperanceMenu.AddItem(GridChinItem);
            GridChinItem.AddPanel(GridChinPanel);

            cFaceApperanceMenu.AddItem(GridChinShapeItem);
            GridChinShapeItem.AddPanel(GridChinShapePanel);

            cFaceApperanceMenu.AddItem(GridNeckThicknessItem);
            GridNeckThicknessItem.AddPanel(GridNeckThicknessPanel);

            cFaceApperanceMenu.AddItem(charFaceShapeMenuBack);
            cFaceApperanceMenu.AddItem(charFaceShapeMenuConfirm);


            try
            {

                cFaceApperanceMenu.OnGridPanelChange += (item, panel, value) =>
                {
                    if (panel == GridNosePanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 0, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 1, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.NoseWidth = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.NosePeak = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridNoseProfilePanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 2, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 3, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.NosePeakLength = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.NoseBoneHeight = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridNoseTipPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 4, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 5, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.NosePeakLowering = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.NoseBoneTwist = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridEyeBrowsPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 7, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 6, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.EyeBrowHeight = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.EyeBrowDepth = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridCheekBonesPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 8, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 9, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        pChar.CheekBoneHeight = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                        pChar.CheekBoneWidth = Denormalize(panel.CirclePosition.X, -1f, 1f);
                    }
                    if (panel == GridCheeksPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 10, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        pChar.CheeksWidth = Denormalize(panel.CirclePosition.X, -1f, 1f);
                    }
                    if (panel == GridEyesPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 11, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        pChar.EyesOpening = Denormalize(panel.CirclePosition.X, -1f, 1f);
                    }
                    if (panel == GridLipsPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 12, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        pChar.LipsThickness = Denormalize(panel.CirclePosition.X, -1f, 1f);
                    }
                    if (panel == GridJawBonePanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 13, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 14, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.JawBoneWidth = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.JawBoneDepth = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridChinPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 15, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 16, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.ChinHeight = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.ChinDepth = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridChinShapePanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 17, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        SetPedFaceFeature(GetPlayerPed(-1), 18, Denormalize(panel.CirclePosition.Y, -1f, 1f));
                        pChar.ChinWidth = Denormalize(panel.CirclePosition.X, -1f, 1f);
                        pChar.ChinHoleSize = Denormalize(panel.CirclePosition.Y, -1f, 1f);
                    }
                    if (panel == GridNeckThicknessPanel)
                    {
                        SetPedFaceFeature(GetPlayerPed(-1), 19, Denormalize(panel.CirclePosition.X, -1f, 1f));
                        pChar.NeckThickness = Denormalize(panel.CirclePosition.X, -1f, 1f);
                    }
                };

                cFaceApperanceMenu.OnItemSelect += (sender, item, index) =>
                {
                    if (item == charFaceShapeMenuConfirm)
                    {
                        MenuController.CloseAllMenus();
                        charFaceApperanceMenu(pChar);
                        inFaceShape = false;
                    }
                    if (item == charFaceShapeMenuBack)
                    {
                        MenuController.CloseAllMenus();
                        charHeritageMenu(pChar);
                        inFaceShape = false;
                    }
                };

            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine($"[EXCPETION CAUGHT] {e}");
            }

            cFaceApperanceMenu.Visible = true;
            inFaceShape = true;
        }

            
        public void charFaceApperanceMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cFaceShapeMenu = new UIMenu("Facial Apperance", "Character's facial features.", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"), false);
            MenuController.AddMenu(cFaceShapeMenu);

            cFaceShapeMenu.EnableAnimation = true;
            cFaceShapeMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;

            cFaceShapeMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cFaceShapeMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cFaceShapeMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cFaceShapeMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));

            // Hair

            var charHairStyleItem = new UIMenuListItem("Haircut", maleHairStyles, pChar.hairStyle); // Hairstyle
            var charHairStyleColorPanel = new UIMenuColorPanel("Color", ColorPanelType.Hair);

            cFaceShapeMenu.AddItem(charHairStyleItem);
            charHairStyleItem.AddPanel(charHairStyleColorPanel);
            charHairStyleColorPanel.SetParentItem(charHairStyleItem);

            // Skin Blemishes [0]

            var charBlemishesStyleItem = new UIMenuListItem("Skin Blemishes", blemishesStyles, pChar.blemishesStyle); // Blemishes
            var charBlemishesStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);
            cFaceShapeMenu.AddItem(charBlemishesStyleItem);
            charBlemishesStyleItem.AddPanel(charBlemishesStylePercentPanel);

            // Facial Hair [1]

            var charBeardStyleItem = new UIMenuListItem("Beard", beardStyles, pChar.beardStyle); // Beard
            var charBeardStyleColorPanel = new UIMenuColorPanel("Color", ColorPanelType.Hair);
            var charBeardStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charBeardStyleItem);
            charBeardStyleItem.AddPanel(charBeardStyleColorPanel);
            charBeardStyleItem.AddPanel(charBeardStylePercentPanel);
            charBeardStyleColorPanel.SetParentItem(charBeardStyleItem);
            charBeardStylePercentPanel.SetParentItem(charBeardStyleItem);

            // Eyebrows [2]

            var charEyeBrowsStyleItem = new UIMenuListItem("Eye Brows", eyebrowStyles, pChar.eyeBrowStyle); // Eyebrows
            var charEyeBrowsStyleColorPanel = new UIMenuColorPanel("Color", ColorPanelType.Hair);
            var charEyeBrowsStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charEyeBrowsStyleItem);
            charEyeBrowsStyleItem.AddPanel(charEyeBrowsStyleColorPanel);
            charEyeBrowsStyleItem.AddPanel(charEyeBrowsStylePercentPanel);
            charEyeBrowsStyleColorPanel.SetParentItem(charEyeBrowsStyleItem);
            charEyeBrowsStylePercentPanel.SetParentItem(charEyeBrowsStyleItem);

            // Skin Aging [3]

            var charSkinAgeStyleItem = new UIMenuListItem("Skin Aging", agingStyles, pChar.skinAgingStyle); // Skin Aging
            var charSkinAgingStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charSkinAgeStyleItem);
            charSkinAgeStyleItem.AddPanel(charSkinAgingStylePercentPanel);
            charSkinAgingStylePercentPanel.SetParentItem(charSkinAgeStyleItem);

            // Makeup [4]

            var charMakeupStyleItem = new UIMenuListItem("Makeup", eyeMakeupStyles, pChar.makeupStyle); // Makeup
            var charMakeupStyleColorPanel = new UIMenuColorPanel("Color", ColorPanelType.Makeup);
            var charMakeupStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charMakeupStyleItem);
            charMakeupStyleItem.AddPanel(charMakeupStyleColorPanel);
            charMakeupStyleItem.AddPanel(charMakeupStylePercentPanel);
            charMakeupStyleColorPanel.SetParentItem(charMakeupStyleItem);
            charMakeupStylePercentPanel.SetParentItem(charMakeupStyleItem);

            // Complexion [6]

            var charComplexionStylesItem = new UIMenuListItem("Skin Complexion", complexionStyles, pChar.complexionStyle); // Skin Complexion
            var charComplexionStylesPercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);
            

            cFaceShapeMenu.AddItem(charComplexionStylesItem);
            charComplexionStylesItem.AddPanel(charComplexionStylesPercentPanel);
            charComplexionStylesPercentPanel.SetParentItem(charComplexionStylesItem);

            // Sun Damage [7]

            var charSunDamageStyleItem = new UIMenuListItem("Skin Damage", skinDamageStyles, pChar.sunDamageStyle); // Sun Damage
            var charSunDamageStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charSunDamageStyleItem);
            charSunDamageStyleItem.AddPanel(charSunDamageStylePercentPanel);
            charSunDamageStylePercentPanel.SetParentItem(charSunDamageStyleItem);

            // Lipstick [8]


            var charLipStickStyleItem = new UIMenuListItem("Lipstick", lipStickStyles, pChar.lipStickStyle); // Lipstick
            var charLipStickStyleColorPanel = new UIMenuColorPanel("Color", ColorPanelType.Makeup);
            var charLipStickStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charLipStickStyleItem);
            charLipStickStyleItem.AddPanel(charLipStickStyleColorPanel);
            charLipStickStyleItem.AddPanel(charLipStickStylePercentPanel);
            charLipStickStyleColorPanel.SetParentItem(charLipStickStyleItem);
            charLipStickStylePercentPanel.SetParentItem(charLipStickStyleItem);

            // Moles/Freckles [9]

            var charMoleFrecklesStyleItem = new UIMenuListItem("Moles & Freckles", molesStyle, pChar.molesStyle); // Moles & Freckles
            var charMoleFrecklesStylePercentPanel = new UIMenuPercentagePanel("Opacity", "0%", "100%", 50.0f);

            cFaceShapeMenu.AddItem(charMoleFrecklesStyleItem);
            charMoleFrecklesStyleItem.AddPanel(charMoleFrecklesStylePercentPanel);
            charMoleFrecklesStylePercentPanel.SetParentItem(charMoleFrecklesStyleItem);

         
            // Eye color

            var charEyeColorStyleItem = new UIMenuListItem("Eye Color", eyeColorStyles, pChar.eyeColorStyle); // Eye color
            cFaceShapeMenu.AddItem(charEyeColorStyleItem);

            // Back button

            var charApperanceMenuBack = new UIMenuItem("Back", "Go back to the ~r~facial shape~s~ menu");
            cFaceShapeMenu.AddItem(charApperanceMenuBack);

            // Confirmation button

            var charApperanceMenuConfirm = new UIMenuItem("Next", "Go to the ~r~clothes~s~ menu"); // Confirm button to show the next menu.
            cFaceShapeMenu.AddItem(charApperanceMenuConfirm);

    

            // List Events

            try
            {
                cFaceShapeMenu.OnListChange += (sender, item, index) =>
                {
                    if (item == charHairStyleItem)
                    {
                        pChar.hairStyle = index;
                        SetPedComponentVariation(GetPlayerPed(-1), 2, index, 0, 2); // Hair
                    }
                    if (item == charEyeBrowsStyleItem)
                    {
                        pChar.eyeBrowStyle = index;
                        updatePlayerChar(2, pChar.eyeBrowStyle, pChar.eyeBrowOpacity);
                    }
                    if (item == charBeardStyleItem)
                    {
                        pChar.beardStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(1, pChar.beardStyle, pChar.beardOpacity);
                    }
                    if (item == charBlemishesStyleItem)
                    {
                        pChar.blemishesStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(0, pChar.blemishesStyle, pChar.blemishesOpacity);
                    }
                    if (item == charSkinAgeStyleItem)
                    {
                        pChar.skinAgingStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(3, pChar.skinAgingStyle, pChar.skinAgingOpacity);
                    }
                    if (item == charComplexionStylesItem)
                    {
                        pChar.complexionStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(6, pChar.complexionStyle, pChar.complexionOpacity);
                    }
                    if (item == charMoleFrecklesStyleItem)
                    {
                        pChar.molesStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(9, pChar.molesStyle, pChar.molesOpacity);
                    }
                    if (item == charSunDamageStyleItem)
                    {
                        pChar.sunDamageStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(7, pChar.sunDamageStyle, pChar.sunDamageOpacity);
                    }
                    if (item == charEyeColorStyleItem)
                    { 
                        pChar.eyeColorStyle = index;
                        SetPedEyeColor(API.GetPlayerPed(-1), pChar.eyeColorStyle); // Eye Color
                    }
                    if (item == charMakeupStyleItem)
                    {
                        pChar.makeupStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1; 
                        updatePlayerChar(4, pChar.makeupStyle, pChar.makeupOpacity);
                    }
                    if (item == charLipStickStyleItem)
                    {
                        pChar.lipStickStyle = (string)item.Items[index] == GetLabelText("FACE_F_P_OFF") ? 255 : index - 1;
                        updatePlayerChar(8, pChar.lipStickStyle, pChar.lipStickOpacity);
                    }

               };

                cFaceShapeMenu.OnColorPanelChange += (item, panel, value) =>
                {
                    if (panel == charEyeBrowsStyleColorPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.eyeBrowColor = value;
                            updatePlayerChar(pChar, 2, 1, value, 0);
                        }
                    }
                    if (panel == charBeardStyleColorPanel)
                    {
                        if (panel == item.Panels[0])
                        { 
                            pChar.beardColor = value;
                            updatePlayerChar(pChar, 1, 1, value, 0);
                        }
                    }
                    if (panel == charMakeupStyleColorPanel)
                    {
                        if (panel == item.Panels[0])
                        { 
                            pChar.makeupColor = value;
                            updatePlayerChar(pChar, 4, 0, value, 0);
                        }
                    }
                    if (panel == charLipStickStyleColorPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.lipStickColor = value;
                            updatePlayerChar(pChar, 8, 2, value, 0);
                        }
                    }
                    if (panel == charHairStyleColorPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.hairStyleColor = value;
                            SetPedHairColor(GetPlayerPed(-1), value, 0);
                        }
                    }
                };

                cFaceShapeMenu.OnPercentagePanelChange += (item, panel, value) =>
                {
                    if (value > 100.0f || value < 0.0f)
                    {
                        return;
                    }

                    var percentage = value / 100.0f;

                    if (panel == charEyeBrowsStylePercentPanel)
                    {
                        if (panel == item.Panels[1])
                        {
                            pChar.eyeBrowOpacity = percentage;
                            updatePlayerChar(pChar, 2, percentage);
                        }
                    }
                    if (panel == charBeardStylePercentPanel)
                    {
                        if (panel == item.Panels[1])
                        {
                            pChar.beardOpacity = percentage;
                            updatePlayerChar(pChar, 1, percentage);
                        }
                    }
                    if (panel == charBlemishesStylePercentPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.blemishesOpacity = percentage;
                            updatePlayerChar(pChar, 0, percentage);
                        }
                    }
                    if (panel == charSkinAgingStylePercentPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.skinAgingOpacity = percentage;
                            updatePlayerChar(pChar, 3, percentage);
                        }
                    }
                    if (panel == charComplexionStylesPercentPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.complexionOpacity = percentage;
                            updatePlayerChar(pChar, 6, percentage);
                        }
                    }
                    if (panel == charMoleFrecklesStylePercentPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.molesOpacity = percentage;
                            updatePlayerChar(pChar, 9, percentage);
                        }
                    }
                    if (panel == charSunDamageStylePercentPanel)
                    {
                        if (panel == item.Panels[0])
                        {
                            pChar.sunDamageOpacity = percentage;
                            updatePlayerChar(pChar, 7, percentage);
                        }
                    }
                    if (panel == charMakeupStylePercentPanel)
                    {
                        if (panel == item.Panels[0])
                        { 
                            pChar.makeupOpacity = percentage;
                            updatePlayerChar(pChar, 4, percentage);
                        }
                    }
                    if (panel == charLipStickStylePercentPanel)
                    {
                        if (panel == item.Panels[1])
                        {
                            pChar.lipStickOpacity = percentage;
                            updatePlayerChar(pChar, 8, percentage);
                        }
                    }
                };

            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine($"[EXCEPTION] {e}");
            }

            cFaceShapeMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == charApperanceMenuConfirm)
                {
                    MenuController.CloseAllMenus();
                    charClothingMenu(pChar);
                    inFaceApperance = false;
                }
                if (item == charApperanceMenuBack)
                {
                    MenuController.CloseAllMenus();
                    charFaceShapeMenu(pChar);
                    inFaceApperance = false;
                }
            };

            cFaceShapeMenu.Visible = true;
            inFaceApperance = true;
        }
        public void charClothingMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cClothesMenu = new UIMenu("Clothing", "Character's clothing.", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"), false);
            MenuController.AddMenu(cClothesMenu);

            cClothesMenu.EnableAnimation = true;
            cClothesMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;


            cClothesMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cClothesMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cClothesMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cClothesMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));


            for (int drawable = 0; drawable < 12; drawable++)
            {
                int currentDrawable = GetPedDrawableVariation(Game.PlayerPed.Handle, drawable);
                int maxVariations = GetNumberOfPedDrawableVariations(Game.PlayerPed.Handle, drawable);
                int maxTextures = GetNumberOfPedTextureVariations(Game.PlayerPed.Handle, drawable, currentDrawable);

                if (maxVariations > 0)
                {
                    List<dynamic> drawableTexturesList = new List<dynamic>();

                    for (int i = 0; i < maxVariations; i++)
                    {
                        drawableTexturesList.Add($"Item #{i + 1} (of {maxVariations})");
                    }

                    var drawableTextures = new UIMenuListItem($"{textureNames[drawable]}", drawableTexturesList, currentDrawable);
                    drawableTextures.Description = $"Select an item in the list and press ~o~enter~s~ to cycle through all available textures.";

                    if (drawable == 1 || drawable == 3 || drawable == 4 || drawable == 6 || drawable == 7 || drawable == 8 || drawable == 11) // add used comps only
                    {
                        cClothesMenu.AddItem(drawableTextures);
                    }
                    
                    cClothesMenu.OnListChange += (_sender, _item, _index) =>
                    {
                        int compID = cClothesMenu.CurrentSelection;
                        if (_item == drawableTextures)
                        {
                            switch (compID)
                            {
                                case 0:
                                    SetPedComponentVariation(GetPlayerPed(-1), 1, drawableTextures.Index, 0, 2);
                                    pChar.maskStyle = drawableTextures.Index;
                                    pChar.maskColor = 0;
                                    break;
                                case 1:
                                    SetPedComponentVariation(GetPlayerPed(-1), 3, drawableTextures.Index, 0, 2);
                                    pChar.armStyle = drawableTextures.Index;
                                    pChar.armColor = 0;
                                    break;
                                case 2:
                                    SetPedComponentVariation(GetPlayerPed(-1), 4, drawableTextures.Index, 0, 2);
                                    pChar.pantStyle = drawableTextures.Index;
                                    pChar.pantColor = 0;
                                    break;
                                case 3:
                                    SetPedComponentVariation(GetPlayerPed(-1), 6, drawableTextures.Index, 0, 2);
                                    pChar.shoeStyle = drawableTextures.Index;
                                    pChar.shoeColor = 0;
                                    break;
                                case 4:
                                    SetPedComponentVariation(GetPlayerPed(-1), 7, drawableTextures.Index, 0, 2);
                                    pChar.tShirtStyle = drawableTextures.Index;
                                    pChar.tShirtColor = 0;
                                    break;
                                case 5:
                                    SetPedComponentVariation(GetPlayerPed(-1), 8, drawableTextures.Index, 0, 2);
                                    pChar.bArmorStyle = drawableTextures.Index;
                                    pChar.bArmorColor = 0;
                                    break;
                                case 6:
                                    SetPedComponentVariation(GetPlayerPed(-1), 11, drawableTextures.Index, 0, 2);
                                    pChar.torsoStyle = drawableTextures.Index;
                                    pChar.torsoColor = 0;
                                    break;
                                default:
                                    break;
                            }
                        }
                    };

                    cClothesMenu.OnListSelect += (_sender, _item, _index) =>
                    {
                        if (_item == drawableTextures)
                        {
                            var compID = cClothesMenu.CurrentSelection;
                            int propIndex = compID;

                            if (compID == 0)
                            {
                                propIndex = 1;
                            }
                            if(compID == 1)
                            {
                                propIndex = 3;
                            }
                            if (compID == 2)
                            {
                                propIndex = 4;
                            }
                            if (compID == 3)
                            {
                                propIndex = 6;
                            }
                            if (compID == 4)
                            {
                                propIndex = 7;
                            }
                            if (compID == 5)
                            {
                                propIndex = 8;
                            }
                            if (compID == 6)
                            {
                                propIndex = 11;
                            }

                            int textureIndex = GetPedTextureVariation(Game.PlayerPed.Handle, propIndex);
                            int newTextureIndex = (GetNumberOfPedTextureVariations(Game.PlayerPed.Handle, propIndex, _index) - 1) < (textureIndex + 1) ? 0 : textureIndex + 1;
                            switch (compID)
                            {
                                case 0:
                                    SetPedComponentVariation(GetPlayerPed(-1), 1, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.maskStyle = drawableTextures.Index;
                                    pChar.maskColor = newTextureIndex;
                                    break;
                                case 1:
                                    SetPedComponentVariation(GetPlayerPed(-1), 3, drawableTextures.Index, 0, 2);
                                    pChar.armStyle = drawableTextures.Index;
                                    pChar.armColor = newTextureIndex;
                                    break;
                                case 2:
                                    SetPedComponentVariation(GetPlayerPed(-1), 4, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.pantStyle = drawableTextures.Index;
                                    pChar.pantColor = newTextureIndex;
                                    break;
                                case 3:
                                    SetPedComponentVariation(GetPlayerPed(-1), 6, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.shoeStyle = drawableTextures.Index;
                                    pChar.shoeColor = newTextureIndex;
                                    break;
                                case 4:
                                    SetPedComponentVariation(GetPlayerPed(-1), 7, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.tShirtStyle = drawableTextures.Index;
                                    pChar.tShirtColor = newTextureIndex;
                                    break;
                                case 5:
                                    SetPedComponentVariation(GetPlayerPed(-1), 8, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.bArmorStyle = drawableTextures.Index;
                                    pChar.bArmorColor = newTextureIndex;
                                    break;
                                case 6:
                                    SetPedComponentVariation(GetPlayerPed(-1), 11, drawableTextures.Index, newTextureIndex, 2);
                                    pChar.torsoStyle = drawableTextures.Index;
                                    pChar.torsoColor = newTextureIndex;
                                    break;
                                default:
                                    break;
                            }
                        }
                    };
                }
            }


            var charClothingBack = new UIMenuItem("Back", "Go back to the ~r~facial apperance~s~ menu."); // Confirm button to show the next menu.
            cClothesMenu.AddItem(charClothingBack);

            var charClothingConfirm = new UIMenuItem("Next", "Go to the ~r~props~s~ menu"); // Confirm button to show the next menu.
            cClothesMenu.AddItem(charClothingConfirm);



            cClothesMenu.OnItemSelect += (_sender, _item, _index) =>
            {
                if (_item == charClothingConfirm)
                {
                    MenuController.CloseAllMenus();
                    charPropsMenu(pChar);
                    inClothes = false;
                }
                if (_item == charClothingBack)
                {
                    MenuController.CloseAllMenus();
                    charFaceApperanceMenu(pChar);
                    inClothes = false;
                }
            };


            cClothesMenu.Visible = true;
            inClothes = true;
        }

        public void charPropsMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cPropsMenu = new UIMenu("Props", "Character's props.", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"), false);
            MenuController.AddMenu(cPropsMenu);

            cPropsMenu.EnableAnimation = true;
            cPropsMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;


            cPropsMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cPropsMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cPropsMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cPropsMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));

            for (int x = 0; x < 5; x++)
            {
                int propId = x;
                if (x > 2)
                {
                    propId += 3;
                }

                var currentProp = GetPedPropIndex(Game.PlayerPed.Handle, propId);
                int maxPropTextures = GetNumberOfPedPropTextureVariations(Game.PlayerPed.Handle, propId, currentProp);

                List<dynamic> propsList = new List<dynamic>();
                for (int i = 0; i < GetNumberOfPedPropDrawableVariations(Game.PlayerPed.Handle, propId); i++)
                {
                    propsList.Add($"Prop #{i} (of {GetNumberOfPedPropDrawableVariations(Game.PlayerPed.Handle, propId)})");
                }

                var propListItem = new UIMenuListItem($"{propNames[x]}", propsList, currentProp);
                propListItem.Description = $"Select an item in the list and press ~o~enter~s~ to cycle through all available textures.";
                cPropsMenu.AddItem(propListItem);

                cPropsMenu.OnListChange += (_sender, _item, _index) =>
                {
                     var compID = cPropsMenu.CurrentSelection;
                     if(_item == propListItem)
                     {
                        switch (compID)
                        {
                            case 0:
                                if (_index == 0) ClearPedProp(Game.PlayerPed.Handle, 0);
                                else
                                {
                                    SetPedPropIndex(Game.PlayerPed.Handle, 0, _index, 0, true);
                                    pChar.hatID = _index;
                                    pChar.hatColor = 0;
                                }
                                break; 
                            case 1:
                                if (_index == 0) ClearPedProp(Game.PlayerPed.Handle, 1);
                                else
                                {
                                    SetPedPropIndex(Game.PlayerPed.Handle, 1, _index, 0, true);
                                    pChar.glassesID = _index;
                                    pChar.glassesColor = 0;
                                }
                                break;
                            case 2:
                                if (_index == 0) ClearPedProp(Game.PlayerPed.Handle, 2);
                                else
                                {
                                    SetPedPropIndex(Game.PlayerPed.Handle, 2, _index, 0, true);
                                    pChar.earringID = _index;
                                    pChar.earringColor = 0;
                                }
                                break;
                            case 3:
                                if (_index == 0) ClearPedProp(Game.PlayerPed.Handle, 6);
                                else
                                {
                                    SetPedPropIndex(Game.PlayerPed.Handle, 6, _index, 0, true);
                                    pChar.watchID = _index;
                                    pChar.watchColor = 0;
                                }
                                break;
                            case 4:
                                if (_index == 0) ClearPedProp(Game.PlayerPed.Handle, 7);
                                else
                                {
                                    SetPedPropIndex(Game.PlayerPed.Handle, 7, _index, 0, true);
                                    pChar.braceletID = _index;
                                    pChar.braceletColor = 0;
                                }
                                break;
                            default:
                                break;
                        }
                     }
                };

                cPropsMenu.OnListSelect += (_sender, _item, _index) =>
                {
                    if (_item == propListItem)
                    {
                        var compID = cPropsMenu.CurrentSelection;
                        int propIndex = compID;

                        if (compID == 3)
                        {
                            propIndex = 6;
                        }
                        if (compID == 4)
                        {
                            propIndex = 7;
                        }

                        int textureIndex = GetPedPropTextureIndex(Game.PlayerPed.Handle, propIndex);
                        int newTextureIndex = (GetNumberOfPedPropTextureVariations(Game.PlayerPed.Handle, propIndex, _index) - 1) < (textureIndex) ? 0 : textureIndex + 1;
                        if (textureIndex >= GetNumberOfPedPropDrawableVariations(Game.PlayerPed.Handle, propIndex))
                        {
                            SetPedPropIndex(Game.PlayerPed.Handle, propIndex, -1, -1, false);
                            ClearPedProp(Game.PlayerPed.Handle, propIndex);
                        }
                        else
                        {
                            switch (compID)
                            {
                                case 0:
                                    SetPedPropIndex(Game.PlayerPed.Handle, 0, _index, newTextureIndex, true);
                                    pChar.hatID = _index;
                                    pChar.hatColor = newTextureIndex;
                                    break;
                                case 1:
                                    SetPedPropIndex(Game.PlayerPed.Handle, 1, _index, newTextureIndex, true);
                                    pChar.glassesID = _index;
                                    pChar.glassesColor = newTextureIndex;
                                    break;
                                case 2:
                                    SetPedPropIndex(Game.PlayerPed.Handle, 2, _index, newTextureIndex, true);
                                    pChar.earringID = _index;
                                    pChar.earringColor = newTextureIndex;
                                    break;
                                case 3:
                                    SetPedPropIndex(Game.PlayerPed.Handle, 6, _index, newTextureIndex, true);
                                    pChar.watchID = _index;
                                    pChar.watchColor = newTextureIndex;
                                    break;
                                case 4:
                                    SetPedPropIndex(Game.PlayerPed.Handle, 7, _index, newTextureIndex, true);
                                    pChar.braceletID = _index;
                                    pChar.braceletColor = newTextureIndex;
                                    break;
                            }
                        }
                    }
                };
            }

            var charPropsBack = new UIMenuItem("Back", "Go back to the ~r~clothes~s~ menu."); // Confirm button to show the next menu.
            cPropsMenu.AddItem(charPropsBack);

            var charPropsConfirm = new UIMenuItem("Next", "Go to the ~r~tattoos~s~ menu."); // Confirm button to show the next menu.
            cPropsMenu.AddItem(charPropsConfirm);

            cPropsMenu.OnItemSelect += (_sender, _item, _index) =>
            {
                if (_item == charPropsBack)
                {
                    MenuController.CloseAllMenus();
                    charClothingMenu(pChar);
                    inProps = false;
                }
                if (_item == charPropsConfirm)
                {
                    MenuController.CloseAllMenus();
                    charTatoosMenu(pChar);
                    inProps = false;
                }
            };

            cPropsMenu.Visible = true;
            inProps = true;
        }

        public void charTatoosMenu(Player.Character pChar)
        {
            PointF screenCenter = new PointF(150, 150);
            cTattoosMenu = new UIMenu("Tattoos", "Character's tattoos.", screenCenter, new KeyValuePair<string, string>("commonmenu", "gradient_bgd"), false);
            MenuController.AddMenu(cTattoosMenu);

            cTattoosMenu.EnableAnimation = true;
            cTattoosMenu.AnimationType = MenuAnimationType.QUARTIC_INOUT;


            cTattoosMenu.InstructionalButtons.Add(new InstructionalButton(Control.MoveLeftRight, "Turn Head"));
            cTattoosMenu.InstructionalButtons.Add(new InstructionalButton(Control.PhoneExtraOption, "Turn Character"));
            cTattoosMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeRight, "Turn Camera Right"));
            cTattoosMenu.InstructionalButtons.Add(new InstructionalButton(Control.ParachuteBrakeLeft, "Turn Camera Left"));

            List<dynamic> headTattoosList = new List<dynamic>();
            List<dynamic> torsoTattoosList = new List<dynamic>();
            List<dynamic> leftArmTattoosList = new List<dynamic>();
            List<dynamic> rightArmTattoosList = new List<dynamic>();
            List<dynamic> leftLegTattoosList = new List<dynamic>();
            List<dynamic> rightLegTattoosList = new List<dynamic>();

            if (pChar.Gender)
            {
                int counter = 1;
                foreach (var tattoo in MaleTattoosCollection.HEAD)
                {
                    headTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.HEAD.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in MaleTattoosCollection.TORSO)
                {
                    torsoTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.TORSO.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in MaleTattoosCollection.LEFT_ARM)
                {
                    leftArmTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.LEFT_ARM.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in MaleTattoosCollection.RIGHT_ARM)
                {
                    rightArmTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.RIGHT_ARM.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in MaleTattoosCollection.LEFT_LEG)
                {
                    leftLegTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.LEFT_LEG.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in MaleTattoosCollection.RIGHT_LEG)
                {
                    rightLegTattoosList.Add($"Tattoo #{counter} (of {MaleTattoosCollection.RIGHT_LEG.Count})");
                    counter++;
                }
            }
            else
            {
                int counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.HEAD)
                {
                    headTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.HEAD.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.TORSO)
                {
                    torsoTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.TORSO.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.LEFT_ARM)
                {
                    leftArmTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.LEFT_ARM.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.RIGHT_ARM)
                {
                    rightArmTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.RIGHT_ARM.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.LEFT_LEG)
                {
                    leftLegTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.LEFT_LEG.Count})");
                    counter++;
                }
                counter = 1;
                foreach (var tattoo in FemaleTattoosCollection.RIGHT_LEG)
                {
                    rightLegTattoosList.Add($"Tattoo #{counter} (of {FemaleTattoosCollection.RIGHT_LEG.Count})");
                    counter++;
                }
            }

            const string tatDesc = "Cycle through the list to preview tattoos   Press ~o~enter~s~ to add ~r~OR~s~ remove the selected tattoo to your character.";
            UIMenuListItem headTatts = new UIMenuListItem("Head Tattoos", headTattoosList, 0, tatDesc);
            UIMenuListItem torsoTatts = new UIMenuListItem("Torso Tattoos", torsoTattoosList, 0, tatDesc);
            UIMenuListItem leftArmTatts = new UIMenuListItem("Left Arm Tattoos", leftArmTattoosList, 0, tatDesc);
            UIMenuListItem rightArmTatts = new UIMenuListItem("Right Arm Tattoos", rightArmTattoosList, 0, tatDesc);
            UIMenuListItem leftLegsTatts = new UIMenuListItem("Left Leg Tattoos", leftLegTattoosList, 0, tatDesc);
            UIMenuListItem rightLegsTatts = new UIMenuListItem("Right Leg Tattoos", rightLegTattoosList, 0, tatDesc);

            UIMenuItem cTattoosRemove = new UIMenuItem("Remove All Tattoos", "Click this if you want to ~r~remove~s~ all tattoos.");
            UIMenuItem cTattoosConfirm = new UIMenuItem("Confirm", "Confirm the ~r~creation~s~ of your character.");
            UIMenuItem cTattoosBack = new UIMenuItem("Back", "Go back to the ~r~props~s~ menu.");

            cTattoosMenu.AddItem(headTatts);
            cTattoosMenu.AddItem(torsoTatts);
            cTattoosMenu.AddItem(leftArmTatts);
            cTattoosMenu.AddItem(rightArmTatts);
            cTattoosMenu.AddItem(leftLegsTatts);
            cTattoosMenu.AddItem(rightLegsTatts);
            cTattoosMenu.AddItem(cTattoosRemove);
            cTattoosMenu.AddItem(cTattoosConfirm);
            cTattoosMenu.AddItem(cTattoosBack);


            void CreateListsIfNull()
            {
                if (pChar.HeadTattoos == null)
                {
                    pChar.HeadTattoos = new List<KeyValuePair<string, string>>();
                }
                if (pChar.TorsoTattoos == null)
                {
                    pChar.TorsoTattoos = new List<KeyValuePair<string, string>>();
                }
                if (pChar.LeftArmTattoos == null)
                {
                    pChar.LeftArmTattoos = new List<KeyValuePair<string, string>>();
                }
                if (pChar.RightArmTattoos == null)
                {
                    pChar.RightArmTattoos = new List<KeyValuePair<string, string>>();
                }
                if (pChar.LeftLegTattoos == null)
                {
                    pChar.LeftLegTattoos = new List<KeyValuePair<string, string>>();
                }
                if (pChar.RightLegTattoos == null)
                {
                    pChar.RightLegTattoos = new List<KeyValuePair<string, string>>();
                }
            }

            void ApplySavedTattoos()
            {
                ClearPedDecorations(Game.PlayerPed.Handle);

                foreach (var tattoo in pChar.HeadTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
                foreach (var tattoo in pChar.TorsoTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
                foreach (var tattoo in pChar.LeftArmTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
                foreach (var tattoo in pChar.RightArmTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
                foreach (var tattoo in pChar.LeftLegTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
                foreach (var tattoo in pChar.RightLegTattoos)
                {
                    SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tattoo.Key), (uint)GetHashKey(tattoo.Value));
                }
            }

            cTattoosMenu.OnListChange += (_sender, _item, _index) =>
            {
                CreateListsIfNull();
                ApplySavedTattoos();
                if (cTattoosMenu.CurrentSelection == 0) // head
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.HEAD.ElementAt(_index) : FemaleTattoosCollection.HEAD.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.HeadTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 1) // torso
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.TORSO.ElementAt(_index) : FemaleTattoosCollection.TORSO.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.TorsoTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 2) // left arm
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.LEFT_ARM.ElementAt(_index) : FemaleTattoosCollection.LEFT_ARM.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.LeftArmTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 3) // right arm
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.RIGHT_ARM.ElementAt(_index) : FemaleTattoosCollection.RIGHT_ARM.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.RightArmTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 4) // left leg
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.LEFT_LEG.ElementAt(_index) : FemaleTattoosCollection.LEFT_LEG.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.LeftLegTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 5) // right leg
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.RIGHT_LEG.ElementAt(_index) : FemaleTattoosCollection.RIGHT_LEG.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (!pChar.RightLegTattoos.Contains(tat))
                    {
                        SetPedDecoration(Game.PlayerPed.Handle, (uint)GetHashKey(tat.Key), (uint)GetHashKey(tat.Value));
                    }
                }
            };


            cTattoosMenu.OnListSelect += (_sender, _item, _index) =>
            {
                CreateListsIfNull();

                if (cTattoosMenu.CurrentSelection == 0) // head
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.HEAD.ElementAt(_index) : FemaleTattoosCollection.HEAD.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.HeadTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.HeadTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.HeadTattoos.Add(tat);
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 1) // torso
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.TORSO.ElementAt(_index) : FemaleTattoosCollection.TORSO.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.TorsoTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.TorsoTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.TorsoTattoos.Add(tat);
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 2) // left arm
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.LEFT_ARM.ElementAt(_index) : FemaleTattoosCollection.LEFT_ARM.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.LeftArmTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.LeftArmTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.LeftArmTattoos.Add(tat);
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 3) // right arm
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.RIGHT_ARM.ElementAt(_index) : FemaleTattoosCollection.RIGHT_ARM.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.RightArmTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.RightArmTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.RightArmTattoos.Add(tat);
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 4) // left leg
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.LEFT_LEG.ElementAt(_index) : FemaleTattoosCollection.LEFT_LEG.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.LeftLegTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.LeftLegTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.LeftLegTattoos.Add(tat);
                    }
                }
                else if (cTattoosMenu.CurrentSelection == 5) // right leg
                {
                    var Tattoo = pChar.Gender ? MaleTattoosCollection.RIGHT_LEG.ElementAt(_index) : FemaleTattoosCollection.RIGHT_LEG.ElementAt(_index);
                    KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                    if (pChar.RightLegTattoos.Contains(tat))
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~r~removed~s~.");
                        pChar.RightLegTattoos.Remove(tat);
                    }
                    else
                    {
                        Utility.CommFuncs.DisplayNotify($"Tattoo #{_index + 1} has been ~g~added~s~.");
                        pChar.RightLegTattoos.Add(tat);
                    }
                }

                ApplySavedTattoos();
            };

            cTattoosMenu.OnItemSelect += (_sender, _item, _index) =>
            {
                if (_item == cTattoosRemove)
                {
                    CreateListsIfNull();
                }
                if(_item == cTattoosConfirm)
                {
                    API.DoScreenFadeOut(500);
                    MenuController.CloseAllMenus();
                    confirmCharCreation(pChar);
                    inTattoos = false;
                }
                if(_item == cTattoosBack)
                {
                    MenuController.CloseAllMenus();
                    charPropsMenu(pChar);
                    inTattoos = false;
                }
            };

            cTattoosMenu.Visible = true;
            inTattoos = true;
        }

        public charFactory()
        {
            EventHandlers["dFRP:startCreator"] += new Action<string>(startCharCreation);

            Tick += async () =>
            {
                if(inCreation == true)
                {
                    if (IsControlJustReleased(0, 202) || IsControlJustReleased(0, 200) || IsControlJustReleased(0, 177) || IsControlJustReleased(0, 322))
                    {
                        if(inHeritage)
                        {
                            MenuController.CloseAllMenus(); // avoid menu duplication
                            cHeritageMenu.Visible = true;
                        }
                        if(inFaceShape)
                        {
                            MenuController.CloseAllMenus();
                            cFaceShapeMenu.Visible = true;
                        }
                        if(inFaceApperance)
                        {
                            MenuController.CloseAllMenus();
                            cFaceApperanceMenu.Visible = true;
                        }
                        if(inClothes)
                        {
                            MenuController.CloseAllMenus();
                            cClothesMenu.Visible = true;
                        }
                        if(inProps)
                        {
                            MenuController.CloseAllMenus();
                            cPropsMenu.Visible = true;
                        }
                        if(inTattoos)
                        {
                            MenuController.CloseAllMenus();
                            cTattoosMenu.Visible = true;
                        }
                    }
                }

                await Task.FromResult(0);
            };
        }

        public async void startCharCreation(string playerChar)
        {
            var pChar = JsonConvert.DeserializeObject<Player.Character>(playerChar);

            TakeControlOfFrontend();

            API.DoScreenFadeOut(1000);

            while (API.IsScreenFadingOut() && !API.HasModelLoaded(1885233650))
            {
                await Delay(1);
            }

            API.NetworkSetInSpectatorMode(false, 0);

            //--------------------------------[PRE-SPAWN LOCATION & MODEL]-----------------------------------------------//

            await Game.Player.ChangeModel(1885233650);
            var x = -1848.884F;
            var y = -1247.196F;
            var z = 8.605103F - 0.8f;

            //-----------------------------------------------------------------------------------------------------------//

            var playerPed = GetPlayerPed(-1);

            API.RequestCollisionAtCoord(x, y, z);
            API.SetEntityCoordsNoOffset(playerPed, x, y, z, false, false, false);
            API.SetEntityHeading(playerPed, 315.0F);
            API.NetworkResurrectLocalPlayer(x, y, z, 315.0F, true, true);
            API.ClearPedTasksImmediately(playerPed);
            API.RemoveAllPedWeapons(playerPed, false);
            API.ClearPlayerWantedLevel(playerPed);

            while (!API.HasCollisionLoadedAroundEntity(playerPed))
            {
                await Delay(1);
            }

            API.ShutdownLoadingScreen();
 
            await Delay(100);
            TriggerEvent("playerSpawned", PlayerId());

            charHeritageMenu(pChar);
            MenuController.CloseAllMenus(); // reset the menu & wait 1 sec to reload - otherwise the background YTD doesn't load.

            await Delay(1000);
            pChar.renderPlayerCharacter();
            SetPedHeadBlendData(GetPlayerPed(-1), 0, 0, 0, 0, 0, 0, 0.5F, 0.5F, 0, true);

 
            charHeritageMenu(pChar);

            API.DoScreenFadeIn(2000);
            while (API.IsScreenFadingIn())
            {
                await Delay(1);
            }

        }

        public void confirmCharCreation(Player.Character pChar)
        {
            ReleaseControlOfFrontend();
            inCreation = false;
            var charInfo = JsonConvert.SerializeObject(pChar);

            TriggerEvent("dFRP:spawnPlayerCharacter", charInfo);
            TriggerServerEvent("dFRP:addNewCharacter", charInfo);
            TriggerServerEvent("dFRP:resetPlayerBucket");
        }


        public static bool IsInCharacterCreation()
        {
            if(inCreation == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static UIMenu getCurrentCharCreatorMenu()
        {
            if (inHeritage)
            {
                return cHeritageMenu;
            }
            else if (inFaceApperance)
            {
                return cFaceApperanceMenu;
            }
            else if (inFaceShape)
            {
                return cFaceShapeMenu;
            }
            else if (inClothes)
            {
                return cClothesMenu;
            }
            else if (inProps)
            {
                return cPropsMenu;
            }
            else if (inTattoos)
            {
                return cTattoosMenu;
            }
            else
            {
                return null;
            }
        }

    }
}
