using Gamekit3D.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gamekit3D
{
    public class PlayerInfo
    {
        static public int playerId = 0;
        static public string name = "";
        static public string chatName = "";
        static public Dictionary<string, List<string> > chatMessage = new Dictionary<string, List<string> >();   

        static public int currentHP = 5;
        static public int intelligence = 100;
        static public int speed =  20;
        static public int level = 1;
        static public int attack = 20;
        static public int defense = 20;

        static public Dictionary<int, string> friends = new Dictionary<int, string>();
    }
}
