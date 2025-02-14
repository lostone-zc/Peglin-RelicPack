﻿using Battle;
using HarmonyLib;
using PeglinRelicLib.Register;
using Relics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RelicPack.RubyHeart
{
    [HarmonyPatch(typeof(PlayerHealthController), "Damage")]
    public class PlayerHealthDamagePatch
    {
        public static void Prefix(ref float damage, RelicManager ____relicManager)
        {
            if (RelicRegister.TryGetCustomRelicEffect("io.github.crazyjackel.fullHeart", out RelicEffect fullHeart) && ____relicManager.RelicEffectActive(fullHeart))
            {
                damage -= Plugin.Full_Heart_Damage_Reduction.Value;
            }
        }
    }
}
