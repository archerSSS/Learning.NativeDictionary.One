using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {

        // Проверка на работоспособность метода Get();
        // Одно значение;
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


        // Проверка на работоспособность метода Get();
        // Полное заполнение;
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

        
        // Проверка метода Get();
        // Добавление двух одинаковых ключей с разными значениями;
        // Возвращается значение ближайшего для хэш-функции ключа;
        //
        [TestMethod]
        public void TestA_Get_3()
        {
            int size = 4;
            string key1 = "one";
            string key2 = "one";
            int index1 = 0;
            int index2 = 0;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            nat.Put(key1, 1);
            nat.Put(key2, 2);
            
            for (int i = 0; i < size; i++)
            {
                if (nat.values[i] == 2) index2 = i;
            }

            Assert.AreEqual(0, index2);
        }

        // Проверка на работоспособность метода HashFun();
        // Добавление одного ключа;
        // Размер словаря =4;
        //
        [TestMethod]
        public void TestA_Hash_1()
        {
            int size = 4;
            string key = "one";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            int index1 = nat.HashFun(key) % size;
            nat.Put(key, 1);

            int index2 = 0;
            for (int i = 0; i < size; i++)
                if (nat.values[i] != 0) index2 = i;

            Assert.AreEqual(index1, index2);
        }


        // Проверка на работоспособность метода HashFun();
        // Добавление одного ключа;
        // Размер словаря =16;
        //
        [TestMethod]
        public void TestA_Hash_2()
        {
            int size = 16;
            string key = "one";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            int index1 = nat.HashFun(key) % size;
            nat.Put(key, 1);

            int index2 = 0;
            for (int i = 0; i < size; i++)
                if (nat.values[i] != 0) index2 = i;

            Assert.AreEqual(index1, index2);
        }


        // Проверка на работоспособность метода HashFun();
        // Генерация индексов для двух одинаковых ключей;
        // Размер словаря =16;
        //
        [TestMethod]
        public void TestA_Hash_3()
        {
            int size = 16;
            string key1 = "one";
            string key2 = "one";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            int index1 = nat.HashFun(key1);
            int index2 = nat.HashFun(key2);
            
            Assert.AreEqual(true, index1 == index2);
        }


        // Проверка на работоспособность метода HashFun();
        // Генерация индексов для трех разных ключей;
        // Специфические строковые значения в качестве ключей;
        // Предел значений индексов
        // Размер словаря =16;
        //
        [TestMethod]
        public void TestA_Hash_4()
        {
            int size = 16;
            string key1 = "Blitz krieg pop";
            string key2 = " ";
            string key3 = "111111";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            int index1 = nat.HashFun(key1);
            int index2 = nat.HashFun(key2);
            int index3 = nat.HashFun(key3);

            Assert.AreEqual(true, index1 > -1 && index1 < size-1);
            Assert.AreEqual(true, index2 > -1 && index2 < size - 1);
            Assert.AreEqual(true, index3 > -1 && index3 < size - 1);
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


        [TestMethod]
        public void TestA_Put_4()
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
        public void TestA_IsKey_1()
        {
            int size = 16;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            nat.Put("one", 1);

            Assert.AreEqual(true, nat.IsKey("one"));
        }


        [TestMethod]
        public void TestA_IsKey_2()
        {
            int size = 16;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            for (int i = 0; i < size; i++)
                nat.Put("key" + i, i);

            for (int i = 0; i < size; i++)
                Assert.AreEqual(true, nat.IsKey("key"+1));
        }


        [TestMethod]
        public void TestA_IsKey_3()
        {
            int size = 16;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            Assert.AreEqual(false, nat.IsKey("one"));
            Assert.AreEqual(false, nat.IsKey("key"));
        }


        [TestMethod]
        public void TestB_Put_1()
        {
            NativeDictionary<string> nat = new NativeDictionary<string>(16);

            nat.Put("one", "1");

            Assert.AreEqual("1", nat.Get("one"));
        }


        [TestMethod]
        public void TestB_Put_2()
        {
            NativeDictionary<string> nat = new NativeDictionary<string>(16);

            nat.Put("one", "pet");
            nat.Put("two", "fat");
            nat.Put("three", "bat");
            nat.Put("four", "dot");
            nat.Put("five", "bed");

            Assert.AreEqual("pet", nat.Get("one"));
            Assert.AreEqual("fat", nat.Get("two"));
            Assert.AreEqual("bat", nat.Get("three"));
            Assert.AreEqual("dot", nat.Get("four"));
            Assert.AreEqual("bed", nat.Get("five"));
        }


        [TestMethod]
        public void TestB_Put_3()
        {
            NativeDictionary<string> nat = new NativeDictionary<string>(10);

            nat.Put("cat1", "pet");
            nat.Put("cat2", "fat");
            nat.Put("cat3", "bat");
            nat.Put("cat4", "dot");
            nat.Put("cat5", "bed");
            nat.Put("cat6", "toy");
            nat.Put("cat7", "pay");
            nat.Put("cat8", "day");
            nat.Put("cat9", "say");
            nat.Put("cat10", "key");
            nat.Put("cat11", "tea");

            Assert.AreEqual("pet", nat.Get("cat1"));
            Assert.AreEqual("fat", nat.Get("cat2"));
            Assert.AreEqual("bat", nat.Get("cat3"));
            Assert.AreEqual("dot", nat.Get("cat4"));
            Assert.AreEqual("bed", nat.Get("cat5"));
            Assert.AreEqual("toy", nat.Get("cat6"));
            Assert.AreEqual("pay", nat.Get("cat7"));
            Assert.AreEqual("day", nat.Get("cat8"));
            Assert.AreEqual("say", nat.Get("cat9"));
            Assert.AreEqual("key", nat.Get("cat10"));
            Assert.AreEqual(null, nat.Get("cat11"));
        }


        [TestMethod]
        public void TestB_Put_4()
        {
            NativeDictionary<string> nat = new NativeDictionary<string>(16);

            nat.Put("one", "1");
            nat.Put("two", "5");
            nat.Put("three", "12");
            nat.Put("four", "20");
            nat.Put("five", "34");

            Assert.AreEqual("1", nat.Get("one"));
            Assert.AreEqual("5", nat.Get("two"));
            Assert.AreEqual("12", nat.Get("three"));
            Assert.AreEqual("20", nat.Get("four"));
            Assert.AreEqual("34", nat.Get("five"));
        }
    }
}
