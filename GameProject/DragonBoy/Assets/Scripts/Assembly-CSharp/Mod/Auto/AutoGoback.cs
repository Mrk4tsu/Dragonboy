﻿using Mod.R;
using Mod.Xmap;
using UnityEngine;

namespace Mod.Auto
{
    internal class AutoGoback
    {
        internal static InfoGoBack goingBackTo = new InfoGoBack();
        internal static bool isGoingBack = false;
        internal static GoBackMode mode { get; set; }
        static long lastTimeGoBack;

        internal static bool isEnabled => mode != GoBackMode.Disabled;

        internal static void setState(int value)
        {
            mode = (GoBackMode)value;
            if (isEnabled)
                enable();
            else
                disable();
        }

        internal static void enable()
        {
            if (mode != GoBackMode.GoBackToFixedLocation) 
                return;
            goingBackTo = new InfoGoBack(TileMap.mapID, TileMap.zoneID, Char.myCharz().cx, Char.myCharz().cy);
            GameScr.info1.addInfo(string.Format(Strings.gobackTo, TileMap.mapName, TileMap.zoneID, goingBackTo.x, goingBackTo.y) + '!', 0);
        }

        internal static void disable()
        {
            isGoingBack = false;
            XmapController.finishXmap();
        }

        internal static void update()
        {
            if (!isEnabled || GameCanvas.gameTick % (60 * Time.timeScale) == 0 || XmapController.gI.IsActing)
                return;
            if (isGoingBack)
                handleGoingBack();
            else if (Char.myCharz().isCharDead())
                handleDeath();
        }

        static void handleGoingBack()
        {
            if (Utils.isMyCharHome())
            {
                if (hasChicken()) 
                    Service.gI().pickItem(-1);
                else if (Char.myCharz().cHP <= 1)
                    GameScr.gI().doUseHP();
                else
                    XmapController.start(goingBackTo.mapID);
            }
            else if (TileMap.mapID == goingBackTo.mapID)
            {
                if (TileMap.zoneID != goingBackTo.zoneID)
                  Service.gI().requestChangeZone(goingBackTo.zoneID, 0);
                else 
                {
                    if (mode != GoBackMode.GoBackToWhereIDied && Char.myCharz().cx != goingBackTo.x || Char.myCharz().cy != goingBackTo.y)
                        Utils.teleportMyChar(goingBackTo.x, goingBackTo.y);
                    else
                        isGoingBack = false;
                }
            }
        }

        static void handleDeath()
        {
            long now = mSystem.currentTimeMillis();
            long timeSinceDeath = now - lastTimeGoBack;
            if (timeSinceDeath > 4000)
            {
                lastTimeGoBack = now;
                return;
            }
            if (timeSinceDeath > 3000)
            {
                if (mode != GoBackMode.GoBackToFixedLocation)
                    goingBackTo = new InfoGoBack(TileMap.mapID, TileMap.zoneID, Char.myCharz());
                Service.gI().returnTownFromDead();
                isGoingBack = true;
            }
        }

        static bool hasChicken()
        {
            return GameScr.vItemMap.size() > 0;
        }

        internal struct InfoGoBack
        {
            internal int mapID;
            internal int zoneID;
            internal int x;
            internal int y;

            internal InfoGoBack(int mapId, int zoneId, int x, int y)
            {
                mapID = mapId;
                zoneID = zoneId;
                this.x = x;
                this.y = TileMap.tileTypeAt(x, y, 2) ? y : Utils.getYGround(x);
            }
            internal InfoGoBack(int mapId, int zoneId, IMapObject mapObject)
            {
                mapID = mapId;
                zoneID = zoneId;
                x = mapObject.getX();
                y = TileMap.tileTypeAt(x, mapObject.getY(), 2) ? mapObject.getY() : Utils.getYGround(x);
            }
        }

        internal enum GoBackMode
        {
            Disabled,
            GoBackToWhereIDied,
            GoBackToFixedLocation,
        }
    }
}