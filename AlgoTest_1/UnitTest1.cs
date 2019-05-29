using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {

        // Проверка на работоспособность метода Get()
        // Одно значение
        //
        [TestMethod]
        public void TestA_Get_1()
        {
            int size = 16;
            string key = "one";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            nat.Put(key, 111);

            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (nat.values[i] != 111) continue;
                index = i;
                break;
            }

            Assert.AreEqual(nat.values[index], nat.Get(key));
        }


        // Проверка на работоспособность метода Get()
        // Полное заполнение
        //
        [TestMethod]
        public void TestA_Get_2()
        {
            int size = 4;
            string key1 = "one";
            string key2 = "two";
            string key3 = "three";
            string key4 = "four";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            nat.Put(key1, 614);
            nat.Put(key2, 921);
            nat.Put(key3, 53);
            nat.Put(key4, 910);

            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            int index4 = 0;
            for (int i = 0; i < size; i++)
            {
                if (nat.values[i] == 0) continue;
                else if (nat.slots[i] == key1) index1 = i;
                else if (nat.slots[i] == key2) index2 = i;
                else if (nat.slots[i] == key3) index3 = i;
                else if (nat.slots[i] == key4) index4 = i;
                else break;
            }

            Assert.AreEqual(nat.values[index1], nat.Get("one"));
            Assert.AreEqual(nat.values[index2], nat.Get("two"));
            Assert.AreEqual(nat.values[index3], nat.Get("three"));
            Assert.AreEqual(nat.values[index4], nat.Get("four"));
        }

        [TestMethod]
        public void TestA_Put_1()
        {
            NativeDictionary<int> nat = new NativeDictionary<int>(16);

            nat.Put("one", 1);
            
            Assert.AreEqual(1, nat.Get("one"));
        }


        [TestMethod]
        public void TestA_Put_2()
        {
            NativeDictionary<int> nat = new NativeDictionary<int>(16);

            nat.Put("one", 1);
            nat.Put("two", 5);
            nat.Put("three", 12);
            nat.Put("four", 20);
            nat.Put("five", 34);

            Assert.AreEqual(1, nat.Get("one"));
            Assert.AreEqual(5, nat.Get("two"));
            Assert.AreEqual(12, nat.Get("three"));
            Assert.AreEqual(20, nat.Get("four"));
            Assert.AreEqual(34, nat.Get("five"));
        }


        [TestMethod]
        public void TestA_Put_3()
        {
            NativeDictionary<int> nat = new NativeDictionary<int>(10);

            nat.Put("cat1", 1);
            nat.Put("cat2", 3);
            nat.Put("cat3", 5);
            nat.Put("cat4", 7);
            nat.Put("cat5", 9);
            nat.Put("cat6", 11);
            nat.Put("cat7", 13);
            nat.Put("cat8", 15);
            nat.Put("cat9", 17);
            nat.Put("cat10", 19);
            nat.Put("cat11", 21);

            
            Assert.AreEqual(1, nat.Get("cat1"));
            Assert.AreEqual(3, nat.Get("cat2"));
            Assert.AreEqual(5, nat.Get("cat3"));
            Assert.AreEqual(7, nat.Get("cat4"));
            Assert.AreEqual(9, nat.Get("cat5"));
            Assert.AreEqual(11, nat.Get("cat6"));
            Assert.AreEqual(13, nat.Get("cat7"));
            Assert.AreEqual(15, nat.Get("cat8"));
            Assert.AreEqual(17, nat.Get("cat9"));
            Assert.AreEqual(19, nat.Get("cat10"));
            Assert.AreEqual(0, nat.Get("cat11"));
        }
    }
}
