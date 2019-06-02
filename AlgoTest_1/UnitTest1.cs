using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1_FirstStartTest()
        {
            int size = 16;

            string key1 = "key1";
            int item1 = 1;

            string key2 = "key2";
            string item2 = "1";

            string key3 = "key3";
            BitBag item3 = new BitBag(1);

            string key4 = "key4";
            BitBagE item4 = new BitBagE(1);
            
            NativeDictionary<int> nat1 = new NativeDictionary<int>(size);
            NativeDictionary<string> nat2 = new NativeDictionary<string>(size);
            NativeDictionary<BitBag> nat3 = new NativeDictionary<BitBag>(size);

            nat1.Put(key1, item1);
            nat2.Put(key2, item2);
            nat3.Put(key3, item3);
            nat3.Put(key4, item4);

            Assert.AreEqual(true, nat1.IsKey(key1));
            Assert.AreEqual(item1, nat1.Get(key1));

            Assert.AreEqual(true, nat2.IsKey(key2));
            Assert.AreEqual(item2, nat2.Get(key2));

            Assert.AreEqual(true, nat3.IsKey(key3));
            Assert.AreEqual(item3, nat3.Get(key3));
            Assert.AreEqual(true, nat3.IsKey(key4));
            Assert.AreEqual(item4, nat3.Get(key4));
        }


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
            int index1 = 10;
            int index2 = 10;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            nat.Put(key1, 1);
            nat.Put(key2, 2);
            
            for (int i = 0; i < size; i++)
            {
                if (nat.values[i] == 1) index1 = i;
                if (nat.values[i] == 2) index2 = i; 
            }
                
            
            Assert.AreEqual(true, index1 == 10);
            Assert.AreEqual(true, index2 != 10);
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
        public void TestA_Put_5()
        {
            NativeDictionary<int> nat = new NativeDictionary<int>(16);

            nat.Put("1", 1);
            nat.Put("11", 2);
            nat.Put("111", 3);

            Assert.AreEqual(1, nat.Get("1"));
            Assert.AreEqual(2, nat.Get("11"));
            Assert.AreEqual(3, nat.Get("111"));
        }


        [TestMethod]
        public void TestA_IsKey_1()
        {
            int size = 16;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            nat.Put("one", 1);

            Assert.AreEqual(true, nat.IsKey("one"));
            Assert.AreEqual(false, nat.IsKey("on"));
            Assert.AreEqual(false, nat.IsKey("omf"));
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
            Assert.AreEqual(false, nat.IsKey(" "));
        }


        [TestMethod]
        public void TestA_IsKey_4()
        {
            int size = 4;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);
            nat.Put(" ", 1);

            Assert.AreEqual(false, nat.IsKey("one"));
            Assert.AreEqual(false, nat.IsKey("key"));
        }


        [TestMethod]
        public void TestA_IsKey_5()
        {
            int size = 16;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            nat.Put("one", 1);

            Assert.AreEqual(false, nat.IsKey(""));
            Assert.AreEqual(false, nat.IsKey(null));
        }


        [TestMethod]
        public void TestA_IsKey_6()
        {
            int size = 4;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            nat.Put("one", 1);
            nat.Put("two", 2);
            nat.Put("three", 3);
            nat.Put("four", 4);

            Assert.AreEqual(true, nat.IsKey("one"));
            Assert.AreEqual(true, nat.IsKey("two"));
            Assert.AreEqual(true, nat.IsKey("three"));
            Assert.AreEqual(true, nat.IsKey("four"));
        }


        [TestMethod]
        public void TestA_IsKey_7()
        {
            int size = 1;

            NativeDictionary<int> nat1 = new NativeDictionary<int>(size);
            NativeDictionary<int> nat2 = new NativeDictionary<int>(size);
            NativeDictionary<int> nat3 = new NativeDictionary<int>(size);

            nat1.Put("one", 1);
            nat2.Put("two", 1);
            nat3.Put("four", 1);

            Assert.AreEqual(true, nat1.IsKey("one"));
            Assert.AreEqual(true, nat2.IsKey("two"));
            Assert.AreEqual(true, nat3.IsKey("four"));
        }


        [TestMethod]
        public void TestA_IsKey_8()
        {
            int size = 16;
            string key1 = "";

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            Assert.AreEqual(false, nat.IsKey(""));

            nat.Put(key1, 1);

            Assert.AreEqual(true, nat.IsKey(""));
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


        [TestMethod]
        public void TestB_Put_5()
        {
            NativeDictionary<string> nat = new NativeDictionary<string>(16);

            nat.Put("1", "1");
            nat.Put("11", "2");
            nat.Put("111", "3");

            Assert.AreEqual("1", nat.Get("1"));
            Assert.AreEqual("2", nat.Get("11"));
            Assert.AreEqual("3", nat.Get("111"));
        }


        [TestMethod]
        public void TestB_Put_6()
        {
            int size = 16;
            NativeDictionary<string> nat = new NativeDictionary<string>(size);
            nat.Put(null, "1");

            for (int i = 0; i < size; i++)
                Assert.AreEqual(true, nat.values[i] == null);
        }


        [TestMethod]
        public void TestB_Put_7()
        {
            int size = 16;
            NativeDictionary<string> nat = new NativeDictionary<string>(size);
            nat.Put("key", null);

            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(true, nat.values[i] == null);
                if (nat.slots[i] != null)
                {
                    Assert.AreEqual(true, nat.slots[i] != null);
                    nat.values[i] = "notNull";
                    break;
                }
            }
            Assert.AreEqual("notNull", nat.Get("key"));
        }


        [TestMethod]
        public void TestC_Put_1()
        {
            int size = 16;
            NativeDictionary<BitBag> nat = new NativeDictionary<BitBag>(size);

            nat.Put("key1", new BitBag(1));
            nat.Put("key2", new BitBag(2));

            Assert.AreEqual(1, nat.Get("key1").value);
            Assert.AreEqual(2, nat.Get("key2").value);
        }


        [TestMethod]
        public void TestC_Put_2()
        {
            int size = 16;
            BitBag bb1 = new BitBag(1);
            BitBag bb2 = new BitBag(2);
            NativeDictionary<BitBag> nat = new NativeDictionary<BitBag>(size);
            
            nat.Put("key1", bb1);
            nat.Put("key2", bb2);

            Assert.AreEqual(bb1, nat.Get("key1"));
            Assert.AreEqual(bb2, nat.Get("key2"));
        }


        [TestMethod]
        public void TestC_Put_3()
        {
            int size = 16;
            BitBag bb1 = new BitBag(1);
            BitBag bb2 = new BitBag(2);
            BitBag bbe1 = new BitBagE(3);
            NativeDictionary<BitBag> nat = new NativeDictionary<BitBag>(size);

            nat.Put("key1", bb1);
            nat.Put("key2", bb2);
            nat.Put("key3", bbe1);

            Assert.AreEqual(bb1, nat.Get("key1"));
            Assert.AreEqual(bb2, nat.Get("key2"));
            Assert.AreEqual(bbe1, nat.Get("key3"));
        }


        [TestMethod]
        public void TestC_IsKey_1()
        {
            int size = 16;
            BitBag bb1 = new BitBag(1);
            BitBag bb2 = new BitBag(2);
            BitBagE bb3 = new BitBagE(3);
            BitBagE bb4 = new BitBagE(4);
            BitBag bb5 = new BitBag(5);
            BitBag bb6 = new BitBag(6);
            BitBag bb7 = new BitBag(7);
            BitBagE bb8 = new BitBagE(8);
            BitBagE bb9 = new BitBagE(9);
            BitBagE bb10 = new BitBagE(10);
            BitBag bb11 = new BitBag(11);
            BitBagE bb12 = new BitBagE(12);
            BitBag bb13 = new BitBag(13);
            BitBag bb14 = new BitBag(14);
            BitBagE bb15 = new BitBagE(15);
            BitBagE bb16 = new BitBagE(16);

            string key1 = "key1";
            string key2 = "key2";
            string key3 = "key3";
            string key4 = "key4";
            string key5 = "key5";
            string key6 = "key6";
            string key7 = "key7";
            string key8 = "key8";
            string key9 = "key9";
            string key10 = "key10";
            string key11 = "key11";
            string key12 = "key12";
            string key13 = "key13";
            string key14 = "key14";
            string key15 = "key15";
            string key16 = "key16";

            NativeDictionary<BitBag> nat = new NativeDictionary<BitBag>(size);

            nat.Put(key1, bb1);
            nat.Put(key2, bb2);
            nat.Put(key3, bb3);
            nat.Put(key4, bb4);
            nat.Put(key5, bb5);
            nat.Put(key6, bb6);
            nat.Put(key7, bb7);
            nat.Put(key8, bb8);
            nat.Put(key9, bb9);
            nat.Put(key10, bb10);
            nat.Put(key11, bb11);
            nat.Put(key12, bb12);
            nat.Put(key13, bb13);
            nat.Put(key14, bb14);
            nat.Put(key15, bb15);
            nat.Put(key16, bb16);

            Assert.AreEqual(true, nat.IsKey(key1));
            Assert.AreEqual(true, nat.IsKey(key2));
            Assert.AreEqual(true, nat.IsKey(key3));
            Assert.AreEqual(true, nat.IsKey(key4));
            Assert.AreEqual(true, nat.IsKey(key5));
            Assert.AreEqual(true, nat.IsKey(key6));
            Assert.AreEqual(true, nat.IsKey(key7));
            Assert.AreEqual(true, nat.IsKey(key8));
            Assert.AreEqual(true, nat.IsKey(key9));
            Assert.AreEqual(true, nat.IsKey(key10));
            Assert.AreEqual(true, nat.IsKey(key11));
            Assert.AreEqual(true, nat.IsKey(key12));
            Assert.AreEqual(true, nat.IsKey(key13));
            Assert.AreEqual(true, nat.IsKey(key14));
            Assert.AreEqual(true, nat.IsKey(key15));
            Assert.AreEqual(true, nat.IsKey(key16));
        }




        [TestMethod]
        public void TestA_15()
        {
            int size = 8;

            NativeDictionary<int> nat = new NativeDictionary<int>(size);

            nat.Put("1", 1);
            nat.Put("2", 2);
            nat.Put("3", 3);
            nat.Put("4", 4);
            nat.Put("5", 5);
            nat.Put("6", 6);
            nat.Put("7", 7);
            nat.Put("8", 8);

            Assert.AreEqual(true, nat.IsKey("1"));
            Assert.AreEqual(true, nat.IsKey("2"));
            Assert.AreEqual(true, nat.IsKey("3"));
            Assert.AreEqual(true, nat.IsKey("4"));
            Assert.AreEqual(true, nat.IsKey("5"));
            Assert.AreEqual(true, nat.IsKey("6"));
            Assert.AreEqual(true, nat.IsKey("7"));
            Assert.AreEqual(true, nat.IsKey("8"));
            
            for (int i = 0; i < 100000; i++)
                nat.Put("a" + 1, 7);

            Assert.AreEqual(true, nat.IsKey("1"));
            Assert.AreEqual(true, nat.IsKey("2"));
            Assert.AreEqual(true, nat.IsKey("3"));
            Assert.AreEqual(true, nat.IsKey("4"));
            Assert.AreEqual(true, nat.IsKey("5"));
            Assert.AreEqual(true, nat.IsKey("6"));
            Assert.AreEqual(true, nat.IsKey("7"));
            Assert.AreEqual(true, nat.IsKey("8"));

            for (int i = 0; i < 100000; i++)
                nat.Put("7", 10 + i);

            Assert.AreEqual(true, nat.IsKey("1"));
            Assert.AreEqual(true, nat.IsKey("2"));
            Assert.AreEqual(true, nat.IsKey("3"));
            Assert.AreEqual(true, nat.IsKey("4"));
            Assert.AreEqual(true, nat.IsKey("5"));
            Assert.AreEqual(true, nat.IsKey("6"));
            Assert.AreEqual(true, nat.IsKey("7"));
            Assert.AreEqual(true, nat.IsKey("8"));

            for (int i = 1; i < 100000; i++)
                nat.Put("" + i, 10 + i);

            Assert.AreEqual(true, nat.IsKey("1"));
            Assert.AreEqual(true, nat.IsKey("2"));
            Assert.AreEqual(true, nat.IsKey("3"));
            Assert.AreEqual(true, nat.IsKey("4"));
            Assert.AreEqual(true, nat.IsKey("5"));
            Assert.AreEqual(true, nat.IsKey("6"));
            Assert.AreEqual(true, nat.IsKey("7"));
            Assert.AreEqual(true, nat.IsKey("8"));
        }

    }
}
