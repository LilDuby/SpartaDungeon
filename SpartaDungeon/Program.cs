using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SpartaDungeon
{
    //Player class
    public class Player
    {
        public int playerLv;
        public string? playerName;
        public string? playerJob;
        public int playerAtk;
        public int playerDef;
        public double playerHp;
        public double playerGold;
        public Player(int _playerLv, string? _playerName, string? _playerJob, int _playerAtk, int _playerDef, double _playerHp, double _playerGold)
        {
            playerLv = _playerLv;
            playerName = _playerName;
            playerJob = _playerJob;
            playerAtk = _playerAtk;
            playerDef = _playerDef;
            playerHp = _playerHp;
            playerGold = _playerGold;
        }

        ~Player()
        {

        }
    }

    //Items class
    public class Items
    {
        public bool itemEqp;
        public string itemName;
        public string itemOp;
        public int itemStt;
        public string itemInfo;
        public double itemPr;
        public bool itemBuy;

        public int? itemNum;
        public int? itemBuyNum;
        public int? itemSellNum;
        public Items(bool _itemEqp, string _itemName, string _itemOp, int _itemStt,
                      string _itemInfo, double _itemPr, bool _itemBuy, int? _itemNum, int? _itemBuyNum, int? _itemSellNum)
        {
            itemEqp = _itemEqp;
            itemName = _itemName;
            itemOp = _itemOp;
            itemStt = _itemStt;
            itemInfo = _itemInfo;
            itemPr = _itemPr;
            itemBuy = _itemBuy;
            itemNum = _itemNum;
            itemBuyNum = _itemBuyNum;
            itemSellNum = _itemSellNum;
        }
        ~Items()
        {

        }

        public void InvenInfoEqp()
        {
            Console.WriteLine($"[E]{itemName}| {itemOp} +{itemStt}\t| {itemInfo}");
        }

        public void InvenInfo()
        {
            Console.WriteLine($"{itemName}| {itemOp} +{itemStt}\t| {itemInfo}");
        }

        public void StoreInfo()
        {
            Console.WriteLine($"{itemName}| {itemOp} +{itemStt}\t| {itemInfo} | {itemPr} G");
        }

        public void StoreInfoBuy()
        {
            Console.WriteLine($"{itemName}| {itemOp} +{itemStt}\t| {itemInfo} | 구매완료");
        }

        public void StoreInfoSell()
        {
            Console.WriteLine($"{itemName}| {itemOp} +{itemStt}\t| {itemInfo} | {Math.Round(itemPr * 0.85)} G");
        }
        public void StoreInfoSellEqp()
        {
            Console.WriteLine($"[E] {itemName}| {itemOp} +{itemStt}\t| {itemInfo} | {Math.Round(itemPr * 0.85)} G");
        }
    }





    internal class Program
    {
        public static Player player;
        public static Items item;
        public static List<Items> itemList;
        public static Random random;

        static void Main(string[] args)
        {


            //랜덤클래스 객체 생성
            random = new Random();

            //게임실행
            StartScene();
        }

        //---------------------------------시작화면-----------------------------------------------

        static int startScene;
        static bool startSceneCheck;

        static void StartScene()
        {
            Console.Clear();
            Console.WriteLine("\r\n  ####                             #                     ####                                                   \r\n #    #                            #                     #   #                                                  \r\n #       #####    #####  # ###   #####    #####          #    #  #    #  # ###    #####   ####    ####   # ###  \r\n  ####   #    #  #    #  ##        #     #    #          #    #  #    #  ##   #  #    #  #    #  #    #  ##   # \r\n      #  #    #  #    #  #         #     #    #          #    #  #    #  #    #  #    #  ######  #    #  #    # \r\n #    #  #    #  #   ##  #         #     #   ##          #   #   #   ##  #    #   #####  #       #    #  #    # \r\n  ####   #####    ### #  #          ###   ### #          ####     ### #  #    #       #   ####    ####   #    # \r\n         #                                                                        ####                          \r\n");
            Console.WriteLine("\n1. 게임시작");
            Console.Write("0. 게임종료\n>> ");
            startSceneCheck = int.TryParse(Console.ReadLine(), out startScene);
            if (startSceneCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                StartScene();
                return;
            }
            switch (startScene)
            {
                case 1:
                    //player 생성
                    player = new Player(1, null, null, 10, 5, 100, 1500);
                    //장비 생성 후 List배열에 저장
                    itemList = new List<Items>();
                    itemList.Add(new Items(false, "수련자 갑옷    ", "방어력", 5, "수련에 도움을 주는 갑옷입니다.                    ", 1000, false, null, null, null));
                    itemList.Add(new Items(false, "무쇠갑옷       ", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.                ", 1500, false, null, null, null));
                    itemList.Add(new Items(false, "스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ", 3500, false, null, null, null));
                    itemList.Add(new Items(false, "낡은 검        ", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.                   ", 1000, false, null, null, null));
                    itemList.Add(new Items(false, "청동 도끼      ", "공격력", 5, "어디선가 사용됐건거 같은 도끼입니다.              ", 1500, false, null, null, null));
                    itemList.Add(new Items(false, "스파르타의 창  ", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.   ", 3500, false, null, null, null));
                    SelectJob();
                    return;

                case 0:
                    Console.WriteLine("게임을 종료합니다.");
                    Thread.Sleep(500);
                    Environment.Exit(0);
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    StartScene();
                    return;
            }
        }



        //----------------------------------직업 선택----------------------------------
        static int selectJob;
        static bool selectJobCheck;
        static int selectJobYes;
        static bool selectJobYesCheck;
        static void SelectJob()
        {
            Console.Clear();
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            Console.WriteLine("3. 마법사");
            Console.WriteLine("4. 궁수");
            Console.WriteLine("5. ???\n");
            Console.Write(">> ");
            selectJobCheck = int.TryParse(Console.ReadLine(), out selectJob);
            if (selectJobCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                SelectJob();
                return;
            }
            switch (selectJob)
            {
                case 1:
                    Console.WriteLine("전사를 선택하시겠습니까?\n");
                    Console.WriteLine("1. 예");
                    Console.Write("0. 아니요\n>> ");
                    selectJobYesCheck = int.TryParse(Console.ReadLine(), out selectJobYes);
                    if (selectJobYesCheck == false)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        SelectJob();
                        return;
                    }
                    switch (selectJobYes)
                    {
                        case 1:
                            player.playerJob = "전사";
                            NameMenu();
                            return;

                        case 0:
                            SelectJob();
                            return;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            SelectJob();
                            return;
                    }

                case 2:
                    Console.WriteLine("도적를 선택하시겠습니까?\n");
                    Console.WriteLine("1. 예");
                    Console.Write("0. 아니요\n>> ");
                    selectJobYesCheck = int.TryParse(Console.ReadLine(), out selectJobYes);
                    if (selectJobYesCheck == false)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        SelectJob();
                        return;
                    }
                    switch (selectJobYes)
                    {
                        case 1:
                            player.playerJob = "도적";
                            NameMenu();
                            return;

                        case 0:
                            SelectJob();
                            return;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            SelectJob();
                            return;
                    }

                case 3:
                    Console.WriteLine("마법사를 선택하시겠습니까?\n");
                    Console.WriteLine("1. 예");
                    Console.Write("0. 아니요\n>> ");
                    selectJobYesCheck = int.TryParse(Console.ReadLine(), out selectJobYes);
                    if (selectJobYesCheck == false)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        SelectJob();
                        return;
                    }
                    switch (selectJobYes)
                    {
                        case 1:
                            player.playerJob = "마법사";
                            NameMenu();
                            return;

                        case 0:
                            SelectJob();
                            return;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            SelectJob();
                            return;
                    }



                case 4:
                    Console.WriteLine("궁수를 선택하시겠습니까?\n");
                    Console.WriteLine("1. 예");
                    Console.Write("0. 아니요\n>> ");
                    selectJobYesCheck = int.TryParse(Console.ReadLine(), out selectJobYes);
                    if (selectJobYesCheck == false)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        SelectJob();
                        return;
                    }
                    switch (selectJobYes)
                    {
                        case 1:
                            player.playerJob = "궁수";
                            NameMenu();
                            return;

                        case 0:
                            SelectJob();
                            return;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            SelectJob();
                            return;
                    }

                case 5:
                    Console.WriteLine("???를 선택하시겠습니까?\n");
                    Console.WriteLine("1. 예");
                    Console.Write("0. 아니요\n>> ");
                    selectJobYesCheck = int.TryParse(Console.ReadLine(), out selectJobYes);
                    if (selectJobYesCheck == false)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        SelectJob();
                        return;
                    }
                    switch (selectJobYes)
                    {
                        case 1:
                            player.playerJob = "마왕";
                            itemList.Add(new Items(true, "마왕의 망토    ", "방어력", 99, "핏빛에 물든 망토입니다.                           ", 9999, true, null, null, null));
                            itemList.Add(new Items(true, "마왕의 대검    ", "공격력", 99, "수만은 용사의 영혼이 담긴 대검입니다.             ", 9999, true, null, null, null));
                            NameMenu();
                            return;

                        case 0:
                            SelectJob();
                            return;

                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                            SelectJob();
                            return;
                    }

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    SelectJob();
                    return;
                }
            }







        //----------------------------------------이름 정하기----------------------------------


        static string nameMenu;
        static int nameMenuYes;
        static bool nameMenuYesCheck;

        static void NameMenu()
        {
            Console.Clear();
            Console.Write("이름을 입력해주세요.\n\n\n>> ");
            nameMenu = Console.ReadLine();
            player.playerName = nameMenu;
            Console.WriteLine($"이름을 {player.playerName} (으)로 하시겠습니까?\n");
            Console.WriteLine("1. 네");
            Console.Write("0. 아니요\n>> ");
            nameMenuYesCheck = int.TryParse(Console.ReadLine(), out nameMenuYes);
            if (nameMenuYesCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                NameMenu();
            }
            switch (nameMenuYes)
            {
                case 1:
                    MainMenu();
                    return;

                case 0:
                    player.playerName = null;
                    NameMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    player.playerName = null;
                    NameMenu();
                    return;

            }
        }













        //-------------------------------------------인벤토리-------------------------------------------
        static int invenMenu;
        static bool invenMenuCheck;
        static void InvenMenu()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (Items item in itemList)
            {
                if (item.itemBuy == true)
                {
                    if (item.itemEqp == true)
                    {
                        Console.Write("- ");
                        item.InvenInfoEqp();
                    }
                    else
                    {
                        Console.Write("- ");
                        item.InvenInfo();
                    }
                }
                else
                {

                }
            }
            Console.WriteLine("\n1. 창착 관리");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하는 행동을 입력해주세요.\n>> ");
            invenMenuCheck = int.TryParse(Console.ReadLine(), out invenMenu);
            if (invenMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InvenMenu();
                return;
            }
            switch (invenMenu)
            {
                case 0:
                    MainMenu();
                    return;

                case 1:
                    InvenManageMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    InvenMenu();
                    return;
            }
        }
        //장착관리
        static int num;
        static int invenManageMenu;
        static bool invenManageMenuCheck;

        static void InvenManageMenu()
        {
            num = 1;
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            foreach (Items item in itemList)
            {
                if (item.itemBuy == true)
                {
                    if (item.itemEqp == true)
                    {
                        Console.Write($"- {num} ");
                        item.InvenInfoEqp();
                        item.itemNum = num;
                        num++;
                    }
                    else
                    {
                        Console.Write($"- {num} ");
                        item.InvenInfo();
                        item.itemNum = num;
                        num++;
                    }
                }
                else
                {

                }
            }
            Console.WriteLine("\n0. 나가기\n");
            Console.Write("원하는 행동을 입력해주세요.\n>> ");
            invenManageMenuCheck = int.TryParse(Console.ReadLine(), out invenManageMenu);
            if (invenManageMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InvenManageMenu();
                return;
            }
            foreach (Items item in itemList)
            {
                if (invenManageMenu == item.itemNum)
                {
                    if (item.itemEqp == true)
                    {
                        item.itemEqp = false;
                        if (item.itemOp == "공격력")
                        {
                            player.playerAtk -= item.itemStt;
                        }
                        else if (item.itemOp == "방어력")
                        {
                            player.playerDef -= item.itemStt;
                        }
                        Console.WriteLine("장비 해제");
                        Thread.Sleep(500);
                        InvenManageMenu();
                        break;
                    }
                    else
                    {
                        if (item.itemOp == "공격력")
                        {
                            foreach (Items item0 in itemList)
                            {
                                if (item0.itemOp == "공격력" && item0.itemEqp == true)
                                {
                                    item0.itemEqp = false;
                                    player.playerAtk -= item0.itemStt;
                                    break;
                                }
                            }
                            player.playerAtk += item.itemStt;
                        }
                        else if (item.itemOp == "방어력")
                        {
                            foreach (Items item0 in itemList)
                            {
                                if (item0.itemOp == "방어력" && item0.itemEqp == true)
                                {
                                    item0.itemEqp = false;
                                    player.playerDef -= item0.itemStt;
                                    break;
                                }
                            }
                            player.playerDef += item.itemStt;
                        }
                        item.itemEqp = true;
                        Console.WriteLine("장비 장착");
                        Thread.Sleep(500);
                        InvenManageMenu();
                        break;
                    }
                }
                else
                {

                }
            }
            if (invenManageMenu == 0)
            {
                foreach (Items item in itemList)
                {
                    item.itemNum = null;
                }
                InvenMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                InvenManageMenu();
                return;
            }
        }

        // ------------------------------------------상태 보기--------------------------------------
        static int sttMenu;
        static bool sttMenuCheck;
        static void SttMenu()
        {



            Console.Clear();
            Console.WriteLine("상태 표시");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {player.playerLv}");
            Console.WriteLine($"{player.playerName} ( {player.playerJob} )");
            Console.Write($"공격력 : {player.playerAtk} ");
            if (player.playerAtk != 10)
            {
                Console.WriteLine($"(+{player.playerAtk - 10})");
            }
            else
            {
                Console.WriteLine("");
            }
            Console.Write($"방어력 : {player.playerDef} ");
            if (player.playerDef != 5)
            {
                Console.WriteLine($"(+{player.playerDef - 5})");
            }
            else
            {
                Console.WriteLine("");
            }
            Console.WriteLine($"체 력 : {player.playerHp}");
            Console.WriteLine($"Gold : {player.playerGold} G\n");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            sttMenuCheck = int.TryParse(Console.ReadLine(), out sttMenu);
            if (sttMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                SttMenu();
                return;
            }
            switch (sttMenu)
            {
                case 0:
                    MainMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    SttMenu();
                    return;
            }
        }


        //--------------------------------------------메인 화면---------------------------------------
        static int mainMenu;
        static bool mainMenuCheck;
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("0. 게임 종료\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            mainMenuCheck = int.TryParse(Console.ReadLine(), out mainMenu);
            if (mainMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                MainMenu();
                return;
            }
            switch (mainMenu)
            {
                case 0:
                    Console.WriteLine("게임을 종료합니다.");
                    Thread.Sleep(500);
                    Environment.Exit(0);
                    return;

                case 1:
                    SttMenu();
                    return;

                case 2:
                    InvenMenu();
                    return;

                case 3:
                    StoreMenu();
                    return;

                case 4:
                    DungeonMenu();
                    return;

                case 5:
                    RestMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    MainMenu();
                    return;
            }
        }

        //-------------------------------------------상점--------------------------------------------
        static int storeMenu;
        static bool storMenuCheck;
        static void StoreMenu()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.playerGold} G\n");
            Console.WriteLine("[아이템 목록]");
            foreach (Items item in itemList)
            {
                if (item.itemBuy == false)
                {
                    item.StoreInfo();
                }
                else
                {
                    item.StoreInfoBuy();
                }
            }
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2, 아이템 판매");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            storMenuCheck = int.TryParse(Console.ReadLine(), out storeMenu);
            if (storMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                StoreMenu();
                return;
            }
            switch (storeMenu)
            {
                case 1:
                    StoreBuyMenu();
                    return;

                case 2:
                    StoreSellMenu();
                    return;

                case 0:
                    MainMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    StoreMenu();
                    return;
            }
        }
        //아이템 구매
        static int storeBuyMenu;
        static bool storeBuyMenuCheck;
        static void StoreBuyMenu()
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("보유 골드");
            Console.WriteLine($"{player.playerGold} G\n");
            Console.WriteLine("[아이템 목록]");
            foreach (Items item in itemList)
            {
                if (item.itemBuy == false)
                {
                    Console.Write($"- {i} ");
                    item.StoreInfo();
                    item.itemBuyNum = i;
                    i++;
                }
                else
                {
                    Console.Write($"- {i} ");
                    item.StoreInfoBuy();
                    item.itemBuyNum = i;
                    i++;
                }
            }
            Console.WriteLine("\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            storeBuyMenuCheck = int.TryParse(Console.ReadLine(), out storeBuyMenu);
            if (storeBuyMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                StoreBuyMenu();
                return;
            }
            foreach (Items item in itemList)
            {
                if (storeBuyMenu == item.itemBuyNum)
                {
                    if (item.itemBuy == false)
                    {
                        if (player.playerGold >= item.itemPr)
                        {
                            item.itemBuy = true;
                            Console.WriteLine("구매를 완료했습니다.");
                            player.playerGold -= item.itemPr;
                            Thread.Sleep(500);
                            StoreBuyMenu();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                            Thread.Sleep(500);
                            StoreBuyMenu();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("이미 구매한 아이템입니다");
                        Thread.Sleep(500);
                        StoreBuyMenu();
                        return;
                    }
                }
            }
            switch (storeBuyMenu)
            {
                case 0:
                    foreach (Items item in itemList)
                    {
                        item.itemBuyNum = null;
                    }
                    StoreMenu();
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    StoreBuyMenu();
                    return;
            }
        }

        //------------------------------------------------아이템 판매-----------------------------------------------------
        static int storeSellMenu;
        static bool storeSellMenuCheck;

        static void StoreSellMenu()
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("상점에 팔고싶은 아이템을 선택하세요");
            Console.WriteLine("※ 판매 시 구매 가격의 85% 가격에 판매합니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.playerGold} G\n");
            Console.WriteLine("[아이템 목록]");
            foreach (Items item in itemList)
            {
                if (item.itemBuy == true)
                {
                    if (item.itemEqp == false)
                    {
                        Console.Write($"- {i} ");
                        item.StoreInfoSell();
                        item.itemSellNum = i;
                        i++;
                    }
                    else
                    {
                        Console.Write($"- {i} ");
                        item.StoreInfoSellEqp();
                        item.itemSellNum = i;
                        i++;
                    }
                }
                else
                {
                    item.itemSellNum = null;
                }

            }
            Console.WriteLine("\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            storeSellMenuCheck = int.TryParse(Console.ReadLine(), out storeSellMenu);
            if (storeSellMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                StoreSellMenu();
                return;
            }
            foreach (Items item in itemList)
            {
                if (storeSellMenu == item.itemSellNum)
                {
                    if (item.itemEqp == false)
                    {
                        Console.WriteLine("아이템 판매중...");
                        Thread.Sleep(500);
                        item.itemBuy = false;
                        player.playerGold += Math.Round(item.itemPr * 0.85);
                        Console.WriteLine("아이템이 판매되었습니다.");
                        Console.WriteLine($"{Math.Round(item.itemPr * 0.85)} G 획득");
                        Thread.Sleep(500);
                        StoreSellMenu();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템 판매중...");
                        Thread.Sleep(500);
                        item.itemBuy = false;
                        item.itemEqp = false;
                        if (item.itemOp == "공격력")
                        {
                            player.playerAtk -= item.itemStt;
                        }
                        else if (item.itemOp == "방어력")
                        {
                            player.playerDef -= item.itemStt;
                        }
                        player.playerGold += Math.Round(item.itemPr * 0.85);
                        Console.WriteLine("아이템이 판매되었습니다.");
                        Console.WriteLine($"{Math.Round(item.itemPr * 0.85)} G 획득");
                        Thread.Sleep(500);
                        StoreSellMenu();
                        return;
                    }

                }
            }
            switch (storeSellMenu)
            {
                case 0:
                    foreach (Items item in itemList)
                    {
                        item.itemSellNum = null;
                    }
                    StoreMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    StoreSellMenu();
                    return;
            }
        }



        //------------------------------------------------던전입장------------------------------------------------------
        static int dungeonMenu;
        static bool dungeonMenuCheck;

        static void DungeonMenu()
        {
            Console.Clear();
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("플레이어의 공격력과 방어력에 따라 입는 피해 및 클리어 보상이 조정됩니다.\n");
            Console.WriteLine("※ 플레이어 방어력이 권장 방어력보다 낮을경우 40% 확률로 클리어에 실패합니다.\n" +
                              "   클리어 실패 시 보상 없이 체력 50% 소멸\n");
            Console.WriteLine($"현재 체력 : {player.playerHp}\n");
            Console.WriteLine("1. 쉬운 던전\t| 방어력  5 이상 권장 | 보상 1000 G");
            Console.WriteLine("2. 일반 던전\t| 방어력 11 이상 권장 | 보상 1700 G");
            Console.WriteLine("3. 어려운 던전\t| 방어력 17 이상 권장 | 보상 2500 G");
            Console.WriteLine("0, 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요\n>> ");
            dungeonMenuCheck = int.TryParse(Console.ReadLine(), out dungeonMenu);
            if (dungeonMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                DungeonMenu();
                return;
            }
            else
            {
                switch (dungeonMenu)
                {
                    case 0:
                        MainMenu();
                        return;

                    case 1:
                        EasyDungeon();
                        return;

                    case 2:
                        NormalDungeon();
                        return;

                    case 3:
                        HardDungeon();
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        DungeonMenu();
                        return;
                }
            }
        }




        static int easyDungeon;
        static bool easyDungeonCheck;

        static int damage;
        static double dungeonGold;
        //쉬운 던전
        static void EasyDungeon()
        {
            double life = player.playerHp;
            damage = random.Next(20 + (5 - player.playerDef), 35 + (5 - player.playerDef));
            if(damage <= 0)
            {
                damage = 0;
            }
            dungeonGold = 1000 * random.Next(player.playerAtk, player.playerAtk * 2) / 100 + 1000;
            Math.Round(dungeonGold);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("쉬움 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            life = player.playerHp - damage;
            if(life <= 0)
            {
                GameOver();
                return;
            }
            DungeonClear();
        }

        static void DungeonClear()
        {
            Console.Clear();
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("던전을 클리어 하였습니다.\n");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {player.playerHp} -> {player.playerHp - damage}");
            Console.WriteLine($"Gold {player.playerGold} G -> {player.playerGold + dungeonGold} G\n");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            easyDungeonCheck = int.TryParse(Console.ReadLine(), out easyDungeon);
            if (easyDungeonCheck == false)
            {
                while (true)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    DungeonClear();
                    return;
                }
            }
            else
            {
                switch (easyDungeon)
                {
                    case 0:
                        player.playerHp -= damage;
                        player.playerGold += dungeonGold;
                        damage = 0;
                        dungeonGold = 0;
                        DungeonMenu();
                        return;


                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        DungeonClear();
                        return;
                }
            }


        }
        //일반 던전
        static void NormalDungeon()
        {
            int clear;
            double life = player.playerHp;
            damage = random.Next(20 + (11 - player.playerDef), 35 + (11 - player.playerDef));
            if (damage <= 0)
            {
                damage = 0;
            }
            dungeonGold = 1700 * random.Next(player.playerAtk, player.playerAtk * 2) / 100 + 1700;
            Math.Round(dungeonGold);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("일반 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            clear = random.Next(1, 11);
            life = player.playerHp - damage;
            if (life <= 0)
            {
                GameOver();
                return;
            }
            if (clear < 5)
            {
                Console.WriteLine("던전 클리어 실패...\n");
                Console.WriteLine($"체력 {player.playerHp} -> {Math.Round(player.playerHp / 2)}\n");
                Console.WriteLine("도망치는중...");
                player.playerHp = Math.Round(player.playerHp/2);
                Thread.Sleep(3000);
                if (player.playerHp < 0)
                {
                    GameOver();
                }
                DungeonMenu();
                return;
            }
            DungeonClear();
        }

        //어려운 던전
        static void HardDungeon()
        {
            int clear;
            double life = player.playerHp;
            damage = random.Next(20 + (17 - player.playerDef), 35 + (17 - player.playerDef));
            if (damage <= 0)
            {
                damage = 0;
            }
            dungeonGold = 2500 * random.Next(player.playerAtk, player.playerAtk * 2) / 100 + 2500;
            Math.Round(dungeonGold);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중.");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중..");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("어려운 던전 클리어중...");
            Thread.Sleep(300);
            Console.Clear();
            clear = random.Next(1, 11);
            life = player.playerHp - damage;
            if (life <= 0)
            {
                GameOver();
                return;
            }
            if (clear < 5)
            {
                Console.WriteLine("던전 클리어 실패...\n");
                Console.WriteLine($"체력 {player.playerHp} -> {Math.Round(player.playerHp / 2)}\n");
                Console.WriteLine("도망치는중...");
                player.playerHp = Math.Round(player.playerHp / 2);
                Thread.Sleep(3000);
                if (player.playerHp < 0)
                {
                    GameOver();
                }
                DungeonMenu();
                return;
            }
            DungeonClear();
        }
















        //-----------------------------------------------------휴식기능------------------------------------------------

        static int restMenu;
        static bool restMenuCheck;

        static void RestMenu()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.playerGold} G)\n");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            restMenuCheck = int.TryParse(Console.ReadLine(),out restMenu);
            if (restMenuCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(500);
                RestMenu();
                return;
            }
            else
            
            switch (restMenu)
            {
                case 0:
                    MainMenu();
                    return;

                case 1:
                        if(player.playerGold < 500)
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                            Thread.Sleep(500);
                            RestMenu();
                            return;
                        }
                    Console.Clear();
                    Console.WriteLine("휴식중.");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식중..");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식중...");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식중.");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식중..");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식중...");
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("휴식완료!!\n");
                    Console.WriteLine($"체력 {player.playerHp} -> 100");
                    Console.WriteLine($"Gold {player.playerGold} G -> {player.playerGold - 500} G");
                    player.playerHp = 100;
                    player.playerGold -= 500;
                    Thread.Sleep(3000);
                    MainMenu();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                    RestMenu();
                    return;
            }
        }



        //-------------------------------------------게임오버-----------------------------------------

        static int gmaeOver;
        static bool gameOverCheck;
        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("   ####                                         ###                              \r\n  #    #                                       #   #                             \r\n #         ######  ### ##    #####            #     #  ##   ##   #####    # ###  \r\n #   ###  #     #  #  #  #  #     #           #     #   #   #   #     #   ##     \r\n #     #  #     #  #  #  #  #######           #     #    # #    #######   #      \r\n  #    #  #    ##  #  #  #  #                  #   #     # #    #         #      \r\n   #####   #### #  #     #   #####              ###       #      #####    #      \r\n                                                                                 ");

            Console.WriteLine("\n1. 다시하기");
            Console.WriteLine("0. 게임종료\n>> ");
            gameOverCheck = int.TryParse(Console.ReadLine(), out gmaeOver);
            if (gameOverCheck == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                GameOver();
                return;
            }
            switch(gmaeOver)
            {
                case 1:
                    //player, 장비 삭제
                    player = null;
                    //foreach 사용 X
                    //요소가 하나 제거되면서 인덱스가 앞으로 하나씩 밀리기 때문에
                    //1번 자리 삭제 후 2번 자리 확인 - 삭제된 1번 자리에 2번이 들어가고 2번자리에 3번이 들어감
                    //이러면 foreach구문 실행 후 요소가 제대로 제거되지 않음
                    //역 for문을 이용해 List의 끝에서부터 역순으로 실행하면 밀리지 않고 모두 삭제 가능
                    for(int i = itemList.Count - 1; i >= 0; i--)
                    {
                        itemList.RemoveAt(i);
                    }

                    StartScene();
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    GameOver();
                    return;
            }
        }



















    }
}
