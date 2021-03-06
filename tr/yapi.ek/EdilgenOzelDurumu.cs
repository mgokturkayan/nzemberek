﻿/* ***** BEGIN LICENSE BLOCK *****
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
 * The Original Code is Zemberek Doğal Dil İşleme Kütüphanesi.
 *
 * The Initial Developer of the Original Code is
 * Ahmet A. Akın, Mehmet D. Akın.
 * Portions created by the Initial Developer are Copyright (C) 2006
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *   Mert Derman
 *   Tankut Tekeli
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Text;
using net.zemberek.yapi;
using net.zemberek.yapi.ek;
using net.zemberek.islemler.cozumleme;
using net.zemberek.tr.yapi.kok;

namespace net.zemberek.tr.yapi.ek
{
/**
 * edilgen cati eki -il ya da -in seklinde olusabilir. (yap-il-mak, gel-in-mek)
 * ayrica fiillerde sesli dusmesi oldugu durumlarda ozel sekilde uretilmesi gerekir.
 * (kavurmak -> kavr-ul-mak, kavr-Il-mak degil.)
 * User: ahmet
 * Date: Aug 29, 2005
 */
public class EdilgenOzelDurumu : EkOzelDurumu {

    private Alfabe alfabe;
    private TurkceSesliUretici sesliUretici;

    public EdilgenOzelDurumu(Alfabe alfabe ) {
        this.alfabe = alfabe;
        this.sesliUretici = new TurkceSesliUretici(alfabe);
    }

    public override HarfDizisi cozumlemeIcinUret(Kelime kelime, HarfDizisi giris, HarfDizisiKiyaslayici kiyaslayici) {
        TurkceHarf son = kelime.sonHarf();
        if(son.sesliMi())
          return new HarfDizisi(0);
        HarfDizisi sonuc = new HarfDizisi();
        if (kelime.kok().ozelDurumIceriyormu(TurkceKokOzelDurumTipi.FIIL_ARA_SESLI_DUSMESI)) {
            //eger ara sesli dusmesi olmussa eklenecek seslinin dusen sesliye gore
            //belirlenmesi gerekir. yani, "kavurmak" koku ve "kavrulmuS" girisini dusunelim,
            //ara sesli dusmesi ozel durumu nedeniyle "u" harfi kokten duserek "kavr" haline
            //gelir. Ancak koke bu haliyle edilgenlik ekini eklemeye kalkarsak "kavrIlmIS"
            //seklinde yanlis bir kelime ortaya cikardi. Bu nedenle burada dusen eke gore hangi
            // harfin eklenecegi belirleniyor.
            HarfDizisi kok = new HarfDizisi(kelime.kok().icerik(), alfabe);
            TurkceHarf kokAsilSesli = kok.sonSesli();
            sonuc.ekle(sesliUretici.sesliBelirleIU(kokAsilSesli));
        } else
            sonuc.ekle(sesliUretici.sesliBelirleIU(kelime.icerik()));
        if (son.Equals(alfabe.harf('l')))
            sonuc.ekle(alfabe.harf('n'));
        else
            sonuc.ekle(alfabe.harf('l'));
        return sonuc;
    }

    public override HarfDizisi olusumIcinUret(Kelime kelime, Ek sonrakiEk)
    {
       return cozumlemeIcinUret(kelime, null, null);
    }
}
}
