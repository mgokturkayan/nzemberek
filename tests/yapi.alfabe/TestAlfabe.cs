﻿using System;
using System.Collections.Generic;
using System.Text;
using net.zemberek.yapi;
using NUnit.Framework;

namespace net.zemberek.tests.yapi.alfabe
{
    [TestFixture]
    public class TestAlfabe
    {
    
        private Alfabe alfabe;

        [SetUp]
        public void setUp() {
            alfabe = new Alfabe(@"..\..\tests\yapi\test_harf_tr.txt","tr");
        }

        [Test]
        public void testHarfErisim() {
            TurkceHarf harf = new TurkceHarf('a', 1);
            harf.setSesli(true);

            TurkceHarf okunan = alfabe.harf('a');
            Assert.AreEqual(harf.charDeger(), okunan.charDeger());
            Assert.IsTrue(harf.sesliMi());

        }

        [Test]
        public void testAyikla() {
            String kel = "a'ghh-";
            Assert.AreEqual(alfabe.ayikla(kel), "aghh");
        }
        
        [Test]
        public void testTurkceMi() {
            String kel = "wws$$dgsdashj";
            Assert.IsTrue(!alfabe.cozumlemeyeUygunMu(kel));
            kel = "merhaba";
            Assert.IsTrue(alfabe.cozumlemeyeUygunMu(kel));
        }

        [Test]
        [Ignore("Hatali yazilmis gibi, kucuk (noktasiz) i giriyor buyuk yapip buyuk noktali i ile karsilastiriyor")]
        public void testLowerUpperCase() {
            TurkceHarf ii = alfabe.harf(Alfabe.CHAR_ii);
            TurkceHarf harfI = alfabe.buyukHarf(ii);
            Assert.AreEqual(harfI.charDeger(), Alfabe.CHAR_II);
            TurkceHarf i = alfabe.harf('i');
            TurkceHarf harfBuyuki = alfabe.buyukHarf(i);
            Assert.AreEqual(harfBuyuki.charDeger(), 'I');
        }
    }
}