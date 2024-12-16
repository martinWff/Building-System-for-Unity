using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingSystem;
using MoonSharp.Interpreter;

[CreateAssetMenu(menuName = "Building System/Script Processors/Lua")]
public class LuaFurnitureScriptProcessor : FurnitureScriptProcessor
{
    private Script script;
    private ScriptFunctionDelegate onUpdate;

    public override void Setup()
    {
        script.Globals.Get("OnSetup").Function.Call();
    }

    public override void Tick()
    {
        onUpdate?.Invoke(Time.deltaTime);
    }

    protected override void Init()
    {
        script = new Script();
        DynValue v = script.LoadString(scriptText);

        v.Function.Call();
        
        
    }
}
