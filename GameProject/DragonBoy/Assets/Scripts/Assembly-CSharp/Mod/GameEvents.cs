﻿using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Mod
{
    /// <summary>
    /// Định nghĩa các sự kiện của game.
    /// </summary>
    /// <remarks>
    /// - Các hàm bool trả về true thì sự kiện game sẽ không được thực hiện, 
    /// trả về false thì sự kiện sẽ được kích hoạt như bình thường.<br/>
    /// - Các hàm void hỗ trợ thực hiện các lệnh cùng với sự kiện.
    /// </remarks>
    public static class GameEvents
    {
        private static bool isZoomLevelChecked;

        /// <summary>
        /// Kích hoạt khi người chơi chat.
        /// </summary>
        /// <param name="text">Nội dung chat.</param>
        /// <returns></returns>
        public static bool onSendChat(string text)
        {
            bool result = true;
            if (text == "test")
                GameScr.info1.addInfo("Test OK", 0);
            else 
                result = false;
            return result;
        }

        /// <summary>
        /// Kích hoạt sau khi game khởi động.
        /// </summary>
        public static void onGameStarted()
        {

        }

        /// <summary>
        /// Kích hoạt khi game đóng
        /// </summary>
        public static void onGameClosing()
        {

        }

        public static void onSaveRMSString(ref string filename, ref string data)
        {
            
        }

        /// <summary>
        /// Kích hoạt khi cài đăt kích thước màn hình.
        /// </summary>
        /// <returns></returns>
        public static bool onSetResolution()
        {
            return false;
        }

        /// <summary>
        /// Kích hoạt khi nhấn phím tắt (GameScr) chưa được xử lý.
        /// </summary>
        public static void onGameScrPressHotkeysUnassigned()
        {
            
        }

        /// <summary>
        /// Kích hoạt khi nhấn phím tắt (GameScr).
        /// </summary>
        public static void onGameScrPressHotkeys()
        {
           
        }

        /// <summary>
        /// Kích hoạt sau khi vẽ khung chat.
        /// </summary>
        public static void onPaintChatTextField(ChatTextField instance, mGraphics g)
        {

        }

        /// <summary>
        /// Kích hoạt khi mở khung chat.
        /// </summary>
        public static bool onStartChatTextField(ChatTextField sender, IChatable parentScreen)
        {
            return false;
        }

        public static bool onLoadRMSInt(string file, out int result)
        {
            result = -1;
            return false;
        }

        internal static bool onGetRMSPath(out string result)
        {
            result = $"asset\\{GameMidlet.IP}_{GameMidlet.PORT}_x{mGraphics.zoomLevel}\\";
            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);
            return true;
        }

        public static bool onTeleportUpdate(Teleport teleport)
        {
            return false;
        }

        /// <summary>
        /// Kích hoạt khi có ChatTextField update.
        /// </summary>
        public static void onUpdateChatTextField(ChatTextField sender)
        {
           
        }

        public static bool onClearAllRMS()
        {
            return false;
        }

        /// <summary>
        /// Kích hoạt khi GameScr.gI() update.
        /// </summary>
        public static void onUpdateGameScr()
        {
           
        }

        /// <summary>
        /// Kích hoạt khi gửi yêu cầu đăng nhập.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <param name="type"></param>
        public static void onLogin(ref string username, ref string pass, ref sbyte type)
        {

        }

        /// <summary>
        /// Kích hoạt sau khi màn hình chọn server được load.
        /// </summary>
        public static void onServerListScreenLoaded()
        {

        }

        /// <summary>
        /// Kích hoạt khi Session kết nối đến server.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public static void onSessionConnecting(ref string host, ref int port)
        {

        }

        public static void onSceenDownloadDataShow()
        {

        }

        public static bool onCheckZoomLevel()
        {

            return false;
        }

        public static bool onKeyPressedz(int keyCode, bool isFromSync)
        {
            return false;
        }

        public static bool onKeyReleasedz(int keyCode, bool isFromAsync)
        { 
            return false;
        }

        public static bool onChatPopupMultiLine(string chat)
        {
            return false;
        }

        public static bool onAddBigMessage(string chat, Npc npc)
        {
            return false;
        }

        public static void onInfoMapLoaded()
        {
        }

        public static void onPaintGameScr(mGraphics g)
        {

        }

        public static bool onUseSkill(Skill skill)
        {
            return false;
        }

        public static void onFixedUpdateMain()
        {

        }

        public static void onUpdateMain()
        {

        }

        public static void onAddInfoMe(string str)
        {

        }

        public static void onUpdateTouchGameScr()
        {

        }

        public static void onUpdateTouchPanel()
        {

        }

        public static void onSetPointItemMap(int xEnd, int yEnd)
        {
           
        }

        public static bool onMenuStartAt(MyVector menuItems)
        {
            return false;
        }

        public static void onAddInfoChar(string info, Char c)
        {

        }

        public static void onLoadImageGameCanvas()
        {

        }

        public static bool onPaintBgGameScr(mGraphics g)
        {
            return false;
        }

        public static void onMobStartDie(Mob instance)
        {
           
        }

        public static void onUpdateMob(Mob instance)
        {
            
        }

        public static Image onCreateImage(string filename)
        {
            Image image = new Image();
            Texture2D texture2D = new Texture2D(1, 1);
            if (!Directory.Exists("Game_Data\\CustomAssets")) Directory.CreateDirectory("Game_Data\\CustomAssets");
            if (File.Exists("Game_Data\\CustomAssets\\" + filename.Replace('/', '\\') + ".png"))
            {
                texture2D.LoadImage(File.ReadAllBytes("Game_Data\\CustomAssets\\" + filename.Replace('/', '\\') + ".png"));
            }
            else texture2D = Resources.Load(filename) as Texture2D;
            image.texture = texture2D ?? throw new Exception("NULL POINTER EXCEPTION AT Image onCreateImage " + filename);
            image.w = image.texture.width;
            image.h = image.texture.height;
            image.texture.anisoLevel = 0;
            image.texture.filterMode = FilterMode.Point;
            image.texture.mipMapBias = 0f;
            image.texture.wrapMode = TextureWrapMode.Clamp;
            return image;
        }

        public static void onChatVip(string chatVip)
        {

        }

        public static void onUpdateScrollMousePanel(Panel instance, ref int pXYScrollMouse)
        {

        }

        public static void onPanelHide(Panel instance)
        {

        }

        public static void onUpdateKeyPanel(Panel instance)
        {

        }
    }
}