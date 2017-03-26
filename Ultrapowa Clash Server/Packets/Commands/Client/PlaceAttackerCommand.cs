﻿using System.Collections.Generic;
using UCS.Files.Logic;
using UCS.Helpers.Binary;
using UCS.Logic;
using UCS.Logic.Enums;

namespace UCS.Packets.Commands.Client
{
    // Packet 600
    internal class PlaceAttackerCommand : Command
    {
        public PlaceAttackerCommand(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }

        internal override void Decode()
        {
            this.X = this.Reader.ReadInt32();
            this.Y = this.Reader.ReadInt32();
            this.Unit = (CombatItemData) this.Reader.ReadDataReference();
            this.Tick = this.Reader.ReadUInt32();
        }


        internal override void Process()
        {
            if (this.Device.PlayerState != State.IN_BATTLE)
            {
                List<DataSlot> _PlayerUnits = this.Device.Player.Avatar.GetUnits();

                DataSlot _DataSlot = _PlayerUnits.Find(t => t.Data.GetGlobalID() == Unit.GetGlobalID());
                if (_DataSlot != null)
                {
                    _DataSlot.Value = _DataSlot.Value - 1;
                }
            }
        }

        public CombatItemData Unit;
        public uint Tick;
        public int X;
        public int Y;
    }
}