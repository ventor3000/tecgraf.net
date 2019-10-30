using System;
using System.Collections.Generic;
using System.Text;

namespace Tecgraf
{

    /// <summary>
    /// Key definitions.
    /// From 32 to 126, all character sets are equal,
    /// the key code is the same as the ASCii character code.
    /// </summary>
    public enum Key
    {
        None = '\0',  /* .NET specific addition */
        SP = ' ',   /* 32 (0x20) */
        exclam = '!',   /* 33 */
        quotedbl = '\"',  /* 34 */
        numbersign = '#',   /* 35 */
        dollar = '$',   /* 36 */
        percent = '%',   /* 37 */
        ampersand = '&',   /* 38 */
        apostrophe = '\'',  /* 39 */
        parentleft = '(',   /* 40 */
        parentright = ')',   /* 41 */
        asterisk = '*',   /* 42 */
        plus = '+',   /* 43 */
        comma = ',',   /* 44 */
        minus = '-',   /* 45 */
        period = '.',   /* 46 */
        slash = '/',   /* 47 */
        D0 = '0',   /* 48 (0x30) */
        D1 = '1',   /* 49 */
        D2 = '2',   /* 50 */
        D3 = '3',   /* 51 */
        D4 = '4',   /* 52 */
        D5 = '5',   /* 53 */
        D6 = '6',   /* 54 */
        D7 = '7',   /* 55 */
        D8 = '8',   /* 56 */
        D9 = '9',   /* 57 */
        colon = ':',   /* 58 */
        semicolon = ';',   /* 59 */
        less = '<',   /* 60 */
        equal = '=',   /* 61 */
        greater = '>',   /* 62 */
        question = '?',   /* 63 */
        at = '@',   /* 64 */
        A = 'A',   /* 65 (0x41) */
        B = 'B',   /* 66 */
        C = 'C',   /* 67 */
        D = 'D',   /* 68 */
        E = 'E',   /* 69 */
        F = 'F',   /* 70 */
        G = 'G',   /* 71 */
        H = 'H',   /* 72 */
        I = 'I',   /* 73 */
        J = 'J',   /* 74 */
        K = 'K',   /* 75 */
        L = 'L',   /* 76 */
        M = 'M',   /* 77 */
        N = 'N',   /* 78 */
        O = 'O',   /* 79 */
        P = 'P',   /* 80 */
        Q = 'Q',   /* 81 */
        R = 'R',   /* 82 */
        S = 'S',   /* 83 */
        T = 'T',   /* 84 */
        U = 'U',   /* 85 */
        V = 'V',   /* 86 */
        W = 'W',   /* 87 */
        X = 'X',   /* 88 */
        Y = 'Y',   /* 89 */
        Z = 'Z',   /* 90 */
        bracketleft = '[',   /* 91 */
        backslash = '\\',  /* 92 */
        bracketright = ']',  /* 93 */
        circum = '^',   /* 94 */
        underscore = '_',   /* 95 */
        grave = '`',   /* 96 */
        a = 'a',   /* 97 (0x61) */
        b = 'b',   /* 98 */
        c = 'c',   /* 99 */
        d = 'd',   /* 100 */
        e = 'e',   /* 101 */
        f = 'f',   /* 102 */
        g = 'g',   /* 103 */
        h = 'h',   /* 104 */
        i = 'i',   /* 105 */
        j = 'j',   /* 106 */
        k = 'k',   /* 107 */
        l = 'l',   /* 108 */
        m = 'm',   /* 109 */
        n = 'n',   /* 110 */
        o = 'o',   /* 111 */
        p = 'p',   /* 112 */
        q = 'q',   /* 113 */
        r = 'r',   /* 114 */
        s = 's',   /* 115 */
        t = 't',   /* 116 */
        u = 'u',   /* 117 */
        v = 'v',   /* 118 */
        w = 'w',   /* 119 */
        x = 'x',   /* 120 */
        y = 'y',   /* 121 */
        z = 'z',   /* 122 */
        braceleft = '{',   /* 123 */
        bar = '|',   /* 124 */
        braceright = '}',   /* 125 */
        tilde = '~',   /* 126 (0x7E) */

        BS = '\b',       /* 8 */
        TAB = '\t',       /* 9 */
        LF = '\n',       /* 10 (0x0A) not a real key, is a combination of CR with a modifier, just to document */
        CR = '\r',       /* 13 (0x0D) */

        PAUSE = 0xFF13,
        ESC = 0xFF1B,
        HOME = 0xFF50,
        LEFT = 0xFF51,
        UP = 0xFF52,
        RIGHT = 0xFF53,
        DOWN = 0xFF54,
        PGUP = 0xFF55,
        PGDN = 0xFF56,
        END = 0xFF57,
        MIDDLE = 0xFF0B,
        Print = 0xFF61,
        INS = 0xFF63,
        Menu = 0xFF67,
        DEL = 0xFFFF,
        F1 = 0xFFBE,
        F2 = 0xFFBF,
        F3 = 0xFFC0,
        F4 = 0xFFC1,
        F5 = 0xFFC2,
        F6 = 0xFFC3,
        F7 = 0xFFC4,
        F8 = 0xFFC5,
        F9 = 0xFFC6,
        F10 = 0xFFC7,
        F11 = 0xFFC8,
        F12 = 0xFFC9,

        /* no Shift/Ctrl/Alt */
        LSHIFT = 0xFFE1,
        RSHIFT = 0xFFE2,
        LCTRL = 0xFFE3,
        RCTRL = 0xFFE4,
        LALT = 0xFFE9,
        RALT = 0xFFEA,

        NUM = 0xFF7F,
        SCROLL = 0xFF14,
        CAPS = 0xFFE5,

        /* Also, these are the same as the Latin-1 definition */

        ccedilla = 0x00E7,
        Ccedilla = 0x00C7,
        acute = 0x00B4,  /* no Shift/Ctrl/Alt */
        diaeresis = 0x00A8

    }

    public static class IupKey
    {
        /// <summary>
        /// Decorate a key with the shift modifier.
        /// </summary>
        public static Key ModShift(Key k) { return k | (Key)0x10000000; }

        /// <summary>
        /// Decorate a key with the control modifier.
        /// </summary>
        public static Key ModCtrl(Key k) { return k | (Key)0x20000000; }

        /// <summary>
        /// Decorate a key with the alt modifier.
        /// </summary>
        public static Key ModAlt(Key k) { return k | (Key)0x40000000; }

        /// <summary>
        /// Decorate a key with the sys modifier (Windows key or apple key)
        /// </summary>
        public static Key ModSys(Key k) { unchecked { return k | (Key)0x80000000; } } /* Win or Apple */

        /// <summary>
        /// Undecorate a key from any modifiers.
        /// </summary>
        public static Key ModNone(Key k) { return k & (Key)0x0fffffff; }

        //TODO: some more utils from iupkey.h
    }




    /*        
    public enum Key
    {
        None=0,
        SP = ' ',
        exclam = '!',
        numbersign = '#',
        excalm = '!',
        quotedbl = '\"',
        percent = '%',
        ampersand = '&',
        apostrophe = '\'',
        parentleft = '(',
        parentright = ')',
        asterisk = '*',
        plus = '+',
        comma = ',',
        minus = '-',
        period = '.',
        slash = '/',
        D0 = '0',
        D1 = '1',
        D2 = '2',
        D3 = '3',
        D4 = '4',
        D5 = '5',
        D6 = '6',
        D7 = '7',
        D8 = '8',
        D9 = '9',
        colon = ':',
        semicolon = ';',
        less = '<',
        equal = '=',
        greater = '>',
        question = '?',
        at = '@',
        A = 'A',
        B = 'B',
        C = 'C',
        D = 'D',
        E = 'E',
        F = 'F',
        G = 'G',
        H = 'H',
        I = 'I',
        J = 'J',
        K = 'K',
        L = 'L',
        M = 'M',
        N = 'N',
        O = 'O',
        P = 'P',
        Q = 'Q',
        R = 'R',
        S = 'S',
        T = 'T',
        U = 'U',
        V = 'V',
        W = 'W',
        X = 'X',
        Y = 'Y',
        Z = 'Z',
        bracketleft = '[',
        backslash = '\\',
        bracketright = ']',
        circum = '^',
        underscore = '_',
        grave = '`',
        a = 'a',
        b = 'b',
        c = 'c',
        d = 'd',
        e = 'e',
        f = 'f',
        g = 'g',
        h = 'h',
        i = 'i',
        j = 'j',
        k = 'k',
        l = 'l',
        m = 'm',
        n = 'n',
        o = 'o',
        p = 'p',
        q = 'q',
        r = 'r',
        s = 's',
        t = 't',
        u = 'u',
        v = 'v',
        w = 'w',
        x = 'x',
        y = 'y',
        z = 'z',
        braceleft = '{',
        bar = '|',
        braceright = '}',
        tilde = '~',

        BS = '\b',
        TAB = '\t',
        LF = '\n',
        CR = '\r',

        //XKeys
        HOME = 1 | 128,
        UP = 2 | 128,
        PGUP = 3 | 128,
        LEFT = 4 | 128,
        MIDDLE = 5 | 128,
        RIGHT = 6 | 128,
        END = 7 | 128,
        DOWN = 8 | 128,
        PGDN = 9 | 128,
        INS = 10 | 128,
        DEL = 11 | 128,
        PAUSE = 12 | 128,
        ESC = 13 | 128,
        Ccedilla = 14 | 128,
        F1 = 15 | 128,
        F2 = 16 | 128,
        F3 = 17 | 128,
        F4 = 18 | 128,
        F5 = 19 | 128,
        F6 = 20 | 128,
        F7 = 21 | 128,
        F8 = 22 | 128,
        F9 = 23 | 128,
        F10 = 24 | 128,
        F11 = 25 | 128,
        F12 = 26 | 128,
        Print = 27 | 128,
        Menu = 28 | 128,
        acute = 29 | 128,

        //ShiftX
        sHOME = HOME | 256,
        sUP = UP | 256,
        sPGUP = PGUP | 256,
        sLEFT = LEFT | 256,
        sMIDDLE = MIDDLE | 256,
        sRIGHT = RIGHT | 256,
        sEND = END | 256,
        sDOWN = DOWN | 256,
        sPGDN = PGDN | 256,
        sINS = INS | 256,
        sDEL = DEL | 256,
        sSP = SP | 256,
        sTAB = TAB | 256,
        sCR = CR | 256,
        sBS = BS | 256,
        sPAUSE = PAUSE | 256,
        sESC = ESC | 256,
        sCcedilla = Ccedilla | 256,
        sF1 = F1 | 256,
        sF2 = F2 | 256,
        sF3 = F3 | 256,
        sF4 = F4 | 256,
        sF5 = F5 | 256,
        sF6 = F6 | 256,
        sF7 = F7 | 256,
        sF8 = F8 | 256,
        sF9 = F9 | 256,
        sF10 = F10 | 256,
        sF11 = F11 | 256,
        sF12 = F12 | 256,
        sPrint = Print | 256,
        sMenu = Menu | 256,

        //ControlX keys
        cHOME = HOME | 512,
        cUP = UP | 512,
        cPGUP = PGUP | 512,
        cLEFT = LEFT | 512,
        cMIDDLE = MIDDLE | 512,
        cRIGHT = RIGHT | 512,
        cEND = END | 512,
        cDOWN = DOWN | 512,
        cPGDN = PGDN | 512,
        cINS = INS | 512,
        cDEL = DEL | 512,
        cSP = SP | 512,
        cTAB = TAB | 512,
        cCR = CR | 512,
        cBS = BS | 512,
        cPAUSE = PAUSE | 512,
        cESC = ESC | 512,
        cCcedilla = Ccedilla | 512,
        cF1 = F1 | 512,
        cF2 = F2 | 512,
        cF3 = F3 | 512,
        cF4 = F4 | 512,
        cF5 = F5 | 512,
        cF6 = F6 | 512,
        cF7 = F7 | 512,
        cF8 = F8 | 512,
        cF9 = F9 | 512,
        cF10 = F10 | 512,
        cF11 = F11 | 512,
        cF12 = F12 | 512,
        cPrint = Print | 512,
        cMenu = Menu | 512,

        //ModifierX keys
        mHOME = HOME | 768,
        mUP = UP | 768,
        mPGUP = PGUP | 768,
        mLEFT = LEFT | 768,
        mMIDDLE = MIDDLE | 768,
        mRIGHT = RIGHT | 768,
        mEND = END | 768,
        mDOWN = DOWN | 768,
        mPGDN = PGDN | 768,
        mINS = INS | 768,
        mDEL = DEL | 768,
        mSP = SP | 768,
        mTAB = TAB | 768,
        mCR = CR | 768,
        mBS = BS | 768,
        mPAUSE = PAUSE | 768,
        mESC = ESC | 768,
        mCcedilla = Ccedilla | 768,
        mF1 = F1 | 768,
        mF2 = F2 | 768,
        mF3 = F3 | 768,
        mF4 = F4 | 768,
        mF5 = F5 | 768,
        mF6 = F6 | 768,
        mF7 = F7 | 768,
        mF8 = F8 | 768,
        mF9 = F9 | 768,
        mF10 = F10 | 768,
        mF11 = F11 | 768,
        mF12 = F12 | 768,
        mPrint = Print | 768,
        mMenu = Menu | 768,

        //SystemX keys
        yHOME = HOME | 1024,
        yUP = UP | 1024,
        yPGUP = PGUP | 1024,
        yLEFT = LEFT | 1024,
        yMIDDLE = MIDDLE | 1024,
        yRIGHT = RIGHT | 1024,
        yEND = END | 1024,
        yDOWN = DOWN | 1024,
        yPGDN = PGDN | 1024,
        yINS = INS | 1024,
        yDEL = DEL | 1024,
        ySP = SP | 1024,
        yTAB = TAB | 1024,
        yCR = CR | 1024,
        yBS = BS | 1024,
        yPAUSE = PAUSE | 1024,
        yESC = ESC | 1024,
        yCcedilla = Ccedilla | 1024,
        yF1 = F1 | 1024,
        yF2 = F2 | 1024,
        yF3 = F3 | 1024,
        yF4 = F4 | 1024,
        yF5 = F5 | 1024,
        yF6 = F6 | 1024,
        yF7 = F7 | 1024,
        yF8 = F8 | 1024,
        yF9 = F9 | 1024,
        yF10 = F10 | 1024,
        yF11 = F11 | 1024,
        yF12 = F12 | 1024,
        yPrint = Print | 1024,
        yMenu = Menu | 1024,


        sPlus = plus | 128,
        sComma = comma | 128,
        sMinus = minus | 128,
        sPeriod = period | 128,
        sSlash = slash | 128,
        sAsterisk = asterisk | 128,


        //Control with standard
        cA = A | 512,
        cB = B | 512,
        cC = C | 512,
        cD = D | 512,
        cE = E | 512,
        cF = F | 512,
        cG = G | 512,
        cH = H | 512,
        cI = I | 512,
        cJ = J | 512,
        cK = K | 512,
        cL = L | 512,
        cM = M | 512,
        cN = N | 512,
        cO = O | 512,
        cP = P | 512,
        cQ = Q | 512,
        cR = R | 512,
        cS = S | 512,
        cT = T | 512,
        cU = U | 512,
        cV = V | 512,
        cW = W | 512,
        cX = X | 512,
        cY = Y | 512,
        cZ = Z | 512,
        c1 = D1 | 512,
        c2 = D2 | 512,
        c3 = D3 | 512,
        c4 = D4 | 512,
        c5 = D5 | 512,
        c6 = D6 | 512,
        c7 = D7 | 512,
        c8 = D8 | 512,
        c9 = D9 | 512,
        c0 = D0 | 512,
        cPlus = plus | 512,
        cComma = comma | 512,
        cMinus = minus | 512,
        cPeriod = period | 512,
        cSlash = slash | 512,
        cSemicolon = semicolon | 512,
        cEqual = equal | 512,
        cBracketleft = bracketleft | 512,
        cBracketright = bracketright | 512,
        cBackslash = backslash | 512,
        cAsterisk = asterisk | 512,

        //Modifier with standard
        mA = A | 768,
        mB = B | 768,
        mC = C | 768,
        mD = D | 768,
        mE = E | 768,
        mF = F | 768,
        mG = G | 768,
        mH = H | 768,
        mI = I | 768,
        mJ = J | 768,
        mK = K | 768,
        mL = L | 768,
        mM = M | 768,
        mN = N | 768,
        mO = O | 768,
        mP = P | 768,
        mQ = Q | 768,
        mR = R | 768,
        mS = S | 768,
        mT = T | 768,
        mU = U | 768,
        mV = V | 768,
        mW = W | 768,
        mX = X | 768,
        mY = Y | 768,
        mZ = Z | 768,
        m1 = D1 | 768,
        m2 = D2 | 768,
        m3 = D3 | 768,
        m4 = D4 | 768,
        m5 = D5 | 768,
        m6 = D6 | 768,
        m7 = D7 | 768,
        m8 = D8 | 768,
        m9 = D9 | 768,
        m0 = D0 | 768,
        mPlus = plus | 768,
        mComma = comma | 768,
        mMinus = minus | 768,
        mPeriod = period | 768,
        mSlash = slash | 768,
        mSemicolon = semicolon | 768,
        mEqual = equal | 768,
        mBracketleft = bracketleft | 768,
        mBracketright = bracketright | 768,
        mBackslash = backslash | 768,
        mAsterisk = asterisk | 768,

        //System with standard
        yA = A | 1024,
        yB = B | 1024,
        yC = C | 1024,
        yD = D | 1024,
        yE = E | 1024,
        yF = F | 1024,
        yG = G | 1024,
        yH = H | 1024,
        yI = I | 1024,
        yJ = J | 1024,
        yK = K | 1024,
        yL = L | 1024,
        yM = M | 1024,
        yN = N | 1024,
        yO = O | 1024,
        yP = P | 1024,
        yQ = Q | 1024,
        yR = R | 1024,
        yS = S | 1024,
        yT = T | 1024,
        yU = U | 1024,
        yV = V | 1024,
        yW = W | 1024,
        yX = X | 1024,
        yY = Y | 1024,
        yZ = Z | 1024,
        y1 = D1 | 1024,
        y2 = D2 | 1024,
        y3 = D3 | 1024,
        y4 = D4 | 1024,
        y5 = D5 | 1024,
        y6 = D6 | 1024,
        y7 = D7 | 1024,
        y8 = D8 | 1024,
        y9 = D9 | 1024,
        y0 = D0 | 1024,
        yPlus = plus | 1024,
        yComma = comma | 1024,
        yMinus = minus | 1024,
        yPeriod = period | 1024,
        ySlash = slash | 1024,
        ySemicolon = semicolon | 1024,
        yEqual = equal | 1024,
        yBracketleft = bracketleft | 1024,
        yBracketright = bracketright | 1024,
        yBackslash = backslash | 1024,
        yAsterisk = asterisk | 1024,
    }*/
}
