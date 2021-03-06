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
using System.Text;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using Iesi.Collections;
using net.zemberek.yapi;
using net.zemberek.yapi.ek;
using net.zemberek.yapi.kok;


namespace net.zemberek.javaporttemp
{
    public abstract class Collections
    {
        public static readonly List<object> EMPTY_LIST = new List<object>();
        public static readonly List<Kelime> EMPTY_LIST_KELIME = new List<Kelime>();
        public static readonly Set<Ek> EMPTY_SET = new HashedSet<Ek>();// (System.Collections.IList)System.Collections.ArrayList.ReadOnly(new System.Collections.ArrayList());
        public static readonly Set<String> EMPTY_SET_STRING = new HashedSet<String>();
        public static readonly Kelime[] BOS_KELIME_DIZISI = new Kelime[0];
    }
    /// <summary>
    /// imported from java.lang.CharSequence
    /// </summary>

    //public interface CharSequence
    //{
    //    /**
    //     * Returns the length of this character sequence.  The length is the number
    //     * of 16-bit <code>char</code>s in the sequence.</p>
    //     * @return  the number of <code>char</code>s in this sequence
    //     */
    //    int length();

    //    /**
    //     * Returns the <code>char</code> value at the specified index.  An index ranges from zero
    //     * to <tt>length() - 1</tt>.  The first <code>char</code> value of the sequence is at
    //     * index zero, the next at index one, and so on, as for array
    //     * indexing. </p>
    //     *
    //     * <p>If the <code>char</code> value specified by the index is a
    //     * <a href="Character.html#unicode">surrogate</a>, the surrogate
    //     * value is returned.
    //     *
    //     * @param   index   the index of the <code>char</code> value to be returned
    //     *
    //     * @return  the specified <code>char</code> value
    //     *
    //     * @throws  IndexOutOfBoundsException
    //     *          if the <tt>index</tt> argument is negative or not less than
    //     *          <tt>length()</tt>
    //     */
    //    char charAt(int index);

    //    /**
    //     * Returns a new <code>CharSequence</code> that is a subsequence of this sequence.
    //     * The subsequence starts with the <code>char</code> value at the specified index and
    //     * ends with the <code>char</code> value at index <tt>end - 1</tt>.  The length
    //     * (in <code>char</code>s) of the
    //     * returned sequence is <tt>end - start</tt>, so if <tt>start == end</tt>
    //     * then an empty sequence is returned. </p>
    //     * 
    //     * @param   start   the start index, inclusive
    //     * @param   end     the end index, exclusive
    //     *
    //     * @return  the specified subsequence
    //     *
    //     * @throws  IndexOutOfBoundsException
    //     *          if <tt>start</tt> or <tt>end</tt> are negative,
    //     *          if <tt>end</tt> is greater than <tt>length()</tt>,
    //     *          or if <tt>start</tt> is greater than <tt>end</tt>
    //     */
    //    CharSequence subSequence(int start, int end);

    //    /**
    //     * Returns a string containing the characters in this sequence in the same
    //     * order as this sequence.  The length of the string will be the length of
    //     * this sequence. </p>
    //     *
    //     * @return  a string consisting of exactly this sequence of characters
    //     */
    //    String ToString();
    //}

}
