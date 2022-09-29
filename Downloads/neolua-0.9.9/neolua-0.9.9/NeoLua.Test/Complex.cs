﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo.IronLua;

namespace LuaDLR.Test
{
  public class ComplexTestClass
  {
    public static T GenericSimple<T>(T i)
    {
      return i;
    } // proc Test

    public static string GenericSimple(string i)
    {
      return i;
    } // proc Test
  } // class ComplexTestClass

  [TestClass]
  public class ComplexStructures : TestHelper
  {
    [TestMethod]
    public void Generics01()
    {
      TestCode(GetLines("Lua.Generics01.lua"), 3);
    } // proc Generics01

    [TestMethod]
    public void Generics02()
    {
      TestCode("return clr.LuaDLR.Test.ComplexTestClass:GenericSimple(3)", 3);
      TestCode("return clr.LuaDLR.Test.ComplexTestClass:GenericSimple('3')", "3");
    } // proc Generics02

    private delegate string TestDelegate(int value);

    [TestMethod]
    public void Delegate01()
    {
      using (Lua l = new Lua())
      {
        l.PrintExpressionTree = true;
        TestDelegate dlg = l.CreateLambda<TestDelegate>("Test", "return value:ToString();");
        string sR = dlg(3);
        Assert.IsTrue(sR == "3");
      }
    } // proc Delegate01

    [TestMethod]
    public void Delegate02()
    {
      using (Lua l = new Lua())
      {
        l.PrintExpressionTree = true;
        var dlg = l.CreateLambda<Func<int, int, int>>("Test", "return arg1 + arg2");
        Assert.IsTrue(dlg(1, 2) == 3);
      }
    } // proc Delegate02

    [TestMethod]
    public void Delegate03()
    {
      using (Lua l = new Lua())
      {
        l.PrintExpressionTree = true;
        var dlg = l.CreateLambda<Func<int, int, int>>("Test", "return a + b", "a", "b");
        Assert.IsTrue(dlg(1, 2) == 3);
      }
    } // proc Delegate03

    [TestMethod]
    public void Coroutines01()
    {
      TestCode(GetLines("Lua.Coroutines01.lua"));
    }
  } // class ComplexStructures
}
