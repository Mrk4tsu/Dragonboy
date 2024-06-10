using System.Collections.Generic;
using System.Linq;

namespace Mod.Graphics
{
    //Hiện tại chỉ dùng cho PickMob
    internal class NewUI : IActionListener
    {
        private List<string> strAreas = new List<string> { "Buỵt Buỵt", "Gâu Gâu Gâu", "Ẳng ẳng ẳng Ẳng" };

        private sbyte select_Area;

        internal bool isEnable;

        internal string Content;

        internal int xPopUp_Area;

        internal int yPopUp_Area;

        internal int yBox;

        internal int wBox;

        internal int hBox;

        internal int htext;

        internal int color;
        internal static NewUI Instance { get; } = new NewUI();      
        private NewUI()
        {
            this.Content = "Hello World";
            this.strAreas.Sort();
            this.wBox = 75 + (maxLenght() * 2);
            this.hBox = 20;
            this.htext = 15;
            this.color = 0;
            this.select_Area = 0;
        }
        internal void paintPopup(mGraphics g, int x, int y)
        {
            this.xPopUp_Area = x;
            this.yPopUp_Area = y + hBox;
            PopUp.paintPopUp(g, x, y, wBox, hBox, 0, true);
            mFont.tahoma_7b_dark.drawString(g, Content, x + (wBox - 10) / 2, y + 5, 2);
            g.drawRegion(Mob.imgHP, 0, 30, 9, 6, 0, x + wBox - 10, y + 14, mGraphics.BOTTOM | mGraphics.HCENTER);



            if (isEnable)
            {
                g.setColor(10254674);
                g.fillRect(x, yPopUp_Area, wBox, strAreas.Count * htext + 1);
                foreach (var i in strAreas)
                {
                    int index = strAreas.IndexOf(i);

                    mFont.tahoma_7_white.drawString(g, strAreas[index], x + wBox / 2, yPopUp_Area + index * htext + 2, 2);
                    if (select_Area == index)
                    {
                        g.setColor(15591444);
                        g.drawRect(x + 2, yPopUp_Area + index * htext + 1, wBox - 4, htext - 2);
                    }

                }
            }


        }
        internal void updateKeyPopup(int x, int y)
        {
            if (GameCanvas.isPointerHoldIn(x, y, wBox, hBox))
            {
                GameCanvas.isPointerJustDown = false;
                GameScr.gI().isPointerDowning = false;
                if (GameCanvas.isPointerClick)
                {
                    this.isEnable = !isEnable;
                }

                GameCanvas.clearAllPointerEvent();
                GameCanvas.clearKeyPressed();
                GameCanvas.clearKeyHold();
                return;
            }
            updateKeyListItem(x, y);
        }
        internal void updateKeyListItem(int x, int y)
        {
            if (!isEnable) return;
            foreach (var item in strAreas)
            {
                int index = strAreas.IndexOf(item);
                if (GameCanvas.isPointerHoldIn(x + 2, yPopUp_Area + index * htext + 1, wBox - 4, htext - 2))
                {
                    GameCanvas.isPointerJustDown = false;
                    GameScr.gI().isPointerDowning = false;
                    if (GameCanvas.isPointerClick)
                    {
                        select_Area = (sbyte)index;
                        this.Content = strAreas[index];
                    }

                    GameCanvas.clearAllPointerEvent();
                    GameCanvas.clearKeyPressed();
                    GameCanvas.clearKeyHold();
                    return;
                }
            }
        }
        internal void update()
        {

        }
        public void perform(int idAction, object p)
        {
            throw new System.NotImplementedException();
        }
        //Dùng LinQ set chuỗi dài nhất trong List
        internal int maxLenght() => strAreas.Max(x => x.Length);
    }
}
