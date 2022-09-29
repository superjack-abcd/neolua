using Neo.IronLua;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using static System.Console;
namespace Test
{
    public static class Program
    {


        private static Neo.IronLua.ILuaDebug debugNeoLua = Neo.IronLua.Lua.DefaultDebugEngine;


        public static void LuaTest(int i)
        {
           // v++;
        }

        public static object LuaEcho(object e)
        {
           // v++;
            return e;
        }



        private static double ExecuteNeoLuaCompiled1(string sScript, int iLoops)
        {
            using (Neo.IronLua.Lua lua = new Neo.IronLua.Lua())
            {
                Neo.IronLua.LuaChunk chunk = lua.CompileChunk(sScript, "test", debugNeoLua);
                Neo.IronLua.LuaGlobal g = lua.CreateEnvironment();
                g["test"] = new Action<int>(LuaTest);
                g["echo"] = new Func<object, object>(LuaEcho);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < iLoops; i++)
                    g.DoChunk(chunk);
                return sw.ElapsedMilliseconds / (double)iLoops;
            }
        }


        private static double ExecuteNeoLuaCompiled(string sScript, int iLoops)
        {
            using (Neo.IronLua.Lua lua = new Neo.IronLua.Lua())
            {
                Neo.IronLua.LuaChunk chunk = lua.CompileChunk(sScript, "test", debugNeoLua);
                Neo.IronLua.LuaGlobal g = lua.CreateEnvironment();

                g.DoChunk(chunk);
                return 0;
            }
        }


        public static void Main(string[] args)
        {

            


           ExecuteNeoLuaCompiled(File.ReadAllText(@"C:\Users\Jack\Desktop\lua\test1.lua"), 1);


            debugNeoLua = Neo.IronLua.Lua.DefaultDebugEngine;

        }
    }
}