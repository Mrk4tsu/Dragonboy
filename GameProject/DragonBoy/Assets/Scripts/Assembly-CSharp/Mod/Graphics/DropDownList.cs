namespace Mod.Graphics
{
    public class DropDownList : IActionListener
    {
        private static DropDownList Instance;
        public static DropDownList _Instance()
        {
            if (Instance == null)
            {
                Instance = new DropDownList();
            }
            return Instance;
        }
        internal string[] strArea = new string[2] { "VIỆT NAM", "GLOBAL" };

        internal Command cmdGlobal;
        internal Command cmdVietNam;

        internal MyVector vecServer = new MyVector();

        internal static bool isEnable;

        public void paint(mGraphics g)
        {
            if (isEnable)
            {
                cmdGlobal = new Command(strArea[0], this, 98, null);
                cmdGlobal.x = 0;
                cmdGlobal.y = 0;
                cmdVietNam = new Command(strArea[1], this, 97, null);
                cmdVietNam.x = 50;
                cmdVietNam.y = 0;
                vecServer = new MyVector();
                vecServer.addElement(cmdGlobal);
                vecServer.addElement(cmdVietNam);
            }
        }
        internal void paint_Area(mGraphics g, int x, int y)
        {
            GameCanvas.serverScr.xPopUp_Area = x;
            PopUp.paintPopUp(g, x, y, GameCanvas.serverScr.wBox, GameCanvas.serverScr.hBox, 0, true);
            mFont.tahoma_7b_dark.drawString(g, strArea[GameCanvas.serverScr.select_Area], x + (GameCanvas.serverScr.wBox - 10) / 2, y + 5, 2);
            g.drawRegion(Mob.imgHP, 0, 30, 9, 6, 0, x + GameCanvas.serverScr.wBox - 10, y + 14, mGraphics.BOTTOM | mGraphics.HCENTER);
            if (!isEnable)
                return;
            GameCanvas.serverScr.yPopUp_Area = y + GameCanvas.serverScr.hBox + 5;
            g.setColor(10254674);
            g.fillRect(x, GameCanvas.serverScr.yPopUp_Area, GameCanvas.serverScr.wBox, strArea.Length * GameCanvas.serverScr.htext + 1);
            for (int i = 0; i < strArea.Length; i++)
            {
                mFont.tahoma_7_white.drawString(g, strArea[i], x + GameCanvas.serverScr.wBox / 2, GameCanvas.serverScr.yPopUp_Area + i * GameCanvas.serverScr.htext + 2, 2);
                if (GameCanvas.serverScr.select_Area == i)
                {
                    g.setColor(15591444);
                    g.drawRect(x + 2, GameCanvas.serverScr.yPopUp_Area + i * GameCanvas.serverScr.htext + 1, GameCanvas.serverScr.wBox - 4, GameCanvas.serverScr.htext - 2);
                }
            }
        }
        public void update()
        {

        }
        public void perform(int idAction, object p)
        {
            throw new System.NotImplementedException();
        }
    }
}
