﻿using System;
using Config.cs;
using System.Reflection;
using Config.cs;

namespace Config.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new Serializer(typeof(TestClass),
                new SerializeOption()
                {
                    EnumAsString = false,
                    BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static
                });
            var serialized = serializer.Serialize();
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(serialized));
            TestClass.value1 = 3;
            TestClass.value2 = "def";
            TestClass.alphabet = Alphabet.C;
            TestClass.ChildClass.value = 1.5f;
            TestClass.ChildClass.GrancChildClass.message = "みよーん.";
            serialized = serializer.Serialize();
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(serialized));
            TestClass.value1 = 5;
            TestClass.value2 = "abc";
            TestClass.alphabet = Alphabet.B;
            TestClass.ChildClass.value = 3.141592653589793238462643383279f;
            var serialized2 = serializer.Serialize();
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(serialized2));
            serializer.Deserialize(serialized);
            serialized = serializer.Serialize();
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(serialized));
        }
    }
    public static class TestClass
    {
        public static int value1 = 1;
        public static string value2 = "abc";
        public static Alphabet alphabet = Alphabet.B;

        public static class ChildClass
        {
            public static float value = 1;
            public static class GrancChildClass
            {
                public static string message = "hello";
            }
        }
    }
    public enum Alphabet
    {
        A,B,C
    }
}
