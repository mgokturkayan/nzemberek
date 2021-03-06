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

using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using net.zemberek.yapi;
namespace net.zemberek.yapi.ek
{

    /// <summary> ek uretim kuralinin islenmesinde kullanilan sinif icin ortak arayuz.
    /// Her lehce kendi uretim sinifini kullanir.
    /// User: ahmet
    /// Date: Aug 22, 2005
    /// </summary>
    public interface EkUretici
    {
        /**
         * Kelime Cozumleme islemi icin ek uretimi.
         * @param ulanacak
         * @param giris
         * @param bilesenler
         * @return uretilen ek, HarfDizisi cinsinden.
         */
        HarfDizisi cozumlemeIcinEkUret(HarfDizisi ulanacak,
                                       HarfDizisi giris,
                                       List<EkUretimBileseni> bilesenler);

        /**
         * Kelime uretimi icin ek uretimi.
         * @param ulanacak
         * @param sonrakiEk
         * @param bilesenler
         * @return uretilen ek, HarfDizisi cinsinden.
         */
        HarfDizisi olusumIcinEkUret(HarfDizisi ulanacak,
                                    Ek sonrakiEk,
                                    List<EkUretimBileseni> bilesenler);

        /**
         * Ek bilesenlerini kullarak bir ekin hangi harflerle baslayacagini kestirip sonuclari
         * bir set icerisinde dondurur.
         * @param bilesenler
         * @return olasi baslangic harfleri bir Set icerisinde.
         */
        Set<TurkceHarf> olasiBaslangicHarfleri(List<EkUretimBileseni> bilesenler);
    }


    /**
 * Turk dilleri icin cesitli uretim kurallarini belirler. Bazi kurallar sadece belli dillerde
 * kullanilir.
 */
    public enum EkUretimKurali
    {
        SESLI_AE,
        SESLI_AA,
        SESLI_IU,
        SESSIZ_Y,
        SERTLESTIR,
        KAYNASTIR,
        HARF
    }

}