﻿using AdventOfCode.Year2024;

namespace AdventOfCodeTests.Year2024
{
    public class Day07Tests
    {
        [Test]
        public void GuardPath_CountAllVisitedLocations_ShouldSolveTestInput()
        {
            RopeBridgeCalibrator.FindSumOfTrueEquations(_puzzleTestInput).Should().Be(3749);
        }

        [Test]
        public void GuardPath_CountAllVisitedLocations_ShouldSolveInput()
        {
            RopeBridgeCalibrator.FindSumOfTrueEquations(_puzzleInput).Should().Be(538191549061);
        }

        [Test]
        public void GuardPath_CountAllVisitedLocations_ShouldSolveTestInputPart2()
        {
            RopeBridgeCalibrator.FindSumOfTrueEquations(_puzzleTestInput, true).Should().Be(11387);
        }

        [Test]
        //[Ignore("bit slow 3s")]
        public void GuardPath_CountAllVisitedLocations_ShouldSolveInputPart2()
        {
            RopeBridgeCalibrator.FindSumOfTrueEquations(_puzzleInput, true).Should().Be(34612812972206);
        }

        private const string _puzzleTestInput = "190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20";

        private const string _puzzleInput =
"590877201219: 9 985 5 9 7 8 76 8 174\r\n341481: 7 3 31 915 25 394 9 75\r\n4060: 4 35 47 1 3 5 4 3 8 1 895\r\n10555865325: 7 7 2 2 78 6 546 9 81 5\r\n589800341: 996 79 4 5 11 2 137\r\n499: 2 9 9 5 4\r\n14644280: 35 996 84 616 5\r\n58781: 2 5 4 337 6 7 3 1 4 7 3 6\r\n78542: 8 777 44\r\n75387319: 7 76 6 7 4 2 9 7 6 9 8 318\r\n156833006145: 2 87 6 1 6 23 8 898 1 47\r\n23407953580: 4 9 2 476 260 683\r\n16536082970: 50 836 40 3 989\r\n263150646: 30 22 2 72 87 5 1\r\n8008759260192: 3 35 9 3 46 10 7 83 32\r\n2988763: 82 185 8 149 3 65\r\n292548726: 2 4 7 4 4 2 9 9 7 5 38 27\r\n116759788099: 2 955 944 395 99\r\n3716625: 365 1 1 65 62 5 1\r\n1336614665: 5 2 11 72 102 943 9 7\r\n351364: 5 88 4 5 932\r\n306429: 54 242 8 8 42 3\r\n496581763: 926 71 9 944 8\r\n1004: 28 35 24\r\n729266593: 717 5 117 664 71 121\r\n57422: 543 15 16 18 7\r\n27069: 471 5 36 60 256 2\r\n140711341: 3 5 2 6 641 6 7 560 7 2 2\r\n47640974: 753 1 7 632 81 6\r\n22341061: 3 6 62 49 1 62 3 96 59\r\n111725316757: 8 50 32 88 92 3 694 85\r\n683490481804: 2 729 10 2 9 3 5 97 931\r\n694400: 5 8 42 8 3 3 222 6 8 7 16\r\n684786: 2 3 661 750 33\r\n26925082664: 597 451 40 342 664\r\n444150: 84 8 15 92 26 45\r\n675949120: 65 6 28 600 5 3 8 55 7 7\r\n151616887: 252 631 2 635 1 6 4 61\r\n4813038385: 8 3 486 6 12 2 9 381 1\r\n90386: 11 504 4 384 89\r\n4324782: 3 99 1 933 3 14 5 5 34 3\r\n1610070872006: 88 8 56 906 3 73 25 8 6\r\n61335: 9 99 7 1 4 68\r\n69422101008: 2 119 4 439 8 819 1 6 5\r\n1755533171: 637 448 6 3 459\r\n9464832: 574 58 39 8 48\r\n561077: 401 2 3 942 312 338\r\n498378: 41 8 52 31 75\r\n14072856: 82 3 9 40 65 6 76 4 4 4 6\r\n23920344397: 3 2 19 11 17 74 73 468\r\n4236348: 674 1 9 752 3 6 982\r\n34943027544: 8 30 1 421 27 544\r\n956229692: 2 665 6 346 204 46 89\r\n1291680: 4 15 598 9 4\r\n17406915: 29 6 1 2 4 6 484 4 9 1 9 6\r\n12804488: 34 3 3 45 1 76 8 4 5 3 8\r\n738024908: 7 8 5 1 5 8 15 828 5 6 71\r\n33610025552: 231 7 9 5 3 7 3 9 82 6 4 9\r\n184299: 2 9 8 94 975 2 7 1 6 4 3 1\r\n61568: 19 697 77 743 3 5 2 4 8\r\n8323590: 307 8 4 18 58 1 9 43 3 8\r\n31643: 4 520 7\r\n735: 5 147 1\r\n7734: 23 315 9 477 1\r\n25965018: 404 46 577 1 8\r\n381726414323: 1 377 9 7 55 5 3 8 9 7 2 5\r\n7198253075: 232 201 709 3 31\r\n67016589: 9 8 9 8 4 9 3 3 1 82 584 5\r\n93649: 153 6 9 91 855\r\n2121312276: 3 3 2 7 8 16 9 8 7 1 227\r\n1004: 38 62 799 97 8\r\n8288281798: 164 7 6 483 17 96\r\n75116813: 2 5 511 68 11\r\n112283: 27 8 8 40 16 5\r\n123687502: 46 33 9 9 9 502\r\n6287743044: 9 2 6 8 9 594 5 2 2 75 36\r\n914528962: 8 278 9 62 567 6 6 1 5 9\r\n26697895485: 169 29 4 256 7 84 2 66\r\n118181: 193 306 1 10 6 9 2 6 7\r\n4860404640: 221 750 520 464 9 7\r\n221863: 7 309 94 7 6\r\n34759: 6 5 49 6 5 365 44\r\n125066: 842 5 905 71 585 89\r\n75690824: 189 4 90 821\r\n777498: 37 57 5 7 6 638 9 606\r\n5365990302: 619 8 8 50 1 7 1 3 43 3 6\r\n89137440000: 93 6 9 6 6 67 7 8 3 7 75 4\r\n36190: 6 97 452 5 7\r\n97895519: 5 16 462 130 825 1 1 8\r\n6579: 55 51 6 6 1 7 6 920 703\r\n19: 9 2 1\r\n82236: 822 2 7 6\r\n458700698113: 764 492 9 6 98 107 4\r\n259798729602: 3 4 9 6 1 49 3 4 50 422 4\r\n432085: 9 60 8 8 3\r\n36186: 49 22 505 1 210 63 55\r\n433240464: 65 6 9 2 18 89 7 197 34\r\n1940: 1 9 38\r\n403135: 56 6 879 2 331 54 254\r\n578901186: 7 2 11 7 1 5 6 3 529 6 4\r\n4873227439: 115 25 332 411 439\r\n4244991173: 9 6 2 979 5 7 8 7 4 1 6 8\r\n244041445017450: 8 1 3 47 1 483 39 3 451\r\n7334: 848 531 5 65 6 368\r\n1031568: 1 9 3 148 8 5\r\n39537375: 73 2 453 524 6\r\n1799: 960 1 1 61 6 751 6 5 6 4\r\n19683930422: 3 20 3 44 194 466 17\r\n2992968: 150 4 68 1 682 80 6 8 9\r\n143489508: 851 98 56 27 6 60 48\r\n1633086: 595 3 2 7 39\r\n4102: 5 565 3 903 371\r\n132039052: 44 6 10 7 803 5 28 9\r\n219373058: 5 2 496 4 796 934 58\r\n1770060718141: 21 852 6 81 7 4 8 1 3 8\r\n27300370328021: 4 7 893 9 9 35 4 772 20\r\n5831145: 33 7 3 4 7 5 3 239 7 5 5 6\r\n5395959457: 7 8 35 6 2 6 5 9 5 938 7 7\r\n65113388: 1 4 4 255 3 8 3 7 9 3 7 2\r\n30758: 90 1 255 89 53\r\n63936847222: 1 7 7 718 963 1 3 9 53 4\r\n424436: 95 446 3 636 97\r\n42036: 7 60 20 13\r\n941772392: 941 7 723 9 2\r\n84578: 8 93 2 1 781 5 9 94 72\r\n127686: 44 402 2 536 7 47 54\r\n125107379: 8 4 862 31 4 4 8 4 87 92\r\n13639451: 2 81 8 894 692 13 9 14\r\n12501969064: 694 3 18 42 3 690 61\r\n8006402: 272 841 35 82\r\n134109600: 7 96 8 57 692 5\r\n133447951: 4 6 1 2 5 2 82 479 35 6 8\r\n3236693: 7 963 48 10 794 222\r\n1392: 6 23 9\r\n2821548757: 1 28 214 1 4 7 996 762\r\n268648831: 88 2 1 2 6 3 8 41 4 7 2 19\r\n426215: 6 2 7 6 976 1 3 8 4 420 2\r\n167947: 4 176 8 890 37 590 1\r\n631866547412: 9 702 66 54 740 9\r\n51984865: 8 550 9 77 93 7\r\n130026: 2 3 7 5 1 5 9 683 3 808 2\r\n1429: 9 26 8 4 39 456 762\r\n74596050960: 9 8 6 6 2 8 8 7 4 501 9 62\r\n15375262058186: 5 322 642 9 1 45 81 88\r\n10064773: 133 84 94 8 8\r\n3374281: 9 920 8 4 9 52 75 956 1\r\n12264: 17 9 4 8 4 9 957 76 339\r\n1890047: 2 5 315 731 487\r\n1441460: 8 86 5 21 99 713\r\n9149992: 9 149 943 44 7\r\n10214: 3 85 1 32 8 5 2 62 3\r\n64961897: 6 6 3 6 5 26 7 3 77 5 9 6\r\n2531533121: 305 83 2 815 496 8\r\n61290135: 58 1 781 45 132\r\n47866682: 182 2 423 615 2\r\n3485393: 3 345 45 8 90\r\n4981892069: 46 95 3 4 969 95 16\r\n333529: 2 36 97 527\r\n863393445: 1 7 578 778 8 1 4 1 5 3 1\r\n32473449120: 95 1 843 255 6 2 280 4\r\n12217522351598: 7 53 1 168 9 4 4 7 9 19 5\r\n9408614: 940 18 9 601 67 4 42\r\n2589967782: 6 2 6 6 598 656 4 778 1\r\n209019069622: 8 709 6 766 6 8 4 19\r\n75814: 2 1 41 916 481 224\r\n8183473443006: 89 2 6 79 3 69 707 58\r\n2266968172: 8 31 88 31 169\r\n59978: 10 40 28 969 8\r\n2570: 56 45 31 7 12\r\n1749230422: 860 836 811 3 742\r\n126071336759: 5 5 9 8 4 6 1 9 7 669 6 9\r\n25954985: 3 31 993 1 8 7 719 7 74\r\n10764846: 5 468 46 1 4 834\r\n76992: 1 9 86 3 9 30 1 6 7 23 1 5\r\n174302137: 584 9 2 13 149\r\n205096551780: 590 91 1 956 12 382 5\r\n753554337: 7 64 4 89 29 5 420 77 3\r\n1735904: 707 9 1 2 7 7 9 7 6 136\r\n590570235: 6 984 93 77 237\r\n75848896: 457 194 107 488 97\r\n3160356946606: 395 16 713 889 4 2 5 3\r\n5255049: 7 945 16 23 15 9\r\n43148557688: 1 867 90 28 1 7 5 33 7 7\r\n766118: 475 160 8 603 7\r\n822646826: 550 83 570 24 95 25 1\r\n46207080: 6 62 38 877 8 37 5 4 6 3\r\n29405645: 8 1 2 2 4 46 9 4 82 5 237\r\n3092868591: 39 5 3 261 913 946 4\r\n2889460045: 22 6 894 5 99 89 54\r\n693: 8 3 672 1 8\r\n397281130294: 5 877 5 4 234 781 3 3 4\r\n745312: 912 7 811 1\r\n322435163146: 3 223 5 8 515 1 314 3 1\r\n57393: 4 2 9 82 1 810 1 9 8 7 3 4\r\n956019806: 19 781 9 537 407 7\r\n7896459305: 789 645 927 4 31\r\n13345802: 25 58 63 92 7\r\n4036163600: 297 949 2 358 40\r\n262417795428: 877 3 697 53 3 8 7 25 9\r\n3727: 8 8 4 7 3 2 361 7 7 52 4\r\n217251: 6 9 2 7 7 1 78 73 1\r\n62405808392: 7 55 2 391 51 9 7 1 9 1 3\r\n4816: 4 27 6 3 32 5 7\r\n262: 215 29 16\r\n871: 9 777 85\r\n31355100: 656 9 46 252 5 35\r\n1107: 9 6 73 23 10\r\n549255168081: 86 8 16 1 9 9 88 70 78\r\n588201: 735 8 99 7 81 13\r\n83476167: 160 1 4 1 6 2 6 7 4 6 8 9\r\n2830: 210 1 70 2 3\r\n312766: 1 745 88 85 9 34\r\n498245: 653 39 8 90 5\r\n120400: 4 1 57 99 3 57 4 652 43\r\n181238: 181 18 42 752 6\r\n8595645176: 3 5 7 2 1 95 627 18 176\r\n63941249: 1 10 934 831 11 1 341\r\n222: 8 11 10 1 32\r\n648782: 879 37 43 973 67 7\r\n118832: 44 30 15 6 32\r\n473849: 4 39 77 41 2 7 36\r\n27720691: 688 4 92 8 5 2 75 5 4 8 3\r\n6960275411: 527 33 1 92 3 8 852 4\r\n896629360: 1 49 43 8 227 6\r\n742: 660 1 15 65 1\r\n73902349: 4 91 41 6 338\r\n10983281: 1 7 5 5 8 1 64 330 881\r\n4204579: 96 2 715 6 60 19\r\n582461: 939 1 57 146 4 798\r\n132639366: 172 41 896 695 6\r\n2349058: 59 4 2 987 1\r\n60891768227: 9 1 833 659 96 72 225\r\n304: 291 7 9\r\n57841: 2 89 13 6 2 2\r\n3780564840: 605 8 34 7 38 6 54 54 1\r\n7456: 7 215 61 649 8\r\n1935: 5 6 82 6 2 4 587\r\n240128427: 8 322 3 2 9 1 3 4 3 8 31 7\r\n432062477: 334 98 6 22 80\r\n4224726446: 238 71 6 5 5 73 3 444\r\n347487: 3 3 27 65 6\r\n1881036: 855 11 2 36\r\n13872472: 25 143 5 4 8 394 69 9\r\n227170245: 93 868 4 242 5\r\n1311858450: 889 7 7 4 83 4 7 35 9 2 1\r\n284211255: 70 302 4 938 754\r\n78885: 1 770 14 80 149 254\r\n4970590223: 71 70 590 22 5\r\n1602907: 78 87 82 45 2 11 96\r\n13841612: 9 967 7 493 197\r\n6794281800: 28 24 414 24 81 24 75\r\n3445: 53 3 4 7 26 2 5 8 27 529\r\n2153642498: 5 9 271 7 1 12 34 2 8 9 8\r\n1101127586: 71 284 2 31 7 584\r\n748: 2 1 82 2 578\r\n14912132: 590 35 532 704 6\r\n94380: 71 2 2 6 897 6 79 8\r\n374: 4 364 1 6\r\n573343848: 9 2 96 7 7 1 2 3 9 2 76 9\r\n88452868266: 402 8 764 6 711 6\r\n16067: 27 790 9 55 3 6 157 52\r\n36465214: 663 15 8 2 53 326 885\r\n121966181322: 5 61 28 53 7 2 1 41 2 8\r\n4837640: 567 7 24 312 34 8 1 3 3\r\n9556492: 1 4 940 3 6 2 639 1 6 4 4\r\n50007513650: 22 372 804 76 48 5 1\r\n43315: 4 5 3 5 5 1 9 2 3 5 28 87\r\n202771978716206: 5 1 334 67 8 5 7 8 790 9\r\n79852128: 7 737 43 52 2 6 8\r\n4147549908: 6 2 81 4 8 8 1 8 2 9 910\r\n200429752: 7 3 8 4 5 4 8 2 71 420 7 9\r\n225679: 6 781 48 1 750\r\n178161139: 99 7 5 6 4 53 514\r\n536762: 6 487 60 45 4\r\n38997: 55 6 7 7 9\r\n5829: 6 854 1 644 60\r\n25746433854: 2 27 640 578 77 6 4 5\r\n175809002: 34 4 8 60 7 47 5 66 500\r\n6980: 687 6 4 4 40\r\n369920: 41 9 924 40 8\r\n1624: 4 9 31 9 2 6\r\n9411309: 5 5 1 22 57 997 962 7 9\r\n667326108: 453 91 141 15 87\r\n1004698: 8 20 3 1 60 81 5 12\r\n36731761: 452 520 961 25 19 5 8\r\n58424832: 2 4 166 6 1 5 409 4 192\r\n120: 2 1 7 1 8\r\n36176974: 9 6 6 829 2 20 727\r\n107142489: 653 418 423 1 91\r\n2538: 3 2 80 8 27\r\n2096316498: 87 3 464 3 24 218 1\r\n1143187220466: 9 45 7 3 2 96 3 5 5 4 468\r\n2311353: 5 77 667 7 15 9\r\n2616546960: 4 6 4 3 7 19 6 8 23 4 180\r\n467450295: 2 241 46 4 2 8 4 8 6 1 3 6\r\n9970163: 436 1 3 676 7 5 11 4 9 1\r\n35850448667: 4 80 7 65 3 8 286 45 4 2\r\n569902155: 4 9 75 6 79 823 56 445\r\n117431: 75 52 77 7 4 3\r\n39762: 8 270 7 9 16 57 15 192\r\n65228: 104 9 9 61 693\r\n168936037718: 35 195 80 6 1 286 6\r\n10846807: 191 3 567 8 88\r\n107280: 7 81 2 17 280\r\n1328917: 6 1 3 91 253 58 2\r\n39225: 8 498 6 886 8\r\n423272592: 42 3 271 874 716\r\n12478726: 766 91 416 7 5 2 6 798\r\n2068614935396: 86 3 799 4 8 9 3 6 5 39 6\r\n3608786755: 9 513 1 6 8 9 5 4 768 8 4\r\n214825563: 397 825 1 1 1 2 3 1 9\r\n1577: 54 3 6 72 6 137\r\n265199760167: 29 39 4 3 6 632 8 9 1 6 8\r\n4832712: 6 20 866 9 432\r\n388203616: 462 14 69 28 3 223\r\n838702483053: 19 3 776 3 7 8 290 15 3\r\n8353141: 85 332 74 4 14 3 4\r\n805660234766: 33 9 3 9 72 8 7 84 471\r\n49483708029: 39 9 9 3 2 1 3 7 54 3 62\r\n8892416966: 49 1 9 20 72 413 3 9 66\r\n6336692: 1 4 2 9 88 519 88 9 73\r\n45323953: 4 272 8 7 462 4 7 2 3 5 5\r\n1656480: 22 2 2 4 5 4 7 5 5 238 3 2\r\n1885042369: 231 85 858 4 3 8\r\n70734: 70 659 76\r\n451366: 8 9 9 73 653 6 8 7 1 7 2 5\r\n393595517955: 9 632 871 35 1 4 511 3\r\n999: 9 8 6 6 7\r\n336677287334067: 879 99 977 66 23 4 5 6\r\n760635: 4 3 60 245 391\r\n130284: 8 2 83 658 2\r\n2404653: 528 897 979 64 5 8\r\n681300892: 71 94 9 656 561 5 7 6 4\r\n1604729427: 73 86 408 369 8 3 84 8\r\n6976026652: 5 811 2 35 3 1 45 4 85 2\r\n15162053: 1 153 6 2 95 380 50\r\n1787623976242: 798 473 3 8 6 95 592\r\n66792649: 1 78 934 66 588 60\r\n8106810: 255 8 2 1 3 4 9 9 6 8 93\r\n785870580: 3 745 37 870 5 80\r\n585080: 68 717 2 6 8\r\n6453586: 383 337 6 5 8\r\n37391642512: 4 245 2 776 3 450 52 5\r\n621878912: 5 4 727 3 6 8 1 915\r\n33622021: 7 85 7 79 89 36 27 522\r\n18663545806077: 896 165 649 234 89\r\n7478552: 1 73 88 90 289 264\r\n193124594589: 965 62 297 296 2\r\n851168884: 2 16 8 5 9 71 4 4 3 1 884\r\n201303846: 38 293 1 49 2 8 2 1 94 9\r\n19384474050: 6 3 8 2 53 3 447 40 47 6\r\n101416182: 4 1 7 6 712 8 546 5 4 76\r\n1389457: 52 668 40 1 16\r\n62222885: 59 9 22 9 2 68 5 55 85\r\n157550163508: 6 95 2 3 274 163 505\r\n1194: 74 824 72 1 223 3\r\n47245667: 4 15 325 5 36 5 3 76 42\r\n14656583414: 1 3 1 65 583 75 25 9 11\r\n100928239: 6 46 957 28 23 8\r\n28737516: 5 19 5 278 7 4 2 5 1 5 9\r\n319611572280: 5 39 9 585 6 307 749\r\n1087345979: 10 7 8 5 80 8 43 2 977\r\n5670810053865: 9 601 7 4 5 99 9 947\r\n4785796947: 4 6 4 9 8 21 8 6 618 1 8 4\r\n5583960: 926 5 950 5 34 55 1 8\r\n6593: 1 5 8 5 97 8 7 2 257 1 13\r\n557119332: 363 121 14 906 1\r\n115695268: 964 12 788 738 5\r\n148681847648411: 743 4 5 461 9 121 4 13\r\n598955: 2 32 47 319 953 2\r\n5322245312: 66 96 84 530 9\r\n11637274559: 2 8 4 9 9 9 381 787 146\r\n24562136: 537 8 6 50 571\r\n26208: 246 320 5 82 9\r\n105736523: 71 7 2 9 2 64 7 88 1 641\r\n44037634342: 6 1 1 9 2 708 1 1 1 4 341\r\n26535: 7 39 538 878 912\r\n3815734: 381 57 27 7\r\n6998128: 699 41 2 398 3 28\r\n643469713261: 233 3 84 9 5 4 6 493 6 3\r\n1153089117: 28 91 67 184 2 5 393\r\n87211006: 25 114 34 75 33 9 25 9\r\n28171737697: 4 4 9 7 98 7 9 1 3 99 697\r\n1394607205: 5 6 841 628 1 7 5 2 16 4\r\n3404811221: 3 399 5 811 224\r\n3849330: 3 3 3 6 9 296 7 92 8 4 8\r\n617623508: 2 56 3 762 351 1\r\n14853187: 674 146 671 328 22\r\n1454: 3 9 3 487 90 50 797\r\n8962405: 448 2 188 1 525\r\n259572: 706 367 74 362 34\r\n2779245985: 3 441 45 3 7 986\r\n296: 9 9 151 1 63\r\n55496: 1 10 544 9 5\r\n144484: 304 471 9 790 498 3\r\n41910660: 51 83 37 3 99\r\n52391086: 9 688 8 846 1\r\n2689350: 6 297 3 6 3 493 2 8 7 8 6\r\n115312: 11 5 3 1 4\r\n124: 2 52 1 7 2\r\n1619708377122: 74 435 8 8 4 8 84 68 1\r\n1012786558572: 5 316 6 78 36 7 3 6 7 7 3\r\n18705: 59 4 8 222 63 3 8\r\n5427163016: 859 9 90 78 10 18\r\n130598: 53 67 47 782 4\r\n5303900187: 8 52 456 699 40 27\r\n548152: 6 4 802 25 3 1 3 3 9 3 7 9\r\n5703654827: 97 9 1 97 913 8 6\r\n941392235: 67 8 6 9 2 129 5 7 7 5 6 6\r\n17002440: 5 1 9 1 4 4 7 5 7 9 52 30\r\n1832216: 192 679 503 2 7 21\r\n10092595635: 96 1 7 1 7 1 3 207 1 5 8 7\r\n93223: 93 831 3 31 2 8 470 1\r\n104178948: 6 868 9 474 2\r\n60571: 60 4 73 4 94\r\n16135488: 21 409 6 9 8 514\r\n61341829: 69 889 74 8 6\r\n222710400: 9 1 76 74 8 495\r\n97147: 7 7 96 286 5 45 172\r\n9371290: 1 10 860 914 985\r\n510996: 29 27 5 768 421 5 93\r\n95890474420: 95 88 9 5 9 7 39 45 476\r\n1584: 111 70 27 602 98 676\r\n69285328043: 69 2 1 8 526 6 80 34 2 7\r\n77406525462: 48 378 6 8 38 26 1 31 2\r\n53638: 8 638 83 4 5 8 3\r\n89682: 3 96 90 2 583\r\n38950: 1 2 67 48 56 6 6 1 6 9\r\n147192243: 696 35 162 10 6 245\r\n5875749569: 8 9 30 2 6 91 574 9 571\r\n86094936075: 6 94 3 140 124 76\r\n831: 5 1 89 729 9\r\n209738679: 98 2 5 198 183 2 6 680\r\n622617586: 108 6 6 3 1 57 7 8 9 796\r\n36002: 49 19 57 72 4 2\r\n70185240486: 618 4 80 61 507 7\r\n133062: 97 35 858 9 197\r\n673138: 5 4 3 9 763 7 6 29 143 1\r\n5354409: 9 6 47 555 322\r\n21: 7 6 9\r\n2985: 496 90 8 3 5\r\n134744: 49 83 8 9 9 5 53 82 9\r\n21136: 9 56 4 40 40 2 1 9 764\r\n34359: 5 4 23 6 72 807\r\n590700448: 587 26 82 472\r\n4656: 236 55 8 2\r\n2091397218: 433 483 71 39 68 8\r\n30253359: 35 3 7 75 9 33 2 5 2 5 57\r\n368680312: 367 7 73 907 315\r\n27669457: 27 603 66 457\r\n1909598: 57 5 67 72 29\r\n363584496: 9 5 42 226 37 503 6 4\r\n1695: 8 2 25 70\r\n75459782: 78 297 2 4 5 9 780\r\n396365711: 22 67 445 31 5 709\r\n4227: 6 694 47 1 16\r\n193414: 42 98 45 4\r\n178472020519: 6 297 5 8 85 102 2 69\r\n2356070: 1 271 2 34 858\r\n297355331: 887 5 1 335 44 4 489 4\r\n275421342: 5 918 3 1 550 7 6 1\r\n3931: 2 7 924 79 9 3 851 2\r\n844164: 991 1 4 50 27 1 786\r\n41294252: 4 12 942 20 4 30\r\n251642899052: 54 75 2 589 6 766 6\r\n18494: 3 4 6 4 6 6 1 5 2 77 717\r\n4448239240: 8 4 8 6 3 524 3 237\r\n1303: 58 1 732 4 5 3 2 83 415\r\n39780279: 9 68 7 2 68 94 3\r\n55590: 17 8 8 2 51\r\n6708163529: 670 81 541 79 1 15 29\r\n1430317: 6 1 86 92 4 14 89 1 57 2\r\n369: 4 87 13 2 6\r\n188043537614: 967 8 2 4 6 6 633 80 3 9\r\n1043: 37 59 46 7 7\r\n1058627808: 2 8 75 440 8 92 7 3 25 9\r\n2258503303: 43 9 1 257 764 641 9 2\r\n4321966143: 432 196 5 911 232\r\n378672480215: 7 9 5 5 6 1 3 8 96 5 2 16\r\n61080272022: 1 191 460 79 88 22\r\n306296408: 2 6 51 55 4 1 9 1 3 78 5\r\n379989863177: 654 9 634 7 69 904\r\n46216845635: 649 104 9 712 34\r\n963: 42 95 1 7 4\r\n366029: 4 54 2 50 199 440 589\r\n352032: 7 7 1 179 2 2 3 6 5 7 813\r\n5312011266: 40 8 22 6 40 1 7 4 1 53 5\r\n4022967: 5 7 4 782 49 70\r\n28435262: 2 8 1 4 4 7 7 8 3 442 84 1\r\n1694589: 429 957 26 1 6 12\r\n20192882: 1 81 916 37 68 3\r\n5585510298369: 70 644 852 47 9 29 32\r\n449126029511: 590 170 8 751 761\r\n2685843: 58 9 3 667 6 5 26 2 43\r\n1061506: 39 31 5 3 9\r\n291029855: 5 1 485 247 51 5 8\r\n20727882975: 4 473 7 662 978\r\n55904160038049: 467 8 55 869 1 32 679\r\n4015421905: 4 187 202 3 25 70 70 6\r\n479990: 2 101 44 54 38\r\n210045090: 694 3 5 45 8 275 5 1 73\r\n19759927905: 1 6 343 8 4 9 9 15 7 90 2\r\n67111: 49 81 33 1 782 8 14 9\r\n441928: 6 3 1 33 7\r\n11171760: 75 3 432 9 94 9 9 963\r\n4991508: 10 843 74 1 8 757 183\r\n425042235: 420 4 56 221 10 1 81\r\n62161: 538 71 30 4 239 991\r\n2725764: 42 6 10 3 8 75 45 789\r\n11173464936742: 6 8 9 7 2 1 6 9 312 2 48 3\r\n11978613: 934 3 272 47 5\r\n594683457: 88 506 14 54 345 4\r\n660: 83 498 76\r\n490497802406: 70 7 497 802 409\r\n5440724: 7 1 4 9 160 317 9 3 75\r\n19985: 3 79 2 9 784 10 422 2 1\r\n102695426: 999 53 10 967 24\r\n151408: 70 4 28 2 280 4 36 5\r\n2712720: 98 8 996 508 3\r\n122880: 50 38 8 6 6 64\r\n6229710: 4 7 2 788 2 959 8 37 1 9\r\n19658825: 57 2 34 98 23\r\n28160630: 4 273 3 32 9 8 5 2 6 2 7 5\r\n591140433: 67 63 62 874 44\r\n60896: 5 12 1 889 8\r\n94197: 1 93 415 782 1\r\n62: 5 1 17 9 30\r\n7622540: 8 84 158 458 5 2 254\r\n140652520: 5 5 8 7 6 58 5 7 3 1 81 41\r\n983263: 422 585 9 769 63\r\n32107: 3 8 3 953 11 180 467\r\n2122597: 212 2 27 5 9 313\r\n3600598: 5 5 36 150 4\r\n839022336: 531 205 142 892 9\r\n7853: 7 4 23 7 22\r\n74556: 21 355 5\r\n6519534705375: 3 4 40 848 8 21 652 88\r\n596866566: 6 7 8 9 6 1 5 489 1 4 5 34\r\n4194599: 4 9 9 1 6 8 69 9 9 9 2 689\r\n186052032: 4 211 338 9 96\r\n491053582121: 914 3 7 765 821 18\r\n259: 3 29 5 7\r\n148635877: 29 5 41 435 25\r\n7357400: 884 208 7 56 40\r\n1247536694: 1 3 5 374 9 1 460 33 8 9\r\n5242752494530: 97 9 79 20 824 14 6 45\r\n33841: 79 7 5 226 7 6 908 5\r\n1017708422: 234 49 7 86 8 258 62\r\n17063: 6 64 322 4 77 1 60 1\r\n2458291: 245 823 6 1\r\n1858104: 671 460 2 974 41 7 6\r\n3981306130: 8 250 8 8 2 6 5 9 6 3 4 31\r\n33108: 869 3 37 847 1\r\n324328158: 990 13 2 33 126\r\n150610: 3 86 4 3 8 2 74 1 7 5 903\r\n59551331753: 4 248 52 2 6 3 8 749 4\r\n11392: 1 21 5 6 509 3\r\n35886972295: 260 8 9 382 1 3 639\r\n1195518239: 355 807 3 6 16 70\r\n390263415: 58 81 79 3 84\r\n43719425980686: 67 677 130 646 688\r\n38806776535: 808 465 8 6 9 8 538\r\n11108160581: 81 147 12 812 116 5\r\n62188: 79 1 777 8 20\r\n4328338: 8 541 338\r\n767871302: 1 45 7 91 594 471 959\r\n48307625: 96 6 5 762 7\r\n25845765120: 18 5 898 609 768 60\r\n4920993: 6 69 89 30 990\r\n2009844728: 9 8 2 3 600 57 5 5 4 6 3 5\r\n16262: 8 8 327 3 526 40\r\n102649613987: 9 1 7 1 8 2 746 10 7 48 8\r\n62832: 7 8 3 1 40 25 35\r\n546770312: 69 3 1 3 8 2 3 5 3 871 6 1\r\n995210: 4 6 88 4 13\r\n27764: 96 63 43 9 38 57 4\r\n6596051: 659 5 826 76 151\r\n1696: 4 4 96\r\n76387474: 29 3 878 885 589\r\n887958: 265 9 62 7 1 6 76 620\r\n239447: 604 98 37 3 9 4 2 3 5\r\n5171959300066: 3 48 406 194 57 5 8 67\r\n1798335: 3 39 7 69 3 845 99 3 5\r\n665214448: 665 202 4 8 447\r\n7050: 6 2 2 89 560\r\n5828: 3 3 2 656 36 2 3 3 8 4 92\r\n49296672: 77 64 6 1 9 6 73\r\n448659113757: 594 219 5 363 416\r\n28490582: 74 964 38 426 3\r\n908714: 80 10 248 623 1\r\n441207837: 459 5 9 15 96\r\n3122771: 389 4 8 38 7 86 2\r\n4664: 7 4 748 6 9\r\n14799610652: 881 139 646 26 8\r\n79002161: 9 1 17 7 5 956 9 3 8 6 9\r\n24535779: 385 3 7 7 5 9 6 70 3 4\r\n774464: 2 3 8 6 39 9 53 5 8 656\r\n86843: 315 3 350 130 3\r\n7373481: 1 78 6 62 69\r\n821633561721: 5 25 2 4 1 8 977 2 9 722\r\n42373933703: 5 9 7 2 8 741 7 4 2 1 1 92\r\n14065359: 3 50 4 25 57 12 52 3\r\n615099: 4 27 2 3 9 1 8\r\n4561880: 569 8 4 35 8\r\n1274: 418 551 1 2 264 38\r\n1526839: 9 3 70 193 733\r\n779652: 326 1 8 985 5 1 4 5 9 6 9\r\n595317104: 92 59 61 6 7 2 6 6 6 76 4\r\n2523150: 38 7 30 89 21\r\n13263: 3 62 2 70 6 97\r\n3728386: 9 47 4 1 62 1 1 43 65 22\r\n3432857: 8 429 8 5 9\r\n476343664267: 42 31 836 48 57 9 94 6\r\n255870: 90 9 9 642 29\r\n4900956092109: 699 8 3 36 5 4 4 458 7 7\r\n818241: 358 72 25 19 769\r\n555645818638: 5 90 8 58 5 81 85 4 7 91\r\n95396: 5 6 8 190 199 3 2 8 9 7 6\r\n809185020: 1 734 98 41 274\r\n194875: 3 121 534 54 980\r\n3564788: 5 94 126 1 6 30\r\n9241712: 2 7 225 53 86 10 8 74\r\n5769566: 2 8 6 6 77 4 75 107 6 1\r\n11480278754: 68 2 164 27 86 85 67\r\n55692: 4 98 7 6 13\r\n216953: 18 12 955\r\n307145445609: 78 313 474 53 7 74 64\r\n446713: 2 84 716 557\r\n1629146995: 264 4 4 2 1 2 3 7 5 8 44\r\n25569836: 8 1 7 8 3 4 47 9 736 3 5 9\r\n6437873153: 5 6 4 594 2 6 9 664 8 8 1\r\n719037270: 28 3 9 7 8 51 69 695\r\n49498478570: 6 1 4 525 95 898 2 84 1\r\n26544258088721: 408 373 2 65 7 1 87 2 2\r\n651847677: 145 175 88 9 643 4\r\n2130440: 8 3 11 41 250 3 680\r\n6372: 69 57 5 7 1\r\n42364964: 62 948 537 770 78 44\r\n236043: 686 49 5 89 7 86\r\n93309627778: 43 1 1 989 24 9 3 77 7\r\n18465: 251 69 966 4 4 12 160\r\n20058194459: 9 97 25 6 9 3 9 35 3 9 3 9\r\n22540578: 9 709 7 46 9 3 4 28 2 1 6\r\n76804489172: 8 960 3 6 8 8 9 16 8 5 1\r\n37315111728: 84 15 4 649 248 1 46\r\n2099244933: 33 3 4 394 3 4 904 1 31\r\n5788323: 23 54 5 69 7 21\r\n28236624: 86 61 6 7 2 16 2 1 4 6 8\r\n1313564365: 84 3 159 18 98\r\n757: 8 91 29\r\n11800: 1 1 802\r\n452490301161: 878 62 1 944 515\r\n2990297456: 7 3 59 8 5 2 9 74 1 53\r\n66006075241: 3 4 64 5 5 20 92 2 7 5 7 3\r\n71271389: 5 277 7 2 3 7 4 75 7 1 9 5\r\n24291: 32 4 11 72 77 96\r\n86163645: 8 97 53 8 96\r\n8392581117: 88 61 76 786 939 66\r\n373836672: 1 3 9 4 409 8 848 792\r\n1417505625: 6 31 687 6 374\r\n6470100: 3 72 6 4 9 1 553\r\n270: 7 6 4 2 5\r\n1432399648684: 8 8 89 7 231 93 520 9 2\r\n7114565: 7 3 3 46 97\r\n1580299: 7 52 7 1 744 8 177 45\r\n99294: 7 4 8 2 6 8 90 7\r\n110: 8 6 1 48 10\r\n6450588963334: 82 284 99 783 6 333 1\r\n15008: 27 3 53 3 383 32\r\n5704417: 67 92 59 608 699 70\r\n66464462: 5 5 2 2 59 3 5 74 2 2 9 1\r\n426712: 74 220 71 1 61 26\r\n803: 91 307 385 4 16\r\n102173848: 6 9 5 6 940 7 3 827 24\r\n1638256836: 409 1 4 63 5 5 4 2 2 2 3 6\r\n4428018648: 204 1 216 185 62 85\r\n2228269601: 91 171 45 8 8 90 904 3\r\n277540661734: 3 98 32 5 79 59 734\r\n12670: 872 20 375 1\r\n1216423: 47 527 56 7 7\r\n502212: 68 50 25 73 337\r\n1730465056: 986 587 15 110 59\r\n638559: 2 50 329 4 419\r\n136631196394: 3 2 8 7 6 6 54 913 2 753\r\n84170763: 2 2 425 2 30 7 9\r\n13421696: 83 89 52 159 44 8 55 3\r\n808201: 23 488 1 8 9\r\n88960833: 414 9 623 21 4\r\n1217735408: 826 63 8 5 6 7 234 99 8\r\n671300261: 9 5 9 14 50 259\r\n44644370: 330 555 8 56 9 4 6 7 1 1\r\n7517938: 3 6 2 4 20 58 4 5 54 57 1\r\n132: 30 3 3 19 5 9\r\n333479: 1 3 201 387 280\r\n12096715360: 1 6 126 6 71 535 9\r\n3585279167: 71 61 9 5 432 4 5 1 6 3 7\r\n57353: 16 468 79 7 95 3 3\r\n1275887: 8 337 77 8 92 34 6 5 6\r\n1262728: 3 3 4 9 1 1 514 44 2 2 1 8\r\n1073500: 566 59 6 286 16 978 6\r\n13086888523: 81 3 69 9 6 221 99 45\r\n7232: 15 318 2 3 54 2\r\n10945041: 986 111 9 35 3\r\n63462422: 9 402 70 67 22\r\n387968229: 63 92 74 6 822 5 3\r\n39655: 159 3 971 7 5\r\n4811134: 1 6 60 748 96\r\n4882688: 8 480 268 5\r\n7286: 3 2 291 5 11\r\n40082445503: 8 275 702 69 27 476\r\n15464: 4 550 9 7 1\r\n10750553322: 413 48 282 26 2\r\n1569941232997: 941 60 23 8 8 25 40 49\r\n7408: 6 9 4 5 5 6 8 914 8 16 50\r\n54432: 407 1 97 6 18\r\n1474838566: 73 741 920 8 2 7\r\n7170164160: 841 214 4 996 2\r\n509285509: 427 3 4 405 97 731 2\r\n284618201: 5 431 310 6 407 1 71 4\r\n9728716074: 6 869 8 2 398 3 7 582\r\n564880555: 3 87 923 68 45 54\r\n598: 6 5 2 4 9 8 6 95 245 1\r\n586932: 58 6 592 324 6 9\r\n2193899545: 98 87 71 6 208 1 604 9\r\n2836770: 830 261 26 1 70\r\n394334517187: 5 6 5 5 13 4 8 764 23\r\n10765: 492 6 2 767 79 8\r\n167839818: 4 2 815 1 46 746 258 4\r\n201714977: 14 408 2 317 1 7 758\r\n142: 32 5 35 4 66\r\n140659203186: 72 370 66 8 30 93 92\r\n3787386567: 5 188 5 1 73 2 559 8\r\n5352640: 3 16 3 950 8 3 1 688\r\n23236875956: 2 9 34 5 45 5 85 6 9 9 59\r\n7786061171: 4 1 3 5 8 9 4 9 6 6 423 87\r\n2361736314: 1 36 9 28 831 49 7 17\r\n10066686244863: 8 7 8 6 3 7 3 672 834 66\r\n15643152: 9 9 366 57 56 6\r\n1478892934: 53 9 642 2 3 7 7 293 7 1\r\n9366820: 9 349 1 7 8 2 816 4\r\n206191: 694 2 982 87 1\r\n22831500: 5 925 982 5 5\r\n17122508: 364 1 6 5 3 9 1 6 1 52 59\r\n11308680: 1 4 24 37 4 4 1 566 5 6 9\r\n11784: 974 12 96\r\n752177: 4 9 3 21 1 9 9 996 3 7 9 9\r\n478615: 478 315 242 2 56\r\n1805023: 8 2 2 2 488 481 1 2 3 92\r\n198940: 6 631 3 7\r\n5763734: 960 612 6 49 11\r\n67926: 9 51 7 164 765\r\n766583: 3 754 9 5 85\r\n421852: 4 257 9 41\r\n12361838487: 515 4 2 61 283 6 5\r\n7901: 21 768 9\r\n1758: 766 31 22 60 2\r\n96937597: 91 5 937 594\r\n2247652915: 47 864 615 5 8 9\r\n11004556166: 11 267 8 16 2 488 6\r\n10613252: 149 48 738 1 73\r\n3854: 6 6 1 60 3 77\r\n256528: 1 27 4 8 36 6 9 7 8\r\n60876279: 2 5 78 169 463 75 37\r\n569727271: 560 9 7 272 72\r\n35508: 779 22 546 63 7 2\r\n189229180: 2 3 80 22 24 5 1 78\r\n28582830: 948 95 658 35 740 9\r\n9630: 3 5 601 7 2\r\n1552791240: 973 465 11 8 39\r\n48506850: 156 7 2 4 758 3 522 5 9\r\n41769051: 663 70 9 3 5 16\r\n52058: 97 27 419 3 5 94\r\n224060: 5 8 56 3 6 25\r\n25784: 85 609 36 1 799\r\n21211654: 265 4 58 2 54\r\n50704: 269 237 1 9 5\r\n78384: 86 9 94 8 873 9\r\n33453: 7 34 450 68 56 9\r\n629445337: 27 79 1 713 295\r\n37698877440: 302 9 7 172 3 4 960\r\n2306: 5 3 4 72 2\r\n1902864298: 779 86 244 4 54 99\r\n97546534: 6 8 2 1 6 9 9 6 997 4 9 4\r\n55651121155: 4 7 6 4 7 1 175 7 48 797\r\n85969834364: 9 513 8 9 9 648 4 57 7 6\r\n2399485184: 227 1 128 485 165 19\r\n1600106: 5 137 7 7 4 8 45 968\r\n1768050938: 5 6 8 2 4 8 5 1 7 77 3 7\r\n261477770026: 1 162 3 324 46 2 6 7 75\r\n124551: 46 71 7 65 659\r\n7360000110: 1 34 266 25 736 110\r\n3763620: 6 6 617 3 93 26 4 4 4 9 4\r\n101736: 7 4 9 6 2 5 6 67 6 68 65 6\r\n1544: 8 9 626 143 8 679\r\n61814592717: 135 124 393 783 12\r\n1190233: 4 5 22 986 1 1 27 6 3 8\r\n878475: 3 3 8 4 1 2 1 1 5 103 4 74\r\n152674956: 34 2 60 43 84 417\r\n948935145: 8 259 1 4 7 8 6 9 5 1 63 2\r\n2590109: 5 834 621 464 75\r\n1218360: 3 21 55 923 1\r\n2893245317: 7 201 4 7 680 2 57 6 9\r\n13734971359: 4 5 77 7 9 123 8 4 9 4 6 6\r\n150780: 207 9 2 1 91 77 1 86 4\r\n5125789: 1 284 6 95 3 7 285 901\r\n13267368: 24 69 95 6 93 15 8 7 1\r\n436128: 3 817 537 61 664\r\n52277926: 50 689 734 854 91 9 5\r\n27736: 6 9 5 47 6\r\n80388: 5 8 9 695 99\r\n76368: 5 20 8 30 29 83 7\r\n39090: 3 29 8 4 7 630 5 5 70 1 4\r\n9799459400: 48 994 8 24 962 8 4 5\r\n2835518: 48 59 3 1 4 21\r\n657763085: 1 9 33 4 8 9 79 70 9 35\r\n273865679: 7 6 6 9 4 6 199 1 8 990 4\r\n173337: 9 897 6 19 5 6\r\n465640352: 6 9 8 9 6 74 5 936 1 6 3\r\n8355185149214: 83 46 9 1 85 14 9 215\r\n3273008: 3 827 492 665 8 808\r\n2154849: 1 41 8 31 437\r\n38944925: 59 6 4 653 4\r\n1751852: 3 3 905 8 20 95 28 24\r\n4381: 36 12 1 54 6\r\n23017632: 8 27 41 516 307 8\r\n14593: 220 2 33 2 71\r\n2571008: 3 949 6 9 5 1 1 57 1 9 1 1\r\n20887367880: 9 2 9 541 9 1 3 5 7 8 355\r\n38042064: 36 6 268 96 9\r\n5647886509: 3 1 6 848 6 9 59 837 3\r\n13639: 8 2 3 1 32 4 99 7 1 4 397\r\n20530114: 88 224 4 813 98 5 4 4 4\r\n320: 4 56 96\r\n879215047: 4 8 4 2 9 3 8 841 4 198 7\r\n41374: 1 3 1 57 4 4 5 6 9 8 227\r\n71557700: 746 9 2 5 1 761 8 6 7 7 4\r\n13448009: 71 7 8 27 74 12\r\n265082680: 2 9 1 9 67 3 8 8 6 241 8 4\r\n79661: 28 3 3 2 314 9 28\r\n49842363: 17 18 7 29 65\r\n353560953: 9 549 4 63 37 50\r\n179089654066: 29 224 813 766 8\r\n13504695: 2 4 7 523 47 2 1\r\n207932: 8 8 7 3 890 227\r\n41953: 89 2 461\r\n266192390: 26 810 78 12 99\r\n90301815: 2 88 301 805 8\r\n58819003770: 5 84 80 655 3 717 51\r\n85165026225: 6 70 5 8 25 2 262 24 3\r\n388: 5 85 2 14 2";
    }
}