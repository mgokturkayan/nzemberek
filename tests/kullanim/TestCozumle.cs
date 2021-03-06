/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Zemberek Do�al Dil ��leme K�t�phanesi.
 *
 * The Initial Developer of the Original Code is
 * Ahmet A. Ak�n, Mehmet D. Ak�n.
 * Portions created by the Initial Developer are Copyright (C) 2006
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *   Mert Derman
 *   Tankut Tekeli
 * ***** END LICENSE BLOCK ***** */

//V 0.1

using System;
using System.Collections.Generic;
using System.Text;

using net.zemberek.erisim;
using net.zemberek.tr.yapi;
using net.zemberek.yapi;
using net.zemberek.yapi.ek;

using NUnit.Framework;


namespace net.zemberek.tests.kullanim
{
    [TestFixture]
    public class TestCozumle : TemelTest
    {
        private static Zemberek zemberek;

        [SetUp]
        public override void once() 
        {
            base.once();
            zemberek = new Zemberek(new TurkiyeTurkcesi());
        }

        [Test]
        public void testCozumle1()
        {
            //zemberek = new Zemberek(new TurkiyeTurkcesi());
            string str = "kedi";
            Assert.IsTrue(zemberek.kelimeDenetle(str));
            Kelime[] sonuc = zemberek.kelimeCozumle(str);
            Assert.AreEqual(1, sonuc.Length);
            Kok kok = sonuc[0].kok();
            Assert.AreEqual("kedi", kok.icerik());
            List<Ek> ekler = sonuc[0].ekler();
            Assert.AreEqual(1, ekler.Count);
            Ek ek = ekler[0];
            Assert.AreEqual("ISIM_KOK",ek.ad());
        }

        [Test]
        public void testCozumle2()
        {
            //zemberek = new Zemberek(new TurkiyeTurkcesi());
            string str = "kediciklerin";
            Assert.IsTrue(zemberek.kelimeDenetle(str));
            Kelime[] sonuc = zemberek.kelimeCozumle(str);
            Assert.AreEqual(2, sonuc.Length);

            Kok kok = sonuc[0].kok();
            Assert.AreEqual("kedi", kok.icerik());
            List<Ek> ekler = sonuc[0].ekler();
            Assert.AreEqual(4, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_KUCULTME_CIK", ekler[1].ad());
            Assert.AreEqual("ISIM_COGUL_LER", ekler[2].ad());
            Assert.AreEqual("ISIM_TAMLAMA_IN", ekler[3].ad());

            kok = sonuc[1].kok();
            Assert.AreEqual("kedi", kok.icerik());
            ekler = sonuc[1].ekler();
            Assert.AreEqual(4, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_KUCULTME_CIK", ekler[1].ad());
            Assert.AreEqual("ISIM_COGUL_LER", ekler[2].ad());
            Assert.AreEqual("ISIM_SAHIPLIK_SEN_IN", ekler[3].ad());
        }

        [Test]
        public void testCozumle3()
        {
            //zemberek = new Zemberek(new TurkiyeTurkcesi());
            string str = "getirttirebilirsiniz";
            Assert.IsTrue(zemberek.kelimeDenetle(str));
            Kelime[] sonuc = zemberek.kelimeCozumle(str);
            Assert.AreEqual(1, sonuc.Length);

            Kok kok = sonuc[0].kok();
            Assert.AreEqual("getir", kok.icerik());
            Assert.AreEqual(KelimeTipi.FIIL, kok.tip());
            List<Ek> ekler = sonuc[0].ekler();
            Assert.AreEqual(6, ekler.Count);
            Assert.AreEqual("FIIL_KOK", ekler[0].ad());
            Assert.AreEqual("FIIL_OLDURGAN_T", ekler[1].ad());
            Assert.AreEqual("FIIL_ETTIRGEN_TIR", ekler[2].ad());
            Assert.AreEqual("FIIL_YETENEK_EBIL", ekler[3].ad());
            Assert.AreEqual("FIIL_GENISZAMAN_IR", ekler[4].ad());
            Assert.AreEqual("FIIL_KISI_SIZ", ekler[5].ad());
        }

        [Test]
        public void testCozumle_Suyuyla()
        {
            //zemberek = new Zemberek(new TurkiyeTurkcesi());
            string str = "suyuyla";
            Assert.IsTrue(zemberek.kelimeDenetle(str));
            Kelime[] sonuc = zemberek.kelimeCozumle(str);
            Assert.AreEqual(2, sonuc.Length);
            Kok kok = sonuc[0].kok();
            Assert.AreEqual("su", kok.icerik());
            List<Ek> ekler = sonuc[0].ekler();
            Assert.AreEqual(3, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_TAMLAMA_I", ekler[1].ad());
            Assert.AreEqual("ISIM_BIRLIKTELIK_LE", ekler[2].ad());

            kok = sonuc[1].kok();
            Assert.AreEqual("su", kok.icerik());
            ekler = sonuc[1].ekler();
            Assert.AreEqual(3, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_SAHIPLIK_O_I", ekler[1].ad());
            Assert.AreEqual("ISIM_BIRLIKTELIK_LE", ekler[2].ad());
        }

        [Test]
        public void testCozumle_Sembolu()
        {
            string str = "sembol�";
            Assert.IsTrue(zemberek.kelimeDenetle(str));
            Kelime[] sonuc = zemberek.kelimeCozumle(str);
            Assert.AreEqual(3, sonuc.Length);

            Kok kok = sonuc[0].kok();
            Assert.AreEqual("sembol", kok.icerik());
            List<Ek> ekler = sonuc[0].ekler();
            Assert.AreEqual(2, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_TAMLAMA_I", ekler[1].ad());

            kok = sonuc[1].kok();
            Assert.AreEqual("sembol", kok.icerik());
            ekler = sonuc[1].ekler();
            Assert.AreEqual(2, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_BELIRTME_I", ekler[1].ad());

            kok = sonuc[2].kok();
            Assert.AreEqual("sembol", kok.icerik());
            ekler = sonuc[2].ekler();
            Assert.AreEqual(2, ekler.Count);
            Assert.AreEqual("ISIM_KOK", ekler[0].ad());
            Assert.AreEqual("ISIM_SAHIPLIK_O_I", ekler[1].ad());
         }
    }
}
