﻿using System;
using UCS.Core;
using UCS.Files.Logic;
using UCS.Helpers.Binary;
using UCS.Logic;

namespace UCS.Packets.Commands.Client
{
    // Packet 522
    internal class BuyShieldCommand : Command
    {
        public BuyShieldCommand(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.ShieldId = this.Reader.ReadInt32();
            this.Tick = this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            ClientAvatar player = this.Device.Player.Avatar;
            /*if (ShieldId == 20000000)
            {
                player.SetProtectionTime(Convert.ToInt32(TimeSpan.FromHours(((ShieldData)CSVManager.DataTables.GetDataById(ShieldId)).TimeH).TotalSeconds));
                player.UseDiamonds(((ShieldData)CSVManager.DataTables.GetDataById(ShieldId)).Diamonds);
            }
            else
            {*/
                player.SetShieldTime(player.m_vShieldTime + Convert.ToInt32(TimeSpan.FromHours(((ShieldData)CSVManager.DataTables.GetDataById(ShieldId)).TimeH).TotalSeconds));
                player.UseDiamonds(((ShieldData)CSVManager.DataTables.GetDataById(ShieldId)).Diamonds);
            //}
        }

        public int ShieldId;
        public int Tick;
    }
}
