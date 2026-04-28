using BepInEx.Logging;
using HarmonyLib;
using Polytopia.Data;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;
using PolyMod;

using BepInEx;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using PolytopiaBackendBase.Game;
using System.Text.Json;
using StableNameDotNet;

using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

namespace polyautoplay;
public static class Main
{
    #pragma warning disable CS8618
    private static ManualLogSource logger;
    #pragma warning restore CS8618
    //private static bool isInitialized = false;
    public static void Load(ManualLogSource logger)
    {
        Main.logger = logger;
        logger.LogMessage("Flint was here!");
        Harmony.CreateAndPatchAll(typeof(Main));
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartMatchAction), nameof(StartMatchAction.ExecuteDefault))]
    public static void testata(EndTurnAction __instance, GameState gameState)
    {
        GameManager.debugAutoPlayLocalPlayer = false;
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.Update))]
    public static void AutoPlay()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameManager.debugAutoPlayLocalPlayer = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.debugAutoPlayLocalPlayer = true;
            GameManager.LocalPlayer.handicap = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.debugAutoPlayLocalPlayer = true;
            GameManager.LocalPlayer.handicap = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.debugAutoPlayLocalPlayer = true;
            GameManager.LocalPlayer.handicap = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.debugAutoPlayLocalPlayer = true;
            GameManager.LocalPlayer.handicap = 4;
        }

    }

    //[HarmonyPostfix]
    //[HarmonyPatch(typeof(StartScreen), nameof(StartScreen.Start))]
    /*private static void GameManager_Update()
    {
        //logger.LogMessage("LEROOOOOOY JEEEENKIIINSSS");
            var popup = PopupManager.GetBasicPopup(new(
                "You Got Mail!",
                "LEROOOOOOY JEEEENKIIINSSS",
                new Il2CppReferenceArray<PopupBase.PopupButtonData>(new PopupBase.PopupButtonData[]
                {
                    new("cool", callback: (UIButtonBase.ButtonAction) ((_, _) => { logger.LogMessage("Leroy Jenkins has entered"); })),
                    new("stop", callback: (UIButtonBase.ButtonAction) ((_, _) => { logger.LogMessage("Leroy Jenkins has been eviscerated"); }))
                })
            ));
            popup.Show();*/
        /*if (!isInitialized)
        {
            isInitialized = true;
            
        }*/
        // logger.LogMessage("help there's a rowdy fennekin running around messing with my circuts");
    //}
}
