using ConsoleArchivist.Exceptions;
using ConsoleArchivist.Helpers;

namespace ConsoleArchivistTester
{
    public class TranslationHelperTests
    {
        [Fact]
        public void GetLangTagWith2Letters_Success()
        {
            //Arrange
            var content = @"
---
layout: quote
permalink: /en/
langtag: en
type: modern
script: Latn
langName: English
englishLangName: English
title: Decree of Pharaoh Ptolemy V inscribed on the Rosetta Stone
quote: Copies of this Decree shall be cut in hieroglyphs, demotic, and Greek on basalt slabs and placed in the first, second, and third-order temples alongside the statue of Ptolemy, the ever-living god.
reference: Decrees of Ptolemy V on the Rosetta Stone, 196 B.C., British Museum.
imageAlt: Coin with the face of Ptolemy V
selectAriaLabel: Select a language
buttonRandom: Random
direction: ltr
---";
            //Act
            var lanTag = TutHelper.GetLangTag(content);

            //Assert
            Assert.Equal("en", lanTag);
        }

        [Fact]
        public void GetLangTagWith3Letters_Success()
        {
            //Arrange
            var content = @"
---
layout: quote
permalink: /tlh/
langtag: tlh
type: fictional
script: Latn
langName: ""tlhIngan Hol""
englishLangName: Klingon
title: ""Ptolemy V ghaH ta'pu' QIn rosetta QInHomDaq qon""
quote: ""QInHom vI' rosetta Daq ghaH ta'pu' QIn 'oH chenmoHlu'pu'bogh, demotic, 'ej QrI'qa' Hol, basalt mIwDaq, 'ej ghaH ta'pu', Qun'e' SuvwI', mIw chu'wI', cha', wej, 'ej loS pongDajDaq chen.""
reference: ""Ptolemy V ghaH ta'pu' QIn rosetta QInHomDaq, 196 B.C., British Museum.""
imageAlt: ""mI'wI' 'ej wIy 'oPtolemy V""
selectAriaLabel: ""Hol DIl""
buttonRandom: ""lutuQ""
direction: ltr
---
";

            //Act
            var lanTag = TutHelper.GetLangTag(content);

            //Assert
            Assert.Equal("tlh", lanTag);
        }

        [Fact]
        public void GetLangTagWithDash_Success()
        {
            //Arrange
            var content = @"
---
layout: quote
permalink: /sr-Latn/
langtag: sr-Latn
type: modern
script: Latn
langName: Srpski
englishLangName: Serbian
title: Ukaz faraona Ptolemeja V upisan na Rozetskoj kamenu
quote: Kopije ovog ukaza biće isečene u hijeroglifima, demotiku i grčkom na bazaltnim pločama i postavljene u hramovima prvog, drugog i trećeg reda uz statuu Ptolemeja, večnog boga.
reference: Ukazi Ptolemeja V na Rozetskoj kamenu, 196. godine pre nove ere, Britanski muzej.
imageAlt: Novčić sa likom Ptolemeja V
selectAriaLabel: Izaberite jezik
buttonRandom: Slučajno
direction: ltr
---
";

            //Act
            var lanTag = TutHelper.GetLangTag(content);

            //Assert
            Assert.Equal("sr-Latn", lanTag);
        }

        [Fact]
        public void GetLangContentNull_Failed()
        {
            //Arrange
            string content = null;

            //Act
            //Assert
            var exception = Assert.Throws<ContentNullException>(() => TutHelper.GetLangTag(content));

            Assert.Contains("The translation cannot be null", exception.Message);
        }

        [Fact]
        public void GetLangContentEmpty_Failed()
        {
            //Arrange
            string content = "";

            //Act
            //Assert
            var exception = Assert.Throws<EmptyContentException>(() => TutHelper.GetLangTag(content));

            Assert.Contains("The translation cannot be empty", exception.Message);
        }

        [Fact]
        public void GetLangTagWithNoLangTag_Failed()
        {
            //Arrange
            var content = @"
---
layout: quote
permalink: /sr-Latn/
type: modern
script: Latn
langName: Srpski
englishLangName: Serbian
title: Ukaz faraona Ptolemeja V upisan na Rozetskoj kamenu
quote: Kopije ovog ukaza biće isečene u hijeroglifima, demotiku i grčkom na bazaltnim pločama i postavljene u hramovima prvog, drugog i trećeg reda uz statuu Ptolemeja, večnog boga.
reference: Ukazi Ptolemeja V na Rozetskoj kamenu, 196. godine pre nove ere, Britanski muzej.
imageAlt: Novčić sa likom Ptolemeja V
selectAriaLabel: Izaberite jezik
buttonRandom: Slučajno
direction: ltr
---
";

            //Act
            var exception = Assert.Throws<KeyAbsentException>(() => TutHelper.GetLangTag(content));

            Assert.Contains("No lantag was found in the translation", exception.Message);
        }

        [Fact]
        public void GetEnglishLangName_Success()
        {
            //Arrange
            var content = @"
---
layout: quote
permalink: /en/
langtag: en
type: modern
script: Latn
langName: English
englishLangName: English
title: Decree of Pharaoh Ptolemy V inscribed on the Rosetta Stone
quote: Copies of this Decree shall be cut in hieroglyphs, demotic, and Greek on basalt slabs and placed in the first, second, and third-order temples alongside the statue of Ptolemy, the ever-living god.
reference: Decrees of Ptolemy V on the Rosetta Stone, 196 B.C., British Museum.
imageAlt: Coin with the face of Ptolemy V
selectAriaLabel: Select a language
buttonRandom: Random
direction: ltr
---";
            //Act
            var englishLangName = TutHelper.GetEnglishLangName(content);

            //Assert
            Assert.Equal("English", englishLangName);
        }
    }
}
