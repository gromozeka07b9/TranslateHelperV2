﻿using System.Collections.Generic;

namespace PortableCore.BL
{
    public interface ITestSelectWordsView
    {
        void SetOriginalWord(string originalWord);
        void SetCheckError();
        void SetVariants(List<string> variants);
        void SetFinalTest(int countOfTestedWords);
    }
}