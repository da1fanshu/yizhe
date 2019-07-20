﻿using UnityEngine;
using YxFramwork.Common;
using YxFramwork.Common.Utils;
using YxFramwork.Manager;

namespace Assets.Scripts.Game.bjl3d
{
    public class Plane0 : MonoBehaviour
    {

        public static Plane0 Instance;

        protected void Awake()
        {
            Instance = this;

        }
        public void OnMouseDown()
        {
            MusicManager.Instance.Play("Bet");
            var gdata = App.GetGameData<GlobalData>();
            
            if (Plane5.Instance.IsPointerOverUIObject())
                return;
           
            if (UserInfoUI.Instance.GameConfig.GameState != 5)
            {
                GameUI.Instance.NoteText_Show("此时不能下注！！！");
                return;
            }
            
            if (gdata.CurrentUser.Seat == gdata.B)
            {
                GameUI.Instance.NoteText_Show("自己是庄家，不能下注！！！");
                return;
            }
            if (gdata.CurrentUser.Gold < gdata.GoldNum[UserInfoUI.Instance.GameConfig.CoinType])
            {
                GameUI.Instance.NoteText_Show("金币不足！！！");
                return;
            }
            if (gdata.Allow[0] != 0 && gdata.GoldNum[UserInfoUI.Instance.GameConfig.CoinType] > gdata.Allow[0])
            {
                GameUI.Instance.NoteText_Show("下注已经达到上限！！！");
                return;
            }
            App.GetRServer<GameServer>().UserBet(0, gdata.GoldNum[UserInfoUI.Instance.GameConfig.CoinType]);
            gdata.CurrentUser.Gold -= gdata.GoldNum[UserInfoUI.Instance.GameConfig.CoinType];
            App.GameData.GStatus = GameStatus.PlayAndConfine;
            
        }

    }
}
