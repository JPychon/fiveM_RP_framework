using CitizenFX.Core;
using ScaleformUI;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class MenuController : BaseScript
    {
        private static MenuPool menuPool;

        public MenuController()
        {
            menuPool = new MenuPool();
            menuPool.RefreshIndex();


            Tick += async () =>
            {
                menuPool.ProcessMenus();

                await Task.FromResult(0);
            };

        }

        public static void AddMenu(UIMenu menu)
        {
            menuPool.Add(menu);
        }

        public static void CloseAllMenus()
        {
            menuPool.CloseAllMenus();
        }

        public static UIMenu GetCurrentMenu()
        {
            if(Models.Menus.charFactory.IsInCharacterCreation())
            { 
                return Models.Menus.charFactory.getCurrentCharCreatorMenu();
            }
            else
            {
                return null;
            }
        }

        public static int MenuCurrentIndex(UIMenu menu)
        {
            if (menu == Models.Menus.charFactory.cHeritageMenu)
            {
                return 1;
            }
            else if (menu == Models.Menus.charFactory.cFaceApperanceMenu)
            {
                return 1;
            }
            else if (menu == Models.Menus.charFactory.cFaceShapeMenu)
            {
                return 1;
            }
            else if(menu == Models.Menus.charFactory.cClothesMenu)
            {
                switch (menu.CurrentSelection)
                {
                    case 0: // masks
                        return 1;
                    case 1: // upper hands
                        return 2;
                    case 2: // pants
                        return 3;
                    case 3: // shoes
                        return 4;
                    case 4: // scarfs / acessories
                        return 2;
                    case 5: // undershirt
                        return 2;
                    case 6: // jackets / overlay
                        return 0;
                    case 7: // back
                        return 0;
                    case 8: // confirm
                        return 0;
                    default:
                        return 0;  
                }
            }
            else if(menu == Models.Menus.charFactory.cPropsMenu)
            {
                switch (menu.CurrentSelection)
                {
                    case 0: // hats
                        return 1;
                    case 1: // glasses
                        return 1;
                    case 2: // ears
                        return 1;
                    case 3: // watches
                        return 2;
                    case 4: // bracelets
                        return 2;
                    case 5: // back
                        return 0;
                    case 6: // confirm
                        return 0;
                    default:
                        return 0;   
                }
            }
            else if(menu == Models.Menus.charFactory.cTattoosMenu)
            {
                switch(menu.CurrentSelection)
                {
                    case 0: // head
                        return 1;
                    case 1: // torso
                        return 2;
                    case 2: // left arm
                        return 2;
                    case 3: // right arm
                        return 2; 
                    case 4: // left leg
                        return 3; 
                    case 5: // right leg
                        return 3;
                    default:
                        return 0;
                }
            }
            return 0;
        }
    }
}
